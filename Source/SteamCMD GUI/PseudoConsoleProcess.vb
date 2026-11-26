Option Strict On

Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports Microsoft.Win32.SafeHandles

' A console program attached to a pseudoconsole (Windows 10 1809 or later). It writes, asks and reads as in its own
' window, with a pipe SteamCMD keeps its output until it ends and ignores the input.
' Two background threads fill a queue and the form empties it with a timer: nothing here raises events or uses controls.
Friend NotInheritable Class PseudoConsoleProcess
    Implements IDisposable

    Private Const MaxPending As Integer = 262144
    Private Const DrainTimeout As Integer = 3000
    Private Const CloseTimeout As Integer = 5000

    Private Shared ReadOnly Supported As Boolean = GetProcAddress(GetModuleHandle("kernel32.dll"), "CreatePseudoConsole") <> IntPtr.Zero

    Private ReadOnly Gate As New Object()
    Private ReadOnly Pending As New StringBuilder()
    Private Input As FileStream
    Private Output As FileStream
    Private Console As IntPtr
    Private Job As KernelHandle
    Private Process As KernelHandle
    Private Reader As Thread
    Private Waiter As Thread
    Private Draining As Boolean
    Private Finished As Boolean
    Private Code As Integer

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property IsSupported As Boolean
        Get
            Return Supported
        End Get
    End Property

    ' True when the program has ended and all its output is already in the queue. Read it before TakeOutput.
    Public ReadOnly Property HasExited As Boolean
        Get
            SyncLock Gate
                Return Finished
            End SyncLock
        End Get
    End Property

    Public ReadOnly Property ExitCode As Integer
        Get
            SyncLock Gate
                Return Code
            End SyncLock
        End Get
    End Property

    ' PlatformNotSupportedException: there isn't a pseudoconsole. Win32Exception: the program can't be started.
    Public Shared Function Start(exePath As String, arguments As String, folder As String, columns As Short, rows As Short) As PseudoConsoleProcess
        If Not Supported Then Throw New PlatformNotSupportedException()
        Dim session As New PseudoConsoleProcess()
        Try
            session.OpenConsole(columns, rows)
            session.OpenJob()
            session.Launch(exePath, arguments, folder)
            session.Reader = StartThread(AddressOf session.ReadLoop, "SteamCMD output")
            session.Waiter = StartThread(AddressOf session.WaitLoop, "SteamCMD end")
        Catch
            session.Release()
            Throw
        End Try
        Return session
    End Function

    Private Shared Function StartThread(work As ThreadStart, name As String) As Thread
        Dim thread As New Thread(work)
        thread.IsBackground = True
        thread.Name = name
        thread.Start()
        Return thread
    End Function

    Private Sub OpenConsole(columns As Short, rows As Short)
        Dim inputEnd As SafeFileHandle = Nothing
        Dim outputEnd As SafeFileHandle = Nothing
        Try
            Dim handle As SafeFileHandle = Nothing
            If Not CreatePipe(inputEnd, handle, IntPtr.Zero, 0) Then Throw New Win32Exception()
            Input = New FileStream(handle, FileAccess.Write, 1, False)
            If Not CreatePipe(handle, outputEnd, IntPtr.Zero, 0) Then Throw New Win32Exception()
            Output = New FileStream(handle, FileAccess.Read, 1, False)

            Dim size As COORD
            size.X = columns
            size.Y = rows
            Dim result As Integer = CreatePseudoConsole(size, inputEnd, outputEnd, 0UI, Console)
            If result <> 0 Then
                Console = IntPtr.Zero
                Throw New PlatformNotSupportedException("CreatePseudoConsole: 0x" & result.ToString("X8"))
            End If
        Finally
            ' The pseudoconsole has its own copies, with these open the end of the output would never arrive
            If inputEnd IsNot Nothing Then inputEnd.Dispose()
            If outputEnd IsNot Nothing Then outputEnd.Dispose()
        End Try
    End Sub

    ' Everything that SteamCMD launches is closed with the job, also if the GUI is killed
    Private Sub OpenJob()
        Job = CreateJobObject(IntPtr.Zero, Nothing)
        Dim limits As JOBOBJECT_EXTENDED_LIMIT_INFORMATION
        limits.LimitFlags = JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE
        If Job.IsInvalid OrElse Not SetInformationJobObject(Job, JobObjectExtendedLimitInformation, limits, Marshal.SizeOf(limits)) Then Throw New Win32Exception()
    End Sub

    Private Sub Launch(exePath As String, arguments As String, folder As String)
        Dim startup As STARTUPINFOEX
        Dim info As PROCESS_INFORMATION
        Dim size As IntPtr
        InitializeProcThreadAttributeList(IntPtr.Zero, 1, 0, size) ' It only asks for the size
        startup.lpAttributeList = Marshal.AllocHGlobal(size)
        Try
            If Not InitializeProcThreadAttributeList(startup.lpAttributeList, 1, 0, size) Then Throw New Win32Exception()
            Try
                If Not UpdateProcThreadAttribute(startup.lpAttributeList, 0UI, New IntPtr(PROC_THREAD_ATTRIBUTE_PSEUDOCONSOLE), Console, New IntPtr(IntPtr.Size), IntPtr.Zero, IntPtr.Zero) Then Throw New Win32Exception()
                startup.cb = Marshal.SizeOf(startup)
                startup.dwFlags = STARTF_USESTDHANDLES ' All null, so the ones of the GUI aren't used
                Dim commandLine As New StringBuilder(Chr(34) & exePath & Chr(34) & " " & arguments)
                If Not CreateProcess(Nothing, commandLine, IntPtr.Zero, IntPtr.Zero, False, EXTENDED_STARTUPINFO_PRESENT Or CREATE_SUSPENDED, IntPtr.Zero, folder, startup, info) Then Throw New Win32Exception()
            Finally
                DeleteProcThreadAttributeList(startup.lpAttributeList)
            End Try
        Finally
            Marshal.FreeHGlobal(startup.lpAttributeList)
        End Try

        Process = New KernelHandle(info.hProcess)
        Using thread As New KernelHandle(info.hThread)
            ' It's suspended until it's inside the job, so its children are born there too
            If Not AssignProcessToJobObject(Job, Process) OrElse ResumeThread(thread) = -1 Then
                Dim problem As New Win32Exception()
                TerminateProcess(Process, 1UI)
                Throw problem
            End If
        End Using
    End Sub

    Private Sub ReadLoop()
        Dim decoder As Decoder = New UTF8Encoding(False).GetDecoder() ' It remembers a character cut between two reads
        Dim bytes(4095) As Byte
        Dim chars(Encoding.UTF8.GetMaxCharCount(bytes.Length)) As Char
        Try
            Do
                Dim count As Integer = Output.Read(bytes, 0, bytes.Length)
                If count = 0 Then Return
                Dim length As Integer = decoder.GetChars(bytes, 0, count, chars, 0)
                SyncLock Gate
                    ' If nobody takes the output the program waits, as in a window with the text selected
                    While Pending.Length > MaxPending AndAlso Not Draining
                        Monitor.Wait(Gate)
                    End While
                    Pending.Append(chars, 0, length)
                End SyncLock
            Loop
        Catch ex As IOException
            ' Broken pipe, there isn't more output
        Catch ex As ObjectDisposedException
        End Try
    End Sub

    Private Sub WaitLoop()
        Dim result As UInteger
        Try
            WaitForSingleObject(Process, INFINITE)
            GetExitCodeProcess(Process, result)
            TerminateJobObject(Job, 1UI) ' If it has left something running
        Catch ex As ObjectDisposedException
            ' Dispose gave up waiting
        End Try
        SyncLock Gate
            Draining = True
            Monitor.PulseAll(Gate)
        End SyncLock
        ' It can wait until the last output is read, so it can't be done in the thread that reads
        CloseConsole()
        Reader.Join(DrainTimeout)
        SyncLock Gate
            Code = BitConverter.ToInt32(BitConverter.GetBytes(result), 0)
            Finished = True
        End SyncLock
    End Sub

    Private Sub CloseConsole()
        Dim handle As IntPtr
        SyncLock Gate
            handle = Console
            Console = IntPtr.Zero
        End SyncLock
        If handle <> IntPtr.Zero Then ClosePseudoConsole(handle)
    End Sub

    Public Function TakeOutput() As String
        SyncLock Gate
            Dim text As String = Pending.ToString()
            Pending.Length = 0
            Monitor.PulseAll(Gate)
            Return text
        End SyncLock
    End Function

    Public Sub Write(text As String)
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(text)
        Try
            Input.Write(bytes, 0, bytes.Length)
            Input.Flush()
        Catch ex As IOException
            ' It has just ended
        Catch ex As ObjectDisposedException
        End Try
    End Sub

    ' The Enter key of a terminal is CR
    Public Sub WriteLine(text As String)
        Write(text & ChrW(13))
    End Sub

    ' The program and everything it has launched, HasExited changes a bit later
    Public Sub Kill()
        If Not Job.IsClosed Then TerminateJobObject(Job, 1UI)
    End Sub

    Public Function WaitForExit(milliseconds As Integer) As Boolean
        Return Waiter.Join(milliseconds)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Kill()
        Waiter.Join(CloseTimeout)
        Release()
    End Sub

    Private Sub Release()
        ' First the output: closing a pseudoconsole can wait for someone to read it
        If Output IsNot Nothing Then Output.Dispose()
        CloseConsole()
        If Input IsNot Nothing Then Input.Dispose()
        If Job IsNot Nothing Then Job.Dispose()
        If Process IsNot Nothing Then Process.Dispose()
    End Sub

    ' Windows doesn't reuse the handle while a thread is inside a call that uses it
    Private NotInheritable Class KernelHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid

        Public Sub New()
            MyBase.New(True)
        End Sub

        Public Sub New(value As IntPtr)
            MyBase.New(True)
            SetHandle(value)
        End Sub

        Protected Overrides Function ReleaseHandle() As Boolean
            Return CloseHandle(handle)
        End Function
    End Class

    Private Const PROC_THREAD_ATTRIBUTE_PSEUDOCONSOLE As Integer = &H20016
    Private Const STARTF_USESTDHANDLES As Integer = &H100
    Private Const CREATE_SUSPENDED As UInteger = &H4UI
    Private Const EXTENDED_STARTUPINFO_PRESENT As UInteger = &H80000UI
    Private Const JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE As UInteger = &H2000UI
    Private Const JobObjectExtendedLimitInformation As Integer = 9
    Private Const INFINITE As UInteger = &HFFFFFFFFUI

    <StructLayout(LayoutKind.Sequential)>
    Private Structure COORD
        Public X, Y As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure STARTUPINFOEX
        Public cb As Integer
        Public lpReserved, lpDesktop, lpTitle As IntPtr
        Public dwX, dwY, dwXSize, dwYSize, dwXCountChars, dwYCountChars, dwFillAttribute, dwFlags As Integer
        Public wShowWindow, cbReserved2 As Short
        Public lpReserved2, hStdInput, hStdOutput, hStdError As IntPtr
        Public lpAttributeList As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure PROCESS_INFORMATION
        Public hProcess, hThread As IntPtr
        Public dwProcessId, dwThreadId As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure JOBOBJECT_EXTENDED_LIMIT_INFORMATION
        Public PerProcessUserTimeLimit, PerJobUserTimeLimit As Long
        Public LimitFlags As UInteger
        Public MinimumWorkingSetSize, MaximumWorkingSetSize As IntPtr
        Public ActiveProcessLimit As UInteger
        Public Affinity As IntPtr
        Public PriorityClass, SchedulingClass As UInteger
        Public ReadOperationCount, WriteOperationCount, OtherOperationCount As ULong
        Public ReadTransferCount, WriteTransferCount, OtherTransferCount As ULong
        Public ProcessMemoryLimit, JobMemoryLimit, PeakProcessMemoryUsed, PeakJobMemoryUsed As IntPtr
    End Structure

    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function GetModuleHandle(name As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True)>
    Private Shared Function GetProcAddress(library As IntPtr, name As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function CreatePipe(<Out()> ByRef readEnd As SafeFileHandle, <Out()> ByRef writeEnd As SafeFileHandle, security As IntPtr, size As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function CreatePseudoConsole(size As COORD, input As SafeFileHandle, output As SafeFileHandle, flags As UInteger, ByRef console As IntPtr) As Integer
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Sub ClosePseudoConsole(console As IntPtr)
    End Sub

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Private Shared Function CreateJobObject(security As IntPtr, name As String) As KernelHandle
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function SetInformationJobObject(job As KernelHandle, infoClass As Integer, ByRef info As JOBOBJECT_EXTENDED_LIMIT_INFORMATION, size As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function AssignProcessToJobObject(job As KernelHandle, process As KernelHandle) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function TerminateJobObject(job As KernelHandle, code As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function InitializeProcThreadAttributeList(list As IntPtr, count As Integer, flags As Integer, ByRef size As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function UpdateProcThreadAttribute(list As IntPtr, flags As UInteger, attribute As IntPtr, value As IntPtr, size As IntPtr, previous As IntPtr, returnSize As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Sub DeleteProcThreadAttributeList(list As IntPtr)
    End Sub

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode, EntryPoint:="CreateProcessW")>
    Private Shared Function CreateProcess(application As String, commandLine As StringBuilder, processSecurity As IntPtr, threadSecurity As IntPtr, inheritHandles As Boolean, flags As UInteger, environment As IntPtr, folder As String, ByRef startup As STARTUPINFOEX, ByRef info As PROCESS_INFORMATION) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function ResumeThread(thread As KernelHandle) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function TerminateProcess(process As KernelHandle, code As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function WaitForSingleObject(handle As KernelHandle, milliseconds As UInteger) As UInteger
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function GetExitCodeProcess(process As KernelHandle, ByRef code As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function CloseHandle(handle As IntPtr) As Boolean
    End Function
End Class

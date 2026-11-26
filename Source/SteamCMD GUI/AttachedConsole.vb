Option Strict On

Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

' The lines that a program writes in its console, from what its screen buffer has.
' Row 0 isn't output: srcds and Counter-Strike 2 rewrite their status line there.
Friend NotInheritable Class ConsoleScreenLog
    Private Const TailSize As Integer = 20

    Private NextRow As Integer = 1 ' Where the next line will be
    Private ReadOnly Tail As New List(Of String)() ' The last lines returned, to find them again when the buffer scrolls

    Public ReadOnly Property FirstNeeded As Integer
        Get
            Return Math.Max(1, NextRow - TailSize)
        End Get
    End Property

    ' rows start at firstRow and go at least up to cursorRow. The line of the cursor isn't complete yet.
    ' Returns Nothing when the buffer has scrolled: then it has to be called again with all the rows from 1.
    Public Function Read(firstRow As Integer, rows As List(Of String), cursorRow As Integer) As List(Of String)
        Dim text As List(Of String) = rows.Select(Function(r) r.Replace(ChrW(0), "").TrimEnd()).ToList()
        Dim start As Integer = NextRow
        If Not TailEndsAt(text, firstRow, NextRow - 1) Then
            If firstRow > 1 Then Return Nothing
            start = 1 ' Nothing in common, everything is new (it was cleared, or there was more than the whole buffer)
            For row As Integer = NextRow - 2 To 1 Step -1
                If TailEndsAt(text, 1, row) Then
                    start = row + 1
                    Exit For
                End If
            Next
        End If

        Dim lines As New List(Of String)()
        For row As Integer = start To cursorRow - 1
            lines.Add(text(row - firstRow))
        Next
        Tail.AddRange(lines)
        If Tail.Count > TailSize Then Tail.RemoveRange(0, Tail.Count - TailSize)
        NextRow = Math.Max(1, Math.Max(start, cursorRow))
        Return lines
    End Function

    ' The last lines returned are in the rows that end at lastRow
    Private Function TailEndsAt(text As List(Of String), firstRow As Integer, lastRow As Integer) As Boolean
        If Tail.Count = 0 Then Return lastRow < 1
        If lastRow < 1 Then Return False
        For i As Integer = 0 To Tail.Count - 1
            Dim row As Integer = lastRow - i
            If row < Math.Max(1, firstRow) Then Exit For
            If row - firstRow >= text.Count OrElse text(row - firstRow) <> Tail(Tail.Count - 1 - i) Then Return False
        Next
        Return True
    End Function
End Class

' A console program in its own console, hidden, whose screen is read and where the commands are typed.
' srcds and Counter-Strike 2 make their own console, so they can't use a pseudoconsole.
' Only one at a time: a program can only be attached to one console. For the thread of the form.
Friend NotInheritable Class AttachedConsoleProcess
    Implements IDisposable

    Private Const AttachTimeout As Integer = 15000
    Private Const Columns As Short = 250 ' Wide, so the lines aren't cut

    Private ReadOnly Log As New ConsoleScreenLog()
    Private Process As IntPtr
    Private Id As Integer
    Private Window As IntPtr
    Private Output As IntPtr
    Private Input As IntPtr
    Private Attached As Boolean

    Private Sub New()
    End Sub

    Public ReadOnly Property ProcessId As Integer
        Get
            Return Id
        End Get
    End Property

    Public ReadOnly Property HasExited As Boolean
        Get
            Return WaitForSingleObject(Process, 0) = 0
        End Get
    End Property

    Public ReadOnly Property ExitCode As Integer
        Get
            Dim code As UInteger
            GetExitCodeProcess(Process, code)
            Return BitConverter.ToInt32(BitConverter.GetBytes(code), 0)
        End Get
    End Property

    ' Win32Exception if it can't be started or its console doesn't appear
    Public Shared Function Start(exePath As String, arguments As String, folder As String) As AttachedConsoleProcess
        Dim startup As New STARTUPINFO()
        startup.cb = Marshal.SizeOf(startup)
        startup.dwFlags = STARTF_USESHOWWINDOW
        startup.wShowWindow = SW_HIDE
        Dim info As PROCESS_INFORMATION
        Dim commandLine As New StringBuilder(Chr(34) & exePath & Chr(34) & " " & arguments)
        If Not CreateProcess(Nothing, commandLine, IntPtr.Zero, IntPtr.Zero, False, CREATE_NEW_CONSOLE, IntPtr.Zero, folder, startup, info) Then Throw New Win32Exception()
        CloseHandle(info.hThread)

        Dim session As New AttachedConsoleProcess()
        session.Process = info.hProcess
        session.Id = info.dwProcessId
        Try
            session.Attach()
        Catch
            TerminateProcess(info.hProcess, 1UI)
            session.Dispose()
            Throw
        End Try
        Return session
    End Function

    Private Sub Attach()
        FreeConsole()
        Dim clock As Stopwatch = Stopwatch.StartNew()
        ' The console appears a bit after the program, Counter-Strike 2 takes about 2 seconds
        Do Until AttachConsole(Id)
            If HasExited OrElse clock.ElapsedMilliseconds > AttachTimeout Then Throw New Win32Exception("The console of the server didn't appear.")
            Thread.Sleep(100)
        Loop
        Attached = True
        SetConsoleCtrlHandler(IntPtr.Zero, True) ' Its Ctrl+C isn't for the program
        Window = GetConsoleWindow()
        ShowWindow(Window, SW_HIDE)
        Output = CreateFile("CONOUT$", GENERIC_READ Or GENERIC_WRITE, FILE_SHARE_READ Or FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0UI, IntPtr.Zero)
        Input = CreateFile("CONIN$", GENERIC_READ Or GENERIC_WRITE, FILE_SHARE_READ Or FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0UI, IntPtr.Zero)
        Dim screen As CONSOLE_SCREEN_BUFFER_INFO
        If GetConsoleScreenBufferInfo(Output, screen) AndAlso screen.Size.X < Columns Then
            Dim size As COORD
            size.X = Columns
            size.Y = screen.Size.Y
            SetConsoleScreenBufferSize(Output, size)
        End If
    End Sub

    ' The new complete lines. After the program has ended, also the last ones.
    Public Function TakeLines() As List(Of String)
        If Not Attached Then Return New List(Of String)()
        Dim screen As CONSOLE_SCREEN_BUFFER_INFO
        If Not GetConsoleScreenBufferInfo(Output, screen) Then Return New List(Of String)()
        ' The cursor stays at the end of the last line when it doesn't finish with a new line
        Dim cursorRow As Integer = screen.Cursor.Y + If(screen.Cursor.X > 0 AndAlso HasExited, 1, 0)
        Dim first As Integer = Math.Min(Log.FirstNeeded, cursorRow)
        Dim lines As List(Of String) = Log.Read(first, ReadRows(screen, first, cursorRow), cursorRow)
        If lines Is Nothing Then lines = Log.Read(1, ReadRows(screen, 1, cursorRow), cursorRow)
        Return lines
    End Function

    Private Function ReadRows(screen As CONSOLE_SCREEN_BUFFER_INFO, first As Integer, last As Integer) As List(Of String)
        Dim width As Integer = screen.Size.X
        last = Math.Min(last, screen.Size.Y - 1)
        Dim rows As New List(Of String)()
        If last < first Then
            rows.Add("")
            Return rows
        End If
        Dim chars((last - first + 1) * width - 1) As Char
        Dim origin As COORD
        origin.Y = CShort(first)
        Dim read As Integer
        ReadConsoleOutputCharacter(Output, chars, chars.Length, origin, read)
        For row As Integer = 0 To last - first
            rows.Add(New String(chars, row * width, Math.Max(0, Math.Min(width, read - row * width))))
        Next
        Return rows
    End Function

    ' As if it was typed and Enter was pressed
    Public Sub WriteLine(text As String)
        If Not Attached Then Return
        Dim keys As New List(Of INPUT_RECORD)()
        For Each c As Char In text & ChrW(13)
            For Each down As Integer In New Integer() {1, 0}
                Dim key As New INPUT_RECORD()
                key.EventType = KEY_EVENT
                key.KeyDown = down
                key.RepeatCount = 1
                key.VirtualKeyCode = CShort(If(c = ChrW(13), 13, 0))
                key.UnicodeChar = c
                keys.Add(key)
            Next
        Next
        Dim written As Integer
        WriteConsoleInput(Input, keys.ToArray(), keys.Count, written)
    End Sub

    Public Sub Kill()
        TerminateProcess(Process, 1UI)
    End Sub

    ' The program keeps running in its own console, visible if show is True
    Public Sub Detach(show As Boolean)
        If Not Attached Then Return
        If show Then ShowWindow(Window, SW_SHOW)
        CloseHandle(Output)
        CloseHandle(Input)
        Output = IntPtr.Zero
        Input = IntPtr.Zero
        FreeConsole()
        SetConsoleCtrlHandler(IntPtr.Zero, False)
        Attached = False
    End Sub

    ' For a console that was left hidden, when the program that hid it ended without detaching
    Public Shared Sub ShowConsoleOf(processId As Integer)
        FreeConsole()
        If Not AttachConsole(processId) Then Return
        ShowWindow(GetConsoleWindow(), SW_SHOW)
        FreeConsole()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Detach(False)
        If Process <> IntPtr.Zero Then CloseHandle(Process)
        Process = IntPtr.Zero
    End Sub

    Private Const CREATE_NEW_CONSOLE As UInteger = &H10UI
    Private Const STARTF_USESHOWWINDOW As Integer = 1
    Private Const SW_HIDE As Short = 0
    Private Const SW_SHOW As Short = 5
    Private Const GENERIC_READ As UInteger = &H80000000UI
    Private Const GENERIC_WRITE As UInteger = &H40000000UI
    Private Const FILE_SHARE_READ As UInteger = 1UI
    Private Const FILE_SHARE_WRITE As UInteger = 2UI
    Private Const OPEN_EXISTING As UInteger = 3UI
    Private Const KEY_EVENT As Short = 1

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Private Structure STARTUPINFO
        Public cb As Integer
        Public lpReserved, lpDesktop, lpTitle As String
        Public dwX, dwY, dwXSize, dwYSize, dwXCountChars, dwYCountChars, dwFillAttribute, dwFlags As Integer
        Public wShowWindow, cbReserved2 As Short
        Public lpReserved2, hStdInput, hStdOutput, hStdError As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure PROCESS_INFORMATION
        Public hProcess, hThread As IntPtr
        Public dwProcessId, dwThreadId As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure COORD
        Public X, Y As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure SMALL_RECT
        Public Left, Top, Right, Bottom As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure CONSOLE_SCREEN_BUFFER_INFO
        Public Size, Cursor As COORD
        Public Attributes As Short
        Public Window As SMALL_RECT
        Public MaxWindow As COORD
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Private Structure INPUT_RECORD
        <FieldOffset(0)> Public EventType As Short
        <FieldOffset(4)> Public KeyDown As Integer
        <FieldOffset(8)> Public RepeatCount As Short
        <FieldOffset(10)> Public VirtualKeyCode As Short
        <FieldOffset(12)> Public VirtualScanCode As Short
        <FieldOffset(14)> Public UnicodeChar As Char
        <FieldOffset(16)> Public ControlKeyState As Integer
    End Structure

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode, EntryPoint:="CreateProcessW")>
    Private Shared Function CreateProcess(application As String, commandLine As StringBuilder, processSecurity As IntPtr, threadSecurity As IntPtr, inheritHandles As Boolean, flags As UInteger, environment As IntPtr, folder As String, ByRef startup As STARTUPINFO, ByRef info As PROCESS_INFORMATION) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function WaitForSingleObject(handle As IntPtr, milliseconds As UInteger) As UInteger
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function GetExitCodeProcess(process As IntPtr, ByRef code As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function TerminateProcess(process As IntPtr, code As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function CloseHandle(handle As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function FreeConsole() As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function AttachConsole(processId As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function SetConsoleCtrlHandler(handler As IntPtr, add As Boolean) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function GetConsoleWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ShowWindow(window As IntPtr, command As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode, EntryPoint:="CreateFileW")>
    Private Shared Function CreateFile(name As String, access As UInteger, share As UInteger, security As IntPtr, disposition As UInteger, flags As UInteger, template As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function GetConsoleScreenBufferInfo(output As IntPtr, ByRef info As CONSOLE_SCREEN_BUFFER_INFO) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function SetConsoleScreenBufferSize(output As IntPtr, size As COORD) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode, EntryPoint:="ReadConsoleOutputCharacterW")>
    Private Shared Function ReadConsoleOutputCharacter(output As IntPtr, <Out()> chars As Char(), length As Integer, origin As COORD, ByRef read As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode, EntryPoint:="WriteConsoleInputW")>
    Private Shared Function WriteConsoleInput(input As IntPtr, records As INPUT_RECORD(), count As Integer, ByRef written As Integer) As Boolean
    End Function
End Class

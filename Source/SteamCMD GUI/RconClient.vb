Option Strict On

Imports System.Collections.Concurrent
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

Friend Enum RconError
    Unreachable ' Nothing listens there
    WrongPassword
    Refused ' Closed before the login, the address may be banned
    Closed
    Timeout
    BadData ' It isn't a RCON server
    TooLong
End Enum

Friend Class RconException
    Inherits Exception

    Public ReadOnly Reason As RconError

    Public Sub New(reason As RconError)
        MyBase.New(Text(reason))
        Me.Reason = reason
    End Sub

    Private Shared Function Text(reason As RconError) As String
        Select Case reason
            Case RconError.Unreachable : Return "Can't connect to the server."
            Case RconError.WrongPassword : Return "Wrong RCON password, 'server.cfg' may have another one."
            Case RconError.Refused : Return "The server refused the connection, it bans the address after several wrong passwords."
            Case RconError.Closed : Return "The server closed the connection."
            Case RconError.Timeout : Return "The server doesn't answer."
            Case RconError.BadData : Return "The program that uses that port isn't a RCON server."
        End Select
        Return "The command is too long."
    End Function
End Class

' Source RCON protocol: https://developer.valvesoftware.com/wiki/Source_RCON_Protocol
' It blocks, so it's for a worker thread. Only Close can be called from another one
Friend Class RconClient
    Implements IDisposable

    Public Timeout As Integer = 30000 ' The server doesn't answer while it loads a map

    Public Const MaxCommandBytes As Integer = 510 ' Longer ones are cut, and over 1014 the address is banned
    Private Const MaxPacketSize As Integer = 4194304 ' Counter-Strike 2 doesn't split them, cvarlist is over 300 KB
    Private Const MinPacketSize As Integer = 10

    Private Const ResponsePacket As Integer = 0
    Private Const CommandPacket As Integer = 2
    Private Const LoginResultPacket As Integer = 2
    Private Const LoginPacket As Integer = 3

    ' The packets of a response are sent together, so there are no more after this time
    Private Const StuckTime As Integer = 2000
    Private Const QuietTime As Integer = 150

    Private ReadOnly Connection As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    Private LastId As Integer
    Private SplitsResponses As Boolean

    Private Structure Packet
        Public Id As Integer
        Public Type As Integer
        Public Body As Byte()
    End Structure

    Public Sub Connect(server As IPEndPoint, milliseconds As Integer)
        Try
            Dim attempt As IAsyncResult = Connection.BeginConnect(server, Nothing, Nothing)
            If Not attempt.AsyncWaitHandle.WaitOne(milliseconds) Then Throw Fail(RconError.Unreachable)
            Connection.EndConnect(attempt)
            Connection.NoDelay = True
        Catch ex As SocketException
            Throw Fail(RconError.Unreachable)
        Catch ex As ObjectDisposedException
            Throw Fail(RconError.Closed)
        End Try
    End Sub

    Public Sub Login(password As String)
        Dim id As Integer = NextId()
        Dim clock As Stopwatch = Stopwatch.StartNew()
        Try
            Send(Pack(id, LoginPacket, password))
            Do
                Dim answer As Packet = Receive(clock)
                If answer.Type = LoginResultPacket AndAlso answer.Id = -1 Then Throw Fail(RconError.WrongPassword)
                If answer.Type = LoginResultPacket AndAlso answer.Id = id Then Return
                ' Source sends an empty response before the result, Counter-Strike 2 doesn't
                If answer.Type = ResponsePacket Then SplitsResponses = True
            Loop
        Catch ex As RconException When ex.Reason = RconError.Closed
            Throw New RconException(RconError.Refused)
        End Try
    End Sub

    Public Function Execute(command As String) As String
        If Encoding.UTF8.GetByteCount(command) > MaxCommandBytes Then Throw New RconException(RconError.TooLong)

        Dim id As Integer = NextId()
        Dim endId As Integer = NextId()
        Dim request As Byte() = Pack(id, CommandPacket, command)
        ' The requests are answered in order, the answer to an empty one marks the end of the response.
        ' They have to be in the same write, see https://github.com/ValveSoftware/Source-1-Games/issues/8451
        If SplitsResponses Then request = request.Concat(Pack(endId, ResponsePacket, "")).ToArray()
        Dim clock As Stopwatch = Stopwatch.StartNew()
        Send(request)

        Dim response As New MemoryStream()
        Dim answered As Boolean = False
        Do
            If answered AndAlso Not HasData(If(SplitsResponses, StuckTime, QuietTime)) Then
                ' Stuck by that bug, it would run the command again with the next one
                If SplitsResponses Then Close()
                Exit Do
            End If
            Dim answer As Packet = Receive(clock)
            If answer.Id = endId Then Exit Do
            If answer.Id = -1 Then Throw Fail(RconError.WrongPassword)
            If answer.Id = id Then
                response.Write(answer.Body, 0, answer.Body.Length)
                answered = True
            End If
        Loop
        ' Decoded at the end, a character can be split between two packets
        Return Encoding.UTF8.GetString(response.ToArray()).Replace(vbNullChar, "")
    End Function

    ' Between commands only the rest of the end mark can arrive
    Public Function IsConnected() As Boolean
        Try
            While HasData(0)
                Receive(Stopwatch.StartNew())
            End While
            Return True
        Catch ex As RconException
            Return False
        End Try
    End Function

    Public Sub Close() Implements IDisposable.Dispose
        Try
            Connection.Shutdown(SocketShutdown.Both)
        Catch ex As SocketException
        Catch ex As ObjectDisposedException
        End Try
        Connection.Close()
    End Sub

    Private Function Fail(reason As RconError) As RconException
        Close()
        Return New RconException(reason)
    End Function

    Private Function NextId() As Integer
        LastId += 1
        Return LastId
    End Function

    Private Shared Function Pack(id As Integer, type As Integer, body As String) As Byte()
        Dim text As Byte() = Encoding.UTF8.GetBytes(body)
        Dim data(text.Length + 13) As Byte ' The last two are the terminators
        BitConverter.GetBytes(text.Length + MinPacketSize).CopyTo(data, 0)
        BitConverter.GetBytes(id).CopyTo(data, 4)
        BitConverter.GetBytes(type).CopyTo(data, 8)
        text.CopyTo(data, 12)
        Return data
    End Function

    Private Sub Send(data As Byte())
        Try
            Connection.Send(data)
        Catch ex As SocketException
            Throw Fail(RconError.Closed)
        Catch ex As ObjectDisposedException
            Throw Fail(RconError.Closed)
        End Try
    End Sub

    Private Function Receive(clock As Stopwatch) As Packet
        Dim size As Integer = BitConverter.ToInt32(Read(4, clock), 0)
        If size < MinPacketSize OrElse size > MaxPacketSize Then Throw Fail(RconError.BadData)
        Dim data As Byte() = Read(size, clock)
        Dim answer As New Packet()
        answer.Id = BitConverter.ToInt32(data, 0)
        answer.Type = BitConverter.ToInt32(data, 4)
        Dim body(size - MinPacketSize - 1) As Byte
        Array.Copy(data, 8, body, 0, body.Length)
        answer.Body = body
        Return answer
    End Function

    Private Function Read(count As Integer, clock As Stopwatch) As Byte()
        Dim data(count - 1) As Byte
        Dim done As Integer = 0
        While done < count
            If Not HasData(Math.Max(0, Timeout - CInt(clock.ElapsedMilliseconds))) Then Throw Fail(RconError.Timeout)
            Try
                Dim received As Integer = Connection.Receive(data, done, count - done, SocketFlags.None)
                If received = 0 Then Throw Fail(RconError.Closed)
                done += received
            Catch ex As SocketException
                Throw Fail(RconError.Closed)
            Catch ex As ObjectDisposedException
                Throw Fail(RconError.Closed)
            End Try
        End While
        Return data
    End Function

    ' True also when the connection was closed, reading tells the difference
    Private Function HasData(milliseconds As Integer) As Boolean
        Try
            Return Connection.Poll(milliseconds * 1000, SelectMode.SelectRead)
        Catch ex As SocketException
            Throw Fail(RconError.Closed)
        Catch ex As ObjectDisposedException
            Throw Fail(RconError.Closed)
        End Try
    End Function
End Class

Friend Enum RconState
    Waiting
    Connected
    Disconnected
End Enum

' Keeps the connection with a server in its own thread, and raises the events in that thread
Friend Class RconSession
    Public Event StateChanged(state As RconState, message As String)
    Public Event Output(text As String)

    Public WaitTime As Integer = 180000 ' The server doesn't listen until it's loaded
    Public RetryTime As Integer = 2000
    Public StableTime As Integer = 10000
    Public ResponseTime As Integer = 30000

    ' Far from the failed logins that ban an address: 5 in 30 seconds
    Private Const MaxFailures As Integer = 3

    Private ReadOnly FindServer As Func(Of IPEndPoint)
    Private ReadOnly IsRunning As Func(Of Boolean)
    Private ReadOnly Password As String
    Private ReadOnly Commands As New BlockingCollection(Of String)
    Private ReadOnly Stopping As New ManualResetEvent(False)
    Private Client As RconClient

    Public Sub New(findServer As Func(Of IPEndPoint), isRunning As Func(Of Boolean), password As String)
        Me.FindServer = findServer
        Me.IsRunning = isRunning
        Me.Password = password
    End Sub

    Public Sub Start()
        Dim worker As New Thread(AddressOf Run)
        worker.IsBackground = True
        worker.Start()
    End Sub

    Public Sub Send(command As String)
        Commands.Add(command)
    End Sub

    Public Sub [Stop]()
        Stopping.Set()
        Dim current As RconClient = Client
        If current IsNot Nothing Then current.Close()
    End Sub

    Private Sub Run()
        Dim failures As Integer = 0
        Dim message As String = "Waiting for the server..."
        Do
            RaiseEvent StateChanged(RconState.Waiting, message)
            Dim server As IPEndPoint = WaitForServer(message)
            If server Is Nothing Then Exit Do

            Dim connected As New Stopwatch()
            Client = New RconClient()
            Try
                Client.Timeout = ResponseTime
                If Stopping.WaitOne(0) Then Exit Do
                Client.Connect(server, 5000)
                Client.Login(Password)
                connected.Start()
                RaiseEvent StateChanged(RconState.Connected, "Connected to the server (" & server.ToString() & ").")
                RunCommands()
            Catch ex As RconException
                message = ex.Message
                If ex.Reason = RconError.WrongPassword OrElse ex.Reason = RconError.Refused OrElse ex.Reason = RconError.BadData Then Exit Do
                failures = If(connected.ElapsedMilliseconds > StableTime, 1, failures + 1)
                If failures = MaxFailures Then Exit Do
                message &= " Reconnecting..."
            Finally
                Client.Close()
            End Try
        Loop Until Stopping.WaitOne(RetryTime)
        RaiseEvent StateChanged(RconState.Disconnected, If(Stopping.WaitOne(0), "Disconnected from the server.", message))
    End Sub

    ' Nothing and the reason if there is no server to connect to
    Private Function WaitForServer(ByRef reason As String) As IPEndPoint
        Dim clock As Stopwatch = Stopwatch.StartNew()
        Do
            Dim server As IPEndPoint = FindServer()
            If server IsNot Nothing Then Return server
            If Not IsRunning() Then
                reason = "The server was closed."
                Return Nothing
            End If
        Loop Until clock.ElapsedMilliseconds > WaitTime OrElse Stopping.WaitOne(Math.Min(1000, RetryTime))
        reason = "There isn't any server listening to RCON on that port."
        Return Nothing
    End Function

    Private Sub RunCommands()
        Do Until Stopping.WaitOne(0)
            If Not Client.IsConnected() Then Throw New RconException(RconError.Closed)
            Dim command As String = Nothing
            If Commands.TryTake(command, 500) Then
                RaiseEvent Output("> " & command)
                Try
                    RaiseEvent Output(Client.Execute(command))
                Catch ex As RconException When ex.Reason = RconError.TooLong
                    RaiseEvent Output(ex.Message)
                End Try
            End If
        Loop
    End Sub
End Class

' The servers of this PC. Without -ip, srcds listens on the address of the computer and not on 127.0.0.1
Friend Module RconListeners
    Private Const InsufficientBuffer As Integer = 122
    Private Const IPv4 As Integer = 2
    Private Const ListenersWithProcess As Integer = 3
    Private Const RowSize As Integer = 24
    Private Const PortsTried As Integer = 10 ' The server uses the next one if its port is in use

    <DllImport("iphlpapi.dll")>
    Private Function GetExtendedTcpTable(table As IntPtr, ByRef size As Integer, sorted As Boolean, family As Integer, tableClass As Integer, reserved As Integer) As Integer
    End Function

    Friend Structure Listener
        Public Address As IPEndPoint
        Public ProcessId As Integer
    End Structure

    ' With the process (0 if it's unknown) the server is found although it uses another port
    Public Function Find(port As Integer, processId As Integer) As IPEndPoint
        Return Choose(All(), port, processId)
    End Function

    Friend Function Choose(listeners As IEnumerable(Of Listener), port As Integer, processId As Integer) As IPEndPoint
        Dim last As Integer = If(processId = 0, port, port + PortsTried - 1)
        Dim found As IPEndPoint = Nothing
        For Each l As Listener In listeners
            If processId <> 0 AndAlso l.ProcessId <> processId Then Continue For
            If l.Address.Port < port OrElse l.Address.Port > last Then Continue For
            If found Is Nothing OrElse l.Address.Port < found.Port Then found = l.Address
        Next
        If found IsNot Nothing AndAlso found.Address.Equals(IPAddress.Any) Then Return New IPEndPoint(IPAddress.Loopback, found.Port)
        Return found
    End Function

    Friend Function All() As List(Of Listener)
        Dim result As New List(Of Listener)
        Dim size As Integer = 0
        Dim table As IntPtr = IntPtr.Zero
        Try
            ' The table can grow between two calls
            Dim answer As Integer = GetExtendedTcpTable(table, size, False, IPv4, ListenersWithProcess, 0)
            While answer = InsufficientBuffer
                Marshal.FreeHGlobal(table)
                table = Marshal.AllocHGlobal(size)
                answer = GetExtendedTcpTable(table, size, False, IPv4, ListenersWithProcess, 0)
            End While
            If answer <> 0 OrElse table = IntPtr.Zero Then Return result
            For i As Integer = 0 To Marshal.ReadInt32(table) - 1
                Dim row As Integer = 4 + i * RowSize
                Dim item As New Listener()
                item.Address = New IPEndPoint(New IPAddress(Marshal.ReadInt32(table, row + 4) And &HFFFFFFFFL),
                                              Marshal.ReadByte(table, row + 8) * 256 + Marshal.ReadByte(table, row + 9))
                item.ProcessId = Marshal.ReadInt32(table, row + 20)
                result.Add(item)
            Next
        Finally
            Marshal.FreeHGlobal(table)
        End Try
        Return result
    End Function
End Module

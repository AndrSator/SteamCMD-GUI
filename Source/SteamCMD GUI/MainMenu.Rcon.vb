Option Strict On

' The server in the Console tab: its commands are sent with RCON
Partial Public Class MainMenu
    ' Items of ConsoleCommandList, who gets the text of the input box
    Private Const SteamCmdTarget As Integer = 0
    Private Const ServerTarget As Integer = 1

    Private ServerSession As RconSession
    Private ServerState As RconState = RconState.Disconnected
    Private ServerProcess As Process ' The last server that was run
    Private ServerPort As Integer
    Private SteamCmdInput As Boolean
    Private ReadOnly SentCommands As New List(Of String)
    Private SentIndex As Integer

    Private ReadOnly Property ServerSelected As Boolean
        Get
            Return ConsoleCommandList.SelectedIndex = ServerTarget
        End Get
    End Property

    ' SteamCMD starts or ends in the Console tab
    Private Sub SetSteamCmdInput(enabled As Boolean)
        SteamCmdInput = enabled
        If enabled Then
            ConsoleCommandList.SelectedIndex = SteamCmdTarget
        ElseIf ServerState = RconState.Connected Then
            ConsoleCommandList.SelectedIndex = ServerTarget
        End If
        RefreshConsole()
    End Sub

    ' After the Run button
    Private Sub ServerStarted(server As Process)
        ServerProcess = server
        ServerPort = CInt(UDPPortTexBox.Value)
        If Not String.IsNullOrEmpty(RCON) Then ConnectToServer()
    End Sub

    Private Sub ToggleServerConnection()
        If ServerSession IsNot Nothing Then
            DisconnectFromServer()
            ShowServerMessage("Disconnected from the server.", False)
        ElseIf String.IsNullOrEmpty(RCON) Then
            ShowServerMessage("Please, type the RCON password in the Run Server tab.", True)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        Else
            ConnectToServer()
        End If
    End Sub

    Private Sub ConnectToServer()
        DisconnectFromServer()
        Dim port As Integer = CInt(UDPPortTexBox.Value)
        ' It's unknown if the program didn't run the server, then any server of this PC that uses the port is valid
        Dim server As Process = Nothing
        If ServerProcess IsNot Nothing AndAlso ServerPort = port AndAlso Not ServerProcess.HasExited Then server = ServerProcess
        Dim processId As Integer = If(server Is Nothing, 0, server.Id)

        Dim session As New RconSession(Function() RconListeners.Find(port, processId),
                                       Function() server Is Nothing OrElse Not server.HasExited,
                                       RCON.Replace(Chr(34), "")) ' As in the command line
        AddHandler session.StateChanged, Sub(state, message) RunInForm(session, Sub() ServerStateChanged(state, message))
        AddHandler session.Output, Sub(text) RunInForm(session, Sub() WriteServerText(text))
        ServerSession = session
        ShowServerMessage("RCON port: " & port, False)
        session.Start()
    End Sub

    Private Sub DisconnectFromServer()
        If ServerSession Is Nothing Then Return
        ServerSession.Stop()
        ServerSession = Nothing
        ServerState = RconState.Disconnected
        RefreshConsole()
    End Sub

    ' The events of the session are raised in its thread
    Private Sub RunInForm(session As RconSession, action As MethodInvoker)
        Try
            BeginInvoke(New MethodInvoker(Sub() If session Is ServerSession Then action()))
        Catch ex As InvalidOperationException ' The window was closed
        End Try
    End Sub

    Private Sub ServerStateChanged(state As RconState, message As String)
        ServerState = state
        If state = RconState.Disconnected Then ServerSession = Nothing
        ' What is being typed for SteamCMD (a password for example) can't go to the server
        If state = RconState.Connected AndAlso Not SteamCmdInput Then ConsoleCommandList.SelectedIndex = ServerTarget
        ShowServerMessage(message, state = RconState.Disconnected)
        RefreshConsole()
    End Sub

    Private Sub ShowServerMessage(message As String, isError As Boolean)
        WriteServerText(message)
        Status.Text = message
        Status.BackColor = If(isError, Color.FromArgb(240, 200, 200), Color.FromArgb(240, 240, 240))
    End Sub

    Private Sub WriteServerText(text As String)
        Dim lines As String = text.TrimEnd()
        If lines = "" Then Return ' SelectedText = "" beeps in a read-only box
        ConsoleOutput.AppendText(If(ConsoleOutput.TextLength > 0, vbLf, "") & lines)
        ConsoleOutput.SelectionStart = ConsoleOutput.TextLength
        ConsoleOutput.ScrollToCaret()
    End Sub

    Private Sub RefreshConsole()
        Dim canWrite As Boolean = If(ServerSelected, ServerState = RconState.Connected, SteamCmdInput)
        ConsoleInput.Enabled = canWrite
        ConsoleButton.Enabled = canWrite
        ConsoleConnect.Enabled = ServerSelected OrElse SteamCmdInput
        ToolTip1.SetToolTip(ConsoleConnect, If(Not ServerSelected, "Stop SteamCMD", If(ServerSession Is Nothing, "Connect to server", "Disconnect from server")))
    End Sub

    Private Sub ConsoleCommandList_SelectedIndexChanged() Handles ConsoleCommandList.SelectedIndexChanged
        ConsoleInput.Clear() ' What was typed for one isn't for the other
        RefreshConsole()
    End Sub

    ' True if the text of the input box is for the server
    Private Function SendToServer() As Boolean
        If Not ServerSelected Then Return False
        Dim command As String = ConsoleInput.Text.Trim()
        If command <> "" AndAlso ServerState = RconState.Connected Then
            ServerSession.Send(command)
            If SentCommands.LastOrDefault() <> command Then SentCommands.Add(command)
            SentIndex = SentCommands.Count
            ConsoleInput.Clear()
        End If
        Return True
    End Function

    Private Sub ServerInput_KeyDown(sender As Object, e As KeyEventArgs) Handles ConsoleInput.KeyDown
        If Not ServerSelected Then Return
        Select Case e.KeyCode
            Case Keys.Enter
                SendToServer()
            Case Keys.Up
                ShowSentCommand(SentIndex - 1)
            Case Keys.Down
                ShowSentCommand(SentIndex + 1)
            Case Else
                Return
        End Select
        e.SuppressKeyPress = True
    End Sub

    Private Sub ShowSentCommand(index As Integer)
        If index < 0 OrElse index > SentCommands.Count Then Return
        SentIndex = index
        ConsoleInput.Text = If(index < SentCommands.Count, SentCommands(index), "")
        ConsoleInput.SelectionStart = ConsoleInput.TextLength
    End Sub

    Private Sub Server_FormClosed() Handles Me.FormClosed
        If ServerSession IsNot Nothing Then ServerSession.Stop()
    End Sub
End Class

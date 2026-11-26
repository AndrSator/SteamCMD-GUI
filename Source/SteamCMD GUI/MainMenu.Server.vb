Option Strict On

Imports System.ComponentModel
Imports System.IO

' The server in the Console tab: it runs in its own console, hidden, and the program reads and types in it.
' Closing the program can stop it or leave it running in its own window.
Partial Public Class MainMenu
    Private Const ServerInterval As Integer = 200
    Private Const ServerStopTimeout As Integer = 10000
    Private Const HiddenServerFile As String = "Settings/HiddenServer.txt"

    Private WithEvents ServerTimer As Timer
    Private ServerConsole As AttachedConsoleProcess
    Private ServerQuitting As Stopwatch
    Private ServerStopped As Boolean
    Private KeepServerOnClose As Boolean
    Private ServerLogHeader() As String ' Program, game and path, for the log

    Private ReadOnly Property ServerConsoleIsRunning As Boolean
        Get
            Return ServerConsole IsNot Nothing
        End Get
    End Property

    Private Sub RunServerInConsole(exe As String, arguments As String, folder As String)
        If ServerConsoleIsRunning Then
            ShowStatus("A server is already running in the Console tab. Stop it first or untick '" & ServerInConsoleCheckBox.Text & "'.", True)
            Return
        End If
        DisconnectFromServer()
        Try
            ServerConsole = AttachedConsoleProcess.Start(exe, arguments, folder)
        Catch ex As Win32Exception
            ShowStatus("The server can't be started: " & ex.Message.Replace("%1", Path.GetFileName(exe)), True)
            Return
        End Try
        SaveHiddenServer()
        ServerTerminal.Clear()
        ServerStopped = False
        ServerQuitting = Nothing
        ServerLogHeader = New String() {Path.GetFileName(exe), "Game: " & ModList.Text, "Server path: " & folder}

        ConsoleTab_Click()
        TabMenu.SelectedTab = ConsoleTab
        ' Not while SteamCMD asks for the password or the code: what is being typed is for it
        Dim steamAsks As Boolean = SteamSession IsNot Nothing AndAlso (SteamState.Prompt = SteamCmdPrompt.Password OrElse SteamState.Prompt = SteamCmdPrompt.Code)
        If Not steamAsks Then ConsoleCommandList.SelectedIndex = ServerTarget
        ShowConsole()
        RefreshConsole()
        If ServerTimer Is Nothing Then ServerTimer = New Timer(components)
        ServerTimer.Interval = ServerInterval
        ServerTimer.Start()
        ShowStatus("Running server in the Console tab...", False)
    End Sub

    Private Sub ServerTimer_Tick() Handles ServerTimer.Tick
        Dim ended As Boolean = ServerConsole.HasExited ' Before TakeLines, or the last ones could be lost
        Dim lines As List(Of String) = ServerConsole.TakeLines()
        If lines.Count > 0 Then
            ServerTerminal.Feed(String.Join(vbCrLf, lines.ToArray()) & vbCrLf)
            RenderConsole(ServerTerminal)
        End If
        If ended Then
            ServerConsoleEnded()
        ElseIf ServerQuitting IsNot Nothing AndAlso ServerQuitting.ElapsedMilliseconds > ServerStopTimeout Then
            ServerConsole.Kill()
        End If
    End Sub

    Private Sub ServerConsoleEnded()
        ServerTimer.Stop()
        Dim code As Integer = ServerConsole.ExitCode
        ServerConsole.Dispose()
        ServerConsole = Nothing
        ServerQuitting = Nothing
        DeleteHiddenServer()
        If ServerStopped OrElse code = 0 Then
            ShowStatus("The server has stopped.", False)
        Else
            ShowStatus("The server closed unexpectedly (code " & code & ").", True)
        End If
        If ServerStopped Then SaveConsoleLog(ServerLogHeader, ServerTerminal)
        RefreshConsole()
    End Sub

    ' With quit, so it can save its things. Pressing it again while it closes ends it at once.
    Private Sub StopServerInConsole(ask As Boolean)
        If ServerConsole Is Nothing Then Return
        If ask AndAlso MessageBox.Show("Really want to stop the server?", "Stop server", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        If ServerConsole Is Nothing Then Return ' It ended while the question was open
        ServerStopped = True
        If ServerQuitting Is Nothing Then
            ServerConsole.WriteLine("quit")
            ServerQuitting = Stopwatch.StartNew()
            ShowStatus("Stopping the server...", False)
        Else
            ServerConsole.Kill()
        End If
    End Sub

    Private Sub ServerConsole_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ServerConsole Is Nothing OrElse e.Cancel Then Return
        KeepServerOnClose = e.CloseReason <> CloseReason.UserClosing ' Windows is closing, for example
        If KeepServerOnClose Then Return
        Select Case MessageBox.Show("A server is running in the Console tab." & vbCrLf & vbCrLf &
                                    "Yes: stop it." & vbCrLf & "No: keep it running in its own window." & vbCrLf & "Cancel: don't close the program.",
                                    "Close SteamCMD GUI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Case DialogResult.No
                KeepServerOnClose = True
            Case DialogResult.Cancel
                e.Cancel = True
        End Select
    End Sub

    Private Sub ServerConsole_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If ServerConsole Is Nothing Then Return
        ServerTimer.Stop()
        If KeepServerOnClose Then
            ReleaseServerConsole()
            Return
        End If
        Hide()
        ServerConsole.WriteLine("quit")
        Dim clock As Stopwatch = Stopwatch.StartNew()
        Do Until ServerConsole.HasExited OrElse clock.ElapsedMilliseconds > ServerStopTimeout
            Threading.Thread.Sleep(100)
        Loop
        If Not ServerConsole.HasExited Then ServerConsole.Kill()
        ServerConsole.Dispose()
        ServerConsole = Nothing
        DeleteHiddenServer()
    End Sub

    ' The server keeps running with its window visible, as if it had been run without the console of the program
    Friend Sub ReleaseServerConsole()
        If ServerConsole Is Nothing Then Return
        ServerConsole.Detach(True)
        ServerConsole.Dispose()
        ServerConsole = Nothing
        DeleteHiddenServer()
    End Sub

    ' If the program ends without releasing it, the next time its window is shown again
    Private Sub SaveHiddenServer()
        Try
            File.WriteAllText(HiddenServerFile, ServerConsole.ProcessId & vbLf & Process.GetProcessById(ServerConsole.ProcessId).StartTime.ToUniversalTime().Ticks)
        Catch ex As Exception When TypeOf ex Is IOException OrElse TypeOf ex Is UnauthorizedAccessException OrElse TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException
        End Try
    End Sub

    Private Sub DeleteHiddenServer()
        Try
            File.Delete(HiddenServerFile)
        Catch ex As Exception When TypeOf ex Is IOException OrElse TypeOf ex Is UnauthorizedAccessException
        End Try
    End Sub

    Private Sub ShowHiddenServer()
        If Not File.Exists(HiddenServerFile) Then Return
        Try
            Dim saved() As String = File.ReadAllText(HiddenServerFile).Split(ChrW(10))
            Dim server As Process = Process.GetProcessById(Integer.Parse(saved(0)))
            ' The same number can be used by another program later
            If server.StartTime.ToUniversalTime().Ticks = Long.Parse(saved(1)) Then
                AttachedConsoleProcess.ShowConsoleOf(server.Id)
                ShowStatus("The server that was running in the Console tab is still running, in its own window.", False)
            End If
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is FormatException OrElse TypeOf ex Is IndexOutOfRangeException OrElse
                                   TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is Win32Exception OrElse TypeOf ex Is IOException OrElse TypeOf ex Is OverflowException
            ' It isn't running anymore
        End Try
        DeleteHiddenServer()
    End Sub

    Private Sub SaveConsoleLog(header() As String, terminal As TerminalBuffer)
        Program = header(0)
        Game = header(1)
        PathForLog = header(2)
        Try
            SaveLog(String.Join(vbCrLf, terminal.Lines().ToArray()))
        Catch ex As IOException
            ShowStatus("The log can't be saved: " & ex.Message, True)
        Catch ex As UnauthorizedAccessException
            ShowStatus("The log can't be saved: " & ex.Message, True)
        End Try
    End Sub

    Private Sub ServerInConsoleCheckBox_CheckedChanged() Handles ServerInConsoleCheckBox.CheckedChanged
        RefreshConsoleMode()
    End Sub

    ' Without its text console the server has its window with graphics, that can't be read
    Private Sub RefreshConsoleMode()
        If ServerInConsoleCheckBox.Checked Then
            ConsoleCheckBox.Checked = True
            ConsoleCheckBox.Enabled = False
        Else
            ConsoleCheckBox.Enabled = Not CustomModCheckBox.Checked
        End If
    End Sub
End Class

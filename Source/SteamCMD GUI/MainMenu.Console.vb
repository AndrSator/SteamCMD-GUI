Option Strict On

Imports System.ComponentModel
Imports System.IO

' SteamCMD in the Console tab. Everything runs in the thread of the form, ConsoleTimer collects the output.
Partial Public Class MainMenu
    Private Const ConsoleColumns As Short = 250 ' Wide, so the long paths aren't cut
    Private Const ConsoleRows As Short = 30
    Private Const ConsoleHistory As Integer = 5000
    Private Const ConsoleInterval As Integer = 75
    Private Const QuitTimeout As Integer = 5000

    Private WithEvents ConsoleTimer As Timer
    Private SteamSession As PseudoConsoleProcess
    Private SteamTerminal As TerminalBuffer
    Private SteamView As ConsoleView
    Private SteamState As SteamCmdStatus
    Private SteamMessage As String
    Private SteamStopped As Boolean
    Private SteamKilled As Boolean
    Private SteamQuitting As Stopwatch
    Private NextInstall As String

    ' Open, but at 'Steam>' waiting for a command
    Private ReadOnly Property SteamCmdIsIdle As Boolean
        Get
            Return SteamSession IsNot Nothing AndAlso SteamState.Prompt = SteamCmdPrompt.Command AndAlso SteamQuitting Is Nothing
        End Get
    End Property

    ' Something that would be lost, it isn't waiting for a command nor closing
    Private ReadOnly Property SteamCmdHasWork As Boolean
        Get
            Return SteamSession IsNot Nothing AndAlso SteamState.Prompt <> SteamCmdPrompt.Command AndAlso SteamQuitting Is Nothing
        End Get
    End Property

    Private Function SteamCmdIsBusy() As Boolean
        If SteamSession Is Nothing OrElse SteamCmdIsIdle Then Return False
        ShowStatus("SteamCMD is still working. Wait until it finishes or stop it in the Console tab.", False)
        Return True
    End Function

    Private Sub ShowStatus(message As String, isError As Boolean)
        Status.Text = message
        Status.BackColor = If(isError, Color.FromArgb(240, 200, 200), Color.FromArgb(240, 240, 240))
    End Sub

    Private Sub RunSteamCmdInWindow(arguments As String)
        Dim p As New Process
        With (p.StartInfo)
            .FileName = SteamCMDExePath & "\steamcmd.exe"
            .UseShellExecute = False
            .Arguments = arguments
        End With
        p.Start()
    End Sub

    Private Sub RunSteamCmdInConsole(arguments As String)
        If SteamCmdIsBusy() Then Return
        If SteamSession IsNot Nothing Then
            NextInstall = arguments
            QuitSteamCmd()
            ShowStatus("Closing the previous session of SteamCMD...", False)
            Return
        End If

        Dim terminal As New TerminalBuffer(ConsoleColumns, ConsoleRows, ConsoleHistory, AddressOf SteamCmdLine.Replaces)
        Try
            SteamSession = PseudoConsoleProcess.Start(Path.Combine(SteamCMDExePath, "steamcmd.exe"), arguments, SteamCMDExePath, ConsoleColumns, ConsoleRows)
        Catch ex As PlatformNotSupportedException
            RunSteamCmdInWindow(arguments)
            ShowStatus("The console isn't available in this Windows, SteamCMD runs in its own window.", False)
            Return
        Catch ex As Win32Exception
            ShowStatus("SteamCMD can't be started: " & ex.Message.Replace("%1", "steamcmd.exe"), True)
            Return
        End Try

        ConsoleTab_Click()
        TabMenu.SelectedTab = ConsoleTab
        SteamTerminal = terminal
        SteamView = New ConsoleView(ConsoleOutput, terminal)
        SteamState = New SteamCmdStatus()
        SteamMessage = Nothing
        SteamStopped = False
        SteamKilled = False
        Program = "SteamCmd.exe"
        Game = "Game: " & GamesList.Text
        PathForLog = "Server path: " & ServerPathInstallation

        SetSteamCmdInput(True)
        ConsoleInput.Select()
        If ConsoleTimer Is Nothing Then ConsoleTimer = New Timer(components)
        ConsoleTimer.Interval = ConsoleInterval
        ConsoleTimer.Start()
    End Sub

    Private Sub ConsoleTimer_Tick() Handles ConsoleTimer.Tick
        Dim ended As Boolean = SteamSession.HasExited ' Before TakeOutput, or the last lines could be lost
        Dim text As String = SteamSession.TakeOutput()
        If text <> "" Then ShowOutput(text)
        If ended Then
            SteamCmdEnded()
        ElseIf SteamQuitting IsNot Nothing AndAlso SteamQuitting.ElapsedMilliseconds > QuitTimeout Then
            SteamSession.Kill()
        End If
    End Sub

    Private Sub ShowOutput(text As String)
        Dim scrolled As List(Of String) = SteamTerminal.Feed(text)
        Dim reply As String = SteamTerminal.TakeReply()
        If reply <> "" Then SteamSession.Write(reply)
        SteamView.Render()
        SteamState.Read(SteamTerminal, scrolled)
        DonwloadBar.Value = SteamState.Percent
        MaskConsoleInput(SteamState.Prompt = SteamCmdPrompt.Password)

        Dim message As String = SteamState.Result
        If SteamState.IsWorking Then message = If(SteamMessage Is Nothing, Nothing, "SteamCMD is working...")
        Select Case SteamState.Prompt
            Case SteamCmdPrompt.Password
                message = "SteamCMD asks for the password, type it in the Console tab."
            Case SteamCmdPrompt.Code
                message = "SteamCMD asks for the Steam Guard code, type it in the Console tab."
            Case SteamCmdPrompt.Command
                message = If(SteamState.Result Is Nothing, "SteamCMD is waiting for commands.", SteamState.Result.TrimEnd("."c) & ". SteamCMD is still open.")
        End Select
        ' Only when it changes, the status bar also shows the messages of the other tabs
        If message IsNot Nothing AndAlso message <> SteamMessage AndAlso SteamQuitting Is Nothing Then ShowStatus(message, SteamState.HasFailed AndAlso Not SteamState.IsWorking)
        SteamMessage = message
    End Sub

    Private Sub MaskConsoleInput(mask As Boolean)
        If ConsoleInput.UseSystemPasswordChar = mask Then Return
        ' What has been typed of a password can't be shown
        If Not mask Then ConsoleInput.Clear()
        ConsoleInput.UseSystemPasswordChar = mask
    End Sub

    Private Sub SteamCmdEnded()
        ConsoleTimer.Stop()
        Dim code As Integer = SteamSession.ExitCode
        SteamSession.Dispose()
        SteamSession = Nothing
        SteamQuitting = Nothing
        SetSteamCmdInput(False)
        MaskConsoleInput(False)
        ConsoleInput.Clear()
        DonwloadBar.Value = 0

        If NextInstall IsNot Nothing Then
            Dim arguments As String = NextInstall
            NextInstall = Nothing
            ShowStatus("Installing/Updating...", False)
            RunSteamCmdInConsole(arguments)
        ElseIf SteamKilled Then
            ShowStatus("SteamCMD stopped.", True)
        ElseIf SteamState.IsWorking AndAlso code <> 0 AndAlso code <> 7 Then ' 7 if it has updated itself
            ShowStatus("SteamCMD closed unexpectedly (code " & code & ").", True)
        ElseIf SteamState.Result IsNot Nothing Then
            ShowStatus(SteamState.Result, SteamState.HasFailed)
        Else
            ShowStatus("SteamCMD closed.", False)
        End If
        If SteamStopped Then SaveStoppedLog()
    End Sub

    Private Sub SaveStoppedLog()
        Try
            SaveLog()
        Catch ex As IOException
            ShowStatus("The log can't be saved: " & ex.Message, True)
        Catch ex As UnauthorizedAccessException
            ShowStatus("The log can't be saved: " & ex.Message, True)
        End Try
    End Sub

    ' It closes by itself, so it can save its session. ConsoleTimer kills it if it takes too long.
    Private Sub QuitSteamCmd()
        SteamSession.WriteLine("quit")
        SteamQuitting = Stopwatch.StartNew()
    End Sub

    Private Sub ExecuteButton_Click() Handles ConsoleButton.Click
        If SendToServer() Then Return
        If SteamSession Is Nothing OrElse SteamQuitting IsNot Nothing Then Return
        SteamSession.WriteLine(ConsoleInput.Text)
        SteamState.InputSent(SteamTerminal)
        ConsoleInput.Clear()
        ConsoleInput.Select()
    End Sub

    Private Sub ConsoleInput_KeyDown(sender As Object, e As KeyEventArgs) Handles ConsoleInput.KeyDown
        If e.KeyCode <> Keys.Enter Then Return
        e.SuppressKeyPress = True ' It sounds
        ExecuteButton_Click()
    End Sub

    ' Stop
    Private Sub ConsoleConnect_Click() Handles ConsoleConnect.Click
        If ServerSelected Then
            ToggleServerConnection()
            Return
        End If
        Dim session As PseudoConsoleProcess = SteamSession
        If session Is Nothing Then Return
        If SteamCmdHasWork Then
            If MessageBox.Show("Really want to stop and close SteamCMD?", "Stop SteamCMD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            ' It can end while the question is open
            If SteamSession IsNot session Then Return
        End If

        NextInstall = Nothing
        SteamStopped = True
        If SteamCmdIsIdle Then
            QuitSteamCmd()
        Else
            SteamKilled = SteamCmdHasWork
            session.Kill()
        End If
    End Sub

    Private Sub Console_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not SteamCmdHasWork OrElse e.CloseReason <> CloseReason.UserClosing Then Return
        If MessageBox.Show("SteamCMD is still working. Really want to stop it and exit?", "Stop SteamCMD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then e.Cancel = True
    End Sub

    Private Sub Console_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If SteamSession Is Nothing Then Return
        ConsoleTimer.Stop()
        If e.CloseReason = CloseReason.UserClosing AndAlso Not SteamCmdHasWork Then
            Hide()
            If SteamQuitting Is Nothing Then QuitSteamCmd()
            SteamSession.WaitForExit(QuitTimeout)
        End If
        SteamSession.Dispose()
        SteamSession = Nothing
    End Sub
End Class

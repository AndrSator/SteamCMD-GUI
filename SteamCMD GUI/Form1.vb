Imports System.Net

Module Module1
    Public SteamCMDExePath As String
    Public SteamAppID As String
    Public Login As String
    Public ServerPathInstallation As String
End Module

Public Class Form1

    Dim WithEvents WC As New WebClient

    Private Sub Form1_Load() Handles MyBase.Load
        GamesList.SelectedIndex = 0
        Tips()
    End Sub

    Private Sub SteamCMDDownload_Click() Handles SteamCMDDownloadButton.Click
        SteamCMDDownloadButton.Enabled = False
        If My.Computer.FileSystem.FileExists("steamcmd.zip") Then
            Status.Text = "The file has already been downloaded!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                System.Media.SystemSounds.Hand)
            SteamCMDDownloadButton.Enabled = True
        Else
            WC.DownloadFileAsync(New Uri("http://media.steampowered.com/installer/steamcmd.zip"), "steamcmd.zip")
            Status.Text = "Downloading..."
            Status.BackColor = Color.FromArgb(240, 240, 240)
        End If
    End Sub

    Private Sub OpenFolderButton_Click() Handles OpenFolderButton.Click
        Process.Start("explorer.exe", ".")
    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        If ProgressBar1.Value = 100 Then
            Status.Text = "The file 'steamcmd.zip' has been downloaded. Please, unzip it."
            Status.BackColor = Color.FromArgb(240, 240, 240)
            ProgressBar1.Value = 0
            My.Computer.Audio.PlaySystemSound( _
              System.Media.SystemSounds.Exclamation)
            SteamCMDDownloadButton.Enabled = True
        End If
    End Sub

    Private Sub Tips()
        ToolTip1.SetToolTip(OpenFolderButton, "Open current folder.")
    End Sub

    Private Sub ExePath_TextChanged() Handles ExePath.Click, ExeBrowserButton.Click
        If FolderBrowserDialog2.ShowDialog() = DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(FolderBrowserDialog2.SelectedPath & "\steamcmd.exe") Then
                ExePath.Text = FolderBrowserDialog2.SelectedPath
                SteamCMDExePath = FolderBrowserDialog2.SelectedPath
                Status.Text = "Current path of 'steamcmd.exe' is " & FolderBrowserDialog2.SelectedPath
                Status.BackColor = Color.FromArgb(240, 240, 240)
            Else
                Status.Text = "Can't find the file 'steamcmd.exe'!"
                Status.BackColor = Color.FromArgb(240, 200, 200)
                My.Computer.Audio.PlaySystemSound( _
                    System.Media.SystemSounds.Hand)
            End If
        End If
    End Sub

    Private Sub CustomIDCheckbox_Click() Handles CustomIDCheckbox.CheckedChanged, CustomIDTextBox.TextChanged
        If CustomIDCheckbox.Checked = True Then
            GamesList.Enabled = False
            CustomIDTextBox.Enabled = True
            SteamAppID = CustomIDTextBox.Text
            Status.Text = "Custom Steam App ID: " & SteamAppID
            Status.BackColor = Color.FromArgb(240, 240, 240)
        Else
            GamesList.Enabled = True
            CustomIDTextBox.Enabled = False
        End If
    End Sub

    Private Sub CustomIDTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CustomIDTextBox.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub AnonymousCheckBox_CheckedChanged() Handles AnonymousCheckBox.CheckedChanged
        If AnonymousCheckBox.Checked = True Then
            UsernameTextBox.Enabled = False
            PasswdTextBox.Enabled = False
        Else
            UsernameTextBox.Enabled = True
            PasswdTextBox.Enabled = True
        End If
    End Sub

    Private Sub BrowserButton_Click() Handles BrowserButton.Click, ServerPath.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ServerPath.Text = FolderBrowserDialog1.SelectedPath
            Dim ServerInstallPath As String
            ServerInstallPath = FolderBrowserDialog1.SelectedPath
        End If
        If ServerPath.Text = Nothing Then
            Status.Text = "Please, select a folder for install/update the server"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                System.Media.SystemSounds.Hand)
        Else
            Status.Text = "The server will be installed/updated in '" & ServerPath.Text & "'"
            Status.BackColor = Color.FromArgb(240, 240, 240)
            UpdateServerButton.Enabled = True
        End If
    End Sub

    Private Sub GamesList_SelectedIndexChanged() Handles GamesList.SelectedIndexChanged, GamesList.EnabledChanged
        If GamesList.Text = "Counter-Strike: Global Offensive" Then
            SteamAppID = "740"
        End If
        If GamesList.Text = "Counter-Strike: Source" Then
            SteamAppID = "232330"
        End If
        If GamesList.Text = "Day of Defeat: Source" Then
            SteamAppID = "232290"
        End If
        If GamesList.Text = "Garry's Mod" Then
            SteamAppID = "4020"
        End If
        If GamesList.Text = "Half-Life 2: Deathmatch" Then
            SteamAppID = "232370"
        End If
        If GamesList.Text = "Left 4 Dead 2" Then
            SteamAppID = "222860"
        End If
        If GamesList.Text = "Team Fortress 2" Then
            SteamAppID = "232250"
        End If
        Status.Text = "Game to install: " & GamesList.Text & " - Steam App ID:" & SteamAppID
        Status.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    Private Sub UpdateServerButton_Click() Handles UpdateServerButton.Click
        If My.Computer.FileSystem.FileExists(FolderBrowserDialog2.SelectedPath & "\steamcmd.exe") Then
            If SteamAppID = Nothing Then
                Status.Text = "Steam App ID not defined"
                Status.BackColor = Color.FromArgb(240, 200, 200)
                My.Computer.Audio.PlaySystemSound( _
                    System.Media.SystemSounds.Hand)
            Else
                If AnonymousCheckBox.Checked = True Then
                    Login = "anonymous"
                Else
                    Dim UserName As String
                    Dim Passwd As String
                    UserName = UsernameTextBox.Text
                    Passwd = PasswdTextBox.Text
                    Login = UserName & " " & Passwd
                End If
                If UsernameTextBox.Text = Nothing And AnonymousCheckBox.Checked = False Then
                    Status.Text = "Please, type your Steam name."
                    Status.BackColor = Color.FromArgb(240, 200, 200)
                    My.Computer.Audio.PlaySystemSound( _
                        System.Media.SystemSounds.Hand)
                Else
                    If PasswdTextBox.Text = Nothing And AnonymousCheckBox.Checked = False Then
                        Status.Text = "Please, type your Steam password. You can install many games as 'anonymous'."
                        Status.BackColor = Color.FromArgb(240, 200, 200)
                        My.Computer.Audio.PlaySystemSound( _
                            System.Media.SystemSounds.Hand)
                    Else
                        If ServerPath.Text = Nothing Then
                            Status.Text = "Please, select the path where you want to install the server!"
                            Status.BackColor = Color.FromArgb(240, 200, 200)
                            My.Computer.Audio.PlaySystemSound( _
                                System.Media.SystemSounds.Hand)
                        Else
                            ServerPathInstallation = Chr(34) & ServerPath.Text & Chr(34)
                            Status.Text = "Installing/Updating..."
                            Status.BackColor = Color.FromArgb(240, 240, 240)
                            Process.Start(SteamCMDExePath & "\steamcmd.exe", "SteamCmd +login " & Login & " +force_install_dir " & ServerPathInstallation & " +app_update " & SteamAppID & " validate")
                        End If
                    End If
                End If
            End If
        Else
            Status.Text = "Can't find the file 'steamcmd.exe'!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                System.Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub VDCButton_Click() Handles VDCButton.Click
        Process.Start("https://developer.valvesoftware.com/wiki/SteamCMD")
    End Sub

    Private Sub CheckUpdatesButton_Click() Handles CheckUpdatesButton.Click
        Process.Start("http://gamebanana.com/members/submissions/tools/949805")
    End Sub

    Private Sub SMButton_Click() Handles SMButton.Click
        Process.Start("http://www.sourcemod.net")
    End Sub

    Private Sub MMButton_Click() Handles MMButton.Click
        Process.Start("http://www.sourcemm.net")
    End Sub

    Private Sub ESButton_Click() Handles ESButton.Click
        Process.Start("http://addons.eventscripts.com")
    End Sub

    Private Sub MAPButton_Click() Handles MAPButton.Click
        Process.Start("http://mani-admin-plugin.com")
    End Sub

    Private Sub AboutButton_Click() Handles AboutButton.Click
        Form2.Show()
    End Sub

    Private Sub ExitButton_Click() Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
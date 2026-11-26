Imports System.Globalization
Imports System.Threading
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Text

Module Module1
    Public SteamCMDExePath, SteamAppID, Login, ServerPathInstallation, ValidateApp, GoldSrcMod, Program, Game, PathForLog As String
    ' Run Server
    Public SrcdsExePath, GameMod, ServerName, ServerMap, NetworkType, MaxPlayers, RCON, UDPPort, DebugMode, SourceTV, ConsoleMode, InsecureMode, NoBots, DevMode, AdditionalCommands, Parameters As String
    Public GameServer As ServerType
    ' Strings
    Public CantFindSteamCMDString As String
    Public GameDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
End Module


Public Class MainMenu
    Dim WithEvents WC As New WebClient

    Dim LocalHost As String = Dns.GetHostName
    Dim IPs As IPHostEntry = Dns.GetHostEntry(LocalHost)
    Dim PublicIP As String
    Dim Tf2Install As String

    Private Const GamesListFile As String = "Settings/SteamCMDGames.xml"
    Private Const SteamCmdSettingsFile As String = "Settings/SteamCMDPath.xml"

    Private Declare Function GetInputState Lib "user32" () As Int32

    Private Sub Form1_Load() Handles MyBase.Load
        Dim ConfigFile As String = StartupOptions.ConfigFile(My.Application.CommandLineArgs, Directory.GetCurrentDirectory())
        ' The Settings and Logs folders are next to the program, also if it's opened from another folder
        Directory.SetCurrentDirectory(Application.StartupPath)

        If My.Computer.Network.IsAvailable Then
            Try
                PublicIP = WC.DownloadString("http://ipv4.icanhazip.com/")
            Catch ex As WebException
                PublicIP = "Unknown"
            End Try
        Else
            PublicIP = "Network down"
        End If

        Icon = My.Resources.SteamCMDGUI_Icon
        TabMenu.Size = New Size(417, 303)
        ModList.SelectedIndex = 1
        NetworkComboBox.SelectedIndex = 0
        ConsoleCommandList.SelectedIndex = 0
        Status.Text = ""
        Tips()
        IPPrint()
        If Not Directory.Exists("Settings") Then
            Directory.CreateDirectory("Settings")
        End If
        If Not Directory.Exists("Logs") Then
            Directory.CreateDirectory("Logs")
        End If
        Dim Saved As SteamCmdSettings = SteamCmdSettings.Load(SteamCmdSettingsFile)
        If Saved.CmdPath <> "" Then
            ExePath.Text = Saved.CmdPath
            SteamCMDExePath = Saved.CmdPath
            LogMenu.Enabled = True
        End If
        If Saved.ServerPath <> "" Then
            ServerPath.Text = Saved.ServerPath
            UpdateServerButton.Enabled = True
        End If
        GameDictionary = GameCatalog.LoadOrCreate(GamesListFile)
        GamesList.DataSource = New BindingSource(GameDictionary, Nothing)
        GamesList.DisplayMember = "Value"
        GamesList.ValueMember = "Key"
        GamesList.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
        If GamesList.Items.Count > 1 Then GamesList.SelectedIndex = 1

        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font

        If ConfigFile IsNot Nothing Then LoadServerConfig(ConfigFile)
    End Sub

    Private Sub Tips()
        ToolTip1.SetToolTip(OpenFolderButton, "Open current folder")
        ToolTip1.SetToolTip(CheckBoxMask, "Mask/Unmask RCON and login token")
        ToolTip1.SetToolTip(GsltTextBox, "Game Server Login Token: https://steamcommunity.com/dev/managegameservers")
        ToolTip1.SetToolTip(PasswdTextBox, "Leave it empty to use the session saved by SteamCMD")
        ToolTip1.SetToolTip(RemoveGameButton, "Remove the selected game from the list")
        ToolTip1.SetToolTip(AddButton, "Add more command-line parameters")
        ToolTip1.SetToolTip(ConsoleOpenLog, "Open logs folder")
        ToolTip1.SetToolTip(ConsoleSaveLog, "Save the current log")
        ToolTip1.SetToolTip(ConsoleClearLog, "Clear log")
        CantFindSteamCMDString = "Can't find the file 'steamcmd.exe'!"
    End Sub

    Private Sub IPPrint() Handles ConsoleIPPrint.Click
        For Each LocalIP As System.Net.IPAddress In IPs.AddressList
            ConsoleOutput.Text = "Local IP address:" & vbCr & vbTab & LocalIP.ToString & vbCr & vbCr & "Public IP address:" & vbCr & vbTab & PublicIP
        Next
        IPTextbox.Text = PublicIP
    End Sub

    ' Autosave log
    Private Sub SaveLog()
        Dim ConsoleContent As String = DateTime.Now & " from " & Program & vbCrLf & "______________________" & vbCrLf & Game & vbCrLf & PathForLog & vbCrLf & "______________________" & vbCrLf & ConsoleOutput.Text

        Dim LogFileName As String = Program & " Log-" & DateTime.Now.ToString("dd.MM.yyyy") & " @ " & DateTime.Now.ToString("HH;mm")
        File.WriteAllText("Logs\" & LogFileName & ".txt", ConsoleContent)
    End Sub

    ' Resize tabs
    Private Sub Tab_Click() Handles UpdateTab.Enter, RunTab.Enter
        If GroupBox1.Visible = False Then
            GroupBox1.Show()
            GroupBox3.Show()
            AboutButton.Show()
            ExitButton.Show()
            DonwloadBar.Show()
            TabMenu.Size = New Size(417, 303)
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        End If
    End Sub

    Private Sub ConsoleTab_Click() Handles ConsoleTab.Enter
        GroupBox1.Hide()
        GroupBox3.Hide()
        AboutButton.Hide()
        ExitButton.Hide()
        DonwloadBar.Hide()
        TabMenu.Size = New Size(588, 303)
        ConsoleTab.Size = New Size(580, 277)
        ConsoleOutput.Size = New Size(539, 238)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    End Sub

    ' Update/install server inputs
    Private Sub SteamCMDDownload_Click() Handles SteamCMDDownloadButton.Click
        SteamCMDDownloadButton.Enabled = False
        If My.Computer.FileSystem.FileExists("steamcmd.zip") Then
            Status.Text = "The file has already been downloaded!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
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
        DonwloadBar.Value = e.ProgressPercentage
        If DonwloadBar.Value = 100 Then
            Status.Text = "The file 'steamcmd.zip' has been downloaded. Please, unzip it."
            Status.BackColor = Color.FromArgb(240, 240, 240)
            DonwloadBar.Value = 0
            'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            SteamCMDDownloadButton.Enabled = True
        End If
    End Sub

    Private Sub ExePath_Browser() Handles ExePath.Click, ExeBrowserButton.Click
        Dim folder As String = FolderPicker.Show(Handle, "Select the folder of 'steamcmd.exe'", FolderPicker.FirstExisting(ExePath.Text))
        If folder IsNot Nothing Then
            If My.Computer.FileSystem.FileExists(folder & "\steamcmd.exe") Then
                ExePath.Text = folder
                SteamCMDExePath = folder
                LogMenu.Enabled = True
                Status.Text = "Current path of 'steamcmd.exe' is " & folder
                Status.BackColor = Color.FromArgb(240, 240, 240)
                SaveSteamCmdSettings()
            Else
                LogMenu.Enabled = False
                Status.Text = CantFindSteamCMDString
                Status.BackColor = Color.FromArgb(240, 200, 200)
                My.Computer.Audio.PlaySystemSound( _
                    Media.SystemSounds.Hand)
            End If
        End If
    End Sub

    Private Sub SaveSteamCmdSettings()
        Dim Settings As New SteamCmdSettings()
        Settings.CmdPath = SteamCMDExePath
        Settings.ServerPath = ServerPath.Text
        Try
            Settings.Save(SteamCmdSettingsFile)
        Catch ex As UnauthorizedAccessException
            Status.Text = "The paths can't be saved: " & ex.Message
            Status.BackColor = Color.FromArgb(240, 200, 200)
        Catch ex As IOException
            Status.Text = "The paths can't be saved: " & ex.Message
            Status.BackColor = Color.FromArgb(240, 200, 200)
        End Try
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

    Private Sub IdHelpButton_Click() Handles IdHelpButton.Click
        Process.Start("https://developer.valvesoftware.com/wiki/Dedicated_Servers_List")
    End Sub

    Private Sub BrowserButton_Browser() Handles BrowserButton.Click, ServerPath.Click
        Dim folder As String = FolderPicker.Show(Handle, "Select the folder to install/update the server", FolderPicker.FirstExisting(ServerPath.Text, ExePath.Text))
        If folder IsNot Nothing Then
            ServerPath.Text = folder
        End If
        If ServerPath.Text = "" Then
            Status.Text = "Please, select a folder for install/update the server."
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        Else
            Status.Text = "The server will be installed/updated in '" & ServerPath.Text & "'"
            Status.BackColor = Color.FromArgb(240, 240, 240)
            UpdateServerButton.Enabled = True
            If folder IsNot Nothing Then SaveSteamCmdSettings()
        End If
    End Sub

    Private Sub GamesList_SelectedIndexChanged() Handles GamesList.SelectedIndexChanged, GamesList.EnabledChanged
        If TypeOf (GamesList.SelectedValue) Is KeyValuePair(Of String, String) Then
            SteamAppID = GamesList.SelectedValue.Key
        ElseIf TypeOf (GamesList.SelectedValue) Is Integer Then
            SteamAppID = GamesList.SelectedValue.ToString()
        ElseIf TypeOf (GamesList.SelectedValue) Is String Then
            SteamAppID = GamesList.SelectedValue
        End If


        If Not SteamAppID = 90 Then
            GoldSrcModInput.Hide()
            GoldSrcModLabel.Hide()
            AddCustomGameButton.Show()
            RemoveGameButton.Show()
        Else
            GoldSrcModInput.Show()
            GoldSrcModLabel.Show()
            AddCustomGameButton.Hide()
            RemoveGameButton.Hide()
        End If
        Status.Text = "Game to install: " & GamesList.Text & " - Steam App ID:" & SteamAppID
        Status.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    Private Sub ValidateCheckBox_CheckedChanged() Handles ValidateCheckBox.CheckedChanged
        If ValidateCheckBox.Checked = True Then
            ValidateApp = " validate"
            Status.Text = "The files will be checked and validated."
        Else
            ValidateApp = ""
        End If
    End Sub

    Private Sub UpdateServerButton_Click() Handles UpdateServerButton.Click
        If CheckBoxConsole.Checked AndAlso SteamCmdIsBusy() Then Return
        If My.Computer.FileSystem.FileExists(SteamCMDExePath & "\steamcmd.exe") Then
            If SteamAppID = Nothing Then
                Status.Text = "Steam App ID not defined"
                Status.BackColor = Color.FromArgb(240, 200, 200)
                My.Computer.Audio.PlaySystemSound( _
                    Media.SystemSounds.Hand)
            Else
                Login = CommandLine.SteamLogin(AnonymousCheckBox.Checked, UsernameTextBox.Text, PasswdTextBox.Text)
                If UsernameTextBox.Text = Nothing AndAlso AnonymousCheckBox.Checked = False Then
                    Status.Text = "Please, type your Steam name."
                    Status.BackColor = Color.FromArgb(240, 200, 200)
                    My.Computer.Audio.PlaySystemSound( _
                        Media.SystemSounds.Hand)
                Else
                    If ServerPath.Text = Nothing Then
                        Status.Text = "Please, select the path where you want to install the server."
                        Status.BackColor = Color.FromArgb(240, 200, 200)
                        My.Computer.Audio.PlaySystemSound( _
                            Media.SystemSounds.Hand)
                    Else
                        GoldSrcMod = CommandLine.GoldSrcModConfig(SteamAppID, GoldSrcModInput.Text)
                        ServerPathInstallation = CommandLine.QuotePath(ServerPath.Text)
                        Tf2Install = InstallTf2()
                        If SteamAppID = "90" AndAlso GoldSrcMod = "" Then
                            Status.Text = "Half-Life mod not defined. Installing a default one."
                            Status.BackColor = Color.FromArgb(240, 200, 200)
                            'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
                        Else
                            Status.Text = "Installing/Updating..."
                            Status.BackColor = Color.FromArgb(240, 240, 240)
                        End If

                        Dim Arguments As String = CommandLine.ForSteamCmd(ServerPathInstallation, Login, GoldSrcMod, SteamAppID, ValidateApp) & Tf2Install
                        If CheckBoxConsole.Checked Then
                            RunSteamCmdInConsole(Arguments)
                        Else
                            RunSteamCmdInWindow(Arguments)
                        End If
                    End If
                End If
            End If
        Else
            Status.Text = CantFindSteamCMDString
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        End If
    End Sub

    ' Team Fortress 2 Classified needs the server of Team Fortress 2, it's installed in a folder inside its own
    Private Function InstallTf2() As String
        If SteamAppID <> "3557020" Then Return ""

        Dim folder As String = SourceGames.Tf2FolderOf(ServerPath.Text)
        If SourceGames.TeamFortress2In(folder) Is Nothing AndAlso MessageBox.Show("Team Fortress 2 Classified needs the dedicated server of Team Fortress 2 (about 14 GB)." & vbCrLf & vbCrLf & "Do you want to install it too in '" & folder & "'?", "Team Fortress 2 Classified", MessageBoxButtons.YesNo) = DialogResult.No Then
            Return ""
        End If
        Return CommandLine.AlsoInstall(CommandLine.QuotePath(folder), "232250", ValidateApp)
    End Function

    'Run server inputs
    Private Sub SrcdsExePath_Browser() Handles SrcdsExePathTextBox.Click, SrcdsExeBrowserButton.Click
        Dim folder As String = FolderPicker.Show(Handle, "Select the folder of the server", FolderPicker.FirstExisting(SrcdsExePathTextBox.Text, ServerPath.Text, ExePath.Text))
        If folder IsNot Nothing Then SetServer(folder)
    End Sub

    ' The game configuration is only enabled with the folder of a server
    Private Sub SetServer(ByVal Folder As String)
        Dim Valid As Boolean = SourceGames.HasServer(Folder)
        SrcdsExePathTextBox.Text = Folder
        SrcdsExePath = If(Valid, Folder, Nothing)
        GroupBox6.Enabled = Valid
        MapList.Enabled = Valid
        RunServerButton.Enabled = Valid
        SrcdsExePathOpen.Enabled = Valid
        CFGMenu.Enabled = Valid
        CommonFilesMenu.Enabled = Valid
        SMMenu.Enabled = Valid

        If Valid Then
            SelectDetectedGame(Folder)
            If GameMod = Nothing Then
                Status.Text = "The game of the server wasn't detected. Please, select it or use a custom mod."
            Else
                Status.Text = "Current path of the server is " & Folder
            End If
            Status.BackColor = Color.FromArgb(240, 240, 240)
        Else
            Status.Text = "Can't find any server in '" & Folder & "'!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub SelectDetectedGame(ByVal Folder As String)
        Dim Games As List(Of String) = SourceGames.Detect(Folder)
        If CustomModCheckBox.Checked Then
            If SourceGames.IsGame(Path.Combine(Folder, CustomModTextBox.Text)) Then Return
        ElseIf Games.Contains(ModList.Text) Then
            Return
        End If

        CustomModCheckBox.Checked = False
        ModList.SelectedIndex = If(Games.Count = 0, -1, ModList.FindStringExact(Games.FirstOrDefault()))
        ' The map was of another game
        ServerMap = Nothing
        MapList.Text = ""
    End Sub

    Private Sub SrcdsExePathOpen_Click() Handles SrcdsExePathOpen.Click
        Process.Start("explorer.exe", SrcdsExePath)
    End Sub

    Private Sub ModList_SelectedIndex() Handles ModList.SelectedIndexChanged, ModList.EnabledChanged
        GameMod = SourceGames.FolderOf(ModList.Text)
        GameServer = SourceGames.ServerOf(ModList.Text)
        Status.Text = "Game/Mod to run: " & ModList.Text & " - Game parameter: " & GameMod
        Status.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    Private Sub ModHelpButton_Click() Handles ModHelpButton.Click
        Process.Start("https://developer.valvesoftware.com/wiki/Game_Name_Abbreviations")
    End Sub

    Private Sub CustomModCheckBox_CheckedChanged() Handles CustomModCheckBox.CheckedChanged, CustomModTextBox.TextChanged
        If CustomModCheckBox.Checked = True Then
            ModList.Enabled = False
            CustomModTextBox.Enabled = True
            GameMod = CustomModTextBox.Text
            GameServer = ServerType.Srcds
            DebugModeCheckBox.Enabled = False
            SourceTVCheckBox.Enabled = False
            ConsoleCheckBox.Checked = False
            ConsoleCheckBox.Enabled = False
            InsecureCheckBox.Enabled = False
            BotsCheckBox.Enabled = False
            DevModeCheckBox.Enabled = False
            Status.Text = "Custom Mod: " & GameMod
            Status.BackColor = Color.FromArgb(240, 240, 240)
        Else
            ModList.Enabled = True
            CustomModTextBox.Enabled = False
            DebugModeCheckBox.Enabled = True
            SourceTVCheckBox.Enabled = True
            ConsoleCheckBox.Checked = True
            ConsoleCheckBox.Enabled = True
            InsecureCheckBox.Enabled = True
            BotsCheckBox.Enabled = True
            DevModeCheckBox.Enabled = True
        End If
    End Sub

    Private Sub ServerNameTextBox_TextChanged() Handles ServerNameTextBox.TextChanged
        ServerName = ServerNameTextBox.Text
        Status.Text = "The name of the server will be: " & ServerName
    End Sub

    Private Sub MapList_DropDown() Handles MapList.DropDown
        MapList.Items.Clear()
        Dim mapfolderpath As String
        mapfolderpath = SrcdsExePathTextBox.Text & "\" & GameMod & "\maps"
        If Directory.Exists(mapfolderpath) Then
            MapList.Items.AddRange(SourceGames.Maps(mapfolderpath, GameServer).ToArray())
        Else
            Status.Text = "The 'map' folder is empty or doesn't exist!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub MapList_ChooseMap() Handles MapList.SelectedIndexChanged
        ServerMap = MapList.Text
        Status.Text = "The map of the server will be: " & ServerMap
    End Sub

    Private Sub CheckBoxMask_CheckedChanged() Handles CheckBoxMask.CheckedChanged
        If CheckBoxMask.Checked = True Then
            RconTextBox.PasswordChar = "*"
            RconTextBox.Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)
        Else
            RconTextBox.PasswordChar = ""
            RconTextBox.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
        End If
        GsltTextBox.PasswordChar = RconTextBox.PasswordChar
    End Sub

    Private Sub MaxPlayersTexBox_ValueChanged() Handles MaxPlayersTexBox.TextChanged
        MaxPlayers = MaxPlayersTexBox.Value
        Status.Text = "Max players set to " & MaxPlayers
    End Sub

    Private Sub NetworkComboBox_SelectedIndexChanged() Handles NetworkComboBox.SelectedIndexChanged
        NetworkType = NetworkComboBox.SelectedIndex
        Status.Text = "Cvar sv_lan set to " & NetworkType
    End Sub

    Private Sub RconTextBox_MaskInputRejected() Handles RconTextBox.TextChanged
        RCON = RconTextBox.Text
    End Sub

    Private Sub UDPPortTexBox_ValueChanged() Handles UDPPortTexBox.TextChanged
        UDPPort = UDPPortTexBox.Value
        Status.Text = "UPD port set to " & UDPPort
    End Sub

    'Command-line Arguments
    Private Sub DebugModeCheckBox_CheckedChanged() Handles DebugModeCheckBox.CheckedChanged
        If DebugModeCheckBox.Checked = True Then
            DebugMode = "-debug "
        Else
            DebugMode = ""
        End If
    End Sub

    Private Sub SourceTVCheckBox_CheckedChanged() Handles SourceTVCheckBox.CheckedChanged
        If SourceTVCheckBox.Checked = True Then
            SourceTV = ""
        Else
            SourceTV = "-nohltv "
        End If
    End Sub

    Private Sub ConsoleCheckBox_CheckedChanged() Handles ConsoleCheckBox.CheckedChanged
        If ConsoleCheckBox.Checked = True Then
            ConsoleMode = "-console "
        Else
            ConsoleMode = ""
        End If
    End Sub

    Private Sub InsecureCheckBox_CheckedChanged() Handles InsecureCheckBox.CheckedChanged
        If InsecureCheckBox.Checked = True Then
            InsecureMode = "-insecure "
        Else
            InsecureMode = ""
        End If
    End Sub

    Private Sub BotsCheckBox_CheckedChanged() Handles BotsCheckBox.CheckedChanged
        If BotsCheckBox.Checked = True Then
            NoBots = "-nobots "
        Else
            NoBots = ""
        End If
    End Sub

    Private Sub DevModeCheckBox_CheckedChanged() Handles DevModeCheckBox.CheckedChanged
        If DevModeCheckBox.Checked = True Then
            DevMode = "-dev "
        Else
            DevMode = ""
        End If
    End Sub

    Private Sub AddButton_Click() Handles AddButton.Click
        CommandLineOptionsWindow.Show()
    End Sub

    Private Sub RunServerButton_Click() Handles RunServerButton.Click
        Dim ServerExe As String = Path.Combine(SrcdsExePathTextBox.Text, SourceGames.Executable(GameServer))
        If My.Computer.FileSystem.FileExists(ServerExe) Then
            If GameMod = Nothing Then
                Status.Text = "Please, select a game."
                Status.BackColor = Color.FromArgb(240, 200, 200)
                My.Computer.Audio.PlaySystemSound( _
                    Media.SystemSounds.Hand)
            Else
                If ServerName = Nothing Then
                    Status.Text = "Please, type a name for the server."
                    Status.BackColor = Color.FromArgb(240, 200, 200)
                    My.Computer.Audio.PlaySystemSound( _
                        Media.SystemSounds.Hand)
                Else
                    If ServerMap = Nothing Then
                        Status.Text = "Select the default map."
                        Status.BackColor = Color.FromArgb(240, 200, 200)
                        My.Computer.Audio.PlaySystemSound( _
                            Media.SystemSounds.Hand)
                    ElseIf GameServer <> ServerType.Classified OrElse SetTfPath() Then
                        Parameters = DebugMode & SourceTV & ConsoleMode & InsecureMode & NoBots & DevMode
                        Status.Text = "Running server..."
                        Status.BackColor = Color.FromArgb(240, 240, 240)

                        Dim p As New Process
                        With (p.StartInfo)
                            .FileName = ServerExe
                            .WorkingDirectory = Path.GetDirectoryName(ServerExe)
                            .UseShellExecute = False
                            .CreateNoWindow = False
                            .Arguments = CommandLine.ForServer(CurrentServerOptions())
                        End With

                        p.Start()
                        ServerStarted(p)
                    End If
                End If
            End If
        Else
            Status.Text = "Can't find the file '" & Path.GetFileName(ServerExe) & "'!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        End If
    End Sub

    Private Function CurrentServerOptions() As ServerOptions
        Dim Options As New ServerOptions()
        With Options
            .Server = GameServer
            .Switches = Parameters
            .Folder = GameMod
            .Port = UDPPort
            .HostName = ServerName
            .Map = ServerMap
            .MaxPlayers = MaxPlayers
            .Lan = NetworkComboBox.SelectedIndex
            .Rcon = RCON
            .Gslt = GsltTextBox.Text
            .Additional = AdditionalCommands
        End With
        Return Options
    End Function

    ' Team Fortress 2 Classified uses the files of Team Fortress 2. Their folder is set in the additional parameters
    Private Function SetTfPath() As Boolean
        If CommandLine.HasParameter(AdditionalCommands, "-tf_path") Then Return True

        Dim folder As String = SourceGames.TeamFortress2In(SourceGames.Tf2FolderOf(SrcdsExePathTextBox.Text))
        If folder Is Nothing Then
            MessageBox.Show("Team Fortress 2 Classified needs the files of Team Fortress 2. Its dedicated server can be installed with Team Fortress 2 Classified in the Update/Install tab." & vbCrLf & vbCrLf & "If you already have it, select its folder. It will be added to the Custom Commands, where it can be changed. Don't use the folder of the game if you want to play while the server is running.", "Team Fortress 2 Classified")
            Dim selected As String = FolderPicker.Show(Handle, "Select the folder of the Team Fortress 2 server", Nothing)
            folder = SourceGames.TeamFortress2In(selected)
            If folder Is Nothing Then
                Status.Text = If(selected = "", "Team Fortress 2 Classified needs the folder of Team Fortress 2.", "Team Fortress 2 isn't in '" & selected & "'.")
                Status.BackColor = Color.FromArgb(240, 200, 200)
                My.Computer.Audio.PlaySystemSound( _
                    Media.SystemSounds.Hand)
                Return False
            End If
        End If
        SetAdditionalCommands(CommandLine.AddPath(AdditionalCommands, "-tf_path", folder))
        Return True
    End Function

    Private Sub SetAdditionalCommands(ByVal Commands As String)
        AdditionalCommands = Commands
        If CommandLineOptionsWindow.Visible Then CommandLineOptionsWindow.CommandsTextbox.Text = Commands
    End Sub

    ' Tools buttons
    Private Sub VDCButton_Click() Handles VDCButton.Click
        Process.Start("https://developer.valvesoftware.com/wiki/SteamCMD")
    End Sub

    Private Sub CheckUpdatesButton_Click() Handles CheckUpdatesButton.Click
        Process.Start("https://github.com/AndrSator/SteamCMD-GUI/releases/latest")
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

    'Private Sub MAPButton_Click() Handles MAPButton.Click
    '    Process.Start("http://mani-admin-plugin.com")
    'End Sub

    Private Sub AboutButton_Click() Handles AboutButton.Click, AboutToolStripMenuItem.Click
        AboutWindow.Show()
    End Sub

    Private Sub ExitButton_Click() Handles ExitButton.Click, ExitMenu.Click
        Close()
    End Sub

    'Menu buttons
    Private Sub SaveMenu_Click() Handles SaveMenu.Click, SaveButton.Click
        SaveFileDialog1.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Settings")
        SaveFileDialog1.Filter = "Extensible Markup Language (*.xml)|*.xml"
        SaveFileDialog1.FileName = "Config.xml"

        If SrcdsExePath = Nothing Then
            Status.Text = "Please, select where the server is located in the Run Server tab."
            Status.BackColor = Color.FromArgb(240, 200, 200)
        Else
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim Config As New ServerConfig()
                With Config
                    .Path = SrcdsExePath
                    .HostName = ServerName
                    If CustomModCheckBox.Checked Then
                        .CustomMod = CustomModTextBox.Text
                    Else
                        .GameName = ModList.Text
                    End If
                    .Map = ServerMap
                    .Network = NetworkType
                    .Players = MaxPlayers
                    .Rcon = RCON
                    .Gslt = GsltTextBox.Text
                    .Port = UDPPort
                    .AdditionalCommands = AdditionalCommands
                End With
                Try
                    Config.Save(SaveFileDialog1.FileName)
                    Status.Text = Path.GetFileName(SaveFileDialog1.FileName) & " file saved."
                    Status.BackColor = Color.FromArgb(240, 240, 240)
                    'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                Catch ex As Exception When TypeOf ex Is UnauthorizedAccessException OrElse TypeOf ex Is IOException
                    Status.Text = "The config file can't be saved: " & ex.Message
                    Status.BackColor = Color.FromArgb(240, 200, 200)
                    My.Computer.Audio.PlaySystemSound( _
                        Media.SystemSounds.Hand)
                End Try
            End If
        End If
    End Sub

    Private Sub LoadMenu_Click() Handles LoadMenu.Click
        XmlConfigOpenFileDialog.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Settings")
        XmlConfigOpenFileDialog.FileName = "*.xml"
        XmlConfigOpenFileDialog.Filter = "Extensible Markup Language (*.xml)|*.xml"

        If XmlConfigOpenFileDialog.ShowDialog() = DialogResult.OK Then
            LoadServerConfig(XmlConfigOpenFileDialog.FileName)
        End If
    End Sub

    Private Sub LoadServerConfig(ByVal ConfigFile As String)
        Dim Config As ServerConfig
        Try
            Config = ServerConfig.Load(ConfigFile)
        Catch ex As Exception When TypeOf ex Is XmlException OrElse TypeOf ex Is IOException OrElse TypeOf ex Is UnauthorizedAccessException OrElse TypeOf ex Is ArgumentException
            Status.Text = "The config file can't be loaded: " & ex.Message
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
            Return
        End Try

        If Config.SteamCmdPath IsNot Nothing Then SteamCMDExePath = Config.SteamCmdPath
        If Config.Path IsNot Nothing Then SetServer(Config.Path)
        If Config.HostName IsNot Nothing Then ServerNameTextBox.Text = Config.HostName
        If Config.CustomMod IsNot Nothing Then
            CustomModTextBox.Text = Config.CustomMod
            CustomModCheckBox.Checked = True
        ElseIf Config.GameName IsNot Nothing Then
            CustomModCheckBox.Checked = False
            'If the game is not in the list, the detected one is used
            Dim Game As Integer = ModList.FindStringExact(Config.GameName)
            If Game >= 0 Then ModList.SelectedIndex = Game
            ModList_SelectedIndex()
        End If
        If Config.Map IsNot Nothing Then
            ServerMap = Config.Map
            MapList.Text = ServerMap
        End If
        Dim Network As Integer
        If Integer.TryParse(Config.Network, Network) AndAlso Network >= 0 AndAlso Network < NetworkComboBox.Items.Count Then
            NetworkComboBox.SelectedIndex = Network
        End If
        SetNumber(MaxPlayersTexBox, Config.Players)
        MaxPlayers = MaxPlayersTexBox.Value
        SetNumber(UDPPortTexBox, Config.Port)
        UDPPort = UDPPortTexBox.Value
        If Config.Rcon IsNot Nothing Then
            RconTextBox.Text = Config.Rcon
            RCON = Config.Rcon
            CheckBoxMask.Checked = True
        End If
        ' These are not saved when they are empty, so the ones of the previous config have to be removed
        GsltTextBox.Text = Config.Gslt
        SetAdditionalCommands(Config.AdditionalCommands)

        TabMenu.SelectedTab = RunTab
        GroupBox1.Show()
        GroupBox3.Show()
        If GroupBox6.Enabled Then
            Status.Text = "The config file has been loaded."
            Status.BackColor = Color.FromArgb(240, 240, 240)
        Else
            Status.Text = "The config file has been loaded, but there isn't any server in '" & SrcdsExePathTextBox.Text & "'."
            Status.BackColor = Color.FromArgb(240, 200, 200)
        End If
    End Sub

    Private Sub SetNumber(ByVal Box As NumericUpDown, ByVal Text As String)
        Dim Number As Decimal
        If Decimal.TryParse(Text, Number) Then Box.Value = Math.Max(Box.Minimum, Math.Min(Box.Maximum, Number))
    End Sub

    Private Sub CFGMenu_DropDownOpening() Handles ToolsMenu.Click
        If CFGMenu.Enabled = True Then
            CFGMenu.DropDownItems.Clear()
            CFGMenu.DropDownItems.Add(NewFileToolStripMenuItem)
            CFGMenu.DropDownItems.Add("-")
            Dim cfgfolderpath As String
            cfgfolderpath = SrcdsExePathTextBox.Text & "\" & GameMod & "\cfg"
            If Directory.Exists(cfgfolderpath) = True Then
                'Create new submenu for each cfg file
                For Each CfgFile As String In My.Computer.FileSystem.GetFiles _
                        (cfgfolderpath, FileIO.SearchOption.SearchTopLevelOnly, "*.cfg")
                    Dim text = Path.GetFileNameWithoutExtension(CfgFile)
                    Dim item As ToolStripItem = CFGMenu.DropDownItems.Add(text)
                    item.Tag = CfgFile
                    AddHandler item.Click, AddressOf CfgMenuItems_Click
                    'This works thanks to Hans Passant ^^
                Next
            Else
                Status.Text = "Can't find the CFG folder. New one created."
                Directory.CreateDirectory(cfgfolderpath)
            End If
        Else
            Status.Text = "Can't find the server files!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub CfgMenuItems_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripItem)
        Dim path = CStr(item.Tag)
        Process.Start(path)
    End Sub

    Private Sub NewFile_Click() Handles NewFileToolStripMenuItem.Click
        SaveFileDialog1.InitialDirectory = SrcdsExePathTextBox.Text & "\" & GameMod & "\cfg"
        SaveFileDialog1.Filter = "Configuration files (*.cfg)|*.cfg"
        SaveFileDialog1.FileName = "Config.cfg"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            File.Create(SaveFileDialog1.FileName).Dispose()
            Process.Start(SaveFileDialog1.FileName)
            Status.Text = "File " & SaveFileDialog1.FileName & " has been saved."
        End If
    End Sub

    Private Sub MenuTxt_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MotdTxtButton.Click, MapcycleTxtButton.Click, MaplistTxtButton.Click
        Dim TxtFile As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim MotdPath As String = SrcdsExePath & "\" & GameMod & "\" & TxtFile.Text & ".txt"
        If File.Exists(MotdPath) Then
            Process.Start(MotdPath)
        Else
            File.Create(MotdPath).Dispose()
            Process.Start(MotdPath)
            Status.Text = TxtFile.Text & " file not found. New one created."
        End If
    End Sub

    Private Sub SMMenu_Click() Handles SMMenu.MouseHover, SMMenu.Click
        If SMMenu.Enabled = True Then
            SMMenu.DropDownItems.Clear()
            Dim SMFilesPath As String
            SMFilesPath = SrcdsExePathTextBox.Text & "\" & GameMod & "\addons\sourcemod\configs"
            If Directory.Exists(SMFilesPath) Then
                'Create new submenu for each cfg and txt file
                For Each SMFile As String In My.Computer.FileSystem.GetFiles _
                        (SMFilesPath, FileIO.SearchOption.SearchTopLevelOnly, "*.cfg", "*.txt", "*.ini")
                    Dim text = Path.GetFileNameWithoutExtension(SMFile)
                    Dim item As ToolStripItem = SMMenu.DropDownItems.Add(text)
                    item.Tag = SMFile
                    AddHandler item.Click, AddressOf SMFileMenuItems_Click
                Next
            Else
                Status.Text = "Seems that SourceMod isn't installed."
                Status.BackColor = Color.FromArgb(240, 200, 200)
                'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            End If
        End If
    End Sub

    Private Sub SMFileMenuItems_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripItem)
        Dim path = CStr(item.Tag)
        Process.Start(path)
    End Sub

    Private Sub LogMenu_Click() Handles LogMenu.MouseHover, LogMenu.Click
        If LogMenu.Enabled = True Then
            LogMenu.DropDownItems.Clear()
            Dim LogFilesPath As String
            LogFilesPath = ExePath.Text & "\logs"
            If Directory.Exists(LogFilesPath) Then
                'Create new submenu for each txt file
                For Each LogFile As String In My.Computer.FileSystem.GetFiles _
                        (LogFilesPath, FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
                    Dim text = Path.GetFileNameWithoutExtension(LogFile)
                    Dim item As ToolStripItem = LogMenu.DropDownItems.Add(text)
                    item.Tag = LogFile
                    AddHandler item.Click, AddressOf LogFileMenuItems_Click
                Next
            End If
        End If
    End Sub

    Private Sub LogFileMenuItems_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripItem)
        Dim path = CStr(item.Tag)
        Process.Start(path)
    End Sub

    ' Console Tab
    Private Sub ConsoleOpenLog_Click() Handles ConsoleOpenLog.Click
        Process.Start("explorer.exe", ".\Logs")
    End Sub

    Private Sub ConsoleSaveLog_Click() Handles ConsoleSaveLog.Click
        SaveFileDialog1.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs")
        SaveFileDialog1.DefaultExt = "*.txt"
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt"
        SaveFileDialog1.FileName = "log.txt"

        If (SaveFileDialog1.ShowDialog() = DialogResult.OK) _
            AndAlso (SaveFileDialog1.FileName.Length > 0) Then
            File.WriteAllText(SaveFileDialog1.FileName, ConsoleOutput.Text)
            Process.Start(SaveFileDialog1.FileName)
            Status.Text = "File " & Path.GetFileName(SaveFileDialog1.FileName) & " has been saved in Logs folder."
        End If
    End Sub

    Private Sub ConsoleClearLog_Click() Handles ConsoleClearLog.Click
        Dim result As Integer = MessageBox.Show("Really want to clear all the content?", "Clear console", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            ConsoleOutput.Clear()
            Status.Text = "The console has been cleaned."
        End If
    End Sub

    Private Sub AddCustomGameButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AddCustomGameButton.Click
        Dim Name As String = ""
        Dim ID As String = ""

        Name = InputBox("Custom Game Name")
        ID = InputBox("Custom Game App ID")

        If ("" = Name) Then
            My.Computer.Audio.PlaySystemSound( _
            Media.SystemSounds.Hand)
            MessageBox.Show("Custom Game Name was not entered.", "Add Custom Game Error")
            Return
        End If

        If ("" = ID) Then
            My.Computer.Audio.PlaySystemSound( _
            Media.SystemSounds.Hand)
            MessageBox.Show("Custom Game ID was not entered.", "Add Custom Game Error")
            Return
        End If

        Dim TestInt As Integer = 0
        Integer.TryParse(ID, TestInt)
        If (TestInt = 0) Then
            My.Computer.Audio.PlaySystemSound( _
            Media.SystemSounds.Hand)
            MessageBox.Show("Custom Game ID was not a number (e.x 444880).", "Add Custom Game Error")
            Return
        End If

        If GameDictionary.ContainsKey(ID) AndAlso MessageBox.Show("The ID " & ID & " is already used by '" & GameDictionary(ID) & "'. Do you want to replace it?", "Add Custom Game", MessageBoxButtons.YesNo) = DialogResult.No Then
            Return
        End If

        GameDictionary(ID) = Name
        SaveGamesList()
        GamesList.SelectedIndex = GamesList.FindStringExact(Name)
    End Sub

    Private Sub RemoveGameButton_Click() Handles RemoveGameButton.Click
        If GameDictionary.Count = 1 Then
            Status.Text = "The last game of the list can't be removed."
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        ElseIf MessageBox.Show("Really want to remove '" & GamesList.Text & "' from the list?", "Remove Game", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            GameDictionary.Remove(SteamAppID)
            SaveGamesList()
        End If
    End Sub

    Private Sub SaveGamesList()
        Try
            GameCatalog.Save(GamesListFile, GameDictionary)
        Catch ex As UnauthorizedAccessException
            MessageBox.Show("The list of games can't be saved: " & ex.Message, "Games List Error")
        Catch ex As IOException
            MessageBox.Show("The list of games can't be saved: " & ex.Message, "Games List Error")
        End Try
        GamesList.DataSource = New BindingSource(GameDictionary, Nothing)
    End Sub

    Private Sub IPButton_Click() Handles IPButton.Click
        Clipboard.SetText(PublicIP, TextDataFormat.UnicodeText)
        Status.Text = "Public IP copied"
        Status.BackColor = Color.FromArgb(240, 240, 240)
    End Sub
End Class
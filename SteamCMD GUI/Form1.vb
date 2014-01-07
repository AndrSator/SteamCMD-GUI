Imports System.IO
Imports System.Net
Imports System.Xml

Module Module1
    Public SteamCMDExePath, SteamAppID, Login, ServerPathInstallation As String
    ' Run Server
    Public SrcdsExePath, GameMod, ServerName, ServerMap, NetworkType, MaxPlayers, RCON, UDPPort, DebugMode, SourceTV, ConsoleMode, InsecureMode, NoBots, DevMode As String
    Public Parameters As String
End Module


Public Class Form1
    Dim WithEvents WC As New WebClient

    Private Sub Form1_Load() Handles MyBase.Load
        GamesList.SelectedIndex = 0
        ModList.SelectedIndex = 0
        NetworkComboBox.SelectedIndex = 0
        Status.Text = ""
        Tips()

        If Not System.IO.Directory.Exists("Settings") Then
            System.IO.Directory.CreateDirectory("Settings")
        End If

        If File.Exists("SteamCMDPath.xml") Then
            Dim XmlConfig As XmlReader = New XmlTextReader("SteamCMDPath.xml")
            While (XmlConfig.Read())
                Dim type = XmlConfig.NodeType
                If (type = XmlNodeType.Element) Then
                    If (XmlConfig.Name = "CMDPath") Then
                        ExePath.Text = XmlConfig.ReadInnerXml.ToString()
                        FolderBrowserDialog2.SelectedPath = ExePath.Text
                        SteamCMDExePath = ExePath.Text
                    End If
                End If
            End While
            XmlConfig.Close()
        End If
    End Sub

    ' Update/install server inputs
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
        ToolTip1.SetToolTip(OpenFolderButton, "Open current folder")
        ToolTip1.SetToolTip(CheckBoxMask, "Mask/Unmask RCON")
    End Sub

    Private Sub ExePath_Browser() Handles ExePath.Click, ExeBrowserButton.Click
        If FolderBrowserDialog2.ShowDialog() = DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(FolderBrowserDialog2.SelectedPath & "\steamcmd.exe") Then
                ExePath.Text = FolderBrowserDialog2.SelectedPath
                SteamCMDExePath = FolderBrowserDialog2.SelectedPath

                Dim CMDConfig As New XmlWriterSettings()
                CMDConfig.Indent = True

                Dim XmlWrt As XmlWriter = XmlWriter.Create("SteamCMDPath.xml", CMDConfig)
                With XmlWrt
                    .WriteStartDocument()
                    .WriteComment("Config used by SteamCMD GUI")
                    .WriteComment("This config it's loaded automatically.")
                    .WriteStartElement("SteamCMD-Config")

                    .WriteStartElement("CMDPath")
                    .WriteString(SteamCMDExePath)
                    .WriteEndElement()

                    .WriteEndElement()
                    .WriteEndDocument()
                End With
                XmlWrt.Close()

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

    Private Sub IdHelpButton_Click() Handles IdHelpButton.Click
        Process.Start("https://developer.valvesoftware.com/wiki/SteamCMD#Supported_Servers")
    End Sub

    Private Sub BrowserButton_Browser() Handles BrowserButton.Click, ServerPath.Click
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

    ' Run server inputs
    Private Sub SrcdsExePath_Browser() Handles SrcdsExePathTextBox.Click, SrcdsExeBrowserButton.Click
        If FolderBrowserDialog3.ShowDialog() = DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(FolderBrowserDialog3.SelectedPath & "\srcds.exe") Then
                SrcdsExePathTextBox.Text = FolderBrowserDialog3.SelectedPath
                SrcdsExePath = FolderBrowserDialog3.SelectedPath
                MapList.Enabled = True
                Status.Text = "Current path of 'srcds.exe' is " & FolderBrowserDialog3.SelectedPath
                Status.BackColor = Color.FromArgb(240, 240, 240)
                SrcdsExePathOpen.Enabled = True
                CFGMenu.Enabled = True
                MOTDMenu.Enabled = True
                RunServerButton.Enabled = True
            Else
                SrcdsExePathOpen.Enabled = False
                MapList.Enabled = False
                CFGMenu.Enabled = False
                MOTDMenu.Enabled = False
                RunServerButton.Enabled = False
                Status.Text = "Can't find the file 'srcds.exe'!"
                Status.BackColor = Color.FromArgb(240, 200, 200)
                My.Computer.Audio.PlaySystemSound( _
                    System.Media.SystemSounds.Hand)
            End If
        End If
    End Sub

    Private Sub SrcdsExePathOpen_Click() Handles SrcdsExePathOpen.Click
        Process.Start("explorer.exe", SrcdsExePath)
    End Sub

    Private Sub ModList_SelectedIndex() Handles ModList.SelectedIndexChanged, ModList.EnabledChanged
        If ModList.Text = "Counter-Strike: Global Offensive" Then
            GameMod = "csgo"
        End If
        If ModList.Text = "Counter-Strike: Source" Then
            GameMod = "cstrike"
        End If
        If ModList.Text = "Day of Defeat: Source" Then
            GameMod = "dod"
        End If
        If ModList.Text = "Garry's Mod" Then
            GameMod = "garrysmod"
        End If
        If ModList.Text = "Half-Life 2: Deathmatch" Then
            GameMod = "hl2mp"
        End If
        If ModList.Text = "Left 4 Dead 2" Then
            GameMod = "left4dead2"
        End If
        If ModList.Text = "Team Fortress 2" Then
            GameMod = "tf"
        End If
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
        If System.IO.Directory.Exists(mapfolderpath) Then
            For Each MapFile As String In My.Computer.FileSystem.GetFiles _
                (mapfolderpath, FileIO.SearchOption.SearchTopLevelOnly, "*.bsp")
                MapList.Items.Add(System.IO.Path.GetFileNameWithoutExtension(MapFile))
            Next
        Else
            Status.Text = "The 'map' folder is empty or doesn't exist!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                System.Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub MapList_ChooseMap() Handles MapList.SelectedIndexChanged
        ServerMap = MapList.Text
        Status.Text = "The map of the server will be: " & ServerMap
    End Sub

    Private Sub CheckBoxMask_CheckedChanged() Handles CheckBoxMask.CheckedChanged
        If CheckBoxMask.Checked = True Then
            RconTextBox.PasswordChar = "*"
            RconTextBox.Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold) 'Microsoft Sans Serif, 9.75pt, style=Bold
        Else
            RconTextBox.PasswordChar = ""
            RconTextBox.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
        End If
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

    Private Sub RunServerButton_Click() Handles RunServerButton.Click
        If GameMod = Nothing Then
            Status.Text = "Please, select a game."
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                System.Media.SystemSounds.Hand)
        Else
            If ServerName = Nothing Then
                Status.Text = "Please, type a name for the server."
                Status.BackColor = Color.FromArgb(240, 200, 200)
                My.Computer.Audio.PlaySystemSound( _
                    System.Media.SystemSounds.Hand)
            Else
                If ServerMap = Nothing Then
                    Status.Text = "Select the default map."
                    Status.BackColor = Color.FromArgb(240, 200, 200)
                    My.Computer.Audio.PlaySystemSound( _
                        System.Media.SystemSounds.Hand)
                Else
                    Parameters = DebugMode & SourceTV & ConsoleMode & InsecureMode & NoBots & DevMode
                    Status.Text = "Running server..."
                    Status.BackColor = Color.FromArgb(240, 240, 240)
                    Process.Start(SrcdsExePath & "\srcds.exe", Parameters & "-game " & GameMod & " -port " & UDPPort & " +hostname " & Chr(34) & ServerName & Chr(34) & " +map " & ServerMap & " +maxplayers " & MaxPlayers & " +sv_lan " & NetworkComboBox.SelectedIndex)
                End If
            End If
        End If
    End Sub

    ' Tools buttons
    Private Sub VDCButton_Click() Handles VDCButton.Click
        Process.Start("https://developer.valvesoftware.com/wiki/SteamCMD")
    End Sub

    Private Sub CheckUpdatesButton_Click() Handles CheckUpdatesButton.Click
        Process.Start("https://github.com/DioJoestar/SteamCMD-GUI")
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

    Private Sub AboutButton_Click() Handles AboutButton.Click, AboutToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub ExitButton_Click() Handles ExitButton.Click, ExitMenu.Click
        Me.Close()
    End Sub

    'Menu buttons
    Private Sub SaveMenu_Click() Handles SaveMenu.Click, SaveButton.Click
        SaveFileDialog1.InitialDirectory = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Settings")
        SaveFileDialog1.Filter = "Extensible Markup Language (*.xml)|*.xml"
        SaveFileDialog1.FileName = "Config.xml"

        If SrcdsExePath = Nothing Then
            Status.Text = "Please, select where is located the file 'srcds.exe'."
            Status.BackColor = Color.FromArgb(240, 200, 200)
        Else
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim ConfigFile As String = SaveFileDialog1.FileName
                Dim Config As New XmlWriterSettings()
                Config.Indent = True

                Dim XmlWrt As XmlWriter = XmlWriter.Create(ConfigFile, Config)
                With XmlWrt
                    .WriteStartDocument()
                    .WriteComment("Config used by SteamCMD GUI")
                    .WriteStartElement("Config")

                    .WriteStartElement("Srcds-Config")

                    .WriteStartElement("Path")
                    .WriteString(SrcdsExePath)
                    .WriteEndElement()

                    .WriteEndElement()

                    .WriteStartElement("Server-Config")

                    .WriteStartElement("Mod")
                    .WriteString(ModList.Text)
                    .WriteEndElement()

                    .WriteStartElement("HostName")
                    .WriteString(ServerName)
                    .WriteEndElement()

                    .WriteStartElement("Map")
                    .WriteString(ServerMap)
                    .WriteEndElement()

                    .WriteStartElement("Network")
                    .WriteString(NetworkType)
                    .WriteEndElement()

                    .WriteStartElement("Players")
                    .WriteString(MaxPlayers)
                    .WriteEndElement()

                    .WriteStartElement("RCON")
                    .WriteString(RCON)
                    .WriteEndElement()

                    .WriteStartElement("Port")
                    .WriteString(UDPPort)
                    .WriteEndElement()

                    .WriteEndDocument()
                End With
                XmlWrt.Close()
                Status.Text = Path.GetFileName(ConfigFile) & " file saved."
                Status.BackColor = Color.FromArgb(240, 240, 240)
                My.Computer.Audio.PlaySystemSound( _
                  System.Media.SystemSounds.Exclamation)
            End If
        End If
    End Sub

    Private Sub LoadMenu_Click() Handles LoadMenu.Click
        XmlConfigOpenFileDialog.InitialDirectory = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Settings")
        XmlConfigOpenFileDialog.FileName = "*.xml"
        XmlConfigOpenFileDialog.Filter = "Extensible Markup Language (*.xml)|*.xml"

        If XmlConfigOpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim XmlConfig As XmlReader = New XmlTextReader(XmlConfigOpenFileDialog.FileName)
            While (XmlConfig.Read())
                Dim type = XmlConfig.NodeType
                If (type = XmlNodeType.Element) Then
                    If (XmlConfig.Name = "SteamCMD") Then
                        SteamCMDExePath = XmlConfig.ReadInnerXml.ToString()
                    End If
                    If (XmlConfig.Name = "Path") Then
                        SrcdsExePath = XmlConfig.ReadInnerXml.ToString()
                        SrcdsExePathTextBox.Text = SrcdsExePath
                        MapList.Enabled = True
                        CFGMenu.Enabled = True
                        MOTDMenu.Enabled = True
                        RunServerButton.Enabled = True
                        SrcdsExePathOpen.Enabled = True
                    End If
                    If (XmlConfig.Name = "HostName") Then
                        ServerNameTextBox.Text = XmlConfig.ReadInnerXml.ToString()
                    End If
                    If (XmlConfig.Name = "Mod") Then
                        ModList.Text = XmlConfig.ReadInnerXml.ToString()
                        ' Define the game with ModList.Text
                        ModList_SelectedIndex()
                    End If
                    If (XmlConfig.Name = "Map") Then
                        MapList.Enabled = True
                        ServerMap = XmlConfig.ReadInnerXml.ToString()
                        MapList.Text = ServerMap
                    End If
                    If (XmlConfig.Name = "Network") Then
                        NetworkComboBox.SelectedIndex = XmlConfig.ReadInnerXml.ToString()
                    End If
                    If (XmlConfig.Name = "Players") Then
                        MaxPlayers = XmlConfig.ReadInnerXml.ToString
                        MaxPlayersTexBox.Value = MaxPlayers
                    End If
                    If (XmlConfig.Name = "RCON") Then
                        RCON = XmlConfig.ReadInnerXml.ToString
                        RconTextBox.Text = RCON
                        CheckBoxMask.Checked = True
                    End If
                    If (XmlConfig.Name = "Port") Then
                        UDPPort = XmlConfig.ReadInnerXml.ToString
                        UDPPortTexBox.Value = UDPPort
                    End If
                End If
            End While
            XmlConfig.Close()
            TabMenu.SelectedTab = RunTab
            Status.Text = "The config file has been loaded."
            Status.BackColor = Color.FromArgb(240, 240, 240)
        End If
    End Sub

    Private Sub CFGMenu_DropDownOpening() Handles ToolsMenu.Click
        If CFGMenu.Enabled = True Then
            CFGMenu.DropDownItems.Clear()
            CFGMenu.DropDownItems.Add(NewFileToolStripMenuItem)
            CFGMenu.DropDownItems.Add("-")
            Dim cfgfolderpath As String
            cfgfolderpath = SrcdsExePathTextBox.Text & "\" & GameMod & "\cfg"
            If System.IO.Directory.Exists(cfgfolderpath) Then
                'Create new submenu for each cfg file
                For Each CfgFile As String In My.Computer.FileSystem.GetFiles _
                        (cfgfolderpath, FileIO.SearchOption.SearchTopLevelOnly, "*.cfg")
                    Dim text = System.IO.Path.GetFileNameWithoutExtension(CfgFile)
                    Dim item As ToolStripItem = CFGMenu.DropDownItems.Add(text)
                    item.Tag = CfgFile
                    AddHandler item.Click, AddressOf CfgMenuItems_Click
                    ' This works thanks to Hans Passant ^^
                Next
            End If
        Else
            Status.Text = "The 'cfg' folder is empty or doesn't exist!"
        End If
    End Sub

    Private Sub CfgMenuItems_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripItem)
        Dim path = CStr(item.Tag)
        Process.Start(path)
    End Sub

    Private Sub NewFile_Click() Handles NewFileToolStripMenuItem.Click
        SaveFileDialog2.InitialDirectory = SrcdsExePathTextBox.Text & "\" & GameMod & "\cfg"
        SaveFileDialog2.Filter = "Configuration files (*.cfg)|*.cfg"
        SaveFileDialog2.FileName = "Config.cfg"
        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
            File.Create(SaveFileDialog2.FileName).Dispose()
            Process.Start(SaveFileDialog2.FileName)
            Status.Text = "File " & SaveFileDialog2.FileName & " has been saved"
        End If
    End Sub

    Private Sub MOTD_Click() Handles MOTDMenu.Click
        Dim MotdPath As String = SrcdsExePath & "\" & GameMod & "\motd.txt"
        If File.Exists(MotdPath) Then
            Process.Start(MotdPath)
        Else
            File.Create(MotdPath).Dispose()
            Process.Start(MotdPath)
            Status.Text = "MODT file not found. New one created."
        End If
    End Sub
End Class
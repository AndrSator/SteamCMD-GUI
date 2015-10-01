<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose( disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.GamesList = New System.Windows.Forms.ComboBox()
        Me.SteamCMDDownloadButton = New System.Windows.Forms.Button()
        Me.DonwloadBar = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OpenFolderButton = New System.Windows.Forms.Button()
        Me.CheckUpdatesButton = New System.Windows.Forms.Button()
        Me.VDCButton = New System.Windows.Forms.Button()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AddCustomGameButton = New System.Windows.Forms.Button()
        Me.CheckBoxConsole = New System.Windows.Forms.CheckBox()
        Me.ValidateCheckBox = New System.Windows.Forms.CheckBox()
        Me.IdHelpButton = New System.Windows.Forms.Button()
        Me.BrowserButton = New System.Windows.Forms.Button()
        Me.UpdateServerButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ServerPath = New System.Windows.Forms.TextBox()
        Me.AnonymousCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswdTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.GoldSrcModLabel = New System.Windows.Forms.Label()
        Me.GoldSrcModInput = New System.Windows.Forms.TextBox()
        Me.Status = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ESButton = New System.Windows.Forms.Button()
        Me.MMButton = New System.Windows.Forms.Button()
        Me.SMButton = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ExeBrowserButton = New System.Windows.Forms.Button()
        Me.ExePath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabMenu = New System.Windows.Forms.TabControl()
        Me.UpdateTab = New System.Windows.Forms.TabPage()
        Me.RunTab = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.AddButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.InsecureCheckBox = New System.Windows.Forms.CheckBox()
        Me.DevModeCheckBox = New System.Windows.Forms.CheckBox()
        Me.RunServerButton = New System.Windows.Forms.Button()
        Me.ConsoleCheckBox = New System.Windows.Forms.CheckBox()
        Me.BotsCheckBox = New System.Windows.Forms.CheckBox()
        Me.SourceTVCheckBox = New System.Windows.Forms.CheckBox()
        Me.DebugModeCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckBoxMask = New System.Windows.Forms.CheckBox()
        Me.UDPPortTexBox = New System.Windows.Forms.NumericUpDown()
        Me.RconTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NetworkComboBox = New System.Windows.Forms.ComboBox()
        Me.ServerNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MaxPlayersTexBox = New System.Windows.Forms.NumericUpDown()
        Me.ModHelpButton = New System.Windows.Forms.Button()
        Me.CustomModTextBox = New System.Windows.Forms.TextBox()
        Me.ModList = New System.Windows.Forms.ComboBox()
        Me.CustomModCheckBox = New System.Windows.Forms.CheckBox()
        Me.MapList = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.SrcdsExePathOpen = New System.Windows.Forms.Button()
        Me.SrcdsExeBrowserButton = New System.Windows.Forms.Button()
        Me.SrcdsExePathTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ConsoleTab = New System.Windows.Forms.TabPage()
        Me.ConsoleConnect = New System.Windows.Forms.Button()
        Me.ConsoleIPPrint = New System.Windows.Forms.Button()
        Me.ConsoleClearLog = New System.Windows.Forms.Button()
        Me.ConsoleOpenLog = New System.Windows.Forms.Button()
        Me.ConsoleSaveLog = New System.Windows.Forms.Button()
        Me.ConsoleCommandList = New System.Windows.Forms.ComboBox()
        Me.ConsoleButton = New System.Windows.Forms.Button()
        Me.ConsoleInput = New System.Windows.Forms.TextBox()
        Me.ConsoleOutput = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommonFilesMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MotdTxtButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapcycleTxtButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaplistTxtButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.CFGMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SMMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Empty = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XmlConfigOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.DonateButton = New System.Windows.Forms.PictureBox()
        Me.IPTextbox = New System.Windows.Forms.TextBox()
        Me.IPButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabMenu.SuspendLayout()
        Me.UpdateTab.SuspendLayout()
        Me.RunTab.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.UDPPortTexBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxPlayersTexBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ConsoleTab.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DonateButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GamesList
        '
        Me.GamesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GamesList.FormattingEnabled = True
        resources.ApplyResources(Me.GamesList, "GamesList")
        Me.GamesList.Items.AddRange(New Object() {resources.GetString("GamesList.Items"), resources.GetString("GamesList.Items1"), resources.GetString("GamesList.Items2"), resources.GetString("GamesList.Items3"), resources.GetString("GamesList.Items4"), resources.GetString("GamesList.Items5"), resources.GetString("GamesList.Items6"), resources.GetString("GamesList.Items7"), resources.GetString("GamesList.Items8"), resources.GetString("GamesList.Items9"), resources.GetString("GamesList.Items10")})
        Me.GamesList.Name = "GamesList"
        '
        'SteamCMDDownloadButton
        '
        resources.ApplyResources(Me.SteamCMDDownloadButton, "SteamCMDDownloadButton")
        Me.SteamCMDDownloadButton.Name = "SteamCMDDownloadButton"
        Me.SteamCMDDownloadButton.UseVisualStyleBackColor = True
        '
        'DonwloadBar
        '
        resources.ApplyResources(Me.DonwloadBar, "DonwloadBar")
        Me.DonwloadBar.Name = "DonwloadBar"
        Me.DonwloadBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OpenFolderButton)
        Me.GroupBox1.Controls.Add(Me.SteamCMDDownloadButton)
        Me.GroupBox1.Controls.Add(Me.CheckUpdatesButton)
        Me.GroupBox1.Controls.Add(Me.VDCButton)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'OpenFolderButton
        '
        Me.OpenFolderButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Folder
        resources.ApplyResources(Me.OpenFolderButton, "OpenFolderButton")
        Me.OpenFolderButton.Name = "OpenFolderButton"
        Me.OpenFolderButton.TabStop = False
        Me.OpenFolderButton.UseVisualStyleBackColor = True
        '
        'CheckUpdatesButton
        '
        resources.ApplyResources(Me.CheckUpdatesButton, "CheckUpdatesButton")
        Me.CheckUpdatesButton.Name = "CheckUpdatesButton"
        Me.CheckUpdatesButton.UseVisualStyleBackColor = True
        '
        'VDCButton
        '
        resources.ApplyResources(Me.VDCButton, "VDCButton")
        Me.VDCButton.Name = "VDCButton"
        Me.VDCButton.UseVisualStyleBackColor = True
        '
        'AboutButton
        '
        resources.ApplyResources(Me.AboutButton, "AboutButton")
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        resources.ApplyResources(Me.ExitButton, "ExitButton")
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.AddCustomGameButton)
        Me.GroupBox2.Controls.Add(Me.CheckBoxConsole)
        Me.GroupBox2.Controls.Add(Me.ValidateCheckBox)
        Me.GroupBox2.Controls.Add(Me.IdHelpButton)
        Me.GroupBox2.Controls.Add(Me.BrowserButton)
        Me.GroupBox2.Controls.Add(Me.UpdateServerButton)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ServerPath)
        Me.GroupBox2.Controls.Add(Me.AnonymousCheckBox)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.UsernameTextBox)
        Me.GroupBox2.Controls.Add(Me.PasswdTextBox)
        Me.GroupBox2.Controls.Add(Me.GamesList)
        Me.GroupBox2.Controls.Add(Me.GoldSrcModLabel)
        Me.GroupBox2.Controls.Add(Me.GoldSrcModInput)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'AddCustomGameButton
        '
        resources.ApplyResources(Me.AddCustomGameButton, "AddCustomGameButton")
        Me.AddCustomGameButton.Name = "AddCustomGameButton"
        Me.AddCustomGameButton.UseVisualStyleBackColor = True
        '
        'CheckBoxConsole
        '
        resources.ApplyResources(Me.CheckBoxConsole, "CheckBoxConsole")
        Me.CheckBoxConsole.Name = "CheckBoxConsole"
        Me.CheckBoxConsole.UseVisualStyleBackColor = True
        '
        'ValidateCheckBox
        '
        resources.ApplyResources(Me.ValidateCheckBox, "ValidateCheckBox")
        Me.ValidateCheckBox.Checked = True
        Me.ValidateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ValidateCheckBox.Name = "ValidateCheckBox"
        Me.ValidateCheckBox.TabStop = False
        Me.ValidateCheckBox.UseVisualStyleBackColor = True
        '
        'IdHelpButton
        '
        Me.IdHelpButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Help
        resources.ApplyResources(Me.IdHelpButton, "IdHelpButton")
        Me.IdHelpButton.Name = "IdHelpButton"
        Me.IdHelpButton.TabStop = False
        Me.IdHelpButton.UseVisualStyleBackColor = False
        '
        'BrowserButton
        '
        resources.ApplyResources(Me.BrowserButton, "BrowserButton")
        Me.BrowserButton.Name = "BrowserButton"
        Me.BrowserButton.UseVisualStyleBackColor = True
        '
        'UpdateServerButton
        '
        resources.ApplyResources(Me.UpdateServerButton, "UpdateServerButton")
        Me.UpdateServerButton.Name = "UpdateServerButton"
        Me.UpdateServerButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'ServerPath
        '
        resources.ApplyResources(Me.ServerPath, "ServerPath")
        Me.ServerPath.Name = "ServerPath"
        Me.ServerPath.TabStop = False
        '
        'AnonymousCheckBox
        '
        resources.ApplyResources(Me.AnonymousCheckBox, "AnonymousCheckBox")
        Me.AnonymousCheckBox.Checked = True
        Me.AnonymousCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AnonymousCheckBox.Name = "AnonymousCheckBox"
        Me.AnonymousCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'UsernameTextBox
        '
        resources.ApplyResources(Me.UsernameTextBox, "UsernameTextBox")
        Me.UsernameTextBox.Name = "UsernameTextBox"
        '
        'PasswdTextBox
        '
        resources.ApplyResources(Me.PasswdTextBox, "PasswdTextBox")
        Me.PasswdTextBox.Name = "PasswdTextBox"
        Me.PasswdTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        '
        'GoldSrcModLabel
        '
        resources.ApplyResources(Me.GoldSrcModLabel, "GoldSrcModLabel")
        Me.GoldSrcModLabel.Name = "GoldSrcModLabel"
        '
        'GoldSrcModInput
        '
        resources.ApplyResources(Me.GoldSrcModInput, "GoldSrcModInput")
        Me.GoldSrcModInput.Name = "GoldSrcModInput"
        '
        'Status
        '
        Me.Status.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.Status, "Status")
        Me.Status.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Status.Name = "Status"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ESButton)
        Me.GroupBox3.Controls.Add(Me.MMButton)
        Me.GroupBox3.Controls.Add(Me.SMButton)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'ESButton
        '
        resources.ApplyResources(Me.ESButton, "ESButton")
        Me.ESButton.Name = "ESButton"
        Me.ESButton.UseVisualStyleBackColor = True
        '
        'MMButton
        '
        resources.ApplyResources(Me.MMButton, "MMButton")
        Me.MMButton.Name = "MMButton"
        Me.MMButton.UseVisualStyleBackColor = True
        '
        'SMButton
        '
        resources.ApplyResources(Me.SMButton, "SMButton")
        Me.SMButton.Name = "SMButton"
        Me.SMButton.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ExeBrowserButton)
        Me.GroupBox4.Controls.Add(Me.ExePath)
        Me.GroupBox4.Controls.Add(Me.Label4)
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'ExeBrowserButton
        '
        resources.ApplyResources(Me.ExeBrowserButton, "ExeBrowserButton")
        Me.ExeBrowserButton.Name = "ExeBrowserButton"
        Me.ExeBrowserButton.UseVisualStyleBackColor = True
        '
        'ExePath
        '
        resources.ApplyResources(Me.ExePath, "ExePath")
        Me.ExePath.Name = "ExePath"
        Me.ExePath.TabStop = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'TabMenu
        '
        Me.TabMenu.Controls.Add(Me.UpdateTab)
        Me.TabMenu.Controls.Add(Me.RunTab)
        Me.TabMenu.Controls.Add(Me.ConsoleTab)
        resources.ApplyResources(Me.TabMenu, "TabMenu")
        Me.TabMenu.Name = "TabMenu"
        Me.TabMenu.SelectedIndex = 0
        '
        'UpdateTab
        '
        Me.UpdateTab.Controls.Add(Me.GroupBox4)
        Me.UpdateTab.Controls.Add(Me.GroupBox2)
        resources.ApplyResources(Me.UpdateTab, "UpdateTab")
        Me.UpdateTab.Name = "UpdateTab"
        Me.UpdateTab.UseVisualStyleBackColor = True
        '
        'RunTab
        '
        Me.RunTab.Controls.Add(Me.GroupBox6)
        Me.RunTab.Controls.Add(Me.GroupBox5)
        resources.ApplyResources(Me.RunTab, "RunTab")
        Me.RunTab.Name = "RunTab"
        Me.RunTab.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.AddButton)
        Me.GroupBox6.Controls.Add(Me.SaveButton)
        Me.GroupBox6.Controls.Add(Me.InsecureCheckBox)
        Me.GroupBox6.Controls.Add(Me.DevModeCheckBox)
        Me.GroupBox6.Controls.Add(Me.RunServerButton)
        Me.GroupBox6.Controls.Add(Me.ConsoleCheckBox)
        Me.GroupBox6.Controls.Add(Me.BotsCheckBox)
        Me.GroupBox6.Controls.Add(Me.SourceTVCheckBox)
        Me.GroupBox6.Controls.Add(Me.DebugModeCheckBox)
        Me.GroupBox6.Controls.Add(Me.CheckBoxMask)
        Me.GroupBox6.Controls.Add(Me.UDPPortTexBox)
        Me.GroupBox6.Controls.Add(Me.RconTextBox)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.NetworkComboBox)
        Me.GroupBox6.Controls.Add(Me.ServerNameTextBox)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.MaxPlayersTexBox)
        Me.GroupBox6.Controls.Add(Me.ModHelpButton)
        Me.GroupBox6.Controls.Add(Me.CustomModTextBox)
        Me.GroupBox6.Controls.Add(Me.ModList)
        Me.GroupBox6.Controls.Add(Me.CustomModCheckBox)
        Me.GroupBox6.Controls.Add(Me.MapList)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.Label5)
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.TabStop = False
        '
        'AddButton
        '
        Me.AddButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Add
        resources.ApplyResources(Me.AddButton, "AddButton")
        Me.AddButton.Name = "AddButton"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Save
        resources.ApplyResources(Me.SaveButton, "SaveButton")
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'InsecureCheckBox
        '
        resources.ApplyResources(Me.InsecureCheckBox, "InsecureCheckBox")
        Me.InsecureCheckBox.Name = "InsecureCheckBox"
        Me.InsecureCheckBox.UseVisualStyleBackColor = True
        '
        'DevModeCheckBox
        '
        resources.ApplyResources(Me.DevModeCheckBox, "DevModeCheckBox")
        Me.DevModeCheckBox.Name = "DevModeCheckBox"
        Me.DevModeCheckBox.UseVisualStyleBackColor = True
        '
        'RunServerButton
        '
        resources.ApplyResources(Me.RunServerButton, "RunServerButton")
        Me.RunServerButton.Name = "RunServerButton"
        Me.RunServerButton.UseVisualStyleBackColor = True
        '
        'ConsoleCheckBox
        '
        resources.ApplyResources(Me.ConsoleCheckBox, "ConsoleCheckBox")
        Me.ConsoleCheckBox.Checked = True
        Me.ConsoleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ConsoleCheckBox.Name = "ConsoleCheckBox"
        Me.ConsoleCheckBox.UseVisualStyleBackColor = True
        '
        'BotsCheckBox
        '
        resources.ApplyResources(Me.BotsCheckBox, "BotsCheckBox")
        Me.BotsCheckBox.Name = "BotsCheckBox"
        Me.BotsCheckBox.UseVisualStyleBackColor = True
        '
        'SourceTVCheckBox
        '
        resources.ApplyResources(Me.SourceTVCheckBox, "SourceTVCheckBox")
        Me.SourceTVCheckBox.Name = "SourceTVCheckBox"
        Me.SourceTVCheckBox.UseVisualStyleBackColor = True
        '
        'DebugModeCheckBox
        '
        resources.ApplyResources(Me.DebugModeCheckBox, "DebugModeCheckBox")
        Me.DebugModeCheckBox.Name = "DebugModeCheckBox"
        Me.DebugModeCheckBox.UseVisualStyleBackColor = True
        '
        'CheckBoxMask
        '
        resources.ApplyResources(Me.CheckBoxMask, "CheckBoxMask")
        Me.CheckBoxMask.Checked = True
        Me.CheckBoxMask.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxMask.Name = "CheckBoxMask"
        Me.CheckBoxMask.UseVisualStyleBackColor = True
        '
        'UDPPortTexBox
        '
        resources.ApplyResources(Me.UDPPortTexBox, "UDPPortTexBox")
        Me.UDPPortTexBox.Maximum = New Decimal(New Integer() {49151, 0, 0, 0})
        Me.UDPPortTexBox.Name = "UDPPortTexBox"
        Me.UDPPortTexBox.Value = New Decimal(New Integer() {27015, 0, 0, 0})
        '
        'RconTextBox
        '
        resources.ApplyResources(Me.RconTextBox, "RconTextBox")
        Me.RconTextBox.Name = "RconTextBox"
        Me.RconTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'NetworkComboBox
        '
        Me.NetworkComboBox.FormattingEnabled = True
        Me.NetworkComboBox.Items.AddRange(New Object() {resources.GetString("NetworkComboBox.Items"), resources.GetString("NetworkComboBox.Items1")})
        resources.ApplyResources(Me.NetworkComboBox, "NetworkComboBox")
        Me.NetworkComboBox.Name = "NetworkComboBox"
        '
        'ServerNameTextBox
        '
        resources.ApplyResources(Me.ServerNameTextBox, "ServerNameTextBox")
        Me.ServerNameTextBox.Name = "ServerNameTextBox"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'MaxPlayersTexBox
        '
        resources.ApplyResources(Me.MaxPlayersTexBox, "MaxPlayersTexBox")
        Me.MaxPlayersTexBox.Maximum = New Decimal(New Integer() {64, 0, 0, 0})
        Me.MaxPlayersTexBox.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxPlayersTexBox.Name = "MaxPlayersTexBox"
        Me.MaxPlayersTexBox.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'ModHelpButton
        '
        Me.ModHelpButton.BackColor = System.Drawing.Color.Transparent
        Me.ModHelpButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Help
        resources.ApplyResources(Me.ModHelpButton, "ModHelpButton")
        Me.ModHelpButton.Name = "ModHelpButton"
        Me.ModHelpButton.TabStop = False
        Me.ModHelpButton.UseVisualStyleBackColor = False
        '
        'CustomModTextBox
        '
        resources.ApplyResources(Me.CustomModTextBox, "CustomModTextBox")
        Me.CustomModTextBox.Name = "CustomModTextBox"
        '
        'ModList
        '
        Me.ModList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ModList.FormattingEnabled = True
        Me.ModList.Items.AddRange(New Object() {resources.GetString("ModList.Items"), resources.GetString("ModList.Items1"), resources.GetString("ModList.Items2"), resources.GetString("ModList.Items3"), resources.GetString("ModList.Items4"), resources.GetString("ModList.Items5"), resources.GetString("ModList.Items6"), resources.GetString("ModList.Items7"), resources.GetString("ModList.Items8"), resources.GetString("ModList.Items9"), resources.GetString("ModList.Items10")})
        resources.ApplyResources(Me.ModList, "ModList")
        Me.ModList.Name = "ModList"
        '
        'CustomModCheckBox
        '
        resources.ApplyResources(Me.CustomModCheckBox, "CustomModCheckBox")
        Me.CustomModCheckBox.Name = "CustomModCheckBox"
        Me.CustomModCheckBox.UseVisualStyleBackColor = True
        '
        'MapList
        '
        resources.ApplyResources(Me.MapList, "MapList")
        Me.MapList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MapList.FormattingEnabled = True
        Me.MapList.Name = "MapList"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.SrcdsExePathOpen)
        Me.GroupBox5.Controls.Add(Me.SrcdsExeBrowserButton)
        Me.GroupBox5.Controls.Add(Me.SrcdsExePathTextBox)
        Me.GroupBox5.Controls.Add(Me.Label3)
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        '
        'SrcdsExePathOpen
        '
        Me.SrcdsExePathOpen.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Folder
        resources.ApplyResources(Me.SrcdsExePathOpen, "SrcdsExePathOpen")
        Me.SrcdsExePathOpen.Name = "SrcdsExePathOpen"
        Me.SrcdsExePathOpen.TabStop = False
        Me.SrcdsExePathOpen.UseVisualStyleBackColor = True
        '
        'SrcdsExeBrowserButton
        '
        resources.ApplyResources(Me.SrcdsExeBrowserButton, "SrcdsExeBrowserButton")
        Me.SrcdsExeBrowserButton.Name = "SrcdsExeBrowserButton"
        Me.SrcdsExeBrowserButton.UseVisualStyleBackColor = True
        '
        'SrcdsExePathTextBox
        '
        resources.ApplyResources(Me.SrcdsExePathTextBox, "SrcdsExePathTextBox")
        Me.SrcdsExePathTextBox.Name = "SrcdsExePathTextBox"
        Me.SrcdsExePathTextBox.TabStop = False
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'ConsoleTab
        '
        Me.ConsoleTab.Controls.Add(Me.ConsoleConnect)
        Me.ConsoleTab.Controls.Add(Me.ConsoleIPPrint)
        Me.ConsoleTab.Controls.Add(Me.ConsoleClearLog)
        Me.ConsoleTab.Controls.Add(Me.ConsoleOpenLog)
        Me.ConsoleTab.Controls.Add(Me.ConsoleSaveLog)
        Me.ConsoleTab.Controls.Add(Me.ConsoleCommandList)
        Me.ConsoleTab.Controls.Add(Me.ConsoleButton)
        Me.ConsoleTab.Controls.Add(Me.ConsoleInput)
        Me.ConsoleTab.Controls.Add(Me.ConsoleOutput)
        resources.ApplyResources(Me.ConsoleTab, "ConsoleTab")
        Me.ConsoleTab.Name = "ConsoleTab"
        Me.ConsoleTab.UseVisualStyleBackColor = True
        '
        'ConsoleConnect
        '
        Me.ConsoleConnect.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Connect
        resources.ApplyResources(Me.ConsoleConnect, "ConsoleConnect")
        Me.ConsoleConnect.Name = "ConsoleConnect"
        Me.ConsoleConnect.UseVisualStyleBackColor = True
        '
        'ConsoleIPPrint
        '
        Me.ConsoleIPPrint.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Server
        resources.ApplyResources(Me.ConsoleIPPrint, "ConsoleIPPrint")
        Me.ConsoleIPPrint.Name = "ConsoleIPPrint"
        Me.ConsoleIPPrint.UseVisualStyleBackColor = True
        '
        'ConsoleClearLog
        '
        Me.ConsoleClearLog.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Clear
        resources.ApplyResources(Me.ConsoleClearLog, "ConsoleClearLog")
        Me.ConsoleClearLog.Name = "ConsoleClearLog"
        Me.ConsoleClearLog.UseVisualStyleBackColor = True
        '
        'ConsoleOpenLog
        '
        Me.ConsoleOpenLog.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Folder
        resources.ApplyResources(Me.ConsoleOpenLog, "ConsoleOpenLog")
        Me.ConsoleOpenLog.Name = "ConsoleOpenLog"
        Me.ConsoleOpenLog.UseVisualStyleBackColor = True
        '
        'ConsoleSaveLog
        '
        Me.ConsoleSaveLog.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Save
        resources.ApplyResources(Me.ConsoleSaveLog, "ConsoleSaveLog")
        Me.ConsoleSaveLog.Name = "ConsoleSaveLog"
        Me.ConsoleSaveLog.UseVisualStyleBackColor = True
        '
        'ConsoleCommandList
        '
        Me.ConsoleCommandList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConsoleCommandList.FormattingEnabled = True
        Me.ConsoleCommandList.Items.AddRange(New Object() {resources.GetString("ConsoleCommandList.Items"), resources.GetString("ConsoleCommandList.Items1"), resources.GetString("ConsoleCommandList.Items2"), resources.GetString("ConsoleCommandList.Items3")})
        resources.ApplyResources(Me.ConsoleCommandList, "ConsoleCommandList")
        Me.ConsoleCommandList.Name = "ConsoleCommandList"
        '
        'ConsoleButton
        '
        resources.ApplyResources(Me.ConsoleButton, "ConsoleButton")
        Me.ConsoleButton.Name = "ConsoleButton"
        Me.ConsoleButton.UseVisualStyleBackColor = True
        '
        'ConsoleInput
        '
        resources.ApplyResources(Me.ConsoleInput, "ConsoleInput")
        Me.ConsoleInput.Name = "ConsoleInput"
        '
        'ConsoleOutput
        '
        Me.ConsoleOutput.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.ConsoleOutput, "ConsoleOutput")
        Me.ConsoleOutput.Name = "ConsoleOutput"
        Me.ConsoleOutput.ReadOnly = True
        Me.ConsoleOutput.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Menu
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolsMenu, Me.HelpToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveMenu, Me.LoadMenu, Me.ToolStripSeparator3, Me.ExitMenu})
        Me.FileMenu.Name = "FileMenu"
        resources.ApplyResources(Me.FileMenu, "FileMenu")
        '
        'SaveMenu
        '
        Me.SaveMenu.Name = "SaveMenu"
        resources.ApplyResources(Me.SaveMenu, "SaveMenu")
        '
        'LoadMenu
        '
        Me.LoadMenu.Name = "LoadMenu"
        resources.ApplyResources(Me.LoadMenu, "LoadMenu")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'ExitMenu
        '
        Me.ExitMenu.Name = "ExitMenu"
        resources.ApplyResources(Me.ExitMenu, "ExitMenu")
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommonFilesMenu, Me.CFGMenu, Me.ToolStripSeparator4, Me.SMMenu})
        Me.ToolsMenu.Name = "ToolsMenu"
        resources.ApplyResources(Me.ToolsMenu, "ToolsMenu")
        '
        'CommonFilesMenu
        '
        Me.CommonFilesMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MotdTxtButton, Me.MapcycleTxtButton, Me.MaplistTxtButton})
        resources.ApplyResources(Me.CommonFilesMenu, "CommonFilesMenu")
        Me.CommonFilesMenu.Name = "CommonFilesMenu"
        '
        'MotdTxtButton
        '
        Me.MotdTxtButton.Name = "MotdTxtButton"
        resources.ApplyResources(Me.MotdTxtButton, "MotdTxtButton")
        '
        'MapcycleTxtButton
        '
        Me.MapcycleTxtButton.Name = "MapcycleTxtButton"
        resources.ApplyResources(Me.MapcycleTxtButton, "MapcycleTxtButton")
        '
        'MaplistTxtButton
        '
        Me.MaplistTxtButton.Name = "MaplistTxtButton"
        resources.ApplyResources(Me.MaplistTxtButton, "MaplistTxtButton")
        '
        'CFGMenu
        '
        Me.CFGMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFileToolStripMenuItem, Me.ToolStripSeparator2})
        resources.ApplyResources(Me.CFGMenu, "CFGMenu")
        Me.CFGMenu.Name = "CFGMenu"
        '
        'NewFileToolStripMenuItem
        '
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        resources.ApplyResources(Me.NewFileToolStripMenuItem, "NewFileToolStripMenuItem")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'SMMenu
        '
        Me.SMMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Empty})
        Me.SMMenu.Name = "SMMenu"
        resources.ApplyResources(Me.SMMenu, "SMMenu")
        '
        'Empty
        '
        Me.Empty.Name = "Empty"
        resources.ApplyResources(Me.Empty, "Empty")
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogMenu, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        '
        'LogMenu
        '
        Me.LogMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4})
        resources.ApplyResources(Me.LogMenu, "LogMenu")
        Me.LogMenu.Name = "LogMenu"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        '
        'XmlConfigOpenFileDialog
        '
        Me.XmlConfigOpenFileDialog.RestoreDirectory = True
        '
        'DonateButton
        '
        Me.DonateButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.PPDonateButton
        resources.ApplyResources(Me.DonateButton, "DonateButton")
        Me.DonateButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DonateButton.Name = "DonateButton"
        Me.DonateButton.TabStop = False
        '
        'IPTextbox
        '
        Me.IPTextbox.Cursor = System.Windows.Forms.Cursors.IBeam
        resources.ApplyResources(Me.IPTextbox, "IPTextbox")
        Me.IPTextbox.Name = "IPTextbox"
        Me.IPTextbox.ReadOnly = True
        Me.IPTextbox.TabStop = False
        '
        'IPButton
        '
        Me.IPButton.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.IPButton, "IPButton")
        Me.IPButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IPButton.Name = "IPButton"
        Me.IPButton.TabStop = False
        Me.IPButton.UseVisualStyleBackColor = False
        '
        'MainMenu
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.IPTextbox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabMenu)
        Me.Controls.Add(Me.DonateButton)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.DonwloadBar)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.IPButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainMenu"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabMenu.ResumeLayout(False)
        Me.UpdateTab.ResumeLayout(False)
        Me.RunTab.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.UDPPortTexBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxPlayersTexBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ConsoleTab.ResumeLayout(False)
        Me.ConsoleTab.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DonateButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GamesList As System.Windows.Forms.ComboBox
    Friend WithEvents SteamCMDDownloadButton As System.Windows.Forms.Button
    Friend WithEvents DonwloadBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Status As System.Windows.Forms.TextBox
    Friend WithEvents AnonymousCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswdTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BrowserButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ServerPath As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents VDCButton As System.Windows.Forms.Button
    Friend WithEvents UpdateServerButton As System.Windows.Forms.Button
    Friend WithEvents CheckUpdatesButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents OpenFolderButton As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents AboutButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ESButton As System.Windows.Forms.Button
    Friend WithEvents MMButton As System.Windows.Forms.Button
    Friend WithEvents SMButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ExeBrowserButton As System.Windows.Forms.Button
    Friend WithEvents ExePath As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabMenu As System.Windows.Forms.TabControl
    Friend WithEvents UpdateTab As System.Windows.Forms.TabPage
    Friend WithEvents RunTab As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents SrcdsExeBrowserButton As System.Windows.Forms.Button
    Friend WithEvents SrcdsExePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CustomModTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ModList As System.Windows.Forms.ComboBox
    Friend WithEvents CustomModCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MapList As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ModHelpButton As System.Windows.Forms.Button
    Friend WithEvents IdHelpButton As System.Windows.Forms.Button
    Friend WithEvents RunServerButton As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MaxPlayersTexBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents ServerNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NetworkComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RconTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents UDPPortTexBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBoxMask As System.Windows.Forms.CheckBox
    Friend WithEvents InsecureCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DebugModeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DevModeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ConsoleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BotsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SourceTVCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XmlConfigOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SrcdsExePathOpen As System.Windows.Forms.Button
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CFGMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CommonFilesMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MotdTxtButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MapcycleTxtButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaplistTxtButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SMMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Empty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents LogMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValidateCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ConsoleOutput As System.Windows.Forms.RichTextBox
    Friend WithEvents ConsoleTab As System.Windows.Forms.TabPage
    Friend WithEvents ConsoleButton As System.Windows.Forms.Button
    Friend WithEvents ConsoleInput As System.Windows.Forms.TextBox
    Friend WithEvents ConsoleCommandList As System.Windows.Forms.ComboBox
    Friend WithEvents ConsoleSaveLog As System.Windows.Forms.Button
    Friend WithEvents ConsoleConnect As System.Windows.Forms.Button
    Friend WithEvents ConsoleClearLog As System.Windows.Forms.Button
    Friend WithEvents ConsoleOpenLog As System.Windows.Forms.Button
    Friend WithEvents GoldSrcModLabel As System.Windows.Forms.Label
    Friend WithEvents GoldSrcModInput As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckBoxConsole As System.Windows.Forms.CheckBox
    Friend WithEvents AddCustomGameButton As System.Windows.Forms.Button
    Friend WithEvents DonateButton As System.Windows.Forms.PictureBox
    Friend WithEvents ConsoleIPPrint As System.Windows.Forms.Button
    Friend WithEvents IPTextbox As System.Windows.Forms.TextBox
    Friend WithEvents IPButton As System.Windows.Forms.Button

End Class

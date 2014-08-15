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
        Me.CustomIDCheckbox = New System.Windows.Forms.CheckBox()
        Me.CustomIDTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OpenFolderButton = New System.Windows.Forms.Button()
        Me.CheckUpdatesButton = New System.Windows.Forms.Button()
        Me.VDCButton = New System.Windows.Forms.Button()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
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
        Me.MAPButton = New System.Windows.Forms.Button()
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
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog3 = New System.Windows.Forms.FolderBrowserDialog()
        Me.XmlConfigOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
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
        Me.SuspendLayout()
        '
        'GamesList
        '
        resources.ApplyResources(Me.GamesList, "GamesList")
        Me.GamesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GamesList.FormattingEnabled = True
        Me.GamesList.Items.AddRange(New Object() {resources.GetString("GamesList.Items"), resources.GetString("GamesList.Items1"), resources.GetString("GamesList.Items2"), resources.GetString("GamesList.Items3"), resources.GetString("GamesList.Items4"), resources.GetString("GamesList.Items5"), resources.GetString("GamesList.Items6"), resources.GetString("GamesList.Items7"), resources.GetString("GamesList.Items8"), resources.GetString("GamesList.Items9"), resources.GetString("GamesList.Items10")})
        Me.GamesList.Name = "GamesList"
        Me.ToolTip1.SetToolTip(Me.GamesList, resources.GetString("GamesList.ToolTip"))
        '
        'SteamCMDDownloadButton
        '
        resources.ApplyResources(Me.SteamCMDDownloadButton, "SteamCMDDownloadButton")
        Me.SteamCMDDownloadButton.Name = "SteamCMDDownloadButton"
        Me.ToolTip1.SetToolTip(Me.SteamCMDDownloadButton, resources.GetString("SteamCMDDownloadButton.ToolTip"))
        Me.SteamCMDDownloadButton.UseVisualStyleBackColor = True
        '
        'DonwloadBar
        '
        resources.ApplyResources(Me.DonwloadBar, "DonwloadBar")
        Me.DonwloadBar.Name = "DonwloadBar"
        Me.DonwloadBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ToolTip1.SetToolTip(Me.DonwloadBar, resources.GetString("DonwloadBar.ToolTip"))
        '
        'CustomIDCheckbox
        '
        resources.ApplyResources(Me.CustomIDCheckbox, "CustomIDCheckbox")
        Me.CustomIDCheckbox.Name = "CustomIDCheckbox"
        Me.ToolTip1.SetToolTip(Me.CustomIDCheckbox, resources.GetString("CustomIDCheckbox.ToolTip"))
        Me.CustomIDCheckbox.UseVisualStyleBackColor = True
        '
        'CustomIDTextBox
        '
        resources.ApplyResources(Me.CustomIDTextBox, "CustomIDTextBox")
        Me.CustomIDTextBox.Name = "CustomIDTextBox"
        Me.ToolTip1.SetToolTip(Me.CustomIDTextBox, resources.GetString("CustomIDTextBox.ToolTip"))
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.OpenFolderButton)
        Me.GroupBox1.Controls.Add(Me.SteamCMDDownloadButton)
        Me.GroupBox1.Controls.Add(Me.CheckUpdatesButton)
        Me.GroupBox1.Controls.Add(Me.VDCButton)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip"))
        '
        'OpenFolderButton
        '
        resources.ApplyResources(Me.OpenFolderButton, "OpenFolderButton")
        Me.OpenFolderButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Folder
        Me.OpenFolderButton.Name = "OpenFolderButton"
        Me.OpenFolderButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.OpenFolderButton, resources.GetString("OpenFolderButton.ToolTip"))
        Me.OpenFolderButton.UseVisualStyleBackColor = True
        '
        'CheckUpdatesButton
        '
        resources.ApplyResources(Me.CheckUpdatesButton, "CheckUpdatesButton")
        Me.CheckUpdatesButton.Name = "CheckUpdatesButton"
        Me.ToolTip1.SetToolTip(Me.CheckUpdatesButton, resources.GetString("CheckUpdatesButton.ToolTip"))
        Me.CheckUpdatesButton.UseVisualStyleBackColor = True
        '
        'VDCButton
        '
        resources.ApplyResources(Me.VDCButton, "VDCButton")
        Me.VDCButton.Name = "VDCButton"
        Me.ToolTip1.SetToolTip(Me.VDCButton, resources.GetString("VDCButton.ToolTip"))
        Me.VDCButton.UseVisualStyleBackColor = True
        '
        'AboutButton
        '
        resources.ApplyResources(Me.AboutButton, "AboutButton")
        Me.AboutButton.Name = "AboutButton"
        Me.ToolTip1.SetToolTip(Me.AboutButton, resources.GetString("AboutButton.ToolTip"))
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        resources.ApplyResources(Me.ExitButton, "ExitButton")
        Me.ExitButton.Name = "ExitButton"
        Me.ToolTip1.SetToolTip(Me.ExitButton, resources.GetString("ExitButton.ToolTip"))
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
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
        Me.GroupBox2.Controls.Add(Me.CustomIDTextBox)
        Me.GroupBox2.Controls.Add(Me.GamesList)
        Me.GroupBox2.Controls.Add(Me.CustomIDCheckbox)
        Me.GroupBox2.Controls.Add(Me.GoldSrcModLabel)
        Me.GroupBox2.Controls.Add(Me.GoldSrcModInput)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox2, resources.GetString("GroupBox2.ToolTip"))
        '
        'ValidateCheckBox
        '
        resources.ApplyResources(Me.ValidateCheckBox, "ValidateCheckBox")
        Me.ValidateCheckBox.Checked = True
        Me.ValidateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ValidateCheckBox.Name = "ValidateCheckBox"
        Me.ValidateCheckBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ValidateCheckBox, resources.GetString("ValidateCheckBox.ToolTip"))
        Me.ValidateCheckBox.UseVisualStyleBackColor = True
        '
        'IdHelpButton
        '
        resources.ApplyResources(Me.IdHelpButton, "IdHelpButton")
        Me.IdHelpButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Help
        Me.IdHelpButton.Name = "IdHelpButton"
        Me.IdHelpButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.IdHelpButton, resources.GetString("IdHelpButton.ToolTip"))
        Me.IdHelpButton.UseVisualStyleBackColor = False
        '
        'BrowserButton
        '
        resources.ApplyResources(Me.BrowserButton, "BrowserButton")
        Me.BrowserButton.Name = "BrowserButton"
        Me.ToolTip1.SetToolTip(Me.BrowserButton, resources.GetString("BrowserButton.ToolTip"))
        Me.BrowserButton.UseVisualStyleBackColor = True
        '
        'UpdateServerButton
        '
        resources.ApplyResources(Me.UpdateServerButton, "UpdateServerButton")
        Me.UpdateServerButton.Name = "UpdateServerButton"
        Me.ToolTip1.SetToolTip(Me.UpdateServerButton, resources.GetString("UpdateServerButton.ToolTip"))
        Me.UpdateServerButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'ServerPath
        '
        resources.ApplyResources(Me.ServerPath, "ServerPath")
        Me.ServerPath.Name = "ServerPath"
        Me.ServerPath.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ServerPath, resources.GetString("ServerPath.ToolTip"))
        '
        'AnonymousCheckBox
        '
        resources.ApplyResources(Me.AnonymousCheckBox, "AnonymousCheckBox")
        Me.AnonymousCheckBox.Checked = True
        Me.AnonymousCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AnonymousCheckBox.Name = "AnonymousCheckBox"
        Me.ToolTip1.SetToolTip(Me.AnonymousCheckBox, resources.GetString("AnonymousCheckBox.ToolTip"))
        Me.AnonymousCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'UsernameTextBox
        '
        resources.ApplyResources(Me.UsernameTextBox, "UsernameTextBox")
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.ToolTip1.SetToolTip(Me.UsernameTextBox, resources.GetString("UsernameTextBox.ToolTip"))
        '
        'PasswdTextBox
        '
        resources.ApplyResources(Me.PasswdTextBox, "PasswdTextBox")
        Me.PasswdTextBox.Name = "PasswdTextBox"
        Me.PasswdTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ToolTip1.SetToolTip(Me.PasswdTextBox, resources.GetString("PasswdTextBox.ToolTip"))
        '
        'GoldSrcModLabel
        '
        resources.ApplyResources(Me.GoldSrcModLabel, "GoldSrcModLabel")
        Me.GoldSrcModLabel.Name = "GoldSrcModLabel"
        Me.ToolTip1.SetToolTip(Me.GoldSrcModLabel, resources.GetString("GoldSrcModLabel.ToolTip"))
        '
        'GoldSrcModInput
        '
        resources.ApplyResources(Me.GoldSrcModInput, "GoldSrcModInput")
        Me.GoldSrcModInput.Name = "GoldSrcModInput"
        Me.ToolTip1.SetToolTip(Me.GoldSrcModInput, resources.GetString("GoldSrcModInput.ToolTip"))
        '
        'Status
        '
        resources.ApplyResources(Me.Status, "Status")
        Me.Status.BackColor = System.Drawing.SystemColors.Control
        Me.Status.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Status.Name = "Status"
        Me.ToolTip1.SetToolTip(Me.Status, resources.GetString("Status.ToolTip"))
        '
        'FolderBrowserDialog1
        '
        resources.ApplyResources(Me.FolderBrowserDialog1, "FolderBrowserDialog1")
        '
        'GroupBox3
        '
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Controls.Add(Me.MAPButton)
        Me.GroupBox3.Controls.Add(Me.ESButton)
        Me.GroupBox3.Controls.Add(Me.MMButton)
        Me.GroupBox3.Controls.Add(Me.SMButton)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox3, resources.GetString("GroupBox3.ToolTip"))
        '
        'MAPButton
        '
        resources.ApplyResources(Me.MAPButton, "MAPButton")
        Me.MAPButton.Name = "MAPButton"
        Me.ToolTip1.SetToolTip(Me.MAPButton, resources.GetString("MAPButton.ToolTip"))
        Me.MAPButton.UseVisualStyleBackColor = True
        '
        'ESButton
        '
        resources.ApplyResources(Me.ESButton, "ESButton")
        Me.ESButton.Name = "ESButton"
        Me.ToolTip1.SetToolTip(Me.ESButton, resources.GetString("ESButton.ToolTip"))
        Me.ESButton.UseVisualStyleBackColor = True
        '
        'MMButton
        '
        resources.ApplyResources(Me.MMButton, "MMButton")
        Me.MMButton.Name = "MMButton"
        Me.ToolTip1.SetToolTip(Me.MMButton, resources.GetString("MMButton.ToolTip"))
        Me.MMButton.UseVisualStyleBackColor = True
        '
        'SMButton
        '
        resources.ApplyResources(Me.SMButton, "SMButton")
        Me.SMButton.Name = "SMButton"
        Me.ToolTip1.SetToolTip(Me.SMButton, resources.GetString("SMButton.ToolTip"))
        Me.SMButton.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Controls.Add(Me.ExeBrowserButton)
        Me.GroupBox4.Controls.Add(Me.ExePath)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox4, resources.GetString("GroupBox4.ToolTip"))
        '
        'ExeBrowserButton
        '
        resources.ApplyResources(Me.ExeBrowserButton, "ExeBrowserButton")
        Me.ExeBrowserButton.Name = "ExeBrowserButton"
        Me.ToolTip1.SetToolTip(Me.ExeBrowserButton, resources.GetString("ExeBrowserButton.ToolTip"))
        Me.ExeBrowserButton.UseVisualStyleBackColor = True
        '
        'ExePath
        '
        resources.ApplyResources(Me.ExePath, "ExePath")
        Me.ExePath.Name = "ExePath"
        Me.ExePath.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ExePath, resources.GetString("ExePath.ToolTip"))
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        Me.ToolTip1.SetToolTip(Me.Label4, resources.GetString("Label4.ToolTip"))
        '
        'TabMenu
        '
        resources.ApplyResources(Me.TabMenu, "TabMenu")
        Me.TabMenu.Controls.Add(Me.UpdateTab)
        Me.TabMenu.Controls.Add(Me.RunTab)
        Me.TabMenu.Controls.Add(Me.ConsoleTab)
        Me.TabMenu.Name = "TabMenu"
        Me.TabMenu.SelectedIndex = 0
        Me.ToolTip1.SetToolTip(Me.TabMenu, resources.GetString("TabMenu.ToolTip"))
        '
        'UpdateTab
        '
        resources.ApplyResources(Me.UpdateTab, "UpdateTab")
        Me.UpdateTab.Controls.Add(Me.GroupBox4)
        Me.UpdateTab.Controls.Add(Me.GroupBox2)
        Me.UpdateTab.Name = "UpdateTab"
        Me.ToolTip1.SetToolTip(Me.UpdateTab, resources.GetString("UpdateTab.ToolTip"))
        Me.UpdateTab.UseVisualStyleBackColor = True
        '
        'RunTab
        '
        resources.ApplyResources(Me.RunTab, "RunTab")
        Me.RunTab.Controls.Add(Me.GroupBox6)
        Me.RunTab.Controls.Add(Me.GroupBox5)
        Me.RunTab.Name = "RunTab"
        Me.ToolTip1.SetToolTip(Me.RunTab, resources.GetString("RunTab.ToolTip"))
        Me.RunTab.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
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
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox6, resources.GetString("GroupBox6.ToolTip"))
        '
        'AddButton
        '
        resources.ApplyResources(Me.AddButton, "AddButton")
        Me.AddButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Add
        Me.AddButton.Name = "AddButton"
        Me.ToolTip1.SetToolTip(Me.AddButton, resources.GetString("AddButton.ToolTip"))
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        resources.ApplyResources(Me.SaveButton, "SaveButton")
        Me.SaveButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Save
        Me.SaveButton.Name = "SaveButton"
        Me.ToolTip1.SetToolTip(Me.SaveButton, resources.GetString("SaveButton.ToolTip"))
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'InsecureCheckBox
        '
        resources.ApplyResources(Me.InsecureCheckBox, "InsecureCheckBox")
        Me.InsecureCheckBox.Name = "InsecureCheckBox"
        Me.ToolTip1.SetToolTip(Me.InsecureCheckBox, resources.GetString("InsecureCheckBox.ToolTip"))
        Me.InsecureCheckBox.UseVisualStyleBackColor = True
        '
        'DevModeCheckBox
        '
        resources.ApplyResources(Me.DevModeCheckBox, "DevModeCheckBox")
        Me.DevModeCheckBox.Name = "DevModeCheckBox"
        Me.ToolTip1.SetToolTip(Me.DevModeCheckBox, resources.GetString("DevModeCheckBox.ToolTip"))
        Me.DevModeCheckBox.UseVisualStyleBackColor = True
        '
        'RunServerButton
        '
        resources.ApplyResources(Me.RunServerButton, "RunServerButton")
        Me.RunServerButton.Name = "RunServerButton"
        Me.ToolTip1.SetToolTip(Me.RunServerButton, resources.GetString("RunServerButton.ToolTip"))
        Me.RunServerButton.UseVisualStyleBackColor = True
        '
        'ConsoleCheckBox
        '
        resources.ApplyResources(Me.ConsoleCheckBox, "ConsoleCheckBox")
        Me.ConsoleCheckBox.Checked = True
        Me.ConsoleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ConsoleCheckBox.Name = "ConsoleCheckBox"
        Me.ToolTip1.SetToolTip(Me.ConsoleCheckBox, resources.GetString("ConsoleCheckBox.ToolTip"))
        Me.ConsoleCheckBox.UseVisualStyleBackColor = True
        '
        'BotsCheckBox
        '
        resources.ApplyResources(Me.BotsCheckBox, "BotsCheckBox")
        Me.BotsCheckBox.Name = "BotsCheckBox"
        Me.ToolTip1.SetToolTip(Me.BotsCheckBox, resources.GetString("BotsCheckBox.ToolTip"))
        Me.BotsCheckBox.UseVisualStyleBackColor = True
        '
        'SourceTVCheckBox
        '
        resources.ApplyResources(Me.SourceTVCheckBox, "SourceTVCheckBox")
        Me.SourceTVCheckBox.Name = "SourceTVCheckBox"
        Me.ToolTip1.SetToolTip(Me.SourceTVCheckBox, resources.GetString("SourceTVCheckBox.ToolTip"))
        Me.SourceTVCheckBox.UseVisualStyleBackColor = True
        '
        'DebugModeCheckBox
        '
        resources.ApplyResources(Me.DebugModeCheckBox, "DebugModeCheckBox")
        Me.DebugModeCheckBox.Name = "DebugModeCheckBox"
        Me.ToolTip1.SetToolTip(Me.DebugModeCheckBox, resources.GetString("DebugModeCheckBox.ToolTip"))
        Me.DebugModeCheckBox.UseVisualStyleBackColor = True
        '
        'CheckBoxMask
        '
        resources.ApplyResources(Me.CheckBoxMask, "CheckBoxMask")
        Me.CheckBoxMask.Checked = True
        Me.CheckBoxMask.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxMask.Name = "CheckBoxMask"
        Me.ToolTip1.SetToolTip(Me.CheckBoxMask, resources.GetString("CheckBoxMask.ToolTip"))
        Me.CheckBoxMask.UseVisualStyleBackColor = True
        '
        'UDPPortTexBox
        '
        resources.ApplyResources(Me.UDPPortTexBox, "UDPPortTexBox")
        Me.UDPPortTexBox.Maximum = New Decimal(New Integer() {49151, 0, 0, 0})
        Me.UDPPortTexBox.Minimum = New Decimal(New Integer() {1025, 0, 0, 0})
        Me.UDPPortTexBox.Name = "UDPPortTexBox"
        Me.ToolTip1.SetToolTip(Me.UDPPortTexBox, resources.GetString("UDPPortTexBox.ToolTip"))
        Me.UDPPortTexBox.Value = New Decimal(New Integer() {27015, 0, 0, 0})
        '
        'RconTextBox
        '
        resources.ApplyResources(Me.RconTextBox, "RconTextBox")
        Me.RconTextBox.Name = "RconTextBox"
        Me.RconTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ToolTip1.SetToolTip(Me.RconTextBox, resources.GetString("RconTextBox.ToolTip"))
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        Me.ToolTip1.SetToolTip(Me.Label11, resources.GetString("Label11.ToolTip"))
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        Me.ToolTip1.SetToolTip(Me.Label10, resources.GetString("Label10.ToolTip"))
        '
        'NetworkComboBox
        '
        resources.ApplyResources(Me.NetworkComboBox, "NetworkComboBox")
        Me.NetworkComboBox.FormattingEnabled = True
        Me.NetworkComboBox.Items.AddRange(New Object() {resources.GetString("NetworkComboBox.Items"), resources.GetString("NetworkComboBox.Items1")})
        Me.NetworkComboBox.Name = "NetworkComboBox"
        Me.ToolTip1.SetToolTip(Me.NetworkComboBox, resources.GetString("NetworkComboBox.ToolTip"))
        '
        'ServerNameTextBox
        '
        resources.ApplyResources(Me.ServerNameTextBox, "ServerNameTextBox")
        Me.ServerNameTextBox.Name = "ServerNameTextBox"
        Me.ToolTip1.SetToolTip(Me.ServerNameTextBox, resources.GetString("ServerNameTextBox.ToolTip"))
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        Me.ToolTip1.SetToolTip(Me.Label7, resources.GetString("Label7.ToolTip"))
        '
        'MaxPlayersTexBox
        '
        resources.ApplyResources(Me.MaxPlayersTexBox, "MaxPlayersTexBox")
        Me.MaxPlayersTexBox.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.MaxPlayersTexBox.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxPlayersTexBox.Name = "MaxPlayersTexBox"
        Me.ToolTip1.SetToolTip(Me.MaxPlayersTexBox, resources.GetString("MaxPlayersTexBox.ToolTip"))
        Me.MaxPlayersTexBox.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'ModHelpButton
        '
        resources.ApplyResources(Me.ModHelpButton, "ModHelpButton")
        Me.ModHelpButton.BackColor = System.Drawing.Color.Transparent
        Me.ModHelpButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Help
        Me.ModHelpButton.Name = "ModHelpButton"
        Me.ModHelpButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ModHelpButton, resources.GetString("ModHelpButton.ToolTip"))
        Me.ModHelpButton.UseVisualStyleBackColor = False
        '
        'CustomModTextBox
        '
        resources.ApplyResources(Me.CustomModTextBox, "CustomModTextBox")
        Me.CustomModTextBox.Name = "CustomModTextBox"
        Me.ToolTip1.SetToolTip(Me.CustomModTextBox, resources.GetString("CustomModTextBox.ToolTip"))
        '
        'ModList
        '
        resources.ApplyResources(Me.ModList, "ModList")
        Me.ModList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ModList.FormattingEnabled = True
        Me.ModList.Items.AddRange(New Object() {resources.GetString("ModList.Items"), resources.GetString("ModList.Items1"), resources.GetString("ModList.Items2"), resources.GetString("ModList.Items3"), resources.GetString("ModList.Items4"), resources.GetString("ModList.Items5"), resources.GetString("ModList.Items6"), resources.GetString("ModList.Items7"), resources.GetString("ModList.Items8"), resources.GetString("ModList.Items9"), resources.GetString("ModList.Items10")})
        Me.ModList.Name = "ModList"
        Me.ToolTip1.SetToolTip(Me.ModList, resources.GetString("ModList.ToolTip"))
        '
        'CustomModCheckBox
        '
        resources.ApplyResources(Me.CustomModCheckBox, "CustomModCheckBox")
        Me.CustomModCheckBox.Name = "CustomModCheckBox"
        Me.ToolTip1.SetToolTip(Me.CustomModCheckBox, resources.GetString("CustomModCheckBox.ToolTip"))
        Me.CustomModCheckBox.UseVisualStyleBackColor = True
        '
        'MapList
        '
        resources.ApplyResources(Me.MapList, "MapList")
        Me.MapList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MapList.FormattingEnabled = True
        Me.MapList.Name = "MapList"
        Me.ToolTip1.SetToolTip(Me.MapList, resources.GetString("MapList.ToolTip"))
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        Me.ToolTip1.SetToolTip(Me.Label6, resources.GetString("Label6.ToolTip"))
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        Me.ToolTip1.SetToolTip(Me.Label8, resources.GetString("Label8.ToolTip"))
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        Me.ToolTip1.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip"))
        '
        'GroupBox5
        '
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Controls.Add(Me.SrcdsExePathOpen)
        Me.GroupBox5.Controls.Add(Me.SrcdsExeBrowserButton)
        Me.GroupBox5.Controls.Add(Me.SrcdsExePathTextBox)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.GroupBox5, resources.GetString("GroupBox5.ToolTip"))
        '
        'SrcdsExePathOpen
        '
        resources.ApplyResources(Me.SrcdsExePathOpen, "SrcdsExePathOpen")
        Me.SrcdsExePathOpen.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Folder
        Me.SrcdsExePathOpen.Name = "SrcdsExePathOpen"
        Me.SrcdsExePathOpen.TabStop = False
        Me.ToolTip1.SetToolTip(Me.SrcdsExePathOpen, resources.GetString("SrcdsExePathOpen.ToolTip"))
        Me.SrcdsExePathOpen.UseVisualStyleBackColor = True
        '
        'SrcdsExeBrowserButton
        '
        resources.ApplyResources(Me.SrcdsExeBrowserButton, "SrcdsExeBrowserButton")
        Me.SrcdsExeBrowserButton.Name = "SrcdsExeBrowserButton"
        Me.ToolTip1.SetToolTip(Me.SrcdsExeBrowserButton, resources.GetString("SrcdsExeBrowserButton.ToolTip"))
        Me.SrcdsExeBrowserButton.UseVisualStyleBackColor = True
        '
        'SrcdsExePathTextBox
        '
        resources.ApplyResources(Me.SrcdsExePathTextBox, "SrcdsExePathTextBox")
        Me.SrcdsExePathTextBox.Name = "SrcdsExePathTextBox"
        Me.SrcdsExePathTextBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.SrcdsExePathTextBox, resources.GetString("SrcdsExePathTextBox.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        Me.ToolTip1.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'ConsoleTab
        '
        resources.ApplyResources(Me.ConsoleTab, "ConsoleTab")
        Me.ConsoleTab.Controls.Add(Me.ConsoleConnect)
        Me.ConsoleTab.Controls.Add(Me.ConsoleClearLog)
        Me.ConsoleTab.Controls.Add(Me.ConsoleOpenLog)
        Me.ConsoleTab.Controls.Add(Me.ConsoleSaveLog)
        Me.ConsoleTab.Controls.Add(Me.ConsoleCommandList)
        Me.ConsoleTab.Controls.Add(Me.ConsoleButton)
        Me.ConsoleTab.Controls.Add(Me.ConsoleInput)
        Me.ConsoleTab.Controls.Add(Me.ConsoleOutput)
        Me.ConsoleTab.Name = "ConsoleTab"
        Me.ToolTip1.SetToolTip(Me.ConsoleTab, resources.GetString("ConsoleTab.ToolTip"))
        Me.ConsoleTab.UseVisualStyleBackColor = True
        '
        'ConsoleConnect
        '
        resources.ApplyResources(Me.ConsoleConnect, "ConsoleConnect")
        Me.ConsoleConnect.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Connect
        Me.ConsoleConnect.Name = "ConsoleConnect"
        Me.ToolTip1.SetToolTip(Me.ConsoleConnect, resources.GetString("ConsoleConnect.ToolTip"))
        Me.ConsoleConnect.UseVisualStyleBackColor = True
        '
        'ConsoleClearLog
        '
        resources.ApplyResources(Me.ConsoleClearLog, "ConsoleClearLog")
        Me.ConsoleClearLog.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Clear
        Me.ConsoleClearLog.Name = "ConsoleClearLog"
        Me.ToolTip1.SetToolTip(Me.ConsoleClearLog, resources.GetString("ConsoleClearLog.ToolTip"))
        Me.ConsoleClearLog.UseVisualStyleBackColor = True
        '
        'ConsoleOpenLog
        '
        resources.ApplyResources(Me.ConsoleOpenLog, "ConsoleOpenLog")
        Me.ConsoleOpenLog.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Folder
        Me.ConsoleOpenLog.Name = "ConsoleOpenLog"
        Me.ToolTip1.SetToolTip(Me.ConsoleOpenLog, resources.GetString("ConsoleOpenLog.ToolTip"))
        Me.ConsoleOpenLog.UseVisualStyleBackColor = True
        '
        'ConsoleSaveLog
        '
        resources.ApplyResources(Me.ConsoleSaveLog, "ConsoleSaveLog")
        Me.ConsoleSaveLog.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Save
        Me.ConsoleSaveLog.Name = "ConsoleSaveLog"
        Me.ToolTip1.SetToolTip(Me.ConsoleSaveLog, resources.GetString("ConsoleSaveLog.ToolTip"))
        Me.ConsoleSaveLog.UseVisualStyleBackColor = True
        '
        'ConsoleCommandList
        '
        resources.ApplyResources(Me.ConsoleCommandList, "ConsoleCommandList")
        Me.ConsoleCommandList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConsoleCommandList.FormattingEnabled = True
        Me.ConsoleCommandList.Items.AddRange(New Object() {resources.GetString("ConsoleCommandList.Items"), resources.GetString("ConsoleCommandList.Items1"), resources.GetString("ConsoleCommandList.Items2"), resources.GetString("ConsoleCommandList.Items3")})
        Me.ConsoleCommandList.Name = "ConsoleCommandList"
        Me.ToolTip1.SetToolTip(Me.ConsoleCommandList, resources.GetString("ConsoleCommandList.ToolTip"))
        '
        'ConsoleButton
        '
        resources.ApplyResources(Me.ConsoleButton, "ConsoleButton")
        Me.ConsoleButton.Name = "ConsoleButton"
        Me.ToolTip1.SetToolTip(Me.ConsoleButton, resources.GetString("ConsoleButton.ToolTip"))
        Me.ConsoleButton.UseVisualStyleBackColor = True
        '
        'ConsoleInput
        '
        resources.ApplyResources(Me.ConsoleInput, "ConsoleInput")
        Me.ConsoleInput.Name = "ConsoleInput"
        Me.ToolTip1.SetToolTip(Me.ConsoleInput, resources.GetString("ConsoleInput.ToolTip"))
        '
        'ConsoleOutput
        '
        resources.ApplyResources(Me.ConsoleOutput, "ConsoleOutput")
        Me.ConsoleOutput.BackColor = System.Drawing.SystemColors.Control
        Me.ConsoleOutput.Name = "ConsoleOutput"
        Me.ConsoleOutput.ReadOnly = True
        Me.ConsoleOutput.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ConsoleOutput, resources.GetString("ConsoleOutput.ToolTip"))
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ToolTip1.SetToolTip(Me.ContextMenuStrip1, resources.GetString("ContextMenuStrip1.ToolTip"))
        '
        'ToolStripMenuItem1
        '
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        '
        'ToolStripMenuItem2
        '
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Menu
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolsMenu, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolTip1.SetToolTip(Me.MenuStrip1, resources.GetString("MenuStrip1.ToolTip"))
        '
        'FileMenu
        '
        resources.ApplyResources(Me.FileMenu, "FileMenu")
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveMenu, Me.LoadMenu, Me.ToolStripSeparator3, Me.ExitMenu})
        Me.FileMenu.Name = "FileMenu"
        '
        'SaveMenu
        '
        resources.ApplyResources(Me.SaveMenu, "SaveMenu")
        Me.SaveMenu.Name = "SaveMenu"
        '
        'LoadMenu
        '
        resources.ApplyResources(Me.LoadMenu, "LoadMenu")
        Me.LoadMenu.Name = "LoadMenu"
        '
        'ToolStripSeparator3
        '
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        '
        'ExitMenu
        '
        resources.ApplyResources(Me.ExitMenu, "ExitMenu")
        Me.ExitMenu.Name = "ExitMenu"
        '
        'ToolsMenu
        '
        resources.ApplyResources(Me.ToolsMenu, "ToolsMenu")
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommonFilesMenu, Me.CFGMenu, Me.ToolStripSeparator4, Me.SMMenu})
        Me.ToolsMenu.Name = "ToolsMenu"
        '
        'CommonFilesMenu
        '
        resources.ApplyResources(Me.CommonFilesMenu, "CommonFilesMenu")
        Me.CommonFilesMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MotdTxtButton, Me.MapcycleTxtButton, Me.MaplistTxtButton})
        Me.CommonFilesMenu.Name = "CommonFilesMenu"
        '
        'MotdTxtButton
        '
        resources.ApplyResources(Me.MotdTxtButton, "MotdTxtButton")
        Me.MotdTxtButton.Name = "MotdTxtButton"
        '
        'MapcycleTxtButton
        '
        resources.ApplyResources(Me.MapcycleTxtButton, "MapcycleTxtButton")
        Me.MapcycleTxtButton.Name = "MapcycleTxtButton"
        '
        'MaplistTxtButton
        '
        resources.ApplyResources(Me.MaplistTxtButton, "MaplistTxtButton")
        Me.MaplistTxtButton.Name = "MaplistTxtButton"
        '
        'CFGMenu
        '
        resources.ApplyResources(Me.CFGMenu, "CFGMenu")
        Me.CFGMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFileToolStripMenuItem, Me.ToolStripSeparator2})
        Me.CFGMenu.Name = "CFGMenu"
        '
        'NewFileToolStripMenuItem
        '
        resources.ApplyResources(Me.NewFileToolStripMenuItem, "NewFileToolStripMenuItem")
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'ToolStripSeparator4
        '
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        '
        'SMMenu
        '
        resources.ApplyResources(Me.SMMenu, "SMMenu")
        Me.SMMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Empty})
        Me.SMMenu.Name = "SMMenu"
        '
        'Empty
        '
        resources.ApplyResources(Me.Empty, "Empty")
        Me.Empty.Name = "Empty"
        '
        'HelpToolStripMenuItem
        '
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogMenu, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        '
        'LogMenu
        '
        resources.ApplyResources(Me.LogMenu, "LogMenu")
        Me.LogMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4})
        Me.LogMenu.Name = "LogMenu"
        '
        'ToolStripMenuItem4
        '
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        '
        'AboutToolStripMenuItem
        '
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        '
        'FolderBrowserDialog2
        '
        resources.ApplyResources(Me.FolderBrowserDialog2, "FolderBrowserDialog2")
        '
        'FolderBrowserDialog3
        '
        resources.ApplyResources(Me.FolderBrowserDialog3, "FolderBrowserDialog3")
        '
        'XmlConfigOpenFileDialog
        '
        resources.ApplyResources(Me.XmlConfigOpenFileDialog, "XmlConfigOpenFileDialog")
        Me.XmlConfigOpenFileDialog.RestoreDirectory = True
        '
        'SaveFileDialog1
        '
        resources.ApplyResources(Me.SaveFileDialog1, "SaveFileDialog1")
        '
        'MainMenu
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabMenu)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.DonwloadBar)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainMenu"
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GamesList As System.Windows.Forms.ComboBox
    Friend WithEvents SteamCMDDownloadButton As System.Windows.Forms.Button
    Friend WithEvents DonwloadBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CustomIDCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents CustomIDTextBox As System.Windows.Forms.TextBox
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
    Friend WithEvents MAPButton As System.Windows.Forms.Button
    Friend WithEvents ESButton As System.Windows.Forms.Button
    Friend WithEvents MMButton As System.Windows.Forms.Button
    Friend WithEvents SMButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ExeBrowserButton As System.Windows.Forms.Button
    Friend WithEvents ExePath As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog2 As System.Windows.Forms.FolderBrowserDialog
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
    Friend WithEvents FolderBrowserDialog3 As System.Windows.Forms.FolderBrowserDialog
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

End Class

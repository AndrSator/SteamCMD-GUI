<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GamesList = New System.Windows.Forms.ComboBox()
        Me.SteamCMDDownloadButton = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CustomIDCheckbox = New System.Windows.Forms.CheckBox()
        Me.CustomIDTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OpenFolderButton = New System.Windows.Forms.Button()
        Me.CheckUpdatesButton = New System.Windows.Forms.Button()
        Me.VDCButton = New System.Windows.Forms.Button()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BrowserButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ServerPath = New System.Windows.Forms.TextBox()
        Me.AnonymousCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswdTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.UpdateServerButton = New System.Windows.Forms.Button()
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
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GamesList
        '
        Me.GamesList.FormattingEnabled = True
        Me.GamesList.Items.AddRange(New Object() {"Counter-Strike: Global Offensive", "Counter-Strike: Source", "Day of Defeat: Source", "Garry's Mod", "Half-Life 2: Deathmatch", "Left 4 Dead 2", "Team Fortress 2"})
        Me.GamesList.Location = New System.Drawing.Point(9, 19)
        Me.GamesList.Name = "GamesList"
        Me.GamesList.Size = New System.Drawing.Size(189, 21)
        Me.GamesList.TabIndex = 1
        '
        'SteamCMDDownloadButton
        '
        Me.SteamCMDDownloadButton.Location = New System.Drawing.Point(6, 15)
        Me.SteamCMDDownloadButton.Name = "SteamCMDDownloadButton"
        Me.SteamCMDDownloadButton.Size = New System.Drawing.Size(127, 23)
        Me.SteamCMDDownloadButton.TabIndex = 8
        Me.SteamCMDDownloadButton.Text = "Download SteamCMD"
        Me.SteamCMDDownloadButton.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(418, 290)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(165, 18)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 0
        '
        'CustomIDCheckbox
        '
        Me.CustomIDCheckbox.AutoSize = True
        Me.CustomIDCheckbox.Location = New System.Drawing.Point(286, 22)
        Me.CustomIDCheckbox.Name = "CustomIDCheckbox"
        Me.CustomIDCheckbox.Size = New System.Drawing.Size(108, 17)
        Me.CustomIDCheckbox.TabIndex = 3
        Me.CustomIDCheckbox.Text = "Custom Steam ID"
        Me.CustomIDCheckbox.UseVisualStyleBackColor = True
        '
        'CustomIDTextBox
        '
        Me.CustomIDTextBox.Enabled = False
        Me.CustomIDTextBox.Location = New System.Drawing.Point(204, 20)
        Me.CustomIDTextBox.MaxLength = 10
        Me.CustomIDTextBox.Name = "CustomIDTextBox"
        Me.CustomIDTextBox.Size = New System.Drawing.Size(76, 20)
        Me.CustomIDTextBox.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OpenFolderButton)
        Me.GroupBox1.Controls.Add(Me.SteamCMDDownloadButton)
        Me.GroupBox1.Controls.Add(Me.CheckUpdatesButton)
        Me.GroupBox1.Controls.Add(Me.VDCButton)
        Me.GroupBox1.Location = New System.Drawing.Point(418, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 101)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tools"
        '
        'OpenFolderButton
        '
        Me.OpenFolderButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Folder_6222
        Me.OpenFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.OpenFolderButton.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.OpenFolderButton.Location = New System.Drawing.Point(136, 15)
        Me.OpenFolderButton.Name = "OpenFolderButton"
        Me.OpenFolderButton.Size = New System.Drawing.Size(23, 23)
        Me.OpenFolderButton.TabIndex = 0
        Me.OpenFolderButton.TabStop = False
        Me.OpenFolderButton.UseVisualStyleBackColor = True
        '
        'CheckUpdatesButton
        '
        Me.CheckUpdatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckUpdatesButton.Location = New System.Drawing.Point(6, 73)
        Me.CheckUpdatesButton.Name = "CheckUpdatesButton"
        Me.CheckUpdatesButton.Size = New System.Drawing.Size(153, 23)
        Me.CheckUpdatesButton.TabIndex = 10
        Me.CheckUpdatesButton.Text = "Check for Updates"
        Me.CheckUpdatesButton.UseVisualStyleBackColor = True
        '
        'VDCButton
        '
        Me.VDCButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VDCButton.Location = New System.Drawing.Point(6, 44)
        Me.VDCButton.Name = "VDCButton"
        Me.VDCButton.Size = New System.Drawing.Size(153, 23)
        Me.VDCButton.TabIndex = 9
        Me.VDCButton.Text = "Valve Developer Community"
        Me.VDCButton.UseVisualStyleBackColor = True
        '
        'AboutButton
        '
        Me.AboutButton.Location = New System.Drawing.Point(418, 261)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(79, 23)
        Me.AboutButton.TabIndex = 17
        Me.AboutButton.Text = "About"
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(503, 261)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(80, 23)
        Me.ExitButton.TabIndex = 18
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BrowserButton)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ServerPath)
        Me.GroupBox2.Controls.Add(Me.AnonymousCheckBox)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.UsernameTextBox)
        Me.GroupBox2.Controls.Add(Me.PasswdTextBox)
        Me.GroupBox2.Controls.Add(Me.CustomIDTextBox)
        Me.GroupBox2.Controls.Add(Me.GamesList)
        Me.GroupBox2.Controls.Add(Me.CustomIDCheckbox)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(397, 189)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Server Configuration"
        '
        'BrowserButton
        '
        Me.BrowserButton.Location = New System.Drawing.Point(323, 156)
        Me.BrowserButton.Name = "BrowserButton"
        Me.BrowserButton.Size = New System.Drawing.Size(68, 23)
        Me.BrowserButton.TabIndex = 7
        Me.BrowserButton.Text = "Browser"
        Me.BrowserButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Server path"
        '
        'ServerPath
        '
        Me.ServerPath.Location = New System.Drawing.Point(6, 158)
        Me.ServerPath.Name = "ServerPath"
        Me.ServerPath.Size = New System.Drawing.Size(311, 20)
        Me.ServerPath.TabIndex = 0
        Me.ServerPath.TabStop = False
        '
        'AnonymousCheckBox
        '
        Me.AnonymousCheckBox.AutoSize = True
        Me.AnonymousCheckBox.Checked = True
        Me.AnonymousCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AnonymousCheckBox.Location = New System.Drawing.Point(112, 76)
        Me.AnonymousCheckBox.Name = "AnonymousCheckBox"
        Me.AnonymousCheckBox.Size = New System.Drawing.Size(124, 17)
        Me.AnonymousCheckBox.TabIndex = 6
        Me.AnonymousCheckBox.Text = "Login as Anonymous"
        Me.AnonymousCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Login"
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Location = New System.Drawing.Point(6, 74)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UsernameTextBox.TabIndex = 4
        '
        'PasswdTextBox
        '
        Me.PasswdTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswdTextBox.Location = New System.Drawing.Point(6, 98)
        Me.PasswdTextBox.Name = "PasswdTextBox"
        Me.PasswdTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswdTextBox.Size = New System.Drawing.Size(100, 22)
        Me.PasswdTextBox.TabIndex = 5
        '
        'UpdateServerButton
        '
        Me.UpdateServerButton.Enabled = False
        Me.UpdateServerButton.Location = New System.Drawing.Point(313, 261)
        Me.UpdateServerButton.Name = "UpdateServerButton"
        Me.UpdateServerButton.Size = New System.Drawing.Size(99, 23)
        Me.UpdateServerButton.TabIndex = 16
        Me.UpdateServerButton.Text = "Update/Install"
        Me.UpdateServerButton.UseVisualStyleBackColor = True
        '
        'Status
        '
        Me.Status.BackColor = System.Drawing.SystemColors.Control
        Me.Status.Enabled = False
        Me.Status.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Status.Location = New System.Drawing.Point(12, 290)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(397, 20)
        Me.Status.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.MAPButton)
        Me.GroupBox3.Controls.Add(Me.ESButton)
        Me.GroupBox3.Controls.Add(Me.MMButton)
        Me.GroupBox3.Controls.Add(Me.SMButton)
        Me.GroupBox3.Location = New System.Drawing.Point(418, 119)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(165, 136)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Addons"
        '
        'MAPButton
        '
        Me.MAPButton.Location = New System.Drawing.Point(6, 103)
        Me.MAPButton.Name = "MAPButton"
        Me.MAPButton.Size = New System.Drawing.Size(153, 23)
        Me.MAPButton.TabIndex = 14
        Me.MAPButton.Text = "Mani Admin Plugin"
        Me.MAPButton.UseVisualStyleBackColor = True
        '
        'ESButton
        '
        Me.ESButton.Location = New System.Drawing.Point(6, 74)
        Me.ESButton.Name = "ESButton"
        Me.ESButton.Size = New System.Drawing.Size(153, 23)
        Me.ESButton.TabIndex = 13
        Me.ESButton.Text = "EventScripts"
        Me.ESButton.UseVisualStyleBackColor = True
        '
        'MMButton
        '
        Me.MMButton.Location = New System.Drawing.Point(6, 45)
        Me.MMButton.Name = "MMButton"
        Me.MMButton.Size = New System.Drawing.Size(153, 23)
        Me.MMButton.TabIndex = 12
        Me.MMButton.Text = "Metamod:Source"
        Me.MMButton.UseVisualStyleBackColor = True
        '
        'SMButton
        '
        Me.SMButton.Location = New System.Drawing.Point(6, 19)
        Me.SMButton.Name = "SMButton"
        Me.SMButton.Size = New System.Drawing.Size(153, 23)
        Me.SMButton.TabIndex = 11
        Me.SMButton.Text = "SourceMod"
        Me.SMButton.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ExeBrowserButton)
        Me.GroupBox4.Controls.Add(Me.ExePath)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(397, 48)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SteamCMD Configuration"
        '
        'ExeBrowserButton
        '
        Me.ExeBrowserButton.Location = New System.Drawing.Point(323, 15)
        Me.ExeBrowserButton.Name = "ExeBrowserButton"
        Me.ExeBrowserButton.Size = New System.Drawing.Size(68, 23)
        Me.ExeBrowserButton.TabIndex = 0
        Me.ExeBrowserButton.Text = "Browser"
        Me.ExeBrowserButton.UseVisualStyleBackColor = True
        '
        'ExePath
        '
        Me.ExePath.Location = New System.Drawing.Point(90, 17)
        Me.ExePath.Name = "ExePath"
        Me.ExePath.Size = New System.Drawing.Size(227, 20)
        Me.ExePath.TabIndex = 0
        Me.ExePath.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "SteamCMD path"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 318)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.UpdateServerButton)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(611, 356)
        Me.MinimumSize = New System.Drawing.Size(611, 356)
        Me.Name = "Form1"
        Me.Text = "SteamCMD GUI"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GamesList As System.Windows.Forms.ComboBox
    Friend WithEvents SteamCMDDownloadButton As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
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

End Class

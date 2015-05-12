<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutWindow))
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.AutorLabel = New System.Windows.Forms.Label()
        Me.Close2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VersionLabel2 = New System.Windows.Forms.Label()
        Me.AuthorLabel2 = New System.Windows.Forms.Label()
        Me.ChangelogButton = New System.Windows.Forms.Button()
        Me.LicenseURL = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.LicenseURL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VersionLabel
        '
        resources.ApplyResources(Me.VersionLabel, "VersionLabel")
        Me.VersionLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.VersionLabel.Name = "VersionLabel"
        '
        'AutorLabel
        '
        resources.ApplyResources(Me.AutorLabel, "AutorLabel")
        Me.AutorLabel.BackColor = System.Drawing.SystemColors.Control
        Me.AutorLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AutorLabel.Name = "AutorLabel"
        '
        'Close2
        '
        resources.ApplyResources(Me.Close2, "Close2")
        Me.Close2.Name = "Close2"
        Me.Close2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'VersionLabel2
        '
        resources.ApplyResources(Me.VersionLabel2, "VersionLabel2")
        Me.VersionLabel2.Name = "VersionLabel2"
        '
        'AuthorLabel2
        '
        resources.ApplyResources(Me.AuthorLabel2, "AuthorLabel2")
        Me.AuthorLabel2.Name = "AuthorLabel2"
        '
        'ChangelogButton
        '
        resources.ApplyResources(Me.ChangelogButton, "ChangelogButton")
        Me.ChangelogButton.Name = "ChangelogButton"
        Me.ChangelogButton.UseVisualStyleBackColor = True
        '
        'LicenseURL
        '
        Me.LicenseURL.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.CCLicense
        resources.ApplyResources(Me.LicenseURL, "LicenseURL")
        Me.LicenseURL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LicenseURL.Name = "LicenseURL"
        Me.LicenseURL.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.SteamCMDGUI_Logo
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'AboutWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ChangelogButton)
        Me.Controls.Add(Me.LicenseURL)
        Me.Controls.Add(Me.AuthorLabel2)
        Me.Controls.Add(Me.VersionLabel2)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.AutorLabel)
        Me.Controls.Add(Me.Close2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AboutWindow"
        CType(Me.LicenseURL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents AutorLabel As System.Windows.Forms.Label
    Friend WithEvents Close2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents VersionLabel2 As System.Windows.Forms.Label
    Friend WithEvents AuthorLabel2 As System.Windows.Forms.Label
    Friend WithEvents LicenseURL As System.Windows.Forms.PictureBox
    Friend WithEvents ChangelogButton As System.Windows.Forms.Button
End Class

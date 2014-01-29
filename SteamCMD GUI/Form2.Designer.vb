<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.AutorLabel = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VersionLabel2 = New System.Windows.Forms.Label()
        Me.AuthorLabel2 = New System.Windows.Forms.Label()
        Me.LicenseURL = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ChangelogButton = New System.Windows.Forms.Button()
        CType(Me.LicenseURL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Location = New System.Drawing.Point(137, 99)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(41, 13)
        Me.VersionLabel.TabIndex = 12
        Me.VersionLabel.Text = "version"
        '
        'AutorLabel
        '
        Me.AutorLabel.AutoSize = True
        Me.AutorLabel.BackColor = System.Drawing.SystemColors.Control
        Me.AutorLabel.Location = New System.Drawing.Point(137, 121)
        Me.AutorLabel.Name = "AutorLabel"
        Me.AutorLabel.Size = New System.Drawing.Size(60, 13)
        Me.AutorLabel.TabIndex = 13
        Me.AutorLabel.Text = "Dio Joestar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(187, 227)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(77, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "SteamCMD GUI"
        '
        'VersionLabel2
        '
        Me.VersionLabel2.AutoSize = True
        Me.VersionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel2.Location = New System.Drawing.Point(78, 99)
        Me.VersionLabel2.Name = "VersionLabel2"
        Me.VersionLabel2.Size = New System.Drawing.Size(53, 13)
        Me.VersionLabel2.TabIndex = 17
        Me.VersionLabel2.Text = "Version:"
        '
        'AuthorLabel2
        '
        Me.AuthorLabel2.AutoSize = True
        Me.AuthorLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuthorLabel2.Location = New System.Drawing.Point(83, 121)
        Me.AuthorLabel2.Name = "AuthorLabel2"
        Me.AuthorLabel2.Size = New System.Drawing.Size(48, 13)
        Me.AuthorLabel2.TabIndex = 17
        Me.AuthorLabel2.Text = "Author:"
        '
        'LicenseURL
        '
        Me.LicenseURL.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.by_nc_sa
        Me.LicenseURL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LicenseURL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LicenseURL.Location = New System.Drawing.Point(89, 152)
        Me.LicenseURL.Name = "LicenseURL"
        Me.LicenseURL.Size = New System.Drawing.Size(88, 31)
        Me.LicenseURL.TabIndex = 18
        Me.LicenseURL.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(106, 32)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'ChangelogButton
        '
        Me.ChangelogButton.Location = New System.Drawing.Point(12, 227)
        Me.ChangelogButton.Name = "ChangelogButton"
        Me.ChangelogButton.Size = New System.Drawing.Size(75, 23)
        Me.ChangelogButton.TabIndex = 19
        Me.ChangelogButton.Text = "Changelog"
        Me.ChangelogButton.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 262)
        Me.Controls.Add(Me.ChangelogButton)
        Me.Controls.Add(Me.LicenseURL)
        Me.Controls.Add(Me.AuthorLabel2)
        Me.Controls.Add(Me.VersionLabel2)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.AutorLabel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(290, 300)
        Me.MinimumSize = New System.Drawing.Size(290, 300)
        Me.Name = "Form2"
        Me.Text = "SteamCMD GUI"
        CType(Me.LicenseURL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents AutorLabel As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents VersionLabel2 As System.Windows.Forms.Label
    Friend WithEvents AuthorLabel2 As System.Windows.Forms.Label
    Friend WithEvents LicenseURL As System.Windows.Forms.PictureBox
    Friend WithEvents ChangelogButton As System.Windows.Forms.Button
End Class

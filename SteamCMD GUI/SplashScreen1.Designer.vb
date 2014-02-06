<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen1
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
        Me.AuthorLabelSplash = New System.Windows.Forms.Label()
        Me.VersionLabelSplash = New System.Windows.Forms.Label()
        Me.BannerSplash = New System.Windows.Forms.PictureBox()
        Me.LoadingLabelSplash = New System.Windows.Forms.Label()
        CType(Me.BannerSplash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AuthorLabelSplash
        '
        Me.AuthorLabelSplash.AutoSize = True
        Me.AuthorLabelSplash.BackColor = System.Drawing.Color.Transparent
        Me.AuthorLabelSplash.ForeColor = System.Drawing.SystemColors.Menu
        Me.AuthorLabelSplash.Location = New System.Drawing.Point(540, 113)
        Me.AuthorLabelSplash.Name = "AuthorLabelSplash"
        Me.AuthorLabelSplash.Size = New System.Drawing.Size(60, 13)
        Me.AuthorLabelSplash.TabIndex = 3
        Me.AuthorLabelSplash.Text = "Dio Joestar"
        Me.AuthorLabelSplash.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'VersionLabelSplash
        '
        Me.VersionLabelSplash.AutoSize = True
        Me.VersionLabelSplash.BackColor = System.Drawing.Color.Transparent
        Me.VersionLabelSplash.ForeColor = System.Drawing.SystemColors.Menu
        Me.VersionLabelSplash.Location = New System.Drawing.Point(518, 129)
        Me.VersionLabelSplash.Name = "VersionLabelSplash"
        Me.VersionLabelSplash.Size = New System.Drawing.Size(113, 13)
        Me.VersionLabelSplash.TabIndex = 3
        Me.VersionLabelSplash.Text = "Version: {0}.{1}.{2}.{3}"
        Me.VersionLabelSplash.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'BannerSplash
        '
        Me.BannerSplash.BackColor = System.Drawing.Color.Transparent
        Me.BannerSplash.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.BannerSplash
        Me.BannerSplash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BannerSplash.InitialImage = Nothing
        Me.BannerSplash.Location = New System.Drawing.Point(6, 12)
        Me.BannerSplash.Name = "BannerSplash"
        Me.BannerSplash.Size = New System.Drawing.Size(611, 246)
        Me.BannerSplash.TabIndex = 4
        Me.BannerSplash.TabStop = False
        '
        'LoadingLabelSplash
        '
        Me.LoadingLabelSplash.AutoSize = True
        Me.LoadingLabelSplash.BackColor = System.Drawing.Color.Transparent
        Me.LoadingLabelSplash.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadingLabelSplash.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LoadingLabelSplash.Location = New System.Drawing.Point(534, 161)
        Me.LoadingLabelSplash.Name = "LoadingLabelSplash"
        Me.LoadingLabelSplash.Size = New System.Drawing.Size(66, 16)
        Me.LoadingLabelSplash.TabIndex = 5
        Me.LoadingLabelSplash.Text = "Loading..."
        '
        'SplashScreen1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(629, 270)
        Me.ControlBox = False
        Me.Controls.Add(Me.LoadingLabelSplash)
        Me.Controls.Add(Me.VersionLabelSplash)
        Me.Controls.Add(Me.AuthorLabelSplash)
        Me.Controls.Add(Me.BannerSplash)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.Color.Gray
        CType(Me.BannerSplash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AuthorLabelSplash As System.Windows.Forms.Label
    Friend WithEvents BannerSplash As System.Windows.Forms.PictureBox
    Friend WithEvents VersionLabelSplash As System.Windows.Forms.Label
    Friend WithEvents LoadingLabelSplash As System.Windows.Forms.Label

End Class

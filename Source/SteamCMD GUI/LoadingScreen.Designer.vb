<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadingScreen))
        Me.InfoLabelSplash = New System.Windows.Forms.Label()
        Me.VersionLabelSplash = New System.Windows.Forms.Label()
        Me.BannerSplash = New System.Windows.Forms.PictureBox()
        Me.Copyright = New System.Windows.Forms.Label()
        CType(Me.BannerSplash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InfoLabelSplash
        '
        Me.InfoLabelSplash.BackColor = System.Drawing.Color.Transparent
        Me.InfoLabelSplash.ForeColor = System.Drawing.SystemColors.Menu
        resources.ApplyResources(Me.InfoLabelSplash, "InfoLabelSplash")
        Me.InfoLabelSplash.Name = "InfoLabelSplash"
        '
        'VersionLabelSplash
        '
        resources.ApplyResources(Me.VersionLabelSplash, "VersionLabelSplash")
        Me.VersionLabelSplash.BackColor = System.Drawing.Color.Transparent
        Me.VersionLabelSplash.ForeColor = System.Drawing.SystemColors.Menu
        Me.VersionLabelSplash.Name = "VersionLabelSplash"
        '
        'BannerSplash
        '
        Me.BannerSplash.BackColor = System.Drawing.Color.Transparent
        Me.BannerSplash.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.BannerSplash
        resources.ApplyResources(Me.BannerSplash, "BannerSplash")
        Me.BannerSplash.Name = "BannerSplash"
        Me.BannerSplash.TabStop = False
        '
        'Copyright
        '
        resources.ApplyResources(Me.Copyright, "Copyright")
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.ForeColor = System.Drawing.SystemColors.Menu
        Me.Copyright.Name = "Copyright"
        '
        'LoadingScreen
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ControlBox = False
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.VersionLabelSplash)
        Me.Controls.Add(Me.InfoLabelSplash)
        Me.Controls.Add(Me.BannerSplash)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoadingScreen"
        Me.ShowInTaskbar = False
        Me.TransparencyKey = System.Drawing.Color.Gray
        CType(Me.BannerSplash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InfoLabelSplash As System.Windows.Forms.Label
    Friend WithEvents BannerSplash As System.Windows.Forms.PictureBox
    Friend WithEvents VersionLabelSplash As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label

End Class

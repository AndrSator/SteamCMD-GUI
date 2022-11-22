<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommandLineOptionsWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CommandLineOptionsWindow))
        Me.CommandsTextbox = New System.Windows.Forms.TextBox()
        Me.CommandHelpButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CommandsTextbox
        '
        resources.ApplyResources(Me.CommandsTextbox, "CommandsTextbox")
        Me.CommandsTextbox.Name = "CommandsTextbox"
        '
        'CommandHelpButton
        '
        resources.ApplyResources(Me.CommandHelpButton, "CommandHelpButton")
        Me.CommandHelpButton.BackColor = System.Drawing.Color.Transparent
        Me.CommandHelpButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Help
        Me.CommandHelpButton.Name = "CommandHelpButton"
        Me.CommandHelpButton.TabStop = False
        Me.CommandHelpButton.UseVisualStyleBackColor = False
        '
        'CommandLineOptionsWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CommandHelpButton)
        Me.Controls.Add(Me.CommandsTextbox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "CommandLineOptionsWindow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CommandsTextbox As System.Windows.Forms.TextBox
    Friend WithEvents CommandHelpButton As System.Windows.Forms.Button
End Class

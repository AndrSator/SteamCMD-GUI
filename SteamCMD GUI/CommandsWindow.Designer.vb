<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommandLineOptionsWindow
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
        Me.CommandsTextbox = New System.Windows.Forms.TextBox()
        Me.CommandHelpButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CommandsTextbox
        '
        Me.CommandsTextbox.Location = New System.Drawing.Point(12, 9)
        Me.CommandsTextbox.Name = "CommandsTextbox"
        Me.CommandsTextbox.Size = New System.Drawing.Size(659, 20)
        Me.CommandsTextbox.TabIndex = 0
        '
        'CommandHelpButton
        '
        Me.CommandHelpButton.BackColor = System.Drawing.Color.Transparent
        Me.CommandHelpButton.BackgroundImage = Global.SteamCMD_GUI.My.Resources.Resources.Help
        Me.CommandHelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CommandHelpButton.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.CommandHelpButton.Location = New System.Drawing.Point(677, 8)
        Me.CommandHelpButton.Name = "CommandHelpButton"
        Me.CommandHelpButton.Size = New System.Drawing.Size(23, 23)
        Me.CommandHelpButton.TabIndex = 1
        Me.CommandHelpButton.TabStop = False
        Me.CommandHelpButton.UseVisualStyleBackColor = False
        '
        'CommandLineOptionsWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 38)
        Me.Controls.Add(Me.CommandHelpButton)
        Me.Controls.Add(Me.CommandsTextbox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "CommandLineOptionsWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Custom Commands"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CommandsTextbox As System.Windows.Forms.TextBox
    Friend WithEvents CommandHelpButton As System.Windows.Forms.Button
End Class

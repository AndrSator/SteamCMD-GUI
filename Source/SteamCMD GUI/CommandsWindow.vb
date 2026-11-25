Public Class CommandLineOptionsWindow
    Private Sub LoadWindow() Handles Me.Load
        CommandsTextbox.Text = AdditionalCommands
    End Sub

    Private Sub CommandsTextbox_TextChanged() Handles CommandsTextbox.TextChanged
        AdditionalCommands = CommandsTextbox.Text
    End Sub

    Private Sub CommandsTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CommandsTextbox.KeyPress
        ' Close if press Enter or Escape
        If e.KeyChar = ChrW(Keys.Enter) OrElse e.KeyChar = ChrW(Keys.Escape) Then
            e.Handled = True
            Close()
        End If
    End Sub

    Private Sub CommandHelpButton_Click() Handles CommandHelpButton.Click
        Process.Start("https://developer.valvesoftware.com/wiki/Command_Line_Options")
    End Sub

    Private Sub CommandHelpButton_Click(sender As System.Object, e As EventArgs) Handles CommandHelpButton.Click

    End Sub
End Class
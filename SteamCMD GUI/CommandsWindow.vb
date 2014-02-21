Public Class CommandLineOptionsWindow
    Private Sub LoadWindow() Handles Me.Load
        CommandsTextbox.Text = AdditionalCommands
    End Sub

    ' Disable close button
    Private Const DisableClose As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or DisableClose
            Return myCp
        End Get
    End Property

    Private Sub Test(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CommandsTextbox.KeyPress
        AdditionalCommands = CommandsTextbox.Text
        ' Close if press Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.Close()
        End If
    End Sub

    Private Sub CommandHelpButton_Click() Handles CommandHelpButton.Click
        Process.Start("https://developer.valvesoftware.com/wiki/Command_Line_Options")
    End Sub
End Class
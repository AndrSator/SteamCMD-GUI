Public Class Form2
    Private Sub Form2_Load() Handles MyBase.Load
        VersionLabel.Text = My.Application.Info.Version.ToString()
    End Sub

    Private Sub LicenseURL_Click() Handles LicenseURL.Click
        Process.Start("https://github.com/DioJoestar/SteamCMD-GUI/blob/master/License.txt")
    End Sub

    Private Sub ChangelogButton_Click() Handles ChangelogButton.Click
        Process.Start("https://github.com/DioJoestar/SteamCMD-GUI/blob/master/Changelog.txt")
    End Sub

    Private Sub Button1_Click() Handles Button1.Click
        Me.Close()
    End Sub
End Class
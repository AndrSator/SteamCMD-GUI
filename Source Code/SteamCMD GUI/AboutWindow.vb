Imports System.IO

Public Class AboutWindow
    Private Sub Form2_Load() Handles MyBase.Load
        VersionLabel.Text = System.String.Format(VersionLabel.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        Icon = My.Resources.SteamCMDGUI_Icon
    End Sub

    Private Sub LicenseURL_Click() Handles LicenseURL.Click
        If File.Exists("License.txt") Then
            Process.Start("License.txt")
        Else
            Process.Start("https://raw.github.com/DioJoestar/SteamCMD-GUI/master/License.txt")
        End If
    End Sub

    Private Sub ChangelogButton_Click() Handles ChangelogButton.Click
        If File.Exists("Changelog.txt") Then
            Process.Start("Changelog.txt")
        Else
            Process.Start("https://raw.github.com/DioJoestar/SteamCMD-GUI/master/Changelog.txt")
        End If
    End Sub

    Private Sub Close2_Click() Handles Close2.Click
        Close()
    End Sub

    Private Sub LicenseURL_Click(sender As System.Object, e As EventArgs) Handles LicenseURL.Click

    End Sub
End Class
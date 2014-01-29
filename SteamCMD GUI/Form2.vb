Imports System.IO

Public Class Form2
    Private Sub Form2_Load() Handles MyBase.Load
        VersionLabel.Text = My.Application.Info.Version.ToString()
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
        Me.Close()
    End Sub
End Class
Public Class Form2
    Private Sub Button1_Click() Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ButtonTwitter_Click() Handles ButtonTwitter.Click
        System.Diagnostics.Process.Start("https://twitter.com/Dio_Joestar")
    End Sub

    Private Sub ButtonSteam_Click() Handles ButtonSteam.Click
        System.Diagnostics.Process.Start("http://steamcommunity.com/profiles/76561198000420180")
    End Sub
End Class
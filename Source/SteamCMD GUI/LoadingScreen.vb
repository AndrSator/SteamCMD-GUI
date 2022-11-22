Public NotInheritable Class LoadingScreen
    Private Sub SplashScreen1_Load() Handles Me.Load
        InfoLabelSplash.Text = "Dio Joestar" & Chr(13) & "Version: " & System.String.Format(InfoLabelSplash.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision) & Chr(13) & "CC BY-NC-SA 4.0"
        'Transparent things
        TransparencyKey = BackColor
        InfoLabelSplash.Parent = BannerSplash
        InfoLabelSplash.Location.Offset(-BannerSplash.Left, -BannerSplash.Top)
    End Sub
End Class

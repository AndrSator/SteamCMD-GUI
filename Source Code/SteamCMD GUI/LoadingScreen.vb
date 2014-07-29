Public NotInheritable Class LoadingScreen
    Private Sub SplashScreen1_Load() Handles Me.Load
        VersionLabelSplash.Text = System.String.Format(VersionLabelSplash.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        'Transparent things
        TransparencyKey = BackColor
        LoadingLabelSplash.Parent = BannerSplash
        AuthorLabelSplash.Parent = BannerSplash
        VersionLabelSplash.Parent = BannerSplash
        Copyright.Parent = BannerSplash
    End Sub
End Class

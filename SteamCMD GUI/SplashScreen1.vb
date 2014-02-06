Public NotInheritable Class SplashScreen1
    Private Sub SplashScreen1_Load() Handles Me.Load
        VersionLabelSplash.Text = System.String.Format(VersionLabelSplash.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        'Transparent things
        Me.TransparencyKey = BackColor
        LoadingLabelSplash.Parent = BannerSplash
        AuthorLabelSplash.Parent = BannerSplash
        VersionLabelSplash.Parent = BannerSplash
    End Sub
End Class

Namespace My
    Partial Friend Class MyApplication
        ' A server in the Console tab would stay running and hidden
        Private Sub MyApplication_UnhandledException(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Global.SteamCMD_GUI.MainMenu.ReleaseServerConsole()
        End Sub
    End Class
End Namespace

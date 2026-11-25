Option Strict On

' Builds the command lines of the programs launched by the GUI
Friend Module CommandLine
    ' A backslash before the closing quote would escape it ("D:\"), so it has to be doubled
    Public Function QuotePath(path As String) As String
        Dim trailing As Integer = path.Length - path.TrimEnd("\"c).Length
        Return Chr(34) & path & New String("\"c, trailing) & Chr(34)
    End Function

    Public Function GoldSrcModConfig(appId As String, modName As String) As String
        If appId <> "90" OrElse String.IsNullOrEmpty(modName) Then Return ""
        Return " +app_set_config 90 mod " & modName
    End Function

    Public Function ForSteamCmd(installPath As String, login As String, modConfig As String, appId As String, validate As String) As String
        Return "+force_install_dir " & installPath & " +login " & login & modConfig & " +app_update " & appId & validate
    End Function
End Module

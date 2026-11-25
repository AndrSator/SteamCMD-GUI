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

    Public Function ForServer(o As ServerOptions) As String
        Dim switches As String = o.Switches
        Dim settings As String = " +hostname " & Chr(34) & o.HostName & Chr(34)
        If Not String.IsNullOrEmpty(o.Rcon) Then
            ' The quotes can't be escaped, they would end the password
            settings &= " +rcon_password " & Chr(34) & o.Rcon.Replace(Chr(34), "") & Chr(34)
            ' Counter-Strike doesn't listen to RCON without it
            If o.Server = ServerType.Source2 OrElse o.Folder = "csgo" Then switches &= "-usercon "
        End If
        If o.Gslt IsNot Nothing AndAlso o.Gslt.Trim() <> "" Then settings &= " +sv_setsteamaccount " & o.Gslt.Trim()

        If o.Server = ServerType.Source2 Then
            Return "-dedicated " & switches & "-port " & o.Port & " -maxplayers " & o.MaxPlayers & settings & " +map " & o.Map & " +sv_lan " & o.Lan & " " & o.Additional
        End If
        Dim game As String = If(o.Server = ServerType.Classified, "-tf_path " & QuotePath(o.TfPath), "-game " & o.Folder)
        Return switches & game & " -port " & o.Port & settings & " +map " & o.Map & " +maxplayers " & o.MaxPlayers & " +sv_lan " & o.Lan & " " & o.Additional
    End Function
End Module

Friend Class ServerOptions
    Public Server As ServerType
    Public Switches As String ' -console -insecure...
    Public Folder As String
    Public TfPath As String
    Public Port As String
    Public HostName As String
    Public Map As String
    Public MaxPlayers As String
    Public Lan As Integer
    Public Rcon As String
    Public Gslt As String
    Public Additional As String
End Class

Option Strict On

Imports System.Text.RegularExpressions

' Builds the command lines of the programs launched by the GUI
Friend Module CommandLine
    ' A backslash before the closing quote would escape it ("D:\"), so it has to be doubled
    Public Function QuotePath(path As String) As String
        Dim trailing As Integer = path.Length - path.TrimEnd("\"c).Length
        Return Chr(34) & path & New String("\"c, trailing) & Chr(34)
    End Function

    ' Without password SteamCMD uses its saved session, with it Steam Guard asks for a code every time
    Public Function SteamLogin(anonymous As Boolean, userName As String, password As String) As String
        If anonymous Then Return "anonymous"
        Return userName & If(password = "", "", " " & password)
    End Function

    Public Function GoldSrcModConfig(appId As String, modName As String) As String
        If appId <> "90" OrElse String.IsNullOrEmpty(modName) Then Return ""
        Return " +app_set_config 90 mod " & modName
    End Function

    Public Function ForSteamCmd(installPath As String, login As String, modConfig As String, appId As String, validate As String) As String
        Return "+force_install_dir " & installPath & " +login " & login & modConfig & " +app_update " & appId & validate
    End Function

    ' Added after ForSteamCmd to install another app in other folder
    Public Function AlsoInstall(installPath As String, appId As String, validate As String) As String
        Return " +force_install_dir " & installPath & " +app_update " & appId & validate
    End Function

    Public Function HasParameter(line As String, parameter As String) As Boolean
        Return line IsNot Nothing AndAlso Regex.IsMatch(line, "(^|\s)" & Regex.Escape(parameter) & "(\s|$)", RegexOptions.IgnoreCase)
    End Function

    ' Doesn't replace the parameter if it's already there
    Public Function AddPath(line As String, parameter As String, path As String) As String
        If HasParameter(line, parameter) Then Return line
        Return (parameter & " " & QuotePath(path) & " " & line).Trim()
    End Function

    Public Function ForServer(o As ServerOptions) As String
        Dim switches As String = o.Switches
        ' In the Console tab of the program it has to use its text console
        If o.InConsole AndAlso Not HasParameter(switches, "-console") Then switches = "-console " & switches
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
        ' Team Fortress 2 Classified needs -tf_path instead, it's in the additional parameters
        Dim game As String = If(o.Server = ServerType.Classified, "", "-game " & o.Folder & " ")
        Return switches & game & "-port " & o.Port & settings & " +map " & o.Map & " +maxplayers " & o.MaxPlayers & " +sv_lan " & o.Lan & " " & o.Additional
    End Function
End Module

Friend Class ServerOptions
    Public Server As ServerType
    Public Switches As String ' -console -insecure...
    Public Folder As String
    Public Port As String
    Public HostName As String
    Public Map As String
    Public MaxPlayers As String
    Public Lan As Integer
    Public Rcon As String
    Public Gslt As String
    Public InConsole As Boolean ' Run in the Console tab of the program
    Public Additional As String
End Class

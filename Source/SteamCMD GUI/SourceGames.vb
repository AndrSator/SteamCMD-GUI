Option Strict On

Imports System.IO

Friend Enum ServerType
    Srcds
    Classified ' Team Fortress 2 Classified, it also needs the files of Team Fortress 2
    Source2
End Enum

' Games of the Run Server tab and the folder used in the -game parameter
Friend Module SourceGames
    Public Function FolderOf(gameName As String) As String
        Select Case gameName
            Case "Alien Swarm" : Return "swarm"
            Case "Counter-Strike 2" : Return "game\csgo"
            Case "Counter-Strike: Global Offensive" : Return "csgo"
            Case "Counter-Strike: Source" : Return "cstrike"
            Case "Day of Defeat: Source" : Return "dod"
            Case "Garry's Mod" : Return "garrysmod"
            Case "Half-Life 2: Deathmatch" : Return "hl2mp"
            Case "Insurgency" : Return "insurgency"
            Case "Left 4 Dead" : Return "left4dead"
            Case "Left 4 Dead 2" : Return "left4dead2"
            Case "Team Fortress 2" : Return "tf"
            Case "Team Fortress 2 Classified" : Return "tf2classified"
        End Select
        Return Nothing
    End Function

    Public Function ServerOf(gameName As String) As ServerType
        Select Case gameName
            Case "Counter-Strike 2" : Return ServerType.Source2
            Case "Team Fortress 2 Classified" : Return ServerType.Classified
        End Select
        Return ServerType.Srcds
    End Function

    Public Function Executable(server As ServerType) As String
        Select Case server
            Case ServerType.Classified : Return "srcds_win64.exe"
            Case ServerType.Source2 : Return "game\bin\win64\cs2.exe"
        End Select
        Return "srcds.exe"
    End Function

    Public Function HasServer(folder As String) As Boolean
        Dim servers() As ServerType = {ServerType.Srcds, ServerType.Classified, ServerType.Source2}
        Return servers.Any(Function(s) File.Exists(Path.Combine(folder, Executable(s))))
    End Function

    ' Folder of Team Fortress 2 if that folder is it, or the 'tf' one inside it
    Public Function TeamFortress2In(folder As String) As String
        If String.IsNullOrEmpty(folder) Then Return Nothing
        If File.Exists(Path.Combine(folder, "tf\gameinfo.txt")) Then Return folder
        If String.Equals(Path.GetFileName(folder), "tf", StringComparison.OrdinalIgnoreCase) AndAlso File.Exists(Path.Combine(folder, "gameinfo.txt")) Then
            Return Path.GetDirectoryName(folder)
        End If
        Return Nothing
    End Function

    ' Where the server of Team Fortress 2 is installed with the one of Team Fortress 2 Classified
    Public Function Tf2FolderOf(serverFolder As String) As String
        Return Path.Combine(serverFolder, "tf2")
    End Function

    Public Function Maps(folder As String, server As ServerType) As List(Of String)
        Dim pattern As String = If(server = ServerType.Source2, "*.vpk", "*.bsp")
        Dim names As IEnumerable(Of String) = Directory.GetFiles(folder, pattern).Select(Function(f) Path.GetFileNameWithoutExtension(f))
        If server = ServerType.Source2 Then names = names.Where(Function(n) IsPlayable(n))
        Return names.OrderBy(Function(n) n, StringComparer.OrdinalIgnoreCase).ToList()
    End Function

    ' The maps folder of Counter-Strike 2 also has the backgrounds of the menus
    Private Function IsPlayable(map As String) As Boolean
        Return Not (map.EndsWith("_vanity") OrElse map.StartsWith("workshop_preview_") OrElse map = "graphics_settings" OrElse map = "lobby_mapveto")
    End Function
End Module

Option Strict On

Imports System.IO
Imports System.Text.RegularExpressions

' Games installed with Steam
Friend Module SteamLibrary
    ' Folder inside the server of Team Fortress 2 Classified where the one of Team Fortress 2 is installed
    Public Const Tf2Subfolder As String = "tf2"

    ' The dedicated server of Team Fortress 2 or the game, Nothing if none of them is installed
    Public Function FindTeamFortress2(steamFolder As String) As String
        If String.IsNullOrEmpty(steamFolder) Then Return Nothing
        Dim libraries As List(Of String) = Folders(steamFolder)
        For Each name As String In New String() {"Team Fortress 2 Dedicated Server", "Team Fortress 2"}
            For Each library As String In libraries
                Dim found As String = TeamFortress2In(Path.Combine(library, "steamapps\common\" & name))
                If found IsNot Nothing Then Return found
            Next
        Next
        Return Nothing
    End Function

    ' Folder of Team Fortress 2 to run a server of Team Fortress 2 Classified, Nothing if it has to be selected
    Public Function TeamFortress2For(serverFolder As String, savedFolder As String, steamFolder As String) As String
        Return If(TeamFortress2In(savedFolder), If(TeamFortress2In(Path.Combine(serverFolder, Tf2Subfolder)), FindTeamFortress2(steamFolder)))
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

    Private Function Folders(steamFolder As String) As List(Of String)
        Dim result As New List(Of String)
        result.Add(steamFolder)
        Dim list As String = Path.Combine(steamFolder, "steamapps\libraryfolders.vdf")
        If File.Exists(list) Then
            For Each m As Match In Regex.Matches(File.ReadAllText(list), """path""\s+""([^""]+)""")
                result.Add(m.Groups(1).Value.Replace("\\", "\"))
            Next
        End If
        Return result
    End Function
End Module

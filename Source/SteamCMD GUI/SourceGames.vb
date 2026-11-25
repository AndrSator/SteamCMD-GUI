Option Strict On

' Games of the Run Server tab and the folder used in the -game parameter
Friend Module SourceGames
    Public Function FolderOf(gameName As String) As String
        Select Case gameName
            Case "Alien Swarm" : Return "swarm"
            Case "Counter-Strike: Global Offensive" : Return "csgo"
            Case "Counter-Strike: Source" : Return "cstrike"
            Case "Day of Defeat: Source" : Return "dod"
            Case "Garry's Mod" : Return "garrysmod"
            Case "Half-Life 2: Deathmatch" : Return "hl2mp"
            Case "Insurgency" : Return "insurgency"
            Case "Left 4 Dead" : Return "left4dead"
            Case "Left 4 Dead 2" : Return "left4dead2"
            Case "Team Fortress 2" : Return "tf"
        End Select
        Return Nothing
    End Function
End Module

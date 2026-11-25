Option Strict On

Imports System.IO
Imports System.Xml

' Games of the Update/Install tab (Settings/SteamCMDGames.xml)
Friend Module GameCatalog
    ' Games added to the defaults after this version also reach the lists already saved by the users
    Private Const CurrentVersion As Integer = 2

    Public Function LoadOrCreate(path As String) As Dictionary(Of String, String)
        Dim games As New Dictionary(Of String, String)
        Dim version As Integer = 0
        If File.Exists(path) Then
            ' The lists saved before 3.2.0.0 don't have this attribute
            version = 1
            Using xml As XmlReader = New XmlTextReader(path)
                While xml.Read()
                    If xml.NodeType <> XmlNodeType.Element Then Continue While
                    If xml.Name = "SteamCMD-Games" Then
                        If Not Integer.TryParse(xml.GetAttribute("version"), version) Then version = 1
                    ElseIf xml.Name = "Game" Then
                        xml.MoveToAttribute("id")
                        Dim id As String = xml.Value
                        xml.Read()
                        If xml.NodeType = XmlNodeType.Text Then games(id) = xml.Value
                    End If
                End While
            End Using
        End If

        If version < CurrentVersion Then
            ReplaceId(games, "510", "222840", "Left 4 Dead")
            AddDefaults(games, version)
            Try
                Save(path, games)
            Catch ex As UnauthorizedAccessException
                ' Read-only list: use it as is, it will be merged again the next time
            Catch ex As IOException
            End Try
        End If
        Return games
    End Function

    ' Adds only the games that a list of that version doesn't know, so the ones removed by the user don't come back
    Private Sub AddDefaults(games As Dictionary(Of String, String), version As Integer)
        Dim add As Action(Of Integer, String, String) =
            Sub(since, id, name)
                If version < since AndAlso Not games.ContainsKey(id) Then games.Add(id, name)
            End Sub

        add(1, "635", "Alien Swarm")
        add(1, "740", "Counter-Strike: Global Offensive")
        add(2, "730", "Counter-Strike 2")
        add(1, "232330", "Counter-Strike: Source")
        add(1, "232290", "Day of Defeat: Source")
        add(1, "570", "Dota 2")
        add(1, "4020", "Garry's Mod")
        add(1, "90", "Half-Life Dedicated Server")
        add(1, "232370", "Half-Life 2: Deathmatch")
        add(2, "2089300", "Icarus Dedicated Server")
        add(2, "237410", "Insurgency")
        add(1, "222840", "Left 4 Dead")
        add(1, "222860", "Left 4 Dead 2")
        add(1, "232250", "Team Fortress 2")
        add(2, "3557020", "Team Fortress 2 Classified")
    End Sub

    ' Entries renamed by the user are left untouched
    Private Sub ReplaceId(games As Dictionary(Of String, String), oldId As String, newId As String, name As String)
        Dim current As String = Nothing
        If Not games.TryGetValue(oldId, current) OrElse current <> name Then Return
        games.Remove(oldId)
        If Not games.ContainsKey(newId) Then games.Add(newId, name)
    End Sub

    Public Sub Save(path As String, games As Dictionary(Of String, String))
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        Using xml As XmlWriter = XmlWriter.Create(path, settings)
            xml.WriteStartDocument()
            xml.WriteComment("Custom Games Config used by SteamCMD GUI")
            xml.WriteComment("This config is loaded automatically.")
            xml.WriteStartElement("SteamCMD-Games")
            xml.WriteAttributeString("version", CurrentVersion.ToString())
            For Each game As KeyValuePair(Of String, String) In games
                xml.WriteStartElement("Game")
                xml.WriteAttributeString("id", game.Key)
                xml.WriteString(game.Value)
                xml.WriteEndElement()
            Next
            xml.WriteEndElement()
            xml.WriteEndDocument()
        End Using
    End Sub
End Module

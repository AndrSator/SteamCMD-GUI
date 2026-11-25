Option Strict On

Imports System.Xml

' Config file of the Run Server tab
Friend Class ServerConfig
    Public SteamCmdPath As String
    Public Path As String
    Public HostName As String
    Public GameName As String
    Public CustomMod As String
    Public Map As String
    Public Network As String
    Public Players As String
    Public Rcon As String
    Public Gslt As String
    Public Port As String
    Public AdditionalCommands As String

    ' Throws XmlException if it isn't a config file. The missing values are Nothing
    Public Shared Function Load(file As String) As ServerConfig
        Dim root As XElement = XDocument.Load(file).Root
        If root.Name.LocalName <> "Config" Then Throw New XmlException("it isn't a config of the Run Server tab.")

        Dim value As Func(Of String, String) = Function(name) CStr(root.Descendants(name).FirstOrDefault())
        Dim c As New ServerConfig()
        c.SteamCmdPath = value("SteamCMD")
        c.Path = value("Path")
        c.HostName = value("HostName")
        c.GameName = value("Mod")
        c.CustomMod = value("CustomMod")
        c.Map = value("Map")
        c.Network = value("Network")
        c.Players = value("Players")
        c.Rcon = value("RCON")
        c.Gslt = value("GSLT")
        c.Port = value("Port")
        c.AdditionalCommands = value("AdditionalCommands")
        Return c
    End Function

    Public Sub Save(file As String)
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        Using xml As XmlWriter = XmlWriter.Create(file, settings)
            xml.WriteStartDocument()
            xml.WriteComment("Config used by SteamCMD GUI")
            xml.WriteStartElement("Config")
            xml.WriteStartElement("Srcds-Config")
            xml.WriteElementString("Path", Path)
            xml.WriteEndElement()
            xml.WriteStartElement("Server-Config")
            xml.WriteElementString("HostName", HostName)
            If CustomMod IsNot Nothing Then
                xml.WriteElementString("CustomMod", CustomMod)
            Else
                xml.WriteElementString("Mod", GameName)
            End If
            xml.WriteElementString("Map", Map)
            xml.WriteElementString("Network", Network)
            xml.WriteElementString("Players", Players)
            xml.WriteElementString("RCON", Rcon)
            If Not String.IsNullOrEmpty(Gslt) Then xml.WriteElementString("GSLT", Gslt)
            xml.WriteElementString("Port", Port)
            If Not String.IsNullOrEmpty(AdditionalCommands) Then xml.WriteElementString("AdditionalCommands", AdditionalCommands)
            xml.WriteEndDocument()
        End Using
    End Sub
End Class

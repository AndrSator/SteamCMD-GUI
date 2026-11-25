Option Strict On

Imports System.IO
Imports System.Xml

' Paths of the Update/Install tab (Settings/SteamCMDPath.xml)
Friend Class SteamCmdSettings
    Public CmdPath As String
    Public ServerPath As String

    ' A file that can't be read is ignored, the paths only have to be selected again
    Public Shared Function Load(path As String) As SteamCmdSettings
        Dim settings As New SteamCmdSettings()
        If Not File.Exists(path) Then Return settings
        Try
            Dim root As XElement = XDocument.Load(path).Root
            settings.CmdPath = CStr(root.Element("CMDPath"))
            settings.ServerPath = CStr(root.Element("ServerPath"))
        Catch ex As XmlException
        End Try
        Return settings
    End Function

    Public Sub Save(path As String)
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        Using xml As XmlWriter = XmlWriter.Create(path, settings)
            xml.WriteStartDocument()
            xml.WriteComment("Config used by SteamCMD GUI")
            xml.WriteComment("This config it's loaded automatically.")
            xml.WriteStartElement("SteamCMD-Config")
            If Not String.IsNullOrEmpty(CmdPath) Then xml.WriteElementString("CMDPath", CmdPath)
            If Not String.IsNullOrEmpty(ServerPath) Then xml.WriteElementString("ServerPath", ServerPath)
            xml.WriteEndElement()
            xml.WriteEndDocument()
        End Using
    End Sub
End Class

Option Strict On

Imports System.IO

Friend Module StartupOptions
    ' Config file given as parameter, or Nothing. The relative paths start in the folder where the program was opened
    Public Function ConfigFile(args As IEnumerable(Of String), folder As String) As String
        Dim parameter As String = args.FirstOrDefault(Function(a) a.Trim() <> "")
        If parameter Is Nothing Then Return Nothing
        Try
            Return Path.GetFullPath(Path.Combine(folder, parameter))
        Catch ex As ArgumentException
            Return parameter
        Catch ex As NotSupportedException
            Return parameter
        End Try
    End Function
End Module

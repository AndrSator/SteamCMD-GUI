Option Strict On

Imports System.Globalization
Imports System.Text.RegularExpressions

Friend Enum SteamCmdLineKind
    Other
    Progress
    Success
    Failure
End Enum

Friend Enum SteamCmdPrompt
    None
    Command
    Password
    Code
End Enum

' The meaning of a line written by SteamCMD
Friend NotInheritable Class SteamCmdLine
    Private Const Options As RegexOptions = RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase
    Private Shared ReadOnly Update As New Regex("^(Update state \(0x[0-9a-f]+\) [^,]*), progress: ([0-9.]+) \([0-9]+ / ([0-9]+)\)", Options)
    Private Shared ReadOnly SelfUpdate As New Regex("^\[ *(?:([0-9]+)%|-+)\](.*)$", Options)
    Private Shared ReadOnly Amounts As New Regex("[0-9][0-9.,   ]*", Options)
    Private Shared ReadOnly Installed As New Regex("^Success! App '[0-9]+'", Options)
    Private Shared ReadOnly Failed As New Regex("^(?i:ERROR!)|(^|\.\.\. ?)FAILED\b", RegexOptions.CultureInvariant)

    Public ReadOnly Kind As SteamCmdLineKind
    Public ReadOnly Text As String
    Public ReadOnly Percent As Double
    ' The lines that only update the progress have the same task, Nothing in the rest
    Public ReadOnly Task As String

    Public Sub New(line As String)
        Text = line.Trim()
        Dim m As Match
        If Text.StartsWith("Update state", StringComparison.OrdinalIgnoreCase) Then
            m = Update.Match(Text)
            If Not m.Success Then Return
            Task = m.Groups(1).Value
            ' "(0x0) unknown, progress: 0.00 (0 / 0)", at the end of every install
            If m.Groups(3).Value <> "0" AndAlso Double.TryParse(m.Groups(2).Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, Percent) Then Kind = SteamCmdLineKind.Progress
        ElseIf Text.StartsWith("[", StringComparison.Ordinal) Then
            m = SelfUpdate.Match(Text)
            If Not m.Success Then Return
            Task = Amounts.Replace(m.Groups(2).Value, "#")
            If Double.TryParse(m.Groups(1).Value, NumberStyles.None, CultureInfo.InvariantCulture, Percent) Then Kind = SteamCmdLineKind.Progress
        ElseIf Installed.IsMatch(Text) Then
            Kind = SteamCmdLineKind.Success
        ElseIf Failed.IsMatch(Text) Then
            Kind = SteamCmdLineKind.Failure
        End If
        Percent = Math.Max(0, Math.Min(100, Percent))
    End Sub

    ' SteamCMD writes a new line every time the progress changes
    Public Shared Function Replaces(previous As String, line As String) As Boolean
        Dim task As String = New SteamCmdLine(line).Task
        Return task IsNot Nothing AndAlso task = New SteamCmdLine(previous).Task
    End Function

    ' line is where the cursor is
    Public Shared Function PromptOf(line As String) As SteamCmdPrompt
        line = line.Trim()
        If line = "Steam>" Then Return SteamCmdPrompt.Command
        If line.EndsWith("password:", StringComparison.OrdinalIgnoreCase) Then Return SteamCmdPrompt.Password
        If line.EndsWith("code:", StringComparison.OrdinalIgnoreCase) Then Return SteamCmdPrompt.Code
        Return SteamCmdPrompt.None
    End Function
End Class

' What SteamCMD is doing, deduced from what it has written
Friend NotInheritable Class SteamCmdStatus
    ' By number of line, the screen is read every time it changes and it can have several results
    Private ReadOnly Results As New SortedDictionary(Of Integer, SteamCmdLine)()
    Private FirstNumber As Integer
    Private ProgressNumber As Integer = -1
    Private Progress As Double
    Private CurrentPrompt As SteamCmdPrompt

    Public ReadOnly Property Prompt As SteamCmdPrompt
        Get
            Return CurrentPrompt
        End Get
    End Property

    ' scrolled are the lines that have left the screen since the last time
    Public Sub Read(terminal As TerminalBuffer, scrolled As List(Of String))
        For i As Integer = 0 To scrolled.Count - 1
            ReadLine(terminal.FirstRow - scrolled.Count + i, scrolled(i))
        Next
        For row As Integer = 0 To terminal.RowCount - 1
            ReadLine(terminal.FirstRow + row, terminal.TextOf(row))
        Next
        CurrentPrompt = SteamCmdLine.PromptOf(terminal.TextOf(terminal.CursorRow))
    End Sub

    Private Sub ReadLine(number As Integer, text As String)
        If number < FirstNumber Then Return
        Dim line As New SteamCmdLine(text)
        If line.Kind = SteamCmdLineKind.Other Then Return
        ' The results of the previous command are valid until there is something new
        If Results.Count > 0 AndAlso Results.Keys.First() < FirstNumber Then Results.Clear()
        Select Case line.Kind
            Case SteamCmdLineKind.Progress
                If number >= ProgressNumber Then
                    ProgressNumber = number
                    Progress = line.Percent
                End If
            Case SteamCmdLineKind.Success, SteamCmdLineKind.Failure
                Results(number) = line
        End Select
    End Sub

    ' Something has been written in the prompt. After a command, only what comes next is read.
    Public Sub InputSent(terminal As TerminalBuffer)
        If CurrentPrompt = SteamCmdPrompt.Command Then FirstNumber = terminal.FirstRow + terminal.CursorRow + 1
        CurrentPrompt = SteamCmdPrompt.None
    End Sub

    ' Without a result of what it's doing now
    Public ReadOnly Property IsWorking As Boolean
        Get
            If CurrentPrompt <> SteamCmdPrompt.None Then Return False
            Return Results.Count = 0 OrElse Results.Keys.Last() < Math.Max(FirstNumber, ProgressNumber)
        End Get
    End Property

    Public ReadOnly Property HasFailed As Boolean
        Get
            Return Results.Values.Any(Function(line) line.Kind = SteamCmdLineKind.Failure)
        End Get
    End Property

    ' Nothing until an install ends. More than one can be installed, the first error is the important one.
    Public ReadOnly Property Result As String
        Get
            If Results.Count = 0 Then Return Nothing
            If HasFailed Then Return Results.Values.First(Function(line) line.Kind = SteamCmdLineKind.Failure).Text
            Return String.Join(" ", Results.Values.Select(Function(line) line.Text).Distinct().ToArray())
        End Get
    End Property

    Public ReadOnly Property Percent As Integer
        Get
            If Results.Count > 0 AndAlso Results.Keys.Last() > ProgressNumber Then Return If(HasFailed, 0, 100)
            Return If(ProgressNumber < 0, 0, CInt(Math.Floor(Progress)))
        End Get
    End Property
End Class

Option Strict On

Imports System.Text

' Turns the output of a pseudoconsole (text and VT sequences) into lines, for a single thread.
' The rows of the screen can still be rewritten, the ones that leave it through the top become the history.
Friend NotInheritable Class TerminalBuffer
    Private Enum State
        Text
        Escape
        Csi
        Charset
        Osc
        OscEscape
    End Enum

    Private Const MaxOsc As Integer = 4096
    Private Const MaxParameters As Integer = 64

    ' Second cell of a wide character
    Private Shared ReadOnly Filler As Char = ChrW(0)

    Private ReadOnly Columns As Integer
    Private ReadOnly Rows As Integer
    Private ReadOnly MaxHistory As Integer
    Private ReadOnly Replaces As Func(Of String, String, Boolean)
    Private ReadOnly Screen As New List(Of StringBuilder)()
    Private ReadOnly History As New List(Of String)()
    Private ReadOnly Parameters As New StringBuilder()
    Private ReadOnly Reply As New StringBuilder()
    Private Scrolled As List(Of String)
    Private Mode As State
    Private OscLength As Integer
    Private Row, Column, SavedRow, SavedColumn As Integer
    Private ScrolledCount, DroppedCount As Integer

    ' replaces(previous, line) is True if the line is a new version of the previous one, and only the last one is kept
    Public Sub New(columns As Integer, rows As Integer, maxHistory As Integer, replaces As Func(Of String, String, Boolean))
        Me.Columns = columns
        Me.Rows = rows
        Me.MaxHistory = maxHistory
        Me.Replaces = replaces
        For i As Integer = 1 To rows
            Screen.Add(New StringBuilder())
        Next
    End Sub

    ' Returns the lines that have left the screen
    Public Function Feed(text As String) As List(Of String)
        Scrolled = New List(Of String)()
        For Each c As Char In text
            Receive(c)
        Next
        Return Scrolled
    End Function

    ' History and screen. FirstLine is the number of the first one, it grows when the old ones are dropped.
    Public Function Lines() As List(Of String)
        Dim result As New List(Of String)(History)
        Dim last As Integer = Rows - 1
        While last > Row AndAlso TextOf(last) = ""
            last -= 1
        End While
        For i As Integer = 0 To last
            AddLine(result, TextOf(i))
        Next
        Return result
    End Function

    Public ReadOnly Property FirstLine As Integer
        Get
            Return DroppedCount
        End Get
    End Property

    Public ReadOnly Property RowCount As Integer
        Get
            Return Rows
        End Get
    End Property

    Public Function TextOf(row As Integer) As String
        Return Screen(row).ToString().Replace(Filler, "").TrimEnd()
    End Function

    ' Number of the first row of the screen, counting everything that has left it
    Public ReadOnly Property FirstRow As Integer
        Get
            Return ScrolledCount
        End Get
    End Property

    Public ReadOnly Property CursorRow As Integer
        Get
            Return Row
        End Get
    End Property

    ' What has to be answered to the pseudoconsole, it can ask for the type of terminal and the position of the cursor
    Public Function TakeReply() As String
        Dim text As String = Reply.ToString()
        Reply.Length = 0
        Return text
    End Function

    Private Sub Receive(c As Char)
        ' CAN and SUB cancel any sequence
        If c = ChrW(24) OrElse c = ChrW(26) Then
            Mode = State.Text
            Return
        End If
        Select Case Mode
            Case State.Text
                If c = ChrW(27) Then Mode = State.Escape Else Put(c)
            Case State.Escape
                StartSequence(c)
            Case State.Charset
                Mode = State.Text
            Case State.Csi
                If c = ChrW(27) Then
                    Mode = State.Escape
                ElseIf c < " "c Then
                    Put(c)
                ElseIf c >= "@"c AndAlso c <= "~"c Then
                    Mode = State.Text
                    Execute(c)
                ElseIf Parameters.Length < MaxParameters Then
                    Parameters.Append(c)
                End If
            Case State.Osc
                OscLength += 1
                If c = ChrW(27) Then
                    Mode = State.OscEscape
                ElseIf c = ChrW(7) OrElse OscLength > MaxOsc Then
                    ' The limit is for one that never ends, it would hide everything that comes later
                    Mode = State.Text
                End If
            Case State.OscEscape
                If c = "\"c Then Mode = State.Text Else StartSequence(c)
        End Select
    End Sub

    Private Sub StartSequence(c As Char)
        Mode = State.Text
        Select Case c
            Case "["c
                Parameters.Length = 0
                Mode = State.Csi
            Case "]"c, "P"c, "X"c, "^"c, "_"c
                OscLength = 0
                Mode = State.Osc
            Case "("c, ")"c, "*"c, "+"c, "#"c, "%"c, " "c
                Mode = State.Charset
            Case ChrW(27)
                Mode = State.Escape
            Case "7"c
                SavedRow = Row
                SavedColumn = Column
            Case "8"c
                Row = SavedRow
                Column = SavedColumn
            Case "D"c
                LineFeed()
            Case "E"c
                Column = 0
                LineFeed()
            Case "M"c
                If Row > 0 Then Row -= 1 Else ScrollDown(0)
        End Select
    End Sub

    Private Sub Put(c As Char)
        Select Case c
            Case ChrW(13)
                Column = 0
            Case ChrW(10), ChrW(11), ChrW(12)
                LineFeed()
            Case ChrW(8)
                If Column > 0 Then Column -= 1
            Case ChrW(9)
                Column = Math.Min(Columns - 1, (Column \ 8 + 1) * 8)
            Case Else
                If Not Char.IsControl(c) Then Write(c)
        End Select
    End Sub

    Private Sub Write(c As Char)
        Dim width As Integer = If(IsWide(c), 2, 1)
        If Column + width > Columns Then
            Column = 0
            LineFeed()
        End If
        Dim line As StringBuilder = Screen(Row)
        Pad(line, Column + width)
        SetCell(line, Column, c)
        If width = 2 Then SetCell(line, Column + 1, Filler)
        Column += width
    End Sub

    Private Shared Sub Pad(line As StringBuilder, length As Integer)
        If line.Length < length Then line.Append(" "c, length - line.Length)
    End Sub

    ' When half of a wide character is overwritten the other half disappears
    Private Shared Sub SetCell(line As StringBuilder, index As Integer, c As Char)
        If c <> Filler AndAlso line(index) = Filler Then line(index - 1) = " "c
        If index + 1 < line.Length AndAlso line(index + 1) = Filler Then line(index + 1) = " "c
        line(index) = c
    End Sub

    ' The East Asian characters that use two cells
    Private Shared Function IsWide(c As Char) As Boolean
        Dim code As Integer = AscW(c)
        Return (code >= &H1100 AndAlso code <= &H115F) OrElse (code >= &H2E80 AndAlso code <= &HA4CF AndAlso code <> &H303F) OrElse
            (code >= &HAC00 AndAlso code <= &HD7A3) OrElse (code >= &HF900 AndAlso code <= &HFAFF) OrElse
            (code >= &HFE30 AndAlso code <= &HFE6F) OrElse (code >= &HFF00 AndAlso code <= &HFF60) OrElse (code >= &HFFE0 AndAlso code <= &HFFE6)
    End Function

    Private Sub LineFeed()
        If Row < Rows - 1 Then Row += 1 Else ScrollUp()
    End Sub

    Private Sub ScrollUp()
        Dim line As String = TextOf(0)
        Scrolled.Add(line)
        ScrolledCount += 1
        AddLine(History, line)
        DeleteRow(0)
        ' The oldest ones are dropped in blocks, all the text has to be painted again each time
        If History.Count >= MaxHistory + MaxHistory \ 4 Then
            Dim excess As Integer = History.Count - MaxHistory
            History.RemoveRange(0, excess)
            DroppedCount += excess
        End If
    End Sub

    Private Sub ScrollDown(fromRow As Integer)
        Dim line As StringBuilder = Screen(Rows - 1)
        Screen.RemoveAt(Rows - 1)
        line.Length = 0
        Screen.Insert(fromRow, line)
    End Sub

    Private Sub DeleteRow(index As Integer)
        Dim line As StringBuilder = Screen(index)
        Screen.RemoveAt(index)
        line.Length = 0
        Screen.Add(line)
    End Sub

    Private Sub AddLine(list As List(Of String), line As String)
        If list.Count > 0 AndAlso Replaces IsNot Nothing AndAlso Replaces(list(list.Count - 1), line) Then
            list(list.Count - 1) = line
        Else
            list.Add(line)
        End If
    End Sub

    Private Function Parameter(index As Integer, missing As Integer) As Integer
        Dim parts As String() = Parameters.ToString().Split(";"c)
        Dim value As Integer
        If index < parts.Length AndAlso Integer.TryParse(parts(index), value) AndAlso value > 0 Then Return value
        Return missing
    End Function

    Private Function RowLimit(value As Integer) As Integer
        Return Math.Max(0, Math.Min(Rows - 1, value))
    End Function

    Private Function ColumnLimit(value As Integer) As Integer
        Return Math.Max(0, Math.Min(Columns - 1, value))
    End Function

    Private Sub Execute(command As Char)
        ' Private modes and others with special characters (ESC [ ? 25 l) don't change the text
        For i As Integer = 0 To Parameters.Length - 1
            If Not (Parameters(i) >= "0"c AndAlso Parameters(i) <= "9"c) AndAlso Parameters(i) <> ";"c Then Return
        Next
        ' Never bigger than the screen, the rest of the number wouldn't change anything
        Dim count As Integer = Math.Min(Parameter(0, 1), Math.Max(Rows, Columns))
        Select Case command
            Case "A"c
                Row = RowLimit(Row - count)
            Case "B"c
                Row = RowLimit(Row + count)
            Case "C"c
                Column = ColumnLimit(Column + count)
            Case "D"c
                Column = ColumnLimit(Column - count)
            Case "E"c
                Row = RowLimit(Row + count)
                Column = 0
            Case "F"c
                Row = RowLimit(Row - count)
                Column = 0
            Case "G"c
                Column = ColumnLimit(count - 1)
            Case "H"c, "f"c
                Row = RowLimit(count - 1)
                Column = ColumnLimit(Parameter(1, 1) - 1)
            Case "d"c
                Row = RowLimit(count - 1)
            Case "J"c
                EraseScreen(Parameter(0, 0))
            Case "K"c
                EraseLine(Screen(Row), Parameter(0, 0))
            Case "L"c
                For i As Integer = 1 To Math.Min(count, Rows - Row)
                    ScrollDown(Row)
                Next
            Case "M"c
                For i As Integer = 1 To Math.Min(count, Rows - Row)
                    DeleteRow(Row)
                Next
            Case "S"c
                For i As Integer = 1 To Math.Min(count, Rows)
                    ScrollUp()
                Next
            Case "T"c
                For i As Integer = 1 To Math.Min(count, Rows)
                    ScrollDown(0)
                Next
            Case "X"c
                EraseCells(Screen(Row), Column, Column + count)
            Case "s"c
                SavedRow = Row
                SavedColumn = Column
            Case "u"c
                Row = SavedRow
                Column = SavedColumn
            Case "c"c
                Reply.Append(ChrW(27) & "[?1;0c")
            Case "n"c
                If Parameter(0, 0) = 5 Then Reply.Append(ChrW(27) & "[0n")
                If Parameter(0, 0) = 6 Then Reply.Append(ChrW(27) & "[" & (Row + 1) & ";" & (ColumnLimit(Column) + 1) & "R")
        End Select
    End Sub

    Private Shared Sub EraseCells(line As StringBuilder, first As Integer, last As Integer)
        For i As Integer = first To Math.Min(line.Length, last) - 1
            SetCell(line, i, " "c)
        Next
    End Sub

    Private Sub EraseLine(line As StringBuilder, mode As Integer)
        Select Case mode
            Case 0
                EraseCells(line, Column, line.Length)
            Case 1
                EraseCells(line, 0, Column + 1)
            Case 2
                line.Length = 0
        End Select
    End Sub

    Private Sub EraseScreen(mode As Integer)
        If mode > 2 Then Return ' 3 is the history
        For i As Integer = 0 To Rows - 1
            If i = Row Then
                EraseLine(Screen(i), mode)
            ElseIf mode = 2 OrElse (mode = 0) = (i > Row) Then
                Screen(i).Length = 0
            End If
        Next
    End Sub
End Class

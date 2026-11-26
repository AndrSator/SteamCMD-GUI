Option Strict On

Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

' The lines that are in a text box and the smallest change that updates them, without the text box
Friend NotInheritable Class ConsoleText
    Private ReadOnly Shown As New List(Of String)()
    Private Prefix As Integer
    Private FirstNumber As Integer
    Private LastNumber As Integer ' The one of the last line in the previous update

    ' Characters that the text box has if nobody else has changed it
    Public Length As Integer

    ' Someone else has changed the text, to clear it for example. Their text stays above and the lines that were
    ' complete aren't shown again, only the last one, that could still be changing, and the new ones.
    Private Sub Detach(boxLength As Integer)
        Shown.Clear()
        Prefix = boxLength
        FirstNumber = LastNumber
    End Sub

    ' number is the one of the first line and boxLength what the text box has now. Returns the position of the text
    ' to replace, up to the end, with the new text. Returns -1 if nothing has changed.
    Public Function Update(lines As List(Of String), number As Integer, boxLength As Integer, ByRef newText As String) As Integer
        If boxLength <> Length Then Detach(boxLength)
        LastNumber = number + lines.Count - 1
        Dim skipped As Integer = Math.Max(0, FirstNumber - number)
        Dim count As Integer = Math.Max(0, lines.Count - skipped)

        Dim same As Integer = 0
        Dim position As Integer = Prefix ' End of the last line that doesn't change
        While same < count AndAlso same < Shown.Count AndAlso Shown(same) = lines(skipped + same)
            position += Shown(same).Length + If(position > 0 OrElse same > 0, 1, 0)
            same += 1
        End While
        If same = count AndAlso same = Shown.Count Then
            Length = boxLength
            Return -1
        End If

        Dim text As New StringBuilder()
        For i As Integer = same To count - 1
            If i > 0 OrElse Prefix > 0 Then text.Append(ChrW(10))
            text.Append(lines(skipped + i))
        Next
        newText = text.ToString()
        Shown.RemoveRange(same, Shown.Count - same)
        Shown.AddRange(lines.GetRange(skipped + same, count - same))
        Length = position + newText.Length
        Return position
    End Function
End Class

' Shows a TerminalBuffer in a RichTextBox
Friend NotInheritable Class ConsoleView
    Private Const WM_SETREDRAW As Integer = &HB
    Private Const EM_LINESCROLL As Integer = &HB6
    Private Const EM_REPLACESEL As Integer = &HC2
    Private Const EM_GETFIRSTVISIBLELINE As Integer = &HCE
    Private Const EM_POSFROMCHAR As Integer = &HD6
    Private Const WM_VSCROLL As Integer = &H115
    Private Const SB_BOTTOM As Integer = 7

    Private ReadOnly Box As RichTextBox
    Private ReadOnly Terminal As TerminalBuffer
    Private ReadOnly Text As New ConsoleText()

    Public Sub New(box As RichTextBox, terminal As TerminalBuffer)
        Me.Box = box
        Me.Terminal = terminal
        box.Clear()
    End Sub

    Public Sub Render()
        Dim lines As List(Of String) = Terminal.Lines()
        Dim newText As String = Nothing
        Dim start As Integer = Text.Update(lines, Terminal.FirstLine, Box.TextLength, newText)
        If start < 0 Then Return

        ' It follows the output, unless it has been scrolled or there is something selected
        Dim selected As Integer = Box.SelectionStart
        Dim selectedLength As Integer = Box.SelectionLength
        Dim follow As Boolean = selectedLength = 0 AndAlso EndIsVisible()
        Dim firstLine As Integer = Send(EM_GETFIRSTVISIBLELINE, 0)
        Send(WM_SETREDRAW, 0)
        Try
            Box.Select(start, Box.TextLength - start)
            ' SelectedText = "" sends WM_CLEAR, that only beeps when the text box is read-only
            SendText(Box.Handle, EM_REPLACESEL, IntPtr.Zero, newText)
            ' What the text box counts, if it differs every change would look like one made by others
            Text.Length = Box.TextLength
            If follow Then
                Box.Select(Text.Length, 0)
                Send(WM_VSCROLL, SB_BOTTOM)
            Else
                Box.Select(Math.Min(selected, Text.Length), Math.Min(selectedLength, Math.Max(0, Text.Length - selected)))
                Send(EM_LINESCROLL, 0, firstLine - Send(EM_GETFIRSTVISIBLELINE, 0))
            End If
        Finally
            Send(WM_SETREDRAW, 1)
            Box.Invalidate()
        End Try
    End Sub

    Private Function EndIsVisible() As Boolean
        Dim position As NativePoint
        SendPoint(Box.Handle, EM_POSFROMCHAR, position, New IntPtr(Box.TextLength))
        Return position.Y < Box.ClientSize.Height
    End Function

    Private Function Send(message As Integer, wParam As Integer, Optional lParam As Integer = 0) As Integer
        Return SendMessage(Box.Handle, message, New IntPtr(wParam), New IntPtr(lParam)).ToInt32()
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Private Structure NativePoint
        Public X, Y As Integer
    End Structure

    <DllImport("user32.dll", EntryPoint:="SendMessageW")>
    Private Shared Function SendMessage(window As IntPtr, message As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="SendMessageW", CharSet:=CharSet.Unicode)>
    Private Shared Function SendText(window As IntPtr, message As Integer, wParam As IntPtr, lParam As String) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="SendMessageW")>
    Private Shared Function SendPoint(window As IntPtr, message As Integer, ByRef point As NativePoint, lParam As IntPtr) As IntPtr
    End Function
End Class

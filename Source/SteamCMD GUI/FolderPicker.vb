Option Strict On

Imports System.IO
Imports System.Runtime.InteropServices

' Folder selection with the Windows Explorer dialog, FolderBrowserDialog only has the old tree
Friend NotInheritable Class FolderPicker
    Private Const PickFolders As UInteger = &H20UI
    Private Const ForceFileSystem As UInteger = &H40UI
    Private Const FileSystemPath As UInteger = &H80058000UI
    Private Const Cancelled As Integer = &H800704C7

    Private Sub New()
    End Sub

    ' Returns Nothing if the dialog is cancelled
    Public Shared Function Show(owner As IntPtr, title As String, startFolder As String) As String
        Dim dialog As IFileDialog = CType(Activator.CreateInstance(Type.GetTypeFromCLSID(New Guid("DC1C5A9C-E88A-4DDE-A5A1-60F82A20AEF7"))), IFileDialog)
        Try
            Dim options As UInteger
            dialog.GetOptions(options)
            dialog.SetOptions(options Or PickFolders Or ForceFileSystem)
            dialog.SetTitle(title)
            Dim item As IShellItem = Nothing
            If startFolder IsNot Nothing AndAlso SHCreateItemFromParsingName(startFolder, IntPtr.Zero, GetType(IShellItem).GUID, item) = 0 Then
                dialog.SetFolder(item)
            End If

            Dim result As Integer = dialog.Show(owner)
            If result = Cancelled Then Return Nothing
            Marshal.ThrowExceptionForHR(result)

            dialog.GetResult(item)
            Dim path As String = Nothing
            item.GetDisplayName(FileSystemPath, path)
            Return path
        Finally
            Marshal.ReleaseComObject(dialog)
        End Try
    End Function

    Public Shared Function FirstExisting(ParamArray folders() As String) As String
        For Each folder As String In folders
            If Directory.Exists(folder) Then Return folder
        Next
        Return Nothing
    End Function

    <DllImport("shell32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SHCreateItemFromParsingName(path As String, context As IntPtr, <MarshalAs(UnmanagedType.LPStruct)> id As Guid, ByRef item As IShellItem) As Integer
    End Function

    ' The methods have to be in the order of shobjidl.h, even the ones that are not used
    <ComImport(), Guid("42F85136-DB7E-439C-85F1-E4075D135FC8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IFileDialog
        <PreserveSig()> Function Show(owner As IntPtr) As Integer
        Sub SetFileTypes(count As UInteger, types As IntPtr)
        Sub SetFileTypeIndex(index As UInteger)
        Sub GetFileTypeIndex(ByRef index As UInteger)
        Sub Advise(events As IntPtr, ByRef cookie As UInteger)
        Sub Unadvise(cookie As UInteger)
        Sub SetOptions(options As UInteger)
        Sub GetOptions(ByRef options As UInteger)
        Sub SetDefaultFolder(item As IShellItem)
        Sub SetFolder(item As IShellItem)
        Sub GetFolder(ByRef item As IShellItem)
        Sub GetCurrentSelection(ByRef item As IShellItem)
        Sub SetFileName(<MarshalAs(UnmanagedType.LPWStr)> name As String)
        Sub GetFileName(<MarshalAs(UnmanagedType.LPWStr)> ByRef name As String)
        Sub SetTitle(<MarshalAs(UnmanagedType.LPWStr)> title As String)
        Sub SetOkButtonLabel(<MarshalAs(UnmanagedType.LPWStr)> text As String)
        Sub SetFileNameLabel(<MarshalAs(UnmanagedType.LPWStr)> text As String)
        Sub GetResult(ByRef item As IShellItem)
    End Interface

    <ComImport(), Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IShellItem
        Sub BindToHandler(context As IntPtr, ByRef handler As Guid, ByRef id As Guid, ByRef result As IntPtr)
        Sub GetParent(ByRef item As IShellItem)
        Sub GetDisplayName(form As UInteger, <MarshalAs(UnmanagedType.LPWStr)> ByRef name As String)
    End Interface
End Class

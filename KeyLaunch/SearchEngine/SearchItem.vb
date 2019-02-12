Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Security.Permissions
Imports System.Text

<Serializable()>
Public Class SearchItem
    Public Enum ItemTypeConstants
        SearchItem = 0
        Category = 1
    End Enum

    Private mFileInfo As IO.FileInfo
    Private mName As String
    Private mType As ItemTypeConstants
    Private mIcon As Icon
    Private mLinkedFileInfo As IO.FileInfo
    Private mIsLink As Boolean

    'Private Declare Function ExtractIconEx Lib "shell32.dll" Alias "ExtractIconExA" (ByVal lpszFile As String, ByVal nIconIndex As Integer, ByVal phiconLarge As Integer, ByVal phiconSmall As Integer, ByVal nIcons As Long) As Integer

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Private Structure SHFILEINFO
        Public hIcon As IntPtr ' : icon
        Public iIcon As Integer ' : icondex
        Public dwAttributes As Integer ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public szTypeName As String
    End Structure

    Private Declare Ansi Function SHGetFileInfo Lib "shell32.dll" (ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As IntPtr
    Private Const SHGFI_ICON As Integer = &H100
    Private Const SHGFI_SMALLICON As Integer = &H1
    Private Const SHGFI_LARGEICON As Integer = &H0 ' Large icon

    Private ReadOnly CLSID_ShellLink As Guid = New Guid("00021401-0000-0000-C000-000000000046")
    Private Const INFOTIPSIZE As Integer = 1024

    Public Sub New(ByVal newItemType As ItemTypeConstants)
        mType = newItemType
    End Sub

    Public Sub New(ByVal fileInfo As IO.FileInfo)
        Me.New(ItemTypeConstants.SearchItem)
        Me.FileInfo = fileInfo

        mIcon = GetItemIcon
    End Sub

    Public Sub New(ByVal categoryName As String)
        Me.New(ItemTypeConstants.Category)
        mName = categoryName
    End Sub

    Private Sub HandleLinks()
        mIsLink = (mFileInfo.Extension.ToLower = ".lnk")
        If mIsLink Then mLinkedFileInfo = Me.ResolveLink
    End Sub

    Public ReadOnly Property Exists() As Boolean
        Get
            Return IO.File.Exists(mFileInfo.FullName)
        End Get
    End Property

    Public Property FileInfo() As IO.FileInfo
        Get
            Return mFileInfo
        End Get
        Protected Set(ByVal value As IO.FileInfo)
            mFileInfo = value
            mName = mFileInfo.Name

            HandleLinks()
        End Set
    End Property

    Public ReadOnly Property LinkedFileInfo() As IO.FileInfo
        Get
            Return mLinkedFileInfo
        End Get
    End Property

    Public Property Name(Optional ByVal IncludeExtension As Boolean = True) As String
        Get
            If IncludeExtension Then
                Return mName
            Else
                Dim fExt As String = mFileInfo.Extension
                If fExt <> "" Then
                    Return mName.Replace(fExt, "")
                Else
                    Return mName
                End If
            End If
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property

    Public ReadOnly Property ItemType() As ItemTypeConstants
        Get
            Return mType
        End Get
    End Property

    Public ReadOnly Property ItemIcon() As Icon
        Get
            Return mIcon
        End Get
    End Property

    Public ReadOnly Property IsLink() As Boolean
        Get
            Return mIsLink
        End Get
    End Property

    Private ReadOnly Property GetItemIcon() As Icon
        Get
            Return SearchItem.GetIconFromFile(mFileInfo.FullName)
        End Get
    End Property

    Public Shared Function GetIconFromFile(ByVal fileName As String, Optional ByVal index As Integer = 0, Optional ByVal extractSmallIcon As Boolean = True) As Icon
        Dim hImgSmall As IntPtr
        Dim hImgLarge As IntPtr
        Dim shinfo As SHFILEINFO = New SHFILEINFO()

        fileName = fileName.Replace("""", "")
        If fileName.Contains(",") Then
            If Integer.TryParse(fileName.Split(CChar(","))(1), index) Then
                fileName = fileName.Split(CChar(","))(0)
            End If
        End If

        If IO.File.Exists(fileName) OrElse IO.Directory.Exists(fileName) Then
            shinfo.szDisplayName = New String(Chr(0), 260)
            shinfo.szTypeName = New String(Chr(0), 80)
            shinfo.iIcon = index

            If extractSmallIcon Then
                hImgSmall = SHGetFileInfo(fileName, 0, shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON Or SHGFI_SMALLICON)
            Else
                hImgLarge = SHGetFileInfo(fileName, 0, shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON Or SHGFI_LARGEICON)
            End If
            If shinfo.hIcon.ToInt32 = 0 Then
                Return Nothing
            Else
                Return Icon.FromHandle(shinfo.hIcon)
            End If
        End If

        Return Nothing
    End Function

    Public Function ResolveLink() As IO.FileInfo
        Dim mShellLink As ShellLink = New ShellLink()
        Dim linkPath As String = mShellLink.GetLinkedPath(mFileInfo.FullName)
        mShellLink = Nothing

        If IO.File.Exists(linkPath) Then
            Return New IO.FileInfo(linkPath)
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function ResolveLink(ByVal file As IO.FileInfo) As String
        Dim mShellLink As ShellLink = New ShellLink()
        Dim linkPath As String = mShellLink.GetLinkedPath(file.FullName)
        mShellLink = Nothing

        If IO.File.Exists(linkPath) Then
            Return linkPath
        Else
            Return ""
        End If
    End Function

    Protected Overrides Sub Finalize()
        If mType = ItemTypeConstants.SearchItem AndAlso mIcon IsNot Nothing Then mIcon.Dispose()
        MyBase.Finalize()
    End Sub

    Public Shared Operator =(ByVal si1 As SearchItem, ByVal si2 As SearchItem) As Boolean
        Select Case si1.ItemType
            Case ItemTypeConstants.Category
                Return (si2.ItemType = ItemTypeConstants.Category) AndAlso (si1.Name = si2.Name)
            Case ItemTypeConstants.SearchItem
                Return (si2.ItemType = ItemTypeConstants.SearchItem) AndAlso (si1.FileInfo.FullName = si2.FileInfo.FullName)
        End Select
    End Operator

    Public Shared Operator <>(ByVal si1 As SearchItem, ByVal si2 As SearchItem) As Boolean
        Return Not (si1 = si2)
    End Operator
End Class

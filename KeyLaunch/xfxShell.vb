Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions
Imports System.Text

''' <summary>
''' Represents a shell link object. In general, a shell link is a pointer to
''' a file or non-file object in the shell namespace. However, this
''' implementation dies not support non-file objects.
''' </summary>
Public Class ShellLink
    ''' <summary>
    ''' Shell link object's identifier.
    ''' </summary>
    Private shellLinkType As Type = Type.GetTypeFromCLSID(New Guid(&H21401, 0, 0, &HC0, 0, 0, 0, 0, 0, 0, &H46))
    Private slObject As Object = Activator.CreateInstance(shellLinkType)
    Private shellLinkW As IShellLinkW = CType(slObject, IShellLinkW)
    Private shellLinkA As IShellLinkA = CType(slObject, IShellLinkA)

    ''' <summary>
    ''' Represents SW_xxx constants that apply to shell links.
    ''' </summary>
    ''' <remarks>
    ''' See Platform SDK for full list of possible SW_xxx values.
    ''' </remarks>
    Public Enum ShowCommandConstants
        ''' <summary>
        ''' Maps to SW_SHOWNORMAL. The main application window opens in
        ''' normal state.
        ''' </summary>
        ShowNormal = 1

        ''' <summary>
        ''' Maps to SW_SHOWMAXIMIZED. The main application windows opens
        ''' maximized.
        ''' </summary>
        ShowMaximized = 3

        ''' <summary>
        ''' Maps to SW_SHOWMINNOACTIVE. The main application window opens
        ''' minimized and doesn't get activated. Usefull for running
        ''' background processes.
        ''' </summary>
        ShowMinimized = 7
    End Enum

    Private mArguments As String = String.Empty
    ''' <summary>
    ''' The command-line arguments associated with a shell link object.
    ''' </summary>
    ''' <value>
    ''' The command-line arguments string.
    ''' </value>
    Public Property Arguments() As String
        Get
            Return mArguments
        End Get
        Set(ByVal value As String)
            mArguments = value
        End Set
    End Property

    Private mDescription As String = String.Empty
    ''' <summary>
    ''' The description for a shell link object. The description can be
    ''' any user-defined string.
    ''' </summary>
    ''' <value>
    ''' The description string.
    ''' </value>
    Public Property Description() As String
        Get
            Return mDescription
        End Get

        Set(ByVal value As String)
            mDescription = value
        End Set
    End Property

    Private mHotkey As Short
    ''' <summary>
    ''' The hot key for a shell link object.
    ''' </summary>
    ''' <value>
    ''' The hot key value.
    ''' </value>
    ''' <remarks>
    ''' <para>The virtual key code is in the low-order byte, and the
    ''' modifier flags are in the high-order byte.</para>
    ''' <para>For more information see Platform SDK information on subject
    ''' <c>IShellLink::GetHotKey</c>.</para>
    ''' </remarks>
    Public Property Hotkey() As Short
        Get
            Return mHotkey
        End Get
        Set(ByVal value As Short)
            mHotkey = value
        End Set
    End Property

    Private mIconPath As String = String.Empty
    ''' <summary>
    ''' The path of the file containing the icon for a shell link object.
    ''' </summary>
    ''' <value>
    ''' The path to the icon file.
    ''' </value>
    Public Property IconPath() As String
        Get
            Return mIconPath
        End Get
        Set(ByVal value As String)
            mIconPath = value
        End Set
    End Property

    Private mIconIndex As Integer
    ''' <summary>
    ''' The index of the icon for the shell object.
    ''' </summary>
    ''' <value>
    ''' The index of the icon.
    ''' </value>
    Public Property IconIndex() As Integer
        Get
            Return mIconIndex
        End Get
        Set(ByVal value As Integer)
            mIconIndex = value
        End Set
    End Property

    Private mPath As String = String.Empty
    ''' <summary>
    ''' The path and file name of a shell link object.
    ''' </summary>
    ''' <value>
    ''' The path and file name of the shell link object.
    ''' </value>
    Public Property Path() As String
        Get
            Return mPath
        End Get
        Set(ByVal value As String)
            mPath = value
        End Set
    End Property

    Private mShowCmd As ShowCommandConstants = ShowCommandConstants.ShowNormal
    ''' <summary>
    ''' The show command for a shell link object.
    ''' </summary>
    ''' <value>
    ''' A <see cref="ShowCommand"/> value.
    ''' </value>
    Public Property ShowCommand() As ShowCommandConstants
        Get
            Return mShowCmd
        End Get
        Set(ByVal value As ShowCommandConstants)
            mShowCmd = value
        End Set
    End Property

    Private mWorkingDirectory As String = String.Empty
    ''' <summary>
    ''' The name of the working directory for a shell link object.
    ''' </summary>
    ''' <value>
    ''' The name of the working directory.
    ''' </value>
    Public Property WorkingDirectory() As String
        Get
            Return mWorkingDirectory
        End Get
        Set(ByVal value As String)
            mWorkingDirectory = value
        End Set
    End Property

    Private Sub ThrowInvalidComObjectException()
        Throw New InvalidComObjectException("No shell link interfaces supported by the shell link object")
    End Sub

    ''' <summary>
    ''' Loads a shell link from the specified file and initializes
    ''' the object from the file contents.
    ''' </summary>
    ''' <param name="linkFileName">
    ''' The absolute path of the file to open.
    ''' </param>
    ''' <exception cref="FileNotFoundException">
    ''' No link file found.
    ''' </exception>
    ''' <exception cref="InvalidComObjectException">
    ''' The shell link COM object does not support required interfaces
    ''' Windows corrupt?
    ''' </exception>
    ''' <exception cref="SecurityException">
    ''' Either the calls to unmanaged code are restricted or the shell link
    ''' file cannot be read.
    ''' </exception>
    <SecurityPermission(SecurityAction.Demand, UnmanagedCode:=True)> _
    Public Sub Load(ByVal linkFileName As String)
        'If linkFileName = "" Then
        '    Throw New ArgumentNullException("linkFileName", "The name of the link file cannot be null")
        'End If
        'If Not File.Exists(linkFileName) Then
        '    Throw New FileNotFoundException("Link not found", linkFileName)
        'End If
        Dim ioPerm As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.Read Or FileIOPermissionAccess.PathDiscovery, linkFileName)
        ioPerm.Demand()

        Dim sl As Object = Nothing
        Try
            sl = Activator.CreateInstance(shellLinkType)
            Dim pf As IPersistFile = CType(sl, IPersistFile)
            pf.Load(linkFileName, 0)

            Dim showCmd As Integer
            Dim builder As StringBuilder = New StringBuilder(INFOTIPSIZE)
            Dim shellLinkW As IShellLinkW = CType(sl, IShellLinkW)
            If shellLinkW Is Nothing Then
                Dim shellLinkA As IShellLinkA = CType(sl, IShellLinkA)
                If shellLinkA Is Nothing Then ThrowInvalidComObjectException()
                shellLinkA.GetArguments(builder, builder.Capacity)
                mArguments = builder.ToString()
                shellLinkA.GetDescription(builder, builder.Capacity)
                mDescription = builder.ToString()
                shellLinkA.GetHotkey(mHotkey)
                shellLinkA.GetIconLocation(builder, builder.Capacity, mIconIndex)
                mIconPath = builder.ToString()
                Dim wfd As Win32FindDataA = New Win32FindDataA
                shellLinkA.GetPath(builder, builder.Capacity, wfd, SLGP_UNCPRIORITY)
                mPath = builder.ToString()
                shellLinkA.GetShowCmd(showCmd)
                shellLinkA.GetWorkingDirectory(builder, builder.Capacity)
                mWorkingDirectory = builder.ToString()
            Else
                shellLinkW.GetArguments(builder, builder.Capacity)
                mArguments = builder.ToString()
                shellLinkW.GetDescription(builder, builder.Capacity)
                mDescription = builder.ToString()
                shellLinkW.GetHotkey(mHotkey)
                shellLinkW.GetIconLocation(builder, builder.Capacity, mIconIndex)
                mIconPath = builder.ToString()
                Dim wfd As Win32FindDataW = New Win32FindDataW
                shellLinkW.GetPath(builder, builder.Capacity, wfd, SLGP_UNCPRIORITY)
                mPath = builder.ToString()
                shellLinkW.GetShowCmd(showCmd)
                shellLinkW.GetWorkingDirectory(builder, builder.Capacity)
                mWorkingDirectory = builder.ToString()
            End If
            mShowCmd = CType(showCmd, ShowCommandConstants)
        Finally
            If sl IsNot Nothing Then Marshal.ReleaseComObject(sl)
            ' This object is not eligible for the garbage collection during this method call
            GC.KeepAlive(Me)
        End Try
    End Sub

    Public Function GetLinkedPath(ByVal linkFileName As String) As String
        Dim linkedFilePath As String = ""
        Dim ioPerm As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.Read Or FileIOPermissionAccess.PathDiscovery, linkFileName)
        ioPerm.Demand()

        Try
            Dim pf As IPersistFile = CType(slObject, IPersistFile)
            pf.Load(linkFileName, 0)

            Dim builder As StringBuilder = New StringBuilder(INFOTIPSIZE)
            If shellLinkW Is Nothing Then
                If shellLinkA IsNot Nothing Then
                    shellLinkA.GetPath(builder, builder.Capacity, (New Win32FindDataA), SLGP_UNCPRIORITY)
                    linkedFilePath = builder.ToString()
                End If
            Else
                shellLinkW.GetPath(builder, builder.Capacity, (New Win32FindDataW), SLGP_UNCPRIORITY)
                linkedFilePath = builder.ToString()
            End If
        Catch
        Finally
            'If slObject IsNot Nothing Then Marshal.ReleaseComObject(slObject)
            ' This object is not eligible for the garbage collection during this method call
            'GC.KeepAlive(Me)
        End Try

        Return linkedFilePath
    End Function

    ''' <summary>
    ''' Saves a shell link into the specified file.
    ''' </summary>
    ''' <param name="linkFileName">
    ''' The absolute path of the file to which the object should be saved.
    ''' Note that the file should have the extension .LNK or else the shell
    ''' would not recognize it as a link.
    ''' </param>
    ''' <exception cref="InvalidComObjectException">
    ''' The shell link COM object does not support required interfaces
    ''' Windows corrupt?
    ''' </exception>
    ''' <exception cref="SecurityException">
    ''' Either the calls to unmanaged code are restricted or the shell link
    ''' file cannot be read.
    ''' </exception>
    <SecurityPermission(SecurityAction.Demand, UnmanagedCode:=True)> _
    Public Sub Save(ByVal linkFileName As String)
        If linkFileName = "" Then
            Throw New ArgumentNullException("linkFileName", "The name of the link file cannot be null")
        End If
        Dim ioPerm As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.Write Or FileIOPermissionAccess.PathDiscovery, linkFileName)
        ioPerm.Demand()

        Dim showCmd As Integer = CInt(mShowCmd)
        Dim sl As Object = Nothing
        Try
            sl = Activator.CreateInstance(shellLinkType)
            Dim shellLinkW As IShellLinkW = CType(sl, IShellLinkW)
            If shellLinkW Is Nothing Then
                Dim shellLinkA As IShellLinkA = CType(sl, IShellLinkA)
                If shellLinkA Is Nothing Then ThrowInvalidComObjectException()
                shellLinkA.SetArguments(mArguments)
                shellLinkA.SetDescription(mDescription)
                shellLinkA.SetHotkey(mHotkey)
                shellLinkA.SetIconLocation(mIconPath, mIconIndex)
                shellLinkA.SetPath(mPath)
                shellLinkA.SetShowCmd(showCmd)
                shellLinkA.SetWorkingDirectory(mWorkingDirectory)
            Else
                shellLinkW.SetArguments(mArguments)
                shellLinkW.SetDescription(mDescription)
                shellLinkW.SetHotkey(mHotkey)
                shellLinkW.SetIconLocation(mIconPath, mIconIndex)
                shellLinkW.SetPath(mPath)
                shellLinkW.SetShowCmd(showCmd)
                shellLinkW.SetWorkingDirectory(mWorkingDirectory)
            End If

            Dim pf As IPersistFile = CType(sl, IPersistFile)
            pf.Save(linkFileName, True)
        Finally
            If sl IsNot Nothing Then
                Marshal.ReleaseComObject(sl)
            End If
        End Try
        ' This object is not eligible for the garbage collection during this method call
        GC.KeepAlive(Me)
    End Sub

    ''' <summary>
    ''' Checks if a file is a shell link.
    ''' </summary>
    ''' <param name="filePath">The name of the file to check.</param>
    ''' <returns><c>true</c> if file is a shell link <c>false</c>
    ''' otherwise.</returns>
    <SecurityPermission(SecurityAction.Demand, UnmanagedCode:=True)> _
    Public Shared Function IsShellLink(ByVal filePath As String) As Boolean
        If filePath Is Nothing Then
            Throw New ArgumentNullException("filePath", "A name of the file cannot be null")
        End If
        If Not File.Exists(filePath) Then
            Throw New FileNotFoundException("Cannot check file that doesn't exist", filePath)
        End If

        Dim ioPerm As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.Read Or FileIOPermissionAccess.PathDiscovery, filePath)
        ioPerm.Demand()

        Dim sfi As SHFileInfo = New SHFileInfo()
        SHGetFileInfo(filePath, 0, sfi, Marshal.SizeOf(sfi), SHGFI_ATTRIBUTES)
        Return (SFGAO_LINK = (sfi.Attributes And SFGAO_LINK))
    End Function

#Region "Native Declarations"
    Private Const INFOTIPSIZE As Integer = 1024
    Private Const SLGP_UNCPRIORITY As Integer = &H2
    Private Const SLGP_RAWPATH As Integer = &H4
    Private Const SLR_INVOKE_MSI As Integer = &H80
    Private Const SLR_UPDATE As Integer = &H8
    Private Const SFGAO_LINK As Integer = &H10000
    Private Const SHGFI_ATTRIBUTES As Integer = &H800

    <StructLayoutAttribute(LayoutKind.Sequential)> _
    Private Structure SHFileInfo
        Private hIcon As IntPtr
        Private iIcon As IntPtr
        Private dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Private szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Private szTypeName As String

        Friend Property Attributes() As Integer
            Get
                Return dwAttributes
            End Get
            Set(ByVal value As Integer)
                dwAttributes = value
            End Set
        End Property
    End Structure

    <StructLayoutAttribute(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Private Structure Win32FindDataA
        Private dwFileAttributes As System.UInt32
        Private ftCreationTime As ComTypes.FILETIME
        Private ftLastAccessTime As ComTypes.FILETIME
        Private ftLastWriteTime As ComTypes.FILETIME
        Private nFileSizeHigh As System.UInt32
        Private nFileSizeLow As System.UInt32
        Private dwReserved0 As System.UInt32
        Private dwReserved1 As System.UInt32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Private cFileName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> Private cAlternateFileName As String
    End Structure

    <StructLayoutAttribute(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure Win32FindDataW
        Private dwFileAttributes As System.UInt32
        Private ftCreationTime As ComTypes.FILETIME
        Private ftLastAccessTime As ComTypes.FILETIME
        Private ftLastWriteTime As ComTypes.FILETIME
        Private nFileSizeHigh As System.UInt32
        Private nFileSizeLow As System.UInt32
        Private dwReserved0 As System.UInt32
        Private dwReserved1 As System.UInt32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Private cFileName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> Private cAlternateFileName As String
    End Structure

    <ComImport()> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    <Guid("0000010B-0000-0000-C000-000000000046")> _
    Private Interface IPersistFile
        <PreserveSig()> Function GetClassID(ByRef pClassID As Guid) As Integer
        <PreserveSig()> Function IsDirty() As Integer
        Sub Load(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszFileName As String, ByVal dwMode As Integer)
        Sub Save(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszFileName As String, ByVal fRemember As Boolean)
        Sub SaveCompleted(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszFileName As String)
        Sub GetCurFile(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal ppszFileName As String)
    End Interface

    <ComImport()> _
<InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
<Guid("000214EE-0000-0000-C000-000000000046")> _
    Private Interface IShellLinkA
        Sub GetPath(<Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszFile As StringBuilder, ByVal cchMaxPath As Integer, ByVal pfd As Win32FindDataA, ByVal fFlags As Integer)
        Sub GetIDList(ByRef ppidl As IntPtr)
        Sub SetIDList(ByVal pidl As IntPtr)
        Sub GetDescription(<Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszName As StringBuilder, ByVal cchMaxName As Integer)
        Sub SetDescription(<MarshalAs(UnmanagedType.LPStr)> ByVal pszName As String)
        Sub GetWorkingDirectory(<Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszDir As StringBuilder, ByVal cchMaxPath As Integer)
        Sub SetWorkingDirectory(<MarshalAs(UnmanagedType.LPStr)> ByVal pszDir As String)
        Sub GetArguments(<Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszArgs As StringBuilder, ByVal cchMaxPath As Integer)
        Sub SetArguments(<MarshalAs(UnmanagedType.LPStr)> ByVal pszArgs As String)
        Sub GetHotkey(ByRef pwHotkey As Short)
        Sub SetHotkey(ByVal wHotkey As Short)
        Sub GetShowCmd(ByRef piShowCmd As Integer)
        Sub SetShowCmd(ByVal iShowCmd As Integer)
        Sub GetIconLocation(<Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszIconPath As StringBuilder, ByVal cchIconPath As Integer, ByRef piIcon As Integer)
        Sub SetIconLocation(<MarshalAs(UnmanagedType.LPStr)> ByVal pszIconPath As String, ByVal iIcon As Integer)
        Sub SetRelativePath(<MarshalAs(UnmanagedType.LPStr)> ByVal pszPathRel As String, ByVal dwReserved As Integer)
        Sub Resolve(ByVal hwnd As IntPtr, ByVal fFlags As Integer)
        Sub SetPath(<MarshalAs(UnmanagedType.LPStr)> ByVal pszFile As String)
    End Interface

    <ComImport()> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    <Guid("000214F9-0000-0000-C000-000000000046")> _
    Private Interface IShellLinkW
        Sub GetPath(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszFile As StringBuilder, ByVal cchMaxPath As Integer, ByRef pfd As Win32FindDataW, ByVal fFlags As Integer)
        Sub GetIDList(ByRef ppidl As IntPtr)
        Sub SetIDList(ByVal pidl As IntPtr)
        Sub GetDescription(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszName As StringBuilder, ByVal cchMaxName As Integer)
        Sub SetDescription(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszName As String)
        Sub GetWorkingDirectory(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszDir As StringBuilder, ByVal cchMaxPath As Integer)
        Sub SetWorkingDirectory(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszDir As String)
        Sub GetArguments(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszArgs As StringBuilder, ByVal cchMaxPath As Integer)
        Sub SetArguments(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszArgs As String)
        Sub GetHotkey(ByRef pwHotkey As Short)
        Sub SetHotkey(ByVal wHotkey As Short)
        Sub GetShowCmd(ByRef piShowCmd As Integer)
        Sub SetShowCmd(ByVal iShowCmd As Integer)
        Sub GetIconLocation(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszIconPath As StringBuilder, ByVal cchIconPath As Integer, ByRef piIcon As Integer)
        Sub SetIconLocation(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszIconPath As String, ByVal iIcon As Integer)
        Sub SetRelativePath(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszPathRel As String, ByVal dwReserved As Integer)
        Sub Resolve(ByVal hwnd As IntPtr, ByVal fFlags As Integer)
        Sub SetPath(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszFile As String)
    End Interface

    <DllImport("shell32.dll", SetLastError:=True)> _
    Private Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFileInfo, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As IntPtr
    End Function
#End Region
End Class
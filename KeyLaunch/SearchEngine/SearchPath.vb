<Serializable()>
Public Class SearchPath
    Private mDirInfo As IO.DirectoryInfo
    Private mRecurse As Boolean
    Private mExceptions As SearchPaths
    Private mFriendlyName As String

    Public Sub New()
        mExceptions = New SearchPaths()
    End Sub

    Public Sub New(directory As String, Optional recurse As Boolean = False, Optional friendlyName As String = "")
        Me.New(New IO.DirectoryInfo(directory), recurse, friendlyName)
    End Sub

    Public Sub New(directory As IO.DirectoryInfo, Optional recurse As Boolean = False, Optional friendlyName As String = "")
        Me.New()
        mDirInfo = directory
        mRecurse = recurse
        mFriendlyName = friendlyName
    End Sub

    Public Sub New(directory As IO.DirectoryInfo, recurse As Boolean, exceptions As SearchPaths)
        mDirInfo = directory
        mRecurse = recurse
        mExceptions = exceptions
    End Sub

    Public Property DirectoryInfo() As IO.DirectoryInfo
        Get
            Return mDirInfo
        End Get
        Set(ByVal value As IO.DirectoryInfo)
            mDirInfo = value
        End Set
    End Property

    Public Property Recurse() As Boolean
        Get
            Return mRecurse
        End Get
        Set(ByVal value As Boolean)
            mRecurse = value
        End Set
    End Property

    Public ReadOnly Property FullPathName() As String
        Get
            Return mDirInfo.FullName
        End Get
    End Property

    Public ReadOnly Property ShortPathName() As String
        Get
            Return mDirInfo.Name
        End Get
    End Property

    Public ReadOnly Property Exceptions() As SearchPaths
        Get
            Return mExceptions
        End Get
    End Property

    Public Property FirendlyName() As String
        Get
            If mFriendlyName = "" Then
                Return ShortPathName
            Else
                Return mFriendlyName
            End If
        End Get
        Set(ByVal value As String)
            mFriendlyName = value
        End Set
    End Property

    Public Shared Operator =(ByVal sp1 As SearchPath, ByVal sp2 As SearchPath) As Boolean
        Return sp1.FullPathName = sp2.FullPathName
    End Operator

    Public Shared Operator <>(ByVal sp1 As SearchPath, ByVal sp2 As SearchPath) As Boolean
        Return Not (sp1 = sp2)
    End Operator
End Class

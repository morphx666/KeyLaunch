Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Runtime.InteropServices

Public Class SearchEngine
    Public Enum StateConstants
        Idle = 0
        Searching = 1
        Aborting = 2
    End Enum

    Private mQuery As String = ""
    Private mQueryLenght As Integer
    Private mState As StateConstants = StateConstants.Idle
    Private mItems As SearchItems
    Private mCategories As SearchCategories
    Private mSearchPaths As SearchPaths
    Private mLimitCategory As SearchCategory
    Private mPathsExceptions As List(Of String)
    Private mExtensions As Dictionary(Of String, SearchCategory)
    Private mMaxThreads As Integer
    Private mProgressTotal As Integer
    Private mProgressCount As Integer

    Private mSearchThreads As New List(Of Tasks.Task)
    Private threadThreadsMonitor As Thread
    Private mAbortMonitor As Boolean

    Public Event MatchFound(ByVal searchItem As SearchItem, ByVal category As SearchCategory)
    Public Event Done()
    Public Event Aborted()
    Public Event ProgressChanged()

    Public Sub New()
        mMaxThreads = 20
        mItems = New SearchItems()
        mCategories = New SearchCategories()
        mSearchPaths = New SearchPaths()

        mAbortMonitor = False
        threadThreadsMonitor = New Thread(AddressOf ThreadsMonitor)
        With threadThreadsMonitor
            .IsBackground = True
            .Start()
        End With
    End Sub

    Public Property Query() As String
        Get
            Return mQuery
        End Get
        Protected Set(ByVal value As String)
            mQuery = value.ToLower
            mQueryLenght = value.Length
        End Set
    End Property

    Public ReadOnly Property State() As StateConstants
        Get
            Return mState
        End Get
    End Property

    Public ReadOnly Property SearchPaths() As SearchPaths
        Get
            Return mSearchPaths
        End Get
    End Property

    Public ReadOnly Property Categories() As SearchCategories
        Get
            Return mCategories
        End Get
    End Property

    Public ReadOnly Property SearchItems() As SearchItems
        Get
            Return mItems
        End Get
    End Property

    Public Property MaxThreads() As Integer
        Get
            Return mMaxThreads
        End Get
        Set(ByVal value As Integer)
            mMaxThreads = value
        End Set
    End Property

    Public ReadOnly Property Progess() As Integer
        Get
            If mProgressTotal = 0 Then
                Return 0
            Else
                Return Math.Min(CInt((mProgressCount * 100) / mProgressTotal), 100)
            End If
        End Get
    End Property

    Private Sub InitItemsList()
        mItems.Clear()
        For Each c As SearchCategory In mCategories
            c.Item = New SearchItem(c.Name)
            mItems.Add(c.Item)
        Next
    End Sub

    Public Sub Abort()
        If mState = StateConstants.Idle Then Exit Sub
        mState = StateConstants.Aborting
    End Sub

    Private Sub ThreadsMonitor()
        Do
            Thread.Sleep(60)

            If mState <> StateConstants.Idle Then
                SyncLock mSearchThreads
                    For i As Integer = 0 To mSearchThreads.Count - 1
                        If (mSearchThreads(i) Is Nothing) OrElse mSearchThreads(i).Status <> Tasks.TaskStatus.Running Then
                            mSearchThreads.RemoveAt(i)
                            Exit For
                        End If
                    Next

                    If mSearchThreads.Count = 0 Then
                        Select Case mState
                            Case StateConstants.Aborting
                                DoneAborting()
                            Case StateConstants.Searching
                                DoneSearching()
                        End Select
                    End If
                End SyncLock
            End If
        Loop Until mAbortMonitor
    End Sub

    Public Sub StartNewSearch(ByVal query As String, ByVal pathsExceptions As List(Of String), ByVal selExtensions As Dictionary(Of String, SearchCategory), Optional ByVal limitCategory As SearchCategory = Nothing)
        Me.Query = query
        mLimitCategory = limitCategory
        InitItemsList()

        If mQuery = "" Then
            Me.Abort()
        Else
            mProgressTotal = mSearchPaths.Count
            mProgressCount = 0

            SyncLock mSearchThreads
                mState = StateConstants.Searching
                mPathsExceptions = pathsExceptions
                mExtensions = selExtensions
                For Each folder As SearchPath In mSearchPaths
                    If mState = StateConstants.Aborting Then Exit For
                    CreateNewSearchThread(folder)
                Next
            End SyncLock
        End If
    End Sub

    Private Sub CreateNewSearchThread(ByVal folder As SearchPath)
        If mState <> StateConstants.Searching Then Exit Sub
        mSearchThreads.Add(Tasks.Task.Run(Sub() DoSearch(CType(folder, SearchPath))))
    End Sub

    Private Sub InitSearchThread(ByVal param As Object)
        Try
            DoSearch(CType(param, SearchPath))
        Catch ex As Exception
            Debug.WriteLine($"{NameOf(InitSearchThread)}: {ex.Message}")
        End Try
    End Sub

    Private Sub DoSearch(ByVal folder As SearchPath)
        If Not folder.DirectoryInfo.Exists Then Exit Sub
        If mState <> StateConstants.Searching Then Exit Sub
        If (folder.DirectoryInfo.Attributes And IO.FileAttributes.Hidden) = IO.FileAttributes.Hidden Then Exit Sub

        Dim c As SearchCategory
        Dim fi As IO.FileInfo

        Try
            For Each extCat As KeyValuePair(Of String, SearchCategory) In mExtensions
                If mState <> StateConstants.Searching Then Exit Sub

                For Each fi In folder.DirectoryInfo.GetFiles("*" + extCat.Key)
                    If mState <> StateConstants.Searching Then Exit Sub

                    If IsMatch(fi.Name) Then RaiseEvent MatchFound(New SearchItem(fi), extCat.Value)
                Next
            Next
        Catch ex As Exception
            Debug.WriteLine($"{NameOf(DoSearch)}: {ex.Message}")
            Exit Sub
        End Try

        Dim linkFiles() As IO.FileInfo = folder.DirectoryInfo.GetFiles("*.lnk")
        Dim lnkExt As String
        If linkFiles.Length > 0 Then
            Dim mShellLink As ShellLink = New ShellLink
            Dim lnk As IO.FileInfo
            Dim linkPath As String
            For Each fi In linkFiles
                If mState <> StateConstants.Searching Then Exit Sub

                If IsMatch(fi.Name) Then
                    linkPath = mShellLink.GetLinkedPath(fi.FullName)
                    If IO.File.Exists(linkPath) Then
                        lnk = New IO.FileInfo(linkPath)
                        lnkExt = lnk.Extension.ToLower
                        For Each c In mCategories
                            If mState <> StateConstants.Searching Then Exit Sub
                            If mLimitCategory IsNot Nothing AndAlso mLimitCategory.Name <> c.Name Then Continue For

                            If c.Extensions.Contains(lnkExt) Then
                                RaiseEvent MatchFound(New SearchItem(fi), c)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
            mShellLink = Nothing
        End If

        If folder.Recurse Then
            For Each di As IO.DirectoryInfo In folder.DirectoryInfo.GetDirectories()
                If mState <> StateConstants.Searching Then Exit Sub

                If Not mPathsExceptions.Contains(di.FullName) Then
                    mProgressTotal += 1
                    If mSearchThreads.Count >= mMaxThreads Then
                        Try
                            DoSearch(New SearchPath(di, True, folder.Exceptions))
                        Catch ex As Exception
                            Debug.WriteLine($"{NameOf(DoSearch)}: {ex.Message}")
                        End Try
                    Else
                        CreateNewSearchThread(New SearchPath(di, True, folder.Exceptions))
                    End If
                End If
            Next
        End If

        mProgressCount += 1
        RaiseEvent ProgressChanged()
    End Sub

    Private Sub DoneSearching()
        Application.DoEvents()
        If mState = StateConstants.Searching Then
            mState = StateConstants.Idle
            ResetProgress()
            RaiseEvent Done()
        End If
    End Sub

    Private Sub ResetProgress()
        mProgressCount = 0
        mProgressTotal = 0
        RaiseEvent ProgressChanged()
    End Sub

    Private Sub DoneAborting()
        If mSearchThreads.Count = 0 Then
            mState = StateConstants.Idle
            ResetProgress()
            RaiseEvent Aborted()
        End If
    End Sub

    Private Function IsMatch(ByVal testString As String, Optional ByVal query As String = "", Optional ByVal IsRecursing As Boolean = False) As Boolean
        Dim tLen As Integer
        Dim tStr As String

        testString = testString.ToLower
        If IsRecursing Then
            tStr = query
            tLen = query.Length
        Else
            tStr = mQuery
            tLen = mQueryLenght
        End If

        If testString.Contains(tStr) Then
            Return True
        Else
            If Not IsRecursing AndAlso tStr.Contains(" ") Then
                For Each s As String In tStr.Split(CChar(" "))
                    If Not IsMatch(testString, s, True) Then Return False
                Next
                Return True
            End If
        End If
    End Function

    Protected Overrides Sub Finalize()
        mAbortMonitor = True
        mSearchThreads.Clear()
        MyBase.Finalize()
    End Sub
End Class

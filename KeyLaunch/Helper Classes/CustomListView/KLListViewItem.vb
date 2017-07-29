Public Class KLListViewItem
    Private WithEvents mSubItems As KLListViewItemsCollection
    Private mItemType As ItemTypeConstants
    Private mForeColor As Color
    Private mForeColorSelected As Color
    Private mBackColor As Color
    Private mBackColorSelected As Color
    Private mFont As Font
    Private mFontSelected As Font
    Private mSearchItem As SearchItem
    Private mCategoryItem As SearchCategory
    Private mBounds As Rectangle
    Private mIsSelected As Boolean
    Private mParentItem As KLListViewItem
    Private mParentListView As KLListView
    Private mInView As Boolean
    Private mHasChanged As Boolean

    Public Event SubItemsChanged(ByVal sender As KLListViewItemsCollection, ByVal reason As KLListViewItemsCollection.ChangeEventConstants)

    Public Enum ItemTypeConstants
        Group = 0
        Item = 1
    End Enum

    Public Sub New(ByVal searchItem As SearchItem, ByVal parent As KLListViewItem)
        ' Defaults --------------
        mForeColor = Color.Black
        mBackColor = Color.White
        mFont = New Font("Trebuchet MS", 11, FontStyle.Regular, GraphicsUnit.Pixel)

        mForeColorSelected = Color.White
        mBackColorSelected = Color.FromArgb(69, 138, 191)
        mFontSelected = New Font("Trebuchet MS", 11, FontStyle.Regular, GraphicsUnit.Pixel)
        '------------------------

        mParentItem = parent
        mSubItems = New KLListViewItemsCollection(parent)
        mSearchItem = searchItem
        mItemType = ItemTypeConstants.Item

        mHasChanged = True
    End Sub

    Public Sub New(ByVal categoryItem As SearchCategory, ByVal parent As KLListViewItem, Optional ByVal parentListView As KLListView = Nothing)
        ' Defaults --------------
        mForeColor = Color.FromArgb(51, 51, 51)
        mBackColor = Color.White
        mFont = New Font("Trebuchet MS", 11, FontStyle.Bold, GraphicsUnit.Pixel)

        mForeColorSelected = Color.White
        mBackColorSelected = Color.Red
        mFontSelected = New Font("Trebuchet MS", 11, FontStyle.Bold, GraphicsUnit.Pixel)
        '------------------------

        mParentItem = parent
        mParentListView = parentListView
        mSubItems = New KLListViewItemsCollection(parent)
        mCategoryItem = categoryItem
        mItemType = ItemTypeConstants.Group

        mHasChanged = True
    End Sub

    Public Property IsSelected() As Boolean
        Get
            Return mIsSelected
        End Get
        Set(ByVal value As Boolean)
            If mIsSelected <> value Then
                mIsSelected = value
                mHasChanged = True
            End If
        End Set
    End Property

    Public ReadOnly Property SearchItem() As SearchItem
        Get
            Return mSearchItem
        End Get
    End Property

    Public ReadOnly Property CategoryItem() As SearchCategory
        Get
            Return mCategoryItem
        End Get
    End Property

    Public Property Font() As Font
        Get
            Return mFont
        End Get
        Set(ByVal value As Font)
            mFont = value
        End Set
    End Property

    Public Property FontSelected() As Font
        Get
            Return mFontSelected
        End Get
        Set(ByVal value As Font)
            mFontSelected = value
        End Set
    End Property

    Public Property ForeColor() As Color
        Get
            Return mForeColor
        End Get
        Set(ByVal value As Color)
            mForeColor = value
        End Set
    End Property

    Public Property ForeColorSelected() As Color
        Get
            Return mForeColorSelected
        End Get
        Set(ByVal value As Color)
            mForeColorSelected = value
        End Set
    End Property

    Public Property BackColor() As Color
        Get
            Return mBackColor
        End Get
        Set(ByVal value As Color)
            mBackColor = value
        End Set
    End Property

    Public Property BackColorSelected() As Color
        Get
            Return mBackColorSelected
        End Get
        Set(ByVal value As Color)
            mBackColorSelected = value
        End Set
    End Property

    Public Property SubItems() As KLListViewItemsCollection
        Get
            Return mSubItems
        End Get
        Set(ByVal value As KLListViewItemsCollection)
            mSubItems = value
        End Set
    End Property

    Public ReadOnly Property Index(Optional ByVal realIndex As Boolean = False) As Integer
        Get
            If mParentListView IsNot Nothing Then
                Return mParentListView.Items.IndexOf(Me)
            Else
                Dim idx As Integer = mParentItem.SubItems.IndexOf(Me)

                If realIndex Then
                    For Each lvi As KLListViewItem In mParentItem.mParentListView.Items
                        If lvi = mParentItem Then Exit For
                        idx += lvi.SubItems.Count
                    Next
                End If

                Return idx
            End If
        End Get
    End Property

    Public Function [Next]() As KLListViewItem
        Dim itemsCount As Integer
        If mParentListView IsNot Nothing Then
            itemsCount = (mParentListView.Items.Count - 1)
        Else
            itemsCount = (mParentItem.SubItems.Count - 1)
        End If

        If Me.Index = itemsCount Then
            If mParentItem Is Nothing Then Return Nothing

            Dim nextGroup As KLListViewItem = mParentItem.Next

            Do
                If nextGroup Is Nothing Then Return Nothing
                If nextGroup.SubItems.Count = 0 Then
                    nextGroup = nextGroup.Next
                Else
                    Exit Do
                End If
            Loop

            Return nextGroup.SubItems(0)
        Else
            If mParentListView IsNot Nothing Then
                Return mParentListView.Items(Me.Index + 1)
            Else
                Return mParentItem.SubItems(Me.Index + 1)
            End If
        End If
    End Function

    Public Function Previous() As KLListViewItem
        If Me.Index = 0 Then
            If mParentItem Is Nothing Then Return Nothing

            Dim prevGroup As KLListViewItem = mParentItem.Previous

            Do
                If prevGroup Is Nothing Then Return Nothing
                If prevGroup.SubItems.Count = 0 Then
                    prevGroup = prevGroup.Previous
                Else
                    Exit Do
                End If
            Loop

            Return prevGroup.SubItems(prevGroup.SubItems.Count - 1)
        Else
            If mParentListView IsNot Nothing Then
                Return mParentListView.Items(Me.Index - 1)
            Else
                Return mParentItem.SubItems(Me.Index - 1)
            End If
        End If
    End Function

    Public ReadOnly Property Parent() As KLListViewItem
        Get
            Return mParentItem
        End Get
    End Property

    Public ReadOnly Property ItemType() As ItemTypeConstants
        Get
            Return mItemType
        End Get
    End Property

    Public Property Bounds() As Rectangle
        Get
            Return mBounds
        End Get
        Set(ByVal value As Rectangle)
            If mBounds <> value Then
                mBounds = value
                mHasChanged = True
            End If
        End Set
    End Property

    Public Property InView() As Boolean
        Get
            Return mInView
        End Get
        Set(ByVal value As Boolean)
            mInView = value
        End Set
    End Property

    Private Sub mSubItems_Changed(ByVal sender As KLListViewItemsCollection, ByVal reason As KLListViewItemsCollection.ChangeEventConstants) Handles mSubItems.Changed
        RaiseEvent SubItemsChanged(sender, reason)
    End Sub

    Public ReadOnly Property HasChanged() As Boolean
        Get
            Dim changed As Boolean = mHasChanged
            mHasChanged = False
            Return changed
        End Get
    End Property

    Public Sub Launch()
        Try
            Dim procInfo As ProcessStartInfo = New ProcessStartInfo(mSearchItem.FileInfo.FullName)
            procInfo.UseShellExecute = True
            Process.Start(procInfo)
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + vbCrLf + _
            "File: " + mSearchItem.Name + vbCrLf + _
            "Location: " + mSearchItem.FileInfo.Directory.FullName, _
            MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Launch Failed")
        End Try
    End Sub

    Public Sub OpenContainingFolder()
        Try
            Dim procInfo As ProcessStartInfo = New ProcessStartInfo(mSearchItem.FileInfo.Directory.FullName)
            procInfo.UseShellExecute = True
            Process.Start(procInfo)
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub OpenContainingFolder(ByVal folder As String)
        Try
            Dim procInfo As ProcessStartInfo = New ProcessStartInfo(folder)
            procInfo.UseShellExecute = True
            Process.Start(procInfo)
        Catch ex As Exception
            MsgBox(String.Format("The '{0}' directory could not be opened." + vbCrLf + vbCrLf + "{1}", folder, ex.Message), MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error opening directory")
        End Try
    End Sub

    Public Shared Operator =(ByVal lvi1 As KLListViewItem, ByVal lvi2 As KLListViewItem) As Boolean
        Select Case lvi1.ItemType
            Case ItemTypeConstants.Group
                Return (lvi2.ItemType = ItemTypeConstants.Group) AndAlso (lvi1.CategoryItem = lvi2.CategoryItem)
            Case ItemTypeConstants.Item
                Return (lvi2.ItemType = ItemTypeConstants.Item) AndAlso (lvi1.SearchItem = lvi2.SearchItem)
        End Select
    End Operator

    Public Shared Operator <>(ByVal lvi1 As KLListViewItem, ByVal lvi2 As KLListViewItem) As Boolean
        Return Not (lvi1 = lvi2)
    End Operator
End Class

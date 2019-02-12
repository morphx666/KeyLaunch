Public Class KLListViewItemsCollection
    Implements IList(Of KLListViewItem)

    Public Enum ChangeEventConstants
        ItemAdded = 0
        ItemRemoved = 1
        ItemChanged = 2
        CollectionCleared = 3
    End Enum

    Private mCol As List(Of KLListViewItem)

    Private parentItem As KLListViewItem
    Public Event Changed(ByVal sender As KLListViewItemsCollection, ByVal reason As ChangeEventConstants)

    Private Sub SubitemsChanged(ByVal sender As KLListViewItemsCollection, ByVal reason As ChangeEventConstants)
        RaiseEvent Changed(sender, reason)
    End Sub

    Public Sub New(ByVal parent As KLListViewItem)
        parentItem = parent
        mCol = New List(Of KLListViewItem)
    End Sub

    Public Sub Add(ByVal item As KLListViewItem) Implements ICollection(Of KLListViewItem).Add
        If item.ItemType = KLListViewItem.ItemTypeConstants.Group Then
            AddHandler item.SubItemsChanged, AddressOf SubitemsChanged
        End If

        mCol.Add(item)

        If item.ItemType = KLListViewItem.ItemTypeConstants.Item Then
            RaiseEvent Changed(Me, ChangeEventConstants.ItemAdded)
        End If
    End Sub

    Public Sub Clear() Implements ICollection(Of KLListViewItem).Clear
        mCol.Clear()
        RaiseEvent Changed(Me, ChangeEventConstants.CollectionCleared)
    End Sub

    Public Function Contains(ByVal item As KLListViewItem) As Boolean Implements ICollection(Of KLListViewItem).Contains
        Return mCol.Contains(item)
    End Function

    Public Sub CopyTo(ByVal array() As KLListViewItem, ByVal arrayIndex As Integer) Implements ICollection(Of KLListViewItem).CopyTo

    End Sub

    Public ReadOnly Property Count() As Integer Implements ICollection(Of KLListViewItem).Count
        Get
            Return mCol.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements ICollection(Of KLListViewItem).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function Remove(ByVal item As KLListViewItem) As Boolean Implements ICollection(Of KLListViewItem).Remove
        Dim r As Boolean = mCol.Remove(item)
        RaiseEvent Changed(Me, ChangeEventConstants.ItemRemoved)

        Return r
    End Function

    Public Function GetEnumerator() As IEnumerator(Of KLListViewItem) Implements IEnumerable(Of KLListViewItem).GetEnumerator
        Return mCol.GetEnumerator
    End Function

    Public Function IndexOf(ByVal item As KLListViewItem) As Integer Implements IList(Of KLListViewItem).IndexOf
        Return mCol.IndexOf(item)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal item As KLListViewItem) Implements IList(Of KLListViewItem).Insert
        mCol.Insert(index, item)
        RaiseEvent Changed(Me, ChangeEventConstants.ItemAdded)
    End Sub

    Default Public Property Item(ByVal index As Integer) As KLListViewItem Implements IList(Of KLListViewItem).Item
        Get
            Return mCol(index)
        End Get
        Set(ByVal value As KLListViewItem)
            mCol(index) = value
            RaiseEvent Changed(Me, ChangeEventConstants.ItemChanged)
        End Set
    End Property

    Public Sub RemoveAt(ByVal index As Integer) Implements IList(Of KLListViewItem).RemoveAt
        mCol.RemoveAt(index)
        RaiseEvent Changed(Me, ChangeEventConstants.ItemRemoved)
    End Sub

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return mCol.GetEnumerator
    End Function
End Class

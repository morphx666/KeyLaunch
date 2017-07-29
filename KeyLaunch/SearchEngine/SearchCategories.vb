<Serializable()> _
Public Class SearchCategories
    Implements IList(Of SearchCategory)

    Private mCol As List(Of SearchCategory)

    Public Sub New()
        mCol = New List(Of SearchCategory)
    End Sub

    Public Sub Add(ByVal item As SearchCategory) Implements System.Collections.Generic.ICollection(Of SearchCategory).Add
        mCol.Add(item)
    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of SearchCategory).Clear
        mCol.Clear()
    End Sub

    Public Function Contains(ByVal item As SearchCategory) As Boolean Implements System.Collections.Generic.ICollection(Of SearchCategory).Contains
        Return mCol.Contains(item)
    End Function

    Public Sub CopyTo(ByVal array() As SearchCategory, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of SearchCategory).CopyTo

    End Sub

    Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of SearchCategory).Count
        Get
            Return mCol.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of SearchCategory).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function Remove(ByVal item As SearchCategory) As Boolean Implements System.Collections.Generic.ICollection(Of SearchCategory).Remove
        Return mCol.Remove(item)
    End Function

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of SearchCategory) Implements System.Collections.Generic.IEnumerable(Of SearchCategory).GetEnumerator
        Return mCol.GetEnumerator
    End Function

    Public Function IndexOf(ByVal item As SearchCategory) As Integer Implements System.Collections.Generic.IList(Of SearchCategory).IndexOf
        Return mCol.IndexOf(item)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal item As SearchCategory) Implements System.Collections.Generic.IList(Of SearchCategory).Insert
        mCol.Insert(index, item)
    End Sub

    Default Public Property Item(ByVal index As Integer) As SearchCategory Implements System.Collections.Generic.IList(Of SearchCategory).Item
        Get
            Return mCol(index)
        End Get
        Set(ByVal value As SearchCategory)
            mCol(index) = value
        End Set
    End Property

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.Generic.IList(Of SearchCategory).RemoveAt
        mCol.RemoveAt(index)
    End Sub

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return mCol.GetEnumerator
    End Function
End Class

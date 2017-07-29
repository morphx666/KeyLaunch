<Serializable()> _
Public Class SearchPaths
    Implements IList(Of SearchPath)
    Implements ICloneable

    Private mCol As List(Of SearchPath)

    Public Sub New()
        mCol = New List(Of SearchPath)
    End Sub

    Public Sub Add(ByVal item As SearchPath) Implements System.Collections.Generic.ICollection(Of SearchPath).Add
        mCol.Add(item)
    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of SearchPath).Clear
        mCol.Clear()
    End Sub

    Public Function Contains(ByVal item As SearchPath) As Boolean Implements System.Collections.Generic.ICollection(Of SearchPath).Contains
        Return mCol.Contains(item)
    End Function

    Public Sub CopyTo(ByVal array() As SearchPath, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of SearchPath).CopyTo

    End Sub

    Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of SearchPath).Count
        Get
            Return mCol.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of SearchPath).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function Remove(ByVal item As SearchPath) As Boolean Implements System.Collections.Generic.ICollection(Of SearchPath).Remove
        Return mCol.Remove(item)
    End Function

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of SearchPath) Implements System.Collections.Generic.IEnumerable(Of SearchPath).GetEnumerator
        Return mCol.GetEnumerator
    End Function

    Public Function IndexOf(ByVal item As SearchPath) As Integer Implements System.Collections.Generic.IList(Of SearchPath).IndexOf
        Return mCol.IndexOf(item)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal item As SearchPath) Implements System.Collections.Generic.IList(Of SearchPath).Insert
        mCol.Insert(index, item)
    End Sub

    Default Public Property Item(ByVal index As Integer) As SearchPath Implements System.Collections.Generic.IList(Of SearchPath).Item
        Get
            Return mCol(index)
        End Get
        Set(ByVal value As SearchPath)
            mCol(index) = value
        End Set
    End Property

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.Generic.IList(Of SearchPath).RemoveAt
        mCol.RemoveAt(index)
    End Sub

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return mCol.GetEnumerator
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return MyBase.MemberwiseClone()
    End Function
End Class

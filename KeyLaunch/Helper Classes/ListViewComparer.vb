Public Class ListViewComparer
    Implements IComparer

    Private ReadOnly mColumnNumber As Integer
    Private ReadOnly mSortOrder As SortOrder

    Public Sub New(column_number As Integer, sort_order As SortOrder)
        mColumnNumber = column_number
        mSortOrder = sort_order
    End Sub

    ' Compare the items in the appropriate column
    ' for objects x and y.
    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x, ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y, ListViewItem)

        ' Get the sub-item values.
        Dim string_x As String = If(item_x.SubItems.Count <= mColumnNumber,
                                        "",
                                        item_x.SubItems(mColumnNumber).Text)

        Dim string_y As String = If(item_y.SubItems.Count <= mColumnNumber,
                                        "",
                                        item_y.SubItems(mColumnNumber).Text)

        ' Compare them.
        Return If(mSortOrder = SortOrder.Ascending,
                    String.Compare(string_x, string_y),
                    String.Compare(string_y, string_x))
    End Function
End Class

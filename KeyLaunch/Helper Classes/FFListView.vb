Public Class FFListView
    Inherits ListView

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub

    Public Sub handleKeyNav(ByVal e As KeyEventArgs)
        If Me.SelectedIndices.Count = 0 Then Exit Sub

        Dim selItem As ListViewItem = Me.Items(Me.SelectedIndices(0))
        Select Case e.KeyCode
            Case Keys.Up
                If selItem.Index > 0 Then Me.Items(selItem.Index - 1).Selected = True
            Case Keys.Down
                If selItem.Index < (Me.Items.Count - 1) Then Me.Items(selItem.Index + 1).Selected = True
            Case Keys.PageDown, Keys.End
                Me.Items(Me.Items.Count - 1).Selected = True
            Case Keys.PageUp, Keys.Home
                Me.Items(0).Selected = True
        End Select
    End Sub
End Class

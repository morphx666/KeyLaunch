Public Class frmAddFromDropExtension

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        lbCats.SelectedIndex = -1
        Me.Close()
    End Sub

    Private Sub frmAddFromDropExtension_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        pbIcon.Image = SearchItem.GetIconFromFile(Environment.SystemDirectory + "\shell32.dll", 25, False).ToBitmap()
    End Sub
End Class
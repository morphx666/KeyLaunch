Public Class frmAddFromDropExtension

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lbCats.SelectedIndex = -1
        Me.Close()
    End Sub

    Private Sub frmAddFromDropExtension_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbIcon.Image = SearchItem.GetIconFromFile(Environment.SystemDirectory + "\shell32.dll", 25, False).ToBitmap()
    End Sub
End Class
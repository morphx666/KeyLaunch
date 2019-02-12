Public Class FormAddFromDropExtension
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ListBoxCats.SelectedIndex = -1
        Me.Close()
    End Sub

    Private Sub FormAddFromDropExtension_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBoxIcon.Image = SearchItem.GetIconFromFile(Environment.SystemDirectory + "\shell32.dll", 25, False).ToBitmap()
    End Sub
End Class
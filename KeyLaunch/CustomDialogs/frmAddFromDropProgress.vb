Public Class frmAddFromDropProgress
    Private Sub frmAddFromDropProgress_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.DoubleBuffered = True
    End Sub

    Private Sub frmAddFromDropProgress_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        With e.Graphics
            .DrawRectangle(Pens.DarkGray, 0, 0, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom - 1)
            .DrawLine(Pens.DarkGray, 0, pnlInfo.Bottom, e.ClipRectangle.Right - 1, pnlInfo.Bottom)
        End With
    End Sub
End Class
Public Class FormAddFromDropProgress
    Private Sub FormAddFromDropProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.DoubleBuffered = True
    End Sub

    Private Sub FormAddFromDropProgress_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        With e.Graphics
            .DrawRectangle(Pens.DarkGray, 0, 0, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom - 1)
            .DrawLine(Pens.DarkGray, 0, PanelInfo.Bottom, e.ClipRectangle.Right - 1, PanelInfo.Bottom)
        End With
    End Sub
End Class
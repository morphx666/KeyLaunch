Module modGDIFX
    Public Sub DrawRoundedRectangle(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal d As Integer, ByVal p As Pen)
        Dim BaseRect As New RectangleF(x, y, w, h)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(d, d))

        'top left Arc
        g.DrawArc(p, ArcRect, 180, 90)
        g.DrawLine(p, x + d \ 2, y, x + w - d \ 2, y)

        ' top right arc
        ArcRect.X = BaseRect.Right - d
        g.DrawArc(p, ArcRect, 270, 90)
        g.DrawLine(p, x + w, y + d \ 2, x + w, y + h - d \ 2)

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - d
        g.DrawArc(p, ArcRect, 0, 90)
        g.DrawLine(p, x + d \ 2, y + h, x + w - d \ 2, y + h)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        g.DrawArc(p, ArcRect, 90, 90)
        g.DrawLine(p, x, y + d \ 2, x, y + h - d \ 2)
    End Sub

    Public Sub FillRoundedRectangle(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal d As Integer, ByVal b As Brush)
        Dim path As New Drawing2D.GraphicsPath
        Dim BaseRect As New RectangleF(x, y, w, h)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(d, d))

        'top left Arc
        path.AddArc(ArcRect, 180, 90)
        path.AddLine(x + d \ 2, y, x + w - d \ 2, y)

        ' top right arc
        ArcRect.X = BaseRect.Right - d
        path.AddArc(ArcRect, 270, 90)
        path.AddLine(x + w, y + d \ 2, x + w, y + h - d \ 2)
        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - d
        path.AddArc(ArcRect, 0, 90)
        path.AddLine(x + d \ 2, y + h, x + w - d \ 2, y + h)
        ' bottom left arc
        ArcRect.X = BaseRect.Left
        path.AddArc(ArcRect, 90, 90)
        path.AddLine(x, y + d \ 2, x, y + h - d \ 2)

        g.FillPath(b, path)

        path.Dispose()
    End Sub

    Public Function ConvertToGrayscale(ByVal img As Image) As Image
        Dim bm As Bitmap = New Bitmap(img.Width, img.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        Dim cm As Imaging.ColorMatrix = New Imaging.ColorMatrix(New Single()() _
                                                     {New Single() {0.3, 0.3, 0.3, 0, 0}, _
                                                    New Single() {0.59, 0.59, 0.59, 0, 0}, _
                                                    New Single() {0.11, 0.11, 0.11, 0, 0}, _
                                                    New Single() {0, 0, 0, 1, 0}, _
                                                    New Single() {0, 0, 0, 0, 1}})


        Dim ia As Imaging.ImageAttributes = New Imaging.ImageAttributes()
        ia.SetColorMatrix(cm)
        g.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia)
        g.Dispose()

        Return bm
    End Function

    Public Function IIf(Of T)(ByVal condition As Boolean, ByVal truePart As T, ByVal falsePart As T) As T
        If condition Then
            Return truePart
        Else
            Return falsePart
        End If
    End Function
End Module

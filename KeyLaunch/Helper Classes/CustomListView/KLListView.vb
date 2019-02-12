Imports System.ComponentModel

Public Class KLListView
    Private WithEvents LvItems As KLListViewItemsCollection

    Private mGridColor As Color
    Private isRendering As Boolean
    Private mItemsTotalCount As Integer
    Private mItemsVisibleCount As Integer
    Private mItemsVisibleCountTemp As Integer
    Private scrollBarVisibleCount As Integer
    Private mSelectedItem As KLListViewItem
    Private mMouseClickAt As Integer
    Private mIsRendering As Boolean
    Private mFirstVisibleItem As KLListViewItem
    Private mLastVisibleItem As KLListViewItem
    Private mDoRender As Boolean
    Private itemStringFormat As StringFormat
    Private mDirAreaWidth As Integer = 20

    Private dirDisplayWidth As Integer = 150

    Public Enum SelectColConstants
        Item = 0
        Folder = 1
    End Enum
    Private selectColMode As SelectColConstants = SelectColConstants.Item

    Public Event ItemSelected(ByVal item As KLListViewItem)

    Public Sub New()
        ' Default Values
        Me.BackColor = Color.White
        mGridColor = Color.WhiteSmoke
        mMouseClickAt = -1

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.Selectable, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        MyBase.DoubleBuffered = True

        LvItems = New KLListViewItemsCollection(Nothing)
        VScrollBarItem.Visible = False
        VScrollBarItem.SmallChange = 1
        VScrollBarItem.LargeChange = 1
        scrollBarVisibleCount = -1

        itemStringFormat = New StringFormat(StringFormatFlags.LineLimit) With {.Trimming = StringTrimming.EllipsisCharacter}

        AddHandler Me.MouseWheel, AddressOf HandleMouseWheel

        'TODO: Fix this!!!
        VScrollBar.CheckForIllegalCrossThreadCalls = False
    End Sub

    Public Property DirAreaWidthPercentage() As Integer
        Get
            Return mDirAreaWidth
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 0
            If value > 40 Then value = 40
            mDirAreaWidth = value
            SetDirAreaWidth()
            Me.Invalidate()
        End Set
    End Property

    Public ReadOnly Property ScrollbarIsVisible() As Boolean
        Get
            Return VScrollBarItem.Visible
        End Get
    End Property

    Public ReadOnly Property ScrollbarWidth() As Integer
        Get
            Return If(VScrollBarItem.Visible, VScrollBarItem.Width, 0)
        End Get
    End Property

    Public ReadOnly Property ItemsTotalCount() As Integer
        Get
            Return mItemsTotalCount
        End Get
    End Property

    Public ReadOnly Property ItemsVisibleCount() As Integer
        Get
            Return mItemsVisibleCount
        End Get
    End Property

    Public ReadOnly Property Items() As KLListViewItemsCollection
        Get
            Return LvItems
        End Get
    End Property

    Public Property SelectedItem() As KLListViewItem
        Get
            Return mSelectedItem
        End Get
        Set(ByVal value As KLListViewItem)
            If mSelectedItem IsNot Nothing Then mSelectedItem.IsSelected = False
            mSelectedItem = value
            If mSelectedItem IsNot Nothing Then
                mSelectedItem.IsSelected = True

                RaiseEvent ItemSelected(mSelectedItem)
            End If
        End Set
    End Property

    Public Property ScrollPosition() As Integer
        Get
            Return VScrollBarItem.Value
        End Get
        Set(ByVal value As Integer)
            If value >= 0 And value <= VScrollBarItem.Maximum Then VScrollBarItem.Value = value
        End Set
    End Property

    Public Property SelectionColumnMode() As SelectColConstants
        Get
            Return selectColMode
        End Get
        Set(ByVal value As SelectColConstants)
            If selectColMode <> value Then
                selectColMode = value
                RepaintControl()
            End If
        End Set
    End Property

    Public Function ScrollDown() As Boolean
        Try
            If VScrollBarItem.Value + (scrollBarVisibleCount - 1) < VScrollBarItem.Maximum Then
                VScrollBarItem.Value += 1
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Public Function ScrollUp() As Boolean
        Try
            If VScrollBarItem.Value > 0 Then
                VScrollBarItem.Value -= 1
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    <Category("Appearance"), DefaultValue(GetType(Color), "Color.White")>
    Public Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            MyBase.BackColor = value
        End Set
    End Property

    <Category("Appearance"), DefaultValue(GetType(Color), "Color.WhiteSmoke")>
    Public Property GridColor() As Color
        Get
            Return mGridColor
        End Get
        Set(ByVal value As Color)
            mGridColor = value
        End Set
    End Property

    Private Sub KLListView_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If mSelectedItem IsNot Nothing Then mSelectedItem.IsSelected = False
        mMouseClickAt = e.Y

        selectColMode = If(e.X < Me.Width - dirDisplayWidth - 16,
                            SelectColConstants.Item,
                            SelectColConstants.Folder)

        RepaintControl()
    End Sub

    Private Sub KLListView_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        RenderControl(e.Graphics, e.ClipRectangle)
    End Sub

    Private Sub VScrollBarItem_KeyDown(sender As Object, e As KeyEventArgs) Handles VScrollBarItem.KeyDown
        e.Handled = True

        Me.OnKeyDown(e)
    End Sub

    Private Sub VScrollBarItem_ValueChanged(sender As Object, e As EventArgs) Handles VScrollBarItem.ValueChanged
        RepaintControl()
    End Sub

    Private Sub HandleMouseWheel(sender As Object, e As MouseEventArgs)
        If VScrollBarItem.Visible Then
            If e.Delta < 0 Then
                ScrollDown()
            Else
                ScrollUp()
            End If
        End If
    End Sub

    Private Sub RenderControl(ByVal g As Graphics, ByVal r As Rectangle, Optional ByVal IgnoreRenderingState As Boolean = False)
        Dim p As Point = New Point(2, 2)
        Dim r1 As Rectangle = New Rectangle(r.Left, r.Top, r.Width - dirDisplayWidth, r.Bottom)

        If (Not IgnoreRenderingState) Then
            If mIsRendering Then Exit Sub
            mIsRendering = True
        End If

        If g IsNot Nothing Then
            With g
                .CompositingQuality = Drawing2D.CompositingQuality.AssumeLinear
                .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                .TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

                If dirDisplayWidth > 0 Then
                    Dim p1 As Point = New Point(r.Right - dirDisplayWidth, r.Top)
                    Dim p2 As Point = New Point(r.Right, r.Top)
                    Dim b As Drawing2D.LinearGradientBrush = New Drawing2D.LinearGradientBrush(p1, p2, Color.White, Color.WhiteSmoke)
                    .FillRectangle(b, New Rectangle(r.Right - dirDisplayWidth, r.Top, r.Width, r.Height))
                    .DrawLine(Pens.LightGray, r.Right - dirDisplayWidth + 2, r.Top, r.Right - dirDisplayWidth + 2, r.Bottom)
                End If
            End With
        End If

        mItemsVisibleCount = 0
        mItemsVisibleCountTemp = 0
        mFirstVisibleItem = Nothing
        mDoRender = (g IsNot Nothing)

        RenderItems(g, r1, LvItems, p)

        If (mItemsTotalCount > mItemsVisibleCount) OrElse (p.Y >= r.Height) Then
            With VScrollBarItem
                If scrollBarVisibleCount = -1 Then scrollBarVisibleCount = mItemsVisibleCount

                .Maximum = mItemsTotalCount + 4
                .LargeChange = scrollBarVisibleCount
                .Visible = True
            End With
        Else
            With VScrollBarItem
                If .Visible Then
                    .Visible = False
                    .Value = 0
                End If
                scrollBarVisibleCount = -1
                'r.Width += 17
            End With
        End If

        If g IsNot Nothing Then
            g.DrawRectangle(Pens.DarkGray, r.Left, r.Top, r.Width - 1, r.Height - 1)
            g.DrawLine(New Pen(Color.FromArgb(57, 114, 157)), r.Left, 0, r.Width, 0)
        End If

        If (Not IgnoreRenderingState) Then
            mIsRendering = False
            mMouseClickAt = -1
        End If
    End Sub

    Private Sub RenderItems(ByVal g As Graphics, ByVal r As Rectangle, ByVal parentCol As KLListViewItemsCollection, ByRef p As Point)
        Try
            For Each item As KLListViewItem In parentCol
                mItemsVisibleCountTemp += 1

                If mMouseClickAt <> -1 AndAlso (item.ItemType = KLListViewItem.ItemTypeConstants.Item) Then
                    item.IsSelected = (item.Bounds.Top <= mMouseClickAt And item.Bounds.Bottom >= mMouseClickAt)
                    If item.IsSelected Then SelectedItem = item
                End If

                If mItemsVisibleCountTemp > VScrollBarItem.Value Then
                    mItemsVisibleCount += 1
                    RenderItem(g, r, item, p)

                    p.Y += item.Bounds.Height + 1
                    If p.Y >= r.Height Then
                        mDoRender = False
                        item.InView = False
                    Else
                        item.InView = True
                    End If
                Else
                    item.InView = False
                End If

                If item.ItemType = KLListViewItem.ItemTypeConstants.Group Then RenderItems(g, r, item.SubItems, p)
            Next
        Catch
        End Try
    End Sub

    Private Sub RenderItem(ByVal g As Graphics, ByVal r As Rectangle, ByVal item As KLListViewItem, ByVal p As Point)
        Dim imgHeight As Integer
        Dim textHeight As Integer

        If p.Y + item.Bounds.Height < 0 Then Exit Sub

        If item.ItemType = KLListViewItem.ItemTypeConstants.Group Then
            If g IsNot Nothing Then
                textHeight = g.MeasureString(item.CategoryItem.Name, item.Font, 0).ToSize.Height
                g.DrawString(item.CategoryItem.Name, item.Font, New SolidBrush(item.ForeColor), p.X, p.Y + 2)
                item.Bounds = New Rectangle(0, p.Y, r.Width, textHeight + 2)

                ' FIXME : Add option to enable category underlining
                ' Underline categories
                g.DrawLine(Pens.LightGray, p.X, p.Y + textHeight + 2, r.Width, p.Y + textHeight + 2)
            End If
        Else
            If item.Bounds.IsEmpty Then
                If item.SearchItem.ItemIcon Is Nothing Then Exit Sub
                imgHeight = item.SearchItem.ItemIcon.Height
                textHeight = If(item.IsSelected,
                    g.MeasureString(item.SearchItem.Name(False), item.FontSelected, 0).ToSize.Height,
                    g.MeasureString(item.SearchItem.Name(False), item.Font, 0).ToSize.Height)
                item.Bounds = New Rectangle(p.X, p.Y, r.Width - p.X, Math.Max(imgHeight, textHeight) + 2)
            Else
                item.Bounds = New Rectangle(p.X, p.Y, r.Width - p.X, item.Bounds.Height)
            End If
            If (Not mDoRender) Then Exit Sub

            If item.IsSelected Then
                Select Case selectColMode
                    Case SelectColConstants.Item
                        g.FillRectangle(New SolidBrush(item.BackColorSelected), item.Bounds)
                        g.DrawRectangle(New Pen(item.BackColorSelected), New Rectangle(item.Bounds.Right + 4, item.Bounds.Top, dirDisplayWidth - 8, item.Bounds.Height))
                    Case SelectColConstants.Folder
                        g.DrawRectangle(New Pen(item.BackColorSelected), item.Bounds)
                        g.FillRectangle(New SolidBrush(item.BackColorSelected), New Rectangle(item.Bounds.Right + 4, item.Bounds.Top, dirDisplayWidth - 8, item.Bounds.Height))
                End Select
            End If

            p.X += 16
            g.DrawIcon(item.SearchItem.ItemIcon, p.X, p.Y + 2)
            p.X += (item.SearchItem.ItemIcon.Width + 2)

            Dim rect As Rectangle = New Rectangle(p.X, p.Y + 2 + (imgHeight - textHeight) \ 2, item.Bounds.Width - p.X, item.Bounds.Height)
            If item.IsSelected AndAlso selectColMode = SelectColConstants.Item Then
                g.DrawString(item.SearchItem.Name(False), item.Font, New SolidBrush(item.ForeColorSelected), rect, itemStringFormat)
            Else
                g.DrawString(item.SearchItem.Name(False), item.Font, New SolidBrush(item.ForeColor), rect, itemStringFormat)
            End If

            rect.X = rect.Right + 8
            rect.Width = dirDisplayWidth - 14
            Dim linkTargetDir As String = ""
            If item.SearchItem.IsLink Then linkTargetDir = " » " + item.SearchItem.LinkedFileInfo.Directory.Name
            If item.IsSelected AndAlso selectColMode = SelectColConstants.Folder Then
                g.DrawString(item.SearchItem.FileInfo.Directory.Name + linkTargetDir, item.Font, New SolidBrush(item.ForeColorSelected), rect, itemStringFormat)
            Else
                g.DrawString(item.SearchItem.FileInfo.Directory.Name + linkTargetDir, item.Font, Brushes.DarkOrange, rect, itemStringFormat)
            End If

            If mFirstVisibleItem Is Nothing Then
                mFirstVisibleItem = item
            Else
                mLastVisibleItem = item
            End If
        End If
    End Sub

    Private Sub CollectionChanged(ByVal sender As KLListViewItemsCollection, ByVal reason As KLListViewItemsCollection.ChangeEventConstants) Handles LvItems.Changed
        Select Case reason
            Case KLListViewItemsCollection.ChangeEventConstants.ItemAdded
                mItemsTotalCount += 1
            Case KLListViewItemsCollection.ChangeEventConstants.ItemRemoved
                mItemsTotalCount -= 1
            Case KLListViewItemsCollection.ChangeEventConstants.CollectionCleared
                SelectedItem = Nothing
                mItemsTotalCount = 0
                ReCountItems(LvItems)
            Case KLListViewItemsCollection.ChangeEventConstants.ItemChanged
                'Should call me.invalidate but, somehow, update the item in question only...
                'Me.Invalidate()
                Exit Sub
        End Select

        RepaintControl()
    End Sub

    Private Sub ReCountItems(ByVal parentCol As KLListViewItemsCollection)
        mItemsTotalCount += parentCol.Count

        Try
            For Each item As KLListViewItem In parentCol
                If item.ItemType = KLListViewItem.ItemTypeConstants.Group Then
                    ReCountItems(item.SubItems)
                Else
                    item.IsSelected = False
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub RepaintControl()
        If Not mIsRendering Then Me.Invalidate()
    End Sub

    Public Sub HandleKeyboardNav(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Up, Keys.Down
                MoveUpDown(e.KeyCode)
            Case Keys.PageDown
                For i As Integer = 1 To mItemsVisibleCount \ 2 - 1
                    MoveUpDown(Keys.Down, False)
                Next
                RepaintControl()
            Case Keys.PageUp
                For i As Integer = 1 To mItemsVisibleCount \ 2 - 1
                    MoveUpDown(Keys.Up, False)
                Next
                RepaintControl()
            Case Keys.Left
                If selectColMode = SelectColConstants.Folder Then
                    selectColMode = SelectColConstants.Item
                    RepaintControl()
                End If
                RepaintControl()
            Case Keys.Right
                If selectColMode = SelectColConstants.Item Then
                    selectColMode = SelectColConstants.Folder
                    RepaintControl()
                End If
        End Select
    End Sub

    Public Sub EnsureSelectedItemIsVisible()
        If mSelectedItem IsNot Nothing Then
            MoveUpDown(Keys.Down, False)
            Application.DoEvents()
            MoveUpDown(Keys.Up, False)
        End If
    End Sub

    Private Sub MoveUpDown(ByVal key As Keys, Optional ByVal repaint As Boolean = True)
        If mSelectedItem Is Nothing Then
            For Each c As KLListViewItem In LvItems
                If c.SubItems.Count > 0 Then
                    SelectedItem = c.SubItems(0)

                    RepaintControl()
                    Exit For
                End If
            Next
        Else
            Dim newSel As KLListViewItem = Nothing

            Select Case key
                Case Keys.Down
                    newSel = mSelectedItem.Next
                Case Keys.Up
                    newSel = mSelectedItem.Previous
            End Select

            If newSel IsNot Nothing Then
                mIsRendering = True
                SelectedItem = newSel

                Select Case key
                    Case Keys.Down
                        Do Until mSelectedItem.InView
                            If mSelectedItem.Index(True) >= ScrollPosition Then
                                If Not ScrollDown() Then Exit Do
                            Else
                                If Not ScrollUp() Then Exit Do
                            End If
                            RenderControl(Nothing, Me.ClientRectangle, True)
                        Loop
                    Case Keys.Up
                        Do Until mSelectedItem.InView
                            If mSelectedItem.Index(True) >= ScrollPosition Then
                                If Not ScrollDown() Then Exit Do
                            Else
                                If Not ScrollUp() Then Exit Do
                            End If
                            RenderControl(Nothing, Me.ClientRectangle, True)
                        Loop
                        If VScrollBarItem.Value = 1 Then VScrollBarItem.Value = 0
                End Select

                mIsRendering = False
                If repaint Then RepaintControl()
            End If
        End If
    End Sub

    Private Sub KLListView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SetDirAreaWidth()
    End Sub

    Private Sub SetDirAreaWidth()
        dirDisplayWidth = CInt(Me.Width * (mDirAreaWidth / 100))
    End Sub
End Class

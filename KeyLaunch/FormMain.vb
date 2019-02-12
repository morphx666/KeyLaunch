Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Threading
Imports System.Security.Permissions
Imports System.Runtime.InteropServices

Public Class FormMain
    Friend WithEvents SearchEngineApi As New SearchEngine()
    Private WithEvents KeyboardHookApi As New KbdHookAPI()

    <Flags>
    Private Enum KnownFolderFlag
        None = &H0
        CREATE = &H8000
        DONT_VERFIY = &H4000
        DONT_UNEXPAND = &H2000
        NO_ALIAS = &H1000
        INIT = &H800
        DEFAULT_PATH = &H400
        NOT_PARENT_RELATIVE = &H200
        SIMPLE_IDLIST = &H100
        ALIAS_ONLY = &H80000000
    End Enum

    <DllImport("shell32.dll")>
    Private Shared Function SHGetKnownFolderPath(<MarshalAs(UnmanagedType.LPStruct)> rfid As Guid, dwFlags As Integer, hToken As IntPtr, ByRef pszPath As IntPtr) As Integer
    End Function

    Private confPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\" + My.Application.Info.AssemblyName + "\"

    Delegate Sub delAddNewItem(ByVal searchItem As SearchItem, ByVal category As SearchCategory, ByVal AutoSelect As Boolean)
    Delegate Sub delChangeCatsHeight(ByVal value As Integer)
    Delegate Sub delChangeMainHeight(ByVal value As Integer)

    Private dragClickPos As Point
    Private titleStringFormat As StringFormat
    Private queryStringFormat As StringFormat
    Private searchQuery As String = ""
    Private enqueENTER As Boolean
    Private titleTextArea As Rectangle
    Private mIgnoreFocus As Boolean
    Private mPathsExceptions As List(Of String) = New List(Of String)
    Private mSelExtensions As Dictionary(Of String, SearchCategory)
    Private mSearchSucessful As Boolean
    Private mDontClearList As Boolean
    Private mHasFocus As Boolean
    Private mBottomHandleHeight As Integer = 6

    Private catShortcutFont As Font = New Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Pixel)
    Private catShortcutNameBrush As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.ControlDark))
    Private catAllCatsFont As Font = New Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Pixel)
    Private catAllCatsStringFormat As StringFormat = New StringFormat
    Private catAllCatsColor As SolidBrush
    Private catAllCatsShortcutColor As SolidBrush
    Private catTabDarkColor As SolidBrush = New SolidBrush(Color.FromArgb(80, 80, 80))

    Private Enum MouseModeConstants
        Normal = 0
        Dragging = 1
        ResizingHorizontally = 2
        ResizingVertically = 3
        ResizingDirArea = 4
    End Enum
    Private mouseMode As MouseModeConstants = MouseModeConstants.Normal

    Private Enum ExpColConstants
        Abort = 666
        Expanding = 1
        Collapsing = 2
        Expanded = 3
        Collapsed = 4
    End Enum

    Private threadExpColCats As Thread
    Private catsExpColMode As ExpColConstants = ExpColConstants.Collapsed
    Private catsAnimSpeed As Integer
    Private catsMaxHeight As Integer
    Private selCategoryLVIndex As Integer
    Private selCategory As SearchCategory
    Private selCategoryName As String = "All Categories"

    Private threadExpColMain As Thread
    Private mainExpColMode As ExpColConstants = ExpColConstants.Collapsed
    Private mainAnimSpeed As Integer
    Private lastCatsMode As ExpColConstants
    Private resetSearchStateTimer As Timer

    Private titleRect1 As Rectangle
    Private titleRect2 As Rectangle
    Private titleBrush1 As Drawing2D.LinearGradientBrush
    Private titleBrush2 As Drawing2D.LinearGradientBrush
    Private titlePen1 As Pen

    Private bottomRect1 As Rectangle
    Private bottomRect2 As Rectangle
    Private bottomBrush1 As Drawing2D.LinearGradientBrush
    Private bottomBrush2 As Drawing2D.LinearGradientBrush

    Private Enum SearchStateConstants
        Idle = 0
        Searching = 1
    End Enum
    Private mSearchState As SearchStateConstants

    <Serializable()>
    Friend Structure PreferencesDef
        Dim hotKey As Keys
        Dim retypeDelay As Integer
        Dim showTrayIcon As Boolean
        Dim startWithWindows As Boolean
        Dim hideOnFocusLost As Boolean

        Dim mainColor As HLSRGB

        Dim mainWindowLocation As Point
        Dim mainWindowSize As Size
        Dim mainMaxHeight As Integer
        Dim mainTitleHeight As Integer
        Dim mainFontHeight As Integer

        Dim filesDirWidthPercenrage As Integer

        Dim setupWindowLocation As Point
        Dim setupWindowSize As Size
        Dim setupWindowPathsSplitter As Integer
        Dim setupWindowCategoriesSplitter As Integer
        Dim setupListViewFoldersSelCol As Integer
        Dim setupListViewFoldersSelColSortOrder As SortOrder
        Dim setupListViewCategoriesSelCol As Integer
        Dim setupListViewCategoriesSelColSortOrder As SortOrder
        Dim setupListViewExtensionsSelCol As Integer
        Dim setupListViewExtensionsSelColSortOrder As SortOrder

        Dim optionsWindowLocation As Point
        Dim optionsWindowSize As Size

        Dim cachedResults As Dictionary(Of String, Object())

        Dim KLVersion As Version
    End Structure
    Friend Preferences As PreferencesDef

    Private Const ValidChars As String = "!#$%&()+,-"

#Region "frmMain Events"
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 0
        Me.Visible = False
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.DoubleBuffered = True
        Me.TransparencyKey = Me.BackColor
        Me.TopMost = True
        Me.ShowInTaskbar = False

        Me.MinimumSize = New Size(200, 0)
        Me.MaximumSize = New Size(Screen.GetWorkingArea(Me).Width, Screen.GetWorkingArea(Me).Height \ 2)

        titleStringFormat = New StringFormat(StringFormatFlags.LineLimit) With {.Trimming = StringTrimming.EllipsisCharacter}
        queryStringFormat = New StringFormat With {.Alignment = StringAlignment.Far}

        pnlCats.BackColor = Color.LightSlateGray
        pnlCats.Height = 0
        ListViewCats.Columns(0).Width = ListViewCats.Width - 4
        Dim catsFont As Font = New Font(Me.Font.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)
        ListViewCats.Font = catsFont
        Dim imgList As ImageList = New ImageList With {.ImageSize = New Size(1, 24)}
        ListViewCats.SmallImageList = imgList
        catAllCatsStringFormat.Alignment = StringAlignment.Center

        ListViewFiles.AllowDrop = True

        threadExpColCats = New Thread(AddressOf ExpandCollapseCats)
        threadExpColCats.Start()

        threadExpColMain = New Thread(AddressOf ExpandCollapseMain)
        threadExpColMain.Start()

        LoadKLPreferences()
        LoadSearchPreferences()
        CreateCategoriesTab()

        mSearchState = SearchStateConstants.Idle
        resetSearchStateTimer = New Timer(New TimerCallback(AddressOf ResetSearchState), Nothing, Timeout.Infinite, Timeout.Infinite)
#If Not DEBUG Then
        KeyboardHookApi.HookKeyboard()
#Else
        AddHandler Me.KeyDown, AddressOf HandleKeyDown
        AddHandler ListViewFiles.KeyDown, AddressOf HandleKeyDown
#End If
    End Sub

    Private Sub FormMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        mHasFocus = True
        If mainExpColMode = ExpColConstants.Expanding Then
            mainExpColMode = ExpColConstants.Expanded
            SetMainColor()
            mainExpColMode = ExpColConstants.Expanding
        Else
            SetMainColor()
        End If
        Me.Invalidate()

        If mainExpColMode = ExpColConstants.Expanded Then KeyboardHookApi.CaptureAllKeys = True
    End Sub

    Private Sub FormMain_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        mHasFocus = mIgnoreFocus
        If Me.Visible Then
            SetMainColor()
            Me.Invalidate()

            If mHasFocus = False AndAlso mainExpColMode = ExpColConstants.Expanded Then
                If Me.Preferences.hideOnFocusLost Then ToggleExpColMain()
            End If
            KeyboardHookApi.CaptureAllKeys = False
        End If
    End Sub

    Private Sub FormMain_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                If e.Y <= Preferences.mainTitleHeight Then
                    If e.X < 10 Then
                        mouseMode = MouseModeConstants.ResizingHorizontally
                    Else
                        If e.X >= Me.Width - 30 And e.X <= Me.Width - 18 Then
                            ContextMenuMain.Show(Me, New Point(Me.Width - 20 - 8, Preferences.mainTitleHeight))
                        Else
                            mouseMode = MouseModeConstants.Dragging
                        End If
                    End If
                Else
                    If (e.Y >= ListViewFiles.Top AndAlso e.Y <= ListViewFiles.Bottom) Then
                        Dim d As Integer = CInt(ListViewFiles.Right - ListViewFiles.ScrollbarWidth - ListViewFiles.Width * (ListViewFiles.DirAreaWidthPercentage / 100))
                        If e.X >= d - 1 And e.X <= d + 2 Then
                            mouseMode = MouseModeConstants.ResizingDirArea
                        End If
                    Else
                        If e.Y >= pnlCats.Bottom And e.Y <= pnlCats.Bottom + 30 Then
                            If e.X >= pnlCats.Left And e.X <= pnlCats.Right Then
                                ToggleExpColCats()
                            End If
                        Else
                            If (e.Y >= ListViewFiles.Bottom AndAlso e.Y <= Me.Height) AndAlso (e.X >= ListViewFiles.Left AndAlso e.X <= ListViewFiles.Right) Then
                                mouseMode = MouseModeConstants.ResizingVertically
                            End If
                        End If
                    End If
                End If
                dragClickPos = New Point(e.X, e.Y)
            Case Windows.Forms.MouseButtons.Right
                If e.Y <= Preferences.mainTitleHeight Then ContextMenuMain.Show(Me, e.X, e.Y)
        End Select
    End Sub

    Private Sub FormMain_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Select Case mouseMode
            Case MouseModeConstants.Dragging
                Dim newLeft As Integer = Me.Left + (e.X - dragClickPos.X)
                Dim sWidth As Integer = Screen.GetWorkingArea(Me).Width
                If newLeft < 0 Then newLeft = 0
                If newLeft + Me.Width > sWidth Then newLeft = sWidth - Me.Width
                Me.Left = newLeft
            Case MouseModeConstants.ResizingHorizontally
                Dim newLeft As Integer = Me.Left + (e.X - dragClickPos.X)
                If newLeft < 0 Then newLeft = 0
                Dim newWidth As Integer = Me.Width + (Me.Left - newLeft)
                Me.Left = newLeft
                Me.Width = newWidth
            Case MouseModeConstants.ResizingVertically
                Dim newHeight As Integer = Me.Height + (e.Y - dragClickPos.Y)
                If newHeight > 100 Then
                    SetMainHeight(newHeight)
                    dragClickPos.Y = e.Y
                End If
            Case MouseModeConstants.ResizingDirArea
                ListViewFiles.DirAreaWidthPercentage = CInt((ListViewFiles.Right - ListViewFiles.ScrollbarWidth - e.X) / ListViewFiles.Width * 100)
            Case MouseModeConstants.Normal
                If e.Y <= 20 Then
                    Me.Cursor = If(e.X < 10,
                                    Cursors.SizeWE,
                                    If(e.X >= Me.Width - 30 And e.X <= Me.Width - 18,
                                        Cursors.Hand,
                                        Cursors.Default))
                Else
                    If (e.Y >= ListViewFiles.Top AndAlso e.Y <= ListViewFiles.Bottom) Then
                        Dim d As Integer = CInt(ListViewFiles.Right - ListViewFiles.ScrollbarWidth - ListViewFiles.Width * (ListViewFiles.DirAreaWidthPercentage / 100))
                        Me.Cursor = If(e.X >= d - 1 And e.X <= d + 2,
                                        Cursors.VSplit,
                                        Cursors.Default)
                    Else
                        Me.Cursor = If((e.Y >= ListViewFiles.Bottom AndAlso e.Y <= Me.Height),
                                        Cursors.SizeNS,
                                        Cursors.Default)
                    End If
                End If
        End Select
    End Sub

    Private Sub FormMain_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        mouseMode = MouseModeConstants.Normal
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FormMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If ListViewFiles.Bottom > Me.Height - (mBottomHandleHeight + 2) Then
            ListViewFiles.Height = Me.Height - (mBottomHandleHeight + 2) - ListViewFiles.Top
        End If

        SetMainColor() 'SetRects()
    End Sub

    Private Sub FormMain_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        'e.Graphics.Clear(Me.BackColor)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        If e.ClipRectangle.Height > Preferences.mainTitleHeight Then RenderCategoriesTab(e.Graphics)
        RenderTitleSection(e.Graphics)
        RenderSearchQuery(e.Graphics)
        RenderSelectedItem(e.Graphics)
        If e.ClipRectangle.Height > Preferences.mainTitleHeight Then RenderBottom(e.Graphics)
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("Are you sure you want to exit KeyLaunch?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirm Exit KeyLaunch") = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        StopResetSearchTimer()
        KeyboardHookApi.UnhookKeyboard()
        SearchEngineApi.Abort()

        catsExpColMode = ExpColConstants.Abort
        mainExpColMode = ExpColConstants.Abort

        SaveKLPreferences()
        SaveSearchPreferences()

        catShortcutFont.Dispose()
        catShortcutNameBrush.Dispose()

        DisposeMainBrushes()

        catAllCatsFont.Dispose()
        catAllCatsStringFormat.Dispose()
        queryStringFormat.Dispose()
        titleStringFormat.Dispose()
        catTabDarkColor.Dispose()
    End Sub
#End Region

#Region "Painting Routines"
    Private Sub RepaintTitleArea()
        Me.Invalidate(New Region(New Rectangle(0, 0, Width, Preferences.mainTitleHeight)), False)
    End Sub

    Private Sub RenderCategoriesTab(ByVal g As Graphics)
        FillRoundedRectangle(g, pnlCats.Left - 1, 0, pnlCats.Width + 2, pnlCats.Height + 40 + 1, 15, catTabDarkColor)
        FillRoundedRectangle(g, pnlCats.Left, 0, pnlCats.Width, pnlCats.Height + 40, 15, catAllCatsColor)
        DrawShadowedText(g, selCategoryName,
                            catAllCatsFont, Color.White,
                            New Rectangle(pnlCats.Left, pnlCats.Bottom + 5, pnlCats.Width, 30), catAllCatsStringFormat)

        g.DrawString("F12", catShortcutFont, catAllCatsShortcutColor, pnlCats.Right - 16, pnlCats.Bottom + 2)
    End Sub

    Private Sub RenderTitleSection(ByVal g As Graphics)
        With g
            .FillRectangle(titleBrush1, titleRect1)
            .FillRectangle(titleBrush2, titleRect2)

            Dim r As Rectangle = titleRect2
            r.X = 0
            r.Y = -4
            r.Height = Preferences.mainTitleHeight + 2
            r.Width = Width
            DrawRoundedRectangle(g, r.X + 1, r.Y, r.Width - 3, r.Height, 9, titlePen1)

            r.Y = -4
            r.Height = Preferences.mainTitleHeight + 3
            DrawRoundedRectangle(g, r.X, r.Y, r.Width - 1, r.Height, 9, Pens.Black)

            .DrawLine(New Pen(titleBrush2.LinearColors(1)), titleRect1.X, titleRect1.Bottom - 1, titleRect1.Width, titleRect1.Bottom - 1)

            .DrawImage(My.Resources.LegendHS, r.Right - 26, titleTextArea.Y, 16, 16)

            r = New Rectangle(r.Right - 34, titleTextArea.Y + 1, r.Right - 34, titleTextArea.Height - 2 * (titleTextArea.Y + 1))
            .DrawLine(New Pen(Color.FromArgb(128, 55, 55, 55)), r.X, r.Y, r.X, r.Height)
            r.X += 1
            .DrawLine(New Pen(Color.FromArgb(128, 230, 230, 230)), r.X, r.Y, r.X, r.Height)
        End With
    End Sub

    Private Sub RenderSearchQuery(ByVal g As Graphics)
        Dim c As Color
        Select Case mSearchState
            Case SearchStateConstants.Searching
                c = Color.Cyan
            Case SearchStateConstants.Idle
                c = Color.LightBlue
        End Select
        DrawShadowedText(g, searchQuery.Replace(" ", " + "), Me.Font, c, titleTextArea, queryStringFormat)
    End Sub

    Private Sub RenderSelectedItem(ByVal g As Graphics)
        With g
            Dim text As String
            If ListViewFiles.SelectedItem IsNot Nothing Then
                text = ListViewFiles.SelectedItem.SearchItem.Name(False)
                .DrawIcon(ListViewFiles.SelectedItem.SearchItem.ItemIcon, 14, titleTextArea.Y)
            Else
                text = "KeyLaunch 3.0"
                .DrawImage(My.Resources.ql, New Rectangle(14, titleTextArea.Y, 16, 16))
            End If
            Dim rect As Rectangle = titleTextArea
            rect.Width -= CInt(.MeasureString(searchQuery, Me.Font, 0).Width + 32)
            DrawShadowedText(g, text, Me.Font, Color.White, rect, titleStringFormat)
        End With
    End Sub

    Private Sub RenderBottom(ByVal g As Graphics)
        With g
            .FillRectangle(bottomBrush1, bottomRect1)
            .FillRectangle(bottomBrush2, bottomRect2)

            If SearchEngineApi.Progess > 0 Then
                'Using b = New SolidBrush(Color.FromArgb(128, Preferences.mainColor))
                Using b = New SolidBrush(Color.FromArgb(128, Color.Red))
                    Dim r As Rectangle = New Rectangle(bottomRect1.Left, bottomRect1.Top, bottomRect1.Width, bottomRect1.Height + bottomRect2.Height)
                    .FillRectangle(b, r.X, r.Y, CInt(r.Width * (SearchEngineApi.Progess / 100)), r.Height)
                End Using
            End If

            DrawRoundedRectangle(g, bottomRect1.X - 1, bottomRect1.Y - 3, bottomRect1.Width + 2, mBottomHandleHeight + 4, 8, Pens.DarkGray)
            .DrawLine(New Pen(titleBrush2.LinearColors(1)), bottomRect2.X + 2, bottomRect2.Bottom - 2, bottomRect2.Right - 4, bottomRect2.Bottom - 2)
        End With
    End Sub

    Private Sub DrawShadowedText(ByVal g As Graphics, ByVal text As String, ByVal font As Font, ByVal color As Color, ByVal area As Rectangle, ByVal stringFormat As StringFormat)
        Dim c As HLSRGB = New HLSRGB(color)
        If mHasFocus = False Then c.Luminance -= 0.2F

        g.DrawString(text, font, Brushes.Black, area, stringFormat)
        area.X -= 1
        area.Y -= 1
        g.DrawString(text, font, New SolidBrush(c.Color), area, stringFormat)
    End Sub

    Private Sub SetBottomRects()
        bottomRect1 = New Rectangle(ListViewFiles.Left + 1, ListViewFiles.Bottom - 1, ListViewFiles.Width - 3, CInt(mBottomHandleHeight / 1.5))
        bottomRect2 = New Rectangle(bottomRect1.Left, bottomRect1.Bottom, bottomRect1.Width, mBottomHandleHeight - bottomRect1.Height)
    End Sub

    Private Sub SetRects()
        Using g As Graphics = Me.CreateGraphics
            Preferences.mainFontHeight = g.MeasureString("gW", Me.Font, 0, StringFormat.GenericTypographic).ToSize.Height + 3
        End Using

        titleRect1 = New Rectangle(1, 0, Me.Width - 2, CInt((Preferences.mainTitleHeight - 2) / 2.33F))
        titleRect2 = titleRect1
        titleRect2.Y = titleRect1.Bottom
        titleRect2.Height = (Preferences.mainTitleHeight - 2) - titleRect1.Height
        SetBottomRects()
    End Sub

    Friend Sub SetMainColor(ByVal color As Color)
        If Not (mainExpColMode = ExpColConstants.Collapsing Or mainExpColMode = ExpColConstants.Expanding) Then
            Preferences.mainColor = New HLSRGB(color)

            Dim firstColor As HLSRGB
            Dim secondColor As HLSRGB
            Dim tmpColor As HLSRGB = New HLSRGB(color)

            DisposeMainBrushes()
            SetRects()

            titlePen1 = New Pen(color)

            ' Title section
            firstColor = New HLSRGB(color)
            If mHasFocus = False Then firstColor.Saturation /= 3
            secondColor = New HLSRGB(firstColor)
            secondColor.DarkenColor(0.777)
            titleBrush1 = New Drawing2D.LinearGradientBrush(titleRect1, firstColor.Color, secondColor.Color, Drawing2D.LinearGradientMode.Vertical)
            tmpColor = New HLSRGB(firstColor)
            tmpColor.LightenColor(0.4)
            bottomBrush1 = New Drawing2D.LinearGradientBrush(bottomRect1, tmpColor.Color, secondColor.Color, Drawing2D.LinearGradientMode.Vertical)
            firstColor.DarkenColor(0.58)
            secondColor = New HLSRGB(firstColor)
            secondColor.LightenColor(0.43)
            titleBrush2 = New Drawing2D.LinearGradientBrush(titleRect2, firstColor.Color, secondColor.Color, Drawing2D.LinearGradientMode.Vertical)
            bottomBrush2 = New Drawing2D.LinearGradientBrush(bottomRect2, firstColor.Color, secondColor.Color, Drawing2D.LinearGradientMode.Vertical)

            ' Categories section
            tmpColor = New HLSRGB(color)
            tmpColor.DarkenColor(0.5)
            catAllCatsColor = New SolidBrush(tmpColor.Color)

            tmpColor.LightenColor(0.8)
            catAllCatsShortcutColor = New SolidBrush(tmpColor.Color)
        Else
            SetBottomRects()
        End If
    End Sub

    Private Sub SetMainColor()
        If Preferences.mainColor Is Nothing Then Exit Sub
        SetMainColor(Preferences.mainColor.Color)
    End Sub
#End Region

#Region "Main Menu Handling"
    Private Sub ContextMenuMain_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuMain.Opening
        ContextMenuMainOpenKeyLaunch.Visible = (mainExpColMode = ExpColConstants.Collapsed)
        ContextMenuMainSep01.Visible = (mainExpColMode = ExpColConstants.Collapsed)
    End Sub

    Private Sub ContextMenuMainSearchPreferences_Click(sender As Object, e As EventArgs) Handles ContextMenuMainSearchPreferences.Click
        Dim f As FormSetup = New FormSetup

        mDontClearList = True
        SearchEngineApi.Abort()

        SaveSearchPreferences()
        If f.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            LoadSearchPreferences()
        Else
            ResetKLListView(True)
        End If

        Me.TopMost = True
        UpdateCacheAndShortcuts()
    End Sub

    Private Sub ContextMenuMainExit_Click(sender As Object, e As EventArgs) Handles ContextMenuMainExit.Click
        Me.Close()
    End Sub

    Private Sub ContextMenuMainOptions_Click(sender As Object, e As EventArgs) Handles ContextMenuMainOptions.Click
        Dim f As New FormOptions()

        mDontClearList = True
        SearchEngineApi.Abort()

        SaveKLPreferences()
        mIgnoreFocus = True
        If f.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            LoadKLPreferences()
        Else
            SetKLPreferences()
        End If
        mIgnoreFocus = False
    End Sub

    Private Sub ContextMenuMainOpenKeyLaunch_Click(sender As Object, e As EventArgs) Handles ContextMenuMainOpenKeyLaunch.Click
        ShowKL(False)
    End Sub

    Private Sub ContextMenuMainAbout_Click(sender As Object, e As EventArgs) Handles ContextMenuMainAbout.Click
        Dim f As FormAbout = New FormAbout

        mDontClearList = True
        SearchEngineApi.Abort()

        f.ShowDialog()
    End Sub
#End Region

#Region "Expanding/Collapsing Routines"
    Private Sub ToggleExpColCats()
        Select Case catsExpColMode
            Case ExpColConstants.Collapsed, ExpColConstants.Collapsing
                ListViewCats.Items(selCategoryLVIndex).Selected = True
                ListViewCats.Focus()
                catsAnimSpeed = 1
                catsExpColMode = ExpColConstants.Expanding
            Case ExpColConstants.Expanded, ExpColConstants.Expanding
                catsAnimSpeed = 1
                catsExpColMode = ExpColConstants.Collapsing
        End Select
    End Sub

    Private Sub ToggleExpColMain()
        Select Case mainExpColMode
            Case ExpColConstants.Collapsed, ExpColConstants.Collapsing
                mainAnimSpeed = 1
                mainExpColMode = ExpColConstants.Expanding
                KeyboardHookApi.CaptureAllKeys = True
                Me.Focus()
                ListViewFiles.SelectionColumnMode = KLListView.SelectColConstants.Item
            Case ExpColConstants.Expanded, ExpColConstants.Expanding
                mainAnimSpeed = 1
                mainExpColMode = ExpColConstants.Collapsing
                SearchEngineApi.Abort()
                lastCatsMode = catsExpColMode
                If catsExpColMode = ExpColConstants.Expanded Then ToggleExpColCats()
                KeyboardHookApi.CaptureAllKeys = False
        End Select
    End Sub

    Private Sub ExpandCollapseCats()
        Do
            Thread.Sleep(15)
            Select Case catsExpColMode
                Case ExpColConstants.Collapsing
                    If pnlCats.Height > 0 Then
                        pnlCats.Invoke(New delChangeCatsHeight(AddressOf ChangeCatsHeight), New Object() {pnlCats.Height - catsAnimSpeed})
                    Else
                        catsExpColMode = ExpColConstants.Collapsed
                        pnlCats.Invoke(New delChangeCatsHeight(AddressOf ChangeCatsHeight), New Object() {0})
                    End If
                Case ExpColConstants.Expanding
                    If pnlCats.Height < catsMaxHeight Then
                        pnlCats.Invoke(New delChangeCatsHeight(AddressOf ChangeCatsHeight), New Object() {pnlCats.Height + catsAnimSpeed})
                    Else
                        catsExpColMode = ExpColConstants.Expanded
                        pnlCats.Invoke(New delChangeCatsHeight(AddressOf ChangeCatsHeight), New Object() {catsMaxHeight})
                    End If
                Case ExpColConstants.Abort
                    Exit Do
            End Select
        Loop
    End Sub

    Private Sub ExpandCollapseMain()
        Do
            Thread.Sleep(15)
            Select Case mainExpColMode
                Case ExpColConstants.Collapsing
                    If Me.Height > 4 Then
                        Me.Invoke(New delChangeMainHeight(AddressOf ChangeMainHeight), New Object() {Me.Height - mainAnimSpeed})
                    Else
                        mainExpColMode = ExpColConstants.Collapsed
                        Me.Invoke(New delChangeMainHeight(AddressOf ChangeMainHeight), New Object() {0})
                    End If
                Case ExpColConstants.Expanding
                    If Me.Height < Preferences.mainMaxHeight Then
                        Me.Invoke(New delChangeMainHeight(AddressOf ChangeMainHeight), New Object() {Me.Height + mainAnimSpeed})
                    Else
                        mainExpColMode = ExpColConstants.Expanded
                        Me.Invoke(New delChangeMainHeight(AddressOf ChangeMainHeight), New Object() {Preferences.mainMaxHeight})
                    End If
                Case ExpColConstants.Abort
                    Exit Do
            End Select
        Loop
    End Sub

    Private Sub ChangeMainHeight(ByVal value As Integer)
        Me.Height = value
        mainAnimSpeed += 2

        Select Case mainExpColMode
            Case ExpColConstants.Expanded
                Me.Activate()
                ListViewFiles.Focus()
                If lastCatsMode = ExpColConstants.Expanded Then ToggleExpColCats()
            Case ExpColConstants.Collapsed
                Me.Visible = False
        End Select
    End Sub

    Private Sub ChangeCatsHeight(ByVal value As Integer)
        pnlCats.Height = value
        catsAnimSpeed += 2
        Me.Invalidate(New Region(New Rectangle(0, ListViewCats.Top, ListViewFiles.Left, ListViewCats.Height + 80)), False)

        If catsExpColMode = ExpColConstants.Collapsed Then ListViewFiles.Focus()
    End Sub

    Private Sub SetMainHeight(ByVal h As Integer)
        If h < 100 Then h = 100
        Me.Height = h
        Preferences.mainMaxHeight = Me.Height
    End Sub
#End Region

#Region "Searching Routines"
    Private Sub RemoveLastCharFromQuery()
        If searchQuery.Length > 0 Then
            searchQuery = searchQuery.Substring(0, searchQuery.Length - 1)
            DoSearch()
        End If
    End Sub

    Private Sub LaunchSelectedItem()
        If ListViewFiles.SelectedItem Is Nothing Then
            enqueENTER = True
        Else
            If SearchEngineApi.State = KeyLaunch.SearchEngine.StateConstants.Searching Then
                mDontClearList = True
                SearchEngineApi.Abort()
            End If

            Select Case ListViewFiles.SelectionColumnMode
                Case KLListView.SelectColConstants.Item
                    If Preferences.cachedResults.ContainsKey(searchQuery) Then
                        Preferences.cachedResults(searchQuery) = New Object() {ListViewFiles.SelectedItem.SearchItem, ListViewFiles.SelectedItem.Parent.CategoryItem}
                    Else
                        Preferences.cachedResults.Add(searchQuery, New Object() {ListViewFiles.SelectedItem.SearchItem, ListViewFiles.SelectedItem.Parent.CategoryItem})
                    End If
                    ListViewFiles.SelectedItem.Launch()
                Case KLListView.SelectColConstants.Folder
                    If ListViewFiles.SelectedItem.SearchItem.IsLink Then
                        Dim linkedFile As IO.FileInfo = ListViewFiles.SelectedItem.SearchItem.ResolveLink()
                        If linkedFile IsNot Nothing Then
                            KLListViewItem.OpenContainingFolder(linkedFile.DirectoryName)
                        End If
                    Else
                        ListViewFiles.SelectedItem.OpenContainingFolder()
                    End If
            End Select

            ToggleExpColMain()
        End If
    End Sub

    Private Sub StartResetSearchTimer()
        resetSearchStateTimer.Change(2000, Timeout.Infinite)
    End Sub

    Private Sub StopResetSearchTimer()
        resetSearchStateTimer.Change(Timeout.Infinite, Timeout.Infinite)
    End Sub

    Private Sub ResetSearchState(ByVal state As Object)
        StopResetSearchTimer()
        mSearchState = SearchStateConstants.Idle
        RepaintTitleArea()
    End Sub

    Private Sub ResetKLListView(Optional ByVal resetCategories As Boolean = False)
        mSearchSucessful = False
        ListViewFiles.ScrollPosition = 0
        If ListViewFiles.Items.Count = 0 OrElse resetCategories Then
            ListViewFiles.Items.Clear()

            Dim category As KLListViewItem
            For Each c As SearchCategory In SearchEngineApi.Categories
                category = New KLListViewItem(c, Nothing, ListViewFiles) With {.ForeColor = Color.DarkGray}

                ListViewFiles.Items.Add(category)
            Next
        Else
            For Each lvi As KLListViewItem In ListViewFiles.Items
                lvi.SubItems.Clear()
            Next
        End If
    End Sub

    Private Sub SearchEngine_Done() Handles SearchEngineApi.Done
        If Not mSearchSucessful Then
            StopResetSearchTimer()
            mSearchState = SearchStateConstants.Searching
            RemoveLastCharFromQuery()
        Else
            StartResetSearchTimer()
        End If
        Me.Invalidate()
    End Sub

    Private Sub SearchEngine_Aborted() Handles SearchEngineApi.Aborted
        If mDontClearList Then
            mDontClearList = False
        Else
            ResetKLListView()
        End If
        DoSearch()
    End Sub

    Private Sub SearchEngine_MatchFound(ByVal searchItem As SearchItem, ByVal category As SearchCategory) Handles SearchEngineApi.MatchFound
        ListViewFiles.Invoke(New delAddNewItem(AddressOf AddNewItem), New Object() {searchItem, category, False})
    End Sub

    Private Sub AddNewItem(ByVal searchItem As SearchItem, ByVal category As SearchCategory, ByVal autoSelect As Boolean)
        Static lastCategoryName As String
        Static lastListViewItem As KLListViewItem

        mSearchSucessful = True

        If lastCategoryName <> category.Name Then
            For Each c As KLListViewItem In ListViewFiles.Items
                If c.CategoryItem.Name = category.Name Then
                    lastCategoryName = category.Name
                    lastListViewItem = c
                    Exit For
                End If
            Next
        End If

        ' Prevent duplicates
        For Each item As KLListViewItem In lastListViewItem.SubItems
            If item.SearchItem.FileInfo.FullName = searchItem.FileInfo.FullName Then Exit Sub
        Next

        Dim newItem As KLListViewItem = New KLListViewItem(searchItem, lastListViewItem) With {.ForeColor = category.Color}
        lastListViewItem.SubItems.Add(newItem)

        If autoSelect Then
            ListViewFiles.SelectedItem = newItem
            If enqueENTER Then
                enqueENTER = False
                LaunchSelectedItem()
            End If
        End If
    End Sub

    Private Sub DoSearch()
        If SearchEngineApi.State = SearchEngine.StateConstants.Idle Then
            ResetKLListView()

            If Preferences.cachedResults.ContainsKey(searchQuery) Then
                Dim obj() As Object = Preferences.cachedResults(searchQuery)
                Dim si As SearchItem = New SearchItem(CType(obj(0), SearchItem).FileInfo)
                If si.Exists Then
                    AddNewItem(si, CType(obj(1), SearchCategory), True)
                Else
                    Preferences.cachedResults.Remove(searchQuery)
                End If
            End If
            SearchEngineApi.StartNewSearch(searchQuery, mPathsExceptions, mSelExtensions, selCategory)
        Else
            SearchEngineApi.Abort()
        End If
    End Sub
#End Region

#Region "Keyboard Handling"
    Public Sub HandleKeyDown(sender As Object, e As KeyEventArgs)
        Dim key As Keys = e.KeyCode
        Select Case key
            Case (Preferences.hotKey And Keys.KeyCode)
                If (Preferences.hotKey And Keys.Modifiers) = e.Modifiers Then
                    Me.Visible = True
                    ToggleExpColMain()
                    Me.Focus()
                End If
            Case Keys.F4
                If e.Modifiers = Keys.Alt Then Me.Close()
            Case Keys.Space
                searchQuery += " "
            Case Keys.Back
                RemoveLastCharFromQuery()
            Case Keys.Delete
                searchQuery = ""
                SearchEngineApi.Abort()
                ResetKLListView()
            Case Keys.F12
                If e.Control Then
                    ListViewCats.Items(0).Selected = True
                    SelectCategory()
                    ShowKL(False)
                Else
                    If mainExpColMode = ExpColConstants.Expanded Then ToggleExpColCats()
                End If
            Case Keys.Escape
                If mainExpColMode = ExpColConstants.Expanded Then ToggleExpColMain()
            Case Keys.Enter
                LaunchSelectedItem()
                Exit Sub
#If DEBUG Then
            Case Keys.Up
                If e.Control Then SetMainHeight(Me.Height - 20)
            Case Keys.Down
                If e.Control Then SetMainHeight(Me.Height + 20)
            Case Keys.Left
                If e.Control Then ListViewFiles.DirAreaWidthPercentage += 5
            Case Keys.Right
                If e.Control Then ListViewFiles.DirAreaWidthPercentage -= 5

#Else
            Case Keys.Up
                SetMainHeight(Me.Height - 20)
            Case Keys.Down
                SetMainHeight(Me.Height + 20)
            Case Keys.Left
                ListViewFiles.DirAreaWidthPercentage += 5
            Case Keys.Right
                ListViewFiles.DirAreaWidthPercentage -= 5
#End If
            Case Else
                If e.Control Or e.Shift Or e.Alt Then
                    For i As Integer = 0 To SearchEngineApi.Categories.Count - 1
                        If (SearchEngineApi.Categories(i).ShortCut And Keys.KeyCode) = key AndAlso (SearchEngineApi.Categories(i).ShortCut And Keys.Modifiers) = e.Modifiers Then
                            ListViewCats.Items(i + 1).Selected = True
                            SelectCategory()
                            ShowKL(False)
                            Exit Sub
                        End If
                    Next
                    Exit Sub
                End If

                Dim keyVal As Integer = e.KeyValue
                If keyVal > 122 Then
                    Select Case e.KeyCode
                        Case Keys.OemBackslash
                            keyVal = Asc("-")
                        Case Keys.OemCloseBrackets
                            keyVal = Asc("]")
                        Case Keys.Oemcomma
                            keyVal = Asc(",")
                        Case Keys.OemMinus
                            keyVal = Asc("-")
                        Case Keys.OemOpenBrackets
                            keyVal = Asc("[")
                        Case Keys.Oemtilde
                            keyVal = Asc("'")
                    End Select
                End If

                Dim c As Char = Chr(keyVal)
                If Char.IsLetterOrDigit(c) OrElse ValidChars.Contains(c) Then
                    If mSearchState = SearchStateConstants.Idle Then
                        StopResetSearchTimer()
                        mSearchState = SearchStateConstants.Searching
                        searchQuery = ""
                    End If
                    searchQuery += c
                    DoSearch()
                End If
        End Select

        If enqueENTER Then enqueENTER = False
        RepaintTitleArea()
    End Sub

    Private Sub KeyboardHookApi_KeyDown(ByVal e As KeyEventArgs) Handles KeyboardHookApi.KeyDown
        Me.Visible = True

        If ListViewCats.Focused Then
            Select Case e.KeyCode
                Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.PageDown, Keys.PageUp
                    ListViewCats.HandleKeyNav(e)
                Case Keys.Enter
                    SelectCategory()
                Case Keys.Escape
                    catsExpColMode = ExpColConstants.Collapsing
                Case Else
                    HandleKeyDown(Me, e)
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.PageDown, Keys.PageUp
                    If e.Control Then
                        HandleKeyDown(Me, e)
                    Else
                        ListViewFiles.HandleKeyboardNav(Me, e)
                    End If
                Case Else
                    HandleKeyDown(Me, e)
            End Select
        End If
    End Sub
#End Region

#Region "Categories Handling"
    Private Sub CreateCategoriesTab()
        ListViewCats.VirtualListSize = SearchEngineApi.Categories.Count + 1
        catsMaxHeight = ListViewCats.GetItemRect(0).Height * ListViewCats.VirtualListSize + ListViewCats.VirtualListSize
    End Sub

    Private Sub SelectCategory()
        If selCategoryLVIndex <> ListViewCats.SelectedIndices(0) Then
            selCategoryLVIndex = ListViewCats.SelectedIndices(0)
            If selCategoryLVIndex = 0 Then
                selCategory = Nothing
                selCategoryName = "All Categories"
            Else
                selCategory = SearchEngineApi.Categories(selCategoryLVIndex - 1)
                selCategoryName = selCategory.Name
            End If

            CacheExtensions()
            If searchQuery <> "" Then
                Select Case SearchEngineApi.State
                    Case SearchEngine.StateConstants.Idle
                        ResetKLListView()
                        DoSearch()
                    Case SearchEngine.StateConstants.Searching
                        SearchEngineApi.Abort()
                End Select
            End If
        End If
        catsExpColMode = ExpColConstants.Collapsing
    End Sub

    Private Sub ListViewCats_DoubleClick(sender As Object, e As EventArgs) Handles ListViewCats.DoubleClick
        SelectCategory()
    End Sub

    Private Sub ListViewCats_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListViewCats.DrawItem
        If ListViewCats.SelectedIndices.Count = 0 Then Exit Sub

        Dim isSelected As Boolean = (ListViewCats.SelectedIndices(0) = e.ItemIndex)
        Dim backColor As SolidBrush
        Dim foreColor As SolidBrush
        Dim shortcutName As String = ""
        Dim shortcutNameSize As Size
        Dim itemSize As Size = e.Graphics.MeasureString(e.Item.Text, e.Item.Font, 0).ToSize
        Dim g As Graphics = e.Graphics

        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        shortcutName = If(e.ItemIndex = 0,
                "Control + F12",
                SearchEngineApi.Categories(e.ItemIndex - 1).ShortCutName)
        shortcutNameSize = g.MeasureString(shortcutName, catShortcutFont, 0).ToSize

        If isSelected Then
            foreColor = New SolidBrush(Color.FromKnownColor(KnownColor.HighlightText))
            backColor = New SolidBrush(Color.FromKnownColor(KnownColor.Highlight))

            catShortcutNameBrush = foreColor
            FillRoundedRectangle(g, e.Bounds.Width - shortcutNameSize.Width - 8, e.Bounds.Y, e.Bounds.Width, 16, 8, backColor)
        Else
            foreColor = New SolidBrush(e.Item.ForeColor)
            backColor = New SolidBrush(e.Item.BackColor)
            catShortcutNameBrush = New SolidBrush(Color.FromKnownColor(KnownColor.ControlDark))
        End If

        g.FillRectangle(backColor, e.Bounds.X, e.Bounds.Y + 7, e.Bounds.Width, e.Bounds.Height - 8)
        g.DrawString(e.Item.Text, e.Item.Font, foreColor, 2, e.Bounds.Y + e.Bounds.Height - itemSize.Height - 5, StringFormat.GenericTypographic)

        g.DrawString(shortcutName, catShortcutFont, catShortcutNameBrush, e.Bounds.Width - shortcutNameSize.Width - 4, e.Bounds.Y + 2, StringFormat.GenericTypographic)
        catShortcutNameBrush.Dispose()

        foreColor.Dispose()
        backColor.Dispose()
    End Sub

    Private Sub ListViewCats_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewCats.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SelectCategory()
            Case Keys.Escape
                catsExpColMode = ExpColConstants.Collapsing
            Case Else
                Me.OnKeyDown(e)
        End Select
    End Sub

    Private Sub ListViewCats_LostFocus(sender As Object, e As EventArgs) Handles ListViewCats.LostFocus
        Select Case catsExpColMode
            Case ExpColConstants.Expanded, ExpColConstants.Expanding
                catsExpColMode = ExpColConstants.Collapsing
        End Select
    End Sub

    Private Sub ListViewCats_RetrieveVirtualItem(sender As Object, e As RetrieveVirtualItemEventArgs) Handles ListViewCats.RetrieveVirtualItem
        e.Item = If(e.ItemIndex = 0,
                New ListViewItem("All Categories"),
                New ListViewItem(SearchEngineApi.Categories.Item(e.ItemIndex - 1).Name))
    End Sub
#End Region

#Region "Search Preferences Handling"
    Private Sub SaveSearchPreferences()
        Dim f As BinaryFormatter = New BinaryFormatter
        Dim ms As IO.MemoryStream

        ms = New IO.MemoryStream
        f.Serialize(ms, SearchEngineApi.SearchPaths)
        IO.File.WriteAllText(confPath + "searchPaths.dat", System.Convert.ToBase64String(ms.GetBuffer))
        ms.Dispose()

        ms = New IO.MemoryStream
        f.Serialize(ms, SearchEngineApi.Categories)
        IO.File.WriteAllText(confPath + "searchCategories.dat", System.Convert.ToBase64String(ms.GetBuffer))
        ms.Dispose()
    End Sub

    Private Sub LoadSearchPreferences()
        Dim f As BinaryFormatter = New BinaryFormatter()
        Dim ms As IO.MemoryStream

        SearchEngineApi.SearchPaths.Clear()
        If IO.File.Exists(confPath + "searchPaths.dat") Then
            ms = New IO.MemoryStream(System.Convert.FromBase64String(IO.File.ReadAllText(confPath + "searchPaths.dat")))
            If ms.Capacity > 0 Then
                Dim sps As SearchPaths = CType(f.Deserialize(ms), SearchPaths)
                For Each sp As SearchPath In sps
                    SearchEngineApi.SearchPaths.Add(sp)
                Next
            End If
            ms.Dispose()
        End If

        SearchEngineApi.Categories.Clear()
        If IO.File.Exists(confPath + "searchCategories.dat") Then
            ms = New IO.MemoryStream(System.Convert.FromBase64String(IO.File.ReadAllText(confPath + "searchCategories.dat")))
            If ms.Capacity > 0 Then
                Dim scs As SearchCategories = CType(f.Deserialize(ms), SearchCategories)
                For Each sc As SearchCategory In scs
                    SearchEngineApi.Categories.Add(sc)
                Next
            End If
            ms.Dispose()
        End If

        If SearchEngineApi.SearchPaths.Count = 0 And SearchEngineApi.Categories.Count = 0 Then
            LoadDefaultSearchPreferences()
        End If

        UpdateCacheAndShortcuts()
        ResetKLListView()
    End Sub

    Friend Sub LoadDefaultSearchPreferences()
        SearchEngineApi.SearchPaths.Clear()
        SearchEngineApi.Categories.Clear()

        Dim path As IO.DirectoryInfo = New IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.Programs).Parent
        SearchEngineApi.SearchPaths.Add(New SearchPath(path.FullName, True))
        SearchEngineApi.SearchPaths.Add(New SearchPath(path.FullName.Replace(path.Parent.Name, "All Users"), True))
        SearchEngineApi.SearchPaths(1).FirendlyName += " (All Users)"

        Dim osInfo As OperatingSystem = System.Environment.OSVersion
        If osInfo.Version.Major >= 6 Then
            SearchEngineApi.SearchPaths.Add(New SearchPath(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu), True))

            Dim ns As XNamespace = ""
            Dim libsPath = New IO.DirectoryInfo(IO.Path.Combine(path.Parent.FullName, "Libraries"))
            For Each library As IO.FileInfo In libsPath.GetFiles("*.library-ms")
                Dim data As XDocument = XDocument.Parse(IO.File.ReadAllText(library.FullName).Replace("<libraryDescription xmlns=""http://schemas.microsoft.com/windows/2009/library"">", "<libraryDescription>"))

                For Each url In data...<url>
                    Dim folderPath As String = url.Value
                    If folderPath.Contains("knownfolder:") Then
                        Dim folderGUID = New Guid(folderPath.Split(":")(1).Replace("{", "").Replace("}", ""))
                        Dim folderPtr As IntPtr
                        SHGetKnownFolderPath(folderGUID, KnownFolderFlag.None, IntPtr.Zero, folderPtr)
                        folderPath = Runtime.InteropServices.Marshal.PtrToStringUni(folderPtr)
                        Runtime.InteropServices.Marshal.FreeCoTaskMem(folderPtr)
                    End If
                    If folderPath <> "" Then SearchEngineApi.SearchPaths.Add(New SearchPath(folderPath, True))
                Next
            Next
        Else
            SearchEngineApi.SearchPaths.Add(New SearchPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments, True))
            SearchEngineApi.SearchPaths.Add(New SearchPath(My.Computer.FileSystem.SpecialDirectories.MyMusic, True))
            SearchEngineApi.SearchPaths.Add(New SearchPath(My.Computer.FileSystem.SpecialDirectories.MyPictures, True))
            If IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\My Videos") Then SearchEngineApi.SearchPaths.Add(New SearchPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\My Videos", True))
        End If
        SearchEngineApi.SearchPaths.Add(New SearchPath(My.Computer.FileSystem.SpecialDirectories.Desktop, True))
        SearchEngineApi.SearchPaths.Add(New SearchPath(Environment.GetFolderPath(Environment.SpecialFolder.Favorites), True))

        Dim c As SearchCategory

        c = New SearchCategory With {
            .Name = "Media Files",
            .Color = Color.DarkGreen
        }
        c.Extensions.Add(".mp3")
        c.Extensions.Add(".wav")
        c.Extensions.Add(".mpg")
        c.Extensions.Add(".avi")
        c.Extensions.Add(".wmv")
        c.Extensions.Add(".wma")
        c.Extensions.Add(".acc")
        c.Extensions.Add(".ogg")
        SearchEngineApi.Categories.Add(c)

        c = New SearchCategory With {
            .Name = "Pictures",
            .Color = Color.FromArgb(128, 0, 64)
        }
        c.Extensions.Add(".gif")
        c.Extensions.Add(".jpg")
        c.Extensions.Add(".png")
        c.Extensions.Add(".psd")
        c.Extensions.Add(".tif")
        SearchEngineApi.Categories.Add(c)

        c = New SearchCategory With {
            .Name = "Documents",
            .Color = Color.FromArgb(255, 128, 64)
        }
        c.Extensions.Add(".txt")
        c.Extensions.Add(".doc")
        c.Extensions.Add(".xls")
        c.Extensions.Add(".ppt")
        c.Extensions.Add(".pps")
        SearchEngineApi.Categories.Add(c)

        c = New SearchCategory With {
            .Name = "Applications",
            .Color = Color.FromArgb(128, 64, 64)
        }
        c.Extensions.Add(".exe")
        SearchEngineApi.Categories.Add(c)

        c = New SearchCategory With {
            .Name = "Internet Shortcuts",
            .Color = Color.FromArgb(0, 64, 128)
        }
        c.Extensions.Add(".url")
        SearchEngineApi.Categories.Add(c)
    End Sub
#End Region

#Region "KL Preferences Handling"
    Private Sub LoadKLPreferences()
        Dim f As BinaryFormatter = New BinaryFormatter
        Dim ms As IO.MemoryStream

        If Not IO.Directory.Exists(confPath) Then IO.Directory.CreateDirectory(confPath)

        Try
            If IO.File.Exists(confPath + "pref.dat") Then
                ms = New IO.MemoryStream(System.Convert.FromBase64String(IO.File.ReadAllText(confPath + "pref.dat")))
                If ms.Capacity > 0 Then
                    Preferences = CType(f.Deserialize(ms), PreferencesDef)

                    With Preferences
                        If Not .mainWindowLocation.IsEmpty Then
                            Me.Location = .mainWindowLocation

                            Preferences.mainMaxHeight = .mainWindowSize.Height
                            Me.Width = .mainWindowSize.Width
                        End If

                        SetDefaultKLPreferences(False)
                    End With
                End If
                ms.Dispose()
            Else
                Preferences = New PreferencesDef()
                Me.Location = New Point(80, 0)
                SetDefaultKLPreferences()
                Preferences.mainMaxHeight = 418
            End If
        Catch
            Preferences = New PreferencesDef()
            Me.Location = New Point(80, 0)
            SetDefaultKLPreferences()
            Preferences.mainMaxHeight = 418
        End Try

        SetKLPreferences()
    End Sub

    Private Sub SetKLPreferences()
        NotifyIconIcon.Visible = Preferences.showTrayIcon
        ListViewFiles.DirAreaWidthPercentage = Preferences.filesDirWidthPercenrage

        pnlCats.Top = Preferences.mainTitleHeight
        ListViewFiles.Top = Preferences.mainTitleHeight
        SetMainColor()

        Dim key As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        If Preferences.startWithWindows Then
            key.SetValue("KeyLaunch", String.Format("{0}\{1}.{2}", My.Application.Info.DirectoryPath, My.Application.Info.AssemblyName, "exe"), Microsoft.Win32.RegistryValueKind.String)
        Else
            key.DeleteValue("KeyLaunch", False)
        End If
        key.Close()
    End Sub

    Private Sub SetKeyCapture()
        KeyboardHookApi.HookedKeys.Clear()
        KeyboardHookApi.HookedKeys.Add(Preferences.hotKey)
        KeyboardHookApi.HookedKeys.Add(Keys.Control Or Keys.F12)

        For Each c As SearchCategory In SearchEngineApi.Categories
            If c.ShortCut <> Keys.None Then
                KeyboardHookApi.HookedKeys.Add(c.ShortCut)
            End If
        Next
    End Sub

    Friend Sub SetDefaultKLPreferences(Optional ByVal fullReset As Boolean = True)
        With Preferences
            If .hotKey = Keys.None Or fullReset Then .hotKey = Keys.Scroll
            If .retypeDelay = 0 Or fullReset Then .retypeDelay = 800
            If fullReset Then .showTrayIcon = True
            If fullReset Then .startWithWindows = True
            If .mainColor Is Nothing Or fullReset Then .mainColor = New HLSRGB(Color.FromArgb(146, 191, 237))
            If fullReset Then .hideOnFocusLost = True
            If .cachedResults Is Nothing Or fullReset Then .cachedResults = New Dictionary(Of String, Object())
            If .filesDirWidthPercenrage = 0 Then .filesDirWidthPercenrage = 20
            If .mainTitleHeight = 0 Then .mainTitleHeight = 23
        End With
    End Sub

    Private Sub SaveKLPreferences()
        Dim f As BinaryFormatter = New BinaryFormatter
        Dim ms As IO.MemoryStream

        Preferences.KLVersion = My.Application.Info.Version
        Preferences.mainWindowLocation = Me.Location
        Preferences.mainWindowSize = New Size(Me.Width, Preferences.mainMaxHeight)
        Preferences.filesDirWidthPercenrage = ListViewFiles.DirAreaWidthPercentage

        ms = New IO.MemoryStream
        f.Serialize(ms, Preferences)
        IO.File.WriteAllText(confPath + "pref.dat", System.Convert.ToBase64String(ms.GetBuffer))
        ms.Dispose()
    End Sub
#End Region

    Private Sub DisposeMainBrushes()
        If titleBrush1 IsNot Nothing Then
            titleBrush1.Dispose()
            titleBrush2.Dispose()
            bottomBrush1.Dispose()
            bottomBrush2.Dispose()
            catAllCatsColor.Dispose()
            catAllCatsShortcutColor.Dispose()
            titlePen1.Dispose()
        End If
    End Sub

    Private Sub UpdateCacheAndShortcuts()
        CachePathsExceptions()
        CacheExtensions()
        SetKeyCapture()
    End Sub

    Private Sub CachePathsExceptions()
        mPathsExceptions = New List(Of String)
        For Each folder As SearchPath In SearchEngineApi.SearchPaths
            For Each ex As SearchPath In folder.Exceptions
                mPathsExceptions.Add(ex.FullPathName)
            Next
        Next
    End Sub

    Private Sub CacheExtensions()
        mSelExtensions = New Dictionary(Of String, SearchCategory)
        For Each c As SearchCategory In SearchEngineApi.Categories
            If (selCategory Is Nothing) OrElse selCategory.Name = c.Name Then
                For Each ext As String In c.Extensions
                    mSelExtensions.Add(ext, c)
                Next
            End If
        Next
    End Sub

    Private Sub ShowKL(ByVal ignoreState As Boolean)
        If ignoreState OrElse (mainExpColMode = ExpColConstants.Collapsed) Then
            ToggleExpColMain()
            Me.TopMost = True
            Me.Visible = True
        End If
    End Sub

#Region "lvFiles Events"
    Private Sub ListViewFiles_DoubleClick(sender As Object, e As EventArgs) Handles ListViewFiles.DoubleClick
        LaunchSelectedItem()
    End Sub

    Private Sub ListViewFiles_ItemSelected(ByVal item As KLListViewItem) Handles ListViewFiles.ItemSelected
        RepaintTitleArea()
    End Sub

    Private Sub ListViewFiles_Resize(sender As Object, e As EventArgs) Handles ListViewFiles.Resize
        titleTextArea = New Rectangle(34,
                                    CInt((Preferences.mainTitleHeight - Preferences.mainFontHeight) / 2),
                                    Width - 28 * 2 - 16,
                                    Preferences.mainTitleHeight)
    End Sub

    Private Sub ListViewFiles_MouseMove(sender As Object, e As MouseEventArgs) Handles ListViewFiles.MouseMove
        FormMain_MouseMove(Me, New MouseEventArgs(e.Button, e.Clicks, e.X + ListViewFiles.Left, e.Y + ListViewFiles.Top, e.Delta))
    End Sub

    Private Sub ListViewFiles_MouseDown(sender As Object, e As MouseEventArgs) Handles ListViewFiles.MouseDown
        FormMain_MouseDown(Me, New MouseEventArgs(e.Button, e.Clicks, e.X + ListViewFiles.Left, e.Y + ListViewFiles.Top, e.Delta))
    End Sub

    Private Sub ListViewFiles_MouseUp(sender As Object, e As MouseEventArgs) Handles ListViewFiles.MouseUp
        FormMain_MouseUp(Me, New MouseEventArgs(e.Button, e.Clicks, e.X + ListViewFiles.Left, e.Y + ListViewFiles.Top, e.Delta))
    End Sub
#End Region

#Region "Drag & Drop Handling"
    Private addedFileTypes As Dictionary(Of String, String)
    Private addedFolders As List(Of String)
    Private removedExceptions As List(Of String)
    Private enabledRecursions As List(Of String)

    Private Sub ListViewFiles_DragOver(sender As Object, e As DragEventArgs) Handles ListViewFiles.DragOver
        e.Effect = If(e.Data.GetDataPresent(DataFormats.FileDrop),
                        DragDropEffects.All,
                        DragDropEffects.None)
    End Sub

    Private Sub ListViewFiles_DragDrop(sender As Object, e As DragEventArgs) Handles ListViewFiles.DragDrop
        HandleDroppedFiles(e)
    End Sub

    Friend Sub HandleDroppedFiles(ByVal e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            If mainExpColMode = ExpColConstants.Expanded Then ToggleExpColMain()

            addedFileTypes = New Dictionary(Of String, String)
            addedFolders = New List(Of String)
            removedExceptions = New List(Of String)
            enabledRecursions = New List(Of String)

            Dim f As FormAddFromDropProgress = New FormAddFromDropProgress()
            f.Location = New Point(Screen.FromControl(Me).Bounds.Width \ 2 - f.Width \ 2, 10)
            f.TopMost = True
            f.Show(Me)

            Do
                Application.DoEvents()
            Loop Until mainExpColMode = ExpColConstants.Collapsed

            'Try
            Dim ioFile As IO.FileInfo
            Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            Dim isFolder As Boolean
            For Each file As String In files
                Try
                    ioFile = New IO.FileInfo(file)
                    isFolder = IO.Directory.Exists(ioFile.FullName) '(iofile.Attributes and IO.FileAttributes.Directory)=IO.FileAttributes.Directory

                    If isFolder Then
                        ProcessRequiredFolders(ioFile.FullName)
                    Else
                        Select Case ioFile.Extension.ToLower
                            Case ""
                                MsgBox(String.Format("Files without an extention, such as '{0}' cannot be searched by KeyLaunch", ioFile.FullName), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Invalid File")
                                Continue For
                            Case ".lnk"
                                Continue For
                        End Select

                        ProcessRequiredFileTypes(ioFile.Name, ioFile.Extension, f)
                        ProcessRequiredFolders(ioFile.DirectoryName)
                    End If
                Catch ex As Exception
                    MsgBox(String.Format("An unexpected error has occured while processing '{0}': {1}", file, ex.Message), MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error Parsing Dropped Items")
                End Try
                Application.DoEvents()
            Next
            'Finally
            f.Close()
            'End Try

            Application.DoEvents()
            Dim ff As FormAddFromDropResult = New FormAddFromDropResult With {
                .TopMost = True,
                .StartPosition = FormStartPosition.CenterScreen
            }
            ShowReport(ff.TreeViewFolders, ff.TreeViewExt)
            ff.ShowDialog()

            addedFileTypes.Clear()
            addedFolders.Clear()
            removedExceptions.Clear()
            enabledRecursions.Clear()
        End If
    End Sub

    Private Sub ShowReport(ByVal tvFolders As TreeView, ByVal tvExt As TreeView)
        ProcessFoldersResults(tvFolders, addedFolders, "Added Folders")
        ProcessFoldersResults(tvFolders, removedExceptions, "Removed Exceptions")
        ProcessFoldersResults(tvFolders, enabledRecursions, "Enabled Recursion")

        Dim pNode As TreeNode
        For Each c As SearchCategory In SearchEngineApi.Categories
            pNode = tvExt.Nodes.Add(c.Name)
            For Each aft As KeyValuePair(Of String, String) In addedFileTypes
                If aft.Value = c.Name Then
                    pNode.Nodes.Add(String.Format("{0} ({1})", aft.Key, SearchItems.GetExtensionDescription(SearchItems.GetExtensionDescription(aft.Key))))
                End If
            Next
            If pNode.Nodes.Count = 0 Then
                pNode.Remove()
            Else
                pNode.Expand()
            End If
        Next

        If tvFolders.Nodes.Count = 0 Then
            With tvFolders.Nodes.Add("No changes were required...")
                .ForeColor = Color.FromKnownColor(KnownColor.ControlDark)
            End With
        End If

        If tvExt.Nodes.Count = 0 Then
            With tvExt.Nodes.Add("No changes were required...")
                .ForeColor = Color.FromKnownColor(KnownColor.ControlDark)
            End With
        End If
    End Sub

    Private Sub ProcessFoldersResults(ByVal tv As TreeView, ByVal sList As List(Of String), ByVal title As String)
        Dim pNode As TreeNode
        If sList.Count > 0 Then
            pNode = tv.Nodes.Add(title)
            For Each folder As String In sList
                pNode.Nodes.Add(folder)
            Next
            pNode.Expand()
        End If
    End Sub

    Private Sub ProcessRequiredFileTypes(fileName As String, ext As String, progressForm As FormAddFromDropProgress)
        For Each c As SearchCategory In SearchEngineApi.Categories
            If c.Extensions.Contains(ext.ToLower) Then Exit Sub
        Next

        Dim f As FormAddFromDropExtension = New FormAddFromDropExtension
        f.LabelInfo.Text = String.Format(f.LabelInfo.Text, fileName, ext, SearchItems.GetExtensionDescription(ext))
        For Each c As SearchCategory In SearchEngineApi.Categories
            f.ListBoxCats.Items.Add(c)
        Next
        f.ListBoxCats.SelectedIndex = 0
        f.StartPosition = FormStartPosition.CenterScreen

        progressForm.Visible = False
        f.ShowDialog(Me)
        progressForm.Visible = True

        If f.ListBoxCats.SelectedIndex <> -1 Then
            Dim c As SearchCategory = CType(f.ListBoxCats.SelectedItem, SearchCategory)
            c.Extensions.Add(ext.ToLower)
            addedFileTypes.Add(ext, c.Name)
        End If
    End Sub

    Private Sub ProcessRequiredFolders(ByVal folder As String)
        For Each path As SearchPath In SearchEngineApi.SearchPaths
            If folder = path.FullPathName Then
                ' It's already included, so there's nothing to do
                Exit Sub
            Else
                If folder.StartsWith(path.FullPathName) Then
                    If path.Recurse = False Then
                        ' We need to enable recursion so that this folder can be included
                        path.Recurse = True
                        enabledRecursions.Add(path.FullPathName)

                        ' We are now going to exclude all subfolders except for those that are parents of the one we dropped
                        AddExceptions(path, path, folder)
                        AddSubFolders(folder)
                        Exit Sub
                    Else
                        ' Let's check and see if its part of the exceptions...
                        For Each exPath As SearchPath In path.Exceptions
                            If folder.StartsWith(exPath.FullPathName) Then
                                ' Let's just remove the exception and we'll be done...
                                path.Exceptions.Remove(exPath)
                                removedExceptions.Add(exPath.FullPathName)

                                ' We are now going to exclude all subfolders except for those that are parents of the one we dropped
                                AddExceptions(path, exPath, folder)
                                AddSubFolders(folder)
                                Exit Sub
                            End If
                        Next
                    End If
                    ' the folder is a subfolder of 'path'
                    ' and 'path' is recursive and none of the exceptions affect "folder'
                    ' so... there's nothing to do
                    Exit Sub
                End If

                Application.DoEvents()
            End If
        Next

        SearchEngineApi.SearchPaths.Add(New SearchPath(folder, False))
        addedFolders.Add(folder)
    End Sub

    Private Sub AddSubFolders(ByVal folder As String)
        For Each subFolder As IO.DirectoryInfo In (New IO.DirectoryInfo(folder)).GetDirectories()
            ProcessRequiredFolders(subFolder.FullName)
        Next
    End Sub

    Private Sub AddExceptions(ByVal path As SearchPath, ByVal parentFolder As SearchPath, ByVal excludeFolder As String)
        For Each subFolder As IO.DirectoryInfo In parentFolder.DirectoryInfo.GetDirectories
            If Not excludeFolder.StartsWith(subFolder.FullName) Then
                path.Exceptions.Add(New SearchPath(subFolder.FullName, False))
            Else
                AddExceptions(path, New SearchPath(subFolder.FullName, False), excludeFolder)
            End If
        Next
    End Sub
#End Region

    Private Sub SearchEngineApi_ProgressChanged() Handles SearchEngineApi.ProgressChanged
        Me.Invalidate()
    End Sub

    Private Sub NotifyIconIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIconIcon.MouseDoubleClick
        ShowKL(True)
    End Sub
End Class

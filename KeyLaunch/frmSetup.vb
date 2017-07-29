Imports Microsoft.Win32
Imports System.Threading

Public Class frmSetup
    Private isUpdating As Boolean
    Private isCheckingNodes As Boolean
    Private selPathItem As SearchPath
    Private selCatItem As SearchCategory
    Private searchEngine As SearchEngine = frmMain.mSearchEngine
    Private cancelLoadExtThread As Boolean

    Private loadExtThread As Thread
    Private Delegate Sub AddExtensionDel(ByVal extension As String, ByVal description As String, ByVal iconIndex As Integer, ByVal asocApp As String, ByVal completed As Integer)
    Private Delegate Sub DoneExtensionDel()
    Private extensions() As String
    Private extTotal As Integer

    Private mSortingColumn As ColumnHeader
    Private mSortOrder As System.Windows.Forms.SortOrder

    Private shortcutIsValid As Boolean

    Private Sub frmSetup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cancelLoadExtThread = True

        With frmMain.Preferences
            .setupWindowLocation = Me.Location
            .setupWindowSize = Me.Size
            .setupWindowPathsSplitter = spPaths.SplitterDistance
            .setupWindowCategoriesSplitter = spCategories.SplitterDistance

            .setupListViewFoldersSelCol = CType(CType(lvFolders.Tag, Object())(0), ColumnHeader).Index
            .setupListViewExtensionsSelColSortOrder = CType(CType(lvFolders.Tag, Object())(1), SortOrder)

            .setupListViewCategoriesSelCol = CType(CType(lvCats.Tag, Object())(0), ColumnHeader).Index
            .setupListViewCategoriesSelColSortOrder = CType(CType(lvCats.Tag, Object())(1), SortOrder)

            .setupListViewExtensionsSelCol = CType(CType(lvExt.Tag, Object())(0), ColumnHeader).Index
            .setupListViewExtensionsSelColSortOrder = CType(CType(lvExt.Tag, Object())(1), SortOrder)
        End With

        Do While loadExtThread.IsAlive
            Application.DoEvents()
        Loop
    End Sub

    Private Sub frmSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = False
        With frmMain.Preferences
            If Not .setupWindowLocation.IsEmpty Then
                Me.Location = .setupWindowLocation
                Me.Size = .setupWindowSize

                spPaths.SplitterDistance = .setupWindowPathsSplitter
                spCategories.SplitterDistance = .setupWindowCategoriesSplitter
            End If
        End With
        SetupListViews()

        spCategories.Panel2MinSize = 370

        SetupUI()
    End Sub

    Private Sub SetupUI()
        isUpdating = True

        lvFolders.Items.Clear()
        lvCats.Items.Clear()
        tvExceptions.Nodes.Clear()

        For Each sp As SearchPath In searchEngine.SearchPaths
            AddSearchPath(sp, False)
        Next
        lvFolders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        For Each c As SearchCategory In searchEngine.Categories
            AddCategory(c, False)
        Next
        lvCats.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        If loadExtThread Is Nothing Then
            lvExt.Items.Clear()
            lvCats.Enabled = False
            extensions = Array.FindAll(Registry.ClassesRoot.GetSubKeyNames(), AddressOf StartsWithDot)
            Array.Sort(extensions)
            extTotal = extensions.Length
            loadExtThread = New Thread(AddressOf LoadExtensions)
            With loadExtThread
                .IsBackground = True
                .Name = "LoadExtensions"
                .Priority = ThreadPriority.Lowest
                .Start()
            End With
        End If

        isUpdating = False

        gbFolderInfo.Enabled = False
        gbRecurse.Enabled = False
        chkRecurse.Enabled = False
        btnPathRemove.Enabled = False
        gbCatInfo.Enabled = False
        gbExtensions.Enabled = False
        btnCatAdd.Enabled = False
        btnCatRem.Enabled = False
    End Sub

    Private Sub SetupListViews()
        ilExtIcons.Images.Add(SearchItem.GetIconFromFile("."))
        ilExtIcons.Images.Add(My.Resources.book_reportHS)

        tpPaths.ImageIndex = 2
        tpCategories.ImageIndex = 3

        'tvExceptions.ImageList = ilExtIcons
        lvFolders.SmallImageList = ilExtIcons
        lvCats.SmallImageList = ilExtIcons
        lvExt.SmallImageList = ilExtIcons
        AddHandler lvFolders.ColumnClick, AddressOf ListViewColumnClick
        AddHandler lvCats.ColumnClick, AddressOf ListViewColumnClick
        AddHandler lvExt.ColumnClick, AddressOf ListViewColumnClick

        AddHandler lvFolders.DragOver, AddressOf HandleDragOver
        AddHandler lvFolders.DragDrop, AddressOf HandleDragDrop
        AddHandler lvCats.DragOver, AddressOf HandleDragOver
        AddHandler lvCats.DragDrop, AddressOf HandleDragDrop

        mSortingColumn = Nothing
        With frmMain.Preferences
            mSortOrder = .setupListViewFoldersSelColSortOrder
            ListViewColumnClick(lvFolders, New ColumnClickEventArgs(lvFolders.Columns(.setupListViewFoldersSelCol).Index))

            mSortOrder = .setupListViewCategoriesSelColSortOrder
            ListViewColumnClick(lvCats, New ColumnClickEventArgs(lvCats.Columns(.setupListViewCategoriesSelCol).Index))

            mSortOrder = .setupListViewExtensionsSelColSortOrder
            ListViewColumnClick(lvExt, New ColumnClickEventArgs(lvCats.Columns(.setupListViewExtensionsSelCol).Index))
        End With
    End Sub

    Private Function StartsWithDot(ByVal value As String) As Boolean
        Return value.StartsWith(".")
    End Function

    Private Sub LoadExtensions()
        Dim extCount As Integer = 0
        Dim opensWith As String
        Dim extDesc As String

        Dim key As RegistryKey
        Dim keyData As String

        For Each ext As String In extensions
            Try
                If cancelLoadExtThread Then Exit Sub
                extCount += 1

                key = My.Computer.Registry.ClassesRoot.OpenSubKey(ext, False)

                If key IsNot Nothing AndAlso key.ValueCount > 0 AndAlso key.GetValue("") IsNot Nothing Then
                    keyData = key.GetValue("").ToString
                    key.Close()

                    If keyData <> "" Then
                        extDesc = SearchItems.GetExtensionDescription(keyData)
                        If extDesc <> "" Then
                            opensWith = SearchItems.GetAssociatedApplication(keyData)
                            If opensWith <> "" Then
                                lvExt.Invoke(New AddExtensionDel(AddressOf AddExtension), New Object() {ext.ToLower, extDesc, GetExtensionIconIndex(ext), GetAppInfo(opensWith), CInt(extCount / extTotal * 100)})
                            End If
                        End If
                    End If
                End If
            Catch
            End Try
        Next

        Me.Invoke(New DoneExtensionDel(AddressOf DoneExtension))
    End Sub

    Private Sub DoneExtension()
        btnCatAdd.Enabled = True
        btnCatRem.Enabled = True

        lvExt.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        pbExtensions.Visible = False
        lvCats.Enabled = True
        lvCats.Invalidate()
    End Sub

    Private Sub AddExtension(ByVal extension As String, ByVal description As String, ByVal iconIndex As Integer, ByVal asocApp As String, ByVal completed As Integer)
        Dim newExt As ListViewItem = Nothing

        isUpdating = True

        If lvExt.Items.Count > 0 Then newExt = lvExt.FindItemWithText(description, True, 0)
        If newExt Is Nothing Then
            newExt = lvExt.Items.Add(description, GetExtensionIconIndex(extension))
            newExt.SubItems.Add(New ListViewItem.ListViewSubItem(newExt, extension.ToLower))
            newExt.SubItems.Add(New ListViewItem.ListViewSubItem(newExt, asocApp))
        Else
            newExt.SubItems(chExtExtensions.Index).Text += ", " + extension
        End If

        pbExtensions.Value = completed

        isUpdating = False
    End Sub

    Private Function GetAppInfo(ByVal fileName As String) As String
        Dim vi As FileVersionInfo = FileVersionInfo.GetVersionInfo(fileName)

        If vi.FileDescription = "" Then
            If vi.InternalName = "" Then
                If vi.ProductName = "" Then
                    Dim f As IO.FileInfo = New IO.FileInfo(fileName)
                    Return f.Name.Replace(f.Extension, "")
                Else
                    Return vi.ProductName
                End If
            Else
                Return vi.InternalName
            End If
        Else
            Return vi.FileDescription
        End If
    End Function

    Private Function GetExtensionIconIndex(ByVal ext As String) As Integer
        Dim extKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(ext)
        Dim extValue As String = extKey.GetValue("").ToString
        Dim dataKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(extValue + "\DefaultIcon")
        Dim index As Integer = -1

        If dataKey IsNot Nothing AndAlso dataKey.ValueCount > 0 AndAlso dataKey.GetValue("") IsNot Nothing Then
            Dim dataValue As String = dataKey.GetValue("").ToString

            index = ilExtIcons.Images.IndexOfKey(extValue)
            If index = -1 Then
                Dim ico As Icon = SearchItem.GetIconFromFile(dataValue)
                If ico IsNot Nothing Then
                    ilExtIcons.Images.Add(extValue, ico)
                    index = ilExtIcons.Images.IndexOfKey(extValue)
                End If
            End If
        End If

        If extKey IsNot Nothing Then extKey.Close()
        If dataKey IsNot Nothing Then dataKey.Close()

        Return index
    End Function

    Private Sub AddCategory(ByVal c As SearchCategory, ByVal [select] As Boolean)
        Dim lvi As ListViewItem

        lvi = New ListViewItem(c.Name)
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, c.Color.ToArgb.ToString()))
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, c.ShortCutName))
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, Join(c.Extensions.ToArray, ", ")))
        lvi.Tag = c
        lvCats.Items.Add(lvi)

        If [select] Then
            lvi.EnsureVisible()
            lvi.Selected = True
        End If
    End Sub

    Private Sub AddSearchPath(ByVal sp As SearchPath, ByVal [select] As Boolean)
        Dim lvi As ListViewItem

        lvi = New ListViewItem(sp.FirendlyName, 2)
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, IIf(Of String)(sp.Recurse, "Yes", "No")))
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, IIf(Of String)(sp.Exceptions.Count > 0, "Yes", "No")))
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, sp.FullPathName))
        lvi.Tag = sp
        lvFolders.Items.Add(lvi)

        If [select] Then
            lvi.EnsureVisible()
            lvi.Selected = True
        End If
    End Sub

    Private Sub ListViewColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        ' Get the new sorting column.
        Dim lv As ListView = CType(sender, FFListView)
        Dim newSortingColumn As ColumnHeader = lv.Columns(e.Column)

        ' Figure out the new sorting order.
        If mSortingColumn Is Nothing Then
            ' New column. Sort ascending.
            mSortOrder = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If newSortingColumn.Equals(mSortingColumn) Then
                ' Same column. Switch the sort order.
                If mSortOrder = SortOrder.Ascending Then
                    mSortOrder = SortOrder.Descending
                Else
                    mSortOrder = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                mSortOrder = SortOrder.Ascending
            End If
        End If

        ' Display the new sort order.
        mSortingColumn = newSortingColumn
        For Each c As ColumnHeader In lv.Columns
            If c.Equals(mSortingColumn) Then
                c.ImageIndex = IIf(Of Integer)(mSortOrder = SortOrder.Ascending, 0, 1)
            Else
                c.ImageIndex = -1
            End If
        Next

        ' Create a comparer.
        lv.ListViewItemSorter = New ListViewComparer(e.Column, mSortOrder)

        ' Sort.
        lv.Sort()
        mSortingColumn.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)

        lv.Tag = New Object() {mSortingColumn, mSortOrder}
    End Sub

    Private Sub lvFolders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvFolders.SelectedIndexChanged
        If lvFolders.SelectedItems.Count = 0 Then
            gbFolderInfo.Enabled = False
            gbRecurse.Enabled = False
            chkRecurse.Enabled = False
            btnPathRemove.Enabled = False
            Exit Sub
        End If

        isUpdating = True
        selPathItem = CType(lvFolders.SelectedItems(0).Tag, SearchPath)

        gbFolderInfo.Enabled = True
        chkRecurse.Enabled = True
        btnPathRemove.Enabled = True

        txtName.Text = selPathItem.FirendlyName
        txtLocation.Text = selPathItem.FullPathName
        chkRecurse.Checked = selPathItem.Recurse
        gbRecurse.Enabled = selPathItem.Recurse

        Me.Cursor = Cursors.AppStarting

        InitLoadExceptions(Nothing)

        Me.Cursor = Cursors.Default

        isUpdating = False
    End Sub

    Private Sub InitLoadExceptions(ByVal parent As TreeNode)
        pbExceptions.Value = 0
        pbExceptions.Maximum = 0
        pbExceptions.Visible = True

        If parent Is Nothing Then
            tvExceptions.Nodes.Clear()
            LoadExceptions(selPathItem.DirectoryInfo, Nothing)
        Else
            LoadExceptions(New IO.DirectoryInfo(selPathItem.FullPathName + "\" + parent.FullPath), parent)
        End If

        pbExceptions.Visible = False
    End Sub

    Private Sub LoadExceptions(ByVal dir As IO.DirectoryInfo, ByVal parent As TreeNode)
        Dim newNode As TreeNode
        Dim dirs As IO.DirectoryInfo()

        Try
            dirs = dir.GetDirectories()
        Catch ex As Exception
            Exit Sub
        End Try

        pbExceptions.Maximum += dirs.Length

        For Each subDir As IO.DirectoryInfo In dir.GetDirectories()
            pbExceptions.Value += 1
            If parent Is Nothing Then
                newNode = tvExceptions.Nodes.Add(subDir.Name)
            Else
                newNode = parent.Nodes.Add(subDir.Name)
            End If
            newNode.Name = subDir.FullName
            newNode.ImageIndex = 2

            'If subDir.GetDirectories().Length > 0 Then LoadExceptions(subDir, newNode)
            Try
                If subDir.GetDirectories().Length > 0 Then newNode.Nodes.Add("...")
            Catch
            End Try

            For Each ex As SearchPath In selPathItem.Exceptions
                If subDir.FullName.StartsWith(ex.FullPathName) Then
                    newNode.Checked = True
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub chkRecurse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecurse.CheckedChanged
        gbRecurse.Enabled = chkRecurse.Checked

        UpdateSelectedPathItem()
    End Sub

    Private Sub tvEx_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvExceptions.AfterCheck
        ProcessExclussions(e.Node)
    End Sub

    Private Sub tvExceptions_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvExceptions.BeforeExpand
        If e.Node.Nodes(0).Text = "..." Then
            e.Node.Nodes.Clear()
            InitLoadExceptions(e.Node)
        End If
    End Sub

    Private Sub ProcessExclussions(ByVal node As TreeNode)
        Static recursionCounter As Integer

        recursionCounter = recursionCounter + 1

        Dim sp As SearchPath = CType(lvFolders.SelectedItems(0).Tag, SearchPath)
        If node.Checked = False Then
            If node.Parent IsNot Nothing AndAlso node.Parent.Checked Then
                isUpdating = True
                node.Parent.Checked = False
                node.Parent.ForeColor = Me.ForeColor

                For Each subNode As TreeNode In node.Parent.Nodes
                    If subNode.Text <> node.Text Then
                        sp.Exceptions.Add(New SearchPath(sp.FullPathName + "\" + subNode.FullPath))
                    End If
                Next

                isUpdating = False
            End If

            node.ForeColor = Me.ForeColor
            RemoveException(sp.FullPathName + "\" + node.FullPath, sp)
            If recursionCounter = 1 Then UpdateCheckStateOnChildNodes(node)
        Else
            If Not isUpdating And recursionCounter = 1 Then
                If node.Checked Then
                    sp.Exceptions.Add(New SearchPath(sp.FullPathName + "\" + node.FullPath))
                Else
                    RemoveException(sp.FullPathName + "\" + node.FullPath, sp)
                End If
            End If

            UpdateCheckStateOnChildNodes(node)
        End If

        If recursionCounter = 1 Then UpdateSelectedPathItem()

        recursionCounter = recursionCounter - 1
    End Sub

    Private Function RemoveUnnecessaryExceptions(ByVal exception As SearchPath, ByVal path As SearchPath) As Boolean
        Dim isDone As Boolean
        Dim colHaschanged As Boolean = False
        Dim exFullPathName As String = exception.FullPathName
        Dim exFullPathNameLength As Integer = exception.FullPathName.Length

        Do
            isDone = True
            For Each ex As SearchPath In path.Exceptions
                If ex <> exception Then
                    If ex.FullPathName.StartsWith(exFullPathName) AndAlso ex.FullPathName.Chars(exFullPathNameLength) = "\" Then
                        path.Exceptions.Remove(ex)
                        colHaschanged = True
                        isDone = False
                        Exit For
                    End If
                End If
            Next
        Loop Until isDone

        Return colHaschanged
    End Function

    Private Sub RemoveException(ByVal path As String, ByVal sp As SearchPath)
        For Each ex As SearchPath In sp.Exceptions
            If ex.FullPathName = path Then
                sp.Exceptions.Remove(ex)
                Exit For
            End If
        Next
    End Sub

    Private Sub UpdateCheckStateOnChildNodes(ByVal n As TreeNode)
        n.ForeColor = IIf(Of Color)(n.Checked, Color.FromKnownColor(KnownColor.ControlDark), Me.ForeColor)
        For Each cn As TreeNode In n.Nodes
            cn.Checked = n.Checked
        Next
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        UpdateSelectedPathItem()
    End Sub

    Private Sub UpdateSelectedPathItem()
        If isUpdating Then Exit Sub

        Dim item As ListViewItem = lvFolders.SelectedItems(0)
        Dim sp As SearchPath = CType(item.Tag, SearchPath)
        With sp
            If .FirendlyName <> txtName.Text Then
                .FirendlyName = txtName.Text
                item.Text = .FirendlyName
            End If

            If .FullPathName <> txtLocation.Text Then
                .DirectoryInfo = New IO.DirectoryInfo(txtLocation.Text)
                item.SubItems(chPathsFullPath.Index).Text = .FullPathName

                InitLoadExceptions(Nothing)
            End If

            If .Recurse <> chkRecurse.Checked Then
                .Recurse = chkRecurse.Checked
                item.SubItems(chPathsRecurse.Index).Text = IIf(Of String)(.Recurse, "Yes", "No")
            End If

            item.SubItems(chPathsExceptions.Index).Text = IIf(Of String)(.Exceptions.Count > 0, "Yes", "No")
        End With

        lvFolders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub UpdateSelectedCategoryItem()
        If isUpdating Then Exit Sub

        Dim item As ListViewItem = lvCats.SelectedItems(0)
        With CType(item.Tag, SearchCategory)
            If .Name <> txtCatName.Text Then
                .Name = txtCatName.Text
                item.Text = .Name
            End If

            .Extensions.Clear()
            For Each ext As String In txtExtensions.Text.Replace(" ", "").Split(CChar(","))
                .Extensions.Add(ext)
            Next
            item.SubItems(chCatExtensions.Index).Text = txtExtensions.Text

            If .Color <> btnCatColor.BackColor Then
                .Color = btnCatColor.BackColor
                item.SubItems(chCatColor.Index).Text = .Color.ToArgb.ToString
            End If

            If .ShortCutName <> txtShortcut.Text Then
                If shortcutIsValid Then
                    .ShortCut = CType(txtShortcut.Tag, Keys)
                Else
                    .ShortCut = Keys.None
                End If
                .ShortCutName = txtShortcut.Text
                item.SubItems(chCatShortcut.Index).Text = .ShortCutName
                item.SubItems(chCatShortcut.Index).Tag = .ShortCut
            End If
        End With

        lvCats.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged
        UpdateSelectedPathItem()
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        With fbDialog
            .Description = "Select the new location for the '" + selPathItem.ShortPathName + "' folder"
            .SelectedPath = selPathItem.FullPathName
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If .SelectedPath <> selPathItem.FullPathName Then
                    txtLocation.Text = .SelectedPath
                End If
            End If
        End With
    End Sub

    Private Sub btnPathAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPathAdd.Click
        With fbDialog
            .Description = "Select the folder to add to the list of folders that LeyLaunch will use for its searches"
            .RootFolder = Environment.SpecialFolder.MyComputer
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim sp As SearchPath = New SearchPath(.SelectedPath, False)
                searchEngine.SearchPaths.Add(sp)
                AddSearchPath(sp, True)
            End If
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        cancelLoadExtThread = True

        Me.Cursor = Cursors.WaitCursor

        Dim isDone As Boolean
        For Each sp As SearchPath In Me.searchEngine.SearchPaths
            If Not sp.Recurse AndAlso sp.Exceptions.Count > 0 Then
                sp.Exceptions.Clear()
            End If
            Do
                isDone = True
                For Each ex As SearchPath In sp.Exceptions
                    If RemoveUnnecessaryExceptions(ex, sp) Then
                        isDone = False
                        Exit For
                    End If
                Next
            Loop Until isDone
        Next

        Me.Cursor = Cursors.Default

        frmMain.mSearchEngine = Me.searchEngine
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPathRemove.Click
        For Each sp As SearchPath In searchEngine.SearchPaths
            If sp = selPathItem Then
                searchEngine.SearchPaths.Remove(sp)
                lvFolders.Items.Remove(lvFolders.SelectedItems(0))
                tvExceptions.Nodes.Clear()
                Exit For
            End If
        Next
    End Sub

    Private Sub lvCats_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles lvCats.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub lvCats_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles lvCats.DrawItem
        'e.DrawText()
    End Sub

    Private Sub lvCats_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles lvCats.DrawSubItem
        If e.ColumnIndex = 1 Then
            Dim backColor As SolidBrush
            Dim s As Integer = e.Bounds.Height - 4
            Dim r As Rectangle = New Rectangle(e.Bounds.Left + e.Bounds.Width \ 2 - s \ 2, e.Bounds.Top + 1, s, s)
            Dim isSelected As Boolean = (lvCats.SelectedItems.Count > 0) AndAlso (lvCats.SelectedIndices(0) = e.ItemIndex)

            If lvCats.Enabled Then
                If isSelected Then
                    If lvCats.Focused Then
                        backColor = New SolidBrush(Color.FromKnownColor(KnownColor.Highlight))
                    Else
                        backColor = New SolidBrush(Color.FromKnownColor(KnownColor.Control))
                    End If
                Else
                    If lvCats.Focused Then
                        backColor = New SolidBrush(e.SubItem.BackColor)
                    Else
                        If isSelected Then
                            backColor = New SolidBrush(Color.FromKnownColor(KnownColor.Control))
                        Else
                            backColor = New SolidBrush(e.SubItem.BackColor)
                        End If
                    End If
                End If
            Else
                backColor = New SolidBrush(Color.FromKnownColor(KnownColor.Control))
            End If

            e.Graphics.FillRectangle(backColor, e.Bounds)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(CInt(e.SubItem.Text))), r)
            e.Graphics.DrawRectangle(Pens.White, r)

            backColor.Dispose()
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private Sub lvCats_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCats.EnabledChanged
        lvCats.Invalidate()
    End Sub

    Private Sub lvCats_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCats.SelectedIndexChanged
        If lvCats.SelectedItems.Count = 0 Then
            gbCatInfo.Enabled = False
            gbExtensions.Enabled = False
            Exit Sub
        End If

        isUpdating = True
        selCatItem = CType(lvCats.SelectedItems(0).Tag, SearchCategory)

        gbCatInfo.Enabled = True
        gbExtensions.Enabled = True

        txtCatName.Text = selCatItem.Name
        txtExtensions.Text = lvCats.SelectedItems(0).SubItems(chCatExtensions.Index).Text
        btnCatColor.BackColor = selCatItem.Color
        txtShortcut.Text = selCatItem.ShortCutName
        txtShortcut.Tag = selCatItem.ShortCut

        Dim extItem As ListViewItem
        For Each extItem In lvExt.CheckedItems
            If extItem.Checked = True Then
                With extItem
                    .Checked = False
                    .Font = New Font(extItem.Font, FontStyle.Regular)
                End With
            End If
        Next

        Dim extA() As String
        For Each ext As String In selCatItem.Extensions
            For Each extItem In lvExt.Items
                If extItem.Checked = False Then
                    extA = extItem.SubItems(chExtExtensions.Index).Text.Replace(" ", "").Split(CChar(","))
                    If Array.IndexOf(extA, ext) <> -1 Then
                        With extItem
                            .Checked = True
                            .Font = New Font(extItem.Font, FontStyle.Bold)
                        End With
                    End If
                End If
            Next
        Next

        isUpdating = False
    End Sub

    Private Sub btnCatColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCatColor.Click
        With cDlg
            .AllowFullOpen = True
            .AnyColor = True
            .Color = selCatItem.Color
            .FullOpen = True
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                btnCatColor.BackColor = .Color
                UpdateSelectedCategoryItem()
            End If
        End With
    End Sub

    Private Sub txtCatName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCatName.TextChanged
        UpdateSelectedCategoryItem()
    End Sub

    Private Sub lvExt_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvExt.ItemChecked
        If isUpdating Then Exit Sub

        Dim extA() As String = e.Item.SubItems(chExtExtensions.Index).Text.Replace(" ", "").Split(CChar(","))

        For Each ext As String In extA
            If selCatItem.Extensions.Contains(ext) Then
                selCatItem.Extensions.Remove(ext)
            End If
        Next

        If e.Item.Checked Then
            e.Item.Font = New Font(e.Item.Font, FontStyle.Bold)
            For Each ext As String In extA
                selCatItem.Extensions.Add(ext)
            Next
        Else
            e.Item.Font = New Font(e.Item.Font, FontStyle.Regular)
        End If

        isUpdating = True
        txtExtensions.Text = Join(selCatItem.Extensions.ToArray, ", ")
        lvCats.SelectedItems(0).SubItems(chCatExtensions.Index).Text = Join(selCatItem.Extensions.ToArray, ", ")
        lvCats.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        isUpdating = False
    End Sub

    Private Sub txtShortcut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShortcut.KeyDown
        If e.KeyValue >= 31 Then
            txtShortcut.Tag = e.KeyData
            shortcutIsValid = True
        Else
            shortcutIsValid = False
        End If

        txtShortcut.Text = SearchCategory.KeysToString(e.KeyData)
    End Sub

    Private Sub txtShortcut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShortcut.KeyUp
        If shortcutIsValid = False Then
            txtShortcut.Text = Keys.None.ToString
            txtShortcut.Tag = New KeyEventArgs(Keys.None)
        End If

        UpdateSelectedCategoryItem()
    End Sub

    Private Sub btnCatAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCatAdd.Click
        Dim c As SearchCategory = New SearchCategory()
        c.Name = "[New Category]"
        searchEngine.Categories.Add(c)
        AddCategory(c, True)
        txtCatName.Focus()
        txtCatName.SelectAll()
    End Sub

    Private Sub cmdDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefaults.Click
        If MsgBox("Are you sure you want to load the default paths and categories?" + vbCrLf + vbCrLf + "Note that this action cannot be undone and you will loose all your custom paths and categories", _
                    MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Load Defaults") = MsgBoxResult.Yes Then
            frmMain.LoadDefaultSearchPreferences()
            SetupUI()
        End If
    End Sub

    Private Sub HandleDragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub HandleDragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        frmMain.HandleDroppedFiles(e)
        SetupUI()
    End Sub

    Private Sub cmsExceptionsToggleChildNodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsExceptionsToggleChildNodes.Click
        For Each cNode As TreeNode In tvExceptions.SelectedNode.Nodes
            cNode.Checked = Not cNode.Checked
        Next
    End Sub

    Private Sub cmsExceptions_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsExceptions.Opening
        cmsExceptionsBrowse.Enabled = (tvExceptions.SelectedNode IsNot Nothing)
        cmsExceptionsToggleChildNodes.Enabled = (tvExceptions.SelectedNode IsNot Nothing)
    End Sub

    Private Sub cmsExceptionsBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsExceptionsBrowse.Click
        KLListViewItem.OpenContainingFolder(selPathItem.FullPathName + "\" + tvExceptions.SelectedNode.FullPath)
    End Sub

#Region "Extensions Editor"
    Private Sub btnEditExtensions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditExtensions.Click
        lbExtensions.Items.Clear()

        For Each ext As String In selCatItem.Extensions
            lbExtensions.Items.Add(ext)
        Next
        If lbExtensions.Items.Count = 0 Then
            btnEditExt.Enabled = False
            btnDeleteExt.Enabled = False
        Else
            lbExtensions.SelectedIndex = 0
        End If

        pExtEditor.Top = tabCtrlSections.Top + tpCategories.Top + spCategories.Top + spCategories.Panel2.Top + gbCatInfo.Top + txtExtensions.Bottom
        pExtEditor.Left = tabCtrlSections.Left + tpCategories.Left + spCategories.Left + spCategories.Panel2.Left + gbCatInfo.Left + txtExtensions.Left
        pExtEditor.Width = txtExtensions.Width
        pExtEditor.Visible = True
    End Sub

    Private Sub btnCloseExtEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseExtEditor.Click
        CloseExtensionsEditor()
    End Sub

    Private Sub pExtEditor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles pExtEditor.LostFocus
        CloseExtensionsEditor()
    End Sub

    Private Sub CloseExtensionsEditor()
        Dim exts As String = ""
        For Each ext As String In lbExtensions.Items
            exts += ext + ", "
        Next
        exts = exts.Substring(0, exts.Length - 2)
        txtExtensions.Text = exts

        pExtEditor.Visible = False

        UpdateSelectedCategoryItem()
    End Sub

    Private Sub lbExtensions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbExtensions.SelectedIndexChanged
        UpdateExtEditorUI()
    End Sub

    Private Sub UpdateExtEditorUI()
        If lbExtensions.Items.Count = 0 OrElse lbExtensions.SelectedItems.Count = 0 Then
            btnEditExt.Enabled = False
            btnDeleteExt.Enabled = False
        Else
            btnEditExt.Enabled = True
            btnDeleteExt.Enabled = True
        End If
    End Sub

    Private Sub btnAddExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExt.Click
        txtExtension.Text = txtExtension.Text.ToLower

        If txtExtension.Text = "" Then Exit Sub
        If txtExtension.Text.StartsWith(".") = False Then txtExtension.Text = "." + txtExtension.Text
        If lbExtensions.Items.Contains(txtExtension.Text) Then Exit Sub

        lbExtensions.Items.Add(txtExtension.Text)
        lbExtensions.SelectedIndex = lbExtensions.Items.IndexOf(txtExtension.Text)

        txtExtension.Text = ""
    End Sub

    Private Sub btnEditExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditExt.Click
        Dim ext As String = CType(lbExtensions.SelectedItem, String)
        lbExtensions.Items.Remove(lbExtensions.SelectedItem)

        Application.DoEvents()

        txtExtension.Text = ext
        txtExtension.Focus()
    End Sub

    Private Sub btnDeleteExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteExt.Click
        lbExtensions.Items.Remove(lbExtensions.SelectedItem)

        UpdateExtEditorUI()
    End Sub
#End Region
End Class
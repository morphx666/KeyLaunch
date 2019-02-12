Imports Microsoft.Win32
Imports System.Threading

Public Class FormSetup
    Private isUpdating As Boolean
    Private isCheckingNodes As Boolean
    Private selPathItem As SearchPath
    Private selCatItem As SearchCategory
    Private searchEngine As SearchEngine = FormMain.SearchEngineApi
    Private cancelLoadExtThread As Boolean

    Private loadExtThread As Thread
    Private Delegate Sub AddExtensionDel(ByVal extension As String, ByVal description As String, ByVal iconIndex As Integer, ByVal asocApp As String, ByVal completed As Integer)
    Private Delegate Sub DoneExtensionDel()
    Private extensions() As String
    Private extTotal As Integer

    Private mSortingColumn As ColumnHeader
    Private mSortOrder As SortOrder

    Private shortcutIsValid As Boolean

    Private Sub FormSetup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        cancelLoadExtThread = True

        With FormMain.Preferences
            .setupWindowLocation = Me.Location
            .setupWindowSize = Me.Size
            .setupWindowPathsSplitter = spPaths.SplitterDistance
            .setupWindowCategoriesSplitter = spCategories.SplitterDistance

            .setupListViewFoldersSelCol = CType(CType(ListViewFolders.Tag, Object())(0), ColumnHeader).Index
            .setupListViewExtensionsSelColSortOrder = CType(CType(ListViewFolders.Tag, Object())(1), SortOrder)

            .setupListViewCategoriesSelCol = CType(CType(ListViewCats.Tag, Object())(0), ColumnHeader).Index
            .setupListViewCategoriesSelColSortOrder = CType(CType(ListViewCats.Tag, Object())(1), SortOrder)

            .setupListViewExtensionsSelCol = CType(CType(ListViewExt.Tag, Object())(0), ColumnHeader).Index
            .setupListViewExtensionsSelColSortOrder = CType(CType(ListViewExt.Tag, Object())(1), SortOrder)
        End With

        Do While loadExtThread.IsAlive
            Application.DoEvents()
        Loop
    End Sub

    Private Sub FormSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = False
        With FormMain.Preferences
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

        ListViewFolders.Items.Clear()
        ListViewCats.Items.Clear()
        TreeViewExceptions.Nodes.Clear()

        For Each sp As SearchPath In searchEngine.SearchPaths
            AddSearchPath(sp, False)
        Next
        ListViewFolders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        For Each c As SearchCategory In searchEngine.Categories
            AddCategory(c, False)
        Next
        ListViewCats.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        If loadExtThread Is Nothing Then
            ListViewExt.Items.Clear()
            ListViewCats.Enabled = False
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

        GroupBoxFolderInfo.Enabled = False
        GroupBoxRecurse.Enabled = False
        CheckBoxRecurse.Enabled = False
        ButtonPathRemove.Enabled = False
        GroupBoxCatInfo.Enabled = False
        gbExtensions.Enabled = False
        ButtonCatAdd.Enabled = False
        ButtonCatRem.Enabled = False
    End Sub

    Private Sub SetupListViews()
        ImageListExtIcons.Images.Add(SearchItem.GetIconFromFile("."))
        ImageListExtIcons.Images.Add(My.Resources.book_reportHS)

        tpPaths.ImageIndex = 2
        tpCategories.ImageIndex = 3

        'tvExceptions.ImageList = ilExtIcons
        ListViewFolders.SmallImageList = ImageListExtIcons
        ListViewCats.SmallImageList = ImageListExtIcons
        ListViewExt.SmallImageList = ImageListExtIcons
        AddHandler ListViewFolders.ColumnClick, AddressOf ListViewColumnClick
        AddHandler ListViewCats.ColumnClick, AddressOf ListViewColumnClick
        AddHandler ListViewExt.ColumnClick, AddressOf ListViewColumnClick

        AddHandler ListViewFolders.DragOver, AddressOf HandleDragOver
        AddHandler ListViewFolders.DragDrop, AddressOf HandleDragDrop
        AddHandler ListViewCats.DragOver, AddressOf HandleDragOver
        AddHandler ListViewCats.DragDrop, AddressOf HandleDragDrop

        mSortingColumn = Nothing
        With FormMain.Preferences
            mSortOrder = .setupListViewFoldersSelColSortOrder
            ListViewColumnClick(ListViewFolders, New ColumnClickEventArgs(ListViewFolders.Columns(.setupListViewFoldersSelCol).Index))

            mSortOrder = .setupListViewCategoriesSelColSortOrder
            ListViewColumnClick(ListViewCats, New ColumnClickEventArgs(ListViewCats.Columns(.setupListViewCategoriesSelCol).Index))

            mSortOrder = .setupListViewExtensionsSelColSortOrder
            ListViewColumnClick(ListViewExt, New ColumnClickEventArgs(ListViewCats.Columns(.setupListViewExtensionsSelCol).Index))
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
                                ListViewExt.Invoke(New AddExtensionDel(AddressOf AddExtension), New Object() {ext.ToLower, extDesc, GetExtensionIconIndex(ext), GetAppInfo(opensWith), CInt(extCount / extTotal * 100)})
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
        ButtonCatAdd.Enabled = True
        ButtonCatRem.Enabled = True

        ListViewExt.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ProgressBarExtensions.Visible = False
        ListViewCats.Enabled = True
        ListViewCats.Invalidate()
    End Sub

    Private Sub AddExtension(ByVal extension As String, ByVal description As String, ByVal iconIndex As Integer, ByVal asocApp As String, ByVal completed As Integer)
        Dim newExt As ListViewItem = Nothing

        isUpdating = True

        If ListViewExt.Items.Count > 0 Then newExt = ListViewExt.FindItemWithText(description, True, 0)
        If newExt Is Nothing Then
            newExt = ListViewExt.Items.Add(description, GetExtensionIconIndex(extension))
            newExt.SubItems.Add(New ListViewItem.ListViewSubItem(newExt, extension.ToLower))
            newExt.SubItems.Add(New ListViewItem.ListViewSubItem(newExt, asocApp))
        Else
            newExt.SubItems(chExtExtensions.Index).Text += ", " + extension
        End If

        ProgressBarExtensions.Value = completed

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

            index = ImageListExtIcons.Images.IndexOfKey(extValue)
            If index = -1 Then
                Dim ico As Icon = SearchItem.GetIconFromFile(dataValue)
                If ico IsNot Nothing Then
                    ImageListExtIcons.Images.Add(extValue, ico)
                    index = ImageListExtIcons.Images.IndexOfKey(extValue)
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
        ListViewCats.Items.Add(lvi)

        If [select] Then
            lvi.EnsureVisible()
            lvi.Selected = True
        End If
    End Sub

    Private Sub AddSearchPath(ByVal sp As SearchPath, ByVal [select] As Boolean)
        Dim lvi As ListViewItem

        lvi = New ListViewItem(sp.FirendlyName, 2)
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, If(sp.Recurse, "Yes", "No")))
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, If(sp.Exceptions.Count > 0, "Yes", "No")))
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, sp.FullPathName))
        lvi.Tag = sp
        ListViewFolders.Items.Add(lvi)

        If [select] Then
            lvi.EnsureVisible()
            lvi.Selected = True
        End If
    End Sub

    Private Sub ListViewColumnClick(sender As Object, e As ColumnClickEventArgs)
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
                mSortOrder = If(mSortOrder = SortOrder.Ascending,
                    SortOrder.Descending,
                    SortOrder.Ascending)
            Else
                ' New column. Sort ascending.
                mSortOrder = SortOrder.Ascending
            End If
        End If

        ' Display the new sort order.
        mSortingColumn = newSortingColumn
        For Each c As ColumnHeader In lv.Columns
            c.ImageIndex = If(c.Equals(mSortingColumn),
                                If(mSortOrder = SortOrder.Ascending, 0, 1),
                                -1)
        Next

        ' Create a comparer.
        lv.ListViewItemSorter = New ListViewComparer(e.Column, mSortOrder)

        ' Sort.
        lv.Sort()
        mSortingColumn.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)

        lv.Tag = New Object() {mSortingColumn, mSortOrder}
    End Sub

    Private Sub ListViewFolders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewFolders.SelectedIndexChanged
        If ListViewFolders.SelectedItems.Count = 0 Then
            GroupBoxFolderInfo.Enabled = False
            GroupBoxRecurse.Enabled = False
            CheckBoxRecurse.Enabled = False
            ButtonPathRemove.Enabled = False
            Exit Sub
        End If

        isUpdating = True
        selPathItem = CType(ListViewFolders.SelectedItems(0).Tag, SearchPath)

        GroupBoxFolderInfo.Enabled = True
        CheckBoxRecurse.Enabled = True
        ButtonPathRemove.Enabled = True

        TextBoxName.Text = selPathItem.FirendlyName
        TextBoxLocation.Text = selPathItem.FullPathName
        CheckBoxRecurse.Checked = selPathItem.Recurse
        GroupBoxRecurse.Enabled = selPathItem.Recurse

        Me.Cursor = Cursors.AppStarting

        InitLoadExceptions(Nothing)

        Me.Cursor = Cursors.Default

        isUpdating = False
    End Sub

    Private Sub InitLoadExceptions(ByVal parent As TreeNode)
        ProgressBarExceptions.Value = 0
        ProgressBarExceptions.Maximum = 0
        ProgressBarExceptions.Visible = True

        If parent Is Nothing Then
            TreeViewExceptions.Nodes.Clear()
            LoadExceptions(selPathItem.DirectoryInfo, Nothing)
        Else
            LoadExceptions(New IO.DirectoryInfo(selPathItem.FullPathName + "\" + parent.FullPath), parent)
        End If

        ProgressBarExceptions.Visible = False
    End Sub

    Private Sub LoadExceptions(ByVal dir As IO.DirectoryInfo, ByVal parent As TreeNode)
        Dim newNode As TreeNode
        Dim dirs As IO.DirectoryInfo()

        Try
            dirs = dir.GetDirectories()
        Catch ex As Exception
            Exit Sub
        End Try

        ProgressBarExceptions.Maximum += dirs.Length

        For Each subDir As IO.DirectoryInfo In dir.GetDirectories()
            ProgressBarExceptions.Value += 1
            newNode = If(parent Is Nothing,
                        TreeViewExceptions.Nodes.Add(subDir.Name),
                        parent.Nodes.Add(subDir.Name))
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

    Private Sub CheckBoxRecurse_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRecurse.CheckedChanged
        GroupBoxRecurse.Enabled = CheckBoxRecurse.Checked

        UpdateSelectedPathItem()
    End Sub

    Private Sub TreeViewEx_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeViewExceptions.AfterCheck
        ProcessExclussions(e.Node)
    End Sub

    Private Sub TreeViewExceptions_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeViewExceptions.BeforeExpand
        If e.Node.Nodes(0).Text = "..." Then
            e.Node.Nodes.Clear()
            InitLoadExceptions(e.Node)
        End If
    End Sub

    Private Sub ProcessExclussions(ByVal node As TreeNode)
        Static recursionCounter As Integer

        recursionCounter = recursionCounter + 1

        Dim sp As SearchPath = CType(ListViewFolders.SelectedItems(0).Tag, SearchPath)
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
        n.ForeColor = If(n.Checked, Color.FromKnownColor(KnownColor.ControlDark), Me.ForeColor)
        For Each cn As TreeNode In n.Nodes
            cn.Checked = n.Checked
        Next
    End Sub

    Private Sub TextBoxName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxName.TextChanged
        UpdateSelectedPathItem()
    End Sub

    Private Sub UpdateSelectedPathItem()
        If isUpdating Then Exit Sub

        Dim item As ListViewItem = ListViewFolders.SelectedItems(0)
        Dim sp As SearchPath = CType(item.Tag, SearchPath)
        With sp
            If .FirendlyName <> TextBoxName.Text Then
                .FirendlyName = TextBoxName.Text
                item.Text = .FirendlyName
            End If

            If .FullPathName <> TextBoxLocation.Text Then
                .DirectoryInfo = New IO.DirectoryInfo(TextBoxLocation.Text)
                item.SubItems(chPathsFullPath.Index).Text = .FullPathName

                InitLoadExceptions(Nothing)
            End If

            If .Recurse <> CheckBoxRecurse.Checked Then
                .Recurse = CheckBoxRecurse.Checked
                item.SubItems(chPathsRecurse.Index).Text = If(.Recurse, "Yes", "No")
            End If

            item.SubItems(chPathsExceptions.Index).Text = If(.Exceptions.Count > 0, "Yes", "No")
        End With

        ListViewFolders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub UpdateSelectedCategoryItem()
        If isUpdating Then Exit Sub

        Dim item As ListViewItem = ListViewCats.SelectedItems(0)
        With CType(item.Tag, SearchCategory)
            If .Name <> TextBoxCatName.Text Then
                .Name = TextBoxCatName.Text
                item.Text = .Name
            End If

            .Extensions.Clear()
            For Each ext As String In TextBoxExtensions.Text.Replace(" ", "").Split(CChar(","))
                .Extensions.Add(ext)
            Next
            item.SubItems(chCatExtensions.Index).Text = TextBoxExtensions.Text

            If .Color <> ButtonCatColor.BackColor Then
                .Color = ButtonCatColor.BackColor
                item.SubItems(chCatColor.Index).Text = .Color.ToArgb.ToString
            End If

            If .ShortCutName <> TextBoxShortcut.Text Then
                .ShortCut = If(shortcutIsValid,
                                CType(TextBoxShortcut.Tag, Keys),
                                Keys.None)
                .ShortCutName = TextBoxShortcut.Text
                item.SubItems(chCatShortcut.Index).Text = .ShortCutName
                item.SubItems(chCatShortcut.Index).Tag = .ShortCut
            End If
        End With

        ListViewCats.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub TextBoxLocation_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLocation.TextChanged
        UpdateSelectedPathItem()
    End Sub

    Private Sub ButtonOpen_Click(sender As Object, e As EventArgs) Handles ButtonOpen.Click
        With FolderBrowserDialogPath
            .Description = "Select the new location for the '" + selPathItem.ShortPathName + "' folder"
            .SelectedPath = selPathItem.FullPathName
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If .SelectedPath <> selPathItem.FullPathName Then
                    TextBoxLocation.Text = .SelectedPath
                End If
            End If
        End With
    End Sub

    Private Sub ButtonPathAdd_Click(sender As Object, e As EventArgs) Handles ButtonPathAdd.Click
        With FolderBrowserDialogPath
            .Description = "Select the folder to add to the list of folders that LeyLaunch will use for its searches"
            .RootFolder = Environment.SpecialFolder.MyComputer
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim sp As SearchPath = New SearchPath(.SelectedPath, False)
                searchEngine.SearchPaths.Add(sp)
                AddSearchPath(sp, True)
            End If
        End With
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
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

        FormMain.SearchEngineApi = Me.searchEngine
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonPathRemove.Click
        For Each sp As SearchPath In searchEngine.SearchPaths
            If sp = selPathItem Then
                searchEngine.SearchPaths.Remove(sp)
                ListViewFolders.Items.Remove(ListViewFolders.SelectedItems(0))
                TreeViewExceptions.Nodes.Clear()
                Exit For
            End If
        Next
    End Sub

    Private Sub ListViewCats_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListViewCats.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub ListViewCats_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListViewCats.DrawItem
        'e.DrawText()
    End Sub

    Private Sub ListViewCats_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles ListViewCats.DrawSubItem
        If e.ColumnIndex = 1 Then
            Dim backColor As SolidBrush
            Dim s As Integer = e.Bounds.Height - 4
            Dim r As Rectangle = New Rectangle(e.Bounds.Left + e.Bounds.Width \ 2 - s \ 2, e.Bounds.Top + 1, s, s)
            Dim isSelected As Boolean = (ListViewCats.SelectedItems.Count > 0) AndAlso (ListViewCats.SelectedIndices(0) = e.ItemIndex)

            If ListViewCats.Enabled Then
                If isSelected Then
                    backColor = If(ListViewCats.Focused,
                        New SolidBrush(Color.FromKnownColor(KnownColor.Highlight)),
                        New SolidBrush(Color.FromKnownColor(KnownColor.Control)))
                Else
                    backColor = If(ListViewCats.Focused,
                                    New SolidBrush(e.SubItem.BackColor),
                                    If(isSelected,
                                        New SolidBrush(Color.FromKnownColor(KnownColor.Control)),
                                        New SolidBrush(e.SubItem.BackColor)))
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

    Private Sub ListViewCats_EnabledChanged(sender As Object, e As EventArgs) Handles ListViewCats.EnabledChanged
        ListViewCats.Invalidate()
    End Sub

    Private Sub ListViewCats_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewCats.SelectedIndexChanged
        If ListViewCats.SelectedItems.Count = 0 Then
            GroupBoxCatInfo.Enabled = False
            gbExtensions.Enabled = False
            Exit Sub
        End If

        isUpdating = True
        selCatItem = CType(ListViewCats.SelectedItems(0).Tag, SearchCategory)

        GroupBoxCatInfo.Enabled = True
        gbExtensions.Enabled = True

        TextBoxCatName.Text = selCatItem.Name
        TextBoxExtensions.Text = ListViewCats.SelectedItems(0).SubItems(chCatExtensions.Index).Text
        ButtonCatColor.BackColor = selCatItem.Color
        TextBoxShortcut.Text = selCatItem.ShortCutName
        TextBoxShortcut.Tag = selCatItem.ShortCut

        Dim extItem As ListViewItem
        For Each extItem In ListViewExt.CheckedItems
            If extItem.Checked = True Then
                With extItem
                    .Checked = False
                    .Font = New Font(extItem.Font, FontStyle.Regular)
                End With
            End If
        Next

        Dim extA() As String
        For Each ext As String In selCatItem.Extensions
            For Each extItem In ListViewExt.Items
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

    Private Sub ButtonCatColor_Click(sender As Object, e As EventArgs) Handles ButtonCatColor.Click
        With ColorDialogCategories
            .AllowFullOpen = True
            .AnyColor = True
            .Color = selCatItem.Color
            .FullOpen = True
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ButtonCatColor.BackColor = .Color
                UpdateSelectedCategoryItem()
            End If
        End With
    End Sub

    Private Sub TextBoxCatName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCatName.TextChanged
        UpdateSelectedCategoryItem()
    End Sub

    Private Sub ListViewExt_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListViewExt.ItemChecked
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
        TextBoxExtensions.Text = Join(selCatItem.Extensions.ToArray, ", ")
        ListViewCats.SelectedItems(0).SubItems(chCatExtensions.Index).Text = Join(selCatItem.Extensions.ToArray, ", ")
        ListViewCats.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        isUpdating = False
    End Sub

    Private Sub TextBoxShortcut_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxShortcut.KeyDown
        If e.KeyValue >= 31 Then
            TextBoxShortcut.Tag = e.KeyData
            shortcutIsValid = True
        Else
            shortcutIsValid = False
        End If

        TextBoxShortcut.Text = SearchCategory.KeysToString(e.KeyData)
    End Sub

    Private Sub TextBoxShortcut_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxShortcut.KeyUp
        If shortcutIsValid = False Then
            TextBoxShortcut.Text = Keys.None.ToString
            TextBoxShortcut.Tag = New KeyEventArgs(Keys.None)
        End If

        UpdateSelectedCategoryItem()
    End Sub

    Private Sub ButtonCatAdd_Click(sender As Object, e As EventArgs) Handles ButtonCatAdd.Click
        Dim c As New SearchCategory With {.Name = "[New Category]"}
        searchEngine.Categories.Add(c)
        AddCategory(c, True)
        TextBoxCatName.Focus()
        TextBoxCatName.SelectAll()
    End Sub

    Private Sub ButtonDefaults_Click(sender As Object, e As EventArgs) Handles ButtonDefaults.Click
        If MsgBox("Are you sure you want to load the default paths and categories?" + vbCrLf + vbCrLf + "Note that this action cannot be undone and you will loose all your custom paths and categories",
                    MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Load Defaults") = MsgBoxResult.Yes Then
            FormMain.LoadDefaultSearchPreferences()
            SetupUI()
        End If
    End Sub

    Private Sub HandleDragOver(sender As Object, e As DragEventArgs)
        e.Effect = If(e.Data.GetDataPresent(DataFormats.FileDrop),
                        DragDropEffects.All,
                        DragDropEffects.None)
    End Sub

    Private Sub HandleDragDrop(sender As Object, e As DragEventArgs)
        FormMain.HandleDroppedFiles(e)
        SetupUI()
    End Sub

    Private Sub ContextMenuExceptionsToggleChildNodes_Click(sender As Object, e As EventArgs) Handles ContextMenuExceptionsToggleChildNodes.Click
        For Each cNode As TreeNode In TreeViewExceptions.SelectedNode.Nodes
            cNode.Checked = Not cNode.Checked
        Next
    End Sub

    Private Sub ContextMenuExceptions_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuExceptions.Opening
        ContextMenuExceptionsBrowse.Enabled = (TreeViewExceptions.SelectedNode IsNot Nothing)
        ContextMenuExceptionsToggleChildNodes.Enabled = (TreeViewExceptions.SelectedNode IsNot Nothing)
    End Sub

    Private Sub ContextMenuExceptionsBrowse_Click(sender As Object, e As EventArgs) Handles ContextMenuExceptionsBrowse.Click
        KLListViewItem.OpenContainingFolder(selPathItem.FullPathName + "\" + TreeViewExceptions.SelectedNode.FullPath)
    End Sub

#Region "Extensions Editor"
    Private Sub ButtonEditExtensions_Click(sender As Object, e As EventArgs) Handles ButtonEditExtensions.Click
        ListBoxExtensions.Items.Clear()

        For Each ext As String In selCatItem.Extensions
            ListBoxExtensions.Items.Add(ext)
        Next
        If ListBoxExtensions.Items.Count = 0 Then
            ButtonEditExt.Enabled = False
            ButtonDeleteExt.Enabled = False
        Else
            ListBoxExtensions.SelectedIndex = 0
        End If

        PanelExtEditor.Top = TabControlSections.Top + tpCategories.Top + spCategories.Top + spCategories.Panel2.Top + GroupBoxCatInfo.Top + TextBoxExtensions.Bottom
        PanelExtEditor.Left = TabControlSections.Left + tpCategories.Left + spCategories.Left + spCategories.Panel2.Left + GroupBoxCatInfo.Left + TextBoxExtensions.Left
        PanelExtEditor.Width = TextBoxExtensions.Width
        PanelExtEditor.Visible = True
    End Sub

    Private Sub ButtonCloseExtEditor_Click(sender As Object, e As EventArgs) Handles ButtonCloseExtEditor.Click
        CloseExtensionsEditor()
    End Sub

    Private Sub PanelExtEditor_LostFocus(sender As Object, e As EventArgs) Handles PanelExtEditor.LostFocus
        CloseExtensionsEditor()
    End Sub

    Private Sub CloseExtensionsEditor()
        Dim exts As String = ""
        For Each ext As String In ListBoxExtensions.Items
            exts += ext + ", "
        Next
        exts = exts.Substring(0, exts.Length - 2)
        TextBoxExtensions.Text = exts

        PanelExtEditor.Visible = False

        UpdateSelectedCategoryItem()
    End Sub

    Private Sub ListBoxExtensions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxExtensions.SelectedIndexChanged
        UpdateExtEditorUI()
    End Sub

    Private Sub UpdateExtEditorUI()
        If ListBoxExtensions.Items.Count = 0 OrElse ListBoxExtensions.SelectedItems.Count = 0 Then
            ButtonEditExt.Enabled = False
            ButtonDeleteExt.Enabled = False
        Else
            ButtonEditExt.Enabled = True
            ButtonDeleteExt.Enabled = True
        End If
    End Sub

    Private Sub ButtonAddExt_Click(sender As Object, e As EventArgs) Handles ButtonAddExt.Click
        TextBoxExtension.Text = TextBoxExtension.Text.ToLower

        If TextBoxExtension.Text = "" Then Exit Sub
        If TextBoxExtension.Text.StartsWith(".") = False Then TextBoxExtension.Text = "." + TextBoxExtension.Text
        If ListBoxExtensions.Items.Contains(TextBoxExtension.Text) Then Exit Sub

        ListBoxExtensions.Items.Add(TextBoxExtension.Text)
        ListBoxExtensions.SelectedIndex = ListBoxExtensions.Items.IndexOf(TextBoxExtension.Text)

        TextBoxExtension.Text = ""
    End Sub

    Private Sub ButtonEditExt_Click(sender As Object, e As EventArgs) Handles ButtonEditExt.Click
        Dim ext As String = CType(ListBoxExtensions.SelectedItem, String)
        ListBoxExtensions.Items.Remove(ListBoxExtensions.SelectedItem)

        Application.DoEvents()

        TextBoxExtension.Text = ext
        TextBoxExtension.Focus()
    End Sub

    Private Sub ButtonDeleteExt_Click(sender As Object, e As EventArgs) Handles ButtonDeleteExt.Click
        ListBoxExtensions.Items.Remove(ListBoxExtensions.SelectedItem)

        UpdateExtEditorUI()
    End Sub
#End Region
End Class
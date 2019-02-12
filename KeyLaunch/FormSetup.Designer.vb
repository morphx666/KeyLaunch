<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSetup))
        Me.TabControlSections = New System.Windows.Forms.TabControl()
        Me.tpPaths = New System.Windows.Forms.TabPage()
        Me.spPaths = New System.Windows.Forms.SplitContainer()
        Me.ButtonPathRemove = New System.Windows.Forms.Button()
        Me.ButtonPathAdd = New System.Windows.Forms.Button()
        Me.ListViewFolders = New KeyLaunch.FFListView()
        Me.chPathsFolderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPathsRecurse = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPathsExceptions = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPathsFullPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CheckBoxRecurse = New System.Windows.Forms.CheckBox()
        Me.GroupBoxRecurse = New System.Windows.Forms.GroupBox()
        Me.ProgressBarExceptions = New System.Windows.Forms.ProgressBar()
        Me.TreeViewExceptions = New System.Windows.Forms.TreeView()
        Me.ContextMenuExceptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuExceptionsToggleChildNodes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuExceptionsBrowse = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBoxFolderInfo = New System.Windows.Forms.GroupBox()
        Me.ButtonOpen = New System.Windows.Forms.Button()
        Me.TextBoxLocation = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpCategories = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.spCategories = New System.Windows.Forms.SplitContainer()
        Me.ButtonCatRem = New System.Windows.Forms.Button()
        Me.ButtonCatAdd = New System.Windows.Forms.Button()
        Me.ListViewCats = New KeyLaunch.FFListView()
        Me.chCatName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCatColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCatShortcut = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCatExtensions = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbExtensions = New System.Windows.Forms.GroupBox()
        Me.ProgressBarExtensions = New System.Windows.Forms.ProgressBar()
        Me.ListViewExt = New KeyLaunch.FFListView()
        Me.chExtDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chExtExtensions = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chExtOpensWith = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageListExtIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBoxCatInfo = New System.Windows.Forms.GroupBox()
        Me.ButtonEditExtensions = New System.Windows.Forms.Button()
        Me.TextBoxShortcut = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxExtensions = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ButtonCatColor = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxCatName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialogPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ColorDialogCategories = New System.Windows.Forms.ColorDialog()
        Me.ButtonDefaults = New System.Windows.Forms.Button()
        Me.PanelExtEditor = New System.Windows.Forms.Panel()
        Me.ButtonCloseExtEditor = New System.Windows.Forms.Button()
        Me.ButtonDeleteExt = New System.Windows.Forms.Button()
        Me.ButtonEditExt = New System.Windows.Forms.Button()
        Me.ButtonAddExt = New System.Windows.Forms.Button()
        Me.TextBoxExtension = New System.Windows.Forms.TextBox()
        Me.ListBoxExtensions = New System.Windows.Forms.ListBox()
        Me.TabControlSections.SuspendLayout()
        Me.tpPaths.SuspendLayout()
        CType(Me.spPaths, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spPaths.Panel1.SuspendLayout()
        Me.spPaths.Panel2.SuspendLayout()
        Me.spPaths.SuspendLayout()
        Me.GroupBoxRecurse.SuspendLayout()
        Me.ContextMenuExceptions.SuspendLayout()
        Me.GroupBoxFolderInfo.SuspendLayout()
        Me.tpCategories.SuspendLayout()
        CType(Me.spCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spCategories.Panel1.SuspendLayout()
        Me.spCategories.Panel2.SuspendLayout()
        Me.spCategories.SuspendLayout()
        Me.gbExtensions.SuspendLayout()
        Me.GroupBoxCatInfo.SuspendLayout()
        Me.PanelExtEditor.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlSections
        '
        Me.TabControlSections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlSections.Controls.Add(Me.tpPaths)
        Me.TabControlSections.Controls.Add(Me.tpCategories)
        Me.TabControlSections.ImageList = Me.ImageListExtIcons
        Me.TabControlSections.Location = New System.Drawing.Point(12, 12)
        Me.TabControlSections.Name = "TabControlSections"
        Me.TabControlSections.SelectedIndex = 0
        Me.TabControlSections.Size = New System.Drawing.Size(794, 398)
        Me.TabControlSections.TabIndex = 0
        '
        'tpPaths
        '
        Me.tpPaths.Controls.Add(Me.spPaths)
        Me.tpPaths.Controls.Add(Me.Label1)
        Me.tpPaths.Location = New System.Drawing.Point(4, 23)
        Me.tpPaths.Name = "tpPaths"
        Me.tpPaths.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPaths.Size = New System.Drawing.Size(786, 371)
        Me.tpPaths.TabIndex = 1
        Me.tpPaths.Text = "Paths"
        Me.tpPaths.UseVisualStyleBackColor = True
        '
        'spPaths
        '
        Me.spPaths.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spPaths.Location = New System.Drawing.Point(6, 37)
        Me.spPaths.Name = "spPaths"
        '
        'spPaths.Panel1
        '
        Me.spPaths.Panel1.Controls.Add(Me.ButtonPathRemove)
        Me.spPaths.Panel1.Controls.Add(Me.ButtonPathAdd)
        Me.spPaths.Panel1.Controls.Add(Me.ListViewFolders)
        Me.spPaths.Panel1MinSize = 100
        '
        'spPaths.Panel2
        '
        Me.spPaths.Panel2.Controls.Add(Me.CheckBoxRecurse)
        Me.spPaths.Panel2.Controls.Add(Me.GroupBoxRecurse)
        Me.spPaths.Panel2.Controls.Add(Me.GroupBoxFolderInfo)
        Me.spPaths.Panel2MinSize = 100
        Me.spPaths.Size = New System.Drawing.Size(774, 329)
        Me.spPaths.SplitterDistance = 329
        Me.spPaths.TabIndex = 3
        '
        'ButtonPathRemove
        '
        Me.ButtonPathRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonPathRemove.Location = New System.Drawing.Point(84, 303)
        Me.ButtonPathRemove.Name = "ButtonPathRemove"
        Me.ButtonPathRemove.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPathRemove.TabIndex = 6
        Me.ButtonPathRemove.Text = "Remove"
        Me.ButtonPathRemove.UseVisualStyleBackColor = True
        '
        'ButtonPathAdd
        '
        Me.ButtonPathAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonPathAdd.Image = Global.KeyLaunch.My.Resources.Resources.NewFolderHS
        Me.ButtonPathAdd.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ButtonPathAdd.Location = New System.Drawing.Point(3, 303)
        Me.ButtonPathAdd.Name = "ButtonPathAdd"
        Me.ButtonPathAdd.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.ButtonPathAdd.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPathAdd.TabIndex = 5
        Me.ButtonPathAdd.Text = "Add"
        Me.ButtonPathAdd.UseVisualStyleBackColor = True
        '
        'ListViewFolders
        '
        Me.ListViewFolders.AllowColumnReorder = True
        Me.ListViewFolders.AllowDrop = True
        Me.ListViewFolders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewFolders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chPathsFolderName, Me.chPathsRecurse, Me.chPathsExceptions, Me.chPathsFullPath})
        Me.ListViewFolders.FullRowSelect = True
        Me.ListViewFolders.GridLines = True
        Me.ListViewFolders.HideSelection = False
        Me.ListViewFolders.Location = New System.Drawing.Point(3, 3)
        Me.ListViewFolders.MultiSelect = False
        Me.ListViewFolders.Name = "ListViewFolders"
        Me.ListViewFolders.Size = New System.Drawing.Size(323, 294)
        Me.ListViewFolders.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewFolders.TabIndex = 4
        Me.ListViewFolders.UseCompatibleStateImageBehavior = False
        Me.ListViewFolders.View = System.Windows.Forms.View.Details
        '
        'chPathsFolderName
        '
        Me.chPathsFolderName.Text = "Folder"
        '
        'chPathsRecurse
        '
        Me.chPathsRecurse.Text = "Recurse"
        '
        'chPathsExceptions
        '
        Me.chPathsExceptions.Text = "Exceptions"
        Me.chPathsExceptions.Width = 80
        '
        'chPathsFullPath
        '
        Me.chPathsFullPath.Text = "Full Path"
        '
        'CheckBoxRecurse
        '
        Me.CheckBoxRecurse.AutoSize = True
        Me.CheckBoxRecurse.Location = New System.Drawing.Point(12, 92)
        Me.CheckBoxRecurse.Name = "CheckBoxRecurse"
        Me.CheckBoxRecurse.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxRecurse.TabIndex = 8
        Me.CheckBoxRecurse.UseVisualStyleBackColor = True
        '
        'GroupBoxRecurse
        '
        Me.GroupBoxRecurse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxRecurse.Controls.Add(Me.ProgressBarExceptions)
        Me.GroupBoxRecurse.Controls.Add(Me.TreeViewExceptions)
        Me.GroupBoxRecurse.Controls.Add(Me.Label4)
        Me.GroupBoxRecurse.Location = New System.Drawing.Point(3, 92)
        Me.GroupBoxRecurse.Name = "GroupBoxRecurse"
        Me.GroupBoxRecurse.Size = New System.Drawing.Size(435, 234)
        Me.GroupBoxRecurse.TabIndex = 7
        Me.GroupBoxRecurse.TabStop = False
        Me.GroupBoxRecurse.Text = "     Recursive Search"
        '
        'ProgressBarExceptions
        '
        Me.ProgressBarExceptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarExceptions.Location = New System.Drawing.Point(119, 0)
        Me.ProgressBarExceptions.Name = "ProgressBarExceptions"
        Me.ProgressBarExceptions.Size = New System.Drawing.Size(309, 13)
        Me.ProgressBarExceptions.TabIndex = 7
        Me.ProgressBarExceptions.Visible = False
        '
        'TreeViewExceptions
        '
        Me.TreeViewExceptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeViewExceptions.CheckBoxes = True
        Me.TreeViewExceptions.ContextMenuStrip = Me.ContextMenuExceptions
        Me.TreeViewExceptions.HideSelection = False
        Me.TreeViewExceptions.Location = New System.Drawing.Point(9, 38)
        Me.TreeViewExceptions.Name = "TreeViewExceptions"
        Me.TreeViewExceptions.Size = New System.Drawing.Size(419, 190)
        Me.TreeViewExceptions.TabIndex = 3
        '
        'ContextMenuExceptions
        '
        Me.ContextMenuExceptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuExceptionsToggleChildNodes, Me.ToolStripMenuItem1, Me.ContextMenuExceptionsBrowse})
        Me.ContextMenuExceptions.Name = "cmsExceptions"
        Me.ContextMenuExceptions.Size = New System.Drawing.Size(181, 76)
        '
        'ContextMenuExceptionsToggleChildNodes
        '
        Me.ContextMenuExceptionsToggleChildNodes.Name = "ContextMenuExceptionsToggleChildNodes"
        Me.ContextMenuExceptionsToggleChildNodes.Size = New System.Drawing.Size(180, 22)
        Me.ContextMenuExceptionsToggleChildNodes.Text = "Toggle Child Nodes"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 6)
        '
        'ContextMenuExceptionsBrowse
        '
        Me.ContextMenuExceptionsBrowse.Name = "ContextMenuExceptionsBrowse"
        Me.ContextMenuExceptionsBrowse.Size = New System.Drawing.Size(180, 22)
        Me.ContextMenuExceptionsBrowse.Text = "Browse..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Exceptions"
        '
        'GroupBoxFolderInfo
        '
        Me.GroupBoxFolderInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxFolderInfo.Controls.Add(Me.ButtonOpen)
        Me.GroupBoxFolderInfo.Controls.Add(Me.TextBoxLocation)
        Me.GroupBoxFolderInfo.Controls.Add(Me.Label3)
        Me.GroupBoxFolderInfo.Controls.Add(Me.TextBoxName)
        Me.GroupBoxFolderInfo.Controls.Add(Me.Label2)
        Me.GroupBoxFolderInfo.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxFolderInfo.Name = "GroupBoxFolderInfo"
        Me.GroupBoxFolderInfo.Size = New System.Drawing.Size(435, 83)
        Me.GroupBoxFolderInfo.TabIndex = 6
        Me.GroupBoxFolderInfo.TabStop = False
        Me.GroupBoxFolderInfo.Text = "Folder Information"
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOpen.FlatAppearance.BorderSize = 0
        Me.ButtonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpen.Image = CType(resources.GetObject("ButtonOpen.Image"), System.Drawing.Image)
        Me.ButtonOpen.Location = New System.Drawing.Point(407, 45)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(21, 20)
        Me.ButtonOpen.TabIndex = 4
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'TextBoxLocation
        '
        Me.TextBoxLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLocation.Location = New System.Drawing.Point(60, 45)
        Me.TextBoxLocation.Name = "TextBoxLocation"
        Me.TextBoxLocation.ReadOnly = True
        Me.TextBoxLocation.Size = New System.Drawing.Size(341, 20)
        Me.TextBoxLocation.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Location"
        '
        'TextBoxName
        '
        Me.TextBoxName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxName.Location = New System.Drawing.Point(60, 19)
        Me.TextBoxName.Name = "TextBoxName"
        Me.TextBoxName.Size = New System.Drawing.Size(368, 20)
        Me.TextBoxName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(774, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "The folders listed here are the folders that KeyLaunch will scan whenever you per" &
    "form a search." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To add folders, use the Add button or simply drop them over the " &
    "folders list."
        '
        'tpCategories
        '
        Me.tpCategories.Controls.Add(Me.Label5)
        Me.tpCategories.Controls.Add(Me.spCategories)
        Me.tpCategories.Location = New System.Drawing.Point(4, 23)
        Me.tpCategories.Name = "tpCategories"
        Me.tpCategories.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCategories.Size = New System.Drawing.Size(786, 371)
        Me.tpCategories.TabIndex = 2
        Me.tpCategories.Text = "Categories"
        Me.tpCategories.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.Info
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(6, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(774, 31)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Each category groups a series of file types that KeyLaunch will search for." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Use " &
    "the Add button to add new categories or simply drop files over one of the catego" &
    "ries to add a new file type."
        '
        'spCategories
        '
        Me.spCategories.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spCategories.Location = New System.Drawing.Point(6, 37)
        Me.spCategories.Name = "spCategories"
        '
        'spCategories.Panel1
        '
        Me.spCategories.Panel1.Controls.Add(Me.ButtonCatRem)
        Me.spCategories.Panel1.Controls.Add(Me.ButtonCatAdd)
        Me.spCategories.Panel1.Controls.Add(Me.ListViewCats)
        '
        'spCategories.Panel2
        '
        Me.spCategories.Panel2.Controls.Add(Me.gbExtensions)
        Me.spCategories.Panel2.Controls.Add(Me.GroupBoxCatInfo)
        Me.spCategories.Size = New System.Drawing.Size(774, 329)
        Me.spCategories.SplitterDistance = 305
        Me.spCategories.TabIndex = 3
        '
        'ButtonCatRem
        '
        Me.ButtonCatRem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCatRem.Location = New System.Drawing.Point(84, 303)
        Me.ButtonCatRem.Name = "ButtonCatRem"
        Me.ButtonCatRem.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCatRem.TabIndex = 8
        Me.ButtonCatRem.Text = "Remove"
        Me.ButtonCatRem.UseVisualStyleBackColor = True
        '
        'ButtonCatAdd
        '
        Me.ButtonCatAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCatAdd.Image = Global.KeyLaunch.My.Resources.Resources.newreportHS
        Me.ButtonCatAdd.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ButtonCatAdd.Location = New System.Drawing.Point(3, 303)
        Me.ButtonCatAdd.Name = "ButtonCatAdd"
        Me.ButtonCatAdd.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.ButtonCatAdd.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCatAdd.TabIndex = 7
        Me.ButtonCatAdd.Text = "Add"
        Me.ButtonCatAdd.UseVisualStyleBackColor = True
        '
        'ListViewCats
        '
        Me.ListViewCats.AllowColumnReorder = True
        Me.ListViewCats.AllowDrop = True
        Me.ListViewCats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewCats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCatName, Me.chCatColor, Me.chCatShortcut, Me.chCatExtensions})
        Me.ListViewCats.FullRowSelect = True
        Me.ListViewCats.GridLines = True
        Me.ListViewCats.HideSelection = False
        Me.ListViewCats.Location = New System.Drawing.Point(3, 3)
        Me.ListViewCats.MultiSelect = False
        Me.ListViewCats.Name = "ListViewCats"
        Me.ListViewCats.OwnerDraw = True
        Me.ListViewCats.Size = New System.Drawing.Size(299, 294)
        Me.ListViewCats.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewCats.TabIndex = 4
        Me.ListViewCats.UseCompatibleStateImageBehavior = False
        Me.ListViewCats.View = System.Windows.Forms.View.Details
        '
        'chCatName
        '
        Me.chCatName.Text = "Name"
        '
        'chCatColor
        '
        Me.chCatColor.Text = "Color"
        Me.chCatColor.Width = 80
        '
        'chCatShortcut
        '
        Me.chCatShortcut.Text = "Shortcut"
        '
        'chCatExtensions
        '
        Me.chCatExtensions.Text = "Extensions"
        '
        'gbExtensions
        '
        Me.gbExtensions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbExtensions.Controls.Add(Me.ProgressBarExtensions)
        Me.gbExtensions.Controls.Add(Me.ListViewExt)
        Me.gbExtensions.Location = New System.Drawing.Point(3, 109)
        Me.gbExtensions.Name = "gbExtensions"
        Me.gbExtensions.Size = New System.Drawing.Size(459, 217)
        Me.gbExtensions.TabIndex = 8
        Me.gbExtensions.TabStop = False
        Me.gbExtensions.Text = "Extensions"
        '
        'ProgressBarExtensions
        '
        Me.ProgressBarExtensions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarExtensions.Location = New System.Drawing.Point(70, 0)
        Me.ProgressBarExtensions.Name = "ProgressBarExtensions"
        Me.ProgressBarExtensions.Size = New System.Drawing.Size(383, 13)
        Me.ProgressBarExtensions.TabIndex = 6
        '
        'ListViewExt
        '
        Me.ListViewExt.AllowColumnReorder = True
        Me.ListViewExt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewExt.CheckBoxes = True
        Me.ListViewExt.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chExtDescription, Me.chExtExtensions, Me.chExtOpensWith})
        Me.ListViewExt.FullRowSelect = True
        Me.ListViewExt.GridLines = True
        Me.ListViewExt.Location = New System.Drawing.Point(6, 19)
        Me.ListViewExt.Name = "ListViewExt"
        Me.ListViewExt.Size = New System.Drawing.Size(447, 192)
        Me.ListViewExt.SmallImageList = Me.ImageListExtIcons
        Me.ListViewExt.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewExt.TabIndex = 5
        Me.ListViewExt.UseCompatibleStateImageBehavior = False
        Me.ListViewExt.View = System.Windows.Forms.View.Details
        '
        'chExtDescription
        '
        Me.chExtDescription.Text = "Description"
        Me.chExtDescription.Width = 125
        '
        'chExtExtensions
        '
        Me.chExtExtensions.Text = "Extensions"
        Me.chExtExtensions.Width = 100
        '
        'chExtOpensWith
        '
        Me.chExtOpensWith.Text = "Opens With"
        Me.chExtOpensWith.Width = 100
        '
        'ImageListExtIcons
        '
        Me.ImageListExtIcons.ImageStream = CType(resources.GetObject("ImageListExtIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListExtIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListExtIcons.Images.SetKeyName(0, "")
        Me.ImageListExtIcons.Images.SetKeyName(1, "")
        '
        'GroupBoxCatInfo
        '
        Me.GroupBoxCatInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxCatInfo.Controls.Add(Me.ButtonEditExtensions)
        Me.GroupBoxCatInfo.Controls.Add(Me.TextBoxShortcut)
        Me.GroupBoxCatInfo.Controls.Add(Me.Label9)
        Me.GroupBoxCatInfo.Controls.Add(Me.TextBoxExtensions)
        Me.GroupBoxCatInfo.Controls.Add(Me.Label7)
        Me.GroupBoxCatInfo.Controls.Add(Me.ButtonCatColor)
        Me.GroupBoxCatInfo.Controls.Add(Me.Label8)
        Me.GroupBoxCatInfo.Controls.Add(Me.TextBoxCatName)
        Me.GroupBoxCatInfo.Controls.Add(Me.Label6)
        Me.GroupBoxCatInfo.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxCatInfo.Name = "GroupBoxCatInfo"
        Me.GroupBoxCatInfo.Size = New System.Drawing.Size(459, 100)
        Me.GroupBoxCatInfo.TabIndex = 7
        Me.GroupBoxCatInfo.TabStop = False
        Me.GroupBoxCatInfo.Text = "Category Information"
        '
        'ButtonEditExtensions
        '
        Me.ButtonEditExtensions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEditExtensions.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonEditExtensions.Location = New System.Drawing.Point(392, 45)
        Me.ButtonEditExtensions.Name = "ButtonEditExtensions"
        Me.ButtonEditExtensions.Size = New System.Drawing.Size(61, 20)
        Me.ButtonEditExtensions.TabIndex = 14
        Me.ButtonEditExtensions.Text = "Edit"
        Me.ButtonEditExtensions.UseVisualStyleBackColor = True
        '
        'TextBoxShortcut
        '
        Me.TextBoxShortcut.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TextBoxShortcut.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.TextBoxShortcut.Location = New System.Drawing.Point(70, 71)
        Me.TextBoxShortcut.Name = "TextBoxShortcut"
        Me.TextBoxShortcut.ReadOnly = True
        Me.TextBoxShortcut.Size = New System.Drawing.Size(203, 20)
        Me.TextBoxShortcut.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Shortcut"
        '
        'TextBoxExtensions
        '
        Me.TextBoxExtensions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxExtensions.Location = New System.Drawing.Point(70, 45)
        Me.TextBoxExtensions.Name = "TextBoxExtensions"
        Me.TextBoxExtensions.ReadOnly = True
        Me.TextBoxExtensions.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxExtensions.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Extensions"
        '
        'ButtonCatColor
        '
        Me.ButtonCatColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCatColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCatColor.Location = New System.Drawing.Point(432, 71)
        Me.ButtonCatColor.Name = "ButtonCatColor"
        Me.ButtonCatColor.Size = New System.Drawing.Size(21, 20)
        Me.ButtonCatColor.TabIndex = 9
        Me.ButtonCatColor.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(395, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Color"
        '
        'TextBoxCatName
        '
        Me.TextBoxCatName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCatName.Location = New System.Drawing.Point(70, 19)
        Me.TextBoxCatName.Name = "TextBoxCatName"
        Me.TextBoxCatName.Size = New System.Drawing.Size(383, 20)
        Me.TextBoxCatName.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Name"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(731, 416)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(650, 416)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonDefaults
        '
        Me.ButtonDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDefaults.Location = New System.Drawing.Point(12, 416)
        Me.ButtonDefaults.Name = "ButtonDefaults"
        Me.ButtonDefaults.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDefaults.TabIndex = 3
        Me.ButtonDefaults.Text = "Defaults"
        Me.ButtonDefaults.UseVisualStyleBackColor = True
        '
        'PanelExtEditor
        '
        Me.PanelExtEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelExtEditor.Controls.Add(Me.ButtonCloseExtEditor)
        Me.PanelExtEditor.Controls.Add(Me.ButtonDeleteExt)
        Me.PanelExtEditor.Controls.Add(Me.ButtonEditExt)
        Me.PanelExtEditor.Controls.Add(Me.ButtonAddExt)
        Me.PanelExtEditor.Controls.Add(Me.TextBoxExtension)
        Me.PanelExtEditor.Controls.Add(Me.ListBoxExtensions)
        Me.PanelExtEditor.Location = New System.Drawing.Point(106, 12)
        Me.PanelExtEditor.MinimumSize = New System.Drawing.Size(175, 153)
        Me.PanelExtEditor.Name = "PanelExtEditor"
        Me.PanelExtEditor.Size = New System.Drawing.Size(175, 153)
        Me.PanelExtEditor.TabIndex = 4
        Me.PanelExtEditor.Visible = False
        '
        'ButtonCloseExtEditor
        '
        Me.ButtonCloseExtEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCloseExtEditor.Location = New System.Drawing.Point(90, 64)
        Me.ButtonCloseExtEditor.Name = "ButtonCloseExtEditor"
        Me.ButtonCloseExtEditor.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloseExtEditor.TabIndex = 5
        Me.ButtonCloseExtEditor.Text = "Close"
        Me.ButtonCloseExtEditor.UseVisualStyleBackColor = True
        '
        'ButtonDeleteExt
        '
        Me.ButtonDeleteExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDeleteExt.Location = New System.Drawing.Point(90, 34)
        Me.ButtonDeleteExt.Name = "ButtonDeleteExt"
        Me.ButtonDeleteExt.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDeleteExt.TabIndex = 4
        Me.ButtonDeleteExt.Text = "Delete"
        Me.ButtonDeleteExt.UseVisualStyleBackColor = True
        '
        'ButtonEditExt
        '
        Me.ButtonEditExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEditExt.Location = New System.Drawing.Point(90, 5)
        Me.ButtonEditExt.Name = "ButtonEditExt"
        Me.ButtonEditExt.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEditExt.TabIndex = 3
        Me.ButtonEditExt.Text = "Edit"
        Me.ButtonEditExt.UseVisualStyleBackColor = True
        '
        'ButtonAddExt
        '
        Me.ButtonAddExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddExt.Location = New System.Drawing.Point(90, 121)
        Me.ButtonAddExt.Name = "ButtonAddExt"
        Me.ButtonAddExt.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAddExt.TabIndex = 2
        Me.ButtonAddExt.Text = "Add"
        Me.ButtonAddExt.UseVisualStyleBackColor = True
        '
        'TextBoxExtension
        '
        Me.TextBoxExtension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxExtension.Location = New System.Drawing.Point(7, 122)
        Me.TextBoxExtension.Name = "TextBoxExtension"
        Me.TextBoxExtension.Size = New System.Drawing.Size(77, 20)
        Me.TextBoxExtension.TabIndex = 1
        '
        'ListBoxExtensions
        '
        Me.ListBoxExtensions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxExtensions.FormattingEnabled = True
        Me.ListBoxExtensions.IntegralHeight = False
        Me.ListBoxExtensions.Location = New System.Drawing.Point(7, 5)
        Me.ListBoxExtensions.Name = "ListBoxExtensions"
        Me.ListBoxExtensions.Size = New System.Drawing.Size(77, 111)
        Me.ListBoxExtensions.TabIndex = 0
        '
        'FormSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 451)
        Me.Controls.Add(Me.ButtonDefaults)
        Me.Controls.Add(Me.PanelExtEditor)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.TabControlSections)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "FormSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Configuration"
        Me.TabControlSections.ResumeLayout(False)
        Me.tpPaths.ResumeLayout(False)
        Me.spPaths.Panel1.ResumeLayout(False)
        Me.spPaths.Panel2.ResumeLayout(False)
        Me.spPaths.Panel2.PerformLayout()
        CType(Me.spPaths, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spPaths.ResumeLayout(False)
        Me.GroupBoxRecurse.ResumeLayout(False)
        Me.GroupBoxRecurse.PerformLayout()
        Me.ContextMenuExceptions.ResumeLayout(False)
        Me.GroupBoxFolderInfo.ResumeLayout(False)
        Me.GroupBoxFolderInfo.PerformLayout()
        Me.tpCategories.ResumeLayout(False)
        Me.spCategories.Panel1.ResumeLayout(False)
        Me.spCategories.Panel2.ResumeLayout(False)
        CType(Me.spCategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spCategories.ResumeLayout(False)
        Me.gbExtensions.ResumeLayout(False)
        Me.GroupBoxCatInfo.ResumeLayout(False)
        Me.GroupBoxCatInfo.PerformLayout()
        Me.PanelExtEditor.ResumeLayout(False)
        Me.PanelExtEditor.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlSections As System.Windows.Forms.TabControl
    Friend WithEvents tpPaths As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialogPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents tpCategories As System.Windows.Forms.TabPage
    Friend WithEvents ImageListExtIcons As System.Windows.Forms.ImageList
    Friend WithEvents spCategories As System.Windows.Forms.SplitContainer
    Friend WithEvents ListViewCats As KeyLaunch.FFListView
    Friend WithEvents chCatName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCatColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCatExtensions As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbExtensions As System.Windows.Forms.GroupBox
    Friend WithEvents chExtDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents chExtExtensions As System.Windows.Forms.ColumnHeader
    Friend WithEvents chExtOpensWith As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBoxCatInfo As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonCatColor As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCatName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents spPaths As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonPathRemove As System.Windows.Forms.Button
    Friend WithEvents ButtonPathAdd As System.Windows.Forms.Button
    Friend WithEvents ListViewFolders As KeyLaunch.FFListView
    Friend WithEvents chPathsFolderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPathsRecurse As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPathsExceptions As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPathsFullPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckBoxRecurse As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxRecurse As System.Windows.Forms.GroupBox
    Friend WithEvents TreeViewExceptions As System.Windows.Forms.TreeView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxFolderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonOpen As System.Windows.Forms.Button
    Friend WithEvents TextBoxLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonCatRem As System.Windows.Forms.Button
    Friend WithEvents ButtonCatAdd As System.Windows.Forms.Button
    Friend WithEvents ColorDialogCategories As System.Windows.Forms.ColorDialog
    Friend WithEvents ProgressBarExtensions As System.Windows.Forms.ProgressBar
    Friend WithEvents ListViewExt As KeyLaunch.FFListView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxShortcut As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chCatShortcut As System.Windows.Forms.ColumnHeader
    Friend WithEvents ProgressBarExceptions As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonDefaults As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuExceptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuExceptionsToggleChildNodes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuExceptionsBrowse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBoxExtensions As System.Windows.Forms.TextBox
    Friend WithEvents PanelExtEditor As System.Windows.Forms.Panel
    Friend WithEvents ButtonDeleteExt As System.Windows.Forms.Button
    Friend WithEvents ButtonEditExt As System.Windows.Forms.Button
    Friend WithEvents TextBoxExtension As System.Windows.Forms.TextBox
    Friend WithEvents ListBoxExtensions As System.Windows.Forms.ListBox
    Friend WithEvents ButtonEditExtensions As System.Windows.Forms.Button
    Friend WithEvents ButtonCloseExtEditor As System.Windows.Forms.Button
    Friend WithEvents ButtonAddExt As System.Windows.Forms.Button
End Class

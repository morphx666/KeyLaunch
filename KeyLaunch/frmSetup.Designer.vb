<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetup))
        Me.tabCtrlSections = New System.Windows.Forms.TabControl()
        Me.tpPaths = New System.Windows.Forms.TabPage()
        Me.spPaths = New System.Windows.Forms.SplitContainer()
        Me.btnPathRemove = New System.Windows.Forms.Button()
        Me.btnPathAdd = New System.Windows.Forms.Button()
        Me.chkRecurse = New System.Windows.Forms.CheckBox()
        Me.gbRecurse = New System.Windows.Forms.GroupBox()
        Me.pbExceptions = New System.Windows.Forms.ProgressBar()
        Me.tvExceptions = New System.Windows.Forms.TreeView()
        Me.cmsExceptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsExceptionsToggleChildNodes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsExceptionsBrowse = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbFolderInfo = New System.Windows.Forms.GroupBox()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpCategories = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ilExtIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.fbDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cDlg = New System.Windows.Forms.ColorDialog()
        Me.cmdDefaults = New System.Windows.Forms.Button()
        Me.pExtEditor = New System.Windows.Forms.Panel()
        Me.btnCloseExtEditor = New System.Windows.Forms.Button()
        Me.btnDeleteExt = New System.Windows.Forms.Button()
        Me.btnEditExt = New System.Windows.Forms.Button()
        Me.btnAddExt = New System.Windows.Forms.Button()
        Me.txtExtension = New System.Windows.Forms.TextBox()
        Me.lbExtensions = New System.Windows.Forms.ListBox()
        Me.lvFolders = New KeyLaunch.FFListView()
        Me.chPathsFolderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPathsRecurse = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPathsExceptions = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPathsFullPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.spCategories = New System.Windows.Forms.SplitContainer()
        Me.btnCatRem = New System.Windows.Forms.Button()
        Me.btnCatAdd = New System.Windows.Forms.Button()
        Me.lvCats = New KeyLaunch.FFListView()
        Me.chCatName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCatColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCatShortcut = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCatExtensions = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbExtensions = New System.Windows.Forms.GroupBox()
        Me.pbExtensions = New System.Windows.Forms.ProgressBar()
        Me.lvExt = New KeyLaunch.FFListView()
        Me.chExtDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chExtExtensions = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chExtOpensWith = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbCatInfo = New System.Windows.Forms.GroupBox()
        Me.btnEditExtensions = New System.Windows.Forms.Button()
        Me.txtShortcut = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtExtensions = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCatColor = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCatName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tabCtrlSections.SuspendLayout()
        Me.tpPaths.SuspendLayout()
        CType(Me.spPaths, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spPaths.Panel1.SuspendLayout()
        Me.spPaths.Panel2.SuspendLayout()
        Me.spPaths.SuspendLayout()
        Me.gbRecurse.SuspendLayout()
        Me.cmsExceptions.SuspendLayout()
        Me.gbFolderInfo.SuspendLayout()
        Me.tpCategories.SuspendLayout()
        Me.pExtEditor.SuspendLayout()
        CType(Me.spCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spCategories.Panel1.SuspendLayout()
        Me.spCategories.Panel2.SuspendLayout()
        Me.spCategories.SuspendLayout()
        Me.gbExtensions.SuspendLayout()
        Me.gbCatInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabCtrlSections
        '
        Me.tabCtrlSections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCtrlSections.Controls.Add(Me.tpPaths)
        Me.tabCtrlSections.Controls.Add(Me.tpCategories)
        Me.tabCtrlSections.ImageList = Me.ilExtIcons
        Me.tabCtrlSections.Location = New System.Drawing.Point(12, 12)
        Me.tabCtrlSections.Name = "tabCtrlSections"
        Me.tabCtrlSections.SelectedIndex = 0
        Me.tabCtrlSections.Size = New System.Drawing.Size(794, 398)
        Me.tabCtrlSections.TabIndex = 0
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
        Me.spPaths.Panel1.Controls.Add(Me.btnPathRemove)
        Me.spPaths.Panel1.Controls.Add(Me.btnPathAdd)
        Me.spPaths.Panel1.Controls.Add(Me.lvFolders)
        Me.spPaths.Panel1MinSize = 100
        '
        'spPaths.Panel2
        '
        Me.spPaths.Panel2.Controls.Add(Me.chkRecurse)
        Me.spPaths.Panel2.Controls.Add(Me.gbRecurse)
        Me.spPaths.Panel2.Controls.Add(Me.gbFolderInfo)
        Me.spPaths.Panel2MinSize = 100
        Me.spPaths.Size = New System.Drawing.Size(774, 329)
        Me.spPaths.SplitterDistance = 329
        Me.spPaths.TabIndex = 3
        '
        'btnPathRemove
        '
        Me.btnPathRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPathRemove.Location = New System.Drawing.Point(84, 303)
        Me.btnPathRemove.Name = "btnPathRemove"
        Me.btnPathRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnPathRemove.TabIndex = 6
        Me.btnPathRemove.Text = "Remove"
        Me.btnPathRemove.UseVisualStyleBackColor = True
        '
        'btnPathAdd
        '
        Me.btnPathAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPathAdd.Image = Global.KeyLaunch.My.Resources.Resources.NewFolderHS
        Me.btnPathAdd.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnPathAdd.Location = New System.Drawing.Point(3, 303)
        Me.btnPathAdd.Name = "btnPathAdd"
        Me.btnPathAdd.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnPathAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnPathAdd.TabIndex = 5
        Me.btnPathAdd.Text = "Add"
        Me.btnPathAdd.UseVisualStyleBackColor = True
        '
        'chkRecurse
        '
        Me.chkRecurse.AutoSize = True
        Me.chkRecurse.Location = New System.Drawing.Point(12, 92)
        Me.chkRecurse.Name = "chkRecurse"
        Me.chkRecurse.Size = New System.Drawing.Size(15, 14)
        Me.chkRecurse.TabIndex = 8
        Me.chkRecurse.UseVisualStyleBackColor = True
        '
        'gbRecurse
        '
        Me.gbRecurse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRecurse.Controls.Add(Me.pbExceptions)
        Me.gbRecurse.Controls.Add(Me.tvExceptions)
        Me.gbRecurse.Controls.Add(Me.Label4)
        Me.gbRecurse.Location = New System.Drawing.Point(3, 92)
        Me.gbRecurse.Name = "gbRecurse"
        Me.gbRecurse.Size = New System.Drawing.Size(435, 234)
        Me.gbRecurse.TabIndex = 7
        Me.gbRecurse.TabStop = False
        Me.gbRecurse.Text = "     Recursive Search"
        '
        'pbExceptions
        '
        Me.pbExceptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbExceptions.Location = New System.Drawing.Point(119, 0)
        Me.pbExceptions.Name = "pbExceptions"
        Me.pbExceptions.Size = New System.Drawing.Size(309, 13)
        Me.pbExceptions.TabIndex = 7
        Me.pbExceptions.Visible = False
        '
        'tvExceptions
        '
        Me.tvExceptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvExceptions.CheckBoxes = True
        Me.tvExceptions.ContextMenuStrip = Me.cmsExceptions
        Me.tvExceptions.HideSelection = False
        Me.tvExceptions.Location = New System.Drawing.Point(9, 38)
        Me.tvExceptions.Name = "tvExceptions"
        Me.tvExceptions.Size = New System.Drawing.Size(419, 190)
        Me.tvExceptions.TabIndex = 3
        '
        'cmsExceptions
        '
        Me.cmsExceptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsExceptionsToggleChildNodes, Me.ToolStripMenuItem1, Me.cmsExceptionsBrowse})
        Me.cmsExceptions.Name = "cmsExceptions"
        Me.cmsExceptions.Size = New System.Drawing.Size(180, 54)
        '
        'cmsExceptionsToggleChildNodes
        '
        Me.cmsExceptionsToggleChildNodes.Name = "cmsExceptionsToggleChildNodes"
        Me.cmsExceptionsToggleChildNodes.Size = New System.Drawing.Size(179, 22)
        Me.cmsExceptionsToggleChildNodes.Text = "Toggle Child Nodes"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(176, 6)
        '
        'cmsExceptionsBrowse
        '
        Me.cmsExceptionsBrowse.Name = "cmsExceptionsBrowse"
        Me.cmsExceptionsBrowse.Size = New System.Drawing.Size(179, 22)
        Me.cmsExceptionsBrowse.Text = "Browse..."
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
        'gbFolderInfo
        '
        Me.gbFolderInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbFolderInfo.Controls.Add(Me.btnOpen)
        Me.gbFolderInfo.Controls.Add(Me.txtLocation)
        Me.gbFolderInfo.Controls.Add(Me.Label3)
        Me.gbFolderInfo.Controls.Add(Me.txtName)
        Me.gbFolderInfo.Controls.Add(Me.Label2)
        Me.gbFolderInfo.Location = New System.Drawing.Point(3, 3)
        Me.gbFolderInfo.Name = "gbFolderInfo"
        Me.gbFolderInfo.Size = New System.Drawing.Size(435, 83)
        Me.gbFolderInfo.TabIndex = 6
        Me.gbFolderInfo.TabStop = False
        Me.gbFolderInfo.Text = "Folder Information"
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.FlatAppearance.BorderSize = 0
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.Location = New System.Drawing.Point(407, 45)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(21, 20)
        Me.btnOpen.TabIndex = 4
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.Location = New System.Drawing.Point(60, 45)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(341, 20)
        Me.txtLocation.TabIndex = 3
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
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(60, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(368, 20)
        Me.txtName.TabIndex = 1
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
        Me.Label1.Text = "The folders listed here are the folders that KeyLaunch will scan whenever you per" & _
    "form a search." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To add folders, use the Add button or simply drop them over the " & _
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
        Me.Label5.Text = "Each category groups a series of file types that KeyLaunch will search for." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Use " & _
    "the Add button to add new categories or simply drop files over one of the catego" & _
    "ries to add a new file type."
        '
        'ilExtIcons
        '
        Me.ilExtIcons.ImageStream = CType(resources.GetObject("ilExtIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilExtIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ilExtIcons.Images.SetKeyName(0, "")
        Me.ilExtIcons.Images.SetKeyName(1, "")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(731, 416)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(650, 416)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cmdDefaults
        '
        Me.cmdDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdDefaults.Location = New System.Drawing.Point(12, 416)
        Me.cmdDefaults.Name = "cmdDefaults"
        Me.cmdDefaults.Size = New System.Drawing.Size(75, 23)
        Me.cmdDefaults.TabIndex = 3
        Me.cmdDefaults.Text = "Defaults"
        Me.cmdDefaults.UseVisualStyleBackColor = True
        '
        'pExtEditor
        '
        Me.pExtEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pExtEditor.Controls.Add(Me.btnCloseExtEditor)
        Me.pExtEditor.Controls.Add(Me.btnDeleteExt)
        Me.pExtEditor.Controls.Add(Me.btnEditExt)
        Me.pExtEditor.Controls.Add(Me.btnAddExt)
        Me.pExtEditor.Controls.Add(Me.txtExtension)
        Me.pExtEditor.Controls.Add(Me.lbExtensions)
        Me.pExtEditor.Location = New System.Drawing.Point(106, 12)
        Me.pExtEditor.MinimumSize = New System.Drawing.Size(175, 153)
        Me.pExtEditor.Name = "pExtEditor"
        Me.pExtEditor.Size = New System.Drawing.Size(175, 153)
        Me.pExtEditor.TabIndex = 4
        Me.pExtEditor.Visible = False
        '
        'btnCloseExtEditor
        '
        Me.btnCloseExtEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCloseExtEditor.Location = New System.Drawing.Point(90, 64)
        Me.btnCloseExtEditor.Name = "btnCloseExtEditor"
        Me.btnCloseExtEditor.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseExtEditor.TabIndex = 5
        Me.btnCloseExtEditor.Text = "Close"
        Me.btnCloseExtEditor.UseVisualStyleBackColor = True
        '
        'btnDeleteExt
        '
        Me.btnDeleteExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteExt.Location = New System.Drawing.Point(90, 34)
        Me.btnDeleteExt.Name = "btnDeleteExt"
        Me.btnDeleteExt.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteExt.TabIndex = 4
        Me.btnDeleteExt.Text = "Delete"
        Me.btnDeleteExt.UseVisualStyleBackColor = True
        '
        'btnEditExt
        '
        Me.btnEditExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditExt.Location = New System.Drawing.Point(90, 5)
        Me.btnEditExt.Name = "btnEditExt"
        Me.btnEditExt.Size = New System.Drawing.Size(75, 23)
        Me.btnEditExt.TabIndex = 3
        Me.btnEditExt.Text = "Edit"
        Me.btnEditExt.UseVisualStyleBackColor = True
        '
        'btnAddExt
        '
        Me.btnAddExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddExt.Location = New System.Drawing.Point(90, 121)
        Me.btnAddExt.Name = "btnAddExt"
        Me.btnAddExt.Size = New System.Drawing.Size(75, 23)
        Me.btnAddExt.TabIndex = 2
        Me.btnAddExt.Text = "Add"
        Me.btnAddExt.UseVisualStyleBackColor = True
        '
        'txtExtension
        '
        Me.txtExtension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExtension.Location = New System.Drawing.Point(7, 122)
        Me.txtExtension.Name = "txtExtension"
        Me.txtExtension.Size = New System.Drawing.Size(77, 20)
        Me.txtExtension.TabIndex = 1
        '
        'lbExtensions
        '
        Me.lbExtensions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbExtensions.FormattingEnabled = True
        Me.lbExtensions.IntegralHeight = False
        Me.lbExtensions.Location = New System.Drawing.Point(7, 5)
        Me.lbExtensions.Name = "lbExtensions"
        Me.lbExtensions.Size = New System.Drawing.Size(77, 111)
        Me.lbExtensions.TabIndex = 0
        '
        'lvFolders
        '
        Me.lvFolders.AllowColumnReorder = True
        Me.lvFolders.AllowDrop = True
        Me.lvFolders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFolders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chPathsFolderName, Me.chPathsRecurse, Me.chPathsExceptions, Me.chPathsFullPath})
        Me.lvFolders.FullRowSelect = True
        Me.lvFolders.GridLines = True
        Me.lvFolders.HideSelection = False
        Me.lvFolders.Location = New System.Drawing.Point(3, 3)
        Me.lvFolders.MultiSelect = False
        Me.lvFolders.Name = "lvFolders"
        Me.lvFolders.Size = New System.Drawing.Size(323, 294)
        Me.lvFolders.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvFolders.TabIndex = 4
        Me.lvFolders.UseCompatibleStateImageBehavior = False
        Me.lvFolders.View = System.Windows.Forms.View.Details
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
        Me.spCategories.Panel1.Controls.Add(Me.btnCatRem)
        Me.spCategories.Panel1.Controls.Add(Me.btnCatAdd)
        Me.spCategories.Panel1.Controls.Add(Me.lvCats)
        '
        'spCategories.Panel2
        '
        Me.spCategories.Panel2.Controls.Add(Me.gbExtensions)
        Me.spCategories.Panel2.Controls.Add(Me.gbCatInfo)
        Me.spCategories.Size = New System.Drawing.Size(774, 329)
        Me.spCategories.SplitterDistance = 305
        Me.spCategories.TabIndex = 3
        '
        'btnCatRem
        '
        Me.btnCatRem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCatRem.Location = New System.Drawing.Point(84, 303)
        Me.btnCatRem.Name = "btnCatRem"
        Me.btnCatRem.Size = New System.Drawing.Size(75, 23)
        Me.btnCatRem.TabIndex = 8
        Me.btnCatRem.Text = "Remove"
        Me.btnCatRem.UseVisualStyleBackColor = True
        '
        'btnCatAdd
        '
        Me.btnCatAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCatAdd.Image = Global.KeyLaunch.My.Resources.Resources.newreportHS
        Me.btnCatAdd.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnCatAdd.Location = New System.Drawing.Point(3, 303)
        Me.btnCatAdd.Name = "btnCatAdd"
        Me.btnCatAdd.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnCatAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnCatAdd.TabIndex = 7
        Me.btnCatAdd.Text = "Add"
        Me.btnCatAdd.UseVisualStyleBackColor = True
        '
        'lvCats
        '
        Me.lvCats.AllowColumnReorder = True
        Me.lvCats.AllowDrop = True
        Me.lvCats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCatName, Me.chCatColor, Me.chCatShortcut, Me.chCatExtensions})
        Me.lvCats.FullRowSelect = True
        Me.lvCats.GridLines = True
        Me.lvCats.HideSelection = False
        Me.lvCats.Location = New System.Drawing.Point(3, 3)
        Me.lvCats.MultiSelect = False
        Me.lvCats.Name = "lvCats"
        Me.lvCats.OwnerDraw = True
        Me.lvCats.Size = New System.Drawing.Size(299, 294)
        Me.lvCats.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvCats.TabIndex = 4
        Me.lvCats.UseCompatibleStateImageBehavior = False
        Me.lvCats.View = System.Windows.Forms.View.Details
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
        Me.gbExtensions.Controls.Add(Me.pbExtensions)
        Me.gbExtensions.Controls.Add(Me.lvExt)
        Me.gbExtensions.Location = New System.Drawing.Point(3, 109)
        Me.gbExtensions.Name = "gbExtensions"
        Me.gbExtensions.Size = New System.Drawing.Size(459, 217)
        Me.gbExtensions.TabIndex = 8
        Me.gbExtensions.TabStop = False
        Me.gbExtensions.Text = "Extensions"
        '
        'pbExtensions
        '
        Me.pbExtensions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbExtensions.Location = New System.Drawing.Point(70, 0)
        Me.pbExtensions.Name = "pbExtensions"
        Me.pbExtensions.Size = New System.Drawing.Size(383, 13)
        Me.pbExtensions.TabIndex = 6
        '
        'lvExt
        '
        Me.lvExt.AllowColumnReorder = True
        Me.lvExt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvExt.CheckBoxes = True
        Me.lvExt.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chExtDescription, Me.chExtExtensions, Me.chExtOpensWith})
        Me.lvExt.FullRowSelect = True
        Me.lvExt.GridLines = True
        Me.lvExt.Location = New System.Drawing.Point(6, 19)
        Me.lvExt.Name = "lvExt"
        Me.lvExt.Size = New System.Drawing.Size(447, 192)
        Me.lvExt.SmallImageList = Me.ilExtIcons
        Me.lvExt.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvExt.TabIndex = 5
        Me.lvExt.UseCompatibleStateImageBehavior = False
        Me.lvExt.View = System.Windows.Forms.View.Details
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
        'gbCatInfo
        '
        Me.gbCatInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCatInfo.Controls.Add(Me.btnEditExtensions)
        Me.gbCatInfo.Controls.Add(Me.txtShortcut)
        Me.gbCatInfo.Controls.Add(Me.Label9)
        Me.gbCatInfo.Controls.Add(Me.txtExtensions)
        Me.gbCatInfo.Controls.Add(Me.Label7)
        Me.gbCatInfo.Controls.Add(Me.btnCatColor)
        Me.gbCatInfo.Controls.Add(Me.Label8)
        Me.gbCatInfo.Controls.Add(Me.txtCatName)
        Me.gbCatInfo.Controls.Add(Me.Label6)
        Me.gbCatInfo.Location = New System.Drawing.Point(3, 3)
        Me.gbCatInfo.Name = "gbCatInfo"
        Me.gbCatInfo.Size = New System.Drawing.Size(459, 100)
        Me.gbCatInfo.TabIndex = 7
        Me.gbCatInfo.TabStop = False
        Me.gbCatInfo.Text = "Category Information"
        '
        'btnEditExtensions
        '
        Me.btnEditExtensions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditExtensions.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditExtensions.Location = New System.Drawing.Point(392, 45)
        Me.btnEditExtensions.Name = "btnEditExtensions"
        Me.btnEditExtensions.Size = New System.Drawing.Size(61, 20)
        Me.btnEditExtensions.TabIndex = 14
        Me.btnEditExtensions.Text = "Edit"
        Me.btnEditExtensions.UseVisualStyleBackColor = True
        '
        'txtShortcut
        '
        Me.txtShortcut.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtShortcut.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtShortcut.Location = New System.Drawing.Point(70, 71)
        Me.txtShortcut.Name = "txtShortcut"
        Me.txtShortcut.ReadOnly = True
        Me.txtShortcut.Size = New System.Drawing.Size(203, 20)
        Me.txtShortcut.TabIndex = 13
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
        'txtExtensions
        '
        Me.txtExtensions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExtensions.Location = New System.Drawing.Point(70, 45)
        Me.txtExtensions.Name = "txtExtensions"
        Me.txtExtensions.ReadOnly = True
        Me.txtExtensions.Size = New System.Drawing.Size(316, 20)
        Me.txtExtensions.TabIndex = 11
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
        'btnCatColor
        '
        Me.btnCatColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCatColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatColor.Location = New System.Drawing.Point(432, 71)
        Me.btnCatColor.Name = "btnCatColor"
        Me.btnCatColor.Size = New System.Drawing.Size(21, 20)
        Me.btnCatColor.TabIndex = 9
        Me.btnCatColor.UseVisualStyleBackColor = True
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
        'txtCatName
        '
        Me.txtCatName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCatName.Location = New System.Drawing.Point(70, 19)
        Me.txtCatName.Name = "txtCatName"
        Me.txtCatName.Size = New System.Drawing.Size(383, 20)
        Me.txtCatName.TabIndex = 6
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
        'frmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 451)
        Me.Controls.Add(Me.cmdDefaults)
        Me.Controls.Add(Me.pExtEditor)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.tabCtrlSections)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "frmSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Configuration"
        Me.tabCtrlSections.ResumeLayout(False)
        Me.tpPaths.ResumeLayout(False)
        Me.spPaths.Panel1.ResumeLayout(False)
        Me.spPaths.Panel2.ResumeLayout(False)
        Me.spPaths.Panel2.PerformLayout()
        CType(Me.spPaths, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spPaths.ResumeLayout(False)
        Me.gbRecurse.ResumeLayout(False)
        Me.gbRecurse.PerformLayout()
        Me.cmsExceptions.ResumeLayout(False)
        Me.gbFolderInfo.ResumeLayout(False)
        Me.gbFolderInfo.PerformLayout()
        Me.tpCategories.ResumeLayout(False)
        Me.pExtEditor.ResumeLayout(False)
        Me.pExtEditor.PerformLayout()
        Me.spCategories.Panel1.ResumeLayout(False)
        Me.spCategories.Panel2.ResumeLayout(False)
        CType(Me.spCategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spCategories.ResumeLayout(False)
        Me.gbExtensions.ResumeLayout(False)
        Me.gbCatInfo.ResumeLayout(False)
        Me.gbCatInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabCtrlSections As System.Windows.Forms.TabControl
    Friend WithEvents tpPaths As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fbDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents tpCategories As System.Windows.Forms.TabPage
    Friend WithEvents ilExtIcons As System.Windows.Forms.ImageList
    Friend WithEvents spCategories As System.Windows.Forms.SplitContainer
    Friend WithEvents lvCats As KeyLaunch.FFListView
    Friend WithEvents chCatName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCatColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCatExtensions As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbExtensions As System.Windows.Forms.GroupBox
    Friend WithEvents chExtDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents chExtExtensions As System.Windows.Forms.ColumnHeader
    Friend WithEvents chExtOpensWith As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbCatInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btnCatColor As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCatName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents spPaths As System.Windows.Forms.SplitContainer
    Friend WithEvents btnPathRemove As System.Windows.Forms.Button
    Friend WithEvents btnPathAdd As System.Windows.Forms.Button
    Friend WithEvents lvFolders As KeyLaunch.FFListView
    Friend WithEvents chPathsFolderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPathsRecurse As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPathsExceptions As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPathsFullPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkRecurse As System.Windows.Forms.CheckBox
    Friend WithEvents gbRecurse As System.Windows.Forms.GroupBox
    Friend WithEvents tvExceptions As System.Windows.Forms.TreeView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbFolderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCatRem As System.Windows.Forms.Button
    Friend WithEvents btnCatAdd As System.Windows.Forms.Button
    Friend WithEvents cDlg As System.Windows.Forms.ColorDialog
    Friend WithEvents pbExtensions As System.Windows.Forms.ProgressBar
    Friend WithEvents lvExt As KeyLaunch.FFListView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtShortcut As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chCatShortcut As System.Windows.Forms.ColumnHeader
    Friend WithEvents pbExceptions As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdDefaults As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmsExceptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsExceptionsToggleChildNodes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsExceptionsBrowse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtExtensions As System.Windows.Forms.TextBox
    Friend WithEvents pExtEditor As System.Windows.Forms.Panel
    Friend WithEvents btnDeleteExt As System.Windows.Forms.Button
    Friend WithEvents btnEditExt As System.Windows.Forms.Button
    Friend WithEvents txtExtension As System.Windows.Forms.TextBox
    Friend WithEvents lbExtensions As System.Windows.Forms.ListBox
    Friend WithEvents btnEditExtensions As System.Windows.Forms.Button
    Friend WithEvents btnCloseExtEditor As System.Windows.Forms.Button
    Friend WithEvents btnAddExt As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.chFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuMainOpenKeyLaunch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuMainSep01 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuMainSearchPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuMainOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuMainSep02 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuMainHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuMainAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuMainSep03 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuMainExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlCats = New System.Windows.Forms.Panel()
        Me.ListViewCats = New KeyLaunch.FFListView()
        Me.chCatName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NotifyIconIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ListViewFiles = New KeyLaunch.KLListView()
        Me.ContextMenuMain.SuspendLayout()
        Me.pnlCats.SuspendLayout()
        Me.SuspendLayout()
        '
        'chFile
        '
        Me.chFile.Width = 452
        '
        'ContextMenuMain
        '
        Me.ContextMenuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuMainOpenKeyLaunch, Me.ContextMenuMainSep01, Me.ContextMenuMainSearchPreferences, Me.ContextMenuMainOptions, Me.ContextMenuMainSep02, Me.ContextMenuMainHelp, Me.ContextMenuMainAbout, Me.ContextMenuMainSep03, Me.ContextMenuMainExit})
        Me.ContextMenuMain.Name = "mMain"
        Me.ContextMenuMain.ShowItemToolTips = False
        Me.ContextMenuMain.Size = New System.Drawing.Size(183, 154)
        '
        'ContextMenuMainOpenKeyLaunch
        '
        Me.ContextMenuMainOpenKeyLaunch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ContextMenuMainOpenKeyLaunch.Image = CType(resources.GetObject("ContextMenuMainOpenKeyLaunch.Image"), System.Drawing.Image)
        Me.ContextMenuMainOpenKeyLaunch.Name = "ContextMenuMainOpenKeyLaunch"
        Me.ContextMenuMainOpenKeyLaunch.Size = New System.Drawing.Size(182, 22)
        Me.ContextMenuMainOpenKeyLaunch.Text = "Open KeyLaunch"
        '
        'ContextMenuMainSep01
        '
        Me.ContextMenuMainSep01.Name = "ContextMenuMainSep01"
        Me.ContextMenuMainSep01.Size = New System.Drawing.Size(179, 6)
        '
        'ContextMenuMainSearchPreferences
        '
        Me.ContextMenuMainSearchPreferences.Image = CType(resources.GetObject("ContextMenuMainSearchPreferences.Image"), System.Drawing.Image)
        Me.ContextMenuMainSearchPreferences.Name = "ContextMenuMainSearchPreferences"
        Me.ContextMenuMainSearchPreferences.Size = New System.Drawing.Size(182, 22)
        Me.ContextMenuMainSearchPreferences.Text = "Search Preferences..."
        '
        'ContextMenuMainOptions
        '
        Me.ContextMenuMainOptions.Image = CType(resources.GetObject("ContextMenuMainOptions.Image"), System.Drawing.Image)
        Me.ContextMenuMainOptions.Name = "ContextMenuMainOptions"
        Me.ContextMenuMainOptions.Size = New System.Drawing.Size(182, 22)
        Me.ContextMenuMainOptions.Text = "Options..."
        '
        'ContextMenuMainSep02
        '
        Me.ContextMenuMainSep02.Name = "ContextMenuMainSep02"
        Me.ContextMenuMainSep02.Size = New System.Drawing.Size(179, 6)
        '
        'ContextMenuMainHelp
        '
        Me.ContextMenuMainHelp.Image = Global.KeyLaunch.My.Resources.Resources.Help
        Me.ContextMenuMainHelp.Name = "ContextMenuMainHelp"
        Me.ContextMenuMainHelp.Size = New System.Drawing.Size(182, 22)
        Me.ContextMenuMainHelp.Text = "Help..."
        '
        'ContextMenuMainAbout
        '
        Me.ContextMenuMainAbout.Name = "ContextMenuMainAbout"
        Me.ContextMenuMainAbout.Size = New System.Drawing.Size(182, 22)
        Me.ContextMenuMainAbout.Text = "About..."
        '
        'ContextMenuMainSep03
        '
        Me.ContextMenuMainSep03.Name = "ContextMenuMainSep03"
        Me.ContextMenuMainSep03.Size = New System.Drawing.Size(179, 6)
        '
        'ContextMenuMainExit
        '
        Me.ContextMenuMainExit.Name = "ContextMenuMainExit"
        Me.ContextMenuMainExit.Size = New System.Drawing.Size(182, 22)
        Me.ContextMenuMainExit.Text = "Exit"
        '
        'pnlCats
        '
        Me.pnlCats.Controls.Add(Me.ListViewCats)
        Me.pnlCats.Location = New System.Drawing.Point(12, 19)
        Me.pnlCats.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlCats.Name = "pnlCats"
        Me.pnlCats.Size = New System.Drawing.Size(118, 83)
        Me.pnlCats.TabIndex = 4
        '
        'ListViewCats
        '
        Me.ListViewCats.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewCats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCatName})
        Me.ListViewCats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewCats.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewCats.FullRowSelect = True
        Me.ListViewCats.GridLines = True
        Me.ListViewCats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewCats.Location = New System.Drawing.Point(0, 0)
        Me.ListViewCats.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListViewCats.MultiSelect = False
        Me.ListViewCats.Name = "ListViewCats"
        Me.ListViewCats.OwnerDraw = True
        Me.ListViewCats.Scrollable = False
        Me.ListViewCats.Size = New System.Drawing.Size(118, 83)
        Me.ListViewCats.TabIndex = 0
        Me.ListViewCats.UseCompatibleStateImageBehavior = False
        Me.ListViewCats.View = System.Windows.Forms.View.Details
        Me.ListViewCats.VirtualMode = True
        '
        'chCatName
        '
        Me.chCatName.Text = "Name"
        '
        'NotifyIconIcon
        '
        Me.NotifyIconIcon.ContextMenuStrip = Me.ContextMenuMain
        Me.NotifyIconIcon.Icon = CType(resources.GetObject("NotifyIconIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIconIcon.Text = "KeyLaunch"
        Me.NotifyIconIcon.Visible = True
        '
        'ListViewFiles
        '
        Me.ListViewFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewFiles.BackColor = System.Drawing.Color.White
        Me.ListViewFiles.DirAreaWidthPercentage = 20
        Me.ListViewFiles.GridColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewFiles.Location = New System.Drawing.Point(133, 19)
        Me.ListViewFiles.Margin = New System.Windows.Forms.Padding(5)
        Me.ListViewFiles.Name = "ListViewFiles"
        Me.ListViewFiles.ScrollPosition = 0
        Me.ListViewFiles.SelectedItem = Nothing
        Me.ListViewFiles.SelectionColumnMode = KeyLaunch.KLListView.SelectColConstants.Item
        Me.ListViewFiles.Size = New System.Drawing.Size(362, 317)
        Me.ListViewFiles.TabIndex = 3
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(506, 348)
        Me.Controls.Add(Me.pnlCats)
        Me.Controls.Add(Me.ListViewFiles)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "KeyLaunch"
        Me.TopMost = True
        Me.ContextMenuMain.ResumeLayout(False)
        Me.pnlCats.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListViewFiles As KeyLaunch.KLListView
    Friend WithEvents ContextMenuMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuMainOpenKeyLaunch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuMainSep01 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuMainSearchPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuMainOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuMainSep02 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuMainHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuMainAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuMainSep03 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuMainExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlCats As System.Windows.Forms.Panel
    Friend WithEvents ListViewCats As KeyLaunch.FFListView
    Friend WithEvents chCatName As System.Windows.Forms.ColumnHeader
    Friend WithEvents NotifyIconIcon As System.Windows.Forms.NotifyIcon
End Class

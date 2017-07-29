<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.chFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mMainOpenKeyLaunch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMainSep01 = New System.Windows.Forms.ToolStripSeparator()
        Me.mMainSearchPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMainOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMainSep02 = New System.Windows.Forms.ToolStripSeparator()
        Me.mMainHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMainAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMainSep03 = New System.Windows.Forms.ToolStripSeparator()
        Me.mMainExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlCats = New System.Windows.Forms.Panel()
        Me.lvCats = New KeyLaunch.FFListView()
        Me.chCatName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.niIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lvFiles = New KeyLaunch.KLListView()
        Me.mMain.SuspendLayout()
        Me.pnlCats.SuspendLayout()
        Me.SuspendLayout()
        '
        'chFile
        '
        Me.chFile.Width = 452
        '
        'mMain
        '
        Me.mMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMainOpenKeyLaunch, Me.mMainSep01, Me.mMainSearchPreferences, Me.mMainOptions, Me.mMainSep02, Me.mMainHelp, Me.mMainAbout, Me.mMainSep03, Me.mMainExit})
        Me.mMain.Name = "mMain"
        Me.mMain.ShowItemToolTips = False
        Me.mMain.Size = New System.Drawing.Size(192, 154)
        '
        'mMainOpenKeyLaunch
        '
        Me.mMainOpenKeyLaunch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.mMainOpenKeyLaunch.Image = CType(resources.GetObject("mMainOpenKeyLaunch.Image"), System.Drawing.Image)
        Me.mMainOpenKeyLaunch.Name = "mMainOpenKeyLaunch"
        Me.mMainOpenKeyLaunch.Size = New System.Drawing.Size(191, 22)
        Me.mMainOpenKeyLaunch.Text = "Open KeyLaunch"
        '
        'mMainSep01
        '
        Me.mMainSep01.Name = "mMainSep01"
        Me.mMainSep01.Size = New System.Drawing.Size(188, 6)
        '
        'mMainSearchPreferences
        '
        Me.mMainSearchPreferences.Image = CType(resources.GetObject("mMainSearchPreferences.Image"), System.Drawing.Image)
        Me.mMainSearchPreferences.Name = "mMainSearchPreferences"
        Me.mMainSearchPreferences.Size = New System.Drawing.Size(191, 22)
        Me.mMainSearchPreferences.Text = "Search Preferences..."
        '
        'mMainOptions
        '
        Me.mMainOptions.Image = CType(resources.GetObject("mMainOptions.Image"), System.Drawing.Image)
        Me.mMainOptions.Name = "mMainOptions"
        Me.mMainOptions.Size = New System.Drawing.Size(191, 22)
        Me.mMainOptions.Text = "Options..."
        '
        'mMainSep02
        '
        Me.mMainSep02.Name = "mMainSep02"
        Me.mMainSep02.Size = New System.Drawing.Size(188, 6)
        '
        'mMainHelp
        '
        Me.mMainHelp.Image = Global.KeyLaunch.My.Resources.Resources.Help
        Me.mMainHelp.Name = "mMainHelp"
        Me.mMainHelp.Size = New System.Drawing.Size(191, 22)
        Me.mMainHelp.Text = "Help..."
        '
        'mMainAbout
        '
        Me.mMainAbout.Name = "mMainAbout"
        Me.mMainAbout.Size = New System.Drawing.Size(191, 22)
        Me.mMainAbout.Text = "About..."
        '
        'mMainSep03
        '
        Me.mMainSep03.Name = "mMainSep03"
        Me.mMainSep03.Size = New System.Drawing.Size(188, 6)
        '
        'mMainExit
        '
        Me.mMainExit.Name = "mMainExit"
        Me.mMainExit.Size = New System.Drawing.Size(191, 22)
        Me.mMainExit.Text = "Exit"
        '
        'pnlCats
        '
        Me.pnlCats.Controls.Add(Me.lvCats)
        Me.pnlCats.Location = New System.Drawing.Point(12, 19)
        Me.pnlCats.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlCats.Name = "pnlCats"
        Me.pnlCats.Size = New System.Drawing.Size(118, 83)
        Me.pnlCats.TabIndex = 4
        '
        'lvCats
        '
        Me.lvCats.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lvCats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCatName})
        Me.lvCats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCats.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCats.FullRowSelect = True
        Me.lvCats.GridLines = True
        Me.lvCats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvCats.Location = New System.Drawing.Point(0, 0)
        Me.lvCats.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvCats.MultiSelect = False
        Me.lvCats.Name = "lvCats"
        Me.lvCats.OwnerDraw = True
        Me.lvCats.Scrollable = False
        Me.lvCats.Size = New System.Drawing.Size(118, 83)
        Me.lvCats.TabIndex = 0
        Me.lvCats.UseCompatibleStateImageBehavior = False
        Me.lvCats.View = System.Windows.Forms.View.Details
        Me.lvCats.VirtualMode = True
        '
        'chCatName
        '
        Me.chCatName.Text = "Name"
        '
        'niIcon
        '
        Me.niIcon.ContextMenuStrip = Me.mMain
        Me.niIcon.Icon = CType(resources.GetObject("niIcon.Icon"), System.Drawing.Icon)
        Me.niIcon.Text = "KeyLaunch"
        Me.niIcon.Visible = True
        '
        'lvFiles
        '
        Me.lvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFiles.BackColor = System.Drawing.Color.White
        Me.lvFiles.DirAreaWidthPercentage = 20
        Me.lvFiles.GridColor = System.Drawing.Color.WhiteSmoke
        Me.lvFiles.Location = New System.Drawing.Point(133, 19)
        Me.lvFiles.Margin = New System.Windows.Forms.Padding(5)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.ScrollPosition = 0
        Me.lvFiles.SelectedItem = Nothing
        Me.lvFiles.SelectionColumnMode = KeyLaunch.KLListView.SelectColConstants.Item
        Me.lvFiles.Size = New System.Drawing.Size(362, 317)
        Me.lvFiles.TabIndex = 3
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(506, 348)
        Me.Controls.Add(Me.pnlCats)
        Me.Controls.Add(Me.lvFiles)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "KeyLaunch"
        Me.TopMost = True
        Me.mMain.ResumeLayout(False)
        Me.pnlCats.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFiles As KeyLaunch.KLListView
    Friend WithEvents mMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mMainOpenKeyLaunch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mMainSep01 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mMainSearchPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mMainOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mMainSep02 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mMainHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mMainAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mMainSep03 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mMainExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlCats As System.Windows.Forms.Panel
    Friend WithEvents lvCats As KeyLaunch.FFListView
    Friend WithEvents chCatName As System.Windows.Forms.ColumnHeader
    Friend WithEvents niIcon As System.Windows.Forms.NotifyIcon
End Class

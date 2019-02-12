<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddFromDropExtension
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
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.ListBoxCats = New System.Windows.Forms.ListBox()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.PictureBoxIcon = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBoxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelInfo
        '
        Me.LabelInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelInfo.Location = New System.Drawing.Point(59, 9)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(416, 56)
        Me.LabelInfo.TabIndex = 0
        Me.LabelInfo.Text = "KeyLaunch has determined that in order to be able to search for '{2}' files such " &
    "as '{0}' it needs to add the '{1}' extension." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select the category where you w" &
    "ould like to add the new extension:"
        Me.LabelInfo.UseMnemonic = False
        '
        'ListBoxCats
        '
        Me.ListBoxCats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxCats.FormattingEnabled = True
        Me.ListBoxCats.IntegralHeight = False
        Me.ListBoxCats.Location = New System.Drawing.Point(59, 68)
        Me.ListBoxCats.Name = "ListBoxCats"
        Me.ListBoxCats.Size = New System.Drawing.Size(416, 135)
        Me.ListBoxCats.TabIndex = 1
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(319, 209)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(400, 209)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 3
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'PictureBoxIcon
        '
        Me.PictureBoxIcon.Location = New System.Drawing.Point(12, 12)
        Me.PictureBoxIcon.Name = "PictureBoxIcon"
        Me.PictureBoxIcon.Size = New System.Drawing.Size(32, 32)
        Me.PictureBoxIcon.TabIndex = 4
        Me.PictureBoxIcon.TabStop = False
        '
        'FormAddFromDropExtension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 244)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBoxIcon)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ListBoxCats)
        Me.Controls.Add(Me.LabelInfo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddFromDropExtension"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Add File Type"
        CType(Me.PictureBoxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents ListBoxCats As System.Windows.Forms.ListBox
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents PictureBoxIcon As System.Windows.Forms.PictureBox
End Class

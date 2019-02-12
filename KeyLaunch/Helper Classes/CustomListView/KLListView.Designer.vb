<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KLListView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.VScrollBarItem = New System.Windows.Forms.VScrollBar()
        Me.SuspendLayout()
        '
        'VScrollBarItem
        '
        Me.VScrollBarItem.Dock = System.Windows.Forms.DockStyle.Right
        Me.VScrollBarItem.Location = New System.Drawing.Point(133, 0)
        Me.VScrollBarItem.Name = "VScrollBarItem"
        Me.VScrollBarItem.Size = New System.Drawing.Size(17, 150)
        Me.VScrollBarItem.TabIndex = 0
        '
        'KLListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.VScrollBarItem)
        Me.Name = "KLListView"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VScrollBarItem As System.Windows.Forms.VScrollBar

End Class

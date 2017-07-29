<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.pbKLLogo = New System.Windows.Forms.PictureBox
        CType(Me.pbKLLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbKLLogo
        '
        Me.pbKLLogo.BackColor = System.Drawing.Color.White
        Me.pbKLLogo.Image = CType(resources.GetObject("pbKLLogo.Image"), System.Drawing.Image)
        Me.pbKLLogo.Location = New System.Drawing.Point(12, 12)
        Me.pbKLLogo.Name = "pbKLLogo"
        Me.pbKLLogo.Size = New System.Drawing.Size(60, 60)
        Me.pbKLLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbKLLogo.TabIndex = 0
        Me.pbKLLogo.TabStop = False
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(556, 325)
        Me.Controls.Add(Me.pbKLLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbKLLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbKLLogo As System.Windows.Forms.PictureBox
End Class

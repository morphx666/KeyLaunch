<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAbout))
        Me.PictureBoxKLLogo = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBoxKLLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxKLLogo
        '
        Me.PictureBoxKLLogo.BackColor = System.Drawing.Color.White
        Me.PictureBoxKLLogo.Image = CType(resources.GetObject("PictureBoxKLLogo.Image"), System.Drawing.Image)
        Me.PictureBoxKLLogo.Location = New System.Drawing.Point(12, 12)
        Me.PictureBoxKLLogo.Name = "PictureBoxKLLogo"
        Me.PictureBoxKLLogo.Size = New System.Drawing.Size(60, 60)
        Me.PictureBoxKLLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxKLLogo.TabIndex = 0
        Me.PictureBoxKLLogo.TabStop = False
        '
        'FormAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(556, 325)
        Me.Controls.Add(Me.PictureBoxKLLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBoxKLLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBoxKLLogo As System.Windows.Forms.PictureBox
End Class

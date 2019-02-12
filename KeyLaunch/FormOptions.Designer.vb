<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOptions))
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.CheckBoxStartWithWindows = New System.Windows.Forms.CheckBox()
        Me.GroupBoxColors = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrackBarLum = New System.Windows.Forms.TrackBar()
        Me.TrackBarSat = New System.Windows.Forms.TrackBar()
        Me.TrackBarHue = New System.Windows.Forms.TrackBar()
        Me.CheckBoxShowTrayIcon = New System.Windows.Forms.CheckBox()
        Me.GroupBoxOptions = New System.Windows.Forms.GroupBox()
        Me.CheckBoxkHideOnFocusLost = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TrackBarRetypeDelay = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxHotkey = New System.Windows.Forms.GroupBox()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.TextBoxHotKey = New System.Windows.Forms.TextBox()
        Me.ButtonDefaults = New System.Windows.Forms.Button()
        Me.GroupBoxColors.SuspendLayout()
        CType(Me.TrackBarLum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarSat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarHue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxOptions.SuspendLayout()
        CType(Me.TrackBarRetypeDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxHotkey.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(157, 362)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.Location = New System.Drawing.Point(238, 362)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'CheckBoxStartWithWindows
        '
        Me.CheckBoxStartWithWindows.AutoSize = True
        Me.CheckBoxStartWithWindows.Location = New System.Drawing.Point(6, 19)
        Me.CheckBoxStartWithWindows.Name = "CheckBoxStartWithWindows"
        Me.CheckBoxStartWithWindows.Size = New System.Drawing.Size(117, 17)
        Me.CheckBoxStartWithWindows.TabIndex = 0
        Me.CheckBoxStartWithWindows.Text = "Start with Windows"
        Me.CheckBoxStartWithWindows.UseVisualStyleBackColor = True
        '
        'GroupBoxColors
        '
        Me.GroupBoxColors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxColors.Controls.Add(Me.Label4)
        Me.GroupBoxColors.Controls.Add(Me.Label3)
        Me.GroupBoxColors.Controls.Add(Me.Label2)
        Me.GroupBoxColors.Controls.Add(Me.TrackBarLum)
        Me.GroupBoxColors.Controls.Add(Me.TrackBarSat)
        Me.GroupBoxColors.Controls.Add(Me.TrackBarHue)
        Me.GroupBoxColors.Location = New System.Drawing.Point(12, 249)
        Me.GroupBoxColors.Name = "GroupBoxColors"
        Me.GroupBoxColors.Size = New System.Drawing.Size(301, 107)
        Me.GroupBoxColors.TabIndex = 1
        Me.GroupBoxColors.TabStop = False
        Me.GroupBoxColors.Text = "Interface Colors"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Luminosity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Saturation"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Color"
        '
        'TrackBarLum
        '
        Me.TrackBarLum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBarLum.AutoSize = False
        Me.TrackBarLum.BackColor = System.Drawing.SystemColors.Control
        Me.TrackBarLum.LargeChange = 1
        Me.TrackBarLum.Location = New System.Drawing.Point(75, 71)
        Me.TrackBarLum.Maximum = 100
        Me.TrackBarLum.Name = "TrackBarLum"
        Me.TrackBarLum.Size = New System.Drawing.Size(220, 20)
        Me.TrackBarLum.TabIndex = 3
        Me.TrackBarLum.TickFrequency = 10
        '
        'TrackBarSat
        '
        Me.TrackBarSat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBarSat.AutoSize = False
        Me.TrackBarSat.LargeChange = 1
        Me.TrackBarSat.Location = New System.Drawing.Point(75, 45)
        Me.TrackBarSat.Maximum = 100
        Me.TrackBarSat.Name = "TrackBarSat"
        Me.TrackBarSat.Size = New System.Drawing.Size(220, 20)
        Me.TrackBarSat.TabIndex = 2
        Me.TrackBarSat.TickFrequency = 10
        '
        'TrackBarHue
        '
        Me.TrackBarHue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBarHue.AutoSize = False
        Me.TrackBarHue.LargeChange = 15
        Me.TrackBarHue.Location = New System.Drawing.Point(75, 19)
        Me.TrackBarHue.Maximum = 360
        Me.TrackBarHue.Name = "TrackBarHue"
        Me.TrackBarHue.Size = New System.Drawing.Size(220, 20)
        Me.TrackBarHue.TabIndex = 1
        Me.TrackBarHue.TickFrequency = 15
        '
        'CheckBoxShowTrayIcon
        '
        Me.CheckBoxShowTrayIcon.AutoSize = True
        Me.CheckBoxShowTrayIcon.Location = New System.Drawing.Point(6, 38)
        Me.CheckBoxShowTrayIcon.Name = "CheckBoxShowTrayIcon"
        Me.CheckBoxShowTrayIcon.Size = New System.Drawing.Size(101, 17)
        Me.CheckBoxShowTrayIcon.TabIndex = 1
        Me.CheckBoxShowTrayIcon.Text = "Show Tray Icon"
        Me.CheckBoxShowTrayIcon.UseVisualStyleBackColor = True
        '
        'GroupBoxOptions
        '
        Me.GroupBoxOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxOptions.Controls.Add(Me.CheckBoxkHideOnFocusLost)
        Me.GroupBoxOptions.Controls.Add(Me.Label7)
        Me.GroupBoxOptions.Controls.Add(Me.Label6)
        Me.GroupBoxOptions.Controls.Add(Me.Label5)
        Me.GroupBoxOptions.Controls.Add(Me.TrackBarRetypeDelay)
        Me.GroupBoxOptions.Controls.Add(Me.Label1)
        Me.GroupBoxOptions.Controls.Add(Me.CheckBoxStartWithWindows)
        Me.GroupBoxOptions.Controls.Add(Me.CheckBoxShowTrayIcon)
        Me.GroupBoxOptions.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxOptions.Name = "GroupBoxOptions"
        Me.GroupBoxOptions.Size = New System.Drawing.Size(301, 125)
        Me.GroupBoxOptions.TabIndex = 3
        Me.GroupBoxOptions.TabStop = False
        Me.GroupBoxOptions.Text = "Options"
        '
        'CheckBoxkHideOnFocusLost
        '
        Me.CheckBoxkHideOnFocusLost.AutoSize = True
        Me.CheckBoxkHideOnFocusLost.Location = New System.Drawing.Point(139, 19)
        Me.CheckBoxkHideOnFocusLost.Name = "CheckBoxkHideOnFocusLost"
        Me.CheckBoxkHideOnFocusLost.Size = New System.Drawing.Size(142, 17)
        Me.CheckBoxkHideOnFocusLost.TabIndex = 7
        Me.CheckBoxkHideOnFocusLost.Text = "Hide when loosing focus"
        Me.CheckBoxkHideOnFocusLost.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(277, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "5.0"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(141, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "1.0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "0.5"
        '
        'TrackBarRetypeDelay
        '
        Me.TrackBarRetypeDelay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBarRetypeDelay.AutoSize = False
        Me.TrackBarRetypeDelay.LargeChange = 10
        Me.TrackBarRetypeDelay.Location = New System.Drawing.Point(6, 74)
        Me.TrackBarRetypeDelay.Maximum = 50
        Me.TrackBarRetypeDelay.Minimum = 5
        Me.TrackBarRetypeDelay.Name = "TrackBarRetypeDelay"
        Me.TrackBarRetypeDelay.Size = New System.Drawing.Size(289, 20)
        Me.TrackBarRetypeDelay.TabIndex = 3
        Me.TrackBarRetypeDelay.TickFrequency = 5
        Me.TrackBarRetypeDelay.Value = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Retype Delay"
        '
        'GroupBoxHotkey
        '
        Me.GroupBoxHotkey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxHotkey.Controls.Add(Me.LabelInfo)
        Me.GroupBoxHotkey.Controls.Add(Me.TextBoxHotKey)
        Me.GroupBoxHotkey.Location = New System.Drawing.Point(12, 143)
        Me.GroupBoxHotkey.Name = "GroupBoxHotkey"
        Me.GroupBoxHotkey.Size = New System.Drawing.Size(301, 100)
        Me.GroupBoxHotkey.TabIndex = 4
        Me.GroupBoxHotkey.TabStop = False
        Me.GroupBoxHotkey.Text = "Activation Hotkey"
        '
        'LabelInfo
        '
        Me.LabelInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInfo.Location = New System.Drawing.Point(6, 16)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(289, 55)
        Me.LabelInfo.TabIndex = 1
        Me.LabelInfo.Text = "Click the textbox and then press the key combination that you want to use to open" &
    " KeyLaunch." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Make sure you select a unique key combination so that it doesn't in" &
    "terfere with other applications."
        '
        'TextBoxHotKey
        '
        Me.TextBoxHotKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxHotKey.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TextBoxHotKey.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.TextBoxHotKey.Location = New System.Drawing.Point(6, 74)
        Me.TextBoxHotKey.Name = "TextBoxHotKey"
        Me.TextBoxHotKey.ReadOnly = True
        Me.TextBoxHotKey.Size = New System.Drawing.Size(289, 20)
        Me.TextBoxHotKey.TabIndex = 0
        '
        'ButtonDefaults
        '
        Me.ButtonDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDefaults.Location = New System.Drawing.Point(12, 362)
        Me.ButtonDefaults.Name = "ButtonDefaults"
        Me.ButtonDefaults.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDefaults.TabIndex = 5
        Me.ButtonDefaults.Text = "Defaults"
        Me.ButtonDefaults.UseVisualStyleBackColor = True
        '
        'FormOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 391)
        Me.Controls.Add(Me.ButtonDefaults)
        Me.Controls.Add(Me.GroupBoxHotkey)
        Me.Controls.Add(Me.GroupBoxOptions)
        Me.Controls.Add(Me.GroupBoxColors)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1998, 430)
        Me.MinimumSize = New System.Drawing.Size(331, 430)
        Me.Name = "FormOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KeyLaunch Options"
        Me.GroupBoxColors.ResumeLayout(False)
        Me.GroupBoxColors.PerformLayout()
        CType(Me.TrackBarLum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarSat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarHue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxOptions.ResumeLayout(False)
        Me.GroupBoxOptions.PerformLayout()
        CType(Me.TrackBarRetypeDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxHotkey.ResumeLayout(False)
        Me.GroupBoxHotkey.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents CheckBoxStartWithWindows As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxColors As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrackBarLum As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarSat As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarHue As System.Windows.Forms.TrackBar
    Friend WithEvents CheckBoxShowTrayIcon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxOptions As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxHotkey As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxHotKey As System.Windows.Forms.TextBox
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents ButtonDefaults As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TrackBarRetypeDelay As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxkHideOnFocusLost As System.Windows.Forms.CheckBox
End Class

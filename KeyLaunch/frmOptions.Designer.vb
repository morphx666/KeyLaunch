<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.chkStartWithWindows = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbLum = New System.Windows.Forms.TrackBar()
        Me.tbSat = New System.Windows.Forms.TrackBar()
        Me.tbHue = New System.Windows.Forms.TrackBar()
        Me.chkShowTrayIcon = New System.Windows.Forms.CheckBox()
        Me.gbOptions = New System.Windows.Forms.GroupBox()
        Me.chkHideOnFocusLost = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbRetypeDelay = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbHotkey = New System.Windows.Forms.GroupBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.txtHotKey = New System.Windows.Forms.TextBox()
        Me.btnDefaults = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tbLum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbHue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOptions.SuspendLayout()
        CType(Me.tbRetypeDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbHotkey.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Location = New System.Drawing.Point(157, 362)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(238, 362)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkStartWithWindows
        '
        Me.chkStartWithWindows.AutoSize = True
        Me.chkStartWithWindows.Location = New System.Drawing.Point(6, 19)
        Me.chkStartWithWindows.Name = "chkStartWithWindows"
        Me.chkStartWithWindows.Size = New System.Drawing.Size(117, 17)
        Me.chkStartWithWindows.TabIndex = 0
        Me.chkStartWithWindows.Text = "Start with Windows"
        Me.chkStartWithWindows.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbLum)
        Me.GroupBox1.Controls.Add(Me.tbSat)
        Me.GroupBox1.Controls.Add(Me.tbHue)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 107)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Interface Colors"
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
        'tbLum
        '
        Me.tbLum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLum.AutoSize = False
        Me.tbLum.BackColor = System.Drawing.SystemColors.Control
        Me.tbLum.LargeChange = 1
        Me.tbLum.Location = New System.Drawing.Point(75, 71)
        Me.tbLum.Maximum = 100
        Me.tbLum.Name = "tbLum"
        Me.tbLum.Size = New System.Drawing.Size(220, 20)
        Me.tbLum.TabIndex = 3
        Me.tbLum.TickFrequency = 10
        '
        'tbSat
        '
        Me.tbSat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSat.AutoSize = False
        Me.tbSat.LargeChange = 1
        Me.tbSat.Location = New System.Drawing.Point(75, 45)
        Me.tbSat.Maximum = 100
        Me.tbSat.Name = "tbSat"
        Me.tbSat.Size = New System.Drawing.Size(220, 20)
        Me.tbSat.TabIndex = 2
        Me.tbSat.TickFrequency = 10
        '
        'tbHue
        '
        Me.tbHue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbHue.AutoSize = False
        Me.tbHue.LargeChange = 15
        Me.tbHue.Location = New System.Drawing.Point(75, 19)
        Me.tbHue.Maximum = 360
        Me.tbHue.Name = "tbHue"
        Me.tbHue.Size = New System.Drawing.Size(220, 20)
        Me.tbHue.TabIndex = 1
        Me.tbHue.TickFrequency = 15
        '
        'chkShowTrayIcon
        '
        Me.chkShowTrayIcon.AutoSize = True
        Me.chkShowTrayIcon.Location = New System.Drawing.Point(6, 38)
        Me.chkShowTrayIcon.Name = "chkShowTrayIcon"
        Me.chkShowTrayIcon.Size = New System.Drawing.Size(101, 17)
        Me.chkShowTrayIcon.TabIndex = 1
        Me.chkShowTrayIcon.Text = "Show Tray Icon"
        Me.chkShowTrayIcon.UseVisualStyleBackColor = True
        '
        'gbOptions
        '
        Me.gbOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbOptions.Controls.Add(Me.chkHideOnFocusLost)
        Me.gbOptions.Controls.Add(Me.Label7)
        Me.gbOptions.Controls.Add(Me.Label6)
        Me.gbOptions.Controls.Add(Me.Label5)
        Me.gbOptions.Controls.Add(Me.tbRetypeDelay)
        Me.gbOptions.Controls.Add(Me.Label1)
        Me.gbOptions.Controls.Add(Me.chkStartWithWindows)
        Me.gbOptions.Controls.Add(Me.chkShowTrayIcon)
        Me.gbOptions.Location = New System.Drawing.Point(12, 12)
        Me.gbOptions.Name = "gbOptions"
        Me.gbOptions.Size = New System.Drawing.Size(301, 125)
        Me.gbOptions.TabIndex = 3
        Me.gbOptions.TabStop = False
        Me.gbOptions.Text = "Options"
        '
        'chkHideOnFocusLost
        '
        Me.chkHideOnFocusLost.AutoSize = True
        Me.chkHideOnFocusLost.Location = New System.Drawing.Point(139, 19)
        Me.chkHideOnFocusLost.Name = "chkHideOnFocusLost"
        Me.chkHideOnFocusLost.Size = New System.Drawing.Size(142, 17)
        Me.chkHideOnFocusLost.TabIndex = 7
        Me.chkHideOnFocusLost.Text = "Hide when loosing focus"
        Me.chkHideOnFocusLost.UseVisualStyleBackColor = True
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
        'tbRetypeDelay
        '
        Me.tbRetypeDelay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRetypeDelay.AutoSize = False
        Me.tbRetypeDelay.LargeChange = 10
        Me.tbRetypeDelay.Location = New System.Drawing.Point(6, 74)
        Me.tbRetypeDelay.Maximum = 50
        Me.tbRetypeDelay.Minimum = 5
        Me.tbRetypeDelay.Name = "tbRetypeDelay"
        Me.tbRetypeDelay.Size = New System.Drawing.Size(289, 20)
        Me.tbRetypeDelay.TabIndex = 3
        Me.tbRetypeDelay.TickFrequency = 5
        Me.tbRetypeDelay.Value = 5
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
        'gbHotkey
        '
        Me.gbHotkey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbHotkey.Controls.Add(Me.lblInfo)
        Me.gbHotkey.Controls.Add(Me.txtHotKey)
        Me.gbHotkey.Location = New System.Drawing.Point(12, 143)
        Me.gbHotkey.Name = "gbHotkey"
        Me.gbHotkey.Size = New System.Drawing.Size(301, 100)
        Me.gbHotkey.TabIndex = 4
        Me.gbHotkey.TabStop = False
        Me.gbHotkey.Text = "Activation Hotkey"
        '
        'lblInfo
        '
        Me.lblInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(6, 16)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(289, 55)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "Click the textbox and then press the key combination that you want to use to open" &
    " KeyLaunch." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Make sure you select a unique key combination so that it doesn't in" &
    "terfere with other applications."
        '
        'txtHotKey
        '
        Me.txtHotKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHotKey.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtHotKey.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtHotKey.Location = New System.Drawing.Point(6, 74)
        Me.txtHotKey.Name = "txtHotKey"
        Me.txtHotKey.ReadOnly = True
        Me.txtHotKey.Size = New System.Drawing.Size(289, 20)
        Me.txtHotKey.TabIndex = 0
        '
        'btnDefaults
        '
        Me.btnDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDefaults.Location = New System.Drawing.Point(12, 362)
        Me.btnDefaults.Name = "btnDefaults"
        Me.btnDefaults.Size = New System.Drawing.Size(75, 23)
        Me.btnDefaults.TabIndex = 5
        Me.btnDefaults.Text = "Defaults"
        Me.btnDefaults.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 391)
        Me.Controls.Add(Me.btnDefaults)
        Me.Controls.Add(Me.gbHotkey)
        Me.Controls.Add(Me.gbOptions)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1998, 430)
        Me.MinimumSize = New System.Drawing.Size(331, 430)
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KeyLaunch Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tbLum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbHue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOptions.ResumeLayout(False)
        Me.gbOptions.PerformLayout()
        CType(Me.tbRetypeDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbHotkey.ResumeLayout(False)
        Me.gbHotkey.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkStartWithWindows As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbLum As System.Windows.Forms.TrackBar
    Friend WithEvents tbSat As System.Windows.Forms.TrackBar
    Friend WithEvents tbHue As System.Windows.Forms.TrackBar
    Friend WithEvents chkShowTrayIcon As System.Windows.Forms.CheckBox
    Friend WithEvents gbOptions As System.Windows.Forms.GroupBox
    Friend WithEvents gbHotkey As System.Windows.Forms.GroupBox
    Friend WithEvents txtHotKey As System.Windows.Forms.TextBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents btnDefaults As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbRetypeDelay As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkHideOnFocusLost As System.Windows.Forms.CheckBox
End Class

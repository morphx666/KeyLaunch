Public Class FormOptions
    Private Preferences As FormMain.PreferencesDef = FormMain.Preferences

    Private hotKeyIsValid As Boolean

    Private Sub FormOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.Preferences.hotKey = Keys.None Then
            If MsgBox("Are you sure you want to disable the use of a hot key to open KeyLaunch?" + vbCrLf + vbCrLf +
                "If you answer Yes, the 'Show Tray Icon' option will be enabled by default", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Hot key no set or invalid") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                FormMain.Preferences.showTrayIcon = True
            End If
        End If
    End Sub

    Private Sub FormOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupUI()

        AddHandler TrackBarHue.ValueChanged, AddressOf SetNewColor
        AddHandler TrackBarSat.ValueChanged, AddressOf SetNewColor
        AddHandler TrackBarLum.ValueChanged, AddressOf SetNewColor
    End Sub

    Private Sub SetupUI()
        With FormMain.Preferences
            If Not .optionsWindowLocation.IsEmpty Then
                Me.Location = .optionsWindowLocation
                Me.Size = .optionsWindowSize
            End If

            TrackBarHue.Value = CInt(.mainColor.Hue)
            TrackBarSat.Value = CInt(.mainColor.Saturation * 100)
            TrackBarLum.Value = CInt(.mainColor.Luminance * 100)

            TextBoxHotKey.Text = SearchCategory.KeysToString(.hotKey)
            TrackBarRetypeDelay.Value = .retypeDelay \ 100
            CheckBoxShowTrayIcon.Checked = .showTrayIcon
            CheckBoxStartWithWindows.Checked = .startWithWindows
            CheckBoxkHideOnFocusLost.Checked = .hideOnFocusLost
        End With
    End Sub

    Private Sub SetNewColor(sender As Object, e As EventArgs)
        With Me.Preferences.mainColor
            .Hue = TrackBarHue.Value
            .Saturation = CSng(TrackBarSat.Value / 100)
            .Luminance = CSng(TrackBarLum.Value / 100)
        End With
        FormMain.SetMainColor(Me.Preferences.mainColor.Color)
        FormMain.Invalidate()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        FormMain.Preferences = Me.Preferences
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub TextBoxHotKey_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxHotKey.KeyDown
        If e.KeyValue >= 31 Then
            Me.Preferences.hotKey = e.KeyData
            hotKeyIsValid = True
        Else
            hotKeyIsValid = False
        End If

        TextBoxHotKey.Text = SearchCategory.KeysToString(e.KeyData)
    End Sub

    Private Sub TextBoxHotKey_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxHotKey.KeyUp
        If hotKeyIsValid = False Then
            TextBoxHotKey.Text = Keys.None.ToString
            Me.Preferences.hotKey = Keys.None
        End If
    End Sub

    Private Sub TrackBarRetypeDelay_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarRetypeDelay.ValueChanged
        Me.Preferences.retypeDelay = TrackBarRetypeDelay.Value * 100
    End Sub

    Private Sub CheckBoxStartWithWindows_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxStartWithWindows.CheckedChanged
        Me.Preferences.startWithWindows = CheckBoxStartWithWindows.Checked
    End Sub

    Private Sub CheckBoxShowTrayIcon_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowTrayIcon.CheckedChanged
        Me.Preferences.showTrayIcon = CheckBoxShowTrayIcon.Checked
    End Sub

    Private Sub CheckBoxHideOnFocusLost_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxkHideOnFocusLost.CheckedChanged
        Me.Preferences.hideOnFocusLost = CheckBoxkHideOnFocusLost.Checked
    End Sub

    Private Sub ButtonDefaults_Click(sender As Object, e As EventArgs) Handles ButtonDefaults.Click
        FormMain.SetDefaultKLPreferences()
        Me.Preferences = FormMain.Preferences
        SetupUI()
    End Sub
End Class
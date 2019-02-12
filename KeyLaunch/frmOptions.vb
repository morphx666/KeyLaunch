Public Class frmOptions
    Private Preferences As frmMain.PreferencesDef = frmMain.Preferences

    Private hotKeyIsValid As Boolean

    Private Sub frmOptions_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.Preferences.hotKey = Keys.None Then
            If MsgBox("Are you sure you want to disable the use of a hot key to open KeyLaunch?" + vbCrLf + vbCrLf +
                "If you answer Yes, the 'Show Tray Icon' option will be enabled by default", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Hot key no set or invalid") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                frmMain.Preferences.showTrayIcon = True
            End If
        End If
    End Sub

    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        SetupUI()

        AddHandler tbHue.ValueChanged, AddressOf SetNewColor
        AddHandler tbSat.ValueChanged, AddressOf SetNewColor
        AddHandler tbLum.ValueChanged, AddressOf SetNewColor
    End Sub

    Private Sub SetupUI()
        With frmMain.Preferences
            If Not .optionsWindowLocation.IsEmpty Then
                Me.Location = .optionsWindowLocation
                Me.Size = .optionsWindowSize
            End If

            tbHue.Value = CInt(.mainColor.Hue)
            tbSat.Value = CInt(.mainColor.Saturation * 100)
            tbLum.Value = CInt(.mainColor.Luminance * 100)

            txtHotKey.Text = SearchCategory.KeysToString(.hotKey)
            tbRetypeDelay.Value = .retypeDelay \ 100
            chkShowTrayIcon.Checked = .showTrayIcon
            chkStartWithWindows.Checked = .startWithWindows
            chkHideOnFocusLost.Checked = .hideOnFocusLost
        End With
    End Sub

    Private Sub SetNewColor(ByVal sender As Object, ByVal e As EventArgs)
        With Me.Preferences.mainColor
            .Hue = tbHue.Value
            .Saturation = CSng(tbSat.Value / 100)
            .Luminance = CSng(tbLum.Value / 100)
        End With
        frmMain.SetMainColor(Me.Preferences.mainColor.Color)
        frmMain.Invalidate()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdOK.Click
        frmMain.Preferences = Me.Preferences
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtHotKey_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHotKey.KeyDown
        If e.KeyValue >= 31 Then
            Me.Preferences.hotKey = e.KeyData
            hotKeyIsValid = True
        Else
            hotKeyIsValid = False
        End If

        txtHotKey.Text = SearchCategory.KeysToString(e.KeyData)
    End Sub

    Private Sub txtHotKey_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHotKey.KeyUp
        If hotKeyIsValid = False Then
            txtHotKey.Text = Keys.None.ToString
            Me.Preferences.hotKey = Keys.None
        End If
    End Sub

    Private Sub tbRetypeDelay_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbRetypeDelay.Scroll

    End Sub

    Private Sub tbRetypeDelay_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbRetypeDelay.ValueChanged
        Me.Preferences.retypeDelay = tbRetypeDelay.Value * 100
    End Sub

    Private Sub chkStartWithWindows_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkStartWithWindows.CheckedChanged
        Me.Preferences.startWithWindows = chkStartWithWindows.Checked
    End Sub

    Private Sub chkShowTrayIcon_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkShowTrayIcon.CheckedChanged
        Me.Preferences.showTrayIcon = chkShowTrayIcon.Checked
    End Sub

    Private Sub chkHideOnFocusLost_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkHideOnFocusLost.CheckedChanged
        Me.Preferences.hideOnFocusLost = chkHideOnFocusLost.Checked
    End Sub

    Private Sub btnDefaults_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDefaults.Click
        frmMain.SetDefaultKLPreferences()
        Me.Preferences = frmMain.Preferences
        SetupUI()
    End Sub
End Class
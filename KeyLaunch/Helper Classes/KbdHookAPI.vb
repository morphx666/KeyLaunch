Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Drawing
Imports System.Threading

Public Class KbdHookAPI
    Private Delegate Function KeyboardHookDelegate(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    <MarshalAs(UnmanagedType.FunctionPtr)> Private callback As KeyboardHookDelegate

    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Long
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Private Declare Function CallNextHookEx Lib "user32" (ByVal hHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As KBDLLHOOKSTRUCT) As Integer

    Private Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    ' Low-Level Keyboard Constants
    Private Const HC_ACTION As Integer = 0
    'Private Const LLKHF_EXTENDED As Integer = &H1
    'Private Const LLKHF_INJECTED As Integer = &H10
    Private Const LLKHF_ALTDOWN As Integer = &H20
    'Private Const LLKHF_UP As Integer = &H80

    'Private Const VK_TAB As Integer = &H9
    Private Const VK_CONTROL As Integer = &H11
    Private Const VK_SHIFT As Integer = &H10
    'Private Const VK_ESCAPE As Integer = &H1B
    'Private Const VK_DELETE As Integer = &H2E

    Private Const WH_KEYBOARD_LL As Integer = 13&
    Private keyboardHandle As Integer

    Private mHookedKeys As List(Of Keys) = New List(Of Keys)()
    Private mCaptureAllKeys As Boolean

    Public Event KeyDown(ByVal e As KeyEventArgs)
    Public Event KeyUp(ByVal e As KeyEventArgs)

    'Private frmForm As Form

    Public Sub New()
        mHookedKeys.Add(Keys.Scroll)

        'frmForm = New Form()
        'frmForm.Location = New Point(0, 0)
        'frmForm.Size = New Size(200, 20)
        'frmForm.Visible = True
    End Sub

    Public Property CaptureAllKeys() As Boolean
        Get
            Return mCaptureAllKeys
        End Get
        Set(ByVal value As Boolean)
            mCaptureAllKeys = value
        End Set
    End Property

    Public ReadOnly Property HookedKeys() As List(Of Keys)
        Get
            Return mHookedKeys
        End Get
    End Property

    Private Function IsHooked(ByRef hookStruct As KBDLLHOOKSTRUCT) As Boolean
        Dim key As Keys = CType(hookStruct.vkCode, Keys)

        Select Case key
            Case Keys.LShiftKey, Keys.LControlKey, Keys.LMenu, Keys.RShiftKey, Keys.RControlKey, Keys.RMenu
                Return False
            Case Else
                If CBool(GetAsyncKeyState(VK_CONTROL) And &H8000) Then key = key Or Keys.Control
                If CBool(GetAsyncKeyState(VK_SHIFT) And &H8001) Then key = key Or Keys.Shift
                If CBool(hookStruct.flags And LLKHF_ALTDOWN) Then key = key Or Keys.Alt

                If mCaptureAllKeys OrElse mHookedKeys.Contains(key) Then
                    If (hookStruct.flags And &H80) = &H80 Then
                        RaiseEvent KeyUp(New KeyEventArgs(key))
                    Else
                        RaiseEvent KeyDown(New KeyEventArgs(key))
                    End If

                    Return True
                End If
        End Select

        Return False
    End Function

    Private Function KeyboardCallback(ByVal code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
        If code = HC_ACTION Then
            If IsHooked(lParam) Then Return 1
        End If

        Return CallNextHookEx(keyboardHandle, code, wParam, lParam)
    End Function

    Public Sub HookKeyboard()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)
        keyboardHandle = SetWindowsHookEx(WH_KEYBOARD_LL,
                                          callback,
                                          Marshal.GetHINSTANCE([Assembly].GetExecutingAssembly().GetModules()(0)),
                                          0)
        Debug.WriteLine($"Hooked: {keyboardHandle}")
    End Sub

    Private Function Hooked() As Boolean
        Return (keyboardHandle <> 0)
    End Function

    Public Sub UnhookKeyboard()
        If Hooked() Then UnhookWindowsHookEx(keyboardHandle)
    End Sub
End Class

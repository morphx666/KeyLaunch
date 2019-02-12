Imports System.Threading

Public Class frmAbout
    Private mainColor As HLSRGB = New HLSRGB(Color.DarkSlateBlue)

    Private txtTitle As String = "KeyLaunch 3.0"
    Private txtTitleFont As Font = New Font("Trebuchet MS", 40, FontStyle.Bold, GraphicsUnit.Pixel)
    Private txtVerInfo As String = My.Application.Info.Version.ToString
    Private textSize As Size
    Private textVerInfoSize As Size
    Private rect As Rectangle
    Private gradBrush As Drawing2D.LinearGradientBrush
    Private msg As String = ""
    Private msgTop As Integer = 0
    Private cpInfo As String = ""

    Private Sub frmAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Click
        Me.Close()
    End Sub

    Private Sub frmAbout_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        Me.Close()
    End Sub

    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.DoubleBuffered = True
        Me.TransparencyKey = Me.BackColor
        Me.TopMost = True

        Dim g As Graphics = Me.CreateGraphics
        textSize = g.MeasureString(txtTitle, txtTitleFont, 0, StringFormat.GenericTypographic).ToSize
        textVerInfoSize = g.MeasureString(txtVerInfo, Me.Font, 0, StringFormat.GenericTypographic).ToSize
        rect = New Rectangle(pbKLLogo.Right, pbKLLogo.Top - 5, Me.Width, textSize.Height)
        g.Dispose()

        Dim colorCycleThread As Thread = New Thread(AddressOf CycleColor)
        colorCycleThread.IsBackground = True
        colorCycleThread.Start()

        Dim scrollTextThread As Thread = New Thread(AddressOf ScrollText)
        scrollTextThread.IsBackground = True
        scrollTextThread.Start()

        msg = vbCrLf + vbCrLf + vbCrLf
        msg += "For short, KeyLaunch 3.0 is... well... KeyLaunch 2.0 on steroids!" + vbCrLf + vbCrLf
        msg += "KeyLaunch is a small utility to let you access the thousands of documents on your computer with just a few keystrokes." + vbCrLf + vbCrLf
        msg += "At its time of release, back in 2002, KeyLaunch was the first ever instant desktop search utility for Windows!" + vbCrLf + vbCrLf
        msg += "With Today's huge hard drives, which can store millions of files, accessing a particular document on your computer can be a tedious job. The Windows' START menu is meant to alleviate this, with features such as the Recent menu, the My Documents menu, etcetera... but we all know that's not enough." + vbCrLf
        msg += "Most of the time, accessing a particular file can represent several dozen of mouse clicks navigating several folders or menus." + vbCrLf + vbCrLf
        msg += "With KeyLaunch and just a couple of keystrokes you can access any document like you have never done before!" + vbCrLf
        msg += "You will be surprised of how fast you locate documents you don't even know where they actually are!" + vbCrLf
        msg += "KeyLaunch will sit hidden on the top of your screen. Then, when you need it, simply press the Scroll Lock key and start typing a couple of letters from the document you're looking for." + vbCrLf + vbCrLf
        msg += "It doesn't matter the type of document; whether it is an MP3, a Word document, an Internet shortcut or even a program KeyLaunch will find it for you in a matter of seconds." + vbCrLf
        msg += "Then... the next time you type those same letters again KeyLaunch will access that document for you automatically." + vbCrLf
        msg += "Or you can even assign shortcut keys to access your favorite applications or documents by simply pressing the Scroll Lock key plus one of the functions keys." + vbCrLf
        msg += "To really experience what having KeyLaunch feels like... you have to try it." + vbCrLf + vbCrLf
        msg += "In just a couple of days you'll wonder how you ever lived with out it!"
        msg += vbCrLf + vbCrLf + vbCrLf + vbCrLf + vbCrLf
        msg += "Thank you, WhiteLion, for inspiring me to create version 3.0"
        msg += vbCrLf + vbCrLf + vbCrLf + vbCrLf
        msg += "And, as always, I would like to thank my wife and my kids for their amazing and unconditional support..."
        msg += "I love you guys!"
        msg += vbCrLf + vbCrLf + vbCrLf + vbCrLf
        msg += "Well, that's it..."
        msg += "I really hope you enjoy using KeyLaunch!"

        cpInfo = "Copyright © 2002-" + My.Computer.Clock.LocalTime.Year.ToString + " xFX JumpStart : Software Division" + vbCrLf + _
                "This computer program is protected by copyright law and international treaties."
    End Sub

    Private Sub frmAbout_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics

        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        FillRoundedRectangle(g, 0, 0, Width - 2, Height - 2, 16, Brushes.White)

        '---------------------

        Dim msgRect As Rectangle = New Rectangle(rect.Left, rect.Bottom + 20 - msgTop, Me.Width - rect.Left * 2, Me.Height - rect.Bottom - 22 + msgTop)
        g.DrawString(msg, Me.Font, Brushes.DarkSlateGray, msgRect, StringFormat.GenericTypographic)

        Dim bRect As Rectangle = New Rectangle(msgRect.Left - 1, rect.Bottom + 20, msgRect.Width + 2, 40)
        g.FillRectangle(Brushes.White, bRect.Left, 0, bRect.Width, bRect.Top + 2)
        Dim b As Drawing2D.LinearGradientBrush = New Drawing2D.LinearGradientBrush( _
                                bRect, _
                                Color.White, _
                                Color.Transparent, _
                                Drawing2D.LinearGradientMode.Vertical)
        g.FillRectangle(b, bRect)

        bRect = New Rectangle(bRect.Left, Me.Height - 80, bRect.Width, 30)
        b = New Drawing2D.LinearGradientBrush( _
                                bRect, _
                                Color.Transparent, _
                                Color.White, _
                                Drawing2D.LinearGradientMode.Vertical)
        g.FillRectangle(b, bRect)
        g.FillRectangle(Brushes.White, bRect.Left, bRect.Bottom - 1, bRect.Width, Me.Height - bRect.Bottom - 2)

        ' ------------------

        g.DrawString(txtTitle, txtTitleFont, New SolidBrush(Color.FromArgb(180, 51, 51, 51)), rect.X + 2, rect.Y + 2, StringFormat.GenericTypographic)
        gradBrush = New Drawing2D.LinearGradientBrush( _
                                New Rectangle(rect.Right, 0, rect.Width, rect.Height \ 2 + 8), _
                                mainColor.Color, _
                                Color.WhiteSmoke, _
                                Drawing2D.LinearGradientMode.Vertical)
        g.DrawString(txtTitle, txtTitleFont, gradBrush, rect, StringFormat.GenericTypographic)
        g.DrawString(txtVerInfo, Me.Font, Brushes.DarkGray, rect.Left + textSize.Width - textVerInfoSize.Width, rect.Bottom, StringFormat.GenericTypographic)

        '--------------------

        g.DrawString(cpInfo, Me.Font, Brushes.LightSlateGray, 10, Me.Height - 35)

        DrawRoundedRectangle(g, 0, 0, Width - 2, Height - 2, 16, Pens.Black)
    End Sub

    Private Sub CycleColor()
        Do
            Thread.Sleep(60)
            mainColor.Hue = (mainColor.Hue + 1) Mod 360
            Me.Invalidate()
        Loop
    End Sub

    Private Sub ScrollText()
        Thread.Sleep(5000)
        Do
            Thread.Sleep(100)
            msgTop += 1
            If msgTop > 640 Then msgTop = -160
        Loop
    End Sub
End Class
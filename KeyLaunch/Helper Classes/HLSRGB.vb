<Serializable()> _
Public Class HLSRGB
    Private mRed As Byte = 0
    Private mGreen As Byte = 0
    Private mBlue As Byte = 0

    Private mHue As Single = 0
    Private mLuminance As Single = 0
    Private mSaturation As Single = 0

    Public Sub New(ByVal c As Drawing.Color)
        mRed = c.R
        mGreen = c.G
        mBlue = c.B
        ToHLS()
    End Sub

    Public Sub New(ByVal hue As Single, ByVal luminance As Single, ByVal saturation As Single)
        mHue = hue
        mLuminance = luminance
        mSaturation = saturation
        ToRGB()
    End Sub

    Public Sub New(ByVal red As Byte, ByVal green As Byte, ByVal blue As Byte)
        mRed = red
        mGreen = green
        mBlue = blue
    End Sub

    Public Sub New(ByVal hlsrgb As HLSRGB)
        mRed = hlsrgb.Red
        mBlue = hlsrgb.Blue
        mGreen = hlsrgb.Green
        mLuminance = hlsrgb.Luminance
        mHue = hlsrgb.Hue
        mSaturation = hlsrgb.Saturation
    End Sub

    Public Sub New()
    End Sub

    Public Property Red() As Byte
        Get
            Return mRed
        End Get
        Set(ByVal value As Byte)
            mRed = value
            ToHLS()
        End Set
    End Property

    Public Property Green() As Byte
        Get
            Return mGreen
        End Get
        Set(ByVal value As Byte)
            mGreen = value
            ToHLS()
        End Set
    End Property

    Public Property Blue() As Byte
        Get
            Return mBlue
        End Get
        Set(ByVal value As Byte)
            mBlue = value
            ToHLS()
        End Set
    End Property

    Public Property Luminance() As Single
        Get
            Return mLuminance
        End Get
        Set(ByVal value As Single)
            If (value < 0.0F) Or (value > 1.0F) Then
                Throw New ArgumentOutOfRangeException("Luminance", "Luminance must be between 0.0 and 1.0")
            End If
            mLuminance = value
            ToRGB()
        End Set
    End Property

    Public Property Hue() As Single
        Get
            Return mHue
        End Get
        Set(ByVal value As Single)
            If value < 0.0F Then value = Math.Abs((360.0F + value) Mod 360.0F)
            If value > 360.0F Then value = value Mod 360.0F
            'If (value < 0.0F) Or (value > 360.0F) Then
            '    Throw New ArgumentOutOfRangeException("Hue", "Hue must be between 0.0 and 360.0")
            'End If
            mHue = value
            ToRGB()
        End Set
    End Property

    Public Property Saturation() As Single
        Get
            Return mSaturation
        End Get
        Set(ByVal value As Single)
            If (value < 0.0F) Or (value > 1.0F) Then
                Throw New ArgumentOutOfRangeException("Saturation", "Saturation must be between 0.0 and 1.0")
            End If
            mSaturation = value
            ToRGB()
        End Set
    End Property

    Public Property Color() As Color
        Get
            Return Drawing.Color.FromArgb(mRed, mGreen, mBlue)
        End Get
        Set(ByVal value As Color)
            mRed = value.R
            mGreen = value.G
            mBlue = value.B
            ToHLS()
        End Set
    End Property

    Public Sub LightenColor(ByVal lightenBy As Single)
        mLuminance *= (1.0F + lightenBy)
        If mLuminance > 1.0F Then Luminance = 1.0F
        ToRGB()
    End Sub

    Public Sub DarkenColor(ByVal darkenBy As Single)
        Luminance *= darkenBy
        ToRGB()
    End Sub

    Private Sub ToHLS()
        Dim minval As Byte = Math.Min(mRed, Math.Min(mGreen, mBlue))
        Dim maxval As Byte = Math.Max(mRed, Math.Max(mGreen, mBlue))

        Dim mdiff As Single = CSng(maxval) - CSng(minval)
        Dim msum As Single = CSng(maxval) + CSng(minval)

        mLuminance = msum / 510.0F

        If maxval = minval Then
            mSaturation = 0.0F
            mHue = 0.0F
        Else
            Dim rnorm As Single = (maxval - mRed) / mdiff
            Dim gnorm As Single = (maxval - mGreen) / mdiff
            Dim bnorm As Single = (maxval - mBlue) / mdiff

            mSaturation = IIf(Of Single)(mLuminance <= 0.5F, (mdiff / msum), mdiff / (510.0F - msum))

            If mRed = maxval Then mHue = 60.0F * (6.0F + bnorm - gnorm)
            If mGreen = maxval Then mHue = 60.0F * (2.0F + rnorm - bnorm)
            If mBlue = maxval Then mHue = 60.0F * (4.0F + gnorm - rnorm)
            If mHue > 360.0F Then mHue = Hue - 360.0F
        End If
    End Sub

    Private Sub ToRGB()
        If mSaturation = 0.0 Then
            Red = CByte(mLuminance * 255.0F)
            mGreen = mRed
            mBlue = mRed
        Else
            Dim rm1 As Single
            Dim rm2 As Single

            If mLuminance <= 0.5F Then
                rm2 = mLuminance + mLuminance * mSaturation
            Else
                rm2 = mLuminance + mSaturation - mLuminance * mSaturation
            End If
            rm1 = 2.0F * mLuminance - rm2
            mRed = ToRGB1(rm1, rm2, mHue + 120.0F)
            mGreen = ToRGB1(rm1, rm2, mHue)
            mBlue = ToRGB1(rm1, rm2, mHue - 120.0F)
        End If
    End Sub

    Private Function ToRGB1(ByVal rm1 As Single, ByVal rm2 As Single, ByVal rh As Single) As Byte
        If rh > 360.0F Then
            rh -= 360.0F
        ElseIf rh < 0.0F Then
            rh += 360.0F
        End If

        If (rh < 60.0F) Then
            rm1 = rm1 + (rm2 - rm1) * rh / 60.0F
        ElseIf (rh < 180.0F) Then
            rm1 = rm2
        ElseIf (rh < 240.0F) Then
            rm1 = rm1 + (rm2 - rm1) * (240.0F - rh) / 60.0F
        End If

        Return CByte(rm1 * 255)
    End Function
End Class

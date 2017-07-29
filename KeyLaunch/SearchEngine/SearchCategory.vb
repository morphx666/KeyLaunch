<Serializable()> _
Public Class SearchCategory
    Private mName As String
    Private mExtensions As List(Of String)
    Private mItem As SearchItem
    Private mColor As Color
    Private mShortCut As Keys
    Private mShortCutName As String

    Public Sub New()
        mExtensions = New List(Of String)
        mColor = Drawing.Color.Black
    End Sub

    Public Overrides Function ToString() As String
        Return mName
    End Function

    Public Property ShortCutName() As String
        Get
            If mShortCutName = "" Then
                Return Keys.None.ToString
            Else
                Return mShortCutName
            End If
        End Get
        Set(ByVal value As String)
            mShortCutName = value
        End Set
    End Property

    Public Property ShortCut() As Keys
        Get
            Return mShortCut
        End Get
        Set(ByVal value As Keys)
            mShortCut = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property

    Public ReadOnly Property Extensions() As List(Of String)
        Get
            Return mExtensions
        End Get
    End Property

    Public Property Item() As SearchItem
        Get
            Return mItem
        End Get
        Set(ByVal value As SearchItem)
            mItem = value
        End Set
    End Property

    Public Property Color() As Color
        Get
            Return mColor
        End Get
        Set(ByVal value As Color)
            mColor = value
        End Set
    End Property

    Public Shared Function KeysToString(ByVal keyData As Keys) As String
        Dim modifier As String = ""
        Dim key As String = ""
        Dim keyModifiers As Keys = keyData And Keys.Modifiers
        Dim keyCode As Keys = keyData And Keys.KeyCode

        If keyModifiers <> Keys.None Then
            modifier = keyModifiers.ToString()
            If modifier.Contains(", ") Then
                modifier = modifier.Replace(", ", " + ") + " + "
            Else
                modifier += " + "
            End If
        End If

        If keyCode >= 31 Then key = keyCode.ToString()

        Return modifier + key
    End Function

    Public Shared Operator =(ByVal sc1 As SearchCategory, ByVal sc2 As SearchCategory) As Boolean
        Return sc1.Name = sc2.Name
    End Operator

    Public Shared Operator <>(ByVal sc1 As SearchCategory, ByVal sc2 As SearchCategory) As Boolean
        Return Not (sc1 = sc2)
    End Operator
End Class

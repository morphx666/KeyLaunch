Public Class SearchItems
    Implements IList(Of SearchItem)

    Private mCol As List(Of SearchItem)

    Public Sub New()
        mCol = New List(Of SearchItem)
    End Sub

    Public Sub Add(item As SearchItem) Implements ICollection(Of SearchItem).Add
        mCol.Add(item)
    End Sub

    Public Sub Clear() Implements ICollection(Of SearchItem).Clear
        mCol.Clear()
    End Sub

    Public Function Contains(item As SearchItem) As Boolean Implements ICollection(Of SearchItem).Contains
        Return mCol.Contains(item)
    End Function

    Public Sub CopyTo(array() As SearchItem, arrayIndex As Integer) Implements ICollection(Of SearchItem).CopyTo

    End Sub

    Public ReadOnly Property Count() As Integer Implements ICollection(Of SearchItem).Count
        Get
            Return mCol.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements ICollection(Of SearchItem).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function Remove(item As SearchItem) As Boolean Implements ICollection(Of SearchItem).Remove
        Return mCol.Remove(item)
    End Function

    Public Function GetEnumerator() As IEnumerator(Of SearchItem) Implements IEnumerable(Of SearchItem).GetEnumerator
        Return mCol.GetEnumerator
    End Function

    Public Function IndexOf(item As SearchItem) As Integer Implements IList(Of SearchItem).IndexOf
        Return mCol.IndexOf(item)
    End Function

    Public Sub Insert(index As Integer, item As SearchItem) Implements IList(Of SearchItem).Insert
        mCol.Insert(index, item)
    End Sub

    Default Public Property Item(index As Integer) As SearchItem Implements IList(Of SearchItem).Item
        Get
            Return mCol.Item(index)
        End Get
        Set(ByVal value As SearchItem)
            mCol.Item(index) = value
        End Set
    End Property

    Public ReadOnly Property ItemDescription(index As Integer) As String
        Get
            Return SearchItems.GetExtensionDescription(mCol(index).FileInfo.Extension)
        End Get
    End Property

    Public Shared Function GetAssociatedApplication(keyData As String) As String
        If keyData = "linkfile" Then Return WinDir() + "explorer.exe"

        Dim key As Microsoft.Win32.RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey(keyData + "\shell\open\command", False)
        If key IsNot Nothing AndAlso key.ValueCount > 0 AndAlso key.GetValue("") IsNot Nothing Then
            keyData = key.GetValue("").ToString
            key.Close()

            If keyData.Contains("rundll32") Then
                keyData = ""
            Else
                If keyData.StartsWith("""") Then
                    keyData = keyData.Substring(1, keyData.IndexOf("""", 1) - 1)
                Else
                    Do While keyData.Contains("%")
                        keyData = keyData.Substring(0, keyData.IndexOf("%") - 1)
                    Loop

                    Do While keyData.Contains("/")
                        keyData = keyData.Substring(0, keyData.IndexOf("/") - 1)
                    Loop

                    Do While keyData.Contains("-")
                        keyData = keyData.Substring(0, keyData.IndexOf("-") - 1)
                    Loop
                End If
                If keyData = "%1" Then
                    keyData = WinDir() + "explorer.exe"
                Else
                    If Not keyData.Contains("\") Then keyData = FindInPath(keyData)
                    If Not IO.File.Exists(keyData) Then keyData = ""
                End If
            End If
        Else
            keyData = ""
        End If

        Return keyData
    End Function

    Private Shared Function FindInPath(file As String) As String
        Return If(IO.File.Exists(Environment.SystemDirectory + "\" + file),
                    Environment.SystemDirectory + "\" + file,
                    If(IO.File.Exists(WinDir() + file),
                        WinDir() + file,
                        file))
    End Function

    Private Shared Function WinDir() As String
        Return Environment.SystemDirectory.Substring(0, Environment.SystemDirectory.LastIndexOf("\")) + "\"
    End Function

    Public Shared Function GetExtensionDescription(keyData As String) As String
        Dim key As Microsoft.Win32.RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey(keyData, False)
        If key IsNot Nothing AndAlso key.ValueCount > 0 AndAlso key.GetValue("") IsNot Nothing Then
            keyData = key.GetValue("").ToString
            key.Close()
        End If

        Return keyData
    End Function

    Public Sub RemoveAt(index As Integer) Implements IList(Of SearchItem).RemoveAt
        mCol.RemoveAt(index)
    End Sub

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return mCol.GetEnumerator
    End Function
End Class

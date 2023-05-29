namespace MainBot
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security.Principal;

    internal class InfoHelper
    {
        public static string GetHWID()
        {
            IntPtr ptr = Marshal.AllocHGlobal(0xff);
            GetVolumeNameForVolumeMountPoint(Environment.GetEnvironmentVariable(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_40()) + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_9(), ptr, 0xff);
            string str = Marshal.PtrToStringUni(ptr);
            str = str.Substring(str.IndexOf('{'));
            return str.Substring(0, str.IndexOf('}') + 1).Trim();
        }

        public static string GetOS()
        {
            OperatingSystem oSVersion = Environment.OSVersion;
            string str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_41();
            if (oSVersion.Platform == PlatformID.Win32Windows)
            {
                int minor = oSVersion.Version.Minor;
                switch (minor)
                {
                    case 0:
                        str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_42();
                        goto Label_0118;

                    case 10:
                        if (oSVersion.Version.Revision.ToString() == <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_43())
                        {
                            str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_44();
                        }
                        else
                        {
                            str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.PD();
                        }
                        goto Label_0118;
                }
                if (minor == 90)
                {
                    str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_45();
                }
            }
            else if (oSVersion.Platform == PlatformID.Win32NT)
            {
                switch (oSVersion.Version.Major)
                {
                    case 3:
                        str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_46();
                        goto Label_0118;

                    case 4:
                        str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_47();
                        goto Label_0118;

                    case 5:
                        if (oSVersion.Version.Minor != 0)
                        {
                            str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_49();
                        }
                        else
                        {
                            str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_48();
                        }
                        goto Label_0118;

                    case 6:
                        switch (oSVersion.Version.Minor)
                        {
                            case 0:
                                str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_50();
                                goto Label_0118;

                            case 1:
                                str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_51();
                                goto Label_0118;

                            case 2:
                                str = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_52();
                                goto Label_0118;
                        }
                        goto Label_0118;
                }
            }
        Label_0118:
            return (str + (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_53())) ? <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_55() : <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_54()));
        }

        [DllImport("kernel32", CharSet=CharSet.Unicode)]
        private static extern bool GetVolumeNameForVolumeMountPoint(string string_0, IntPtr intptr_0, uint uint_0);
        public static bool IsAdmin()
        {
            try
            {
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }
    }
}


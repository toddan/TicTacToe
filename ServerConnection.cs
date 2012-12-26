using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class ServerConnection
    {
        private TcpClient tcpClient;
        private Stream ClientStream;
        private StreamReader ClientStreamReader;
        private StreamWriter ClientStreamWriter;

        private static ServerConnection instance;

        private string ServerIp;
        private int ServerPort;

        public string LocalIpAddress
        {
            get
            {
                return tcpClient.Client.LocalEndPoint.ToString();
            }
        }

        /// <summary>
        /// Singelton object instance. 
        /// We want the connection to be static so we do not
        /// make a new connection everytime we send a package. 
        /// </summary>
        public static ServerConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception("There is no connection");
                }
                return instance;
            }
        }

        public ServerConnection(string serverip, int serverport)
        {
            ServerIp = serverip;
            ServerPort = serverport;
            instance = this;
        }

        public void Connect()
        {
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse(ServerIp), ServerPort);
            }
            catch (Exception E)
            {
                Console.WriteLine("Connect: " + E.Message);
            }
        }

        public void DisConnect()
        {
            tcpClient.Close();
        }

        public string GetServerResponse()
        {
            ClientStream = tcpClient.GetStream();
            ClientStreamReader = new StreamReader(ClientStream);
            return ClientStreamReader.ReadLine();
        }

        public void SendPackageToServer(Package PackageToServer)
        {
            try
            {
                ClientStream = tcpClient.GetStream();
                ClientStreamWriter = new StreamWriter(ClientStream);
                ClientStreamWriter.AutoFlush = true;
                ClientStreamWriter.WriteLine(PacketParser.MakePackageString(PackageToServer));
            }
            catch (Exception e)
            {
                Console.WriteLine("send package: " + e.Message);
            }
        }
    }
}

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
    class Networking
    {
        private TcpClient tcpClient;
        private Stream ClientStream;
        private StreamReader ClientStreamReader;
        private StreamWriter ClientStreamWriter;

        public Networking(string ip, int port)
        {
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse(ip), port);
                MessageBox.Show("Connected to server" + ip +":"+port.ToString());
                Thread ListenOnServerThread = new Thread(new ThreadStart(InCommingTasks));
                ListenOnServerThread.Start();
                SendTaskToServer(new Package("login","client","server","None"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SendTaskToServer(Package CommandToServer)
        {
            try
            {
                ClientStream = tcpClient.GetStream();
                ClientStreamWriter = new StreamWriter(ClientStream);
                ClientStreamWriter.AutoFlush = true;
                ClientStreamWriter.WriteLine(Protocol.MakePackageString(CommandToServer));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public string GetServerResponse()
        {
            ClientStream = tcpClient.GetStream();
            ClientStreamReader = new StreamReader(ClientStream);
            return ClientStreamReader.ReadLine();
        }

        public void InCommingTasks()
        {
            for (; ; )
            {
                Package InCommingPackage = Protocol.ParsePackageString(GetServerResponse());
                if (InCommingPackage.Type == "userlist")
                {
                    GetLoggedInPlayers(InCommingPackage);
                }
            }
        }

        private void GetLoggedInPlayers(Package LoginResponse)
        {
            MessageBox.Show(LoginResponse.Data);
            string[] UserList = LoginResponse.Data.Split(';');
            ServerConnectForm.ListBox1ref.DataSource = UserList;
            ServerConnectForm.ListBox1ref.Refresh();
        }
    }
}

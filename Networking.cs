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

        private static Networking instance;

        private string[] UserList;

        public static Networking Instance
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
            instance = this;
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
            try
            {
                for (;;)
                {
                    Package InCommingPackage = Protocol.ParsePackageString(GetServerResponse());
                    MessageBox.Show("client: " + Protocol.MakePackageString(InCommingPackage));

                    if (InCommingPackage.Type == "userlist")
                    {
                        GetLoggedInPlayers(InCommingPackage);
                    }

                    if (InCommingPackage.Type == "newgame")
                    {
                        GUIUpdates.ShowGamePlan(InCommingPackage);
                    }

                    if (InCommingPackage.Type == "gamepattern")
                    {
                        GUIUpdates.UpdateGameAreaForm(InCommingPackage);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void StartGameWithOpponent(int opponent,string UserName)
        {
            Package StartGame = new Package();
            StartGame.Type = "newgame";
            StartGame.To = UserList[opponent];
            StartGame.From = tcpClient.Client.LocalEndPoint.ToString();
            StartGame.Data = UserName;
            SendTaskToServer(StartGame);
        }

        public void StartGameWithSelf()
        {
            Package StartGame = new Package();
            StartGame.Type = "newgame";
            StartGame.To = tcpClient.Client.LocalEndPoint.ToString();
            StartGame.From = tcpClient.Client.LocalEndPoint.ToString();
            StartGame.Data = "None";
            SendTaskToServer(StartGame);
        }

        public void SendGamePatternToOpponent(string opponentIp)
        {
            Package GamePattern = new Package();
            GamePattern.Type = "gamepattern";
            GamePattern.To = opponentIp;
            GamePattern.From = tcpClient.Client.LocalEndPoint.ToString();
            GamePattern.Data = Gameplan.gameArea;
            SendTaskToServer(GamePattern);
        }

        private void GetLoggedInPlayers(Package LoginResponse)
        {
            UserList = LoginResponse.Data.Split(';');
            for (int i = 0; i < UserList.Length;i++ )
            {
                if (UserList[i] == tcpClient.Client.LocalEndPoint.ToString())
                {
                    UserList[i] += " YOU";
                }
            }

            GUIUpdates.UpdateUserListListBox(UserList);
        }
    }
}

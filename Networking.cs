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
        private ServerConnection Connection;

        public Networking(ServerConnection Conn)
        {
            Connection = Conn;
        }

        public void LoginToServer()
        {
            Connection.Connect();
            Thread ListenToServer = new Thread(new ThreadStart(InCommingPackages));
            ListenToServer.IsBackground = true;
            ListenToServer.Start();
            Connection.SendPackageToServer(new Package("login", "client", "server", "None"));
        }

        public void LogoutFromServer()
        {
            Connection.DisConnect();
        }

        /// <summary>
        /// Handles the incomming packages. 
        /// Updates the gui depending on the command sent by the server
        /// </summary>
        public void InCommingPackages()
        {
            try
            {
                for( ; ; )
                {
                    Package InCommingPackage = PacketParser.ParsePackageString(Connection.GetServerResponse());
                    Console.WriteLine("client " + PacketParser.MakePackageString(InCommingPackage));

                    if (InCommingPackage.Type == "userlist")
                    {
                        GUIUpdates.UpdateUserListListBox(InCommingPackage, Connection.LocalIpAddress);
                    }

                    if (InCommingPackage.Type == "newgame")
                    {
                        Console.WriteLine("new game: " + PacketParser.MakePackageString(InCommingPackage));
                        GUIUpdates.ShowGamePlan(InCommingPackage);
                    }

                    if (InCommingPackage.Type == "gamepattern")
                    {
                        Console.WriteLine("game pattern: " + InCommingPackage.Data);
                        GUIUpdates.UpdateGameAreaForm(InCommingPackage);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("in comming package: " + e.Message);
            }
        }

        public void StartGameWithOpponent(string opponent,string UserName)
        {
            Package StartGamePackage = new Package("newgame", Connection.LocalIpAddress,
                opponent,UserName);
            Connection.SendPackageToServer(StartGamePackage);
        }

        /// <summary>
        /// When the user starts a new game with an opponent.
        /// We have to send a new game command to the user so that his gameplan 
        /// gets started too. 
        /// </summary>
        /// <param name="opponent">Ip of the opponent</param>
        public void StartGameWithSelf(string opponent)
        {
            Package StartGameWithSelfPackage = new Package("newgame", opponent, 
                Connection.LocalIpAddress,"None");
            Connection.SendPackageToServer(StartGameWithSelfPackage);
        }

        public void SendGamePatternToOpponent(string opponentIp,string num)
        {
            Package GamePattern = new Package("gamepattern",Connection.LocalIpAddress,
                opponentIp,num);
            Connection.SendPackageToServer(GamePattern);
        }
    }
}

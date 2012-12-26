using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    /// <summary>
    /// TicTacToe
    /// Tord Munk
    /// 
    /// ABOUT
    ///     This is a multiplayer tictactoe implementation.
    ///     Some things are not implemented and there are a few bugs.
    ///     But Game play is working.
    ///LICENSE:
    ///     Gpl3
    ///     
    /// </summary>
    public partial class ServerConnectForm : Form
    {
        public static ListBox ListBox1ref = null;
        public static ServerConnectForm ServerConnectFormref = null;

        public static string[] userlist;

        private Networking ClientNetworking;

        public ServerConnectForm()
        {
            InitializeComponent();
            ListBox1ref = listBox1;
            ServerConnectFormref = this;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // make a new connection to the server
            ClientNetworking = new Networking(
                new ServerConnection(textBoxServerIp.Text,
                    Convert.ToInt32(textBoxServerPort.Text)));
            // login to the game server
            ClientNetworking.LoginToServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxUserName.Text == "")
                {
                    MessageBox.Show("You must enter a username to paly");
                }
                else
                {
                    if (userlist[listBox1.SelectedIndex].Split(' ').Contains("YOU"))
                    {
                        MessageBox.Show("you can not start a game with your self");
                    }
                    else
                    {
                        ClientNetworking.StartGameWithOpponent(userlist[listBox1.SelectedIndex],
                            textBoxUserName.Text);
                        ClientNetworking.StartGameWithSelf(userlist[listBox1.SelectedIndex]);
                    }
                }

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}

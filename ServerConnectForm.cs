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
    public partial class ServerConnectForm : Form
    {
        public static ListBox ListBox1ref = null;
        public static ServerConnectForm ServerConnectFormref = null;

        private Networking ClientNetworking;

        public ServerConnectForm()
        {
            InitializeComponent();
            ListBox1ref = listBox1;
            ServerConnectFormref = this;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ClientNetworking = new Networking("127.0.0.1", 8888);
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
                    ClientNetworking.StartGameWithOpponent(listBox1.SelectedIndex, textBoxUserName.Text);
                    ClientNetworking.StartGameWithSelf();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("you need to choose a player to play");
            }
        }
    }
}

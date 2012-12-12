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

        private Networking ClientNetworking;

        public ServerConnectForm()
        {
            InitializeComponent();
            ListBox1ref = listBox1;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ClientNetworking = new Networking("127.0.0.1", 8888);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gamearea gameare = new Gamearea();
            gameare.Show();
        }
    }
}

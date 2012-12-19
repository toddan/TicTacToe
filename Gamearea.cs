using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Gamearea : Form
    {
        Networking ClinetNetworking = new Networking(ServerConnection.Instance);

        public static bool turn = true;

        /// <summary>
        /// Static reference to the gameare winform
        /// </summary>
        public static Gamearea GameAreaFormref;

        /// <summary>
        /// Static references to all the game buttons on the form.
        /// This way we can invoke them in the GUIUpdates class
        /// </summary>
        public static Button button1ref;
        public static Button button2ref;
        public static Button button3ref;
        public static Button button4ref;
        public static Button button5ref;
        public static Button button6ref;
        public static Button button7ref;
        public static Button button8ref;
        public static Button button9ref;

        public string OpponentIp{get;set;}

        public Gamearea(string OpponentName)
        {
            InitializeComponent();
            GameAreaFormref = this;
            button1ref = button1;
            button2ref = button2;
            button3ref = button3;
            button4ref = button4;
            button5ref = button5;
            button6ref = button6;
            button7ref = button7;
            button8ref = button8;
            button9ref = button9;
            label2.Text = OpponentName;
        }
        private void SendPattern(string num)
        {
            try
            {
                ClinetNetworking.SendGamePatternToOpponent(OpponentIp, num);
            }
            catch (Exception E)
            {
                Console.WriteLine("Send pattern " + E.Message);
            }
        }

        /// <summary>
        /// Sets a mark on clicked button.
        /// Then send that number to the opponent. 
        /// </summary>
        /// <param name="x">x game area coordinate</param>
        /// <param name="y">y game area coordinate</param>
        /// <param name="buttonNum"></param>
        private void SetMarker(int x, int y,string buttonNum)
        {
            Gameplan.area[x, y] = true;
            SendPattern(buttonNum);
            Gameplan.checkWin();
            if (Gameplan.win == true)
            {
                SendPattern("0");
                // make the game area "new" when a game is won.
                Gameplan.area = new bool[3, 3];
                Gameplan.win = false;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button1.Text = "X";
                SetMarker(0, 0, "1");
                turn = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button2.Text = "X";
                SetMarker(0, 1, "2");
                turn = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button3.Text = "X";
                SetMarker(0, 2, "3");
                turn = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button4.Text = "X";
                SetMarker(1, 0, "4");
                turn = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button5.Text = "X";
                SetMarker(1, 1, "5");
                turn = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button6.Text = "X"; 
                SetMarker(1, 2, "6");
                turn = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button7.Text = "X";
                SetMarker(2, 0, "7");
                turn = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button8.Text = "X";
                SetMarker(2, 1, "8");
                turn = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                button9.Text = "X";
                SetMarker(2, 2, "9");
                turn = false;
            }
        }
    }
}

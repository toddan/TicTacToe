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
        public static Gamearea GameAreaFormref;

        public static Button button1ref;

        public string OpponentIp{get;set;}

        public Gamearea(string OpponentName)
        {
            InitializeComponent();
            GameAreaFormref = this;
            button1ref = button1;
            label2.Text = OpponentName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "X";
            try
            {
                Networking.Instance.SendGamePatternToOpponent(OpponentIp);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            Gameplan.checkWin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "X";
            Gameplan.gameArea += "2";
            Gameplan.checkWin();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "X";
            Gameplan.gameArea += "3";
            Gameplan.checkWin();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = "X";
            Gameplan.gameArea += "4";
            Gameplan.checkWin();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = "X";
            Gameplan.gameArea += "5";
            Gameplan.checkWin();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = "X";
            Gameplan.gameArea += "6";
            Gameplan.checkWin();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = "X";
            Gameplan.gameArea += "7";
            Gameplan.checkWin();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Text = "X";
            Gameplan.gameArea += "8";
            Gameplan.checkWin();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Text = "X";
            Gameplan.gameArea += "9";
            Gameplan.checkWin();
        }
    }
}

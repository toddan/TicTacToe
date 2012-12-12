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
        Gameplan myGameplan = new Gameplan();

        public Gamearea()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "1";
            myGameplan.checkWin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "2";
            myGameplan.checkWin();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "3";
            myGameplan.checkWin();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "4";
            myGameplan.checkWin();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "5";
            myGameplan.checkWin();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "6";
            myGameplan.checkWin();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "7";
            myGameplan.checkWin();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "8";
            myGameplan.checkWin();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            myGameplan.gameArea += "9";
            myGameplan.checkWin();
        }
    }
}

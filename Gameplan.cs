using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class Gameplan
    {
        public string gameArea { get; set; }

        public void checkWin()
        {
            string[] winnerPatterns = new string[] {"123","456","789",
                                                    "147","258","369",
                                                    "159","357",};

            foreach (string pattern in winnerPatterns)
            {
                if (gameArea == pattern || gameArea == reverse(pattern))
                {
                    MessageBox.Show("WIN");
                }
            }
        }

        private string reverse(string input)
        {
            char[] inputarray = input.ToCharArray();
            Array.Reverse(inputarray);
            return new string(inputarray);
        }
    }
}

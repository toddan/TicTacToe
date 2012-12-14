using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    static class Gameplan
    {
        public static string gameArea;

        public static void checkWin()
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

        private static string reverse(string input)
        {
            char[] inputarray = input.ToCharArray();
            Array.Reverse(inputarray);
            return new string(inputarray);
        }
    }
}

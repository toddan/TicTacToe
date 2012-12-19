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
        // static game state
        public static bool[,] area = new bool[3,3];
        public static bool win = false;

        /// <summary>
        /// Algorithm to calculate who is the winner.
        /// 
        /// We look thru each coordinate and then count three steps forward.
        /// If there is three boolean true in a coordinate the player has won. 
        /// </summary>
        public static void checkWin()
        {
            for (int i = 0; i < 3; i++)
            {
                // if the player has won. Break the loop and tell the victory to the player. 
                if (win == true)
                {
                    MessageBox.Show("WIN");
                    break;
                }

                for (int j = 0; j < 3; j++)
                {

                    if (area[i, j])// if a coordinate is true start to count neighbours. 
                    {
                        // check horisontal 
                        for (int x = 0; x < 3; x++)
                        {
                            // if there is not three trues from the coordinate. Break the loop.
                            if (area[i, x] != true)
                                break;
                            // If there is three trues in the game area starting from 0 to 2, make the player a winner. 
                            if (x == 2)
                            {
                                win = true;
                            }
                        }

                        // check vertical
                        for (int x = 0; x < 3; x++)
                        {
                            if (area[x,j] != true)
                                break;
                            if (x == 2)
                            {
                                win = true;
                            }
                        }

                        // check diagonal
                        if (i == j)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                if (area[x, x] != true)
                                    break;
                                if (x == 2)
                                {
                                    win = true;
                                }
                            }
                        }
                        // check opposite diagonal
                        for (int x = 0; x < 3; x++)
                        {
                            if (area[x, 2 - x] != true)
                                break;
                            if (x == 2)
                            {
                                win = true;
                            }
                        }
                    }
                }
            }
        }
    }
}

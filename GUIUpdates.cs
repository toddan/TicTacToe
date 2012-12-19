using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    /// <summary>
    /// Static class that handles Invokes on the winforms events. 
    /// So we can update the winform gui. Outside its event loop. 
    /// </summary>
    static class GUIUpdates
    {
        public static void ShowGamePlan(Package InCommingPackage)
        {
            ServerConnectForm.ServerConnectFormref.BeginInvoke(new Action(delegate()
            {
                Gamearea ga = new Gamearea(InCommingPackage.Data);
                ga.OpponentIp = InCommingPackage.From;
                ga.Show();
            }));
        }

        public static void UpdateUserListListBox(Package InCommingPackage,string LocalIpAddress)
        {
            ServerConnectForm.ListBox1ref.BeginInvoke(new Action(delegate()
            {
                ServerConnectForm.userlist = InCommingPackage.Data.Split(';');
                for (int i = 0; i < ServerConnectForm.userlist.Length; i++)
                {
                    if (ServerConnectForm.userlist[i] == LocalIpAddress)
                    {
                        ServerConnectForm.userlist[i] += " YOU";
                    }
                }
                ServerConnectForm.ListBox1ref.DataSource = ServerConnectForm.userlist;
            }));
        }

        public static void UpdateGameAreaForm(Package InCommingPackage)
        {
            Gamearea.GameAreaFormref.BeginInvoke(new Action(delegate()
            {
                // place an O where the opponent put his X
                switch (InCommingPackage.Data[InCommingPackage.Data.Length - 1])
                {
                    case '1':
                        Gamearea.button1ref.Text = "O";
                        break;
                    case '2':
                        Gamearea.button2ref.Text = "O";
                        break;
                    case '3':
                        Gamearea.button3ref.Text = "O";
                        break;
                    case '4':
                        Gamearea.button4ref.Text = "O";
                        break;
                    case '5':
                        Gamearea.button5ref.Text = "O";
                        break;
                    case '6':
                        Gamearea.button6ref.Text = "O";
                        break;
                    case '7':
                        Gamearea.button7ref.Text = "O";
                        break;
                    case '8':
                        Gamearea.button8ref.Text = "O";
                        break;
                    case '9':
                        Gamearea.button9ref.Text = "O";
                        break;
                    case '0':
                        MessageBox.Show("LOOSE");
                        Gamearea.GameAreaFormref.Close();
                        break;
                }
                // Make the player able to play when he recived a O from his opponent. 
                Gamearea.turn = true;
            }));
        }
    }
}

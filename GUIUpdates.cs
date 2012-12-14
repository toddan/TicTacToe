using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class GUIUpdates
    {
        public static void ShowGamePlan(Package InCommingPackage)
        {
            ServerConnectForm.ServerConnectFormref.BeginInvoke(new Action(delegate()
            {
                Gamearea ga = new Gamearea(InCommingPackage.Data);
                ga.Show();
            }));
        }

        public static void UpdateUserListListBox(string[] UserList)
        {
            ServerConnectForm.ListBox1ref.BeginInvoke(new Action(delegate()
            {
                ServerConnectForm.ListBox1ref.DataSource = UserList;
            }));
        }

        public static void UpdateGameAreaForm(Package InCommingPackage)
        {
            Gamearea.GameAreaFormref.BeginInvoke(new Action(delegate()
            {
                Gameplan.gameArea += InCommingPackage.Data;
                Gamearea.button1ref.Text = "O";
            }));
        }
    }
}

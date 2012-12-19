using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class PacketParser
    {
        public static string MakePackageString(Package package)
        {
            string CommandString = "";
            CommandString += "<type>" + package.Type + "</type>";
            CommandString += "<to>" + package.To + "</to>";
            CommandString += "<from>" + package.From + "</from>";
            CommandString += "<data>" + package.Data + "</data>";
            return CommandString;
        }

        public static Package ParsePackageString(string CommandString)
        {
            Package myPackage = new Package();

            char[] paths = {'<','>'};
            string[] commands = CommandString.Split(paths);

            for(int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "type")
                {
                    myPackage.Type = commands[i + 1];
                }
                if (commands[i] == "to")
                {
                    myPackage.To = commands[i + 1];
                }
                if (commands[i] == "from")
                {
                    myPackage.From = commands[i + 1];
                }
                if (commands[i] == "data")
                {
                    myPackage.Data = commands[i + 1];
                }
            }

            return myPackage;
        }
    }
}

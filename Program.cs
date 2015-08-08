using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Eksamensopgaven_2015
{
    class Program
    {
        static void Main(string[] args)
        {
            LineSystem lineSystem = new LineSystem();    
            LineSystemCLI CLI = new LineSystemCLI(lineSystem);
            LineSystemCommandParser cmdParser = new LineSystemCommandParser(CLI, lineSystem);

            //2 hardcodede brugere. en med masser af penge og en med under advarselsgrænsen på 50 kr.
            User u = new User("Mathias", "Leding", "mledin14", "mledin14@student.aau.dk");
            User u1 = new User("Lars", "Larsen", "llarse14", "LLarse14@student.aau.dk");
            u.balance = 100;
            u1.balance = 49;
            lineSystem.userList.Add(u);
            lineSystem.userList.Add(u1);

            CLI.RunProgram(cmdParser);            
        }
    }
}

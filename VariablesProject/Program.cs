using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string RealName;
            string GamerTag;
            RealName = "Koal Casler";
            GamerTag = "TheeOBLIVION";
            // Score Total
            int TotalScore;
            //Score Multiplier  
            int ScoreMulti;
            // Base increase in score.
            int BaseScore;
            float Standings;
            float Standing;
            float TotalPlayers;
            ScoreMulti = 2;
            BaseScore = 5;
            Standing = 10f;
            TotalPlayers = 153472f;
            Standings = (Standing / TotalPlayers) * 100;
            TotalScore = ScoreMulti * BaseScore;
            Console.WriteLine("Variables");
            Console.WriteLine("---------");
            Console.WriteLine(RealName + " has the Gamer Tag of : " + GamerTag);
            Console.WriteLine();
            Console.WriteLine("Your Score = " + TotalScore);
            Console.WriteLine("Your Standings are in the top : " + Standings + "% of all players");
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
        }
    }
}

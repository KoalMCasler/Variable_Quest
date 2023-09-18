using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesProject
{
    internal class Program
    {
            string RealName;
            string GamerTag;
            RealName = "Koal Casler";
            StudioName = "Shrouded Fortress Entertainment";
            // Score Total
            int TotalScore;
            //Score Multiplier  
            int ScoreMulti;
            // Base increase in score.
            int BaseScore;
            int MaxHp;
            int CurrentHP;
            int PlayerDam;
            int EnemyDam;
            int EnemyHp;
        static void Main(string[] args)
        {
            Startup();
            Console.WriteLine("Variable Quest!");
            Console.WriteLine("By: " + RealName + " Of, " StudioName);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your Score = " + TotalScore);
            Console.WriteLine("Your Hp = " + CurrentHP);
            Console.WriteLine("Press any key to Continue.");
            Console.ReadKey();
        }
        void Startup()
        {
            EnemyHp = 15;
            MaxHp = 20;
            CurrentHP = MaxHp;
            PlayerDam = 5;
            EnemyDam = 2;
            ScoreMulti = 2;
            BaseScore = 5;
            Standing = 10f;
            TotalPlayers = 153472f;
            Standings = (Standing / TotalPlayers) * 100;
            TotalScore = ScoreMulti * BaseScore;
        }
    }
}

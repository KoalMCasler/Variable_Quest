using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesProject
{
    internal class Program
    {
            static string RealName;
            static string StudioName;
            // Score Total
            static int TotalScore;
            //Score Multiplier  
            static int ScoreMulti;
            // Base increase in score.
            static int BaseScore;
            static int MaxHp;
            static int CurrentHP;
            static int PlayerDam;
            static int EnemyDam;
            static int EnemyHp;
            static int EnemyMaxHp;
            static int PlayerLives;
            static int KillCount;
            static bool GameIsOver;
            static string EnemyName;
            static List<string> EnemyList;
            static int ListIndex;

        static void Main()
        {
            Startup();
            Console.WriteLine("Variable Quest!");
            Credit(RealName,StudioName);
            Console.WriteLine("*************************");
            Console.WriteLine();
            HUD();
            Console.WriteLine("Press any key to Continue.");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
            Encounter();
            while (CurrentHP > 0)
                {
                    Console.WriteLine("\nPress any Key to attack!");
                    Console.ReadKey();
                    Combat();
                    HUD();
                    if (CurrentHP <= 0)
                    {
                        Death();
                        if (PlayerLives <= 0)
                        {
                            GameLose();
                        }
                    }
                    if (KillCount >= 5)
                    {
                        GameWin();
                    }
                    if (GameIsOver == true)
                    {
                        Environment.Exit(0);
                    }
                    Console.WriteLine("\nPress E to Heal back to full HP.\n");
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        Heal();
                        HUD();
                    }
                }
        }
        static void Startup()
        {
            PlayerLives = 3;
            EnemyMaxHp = 15;
            EnemyHp = EnemyMaxHp;
            MaxHp = 20;
            CurrentHP = MaxHp;
            PlayerDam = 5;
            EnemyDam = 2;
            ScoreMulti = 2;
            BaseScore = 100;
            RealName = "Koal Casler";
            StudioName = "Shrouded Fortress Entertainment";
            GameIsOver = false;
            Random rnd = new Random();
            EnemyList = new List<string>{" Float", " Int"," Bool"};
        }
        static void Combat()
        {
            CurrentHP -=  EnemyDam;
            EnemyHp -=  PlayerDam;
            Console.WriteLine("The Enemy" + EnemyName + " has " + EnemyHp + "HP left.");
            Console.WriteLine("\n");
            if (EnemyHp <= 0)
            {
                Console.WriteLine("You killed the enemy" + EnemyName + "!");
                EnemyHp = EnemyMaxHp;
                ScoreCalc();
                KillCount += 1;
                Encounter();
            }
            
        }
        static void HUD()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Your Score = " + TotalScore);
            Console.WriteLine("Your Hp = " + CurrentHP);
            Console.WriteLine("Your Lives = " + PlayerLives);
            Console.WriteLine("Your Kills = " + KillCount);
            Console.WriteLine("**********");
            Console.WriteLine("\n");
        }
        static void ScoreCalc()
        {
            TotalScore += ScoreMulti * BaseScore;
        }
        static void GameEnd()
        {
            GameIsOver = true;
        }
        static void Death()
        {
            PlayerLives -= 1;
            Console.WriteLine("You Died!");
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
            Heal();
        }
        static void Encounter()
        {
            EnemyRandomizer();
            Console.WriteLine("You encounter a wild" + EnemyName + "!");
            Console.WriteLine("The enemy" + EnemyName + " has " + EnemyHp + " Total HP!");
        }
        static void GameWin()
        {
            HUD();
            Credit(RealName,StudioName);
            Console.WriteLine("You Win!");
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
            GameEnd();
        }
        static void GameLose()
        {
            Console.WriteLine("You Lose!");
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
            GameEnd();
        }
        static void Heal()
        {
            CurrentHP = MaxHp;
        }
        static void Credit(string PName, string SName)
        {
            Console.WriteLine("By: " + PName + " Of " + SName);
        }
        static void EnemyRandomizer()
        {
            Random rnd = new Random();
            ListIndex = rnd.Next(3);
            EnemyName = EnemyList.ElementAt(ListIndex);
        }

    }
}

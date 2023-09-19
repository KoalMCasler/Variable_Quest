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
                    Console.WriteLine("Press any Key to attack!");
                    Console.ReadKey();
                    Combat();
                    HUD();
                    if (CurrentHP <= 0)
                    {
                        Death();
                        if (PlayerLives > 0)
                        {
                            GameLose();
                        }
                    }
                    if (KillCount > 2)
                    {
                        GameWin();
                    }
                    if (GameIsOver == true)
                    {
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Press E to Heal back to full HP.");
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
        }
        static void Combat()
        {
            CurrentHP = CurrentHP - EnemyDam;
            EnemyHp = EnemyHp - PlayerDam;
            Console.WriteLine("The Enemy has " + EnemyHp + "HP left.");
            if (EnemyHp <= 0)
            {
                Console.WriteLine("You killed the enemy!");
                EnemyHp = EnemyMaxHp;
                ScoreCalc();
                KillCount += 1;
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
            HUD();
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
            CurrentHP = MaxHp;
        }
        static void Encounter()
        {
            Console.WriteLine("You encounter a wild Float!");
            Console.WriteLine("The enemy Float has " + EnemyHp + " Total HP!");
        }
        static void GameWin()
        {
            Console.WriteLine("You Win!");
            HUD();
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
            Console.WriteLine();
            GameEnd();
        }
        static void GameLose()
        {
            Console.WriteLine("You Lose!");
            HUD();
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
            Console.WriteLine();
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
    }
}

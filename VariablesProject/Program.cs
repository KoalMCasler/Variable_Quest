using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesProject
{
    internal class Program
    {
            // My name
            static string RealName;
            // Name of my studio
            static string StudioName;
            // Score Total
            static int TotalScore;
            //Score Multiplier  
            static int ScoreMulti;
            // Base increase in score.
            static int BaseScore;
            // Max Hit points. 
            static int MaxHp;
            // Current HP
            static int CurrentHP;
            // Player base damage
            static int PlayerDam;
            // Enemy base damage
            static int EnemyDam;
            // Enemy Current HP
            static int EnemyHp;
            // Enemy max hp
            static int EnemyMaxHp;
            // Player lives 
            static int PlayerLives;
            // Player kill count
            static int KillCount;
            // Game over trigger bool
            static bool GameIsOver;
            // Name of enemy pulled from list
            static string EnemyName;
            // List of Enemy names
            static List<string> EnemyList;
            // Index for enemy list to pull one at random.
            static int ListIndex;
            // Fancy line breaks
            static string StarLine;
            static List<string> WeaponList;
            static int WLIndex;

        static void Main()
        {
            // Game startup 
            Startup();
            Console.WriteLine("Variable Quest!");
            Credit(RealName,StudioName);
            Console.WriteLine(StarLine);
            Console.WriteLine();
            HUD();
            Console.WriteLine("Get 5 kills to win!");
            Console.WriteLine("Press any key to get started!");
            Console.WriteLine();
            Console.WriteLine();
            Encounter();
            // Main game play loop 
            while (CurrentHP > 0)
                {
                    // Ability to leave game.
                    if (Console.ReadKey().Key == ConsoleKey.Backspace)
                    {
                        GameEnd();
                    }
                    Console.WriteLine("\nPress any Key to attack!");
                    Combat();
                    HUD();
                    Console.ReadKey();
                    // Player death trigger
                    if (CurrentHP <= 0)
                    {
                        Death();
                        if (PlayerLives <= 0)
                        {
                            GameLose();
                        }
                    }
                    // Win condition
                    if (KillCount >= 5)
                    {
                        GameWin();
                    }
                    // Game ender
                    if (GameIsOver == true)
                    {
                        Environment.Exit(0);
                    }
                    // heal ability
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
            // The instillation 
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
            EnemyList = new List<string>{" Float", " Int"," Bool"};
            StarLine = "**************************************************************************";
            WeaponRandomizer();
        }
        static void Combat()
        {
            // Combat function
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
            // prints the "HUD"
            Console.WriteLine(StarLine);
            Console.WriteLine("Your Score = " + TotalScore);
            Console.WriteLine("Your Hp = " + CurrentHP);
            Console.WriteLine("Your Lives = " + PlayerLives);
            Console.WriteLine("Your Kills = " + KillCount);
            Console.WriteLine(StarLine);
            Console.WriteLine("\n");
        }
        static void ScoreCalc()
        {
            // Calculates score
            TotalScore += ScoreMulti * BaseScore;
        }
        static void GameEnd()
        {
            // Sets game end bool to true and shuts off program
            GameIsOver = true;
        }
        static void Death()
        {
            // lowers player lives, and lets you try again. 
            PlayerLives -= 1;
            Console.WriteLine("You Died!");
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
            Heal();
        }
        static void Encounter()
        {
            // Selects a random enemy name
            EnemyRandomizer();
            Console.WriteLine("You encounter a wild" + EnemyName + "!");
            Console.WriteLine("The enemy" + EnemyName + " has " + EnemyHp + " Total HP!");
        }
        static void GameWin()
        {
            // Displays win text and credits when game is won!
            HUD();
            Console.WriteLine("You Win!");
            Console.WriteLine("Press any key to Exit");
            Credit(RealName,StudioName);
            Console.ReadKey();
            GameEnd();
        }
        static void GameLose()
        {
            // Displays lose text and ends game.
            Console.WriteLine("You Lose!");
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
            GameEnd();
        }
        static void Heal()
        {
            // heals player to max HP
            CurrentHP = MaxHp;
        }
        static void Credit(string PName, string SName)
        {
            // Writes Credit String
            Console.WriteLine("By: " + PName + " Of " + SName);
        }
        static void EnemyRandomizer()
        {
            // Pulls random enemy from list of enemies
            Random rnd = new Random();
            ListIndex = rnd.Next(3);
            EnemyName = EnemyList.ElementAt(ListIndex);
        }
        static void WeaponRandomizer()
        {
            Random rnd = new Random();
            WLIndex = rnd.Next(5);
            WeaponName = WeaponList.ElementAt(WLIndex);
        }

    }
}

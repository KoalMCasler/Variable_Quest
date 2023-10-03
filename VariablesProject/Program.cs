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
            static int ELIndex;
            // Fancy line breaks
            static string StarLine;
            static List<string> WeaponList;
            static int WLIndex;
            static string WeaponName;
            static int BaseShield;
            static int CurrentShield;
            

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
            Console.WriteLine("Press Space to get started!");
            Console.WriteLine("Press Backspace at any time to close.");
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
                    Console.WriteLine("\nPress F to change weapons.\n");
                    if (Console.ReadKey().Key == ConsoleKey.F)
                    {
                        WeaponRandomizer();
                        HUD();
                    }
                    Console.WriteLine("\nPress T to restart the game.\n");
                    if (Console.ReadKey().Key == ConsoleKey.T)
                    {
                        Startup();
                        HUD();
                    }
                }
        }
        static void Startup()
        {
            // The instillation
            Stats();
            CurrentShield = BaseShield;
            CurrentHP = MaxHp;
            RealName = "Koal Casler";
            StudioName = "Shrouded Fortress Entertainment";
            GameIsOver = false;
            EnemyList = new List<string>{" Float", " Int"," Bool"};
            WeaponList = new List<string> { " Stick", " Dagger", " Short Sword", " Long Sword", " Great Sword" };
            StarLine = "**************************************************************************";
            WeaponRandomizer();
        }
        static void Stats()
        {
            //            v Change These to test Code!
            BaseShield = 100;
            TotalScore = 0;
            PlayerLives = 3;
            EnemyMaxHp = 100;
            MaxHp = 100;
            PlayerDam = 10; // Multiplied by Weapon index to give the true damage. 
            EnemyDam = 10; // Multiplied by index to increase damage based on what enemy you fight. 
            ScoreMulti = 2;
            BaseScore = 100;
            //            ^ Change these to test Code!
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
            Console.WriteLine("Your Shield = " + CurrentShield);
            Console.WriteLine("Your Lives = " + PlayerLives);
            Console.WriteLine("Your Kills = " + KillCount);
            Console.WriteLine("You have a" + WeaponName);
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
            Heal(MaxHp);
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
        static void Heal(int HP)
        {
            // heals player to the HP used in heal function.
            CurrentHP = HP;
        }
        static void ChangeWeapon()
        {
            WeaponRandomizer();
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
            ELIndex = rnd.Next(3);
            EnemyName = EnemyList.ElementAt(ELIndex);
            EnemyHp = EnemyMaxHp - ((ELIndex+1)*10);
        }
        static void WeaponRandomizer()
        {
            Random rnd = new Random();
            WLIndex = rnd.Next(5);
            WeaponName = WeaponList.ElementAt(WLIndex);
        }
        static void RefillShield(int Shield)
        {
            CurrentShield = Shield;
        }
        static void TakeDamage(int Damage)
        {
            int DamageDeduction;
            Damage = EnemyDam * (ELIndex + 1);
            if (Damage <= 0)
            {
                Console.WriteLine("Damage Cannot Be 0 or less.");
                return;
            }
            else
            {
                if(CurrentShield > 0)
                {
                    DamageDeduction = CurrentShield - Damage
                }
                //CurrentHP -= Damage;
            }
        }
        static void DoDamage(int Damage)
        {
            if (Damage <= 0)
            {
                Console.WriteLine("Damage Cannot Be 0 or less.");
                return;
            }
            else
            {

            }

        }

    }
}

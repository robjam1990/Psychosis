using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace EncyclopediaApp
{
    class Encyclopedia
    {
        private readonly string EncyclopediaFile = "Encyclopedia.e";
        private readonly string TitleArt = @"

                 ____  __ _   ___  _  _  ___  __     __  ____  ____  ____  __   __  
                (  __)(  ( \ / __)( \/ )/ __)(  )   /  \(  _ \(  __)(    \(  ) / _\ 
                 ) _) /    /( (__  )  /( (__ / (_/\(  O )) __/ ) _)  ) D ( )( /    \
                (____)\_)__) \___)(__/  \___)\____/ \__/(__)  (____)(____/(__)\_/\_/
";

        //Kicks off Encyclopedia app running
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Clear();

            Title = "Encyclopedia App";
            
            DisplayIntro();
            CreateEncyclopediaFile();
            RunMenu();
            DisplayOutro();
            
        }
        private void RunMenu()
        {
            string choice;
            do
            {
                choice = GetChoice();
                switch (choice)
                {
                    case "1":
                        DisplayEncyclopediaContents();
                        break;
                    case "2":
                        ClearEncyclopedia();
                        break;
                    case "3":
                        AddEntry();
                        break;
                    default:
                        break;
                }
            } while (choice != "4");
            
        }
        private string GetChoice()
        {
            bool isChoiceValid = false;
            string choice = "";

            do
            {
                Clear();
                ForegroundColor = ConsoleColor.Green;
                WriteLine(TitleArt);
                ForegroundColor = ConsoleColor.Red;
                
                WriteLine("\nWhat would you like to do?");
                WriteLine(" > 1. Read the Encyclopedia.");
                WriteLine(" > 2. Clear the Encyclopedia");
                WriteLine(" > 3. Add to the Encyclopedia");
                WriteLine(" > 4. Quit.");

                ForegroundColor = ConsoleColor.DarkBlue;
                choice = ReadLine().Trim();
                ForegroundColor = ConsoleColor.Black;

                if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                {
                    isChoiceValid = true;
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine($"\"{choice}\" is not a valid option.\nPlease select 1 - 4");
                    WaitForKey();
                }
            }while (!isChoiceValid);

            return choice;

        }
        private void CreateEncyclopediaFile() 
        {
            //ForegroundColor = ConsoleColor.Black;
            //WriteLine($"Does file exist? {File.Exists("Encyclopedia.e")}");
            //WaitForKey();
            if (!File.Exists(EncyclopediaFile))
            {
                File.CreateText(EncyclopediaFile);
            }
        }
        private void DisplayIntro() 
        {
            WriteLine(TitleArt);
            WriteLine("This is where you can look back at what you've learned.");
            WaitForKey();
        }
        private static void DisplayOutro() 
        {
            ForegroundColor = ConsoleColor.Black;
            WriteLine("Thanks for using.");
            WaitForKey();
        }
        private void DisplayEncyclopediaContents() 
        {
            ForegroundColor = ConsoleColor.Blue;
            string encyclopediaText = File.ReadAllText(EncyclopediaFile);
            WriteLine("\n==========Encyclopedia Contents==========");
            WriteLine(encyclopediaText);
            WriteLine("=========================================");
            WaitForKey();
        }
        private void ClearEncyclopedia()
        {
            ForegroundColor = ConsoleColor.Black;
            File.WriteAllText(EncyclopediaFile, "");
            WriteLine("\nJournal cleared!");
            WaitForKey();
        }
        private void AddEntry() 
        {
            ForegroundColor = ConsoleColor.Black;
            WriteLine("\nWhat would you like to add? (Type EXIT and press enter to stop.)");
            ForegroundColor = ConsoleColor.DarkBlue;

            string newEntry = "";
            bool shouldContinue = true;
            while (shouldContinue)
            {
                string line = ReadLine();
                if (line.ToLower().Trim() == "exit")
                {
                    shouldContinue = false;
                }
                else
                {
                    newEntry += line + "\n";
                }
            }
            File.AppendAllText(EncyclopediaFile, $"\nEntry:\n{newEntry}\n");
            ForegroundColor = ConsoleColor.Black;
            WriteLine("The Encyclopedia has been updated!");
            WaitForKey();
        }
        private static void WaitForKey()
        {
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("Press any key to continue......");
            ReadKey(true);
        }
    }
}

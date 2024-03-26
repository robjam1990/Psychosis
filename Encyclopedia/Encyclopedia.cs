using System;
using System.Collections.Generic;
using System.Linq;
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
            DisplayEncyclopediaContents();
            AddEntry();
            DisplayOutro();
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
            WriteLine("\nWhat would you like to add?");
            ForegroundColor = ConsoleColor.DarkBlue;
            string newLine = ReadLine()!;
            File.AppendAllText(EncyclopediaFile, $"\nEntry:\n> {newLine}\n");
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

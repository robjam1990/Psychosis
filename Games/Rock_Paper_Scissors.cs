//Save Name = Rock Paper Scissors, Save Type = .cs, Current File Location = robjam1990/Psychosis/Gameplay/Games
using System;

namespace RockPaperScissors
{
    class Game
    {
        private const string Rock = "r";
        private const string Paper = "p";
        private const string Scissors = "s";

        private static Random random = new Random(); // Move random initialization outside method

        public static void Main(string[] args)
        {
            Console.WriteLine("Let's play Rock, Paper, Scissors!");
            while (true)
            {
                PlayRound();

                if (!PlayAgain())
                {
                    DisplayExitMessage();
                    break;
                }

                Console.WriteLine();
            }
        }

        private static void PlayRound()
        {
            string userChoice = GetUserChoice();
            string computerChoice = GetComputerChoice();

            DisplayChoices(userChoice, computerChoice);

            string result = DetermineWinner(userChoice, computerChoice);
            DisplayResult(result);
        }

        private static string GetUserChoice()
        {
            while (true)
            {
                Console.Write("Choose rock (r), paper (p), or scissors (s): ");
                string choice = Console.ReadLine().ToLower();
                if (IsValidChoice(choice))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }
        }

        private static bool IsValidChoice(string choice)
        {
            return choice == Rock || choice == Paper || choice == Scissors;
        }

        private static string GetComputerChoice()
        {
            string[] choices = { Rock, Paper, Scissors };
            int index = random.Next(choices.Length); // Use class-level random instance
            return choices[index];
        }

        private static string DetermineWinner(string userChoice, string computerChoice)
        {
            if (userChoice == computerChoice)
            {
                return "It's a tie!";
            }
            else if ((userChoice == Rock && computerChoice == Scissors) ||
                     (userChoice == Paper && computerChoice == Rock) ||
                     (userChoice == Scissors && computerChoice == Paper))
            {
                return "You win!";
            }
            else
            {
                return "Computer wins!";
            }
        }

        private static void DisplayChoices(string userChoice, string computerChoice)
        {
            Console.WriteLine($"You chose: {userChoice}");
            Console.WriteLine($"The computer chose: {computerChoice}");
        }

        private static void DisplayResult(string result)
        {
            Console.WriteLine(result);
            Console.WriteLine("------------------------------");
        }

        private static void DisplayExitMessage()
        {
            Console.WriteLine("Thanks for playing! Goodbye!");
        }

        private static bool PlayAgain()
        {
            while (true)
            {
                Console.Write("Do you want to play again? (y/n): ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    return true;
                }
                else if (choice == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }
        }
    }
}

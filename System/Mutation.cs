using System;
using System.Collections.Generic;

namespace Psychosis.Gameplay.System
{
    // Define the initial state
    class Mutation
    {
        private const string INITIAL_STATE = "O";
        private static string Self = INITIAL_STATE;
        private static List<string> history = new List<string>();

        // Mutation process based on input
        public static void Mutate(int input)
        {
            // Validate input
            if (input < 1 || input > 3)
            {
                Console.WriteLine("Invalid input for mutation. Please provide a valid integer between 1 and 3.");
                return;
            }

            string mutationResult = Self; // Initialize mutation result with the current state

            switch (input)
            {
                case 1:
                    // Mutation 1
                    mutationResult = "-o";
                    history.Add("Mutation 1: Changed to -o");
                    break;
                case 2:
                    // Mutation 2
                    mutationResult = "1.O";
                    history.Add("Mutation 2: Changed to 1.O");
                    break;
                case 3:
                    // Mutation 3
                    mutationResult = "0.1:I.O";
                    history.Add("Mutation 3: Changed to 0.1:I.O");
                    break;
                default:
                    // Should not reach here due to input validation, but handling just in case
                    Console.WriteLine("Unknown input for mutation");
                    return;
            }

            // Update Self with the mutation result
            Self = mutationResult;

            // Log input and history
            Console.WriteLine("Input: " + input);
            Console.WriteLine("History: " + string.Join(", ", history));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the mutate function
            int input = 1;
            Mutation.Mutate(input);
        }
    }
}

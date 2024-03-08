using System;

namespace Dialogue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of NameGenerator and DialogueGenerator
            NameGenerator nameGenerator = new NameGenerator("Names.json");
            DialogueGenerator dialogueGenerator = new DialogueGenerator("Words.json");

            // Create an instance of DialogueManager using the nameGenerator and dialogueGenerator
            DialogueManager dialogueManager = new DialogueManager(nameGenerator, dialogueGenerator);

            // Get a random character name
            string characterName = dialogueManager.GetCharacterName(Gender: "Male", Race: "Human");

            // Generate a greeting for the character
            string greeting = dialogueManager.GenerateGreeting(characterName);

            // Output the character name and greeting
            Console.WriteLine($"Character Name: {characterName}");
            Console.WriteLine($"Greeting: {greeting}");
        }
    }
}

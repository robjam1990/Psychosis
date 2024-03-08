using System;
using System.Collections.Generic;

namespace Character
{
    public class Character
    {
        public string Name { get; set; }
        public Dictionary<string, object> Information { get; set; }
        public Dictionary<string, int> Attributes { get; set; }
        public Dictionary<string, int> SkillTree { get; set; }
        public Dictionary<string, Dictionary<string, int>> Traits { get; set; }
        public string Occupation { get; set; }
        public Dictionary<string, object> Inventory { get; set; }
        public Dictionary<string, string> Quests { get; set; }
        public Dictionary<string, int> Reputation { get; set; }
        public Dictionary<string, List<string>> Relationships { get; set; }

        public Character()
        {
            // Initialize default values for the character
            Name = "Robert";
            Information = new Dictionary<string, object>
            {
                { "gender", "Male" },
                { "birthdate", DateTime.Now },
                { "size", 1 * 3 * 1 },
                { "pigment", new Dictionary<string, int> { { "red", 0 }, { "green", 255 }, { "blue", 0 } } },
                { "odor", "100001" }
            };
            Attributes = new Dictionary<string, int>
            {
                { "Strength/Power", 1 },
                { "Endurance/Stamina", 1 },
                { "Speed/Agility", 1 },
                { "Perception/Recognition", 1 },
                { "Intelligence/Logistics", 1 },
                { "Knowledge/Memory", 1 },
                { "Experience/Wisdom", 1 },
                { "Will/Determination", 1 },
                { "Patience/Poise", 1 },
                { "Flexibility/Elasticity", 1 },
                { "Balance/Dexterity", 1 }
            };
            SkillTree = new Dictionary<string, int> { { "Observation", 1 } };
            Traits = new Dictionary<string, Dictionary<string, int>>
            {
                { "physical", new Dictionary<string, int> { { "strength", 0 }, { "speed", 0 }, { "aggression", 0 }, { "health", 0 }, { "appeal", 0 } } },
                { "social", new Dictionary<string, int> { { "humility", 0 }, { "temperament", 0 }, { "generosity", 0 }, { "loyalty", 0 }, { "honesty", 0 } } },
                { "Emotional", new Dictionary<string, int> { { "Spontaneity", 0 }, { "Mannerism", 0 }, { "Rage", 0 } } },
                { "Behavioral", new Dictionary<string, int> { { "Curiosity", 0 }, { "Dependency", 0 }, { "Confidence", 0 }, { "Ambition", 0 } } },
                { "Intellectual", new Dictionary<string, int> { { "Creativity", 0 }, { "Concentration", 0 }, { "Intelligence", 0 } } }
            };
            Occupation = "Adventurer";
            Inventory = new Dictionary<string, object>
            {
                { "gold", 0 },
                { "silver", 0 },
                { "equipped", new Dictionary<string, string>
                    {
                        { "Head", "" },
                        { "Shoulders", "" },
                        { "Chest", "Rugged Linen Shirt (.5lbs){Durability: 50%}" },
                        { "Arms", "" },
                        { "Waist", "Rugged Cotton Belt (.5lbs){Durability: 50%}" },
                        { "Legs", "Rugged Linen Pants (.5lbs){Durability: 50%}" },
                        { "Feet", "Rugged Rubber Boots (.5lbs){Durability: 50%}" },
                        { "Right Hand", "" },
                        { "Left Hand", "" }
                    }
                },
                { "bag", new Dictionary<string, string> { { "Item(Weight)", "" } } }
            };
            Quests = new Dictionary<string, string> { { "Maia", "Speak with the Barkeep." } };
            Reputation = new Dictionary<string, int> { { "fame", 100 }, { "notoriety", 0 } };
            Relationships = new Dictionary<string, List<string>>
            {
                { "allies", new List<string> { "Alek" } },
                { "enemies", new List<string>() },
                { "Friends", new List<string> { "Alek" } },
                { "Acquaintances", new List<string>() },
                { "Rivals", new List<string>() }
            };
            Relationships["loyalty"] = new List<string> { "Alek" };
            Relationships["fear"] = new List<string>();
            Relationships["respect"] = new List<string>();
            Relationships["morality"] = new List<string>();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Creating and displaying Robert's character sheet
            Character robert = new Character();
            DisplayCharacterSheet(robert);

            // Create a GrowthManager instance and simulate character growth
            GrowthManager playerGrowth = new GrowthManager("Characters.json");

            // Simulate gaining experience
            playerGrowth.GainExperience(50);
            Console.WriteLine($"Current Level: {playerGrowth.Level}, Experience: {playerGrowth.Experience}, Attributes: {string.Join(", ", playerGrowth.Attributes)}");
            playerGrowth.SaveCharacter(); // Save character after gaining experience

            playerGrowth.GainExperience(75);
            Console.WriteLine($"Current Level: {playerGrowth.Level}, Experience: {playerGrowth.Experience}, Attributes: {string.Join(", ", playerGrowth.Attributes)}");
            playerGrowth.SaveCharacter(); // Save character after gaining experience

            // Allocate attribute points upon leveling up
            Dictionary<string, int> attributePoints = new Dictionary<string, int> { { "strength", 2 }, { "agility", 1 } };
            playerGrowth.AllocatePoints(attributePoints);
            Console.WriteLine($"After allocating points: Attributes: {string.Join(", ", playerGrowth.Attributes)}");
            playerGrowth.SaveCharacter(); // Save character after allocating attribute points

            // Calculate damage based on attributes and level
            int baseDamage = 10;
            double calculatedDamage = playerGrowth.CalculateDamage(baseDamage);
            Console.WriteLine($"Calculated Damage: {calculatedDamage}");
        }

        public class CharacterSheet
        {
            public string Name { get; set; }
            public Dictionary<string, object> Information { get; set; }
            public Dictionary<string, int> Attributes { get; set; }
            public Dictionary<string, int> SkillTree { get; set; }
            public Dictionary<string, Dictionary<string, int>> Traits { get; set; }
            public string Occupation { get; set; }
            public Dictionary<string, object> Inventory { get; set; } = new Dictionary<string, object>(); // Initialize with an empty dictionary
            public Dictionary<string, string> Quests { get; set; }
            public Dictionary<string, int> Reputation { get; set; }
            public Dictionary<string, List<string>> Relationships { get; set; }

            public CharacterSheet()
            {
                // Initialize default values for the character
                Name = "Robert";
                Information = new Dictionary<string, object>
        {
            { "gender", "Male" },
            { "birthdate", DateTime.Now },
            { "size", 1 * 3 * 1 },
            { "pigment", new Dictionary<string, int> { { "red", 0 }, { "green", 255 }, { "blue", 0 } } },
            { "odor", "100001" }
        };
                Attributes = new Dictionary<string, int>
                {
                    // Initialize attributes
                };
                SkillTree = new Dictionary<string, int> { { "Observation", 1 } };
                Traits = new Dictionary<string, Dictionary<string, int>>
                {
                    // Initialize traits
                };
                Occupation = "Adventurer";
                Quests = new Dictionary<string, string> { { "Maia", "Speak with the Barkeep." } };
                Reputation = new Dictionary<string, int> { { "fame", 100 }, { "notoriety", 0 } };
                Relationships = new Dictionary<string, List<string>>
                {
                    // Initialize relationships
                };
                Relationships["loyalty"] = new List<string> { "Alek" };
                Relationships["fear"] = new List<string>();
                Relationships["respect"] = new List<string>();
                Relationships["morality"] = new List<string>();
            }
        }

        public static void DisplayCharacterSheet(Character character)
        {
            if (character == null)
            {
                Console.WriteLine("Invalid character data.");
                return;
            }

            Console.WriteLine("Character Name: " + character.Name);

            // Display attributes
            Console.WriteLine("\nAttributes:");
            foreach (KeyValuePair<string, int> attribute in character.Attributes)
            {
                Console.WriteLine($"- {attribute.Key}: {attribute.Value}");
            }

            // Display inventory
            Console.WriteLine("\nInventory:");
            foreach (KeyValuePair<string, object> item in character.Inventory)
            {
                Console.WriteLine($"- {item.Key}: {item.Value}");
            }

            // Display quests
            Console.WriteLine("\nQuests:");
            foreach (KeyValuePair<string, string> quest in character.Quests)
            {
                Console.WriteLine($"- {quest.Key}: {quest.Value}");
            }

            // Display relations
            Console.WriteLine("\nRelations:");
            foreach (KeyValuePair<string, List<string>> relation in character.Relationships)
            {
                Console.WriteLine($"{relation.Key}:");
                if (relation.Value.Count > 0)
                {
                    foreach (string person in relation.Value)
                    {
                        Console.WriteLine($"- {person}");
                    }
                }
                else
                {
                    Console.WriteLine("- None");
                }
            }
        }
    }
}

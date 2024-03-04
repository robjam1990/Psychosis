using System;
using System.Collections.Generic;

public class Stats
{
    public int health = 100;
    public int energy = 100;
    public int hunger = 0;
    public int thirst = 0;
    public int strength = 5;
    public int endurance = 5;
    public int speed = 5;
    public int perception = 5;
    public int intelligence = 5;
    public int knowledge = 5;
    public int experience = 0;
    public int will = 5;
    public int patience = 5;
    public int flexibility = 5;
    public int balance = 5;
    public int charisma = 5;
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, int>> traits = new Dictionary<string, Dictionary<string, int>>
        {
            { "physical", new Dictionary<string, int> { { "strength", 0 }, { "speed", 0 }, { "aggression", 0 }, { "health", 0 }, { "appeal", 0 } } },
            { "social", new Dictionary<string, int> { { "humility", 0 }, { "temperament", 0 }, { "generosity", 0 }, { "loyalty", 0 }, { "honesty", 0 } } },
            { "Emotional", new Dictionary<string, int> { { "Spontaneity", 0 }, { "Mannerism", 0 }, { "Rage", 0 } } },
            { "Behavioral", new Dictionary<string, int> { { "Curiosity", 0 }, { "Dependency", 0 }, { "Confidence", 0 }, { "Ambition", 0 } } },
            { "Intellectual", new Dictionary<string, int> { { "Creativity", 0 }, { "Concentration", 0 }, { "Intelligence", 0 } } }
        };

        Dictionary<string, List<string>> occupation = new Dictionary<string, List<string>>
        {
            { "Royalty", new List<string> { "King", "Queen", "Lord", "Lady" } },
            { "Military", new List<string> { "Guard", "Soldier", "Captain", "Commander", "General" } },
            { "Civilian", new List<string> { "Bard", "Alchemist", "Tanner", "Healer", "Farmer", "Blacksmith", "Barkeep", "Barmaid", "ShopKeep", "Apprentice", "Assistant", "Fletcher", "Butcher", "Weaver", "Potter" } },
            { "Labour", new List<string> { "Miner", "Hunter", "Athlete", "Scavenger", "Servant" } },
            { "Criminal", new List<string> { "Thief", "Murderer", "Assassin", "Pirate", "Bandit" } },
            { "Traversal", new List<string> { "Slave", "Settler", "Adventurer", "Explorer" } },
            { "Dangerous", new List<string> { "Mercenary" } },
            { "School", new List<string> { "Doctor", "Teacher", "Scholar", "Genius" } },
            { "Specialist", new List<string> { "Researcher", "Engineer", "Inventor", "Architect", "Plumber", "Pilot" } },
            { "Other", new List<string> { "Idiot", "Jester", "Judge", "Executioner", "Vagrant", "Priest" } }
        };

        Dictionary<string, object> myCharacter = new Dictionary<string, object>
        {
            { "stats", new Stats() },
            { "traits", traits },
            { "occupation", occupation }
        };

        foreach (var kvp in myCharacter)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}

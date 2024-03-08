using System;
using System.Collections.Generic;

public class CharacterStats
{
    public string Occupation { get; set; } = "Adventurer";
    public int Health { get; set; } = 100;
    public int Energy { get; set; } = 100;
    public int Hunger { get; set; } = 0;
    public int Thirst { get; set; } = 0;
    public int Strength { get; set; } = 5;
    public int Endurance { get; set; } = 5;
    public int Speed { get; set; } = 5;
    public int Perception { get; set; } = 5;
    public int Intelligence { get; set; } = 5;
    public int Knowledge { get; set; } = 5;
    public int Experience { get; set; } = 0;
    public int Will { get; set; } = 5;
    public int Patience { get; set; } = 5;
    public int Flexibility { get; set; } = 5;
    public int Balance { get; set; } = 5;
    public int Charisma { get; set; } = 5;
}

public class CharacterTraits
{
    public Dictionary<string, Dictionary<string, int>> TraitsData { get; set; }

    public CharacterTraits()
    {
        TraitsData = new Dictionary<string, Dictionary<string, int>>
        {
            { "Physical", new Dictionary<string, int> { { "Strength", 0 }, { "Speed", 0 }, { "Aggression", 0 }, { "Health", 0 }, { "Appeal", 0 } } },
            { "Social", new Dictionary<string, int> { { "Humility", 0 }, { "Temperament", 0 }, { "Generosity", 0 }, { "Loyalty", 0 }, { "Honesty", 0 } } },
            { "Emotional", new Dictionary<string, int> { { "Spontaneity", 0 }, { "Mannerism", 0 }, { "Rage", 0 } } },
            { "Behavioral", new Dictionary<string, int> { { "Curiosity", 0 }, { "Dependency", 0 }, { "Confidence", 0 }, { "Ambition", 0 } } },
            { "Intellectual", new Dictionary<string, int> { { "Creativity", 0 }, { "Concentration", 0 }, { "Intelligence", 0 } } }
        };
    }
}

public class OccupationList
{
    public Dictionary<string, List<string>> Occupations { get; set; }

    public OccupationList()
    {
        Occupations = new Dictionary<string, List<string>>
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
    }
}

public class UpdateCharacter
{
    private CharacterStats _characterStats;
    private CharacterTraits _characterTraits;
    private OccupationList _occupationList;

    public UpdateCharacter(CharacterStats characterStats, CharacterTraits characterTraits, OccupationList occupationList)
    {
        _characterStats = characterStats;
        _characterTraits = characterTraits;
        _occupationList = occupationList;
    }

    public void UpdateStats(int health, int strength)
    {
        _characterStats.Health = health;
        _characterStats.Strength = strength;
    }

    public void UpdateTraits(string category, string trait, int value)
    {
        if (_characterTraits.TraitsData.ContainsKey(category) && _characterTraits.TraitsData[category].ContainsKey(trait))
        {
            _characterTraits.TraitsData[category][trait] = value;
        }
    }

    public Dictionary<string, List<string>> GetOccupations()
    {
        return _occupationList.Occupations;
    }
}
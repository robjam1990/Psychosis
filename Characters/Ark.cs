using System;
using System.Collections.Generic;

public class Character
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public int Size { get; set; }
    public Dictionary<string, int> SkillTree { get; set; }
    public Dictionary<string, Dictionary<string, int>> Traits { get; set; }
    public string Occupation { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public Dictionary<string, int> Attributes { get; set; }
    public Dictionary<string, string> Knowledge { get; set; }
    public Dictionary<string, object> Inventory { get; set; }
    public Dictionary<string, int> Reputation { get; set; }
    public Dictionary<string, object> Relationships { get; set; }
    public Dictionary<string, string> Quests { get; set; }
    public Dictionary<string, int> Health { get; set; }
    public Dictionary<string, string> Appearance { get; set; }
    public Dictionary<string, object> Genetics { get; set; }

    public Character(string name, string gender)
    {
        Name = name;
        Gender = gender;
        Birthdate = DateTime.Now;
        Size = 1 * 3 * 1;
        SkillTree = new Dictionary<string, int> { { "Observation", 1 }, { "Identification", 1 }, { "Social", 1 }, { "Personal", 1 } };
        Traits = new Dictionary<string, Dictionary<string, int>>
        {
            { "physical", new Dictionary<string, int> { { "strength", 0 }, { "speed", 0 }, { "aggression", 0 }, { "health", 0 }, { "appeal", 0 } } },
            { "social", new Dictionary<string, int> { { "humility", 0 }, { "temperament", 0 }, { "generosity", 0 }, { "loyalty", 0 }, { "honesty", 0 } } },
            { "Emotional", new Dictionary<string, int> { { "Spontaneity", 0 }, { "Mannerism", 0 }, { "Rage", 0 } } },
            { "Behavioral", new Dictionary<string, int> { { "Curiosity", 0 }, { "Dependency", 0 }, { "Confidence", 1 }, { "Ambition", 0 } } },
            { "Intellectual", new Dictionary<string, int> { { "Creativity", 1 }, { "Concentration", 0 }, { "Intelligence", 1 } } }
        };
        Occupation = "Mercenary";
        Experience = 0;
        Level = 1;
        Attributes = new Dictionary<string, int>
        {
            { "Strength/Power", 11 }, { "Endurance/Stamina", 17 }, { "Speed/Agility", 12 },
            { "Perception/Recognition", 8 }, { "Intelligence/Logistics", 8 }, { "Knowledge/Memory", 8 },
            { "Experience/Wisdom", 8 }, { "Will/Determination", 21 }, { "Patience/Poise", 21 },
            { "Flexibility/Elasticity", 11 }, { "Balance/Dexterity", 13 }
        };
        Knowledge = new Dictionary<string, string> { { "lunge", "Novice" }, { "observation", "Intermediate" }, { "Shield_Bash", "Advanced" } };
        Inventory = new Dictionary<string, object>
        {
            { "gold", 200 }, { "silver", 500 },
            {
                "equipped", new Dictionary<string, string>
                {
                    { "Head", "" }, { "Shoulders", "Custom Linen Cape(5lbs){Durability: 100%}" },
                    { "Chest", "Custom Steel Plated Leather Vest (5lbs){Durability: 100%}" },
                    { "Arms", "Custom Steel Plated Leather Bracers(4lbs){Durability: 100%}" },
                    { "Waist", "Custom Steel Plated Leather Girdle (3lbs){Durability: 100%}" },
                    { "Legs", "Custom Steel Plated Leather Grieves (4lbs){Durability: 100%}" },
                    { "Feet", "Custom Steel Plated Rubber Boots (2lbs){Durability: 100%}" },
                    { "Right Hand", "Custom Diamond Tipped Steel Scimitar (7lbs){Durability: 100%}" },
                    { "Left Hand", "Custom Steel Plated Aluminum Shield (22lbs){Durability: 100%}" }
                }
            },
            { "bag", new Dictionary<string, string> { { "Item(Weight)", "" } } }
        };
        Reputation = new Dictionary<string, int> { { "fame", 50 }, { "notoriety", 20 } };
        Relationships = new Dictionary<string, object>
        {
            { "allies", new List<string> { "Sir Marcus", "Lady Eleanor", "Hammerhead Mercenaries", "Barkeep" } },
            { "enemies", new List<string> { "Bandit Leader" } },
            { "loyalty", 99 }, { "fear", 1 }, { "respect", 86 }, { "morality", 0.98642174532 }  // 1 = "Pure Good", 0 = "Pure Evil"
        };
        Quests = new Dictionary<string, string> { { "Aithaluwa", "Protect Aithaluwa" }, { "Ajax", "Protect the Barkeep" }, { "Barkeep", "Protect Ye Olde Taverne" } };
        Health = new Dictionary<string, int> { { "currentHealth", 100 }, { "maxHealth", 100 } };
        Appearance = new Dictionary<string, string> { { "facialMapping", "Strong jawline, sharp features" }, { "voiceSynthesis", "Deep and commanding" } };
        Genetics = new Dictionary<string, object> { { "mutations", new List<string> { "Enhanced strength", "Improved metabolism" } } };
    }
}

// In the main file or wherever Ark is defined
class Program
{
    static void Main(string[] args)
    {
        Character Ark = new Character("Ark", "Male");

        // In the code where you create a new Mercenary instance
        Mercenary mercenary = new Mercenary(Ark);
        mercenary.VisitTavern();
    }
}

class Mercenary
{
    public Character Character { get; set; }

    public Mercenary(Character character)
    {
        Character = character;
    }

    public void VisitTavern()
    {
        // Your implementation here
    }
}

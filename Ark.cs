using System;
using System.Collections.Generic;

public class Character
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public int Size { get; set; }
    public Dictionary<string, int> SkillTree { get; set; }
    public Dictionary<string, Dictionary<string, int>>? Traits { get; set; }
    public string? Occupation { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public Dictionary<string, int>? Attributes { get; set; }
    public Dictionary<string, string>? Knowledge { get; set; }
    public Dictionary<string, object>? Inventory { get; set; }
    public Dictionary<string, int>? Reputation { get; set; }
    public Dictionary<string, object>? Relationships { get; set; }
    public Dictionary<string, string>? Quests { get; set; }
    public Dictionary<string, int>? Health { get; set; }
    public Dictionary<string, string>? Appearance { get; set; }
    public Dictionary<string, object>? Genetics { get; set; }
    public Character? Ark { get; }

    public Character(string name, string gender, Character? ark = null)
    {
        Name = name;
        Gender = gender;
        Birthdate = DateTime.Now;
        Size = 1 * 3 * 1;
        SkillTree = new Dictionary<string, int> { { "Observation", 1 }, { "Identification", 1 }, { "Social", 1 }, { "Personal", 1 } };
        Ark = ark;
        Traits = null;
        Occupation = null;
        Attributes = null;
        Knowledge = null;
        Inventory = null;
        Reputation = null;
        Relationships = null;
        Quests = null;
        Health = null;
        Appearance = null;
        Genetics = null;
    }

    public Character(Character? ark)
    {
        Name = string.Empty;
        Gender = string.Empty;
        Birthdate = DateTime.Now;
        Size = 1 * 3 * 1;
        SkillTree = new Dictionary<string, int> { { "Observation", 1 }, { "Identification", 1 }, { "Social", 1 }, { "Personal", 1 } };
        Ark = ark;
        Traits = null;
        Occupation = null;
        Attributes = null;
        Knowledge = null;
        Inventory = null;
        Reputation = null;
        Relationships = null;
        Quests = null;
        Health = null;
        Appearance = null;
        Genetics = null;
    }
}
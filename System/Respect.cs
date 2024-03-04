// File = robjam1990/Psychosis/Gameplay/System/Respect.cs

using System;

public class RespectSystem
{
    private readonly Dictionary<string, Dictionary<string, int>> respectLevels;

    public RespectSystem()
    {
        respectLevels = new Dictionary<string, Dictionary<string, int>>
        {
            {"low", new Dictionary<string, int> {{"min", 0}, {"max", 25}}},
            {"medium", new Dictionary<string, int> {{"min", 26}, {"max", 50}}},
            {"high", new Dictionary<string, int> {{"min", 51}, {"max", 75}}},
            {"impressive", new Dictionary<string, int> {{"min", 76}, {"max", 100}}}
        };
    }

    public string CalculateRespectLevel(Character character)
    {
        string respectLevel = "low";

        if (character.Luck > respectLevels["medium"]["min"])
        {
            respectLevel = "medium";
        }

        if (character.Charisma > respectLevels["high"]["min"])
        {
            respectLevel = "high";
        }

        return respectLevel;
    }

    public int AdjustRespect(Character character, int amount)
    {
        character.Respect += amount;

        if (character.Respect < 0)
        {
            character.Respect = 0;
        }

        if (character.Respect > 100)
        {
            character.Respect = 100;
        }

        return character.Respect;
    }

    public void EnforceRespect(Character character, Character target)
    {
        if (character.Respect >= respectLevels["medium"]["min"])
        {
            Console.WriteLine($"{character.Name} shows {target.Name} respect.");
            target.Feelings += 10; // Increase target's feelings toward the character
        }
        else
        {
            Console.WriteLine($"{character.Name} disregards {target.Name}.");
            target.Feelings -= 10; // Decrease target's feelings toward the character
        }
    }

    public void ConfiscateItem(Character character, Item item, int itemValue)
    {
        if (character.Respect > itemValue)
        {
            Console.WriteLine($"{character.Name} confiscates {item.Name}.");
            // Logic to remove the item from the character's inventory
        }
    }

    public void AidInCombat(Character character, Character target, int loyalty, int fear, int morality)
    {
        if ((character.Respect + loyalty > fear) * morality)
        {
            Console.WriteLine($"{character.Name} aids {target.Name} in combat.");
            // Logic to provide assistance in combat
        }
    }
}

// Example usage:
// RespectSystem respectSystem = new RespectSystem();
// string respectLevel = respectSystem.CalculateRespectLevel(character);
// int newRespect = respectSystem.AdjustRespect(character, amount);
// respectSystem.EnforceRespect(character, target);
// respectSystem.ConfiscateItem(character, item, itemValue);
// respectSystem.AidInCombat(character, target, loyalty, fear, morality);

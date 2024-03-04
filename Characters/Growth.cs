using System;
using System.Collections.Generic;

public class GrowthManager
{
    public int level;
    public int experience;
    public int nextLevelThreshold;
    public Dictionary<string, int> attributes;

    public GrowthManager()
    {
        level = 1;
        experience = 0;
        nextLevelThreshold = 100; // Adjust as needed for your game
        attributes = new Dictionary<string, int>
        {
            { "strength", 1 },
            { "agility", 1 },
            { "intelligence", 1 }
        };
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        while (experience >= nextLevelThreshold)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level += 1;
        experience -= nextLevelThreshold;
        nextLevelThreshold = (int)(nextLevelThreshold * 1.275);
        ImproveAttributes();

        // Add any additional stat or ability improvements here
        Console.WriteLine($"Congratulations! You've reached Level {level}.");
    }

    public void ImproveAttributes()
    {
        // Modify attribute growth as per your game's requirements
        foreach (string attr in attributes.Keys)
        {
            attributes[attr] += (int)(level * 1.11275369989);
        }
    }

    public void AllocatePoints(Dictionary<string, int> pointsDict)
    {
        // Allocate attribute points gained upon leveling up
        foreach (KeyValuePair<string, int> pair in pointsDict)
        {
            if (attributes.ContainsKey(pair.Key))
            {
                attributes[pair.Key] += pair.Value;
            }
        }
    }

    public int GetAttribute(string attribute)
    {
        // Retrieve the value of a specific attribute
        return attributes.ContainsKey(attribute) ? attributes[attribute] : 0;
    }

    public double CalculateDamage(int baseDamage)
    {
        // Calculate damage based on attributes and level
        double damageModifier = Math.Sqrt(attributes["strength"]) * 0.5 + level * 0.75;
        return baseDamage * damageModifier;
    }
}

class Program
{
    static void Main(string[] args)
    {
        GrowthManager playerGrowth = new GrowthManager();

        // Simulate gaining experience
        playerGrowth.GainExperience(50);
        Console.WriteLine($"Current Level: {playerGrowth.level}, Experience: {playerGrowth.experience}, Attributes: {string.Join(", ", playerGrowth.attributes)}");

        playerGrowth.GainExperience(75);
        Console.WriteLine($"Current Level: {playerGrowth.level}, Experience: {playerGrowth.experience}, Attributes: {string.Join(", ", playerGrowth.attributes)}");

        // Allocate attribute points upon leveling up
        Dictionary<string, int> attributePoints = new Dictionary<string, int> { { "strength", 2 }, { "agility", 1 } };
        playerGrowth.AllocatePoints(attributePoints);
        Console.WriteLine($"After allocating points: Attributes: {string.Join(", ", playerGrowth.attributes)}");

        // Calculate damage based on attributes and level
        int baseDamage = 10;
        double calculatedDamage = playerGrowth.CalculateDamage(baseDamage);
        Console.WriteLine($"Calculated Damage: {calculatedDamage}");
    }
}

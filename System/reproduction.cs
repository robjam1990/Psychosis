using System;
using System.Collections.Generic;

public class Character
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public Dictionary<string, double> Stats { get; set; }

    public Character(string name, string gender, Dictionary<string, double> stats)
    {
        Name = name;
        Gender = gender;
        Stats = stats;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Name} - {Gender}");
        Console.WriteLine("Stats:");
        foreach (var stat in Stats)
        {
            Console.WriteLine($"{stat.Key}: {stat.Value}");
        }
    }
}

public class Program
{
    public static Character Reproduce(Character parent1, Character parent2, bool elitism = false)
    {
        string childName = $"{parent1.Name}'s offspring";
        string childGender = (new Random().Next(2) == 0) ? "Male" : "Female";

        Dictionary<string, double> childStats = new Dictionary<string, double>();
        if (elitism)
        {
            if (childGender == "Male")
            {
                foreach (var stat in parent1.Stats)
                {
                    childStats[stat.Key] = stat.Value + (stat.Value * 0.1); // Copy 10% of the stat value
                }
            }
            else
            {
                foreach (var stat in parent2.Stats)
                {
                    childStats[stat.Key] = stat.Value + (stat.Value * 0.1); // Copy 10% of the stat value
                }
            }
        }
        else
        {
            foreach (var stat in parent1.Stats)
            {
                childStats[stat.Key] = new Random().NextDouble() * (stat.Value * 0.1) + stat.Value * 0.9;
            }
            foreach (var stat in parent2.Stats)
            {
                childStats[stat.Key] = (childStats.ContainsKey(stat.Key) ? childStats[stat.Key] : 0) + new Random().NextDouble() * (stat.Value * 0.1) + stat.Value * 0.9;
                childStats[stat.Key] /= 2;
            }
        }

        return new Character(childName, childGender, childStats);
    }

    public static void Main(string[] args)
    {
        Character parent1 = new Character("Alice", "Female", new Dictionary<string, double> { { "Strength", 10 }, { "Agility", 8 }, { "Intelligence", 12 } });
        Character parent2 = new Character("Bob", "Male", new Dictionary<string, double> { { "Strength", 12 }, { "Agility", 9 }, { "Intelligence", 10 } });

        // Test reproduction without elitism
        Character child = Reproduce(parent1, parent2);
        child.DisplayInfo();

        // Test reproduction with elitism
        Character childElitism = Reproduce(parent1, parent2, true);
        childElitism.DisplayInfo();
    }
}

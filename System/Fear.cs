// File: Robjam1990/Psychosis/Gameplay/System/Fear.cs

using System;
using System.Collections.Generic;

// This file implements the fear system in the gameplay.

public class FearSystem
{
    private Dictionary<Character, double> fearLevels; // Dictionary to store fear levels of characters

    public FearSystem()
    {
        fearLevels = new Dictionary<Character, double>();
    }

    // Method to get fear level of a character
    public double GetFearLevel(Character character)
    {
        if (fearLevels.ContainsKey(character))
        {
            return fearLevels[character];
        }
        else
        {
            return 0; // Default fear level
        }
    }

    // Method to increase fear level of a character
    public void IncreaseFearLevel(Character character, double amount)
    {
        double fear = fearLevels.ContainsKey(character) ? fearLevels[character] + amount : amount;
        if (character.Injured && character.Diseased)
        {
            fear *= 2.5; // Increase fear level if character is both injured and diseased
        }
        else if (character.Injured || character.Diseased)
        {
            fear *= 1.5; // Increase fear level if character is either injured or diseased
        }
        fearLevels[character] = fear;
    }

    // Method to decrease fear level of a character
    public void DecreaseFearLevel(Character character, double amount)
    {
        if (fearLevels.ContainsKey(character))
        {
            double fear = fearLevels[character] - amount;
            fear = Math.Max(fear, 0); // Ensure fear level doesn't go below 0
            fearLevels[character] = fear;
        }
    }

    // Method to reset fear level of a character
    public void ResetFearLevel(Character character)
    {
        if (fearLevels.ContainsKey(character))
        {
            fearLevels.Remove(character);
        }
    }

    // Method to check if a character is terrified
    public bool IsTerrified(Character character, double threshold)
    {
        return GetFearLevel(character) >= threshold;
    }
}

// Define the Character class if not already defined
public class Character
{
    public bool Injured { get; set; }
    public bool Diseased { get; set; }
    // Add other character properties as needed
}

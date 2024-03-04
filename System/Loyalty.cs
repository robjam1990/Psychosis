// File = robjam1990/Psychosis/Gameplay/System/Loyalty.cs
// Loyalty.cs

using System;
using System.Collections.Generic;

public class LoyaltySystem
{
    private Dictionary<string, int> characters; // Dictionary to store characters and their loyalty attributes

    public LoyaltySystem()
    {
        characters = new Dictionary<string, int>();
    }

    public void AddCharacter(string characterName, int loyaltyLevel)
    {
        // Add a character to the loyalty system.
        if (!characters.ContainsKey(characterName))
        {
            characters.Add(characterName, loyaltyLevel);
        }
        else
        {
            Console.WriteLine($"{characterName} already exists in the loyalty system.");
        }
    }

    public void IncreaseLoyalty(string characterName, int amount)
    {
        // Increase the loyalty level of a character.
        if (characters.ContainsKey(characterName))
        {
            characters[characterName] += amount;
        }
        else
        {
            Console.WriteLine($"{characterName} does not exist in the loyalty system.");
        }
    }

    public void DecreaseLoyalty(string characterName, int amount)
    {
        // Decrease the loyalty level of a character.
        if (characters.ContainsKey(characterName))
        {
            characters[characterName] -= amount;
        }
        else
        {
            Console.WriteLine($"{characterName} does not exist in the loyalty system.");
        }
    }

    public int GetLoyalty(string characterName)
    {
        // Get the loyalty level of a character.
        if (characters.ContainsKey(characterName))
        {
            return characters[characterName];
        }
        else
        {
            Console.WriteLine($"{characterName} does not exist in the loyalty system.");
            return -1; // or return any default value indicating failure
        }
    }

    public void ModifyLoyalty(string characterName, int modifier)
    {
        // Modify the loyalty level of a character based on an event.
        if (characters.ContainsKey(characterName))
        {
            characters[characterName] += modifier;
        }
        else
        {
            Console.WriteLine($"{characterName} does not exist in the loyalty system.");
        }
    }

    public void HandleEvent(string characterName, string event)
    {
        // Handle an event that affects character loyalty.
        switch (event)
        {
            case "completed_quest":
            ModifyLoyalty(characterName, 10); // Increase loyalty after completing a quest
            break;
        case "betrayal":
            ModifyLoyalty(characterName, -20); // Decrease loyalty due to betrayal
            break;
        // Add more cases for other events affecting loyalty
        default:
            Console.WriteLine($"Unhandled event: {event}");
            break;
        }
    }
    }

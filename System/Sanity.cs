// File: robjam1990/Psychosis/Gameplay/System/Sanity.cs

using System;
using System.Collections.Generic;

// This file implements the advanced sanity system for the game.
public class SanitySystem
{
    private Character character;
    private int baseSanity = 100; // Base sanity value
    private int currentSanity; // Current sanity value
    private int maxSanity = 200; // Maximum sanity value
    private double sanityDecayRate = 0.1; // Rate at which sanity decreases over time
    private List<Dictionary<string, Action>> sanityEvents = new List<Dictionary<string, Action>>(); // List to store sanity-related events

    public SanitySystem(Character character)
    {
        this.character = character;
        this.currentSanity = baseSanity;
    }

    // Function to update sanity based on time passage
    public void UpdateSanity()
    {
        // Decrease sanity over time
        currentSanity -= (int)(sanityDecayRate * 10); // Multiply by 10 to simulate decimals

        // Ensure sanity stays within bounds
        currentSanity = Math.Max(0, Math.Min(currentSanity, maxSanity));

        // Check for sanity-related events or triggers
        CheckSanityEvents();
    }

    // Function to check for sanity-related events
    private void CheckSanityEvents()
    {
        // Iterate through sanity events
        foreach (var eventDict in sanityEvents)
        {
            // Check if event conditions are met
            if (eventDict["condition"]())
            {
                // Trigger event action
                eventDict["action"]();
            }
        }
    }

    // Function to restore sanity
    public void RestoreSanity(int amount)
    {
        currentSanity += amount;

        // Ensure sanity stays within bounds
        currentSanity = Math.Min(currentSanity, maxSanity);
    }

    // Function to inflict sanity loss
    public void InflictSanityLoss(int amount)
    {
        currentSanity -= amount;

        // Ensure sanity stays within bounds
        currentSanity = Math.Max(0, currentSanity);
    }

    // Function to add a sanity event
    public void AddSanityEvent(Func<bool> condition, Action action)
    {
        Dictionary<string, Action> eventDict = new Dictionary<string, Action>();
        eventDict.Add("condition", condition);
        eventDict.Add("action", action);
        sanityEvents.Add(eventDict);
    }

    // Additional Features

    // Function to handle sanity event triggers
    public void HandleSanityEvents()
    {
        foreach (var eventDict in sanityEvents)
        {
            if (eventDict["condition"]())
            {
                eventDict["action"]();
            }
        }
    }

    // Function to scale sanity effects with game progression and difficulty
    public void ScaleSanityEffects(double difficultyMultiplier)
    {
        sanityDecayRate *= difficultyMultiplier;
        // You can add more scaling effects here if needed
    }

    // Function to reset sanity to its default state
    public void ResetSanity()
    {
        currentSanity = baseSanity;
    }
}

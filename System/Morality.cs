// File = robjam1990/Psychosis/Gameplay/System/Morality.cs

using System;
using System.Collections.Generic;

// Define Morality class
public class Morality
{
    private string jurisdiction = "local"; // Default jurisdiction for morality spectrum
    private Dictionary<string, double> actions = new Dictionary<string, double>(); // Dictionary to store actions and their morality consequences

    // Set the jurisdiction for morality spectrum
    public void SetJurisdiction(string jurisdiction)
    {
        this.jurisdiction = jurisdiction;
    }

    // Add an action with its morality consequences
    public void AddAction(string action, double moralityConsequence)
    {
        actions[action] = moralityConsequence;
    }

    // Get morality consequence for a specific action
    public double GetMoralityConsequence(string action)
    {
        return actions.ContainsKey(action) ? actions[action] : 0;
    }

    // Calculate morality based on actions performed
    public double CalculateMorality(List<string> actionsPerformed)
    {
        double morality = 0;

        foreach (string action in actionsPerformed)
        {
            if (actions.ContainsKey(action))
            {
                morality += actions[action];
            }
        }

        // Apply consequence multiplier if morality is below 50
        if (morality < 50)
        {
            morality *= 1.5;
        }

        return morality;
    }

    // Update morality jurisdiction
    public void UpdateJurisdiction(string newJurisdiction)
    {
        jurisdiction = newJurisdiction;
    }
}

// Example usage:
class Program
{
    static void Main(string[] args)
    {
        // Instantiate Morality object
        Morality moralitySystem = new Morality();

        // Set jurisdiction
        moralitySystem.SetJurisdiction("local");

        // Add actions and their morality consequences
        moralitySystem.AddAction("helping villagers", 0.01); // Positive morality consequence
        moralitySystem.AddAction("stealing from others", -0.02); // Negative morality consequence

        // Get morality consequence for a specific action
        Console.WriteLine(moralitySystem.GetMoralityConsequence("stealing from others")); // Output: -0.02

        // Calculate morality based on actions performed
        List<string> actionsPerformed = new List<string> { "helping villagers", "stealing from others" };
        Console.WriteLine(moralitySystem.CalculateMorality(actionsPerformed)); // Output: -0.015

        // Update morality jurisdiction
        moralitySystem.UpdateJurisdiction("global");
        Console.WriteLine(moralitySystem.GetJurisdiction()); // Output: global
    }
}

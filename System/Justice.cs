// File = robjam1990/Psychosis/Gameplay/Systems/Justice.cs

using System;
using System.Collections.Generic;

public class JusticeSystem
{
    private Dictionary<string, List<string>> laws = new Dictionary<string, List<string>>()
    {
        { "conjective", new List<string>() { "Slander" } },
        { "injective", new List<string>() { "assault", "vandalism" } },
        { "rejective", new List<string>() { "resisting arrest", "tax evasion" } },
        { "subjective", new List<string>() { "trespassing", "theft", "desertion" } },
        { "objective", new List<string>() { "murder", "assassination", "terrorism" } }
    };
    private Dictionary<string, List<string>> crimeTracker = new Dictionary<string, List<string>>();

    public string HandleCrime(string crime, string perpetrator, bool playerInfluence, bool conscious = true)
    {
        // Validate input parameters
        if (string.IsNullOrEmpty(crime) || string.IsNullOrEmpty(perpetrator))
        {
            throw new ArgumentException("Invalid input parameters. Crime and perpetrator must be provided.");
        }

        int notoriety = 0;
        if (laws["injective"].Contains(crime))
        {
            notoriety += 2;
        }
        else if (laws["rejective"].Contains(crime))
        {
            notoriety += 1;
        }
        else if (laws["subjective"].Contains(crime))
        {
            notoriety += 2;
        }
        else if (laws["objective"].Contains(crime))
        {
            notoriety += 5;
        }

        // Track the crime
        if (!crimeTracker.ContainsKey(perpetrator))
        {
            crimeTracker[perpetrator] = new List<string>();
        }
        crimeTracker[perpetrator].Add(crime);

        string punishment;
        if (notoriety == 1)
        {
            // Implement player influence on punishment
            if (perpetrator == "player" && playerInfluence)
            {
                notoriety -= 1; // Reduced punishment for player's influence
            }
            punishment = "Jail for 1 Day or Fine of 100 silver coins"; // Return alternative punishment if applicable
        }
        else
        {
            if (notoriety >= 3)
            {
                punishment = "Incapacitation";
            }
            else
            {
                if (!conscious)
                {
                    punishment = $"Jail for {notoriety} Day(s) or Fine of {notoriety * 100} silver coins";
                }
                else
                {
                    punishment = "No specific action required.";
                }
            }
            // Implement alternative justice systems
            switch (crime)
            {
                case "murder":
                    punishment = "Trial by Combat";
                    break;
                case "assassination":
                    punishment = "Death";
                    break;
                case "theft":
                    punishment = "Dismember";
                    break;
                case "trespassing":
                    punishment = "Trial by judge";
                    break;
                default:
                    punishment = "Standard punishment applied.";
                    break;
            }
        }
        return punishment;
    }
}

public class JurisdictionSystem
{
    public List<string> Types { get; } = new List<string>() { "locational", "factional" };
}

// Feedback Mechanisms
public class Feedback
{
    public static void ProvideFeedback(string player, string crime, string punishment)
    {
        // Simulate reputation changes, public opinion, etc.
        Console.WriteLine($"{player} committed {crime} and received punishment: {punishment}");
        // Implement long-term consequences
        if (punishment == "Jail for 1 Day or Fine of 100 silver coins")
        {
            Console.WriteLine($"{player} is now a fugitive.");
        }
    }
}

// Example usage:
class Program
{
    static void Main(string[] args)
    {
        string crime = "theft";
        string perpetrator = "player";
        bool playerInfluence = true; // Player attempts to influence the punishment
        JusticeSystem justiceSystem = new JusticeSystem();
        string punishment = justiceSystem.HandleCrime(crime, perpetrator, playerInfluence);
        Feedback.ProvideFeedback(perpetrator, crime, punishment);
    }
}

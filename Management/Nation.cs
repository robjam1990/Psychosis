using System;
using System.Collections.Generic;

public class Nation
{
    public string Name { get; }
    public Dictionary<string, int> Population { get; }
    public int MilitaryStrength { get; }
    public int Industry { get; }
    public int Agriculture { get; }
    public int Commerce { get; }
    public List<string> Territories { get; }
    public Leader CurrentLeader { get; set; }
    public Dictionary<string, int> Time { get; }
    public double TaxRate { get; set; }
    public List<Nation> TradePartners { get; }
    public Dictionary<Nation, string> DiplomaticRelations { get; }
    public int CulturalDevelopment { get; set; }
    public Dictionary<string, int> SocialPolicies { get; }
    public List<string> EventDescriptions { get; }

    public Nation(string name, Dictionary<string, int> population, int militaryStrength, int industry, int agriculture, int commerce)
    {
        Name = name;
        Population = population;
        MilitaryStrength = militaryStrength;
        Industry = industry;
        Agriculture = agriculture;
        Commerce = commerce;
        Territories = new List<string>();
        Time = new Dictionary<string, int> { { "hours", 0 }, { "day", 0 }, { "season", "Spring" } };
        TaxRate = 0.1;
        TradePartners = new List<Nation>();
        DiplomaticRelations = new Dictionary<Nation, string>();
        CulturalDevelopment = 0;
        SocialPolicies = new Dictionary<string, int>();
        EventDescriptions = new List<string>
        {
            "A natural disaster strikes!",
            "A diplomatic crisis erupts with a neighboring nation!",
            "A new technological breakthrough boosts industry!",
            "A cultural renaissance inspires the population!",
            "A plague sweeps through the land, affecting agriculture and population!",
            "A rebellion threatens the stability of the nation!",
            "A bountiful harvest leads to economic prosperity!",
            "A military victory boosts national morale!"
        };
    }

    public void AddTerritory(string territory)
    {
        Territories.Add(territory);
    }

    public void RemoveTerritory(string territory)
    {
        Territories.Remove(territory);
    }

    public void ManageLogistics()
    {
        Console.WriteLine("Managing logistics...");
    }

    public void ManageAgriculture()
    {
        Console.WriteLine("Managing agriculture...");
    }

    public void ManageIndustry()
    {
        Console.WriteLine("Managing industry...");
    }

    public void ManageTaxation(double newTaxRate)
    {
        Console.WriteLine($"Adjusting tax rate to {newTaxRate}...");
        TaxRate = newTaxRate;
    }

    public void ManageTradeAgreements(Nation partnerNation)
    {
        Console.WriteLine($"Establishing trade agreement with {partnerNation.Name}...");
        TradePartners.Add(partnerNation);
    }

    public void ManageDiplomacy(string action, Nation targetNation)
    {
        Console.WriteLine($"Initiating {action} with {targetNation.Name}...");
    }

    public void EnactSocialPolicy(string policy, int value)
    {
        Console.WriteLine($"Enacting {policy} policy with value {value}...");
        SocialPolicies[policy] = value;
    }

    public void HandleEvents()
    {
        Random random = new Random();
        int eventIndex = random.Next(EventDescriptions.Count);
        string eventDescription = EventDescriptions[eventIndex];
        Console.WriteLine(eventDescription);

        switch (eventIndex)
        {
            case 0: // Natural disaster
                Population["citizens"] = (int)(Population["citizens"] * 0.9); // 10% population decrease
                MilitaryStrength = (int)(MilitaryStrength * 0.8); // 20% military strength decrease
                break;
            case 2: // Technological breakthrough
                Industry += 1000; // Boost industry by 1000 units
                break;
            case 3: // Cultural renaissance
                CulturalDevelopment += 10; // Increase cultural development level
                break;
            case 4: // Plague
                Population["citizens"] = (int)(Population["citizens"] * 0.7); // 30% population decrease
                Agriculture = (int)(Agriculture * 0.8); // 20% agriculture decrease
                break;
            case 5: // Rebellion
                MilitaryStrength = (int)(MilitaryStrength * 0.7); // 30% military strength decrease
                break;
            case 6: // Bountiful harvest
                Agriculture += 2000; // Boost agriculture by 2000 units
                break;
            case 7: // Military victory
                MilitaryStrength = (int)(MilitaryStrength * 1.2); // 20% military strength increase
                break;
            default:
                break;
        }
    }

    public void AdvanceTime(int gameHours)
    {
        int daysPassed = gameHours / 24;

        for (int i = 0; i < daysPassed; i++)
        {
            ManageAgriculture();
            ManageIndustry();
            HandleEvents();
            UpdateTime();
        }
    }

    public void UpdateTime()
    {
        Time["hours"] += 24;
        Time["day"]++;

        if (Time["day"] % 30 == 0)
        {
            Time["day"] = 1;
            UpdateSeason();
        }
    }

    public void UpdateSeason()
    {
        string[] seasons = { "Spring", "Summer", "Autumn", "Winter" };
        int currentSeasonIndex = Array.IndexOf(seasons, Time["season"]);
        int nextSeasonIndex = (currentSeasonIndex + 1) % 4;
        Time["season"] = seasons[nextSeasonIndex];
    }
}

// Example usage:

public class Leader
{
    public string Name { get; }
    public string Title { get; }
    public int Level { get; }

    public Leader(string name, string title, int level)
    {
        Name = name;
        Title = title;
        Level = level;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Initialize the nation and leader
        Nation playerNation = new Nation("Bractalia", new Dictionary<string, int> { { "citizens", 10000 }, { "farmers", 2000 }, { "miners", 1500 } }, 1000, 5000, 3000, 2000);
        Leader playerLeader = new Leader("Apus", "Queen", 3);
        playerNation.CurrentLeader = playerLeader;

        // Add territories to the nation
        playerNation.AddTerritory("Territory 1");
        playerNation.AddTerritory("Territory 2");

        // Game loop
        bool isGameOver = false;
        while (!isGameOver)
        {
            // Display menu options and gather player input
            Console.WriteLine("1. Manage Logistics");
            Console.WriteLine("2. Manage Agriculture");
            Console.WriteLine("3. Manage Commerce");
            Console.WriteLine("4. Manage Military");
            Console.WriteLine("5. Manage Taxation");
            Console.WriteLine("6. Manage Trade Agreements");
            Console.WriteLine("7. Manage Diplomacy");
            Console.WriteLine("8. Enact Social Policies");
            Console.WriteLine("9. End Turn");
            Console.WriteLine("10. Exit Game");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            // Execute player's choice
            switch (choice)
            {
                case 1:
                    playerNation.ManageLogistics();
                    break;
                case 2:
                    playerNation.ManageAgriculture();
                    break;
                case 3:
                    playerNation.ManageIndustry();
                    break;
                case 4:
                    playerNation.ManageMilitary();
                    break;
                case 5:
                    Console.Write("Enter the new tax rate: ");
                    double newTaxRate = double.Parse(Console.ReadLine());
                    playerNation.ManageTaxation(newTaxRate);
                    break;
                case 6:
                    Console.Write("Enter the name of the nation to establish a trade agreement with: ");
                    string partnerNation = Console.ReadLine();
                    playerNation.ManageTradeAgreements(new Nation(partnerNation, new Dictionary<string, int>(), 0, 0, 0, 0));
                    break;
                case 7:
                    Console.Write("Enter the diplomatic action (e.g., alliance, ceasefire, declaration of war): ");
                    string action = Console.ReadLine();
                    Console.Write("Enter the name of the target nation: ");
                    string targetNation = Console.ReadLine();
                    playerNation.ManageDiplomacy(action, new Nation(targetNation, new Dictionary<string, int>(), 0, 0, 0, 0));
                    break;
                case 8:
                    Console.Write("Enter the social policy to enact: ");
                    string policy = Console.ReadLine();
                    Console.Write("Enter the value of the social policy: ");
                    int value = int.Parse(Console.ReadLine());
                    playerNation.EnactSocialPolicy(policy, value);
                    break;
                case 9:
                    Console.WriteLine("Ending turn...");
                    // Handle events and advance time by one day (24 game hours)
                    playerNation.HandleEvents();
                    playerNation.AdvanceTime(24);
                    break;
                case 10:
                    Console.WriteLine("Exiting game...");
                    isGameOver = true; // Set the flag to end the game loop
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

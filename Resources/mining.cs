using System;
using System.Collections.Generic;

public class Player
{
    public Dictionary<string, int> inventory = new Dictionary<string, int>
    {
        { "Lithium", 0 }, { "Chromium", 0 }, { "Tungsten", 0 }, { "Mercury", 0 }, { "Uranium", 0 },
        { "Magnesium", 0 }, { "Gallium", 0 }, { "Iron", 0 }, { "Aluminum", 0 }, { "Titanium", 0 },
        { "Steel", 0 }, { "Gold", 0 }, { "Silver", 0 }, { "Bronze", 0 }, { "Copper", 0 }, { "Flint", 0 },
        { "Nickel", 0 }, { "Malachite", 0 }, { "Lead", 0 }, { "Tin", 0 }, { "Zinc", 0 }, { "Cobalt", 0 },
        { "Coal", 0 }, { "Obsidian", 0 }, { "Clay", 0 }, { "Oil", 0 }, { "Marble", 0 }, { "Sand", 0 }, { "Stone", 0 },
        { "Diamond", 0 }, { "Ruby", 0 }, { "Sapphire", 0 }, { "Garnet", 0 }, { "Emerald", 0 }, { "Topaz", 0 },
        { "Amethyst", 0 }, { "Quartz", 0 }
    };

    public Dictionary<string, int> attributes = new Dictionary<string, int>
    {
        { "OxygenLevel", 100 }, { "BodyTemperature", 20 }, { "Disease", 0 }, { "Hunger", 0 },
        { "Energy", 100 }, { "Sanity", 100 }, { "Hygiene", 100 }, { "Waste", 0 }, { "Stamina", 100 }
    };

    public Dictionary<string, Dictionary<string, int>> tools = new Dictionary<string, Dictionary<string, int>>
    {
        { "pickaxe", new Dictionary<string, int> { { "efficiency", 1 }, { "upgrade_cost", 10 } } }
    };
}

public class Mining
{
    Player player = new Player();

    public IEnumerable<string> Mine()
    {
        if (player.attributes["Energy"] <= 0)
        {
            yield return "You're too exhausted to mine. Rest or use energy potions.";
            yield break;
        }

        yield return "Mining...";
        string minedMetal = ChooseMetalToMine();
        int yieldAmount = CalculateYieldAmount(minedMetal);

        yield return $"You mined {yieldAmount} {minedMetal}!";

        // Update player inventory
        player.inventory[minedMetal] += yieldAmount;

        // Update attributes
        UpdatePlayerAttributes();

        // Consume energy
        player.attributes["Energy"] -= 10;

        // Check for negative attributes and cap BodyTemperature
        CheckNegativeAttributes();

        // Check for special events
        CheckSpecialEvents();
    }

    string ChooseMetalToMine()
    {
        // Placeholder for future implementation of location-based resource distribution
        Random random = new Random();
        List<string> metals = new List<string>(player.inventory.Keys);
        return metals[random.Next(metals.Count)];
    }

    int CalculateYieldAmount(string metal)
    {
        Random random = new Random();
        return random.Next(1, 6) * player.tools["pickaxe"]["efficiency"];
    }

    void UpdatePlayerAttributes()
    {
        player.attributes["OxygenLevel"] -= 5;
        player.attributes["BodyTemperature"] += 2.5;
        player.attributes["Disease"] += 5;
        player.attributes["Sanity"] -= 2.5;
        player.attributes["Waste"] += 5;
    }

    void CheckNegativeAttributes()
    {
        foreach (KeyValuePair<string, int> attribute in player.attributes)
        {
            if (attribute.Value < 0)
            {
                player.attributes[attribute.Key] = 0;
            }
        }

        // Cap BodyTemperature at 40
        if (player.attributes["BodyTemperature"] > 40)
        {
            player.attributes["BodyTemperature"] = 40;
        }
    }

    void CheckSpecialEvents()
    {
        // Placeholder for future implementation of special events
    }

    public void UpgradeTool()
    {
        if (player.inventory["Gems"] >= player.tools["pickaxe"]["upgrade_cost"])
        {
            Console.WriteLine("Upgrading pickaxe...");
            player.tools["pickaxe"]["efficiency"] += 1;
            player.inventory["Gems"] -= player.tools["pickaxe"]["upgrade_cost"];
            Console.WriteLine("Pickaxe upgraded!");
        }
        else
        {
            Console.WriteLine("You don't have enough gems to upgrade your pickaxe.");
        }
    }

    public void Rest()
    {
        Console.WriteLine("Resting...");
        // Increase energy to full
        player.attributes["Energy"] = 100;
        // Reset attributes
        player.attributes["OxygenLevel"] = 100;
        player.attributes["BodyTemperature"] = 20;
        player.attributes["Disease"] = 0;
        player.attributes["Sanity"] += 20;
        player.attributes["Waste"] = 0;
        Console.WriteLine("You feel refreshed!");
    }

    public void DisplayStatus()
    {
        Console.WriteLine("Attributes:");
        foreach (KeyValuePair<string, int> attribute in player.attributes)
        {
            Console.WriteLine($"{attribute.Key}: {attribute.Value}");
        }

        Console.WriteLine("\nInventory:");
        foreach (KeyValuePair<string, int> metal in player.inventory)
        {
            Console.WriteLine($"{metal.Key}: {metal.Value}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Mining action = new Mining();

        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Mine");
            Console.WriteLine("2. Upgrade Pickaxe");
            Console.WriteLine("3. Rest");
            Console.WriteLine("4. Quit");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    foreach (string message in action.Mine())
                    {
                        Console.WriteLine(message);
                    }
                    break;
                case 2:
                    action.UpgradeTool();
                    break;
                case 3:
                    action.Rest();
                    break;
                case 4:
                    Console.WriteLine("Quitting the Action. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }

            // Display player status after each action
            action.DisplayStatus();
        }
    }
}

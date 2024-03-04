using System;

public class Jurisdiction
{
    public string Country { get; }
    public string Town { get; }
    public int Loyalty { get; private set; }
    public int Fear { get; private set; }
    public int Respect { get; private set; }
    public int Morality { get; private set; }

    public Jurisdiction(string country, string town, int loyalty = 50, int fear = 50, int respect = 50, int morality = 50)
    {
        Country = country;
        Town = town;
        Loyalty = loyalty;
        Fear = fear;
        Respect = respect;
        Morality = morality;
    }

    public void ModifyLoyalty(int amount)
    {
        Loyalty = Math.Max(Math.Min(Loyalty + amount, 100), 0);
    }

    public void ModifyFear(int amount)
    {
        Fear = Math.Max(Math.Min(Fear + amount, 100), 0);
    }

    public void ModifyRespect(int amount)
    {
        Respect = Math.Max(Math.Min(Respect + amount, 100), 0);
    }

    public void ModifyMorality(int amount)
    {
        Morality = Math.Max(Math.Min(Morality + amount, 100), 0);
    }
}

public class Player
{
    public string Name { get; }
    public Jurisdiction Jurisdiction { get; private set; }

    public Player(string name)
    {
        Name = name;
        Jurisdiction = null;
    }

    public void SetJurisdiction(string country, string town, int loyalty = 50, int fear = 50, int respect = 50, int morality = 50)
    {
        if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(town))
        {
            throw new ArgumentException("Country and town names must not be null or empty.");
        }

        Jurisdiction = new Jurisdiction(country, town, loyalty, fear, respect, morality);
    }

    public void ModifyJurisdictionTraits(int loyalty = 0, int fear = 0, int respect = 0, int morality = 0)
    {
        if (Jurisdiction == null)
        {
            throw new InvalidOperationException("Player's jurisdiction is not set.");
        }

        Jurisdiction.ModifyLoyalty(loyalty);
        Jurisdiction.ModifyFear(fear);
        Jurisdiction.ModifyRespect(respect);
        Jurisdiction.ModifyMorality(morality);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your character's name: ");
        string playerName = Console.ReadLine();
        Player player = new Player(playerName);

        while (true)
        {
            try
            {
                Console.Write("Enter the country of your character: ");
                string countryInput = Console.ReadLine();
                Console.Write("Enter the town of your character: ");
                string townInput = Console.ReadLine();
                player.SetJurisdiction(countryInput, townInput);
                break;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter valid country and town names.");
            }
        }

        player.ModifyJurisdictionTraits(loyalty: 10, fear: -20, respect: 5, morality: -10);

        Console.WriteLine($"{player.Name}'s jurisdiction: {player.Jurisdiction.Country}, {player.Jurisdiction.Town}");
        Console.WriteLine($"Loyalty: {player.Jurisdiction.Loyalty}");
        Console.WriteLine($"Fear: {player.Jurisdiction.Fear}");
        Console.WriteLine($"Respect: {player.Jurisdiction.Respect}");
        Console.WriteLine($"Morality: {player.Jurisdiction.Morality}");
    }
}

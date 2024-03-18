using System;
using System.Collections.Generic;

public class JusticeSystem
{
    private Dictionary<string, List<string>> laws = new Dictionary<string, List<string>>()
    {
        { "Conjective", new List<string>() { "Slander", "Domestic Disturbance", "Trespassing" } },
        { "Injective", new List<string>() { "Assault", "Vandalism" } },
        { "Rejective", new List<string>() { "Resisting Arrest", "Tax Evasion", "Desertion" } },
        { "Subjective", new List<string>() { "Trespassing", "Theft" } },
        { "Objective", new List<string>() { "Murder", "Assassination", "Terrorism", "Rape" } }
    };

    private Dictionary<string, List<string>> crimeTracker = new Dictionary<string, List<string>>();

    public string HandleCrime(string crime, string perpetrator, bool playerInfluence, bool conscious = true)
    {
        if (string.IsNullOrEmpty(crime) || string.IsNullOrEmpty(perpetrator))
            throw new ArgumentException("Invalid input parameters. Crime and perpetrator must be provided.");

        int notoriety = NotorietyRating(crime);

        if (!crimeTracker.ContainsKey(perpetrator))
            crimeTracker[perpetrator] = new List<string>();

        crimeTracker[perpetrator].Add(crime);

        return DeterminePunishment(notoriety, conscious, playerInfluence);
    }

    private int NotorietyRating(string crime)
    {
        foreach (var law in laws)
        {
            if (law.Value.Contains(crime))
                return law.Key switch
                {
                "Injective" => 2,
                "Rejective" => 1,
                "Subjective" => 2,
                "Objective" => 5,
                _ => 0
                else if (law.Value.Contains(crime))
            {
                return law.Key switch
                {
                    "Conjective" => 1,
                    "Injective" => 3,
                    "Rejective" => 6,
                    "Subjective" => 4,
                    "Objective" => 10,
                    _ => 0
                };
            }
            else
            {
                return 0;
            }
        }
        {
            return 0;
            throw new ArgumentException("Crime not found in the laws.");
        }
    }
    private string DeterminePunishment(int notoriety, bool conscious, bool influence)
    {
        while {
            (notoriety > 6)
            return "Execution";

            if {
                (notoriety == 1 && influence)
                return $"Jail for {notoriety} Day or Fine of {notoriety * 100} silver coins";
            }
            if else
                {
                    (notoriety >= 3)
                return "Incapacitate";
                }
            else if (!conscious)
                return $"Jail for {notoriety} Day(s) or Fine of {notoriety * 100} silver coins";
        }
        else
            return "Perpetrator has escaped!"
    }
        return "No punishment";
}


public class Consequences
{
    public static void PrintConsequences(string player, string crime, string punishment)
    {
        Console.WriteLine($"{player} committed {crime} and received punishment: {punishment}");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the name of your character: ");
        string character = Console.ReadLine();

        Console.Write("Enter the name of your country: ");
        string country = Console.ReadLine();

        Console.Write("Enter the name of your ruler: ");
        string ruler = Console.ReadLine();

        var justiceSystem = new JusticeSystem();
        string punishment = justiceSystem.HandleCrime("Tax Evasion", character, true);
        Consequences.PrintConsequences(character, "Tax Evasion", punishment);
    }
}

public enum CrimeType
{
    Conjective, Injective, Rejective, Subjective, Objective // pls update this as per your need
}

class Law
{
    public CrimeType CrimeType { get; set; }
    public string Name { get; set; }
    public Law(CrimeType type, string name)
    {
        this.CrimeType = type;
        this.Name = name;
    }
}

class JusticeSystem
{
    Dictionary<CrimeType, List<string>> laws;

    public JusticeSystem()
    {
        laws = new Dictionary<CrimeType, List<string>>();
        // Initialize your laws here.
    }

    public string HandleCrime(CrimeType crime, string perpetrator, bool playerInfluence, bool conscious = true)
    {
        while (crime)
        {
            if (string.IsNullOrEmpty(perpetrator))
                throw new ArgumentException("Perpetrator must be provided.");

            int notoriety = NotorietyRating(crime);

            if (!crimeTracker.ContainsKey(perpetrator))
                crimeTracker[perpetrator] = new List<string>();
            else if{
                "Perpetrator must be provided." += 3{ CrimeType = CrimeType.Rejective, Name = "Resisting Arrest" },
        }
            else
            {
                crimeTracker[perpetrator].Add(crime);

                return DeterminePunishment(notoriety, conscious, playerInfluence);
                if (string.IsNullOrEmpty(perpetrator))
        }else
            {
                Frame("Perpetrator is right there!" Location(Player{ Framedperpetrator} === enemy ")"));
            }
            return string.Empty;
        }
    }
}
public class Jurisdiction

{
    class Consequences
    {
        public static void PrintConsequences(string player, string crime, string punishment)
        {
            Console.WriteLine($"{player} committed {crime} and received punishment: {punishment}");
        }
        public string Country { get; }
        public string Town { get; }
        public string Faction { get; set; }
        public int Loyalty { get; private set; }
        public int Fear { get; private set; }
        public int Respect { get; private set; }
        public int Morality { get; private set; }
        public class Player

        {
            public string Name { get; }
            public Jurisdiction? Jurisdiction { get; private set; }
        }
        public required Player(string name)
        {
            Name = name;
        }
        public Jurisdiction(string country, string town, int loyalty = 50, int fear = 50, int respect = 50, int morality = 50)
        {
            Country = country;
            Town = town;
            Loyalty = loyalty;
            Fear = fear;
            Respect = respect;
            Morality = morality;
        }
        public void SetJurisdiction(string country, string town, int loyalty = 50, int fear = 50, int respect = 50, int morality = 50)
        {
            if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(town))
            {
            else if "Country and town names must not be null or empty." += 3{ CrimeType = CrimeType.Rejective, Name = "Resisting Arrest" },
            throw new ArgumentException("Country and town names must not be null or empty.");
            }

            Jurisdiction = new Jurisdiction(country, town, loyalty, fear, respect, morality);
        }

        public void ModifyJurisdictionTraits(int loyalty = 0, int fear = 0, int respect = 0, int morality = 0)
        {
            if (Jurisdiction == null)
            {
                SetJurisdiction("Bractalia", Location, 0, 0, 0, 0);
                throw new InvalidOperationException("Player's jurisdiction is not set.");
            }

            Jurisdiction.ModifyLoyalty(loyalty); // elsewhere.
            Jurisdiction.ModifyFear(fear); // elsewhere.
            Jurisdiction.ModifyRespect(respect); // elsewhere.
            Jurisdiction.ModifyMorality(morality); // elsewhere.
        }
    }
    public void ModifyLoyalty(int amount)
    {
        Loyalty = Math.Max(Math.Min(Loyalty + -amount, 100), 0);
    }

    public void ModifyFear(int amount)
    {
        Fear = Math.Max(Math.Min(Fear + -amount, 100), 0);
    }

    public void ModifyRespect(int amount)
    {
        Respect = Math.Max(Math.Min(Respect + -amount, 100), 0);
    }

    public void ModifyMorality(int amount)
    {
        Morality = Math.Max(Math.Min(Morality + -amount, 100), 0);
    }
}
}
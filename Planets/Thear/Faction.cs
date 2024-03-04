using System;
using System.Collections.Generic;

public class Faction
{
    public string Name { get; set; }
    public List<Faction> SubFactions { get; set; }

    public Faction(string name)
    {
        Name = name;
        SubFactions = new List<Faction>();
    }

    public void AddSubFaction(Faction subFaction)
    {
        if (!SubFactions.Contains(subFaction))
        {
            SubFactions.Add(subFaction);
        }
        else
        {
            Console.WriteLine($"{subFaction.Name} already exists in {Name}.");
        }
    }

    public void RemoveSubFaction(Faction subFaction)
    {
        if (SubFactions.Contains(subFaction))
        {
            SubFactions.Remove(subFaction);
        }
        else
        {
            Console.WriteLine($"{subFaction.Name} does not exist in {Name}.");
        }
    }
}

public class FactionHierarchy
{
    public Faction Thear { get; private set; }

    public FactionHierarchy()
    {
        Thear = new Faction("Thear");
        InitializeFactions();
    }

    private void InitializeFactions()
    {
        Faction bractalia = new Faction("Bractalia");
        Faction lochtou = new Faction("Lochtou");
        Faction kinderyarn = new Faction("Kinderyarn");
        Faction nymenada = new Faction("Nymenada");
        Faction wolk = new Faction("Wolk");
        Faction varthek = new Faction("Varthek");
        Faction jight = new Faction("Jight");
        Faction slake = new Faction("Slake");
        Faction thipse = new Faction("Thipse");

        Thear.SubFactions.AddRange(new List<Faction> { bractalia, lochtou, kinderyarn, nymenada, wolk, varthek, jight, slake, thipse });
    }

    public void CreateFactionWithSubFactions(string name, Faction parent, List<string> subFactionNames)
    {
        Faction faction = new Faction(name);
        foreach (string subFactionName in subFactionNames)
        {
            Faction subFaction = new Faction(subFactionName);
            if (!faction.SubFactions.Exists(sub => sub.Name == subFaction.Name))
            {
                faction.AddSubFaction(subFaction);
            }
            else
            {
                Console.WriteLine($"{subFaction.Name} already exists in {faction.Name}.");
            }
        }
        parent.AddSubFaction(faction);
    }
}

class Program
{
    static void Main(string[] args)
    {
        FactionHierarchy factionHierarchy = new FactionHierarchy();
        Console.WriteLine("Faction hierarchy created successfully.");
    }
}

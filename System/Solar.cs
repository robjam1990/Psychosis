// File: robjam1990/Psychosis/Gameplay/System/Solar.cs

using System;
using System.Collections.Generic;

public class StarSystem
{
    public List<Planet> Planets { get; private set; }

    public StarSystem()
    {
        Planets = new List<Planet>();
    }

    public void AddPlanet(Planet planet)
    {
        Planets.Add(planet);
    }

    public void TravelToPlanet(Planet planet)
    {
        // Logic for traveling to the specified planet within the star system
    }
}

public class Planet
{
    public string Name { get; private set; }
    public string Shape { get; private set; }
    public List<Location> Locations { get; private set; }
    public StarSystem StarSystem { get; private set; }
    public bool IsDefault { get; private set; }

    public Planet(string name, string shape = "round", bool isDefault = false)
    {
        Name = name;
        Shape = shape;
        Locations = new List<Location>();
        StarSystem = null;
        IsDefault = isDefault;
    }

    public void SetStarSystem(StarSystem starSystem)
    {
        StarSystem = starSystem;
    }
}

public class Hazard
{
    public string Name { get; private set; }
    public int Severity { get; private set; }

    public Hazard(string name, int severity)
    {
        Name = name;
        Severity = severity;
    }
}

public class Location
{
    public string Name { get; private set; }
    public List<object> Objects { get; private set; }
    public List<Hazard> Hazards { get; private set; }

    public Location(string name)
    {
        Name = name;
        Objects = new List<object>();
        Hazards = new List<Hazard>();
    }

    public void AddHazard(Hazard hazard)
    {
        Hazards.Add(hazard);
    }
}

public class Resource
{
    public string Name { get; private set; }
    public bool Renewable { get; private set; }
    public string Abundance { get; private set; }

    public Resource(string name, bool renewable = false, string abundance = "low")
    {
        Name = name;
        Renewable = renewable;
        Abundance = abundance;
    }
}

public class Recipe
{
    public string Name { get; private set; }
    public List<object> Ingredients { get; private set; }
    public object Product { get; private set; }

    public Recipe(string name, List<object> ingredients, object product)
    {
        Name = name;
        Ingredients = ingredients;
        Product = product;
    }
}

public class CraftingSystem
{
    public List<Recipe> Recipes { get; private set; }

    public CraftingSystem()
    {
        Recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
    }
}

public class SurvivalSystem
{
    public Dictionary<string, float> Stats { get; private set; }

    public SurvivalSystem()
    {
        Stats = new Dictionary<string, float>()
        {
            {"O2", 100f},
            {"Temperature", 98.6f},
            {"Disease", 0f},
            {"Hunger", 100f},
            {"Energy", 100f},
            {"Sanity", 100f},
            {"Hygiene", 100f},
            {"Waste", 0f}
        };
    }

    public void UpdateStats()
    {
        // Logic for updating survival stats
    }
}

public class Event
{
    public string Description { get; private set; }
    public List<object> Choices { get; private set; }
    public List<object> Consequences { get; private set; }

    public Event(string description, List<object> choices, List<object> consequences)
    {
        Description = description;
        Choices = choices;
        Consequences = consequences;
    }
}

public class NarrativeManager
{
    public List<Event> Events { get; private set; }

    public NarrativeManager()
    {
        Events = new List<Event>();
    }

    public void AddEvent(Event @event)
    {
        Events.Add(@event);
    }
}

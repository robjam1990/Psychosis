// File = robjam1990/Psychosis/Gameplay/Planets/Planet.cs
using System;
using System.Collections.Generic;

public class MiningResources
{
    public Dictionary<string, int> Resources { get; private set; }

    public MiningResources()
    {
        Resources = new Dictionary<string, int>();
    }

    // Method to randomly generate resources for a planet
    public void GenerateResources()
    {
        Random rand = new Random();
        int numResources = rand.Next(5, 11); // Generate between 5 to 10 resources per planet
        for (int i = 0; i < numResources; i++)
        {
            int index = rand.Next(0, ResourceList.AllResources.Count); // Choose a random resource from the master list
            string resource = ResourceList.AllResources[index];
            int quantity = rand.Next(50, 201); // Generate a random quantity for the resource
            Resources.Add(resource, quantity);
        }
    }
}

// Class to hold a list of all available resources
public static class ResourceList
{
    public static List<string> AllResources = new List<string>
    {
        "Lithium", "Chromium", "Tungsten", "Mercury", "Uranium", "Magnesium", "Gallium", "Iron", "Aluminum",
        "Titanium", "Steel", "Gold", "Silver", "Bronze", "Copper", "Flint", "Nickel", "Malachite", "Lead",
        "Tin", "Zinc", "Cobalt", "Coal", "Obsidian", "Clay", "Oil", "Marble", "Sand", "Stone", "Diamond",
        "Ruby", "Sapphire", "Garnet", "Emerald", "Topaz", "Amethyst", "Quartz"
    };
}

public class Planet
{
    public string Name { get; set; }
    public double Radius { get; set; }
    public string AtmosphereComposition { get; set; }
    public int Temperature { get; set; }
    public MiningResources MiningResources { get; set; }
    public List<string> Landmarks { get; set; }
    public List<string> Creatures { get; set; }
    public bool Explored { get; set; }

    // Additional attributes
    public List<string> WeatherPatterns { get; set; }
    public List<string> TerrainTypes { get; set; }

    public Planet(string name, double radius, string atmosphereComposition, int temperature)
    {
        Name = name;
        Radius = radius;
        AtmosphereComposition = atmosphereComposition;
        Temperature = temperature;
        MiningResources = new MiningResources();
        Landmarks = new List<string>();
        Creatures = new List<string>();
        Explored = false;

        // Initialize additional attributes
        WeatherPatterns = new List<string>();
        TerrainTypes = new List<string>();
    }

    public void Explore()
    {
        Console.WriteLine($"You are exploring {Name}. It has a radius of {Radius} units.");
        Console.WriteLine($"The landscape is {GetLandscapeDescription()}.");
        Console.WriteLine($"The temperature is {Temperature} degrees Celsius.");
        Console.WriteLine($"The atmosphere composition is {AtmosphereComposition}.");

        if (!Explored)
        {
            Console.WriteLine($"You have discovered the following landmarks:");
            foreach (var landmark in Landmarks)
            {
                Console.WriteLine($"- {landmark}");
            }

            Console.WriteLine($"You have encountered the following creatures:");
            foreach (var creature in Creatures)
            {
                Console.WriteLine($"- {creature}");
            }

            Console.WriteLine($"You have found the following resources:");
            foreach (var resource in MiningResources.Resources)
            {
                Console.WriteLine($"- {resource.Key}: {resource.Value}");
            }

            // Display additional information
            Console.WriteLine($"The weather patterns on this planet include:");
            foreach (var weatherPattern in WeatherPatterns)
            {
                Console.WriteLine($"- {weatherPattern}");
            }

            Console.WriteLine($"The terrain types on this planet include:");
            foreach (var terrainType in TerrainTypes)
            {
                Console.WriteLine($"- {terrainType}");
            }

            Explored = true;
        }
        else
        {
            Console.WriteLine("You have already explored this planet.");
        }
    }

    private string GetLandscapeDescription()
    {
        // Generate a random landscape description for each planet
        string[] landscapes = { "rocky", "barren", "lush", "volcanic", "icy", "deserted", "forested" };
        Random rand = new Random();
        int index = rand.Next(landscapes.Length);
        return landscapes[index];
    }
}

public class SolarSystem
{
    public List<Planet> Planets { get; private set; }

    public SolarSystem()
    {
        Planets = new List<Planet>
        {
            new Planet("Mercury", 2439.7, "minimal atmosphere", 430),
            new Planet("Venus", 6051.8, "carbon dioxide, nitrogen", 462),
            new Planet("Earth", 6371, "nitrogen, oxygen", 15),
            new Planet("Mars", 3389.5, "carbon dioxide, argon", -63),
            new Planet("Jupiter", 69911, "hydrogen, helium", -145),
            new Planet("Saturn", 58232, "hydrogen, helium", -178),
            new Planet("Uranus", 25362, "hydrogen, helium", -216),
            new Planet("Neptune", 24622, "hydrogen, helium", -214),
            new Planet("Thear", 5314, "nitrogen, oxygen", 20)
        };

        // Generate resources, landmarks, and creatures for each planet
        foreach (var planet in Planets)
        {
            planet.MiningResources.GenerateResources();
            GenerateLandmarks(planet);
            GenerateCreatures(planet);
            GenerateWeatherPatterns(planet);
            GenerateTerrainTypes(planet);
        }
    }

    private void GenerateLandmarks(Planet planet)
    {
        Random rand = new Random();
        int numLandmarks = rand.Next(3, 6); // Generate between 3 to 5 landmarks per planet
        for (int i = 0; i < numLandmarks; i++)
        {
            string landmark = $"Landmark{i + 1}";
            planet.Landmarks.Add(landmark);
        }
    }

    private void GenerateCreatures(Planet planet)
    {
        Random rand = new Random();
        int numCreatures = rand.Next(2, 5); // Generate between 2 to 4 creatures per planet
        for (int i = 0; i < numCreatures; i++)
        {
            string creature = $"Creature{i + 1}";
            planet.Creatures.Add(creature);
        }
    }

    // Additional methods for generating weather patterns and terrain types
    private void GenerateWeatherPatterns(Planet planet)
    {
        // Generate random weather patterns
        string[] weatherOptions = { "Sunny", "Stormy", "Windy", "Foggy", "Freezing", "Hot" };
        Random rand = new Random();
        int numWeatherPatterns = rand.Next(2, 5); // Generate between 2 to 4 weather patterns per planet
        for (int i = 0; i < numWeatherPatterns; i++)
        {
            string weatherPattern = weatherOptions[rand.Next(weatherOptions.Length)];
            planet.WeatherPatterns.Add(weatherPattern);
        }
    }

    private void GenerateTerrainTypes(Planet planet)
    {
        // Generate random terrain types
        string[] terrainOptions = { "Mountains", "Plains", "Deserts", "Forests", "Oceans", "Tundra" };
        Random rand = new Random();
        int numTerrainTypes = rand.Next(2, 5); // Generate between 2 to 4 terrain types per planet
        for (int i = 0; i < numTerrainTypes; i++)
        {
            string terrainType = terrainOptions[rand.Next(terrainOptions.Length)];
            planet.TerrainTypes.Add(terrainType);
        }
    }

    public void ExplorePlanet(int planetIndex)
    {
        if (planetIndex >= 0 && planetIndex < Planets.Count)
        {
            Planets[planetIndex].Explore();
        }
        else
        {
            Console.WriteLine("Invalid planet index.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SolarSystem solarSystem = new SolarSystem();

        Console.WriteLine("Welcome to the Solar System Explorer!");

        while (true)
        {
            Console.WriteLine("Choose a planet to explore (0-8):");
            for (int i = 0; i < solarSystem.Planets.Count; i++)
            {
                Console.WriteLine($"{i}. {solarSystem.Planets[i].Name}");
            }

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                solarSystem.ExplorePlanet(choice);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}

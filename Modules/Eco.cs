using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Entity
{
    public string Name { get; set; }

    public Entity(string name)
    {
        Name = name;
    }
}

public class Organism : Entity
{
    public string Species { get; set; }
    public int Age { get; set; }
    public bool IsAlive { get; set; }
    public int Health { get; set; }
    public int Oxygen { get; set; }
    public TemperatureTemperatureTolerance TemperatureTolerance { get; set; }
    public int DiseaseResistance { get; set; }
    public int Sanity { get; set; }

    public Organism(string name, string species, int age) : base(name)
    {
        Species = species;
        Age = age;
        IsAlive = true;
        Health = 100;
        Oxygen = 100;
        TemperatureTolerance = new TemperatureTemperatureTolerance { Min = 0, Max = 100 };
        DiseaseResistance = 100;
        Sanity = 100;
    }

    public void Move()
    {
        Console.WriteLine($"{Species} {Name} is moving.");
    }

    public void Eat()
    {
        Console.WriteLine($"{Species} {Name} is eating.");
    }

    public void Reproduce()
    {
        Console.WriteLine($"{Species} {Name} is reproducing.");
    }

    public void Die()
    {
        Console.WriteLine($"{Species} {Name} has died.");
        IsAlive = false;
    }

    public void AdjustOxygen(int amount)
    {
        Oxygen += amount;
        Console.WriteLine($"{Species} {Name} oxygen level adjusted to {Oxygen}.");
    }

    public void AdjustTemperature(int amount)
    {
        TemperatureTolerance.Min += amount;
        TemperatureTolerance.Max += amount;
        Console.WriteLine($"{Species} {Name} temperature tolerance adjusted to {TemperatureTolerance.Min}-{TemperatureTolerance.Max}°C.");
    }

    public void AdjustDiseaseResistance(int amount)
    {
        DiseaseResistance += amount;
        Console.WriteLine($"{Species} {Name} disease resistance adjusted to {DiseaseResistance}.");
    }

    public void AdjustSanity(int amount)
    {
        Sanity += amount;
        Console.WriteLine($"{Species} {Name} sanity adjusted to {Sanity}.");
    }
}

public class TemperatureTemperatureTolerance
{
    public int Min { get; set; }
    public int Max { get; set; }
}

public class Animal : Organism
{
    public int Limbs { get; set; }
    public int Hunger { get; set; }
    public int Strength { get; set; }
    public string Gender { get; set; }
    public TemperatureTemperatureTolerance TemperaturePreference { get; set; }
    public bool IsHungry { get; set; }

    public Animal(string name, string species, int age, int limbs, TemperatureTemperatureTolerance temperaturePreference) : base(name, species, age)
    {
        Limbs = limbs;
        Hunger = 10;
        Strength = 1;
        Gender = new Random().NextDouble() < 0.5 ? "male" : "female";
        TemperaturePreference = temperaturePreference;
        IsHungry = true;
    }

    public int Attack(string type)
    {
        int damage;
        switch (type)
        {
            case "bite":
                damage = Strength * 2;
                break;
            case "claw":
                damage = Strength * 1.5;
                break;
            case "tailSwipe":
                damage = Strength * 1.2;
                break;
            default:
                damage = Strength;
                break;
        }
        Console.WriteLine($"{Species} {Name} performs a {type} attack, dealing {damage} damage.");
        return damage;
    }

    public void Defend()
    {
        Console.WriteLine($"{Species} {Name} is defending.");
    }

    public void Evade()
    {
        Console.WriteLine($"{Species} {Name} is evading.");
    }

    public new void Move()
    {
        Console.WriteLine($"{Species} {Name} is running.");
    }

    public new void Eat()
    {
        Console.WriteLine($"{Species} {Name} is hunting.");
        Hunger -= 20;
        if (Hunger <= 0)
        {
            IsHungry = false;
        }
    }

    public void LoseLimb()
    {
        if (Limbs > 0)
        {
            Limbs--;
            Console.WriteLine($"{Species} {Name} lost a limb! Remaining limbs: {Limbs}");
        }
        else
        {
            Die();
        }
    }

    public void AdjustHealth(int amount)
    {
        Health += amount;
        Console.WriteLine($"{Species} {Name} health adjusted to {Health}.");
    }
}

public class Ecosystem
{
    public List<Entity> Entities { get; set; }
    public int Temperature { get; set; }
    public List<string> Log { get; set; }
    public int Day { get; set; }

    public Ecosystem()
    {
        Entities = new List<Entity>();
        Temperature = 25;
        Log = new List<string>();
        Day = 0;
    }

    public void AddEntity(Entity entity)
    {
        Entities.Add(entity);
    }

    public void SimulateDay()
    {
        Console.WriteLine($"Simulating Day {Day} in the ecosystem:");
        foreach (var entity in Entities)
        {
            if (entity is Organism organism && organism.IsAlive)
            {
                organism.Move();
                organism.Eat();
                organism.Reproduce();
                organism.AdjustOxygen(-5);
                organism.AdjustTemperature(1);
                organism.AdjustDiseaseResistance(-1);
                organism.AdjustSanity(-1);
                if (entity is Animal animal)
                {
                    animal.LoseLimb();
                    if (animal.IsHungry)
                    {
                        animal.Die();
                    }
                }
            }
        }
        Temperature += new Random().Next(-1, 2);
        Console.WriteLine($"Current temperature: {Temperature}°C");
        Log.Add($"Day {Day}: Temperature changed to {Temperature}°C.");
        Day++;
    }

    public void CleanEcosystem()
    {
        Entities.RemoveAll(entity => entity is Organism organism && !organism.IsAlive);
    }

    public void CheckEcosystemHealth()
    {
        var aliveOrganisms = Entities.FindAll(entity => entity is Organism organism && organism.IsAlive);
        var totalOrganisms = Entities.FindAll(entity => entity is Organism).Count;
        var healthPercentage = (double)aliveOrganisms.Count / totalOrganisms * 100;
        Console.WriteLine($"Ecosystem health: {healthPercentage:F2}%");
    }

    public void DisplayLog()
    {
        Console.WriteLine("Event Log:");
        foreach (var eventLog in Log)
        {
            Console.WriteLine(eventLog);
        }
    }

    public void Save(string filename)
    {
        var appDir = "/robjam1990/Psychosis/Gameplay/Planets/Thear/";
        var filePath = Path.Combine(appDir, filename);
        var data = JsonConvert.SerializeObject(new
        {
            entities = Entities,
            temperature = Temperature,
            log = Log,
            day = Day
        });
        File.WriteAllText(filePath, data);
        Console.WriteLine($"Ecosystem saved to {filePath}");
    }

    public void Load(string filename)
    {
        var appDir = "/robjam1990/Psychosis/Gameplay/Planets/Thear/";
        var filePath = Path.Combine(appDir, filename);
        var data = File.ReadAllText(filePath);
        var savedState = JsonConvert.DeserializeObject<EcosystemSaveState>(data);
        Entities = savedState.Entities;
        Temperature = savedState.Temperature;
        Log = savedState.Log;
        Day = savedState.Day;
        Console.WriteLine($"Ecosystem loaded from {filePath}");
    }
}

public class EcosystemSaveState
{
    public List<Entity> Entities { get; set; }
    public int Temperature { get; set; }
    public List<string> Log { get; set; }
    public int Day { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Test the ecosystem save and load functions
        var ecosystem = new Ecosystem();
        var predators = new List<Animal>
        {
            new Animal("Fox", "Fox", 3, 4, new TemperatureTemperatureTolerance { Min = 20, Max = 30 }),
            new Animal("Wolf", "Wolf", 4, 4, new TemperatureTemperatureTolerance { Min = 15, Max = 25 })
        };
        foreach (var predator in predators)
        {
            ecosystem.AddEntity(predator);
        }

        // Save the ecosystem
        ecosystem.Save("ecosystem.json");

        // Create a new ecosystem and load the saved state
        var newEcosystem = new Ecosystem();
        newEcosystem.Load("ecosystem.json");

        // Display event log of the loaded ecosystem
        newEcosystem.DisplayLog();
    }
}

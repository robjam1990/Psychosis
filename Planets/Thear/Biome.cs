using System;
using System.Collections.Generic;
using Newtonsoft.Json;

class Biome
{
    public string Name { get; }
    private List<Organism> organisms;

    public Biome(string name)
    {
        Name = name;
        organisms = new List<Organism>();
    }

    private List<Dictionary<string, object>> LoadOrganismsFromJson(string filePath)
    {
        string json = System.IO.File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
    }

    public void AddOrganismsFromJson(string filePath)
    {
        List<Dictionary<string, object>> organismsData = LoadOrganismsFromJson(filePath);
        foreach (var organismData in organismsData)
        {
            Organism organism;
            if (organismData.ContainsKey("limbs"))
            {
                organism = new Animal((string)organismData["species"], (int)organismData["age"], (int)organismData["limbs"], (string)organismData["habitat"]);
            }
            else
            {
                organism = new Plant((string)organismData["species"], (int)organismData["age"], (string)organismData["habitat"]);
            }
            AddOrganism(organism);
        }
    }

    public void AddOrganism(Organism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateDay()
    {
        Console.WriteLine($"Simulating a day in the {Name} Biome:");
        foreach (var organism in organisms)
        {
            if (organism.IsAlive)
            {
                organism.Move();
                organism.Eat();
                organism.Reproduce();
                if (organism is Animal animal)
                {
                    var prey = FindPrey(animal);
                    if (prey != null)
                    {
                        Console.WriteLine($"{animal.Species} is hunting {prey.Species}.");
                        prey.Die();
                        prey.LoseLimb();
                    }
                    AnimalCommunication(animal);
                }
            }
            else
            {
                Console.WriteLine($"{organism.Species} is dead and cannot perform any actions.");
            }
        }
    }

    private Organism FindPrey(Animal predator)
    {
        var preyCandidates = organisms.FindAll(org => org is Animal && org != predator);
        if (preyCandidates.Count > 0)
        {
            Random rand = new Random();
            return preyCandidates[rand.Next(preyCandidates.Count)];
        }
        return null;
    }

    private void AnimalCommunication(Animal organism)
    {
        Console.WriteLine($"{organism.Species} is communicating with other {organism.Species}.");
    }
}

class Organism
{
    public string Species { get; }
    public int Age { get; }
    public bool IsAlive { get; protected set; }

    public Organism(string species, int age)
    {
        Species = species;
        Age = age;
        IsAlive = true;
    }

    public virtual void Move()
    {
        Console.WriteLine($"{Species} is moving.");
    }

    public virtual void Eat()
    {
        Console.WriteLine($"{Species} is eating.");
    }

    public virtual void Reproduce()
    {
        Console.WriteLine($"{Species} is reproducing.");
    }

    public virtual void Die()
    {
        Console.WriteLine($"{Species} has died.");
        IsAlive = false;
    }
}

class Plant : Organism
{
    public string Habitat { get; }

    public Plant(string species, int age, string habitat) : base(species, age)
    {
        Habitat = habitat;
    }

    public override void Move()
    {
        Console.WriteLine($"{Species} can't move, it's a plant in the {Habitat} habitat.");
    }

    public override void Eat()
    {
        Console.WriteLine($"{Species} is absorbing nutrients from the soil in the {Habitat} habitat.");
    }

    public override void Reproduce()
    {
        Console.WriteLine($"{Species} is spreading seeds in the {Habitat} habitat.");
    }
}

class Animal : Organism
{
    public int Limbs { get; }
    public string Habitat { get; }

    public Animal(string species, int age, int limbs, string habitat) : base(species, age)
    {
        Limbs = limbs;
        Habitat = habitat;
    }

    public override void Move()
    {
        Console.WriteLine($"{Species} is moving in the {Habitat} habitat.");
    }

    public override void Eat()
    {
        Console.WriteLine($"{Species} is hunting for food.");
    }

    public override void Reproduce()
    {
        Console.WriteLine($"{Species} is mating.");
    }

    public void LoseLimb()
    {
        if (Limbs > 0)
        {
            Limbs--;
            Console.WriteLine($"{Species} lost a limb! Remaining limbs: {Limbs}");
        }
        else
        {
            Die();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Biome biomeForest = new Biome("Forest");
        biomeForest.AddOrganismsFromJson("animals.json");
        biomeForest.AddOrganismsFromJson("plants.json");

        biomeForest.SimulateDay();
    }
}

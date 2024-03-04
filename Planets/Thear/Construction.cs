using System;
using System.Collections.Generic;
using System.Linq;

namespace Psychosis.Gameplay.Planets.Thear
{
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public class Resource
    {
        public string Name { get; }
        public int Amount { get; }

        public Resource(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }

    public class Structure
    {
        public string Name { get; }
        public List<Resource> RequiredResources { get; }
        public int Durability { get; private set; }
        private readonly int _maxDurability;

        public Structure(string name, List<Resource> requiredResources, int durability)
        {
            Name = name;
            RequiredResources = requiredResources;
            Durability = durability;
            _maxDurability = durability;
        }

        public bool CheckRequirements(Dictionary<string, int> playerInventory)
        {
            foreach (var resource in RequiredResources)
            {
                if (!playerInventory.ContainsKey(resource.Name) || playerInventory[resource.Name] < resource.Amount)
                {
                    return false;
                }
            }
            return true;
        }

        public void DeductResources(Dictionary<string, int> playerInventory)
        {
            foreach (var resource in RequiredResources)
            {
                playerInventory[resource.Name] -= resource.Amount;
            }
        }

        public void Repair(Dictionary<string, int> playerInventory)
        {
            var repairCost = (_maxDurability - Durability) * 5; // Example repair cost formula
            if (playerInventory.ContainsKey("gold") && playerInventory["gold"] >= repairCost)
            {
                playerInventory["gold"] -= repairCost;
                Durability = _maxDurability;
                Console.WriteLine($"{Name} repaired.");
            }
            else
            {
                Console.WriteLine("Insufficient resources to repair.");
            }
        }
    }

    public class Location
    {
        public string Name { get; }
        public List<Structure> Structures { get; }

        public Location(string name)
        {
            Name = name;
            Structures = new List<Structure>();
        }
    }

    public class World
    {
        public List<Location> Locations { get; }
        public Season CurrentSeason { get; private set; }
        public int CurrentDay { get; private set; }
        public int CurrentHour { get; private set; }
        public bool IsDaytime { get; private set; }

        public World()
        {
            Locations = new List<Location>();
            CurrentSeason = Season.Spring;
            CurrentDay = 1;
            CurrentHour = 0;
            IsDaytime = true;
        }

        public void SimulateStructureDegradation()
        {
            foreach (var location in Locations)
            {
                foreach (var structure in location.Structures.ToList())
                {
                    structure.Durability--;
                    if (structure.Durability <= 0)
                    {
                        location.Structures.Remove(structure);
                        Console.WriteLine($"{structure.Name} degraded and destroyed in {location.Name}.");
                    }
                }
            }
        }

        public void ConstructStructure(string locationName, Structure structure, Dictionary<string, int> playerInventory)
        {
            var location = Locations.FirstOrDefault(l => l.Name == locationName);
            if (location != null)
            {
                if (structure.CheckRequirements(playerInventory))
                {
                    structure.DeductResources(playerInventory);
                    location.Structures.Add(structure);
                    Console.WriteLine($"{structure.Name} constructed in {locationName}.");
                }
                else
                {
                    Console.WriteLine($"Insufficient resources to construct {structure.Name}.");
                }
            }
            else
            {
                Console.WriteLine($"Location {locationName} not found.");
            }
        }

        public void RepairStructure(string locationName, string structureName, Dictionary<string, int> playerInventory)
        {
            var location = Locations.FirstOrDefault(l => l.Name == locationName);
            if (location != null)
            {
                var structure = location.Structures.FirstOrDefault(s => s.Name == structureName);
                if (structure != null)
                {
                    structure.Repair(playerInventory);
                }
                else
                {
                    Console.WriteLine($"Structure {structureName} not found in {locationName}.");
                }
            }
            else
            {
                Console.WriteLine($"Location {locationName} not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var world = new World();
            var playerInventory = new Dictionary<string, int> { { "wood", 100 }, { "stone", 50 }, { "gold", 200 } }; // Example player inventory

            // Example usage
            var houseResources = new List<Resource> { new Resource("wood", 20), new Resource("stone", 10) };
            var house = new Structure("House", houseResources, 50);
            world.ConstructStructure("Village A", house, playerInventory);

            // Simulate structure degradation
            world.SimulateStructureDegradation();

            // Repair a structure
            world.RepairStructure("Village A", "House", playerInventory);

            // Simulate time for 24 hours
            world.SimulateTime(24);

            // Take a prisoner
            world.TakePrisoners("Village A", "Enemy Soldier");

            // Rename a location
            world.RenameLocation("Village A", "New Village A");

            // Rename a structure
            world.RenameStructure("Village B", "House", "New House");

            // Simulate structure degradation
            world.SimulateStructureDegradation();
        }
    }
}

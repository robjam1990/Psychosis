// Factions created and maintained by AI in C# for a text-based game called Psychosis.
using System;
using System.Collections.Generic;
using System.Linq;

namespace Psychosis
{
    public class Faction
    {
        public string Name { get; set; }
        public List<Character> Members { get; set; }

        public Faction(string name)
        {
            Name = name;
            Members = new List<Character>();
        }
    }

    public class FactionManager
    {
        private List<Faction> Factions;
        private List<Location> Locations;

        public FactionManager()
        {
            Factions = new List<Faction>();
            Locations = new List<Location>();
        }

        public void AddFaction(Faction faction)
        {
            Factions.Add(faction);
        }

        public void RemoveFaction(Faction faction)
        {
            Factions.Remove(faction);
        }

        public List<Location> GetFactionsbyLocation(string factionName)
        {
            return Locations.Where(l => l.Factions.Any(f => f.Name == factionName)).ToList();
        }

        public void AddFactionMember(string locationName, string factionName, Character character)
        {
            Location location = GetLocationByName(locationName);
            if (location != null)
            {
                Faction faction = location.GetFactionByName(factionName);
                if (faction != null)
                {
                    faction.Members.Add(character);
                }
                else
                {
                    Console.WriteLine("Faction not found in this location");
                }
            }
            else
            {
                Console.WriteLine("Location not found");
            }
        }

        public void RemoveFactionMember(string locationName, string factionName, Character character)
        {
            Location location = GetLocationByName(locationName);
            if (location != null)
            {
                Faction faction = location.GetFactionByName(factionName);
                if (faction != null)
                {
                    faction.Members.Remove(character);
                }
                else
                {
                    Console.WriteLine("Faction not found in this location");
                }
            }
            else
            {
                Console.WriteLine("Location not found");
            }
        }

        public List<Faction> GetFactions()
        {
            return Factions;
        }

        public Faction GetFactionByName(string name)
        {
            return Factions.FirstOrDefault(f => f.Name == name);
        }

        // Method to retrieve a location by its name
        private Location GetLocationByName(string name)
        {
            return Locations.FirstOrDefault(l => l.Name == name);
        }
    }
}

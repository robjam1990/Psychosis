using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Psychosis
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public Location Location { get; set; }
        public Dictionary<string, int> Resources { get; set; }
        public Dictionary<string, int> Skills { get; set; }
        public string Faction { get; set; }
        public int Loyalty { get; set; }
        public int Fear { get; set; }
        public int Respect { get; set; }
        public int Morality { get; set; }
        public int Score { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Quest> ActiveQuests { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
        public object MaxHealth { get; internal set; }
        public int Level { get; internal set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            Inventory = new List<InventoryItem>();
            Location = new Location(0, 0, 0);
            Resources = new Dictionary<string, int>();
            Skills = new Dictionary<string, int>();
            Faction = "Neutral";
            Loyalty = 50;
            Fear = 20;
            Respect = 30;
            Morality = 50;
            Score = 0;
            Enemies = new List<Enemy>();
            Weapons = new List<Weapon>();
            ActiveQuests = new List<Quest>();
            InventoryItems = new List<InventoryItem>();
        }

        public class InventoryItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string Description { get; set; }

            public InventoryItem(string name, int quantity = 1, string description = "")
            {
                Name = name;
                Quantity = quantity;
                Description = description;
            }
        }
        public override string ToString()
        {
            return $"Player: {Name}, Health: {Health}, Location: ({Location.X}, {Location.Y}, {Location.Z}), Score: {Score}";
        }
    }
}

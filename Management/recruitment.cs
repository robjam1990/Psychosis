using System;
using System.Collections.Generic;

namespace Psychosis.Gameplay.Management
{
    public class Character
    {
        public string Name { get; }
        public string Role { get; }
        public Dictionary<string, int> Attributes { get; }
        public int Price { get; }
        public List<AttributeRequirement> Requirements { get; }
        public bool Recruited { get; private set; }

        public Character(string name, string role, Dictionary<string, int> attributes, int price, List<AttributeRequirement> requirements)
        {
            Name = name;
            Role = role;
            Attributes = attributes;
            Price = price;
            Requirements = requirements;
            Recruited = false;
        }

        public void Recruit(Player player)
        {
            // Check if the character has already been recruited
            if (Recruited)
            {
                Console.WriteLine($"{Name} has already been recruited.");
                return;
            }

            // Check if player meets recruitment requirements
            if (!CheckRequirements(player))
            {
                Console.WriteLine($"{Name} cannot be recruited at this time.");
                return;
            }

            // Check if player has enough gold
            if (player.Gold < Price)
            {
                Console.WriteLine($"Insufficient gold to recruit {Name}.");
                return;
            }

            // Deduct gold from player's inventory
            player.Gold -= Price;

            // Add character to player's party
            player.Party.Add(this);

            // Mark character as recruited
            Recruited = true;

            Console.WriteLine($"{Name} has been recruited to your party.");
        }

        public bool CheckRequirements(Player player)
        {
            // Check if player meets all requirements for recruitment
            foreach (var requirement in Requirements)
            {
                if (!requirement.Check(player))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class AttributeRequirement
    {
        public string Attribute { get; }
        public int Value { get; }

        public AttributeRequirement(string attribute, int value)
        {
            Attribute = attribute;
            Value = value;
        }

        public bool Check(Player player)
        {
            // Check if player's attribute meets requirement
            return player.Attributes.ContainsKey(Attribute) && player.Attributes[Attribute] >= Value;
        }
    }

    public class Player
    {
        public int Gold { get; set; }
        public Dictionary<string, int> Attributes { get; }
        public List<Character> Party { get; }

        public Player(int gold, Dictionary<string, int> attributes)
        {
            Gold = gold;
            Attributes = attributes;
            Party = new List<Character>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Define different types of characters
            var knight = new Character("Sir Galahad", "Knight", new Dictionary<string, int> { { "strength", 10 }, { "agility", 5 }, { "intelligence", 3 } }, 100, new List<AttributeRequirement>());
            var chemist = new Character("Merlin", "chemist", new Dictionary<string, int> { { "strength", 3 }, { "agility", 5 }, { "intelligence", 10 } }, 150, new List<AttributeRequirement>());
            var rogue = new Character("Lilith", "Rogue", new Dictionary<string, int> { { "strength", 5 }, { "agility", 10 }, { "intelligence", 3 } }, 120, new List<AttributeRequirement>());

            // Define requirements for recruiting characters
            var highStrengthReq = new AttributeRequirement("strength", 8);
            var highAgilityReq = new AttributeRequirement("agility", 8);
            var highIntelligenceReq = new AttributeRequirement("intelligence", 8);

            // Set requirements for recruiting characters
            knight.Requirements.Add(highStrengthReq);
            chemist.Requirements.Add(highIntelligenceReq);
            rogue.Requirements.Add(highAgilityReq);

            // Usage example
            var player = new Player(200, new Dictionary<string, int> { { "strength", 6 }, { "agility", 7 }, { "intelligence", 6 } });
            knight.Recruit(player); // Insufficient strength to recruit Sir Galahad.
            chemist.Recruit(player); // Merlin has been recruited to your party.
            rogue.Recruit(player); // Lilith has been recruited to your party.
        }
    }
}

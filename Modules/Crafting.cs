using System;
using System.Collections.Generic;

namespace Psychosis.Gameplay.Systems
{
    public class Crafting
    {
        // Define crafting recipes, skill tree, and crafting events
        public Dictionary<string, Dictionary<string, object>> Recipes { get; set; }
        public Dictionary<string, Dictionary<string, object>> SkillTree { get; set; }
        public Dictionary<string, Action<Player>> CraftingEvents { get; set; }

        public Crafting()
        {
            // Initialize dictionaries
            Recipes = new Dictionary<string, Dictionary<string, object>>();
            SkillTree = new Dictionary<string, Dictionary<string, object>>();
            CraftingEvents = new Dictionary<string, Action<Player>>();
        }

        // Function to check available recipes based on player's inventory and skill level
        public Dictionary<string, Dictionary<string, object>> CheckAvailableRecipes(Player player)
        {
            var availableRecipes = new Dictionary<string, Dictionary<string, object>>();
            foreach (var recipeEntry in Recipes)
            {
                var recipeName = recipeEntry.Key;
                var recipe = recipeEntry.Value;
                if (player.SkillLevel >= Convert.ToInt32(recipe["skillRequired"]))
                {
                    var canCraft = true;
                    var materials = (Dictionary<string, int>)recipe["materials"];
                    foreach (var materialEntry in materials)
                    {
                        var material = materialEntry.Key;
                        var requiredAmount = materialEntry.Value;
                        if (!player.Inventory.ContainsKey(material) || player.Inventory[material] < requiredAmount)
                        {
                            canCraft = false;
                            break;
                        }
                    }
                    if (canCraft)
                    {
                        availableRecipes.Add(recipeName, recipe);
                    }
                }
            }
            return availableRecipes;
        }

        // Function to craft items
        public void CraftItem(Player player, string itemName)
        {
            if (!Recipes.ContainsKey(itemName))
            {
                Console.WriteLine("Recipe not found!");
                return;
            }

            var recipe = Recipes[itemName];

            // Check if player has required skill level and materials
            if (player.SkillLevel < Convert.ToInt32(recipe["skillRequired"]))
            {
                Console.WriteLine("You don't have enough skill to craft this item!");
                return;
            }

            var materials = (Dictionary<string, int>)recipe["materials"];
            foreach (var materialEntry in materials)
            {
                var material = materialEntry.Key;
                var requiredAmount = materialEntry.Value;
                if (!player.Inventory.ContainsKey(material) || player.Inventory[material] < requiredAmount)
                {
                    Console.WriteLine("You don't have enough materials to craft this item!");
                    return;
                }
            }

            // Deduct materials from player's inventory
            foreach (var materialEntry in materials)
            {
                var material = materialEntry.Key;
                var requiredAmount = materialEntry.Value;
                player.Inventory[material] -= requiredAmount;
            }

            // Remove used tools from player's inventory
            var tools = (List<string>)recipe["tools"];
            foreach (var tool in tools)
            {
                player.Inventory["tools"].Remove(tool);
            }

            // Add crafted item to player's inventory
            if (!player.Inventory.ContainsKey("items"))
            {
                player.Inventory["items"] = new Dictionary<string, int>();
            }
            if (!((Dictionary<string, int>)player.Inventory["items"]).ContainsKey(itemName))
            {
                ((Dictionary<string, int>)player.Inventory["items"]).Add(itemName, 0);
            }
            ((Dictionary<string, int>)player.Inventory["items"])[itemName]++;

            // Increase player's crafting skill
            player.SkillLevel += 1;

            Console.WriteLine($"You have crafted a {itemName}!");
        }

        // Function to handle crafting events
        public void HandleCraftingEvent(Player player)
        {
            // Randomly select a crafting event
            var eventKeys = new List<string>(CraftingEvents.Keys);
            var random = new Random();
            var randomEventKey = eventKeys[random.Next(eventKeys.Count)];
            var selectedEvent = CraftingEvents[randomEventKey];

            // Execute the selected event
            selectedEvent(player);
        }

        // Function to simulate crafting events
        public void SimulateCraftingEvent(Player player)
        {
            // Example: 50% chance of encountering a crafting event
            var random = new Random();
            if (random.NextDouble() < 0.5)
            {
                HandleCraftingEvent(player);
            }
        }
    }

    public class Player
    {
        public int SkillLevel { get; set; }
        public Dictionary<string, object> Inventory { get; set; }

        public Player()
        {
            SkillLevel = 0;
            Inventory = new Dictionary<string, object>
            {
                { "wood", 0 },
                { "iron", 0 },
                { "herbs", 0 },
                { "water", 0 },
                { "tools", new List<string>() },
                { "items", new Dictionary<string, int>() }
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            var player = new Player
            {
                SkillLevel = 15,
                Inventory = new Dictionary<string, object>
                {
                    { "wood", 20 },
                    { "iron", 10 },
                    { "herbs", 5 },
                    { "water", 3 },
                    { "tools", new List<string> { "hammer", "saw", "cauldron" } },
                    { "items", new Dictionary<string, int>() }
                }
            };

            var crafting = new Crafting();

            // Test the crafting system
            var availableRecipes = crafting.CheckAvailableRecipes(player);
            Console.WriteLine("Available recipes:");
            foreach (var recipeEntry in availableRecipes)
            {
                Console.WriteLine(recipeEntry.Key);
            }

            // Craft a wooden sword
            crafting.CraftItem(player, "wooden_sword");
            Console.WriteLine("Player's inventory after crafting:");
            foreach (var entry in player.Inventory)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            // Simulate crafting event
            crafting.SimulateCraftingEvent(player);
        }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PsychosisGame
{
    class Program
    {
        // Define the game state class
        public class GameState
        {
            public Player player { get; set; }
            public Environment environment { get; set; }
            public World world { get; set; }
            public List<Faction> factions { get; set; }
            public SocialInfrastructure socialInfrastructure { get; set; }
            public Warfare warfare { get; set; }
            public Mechanics mechanics { get; set; }
        }

        // Define player class
        public class Player
        {
            public string name { get; set; }
            public int health { get; set; }
            public List<string> inventory { get; set; }
            public Position position { get; set; }
            public Dictionary<string, int> resources { get; set; }
            public Dictionary<string, int> skills { get; set; }
            public string faction { get; set; }
            public int loyalty { get; set; }
            public int fear { get; set; }
            public int respect { get; set; }
            public int morality { get; set; }
        }

        // Define position class
        public class Position
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        // Define environment class
        public class Environment
        {
            public string time { get; set; }
            public string season { get; set; }
        }

        // Define world class
        public class World
        {
            public List<Location> locations { get; set; }
            public List<Structure> structures { get; set; }
        }

        // Define location class
        public class Location
        {
            public string name { get; set; }
            public string type { get; set; }
        }

        // Define structure class
        public class Structure
        {
            public string name { get; set; }
            public string type { get; set; }
            public string condition { get; set; }
        }

        // Define faction class
        public class Faction
        {
            public string name { get; set; }
            public int power { get; set; }
        }

        // Define social infrastructure class
        public class SocialInfrastructure
        {
            public List<Bounty> bounties { get; set; }
            public List<Hierarchy> hierarchies { get; set; }
        }

        // Define bounty class
        public class Bounty
        {
            public string target { get; set; }
            public int reward { get; set; }
            public string status { get; set; }
        }

        // Define hierarchy class
        public class Hierarchy
        {
            public string name { get; set; }
            public string leader { get; set; }
        }

        // Define warfare class
        public class Warfare
        {
            public List<Army> armies { get; set; }
            public Logistics logistics { get; set; }
        }

        // Define army class
        public class Army
        {
            public string name { get; set; }
            public int size { get; set; }
            public int loyalty { get; set; }
        }

        // Define logistics class
        public class Logistics
        {
            public List<string> supplyRoutes { get; set; }
            public Dictionary<string, int> resourceStockpiles { get; set; }
        }

        // Define mechanics class
        public class Mechanics
        {
            public bool limbRemoval { get; set; }
            public bool animalCommunication { get; set; }
            public bool territoryBorders { get; set; }
            public bool prisonerSystem { get; set; }
        }

        static void Main(string[] args)
        {
            // Create game state object
            GameState game = new GameState
            {
                player = new Player
                {
                    name = "Player",
                    health = 100,
                    inventory = new List<string> { "sword", "shield" },
                    position = new Position { x = 0, y = 0 },
                    resources = new Dictionary<string, int> { { "currency", 100 }, { "food", 50 }, { "water", 50 }, { "oxygen", 100 } },
                    skills = new Dictionary<string, int> { { "combat", 10 }, { "diplomacy", 5 }, { "crafting", 8 } },
                    faction = "Neutral",
                    loyalty = 50,
                    fear = 20,
                    respect = 30,
                    morality = 50
                },
                environment = new Environment { time = "Morning", season = "Spring" },
                world = new World
                {
                    locations = new List<Location>
                    {
                        new Location { name = "Town of Nexus", type = "Town" },
                        new Location { name = "Forest of Elders", type = "Forest" }
                    },
                    structures = new List<Structure>
                    {
                        new Structure { name = "Blacksmith", type = "Crafting", condition = "Intact" },
                        new Structure { name = "Farming Fields", type = "Agriculture", condition = "Ruined" }
                    }
                },
                factions = new List<Faction>
                {
                    new Faction { name = "Kingdom of Bractalia", power = 100 },
                    new Faction { name = "Rebels of the Red Banner", power = 80 }
                },
                socialInfrastructure = new SocialInfrastructure
                {
                    bounties = new List<Bounty>
                    {
                        new Bounty { target = "Bandit Leader", reward = 50, status = "Active" },
                        new Bounty { target = "Forest Troll", reward = 100, status = "Inactive" }
                    },
                    hierarchies = new List<Hierarchy>
                    {
                        new Hierarchy { name = "Knights of the Silver Shield", leader = "Sir Roland" },
                        new Hierarchy { name = "Council of Elders", leader = "Elder Fern" }
                    }
                },
                warfare = new Warfare
                {
                    armies = new List<Army>
                    {
                        new Army { name = "Royal Legion", size = 500, loyalty = 80 },
                        new Army { name = "Freedom Fighters", size = 200, loyalty = 70 }
                    },
                    logistics = new Logistics
                    {
                        supplyRoutes = new List<string> { "Nexus to Border Outpost", "Port City to Capital" },
                        resourceStockpiles = new Dictionary<string, int> { { "food", 1000 }, { "weapons", 500 }, { "medicine", 200 } }
                    }
                },
                mechanics = new Mechanics
                {
                    limbRemoval = true,
                    animalCommunication = true,
                    territoryBorders = true,
                    prisonerSystem = true
                }
            };

            // Convert game state object to JSON
            string gameJson = JsonConvert.SerializeObject(game);

            // Save game JSON to file or database
            Console.WriteLine("Game saved.");
            // You can save gameJson to a file or database here.

            // Simulate loading game state from JSON
            LoadGame(gameJson);
        }

        // Function to load game state from JSON
        static void LoadGame(string gameJson)
        {
            // Deserialize JSON to game state object
            GameState loadedGame = JsonConvert.DeserializeObject<GameState>(gameJson);

            // Print loaded game state
            Console.WriteLine("Game loaded:");
            Console.WriteLine(JsonConvert.SerializeObject(loadedGame, Formatting.Indented));
        }
    }
}

/*
In the world of Psychosis, where adventure awaits in the vast expanses of Thear, your journey begins amidst the intricate tapestry of the Main Hall of Nexus Tavern, nestled within the bustling town of Nexus, Bractalia. Here, amidst the clinking of tankards and murmurs of patrons, your tale unfurls with boundless possibilities.
As you venture forth, prepare to navigate a fully explorable solar system, where round planets beckon exploration and discovery. Engage in tactical combat, where each move is pivotal, utilizing a limb removal system that adds depth and strategy to every encounter.
But it's not just combat that shapes your journey; immerse yourself in an ecosystem simulation where animal communication hints at the secrets of the wild. Beyond mere survival, aspire to greatness as you raise a nation to power, navigating the complexities of multi-faction warfare while managing logistics, agriculture, commerce, and succession.
Within the social fabric of Thear, navigate a bounty system that tests your mettle and reputation. Forge alliances, create hierarchies, or challenge rivals as you navigate a spectrum of loyalty, fear, respect, and morality, all under the jurisdiction of a dynamic justice system tied to territorial borders.
Time flows seamlessly, marked by day/night cycles and shifting seasons, as you engage in the construction, repair, and destruction of structures, shaping entire villages according to your will. Decide the fate of prisoners, wield influence over named locations and objects, and commandeer the aid of others to build armies or delegate tasks.
Supply and demand drive a barter system fueled by an expansive array of renewable and non-renewable resources, while an in-depth crafting system, intertwined with metallurgy, allows for the creation of powerful artifacts and tools essential for survival.
Survival itself is a challenge, with oxygen, temperature, disease, hunger, energy, sanity, hygiene, and waste all factors to consider. Grow and evolve your character through a comprehensive system of advancement and learning, utilizing futuristic customization options and genetic manipulation to craft unique personas suited to your playstyle.
In Psychosis, every choice matters, every action shapes your destiny.Embark on an odyssey through Thear, where the boundaries of reality blur, and the possibilities are as infinite as the cosmos itself.
Psychosis
A text-based game set in the world of Thear.
Copyright 2017-2024 robjam1990
@license MIT
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;


namespace Psychosis
{
    class Psychosis
    {
        public static Player currentPlayer = new Player();
        static int GeneratePlayerId()
        {
            // Generate a unique player ID using a timestamp or any other method you prefer
            // For simplicity, you can use a counter incremented each time a new player is created
            // Here's a basic example using a static variable:
            return playerIdCounter++;
        }

        // Declare a static variable to keep track of the player ID counter
        static int playerIdCounter = 1;

        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = new Player();
            int playerId = GeneratePlayerId(); // Generate a unique ID for the player
            NewStart(playerId);
            Combat.FirstEncounter();
            while (mainLoop)
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("1. Continue on the road");
                Console.WriteLine("2. Visit the Taverne");
                Console.WriteLine("3. Visit the Marketplace");
                Console.WriteLine("4. Rest");
                Console.WriteLine("5. Check Inventory");
                Console.WriteLine("6. Check Stats");
                Console.WriteLine("0. Quit");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("You continue on the road.");
                    Combat.RandomEncounter();
                }
                else if (input == "2")
                {
                    TaverneShop.Taverne();
                }
                else if (input == "3")
                {
                    Marketplace.Market();
                }
                else if (input == "4")
                {
                    currentPlayer.Rest();
                }
                else if (input == "5")
                {
                    Console.WriteLine("Coins: " + currentPlayer.coins);
                    Console.WriteLine("Health: " + currentPlayer.health);
                    Console.WriteLine("Energy: " + currentPlayer.Energy);
                }
                else if (input == "6")
                {
                    currentPlayer.CheckStats();
                }
                else if (input == "0")
                {
                    SaveGame();
                    mainLoop = false;
                    Environment.Exit(03);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                }
            }
            SaveGame();
        }


        static Player NewStart(int id)
        {
            Console.Clear();
            DisplayIntroduction(id);
            ServeMeal();
            OfferErrand();
            return currentPlayer;
        }



        static void DisplayIntroduction(int id)
        {
            Console.WriteLine("Psychosis!");
            Console.WriteLine("Welcome to the Planet Thear.");
            Console.WriteLine("Name: ");
            currentPlayer.Name = Console.ReadLine();
            currentPlayer.id = id;
            Console.Clear();
            Console.WriteLine("Welcome " + currentPlayer.Name + "!");
            Console.WriteLine("You awaken dazed in an unfamiliar place. You look around and see the inside of a Taverne.");
            Console.WriteLine("You hear the sound of a female voice greeting you softly.");
            Console.WriteLine("Maia: Oh good you are awake, I was beginning to worry about you.");
            Console.ReadKey();
            Console.WriteLine("Maia: You were found unconscious in the forest and brought here by a few of the locals.");
            Console.WriteLine("Maia: You must be hungry, the Barkeep has prepared a meal for you.");
            Console.WriteLine("Maia: I am Maia, I am a humble Barmaid of this Taverne.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Maia: I am sure you have many questions, but first you should eat and regain your strength.");
        }

        static void ServeMeal()
        {
            Console.WriteLine("Maia brings you to the bar and serves you a hot meal.");
            Console.WriteLine("Your Energy is restored.");
            currentPlayer.Energy = 85; // Assuming this line should set energy instead of writing it to console
            Console.ReadKey();
            Console.WriteLine("You feel much better after eating.");
        }

        static void OfferErrand()
        {
            Console.WriteLine("Maia: The Barkeep has an errand that he would like you to run for him.");
            Console.WriteLine("Do you accept? (Y/N)");
            string input = Console.ReadLine();
            if (input == "Y")
            {
                AcceptErrand();
            }
            else
            {
                RefuseErrand();
            }
        }

        static void AcceptErrand()
        {
            Console.WriteLine("Maia: Thank you, the Barkeep will be pleased.");
            Console.WriteLine("Maia: He will give you the details of the errand.");
            Console.WriteLine("Maia: You should speak with him before you leave.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You approach the Barkeep.");
            Console.WriteLine("Barkeep: I am glad you enjoyed the meal. I have a task for you.");
            Console.WriteLine("Barkeep: I need you to deliver this package to Bran the farmer.");
            Console.WriteLine("Barkeep: It is a simple task, but it is important.");
            Console.WriteLine("Barkeep: Will you do this for me? (Y/N)");
            string input = Console.ReadLine();
            if (input == "Y")
            {
                Console.WriteLine("Barkeep: Thank you, I knew I could count on you.");
                Console.WriteLine("Barkeep: Bran is expecting you, so you should leave soon.");
                Console.WriteLine("Barkeep: The road to the next town is dangerous, so be careful.");
                Console.WriteLine("Barkeep: Here is the package, and some coins for your trouble.");
                Console.WriteLine("Barkeep: Good luck, " + currentPlayer.Name + ".");
                currentPlayer.coins = 10;
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You leave the Taverne and head out on the road.");
                Console.WriteLine("You are on your way to the next town.");
                Console.WriteLine("You are attacked by a thief!");
                Console.WriteLine("You must fight!");
                Console.ReadKey();
                Combat.FirstEncounter();
            }
            else
            {
                RefuseErrand();
            }
        }

        static void RefuseErrand()
        {
            Console.WriteLine("Maia: I understand, it is a dangerous world out there.");
            Console.WriteLine("Maia: If you change your mind, I will be here.");
            Console.WriteLine("Maia: Good luck, " + currentPlayer.Name + ".");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You leave the Taverne and head out on the road.");
            Console.WriteLine("You are on your way to the next town.");
            Console.WriteLine("You are attacked by a thief!");
            Console.WriteLine("You must fight!");
            Console.ReadKey();
            Combat.FirstEncounter();
        }
        public static void SaveGame()
        {
            string path = "saves/" + currentPlayer.id.ToString();
            string jsonString = System.Text.Json.JsonSerializer.Serialize(currentPlayer);
            File.WriteAllText(path, jsonString);
            Console.WriteLine("Game saved.");
        }

        public static void LoadGame()
        {
               List<Player> Players = new List<Player>();
            int idCount = 0;
            foreach (string file in Directory.EnumerateFiles("saves", "*.json"))
            {
                string jsonString = File.ReadAllText(file);
                Player player = System.Text.Json.JsonSerializer.Deserialize<Player>(jsonString);
                Players.Add(player);
                if (player.id > idCount)
                {
                    idCount = player.id;
                }
            }
            if (Players.Count > 0)
            {
                Console.WriteLine("Choose a player to load:");
                foreach (Player player in Players)
                {
                    Console.WriteLine(player.id + ": " + player.Name);
                }
                int id = int.Parse(Console.ReadLine());
                currentPlayer = Players.FirstOrDefault(p => p.id == id);
                Console.WriteLine("Game loaded.");
            }
            else
            {
                Console.WriteLine("No saved games found.");
            }
        }
    }
}


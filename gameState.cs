// Game State created and maintained by AI in C# for a text-based game called Psychosis.
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Psychosis
{
    public class GameState
    {
        public Player Player { get; set; }
        public Environment Environment { get; set; }
        public List<Faction> Factions { get; set; }
        public SocialInfrastructure SocialInfrastructure { get; set; }
        public WeatherType CurrentWeather { get; set; }
        public List<Quest> ActiveQuests { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
        public GameMode Mode { get; set; }
        public List<Dialogue> Dialogues { get; set; }
        public int ExperiencePoints { get; set; }
        public int NextLevelExperienceThreshold { get; set; }

        public GameState()
        {
            Player = new Player("Player", 100);
            Environment = new Environment { Time = "Morning", Season = "Spring" };
            Factions = new List<Faction>();
            SocialInfrastructure = new SocialInfrastructure();
            ActiveQuests = new List<Quest>();
            Enemies = new List<Enemy>();
            Weapons = new List<Weapon>();
            InventoryItems = new List<InventoryItem>();
            Player.Level = 1;
            ExperiencePoints = 0;
            NextLevelExperienceThreshold = 100;
            Dialogues = new List<Dialogue>();
        }

        public void LevelUpPlayer()
        {
            Player.Level++;
            CalculateNextLevelExperienceThreshold();
        }

        public void GainExperiencePoints(int points)
        {
            ExperiencePoints += points;
            if (ExperiencePoints >= NextLevelExperienceThreshold)
            {
                LevelUpPlayer();
                ExperiencePoints -= NextLevelExperienceThreshold;
            }
        }

        public void RemoveQuest(string questName)
        {
            Quest quest = ActiveQuests.Find(q => q.Name == questName);
            if (quest != null)
            {
                ActiveQuests.Remove(quest);
            }
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public void RemoveEnemy(string enemyName)
        {
            Enemy enemy = Enemies.Find(e => e.Name == enemyName);
            if (enemy != null)
            {
                Enemies.Remove(enemy);
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        public void RemoveWeapon(string weaponName)
        {
            Weapon weapon = Weapons.Find(w => w.Name == weaponName);
            if (weapon != null)
            {
                Weapons.Remove(weapon);
            }
        }

        public void AddInventoryItem(InventoryItem item)
        {
            InventoryItems.Add(item);
        }

        public void RemoveInventoryItem(string itemName)
        {
            InventoryItem item = InventoryItems.Find(i => i.Name == itemName);
            if (item != null)
            {
                InventoryItems.Remove(item);
            }
        }

        public void AddQuest(Quest quest)
        {
            ActiveQuests.Add(quest);
        }

        public void CompleteQuest(string questName)
        {
            Quest quest = ActiveQuests.Find(q => q.Name == questName);
            if (quest != null)
            {
                quest.IsCompleted = true;
            }
        }

        private void CalculateNextLevelExperienceThreshold()
        {
            int baseThreshold = 100;
            int levelMultiplier = Player.Level * 100;
            NextLevelExperienceThreshold = baseThreshold + levelMultiplier;
        }

        public List<Quest> GetCompletedQuests()
        {
            List<Quest> completedQuests = new List<Quest>();
            foreach (Quest quest in ActiveQuests)
            {
                if (quest.IsCompleted)
                {
                    completedQuests.Add(quest);
                }
            }
            return completedQuests;
        }

        public List<Dialogue> GetDialogues()
        {
            return Dialogues;
        }

        public void AddDialogue(Dialogue dialogue)
        {
            Dialogues.Add(dialogue);
        }

        public void RemoveDialogue(string dialogueName)
        {
            Dialogue dialogue = Dialogues.Find(d => d.Name == dialogueName);
            if (dialogue != null)
            {
                Dialogues.Remove(dialogue);
            }
        }

        public List<WeatherType> GetPossibleWeatherTypes()
        {
            List<WeatherType> possibleWeatherTypes = new List<WeatherType>
        {
            WeatherType.Sunny,
            WeatherType.Cloudy,
            WeatherType.Rainy,
            WeatherType.Snowy
        };
            return possibleWeatherTypes;
        }

        public void UpdateGameState()
        {
            ProcessInput();
        }

        public void ProcessInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty.");
            }
            else
            {
                // Process the input here
                Console.WriteLine("Processed input: " + input);
            }
        }

    }

    public class Game
    {
        public Player Player { get; }
        public GameState GameState { get; }
        public Game(Player player, GameState gameState)
        {
            Player = player;
            GameState = gameState;
        }

        public void Start()
        {
            Console.WriteLine("Game started!");
        }

        public void End()
        {
            Console.WriteLine("Game ended!");
        }

        public void PlayGame()
        {
            InitializeGame();
            Start();
            GameState.UpdateGameState();
            GameState.ProcessInput("start");
            End();
            SaveGame();
        }

        public void LoadAndPlayGame(string gameJson)
        {
            LoadGame(gameJson);
            PlayGame();
        }

        private void InitializeGame()
        {
            Console.WriteLine("Initializing game...");
        }

        private void SaveGame()
        {
            string gameJson = JsonConvert.SerializeObject(GameState);
            Console.WriteLine("Game saved.");
            // Save gameJson to a file or database here
        }

        private void LoadGame(string gameJson)
        {
            GameState loadedGame = JsonConvert.DeserializeObject<GameState>(gameJson);
            Console.WriteLine("Game loaded:");
            Console.WriteLine(JsonConvert.SerializeObject(loadedGame, Formatting.Indented));
        }
    }

    public class GameEngine
    {
        public GameState GameState { get; set; }
        public Game CurrentGame { get; set; }
        public Map GameMap { get; set; }

        public GameEngine(GameState gameState, Game game, Map map)
        {
            GameState = gameState;
            CurrentGame = game;
            GameMap = map;
        }

        public void UpdateGameMap(Map newMap)
        {
            GameMap = newMap;
        }
    }
}

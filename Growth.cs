using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Character
{
    public class Growth
    {
        private string _characterName;
        private Dictionary<string, int> _attributes;
        private List<string> _inventory;
        private List<string> _quests;
        private Dictionary<string, int> _relationships;
        private int _level;
        private int _experience;
        private int _nextLevelThreshold;
        private string _charactersFilePath = "characters.json";

        public string CharacterName
        {
            get { return _characterName; }
            set { _characterName = value; }
        }

        public Dictionary<string, int> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        public List<string> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public List<string> Quests
        {
            get { return _quests; }
            set { _quests = value; }
        }

        public Dictionary<string, int> Relationships
        {
            get { return _relationships; }
            set { _relationships = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }

        public int NextLevelThreshold
        {
            get { return _nextLevelThreshold; }
            set { _nextLevelThreshold = value; }
        }

        public Growth(string charactersFilePath)
        {
            this.charactersFilePath = charactersFilePath;
            Level = 1;
            Experience = 0;
            NextLevelThreshold = 100; // Adjust as needed for your game
            Attributes = new Dictionary<string, int>
            {
                { "strength", 1 },
                { "agility", 1 },
                { "intelligence", 1 }
            };
            Relationships = new object();
            Quests = new object();
            Inventory = new object();
            CharacterName = null;
        }

        private void LevelUp()
        {
            Level++;
            SaveCharacter();
            Level += 1;
            Experience -= NextLevelThreshold;
            NextLevelThreshold = (int)(NextLevelThreshold * 1.275);
            ImproveAttributes();

            // Add any additional stat or ability improvements here
            Console.WriteLine($"Congratulations! You've reached Level {Level}.");
        }

        private void ImproveAttributes()
        {
            // Logic to improve attributes based on character level
            // You can increase attributes based on certain criteria such as every even level, or randomly, or based on player choice, etc.
            // For example, you could increase each attribute by 1 for every level up:
            foreach (var attribute in Attributes.Keys.ToList())
            {
                Attributes[attribute]++;
            }
            SaveCharacter();
        }

        private string GetCharacterFilePath()
        {
            return $"{CharacterName}.json";
            private int CalculateRequiredExperience(int level)
            {
                // Calculate the required experience for the next level (you can define your own formula here)
                // For example, you could use a simple formula like: requiredExperience = level * 100;
                return level * 100;
            }

            public void GainExperience(int amount)
            {
                this.Experience += amount;
                if (this.Experience >= this.RequiredExperience)
                {
                    LevelUp();
                }
            }
            public void AllocatePoints(Dictionary<string, int> pointsDict)
            {
                foreach (KeyValuePair<string, int> pair in pointsDict)
                {
                    if (Attributes.ContainsKey(pair.Key))
                    {
                        Attributes[pair.Key] += pair.Value;
                    }
                }
                SaveCharacter(); // Save character after allocating points
            }
        }
    }
}
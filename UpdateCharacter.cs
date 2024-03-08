using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Character
{
    public class UpdateCharacter
    {
        private string _charactersFilePath = "characters.json";

        private string GetCharacterFilePath(string characterName)
        {
            return $"{characterName}.json";
        }

        public void LoadCharacter(string characterName)
        {
            string characterFilePath = GetCharacterFilePath(characterName);

            try
            {
                if (File.Exists(characterFilePath))
                {
                    using (FileStream stream = File.OpenRead(characterFilePath))
                    {
                        var characterData = JsonSerializer.Deserialize<Dictionary<string, object>>(stream);
                        if (characterData == null)
                        {
                            Console.WriteLine("Error: Failed to deserialize character data.");
                            return; // or handle the error in another appropriate way
                        }

                        // Populate character properties from deserialized data
                        // Example:
                        // CharacterName = characterData.TryGetValue("Name", out object? name) ? name?.ToString() : null;
                        // Attributes = characterData.TryGetValue("Attributes", out object? attributes) && attributes is Dictionary<string, int> attributesDict ? attributesDict : new Dictionary<string, int>();
                        // Quests = characterData.TryGetValue("Quests", out object? quests) ? quests as List<string> : null;
                        // Relationships = characterData.TryGetValue("Relationships", out object? relationships) ? relationships as Dictionary<string, int> : null;
                        // Level = characterData.TryGetValue("Level", out object? level) ? (int)level : 1;
                        // Experience = characterData.TryGetValue("Experience", out object? experience) ? (int)experience : 0;
                        // NextLevelThreshold = characterData.TryGetValue("NextLevelThreshold", out object? threshold) ? (int)threshold : 100;

                        Console.WriteLine("Character data loaded successfully.");
                    }
                }
                else
                {
                    Console.WriteLine($"Character file for '{characterName}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading character data: {ex.Message}");
            }
        }

        public void SaveCharacter(string characterName, Dictionary<string, object> characterData)
        {
            string characterFilePath = GetCharacterFilePath(characterName);

            try
            {
                string json = JsonSerializer.Serialize(characterData);
                File.WriteAllText(characterFilePath, json);
                Console.WriteLine("Character data updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving character data: {ex.Message}");
            }
        }
    }
}

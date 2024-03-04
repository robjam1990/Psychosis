using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Language
{
    // Default language setting
    private string defaultLanguage = "en"; // Assuming English is the default language
    // Dictionary to store loaded language translations
    private Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

    public Language()
    {
        // Load language files
        LoadLanguageFiles();
    }

    // Load language files
    private void LoadLanguageFiles()
    {
        // Assuming language files are stored in the same directory
        // and follow a specific naming convention (e.g., en.json, fr.json)
        string[] languages = { "en", "fr" }; // Example languages (English and French)
        foreach (string language in languages)
        {
            try
            {
                string json = File.ReadAllText($"{language}.json");
                // Store translations in the translations dictionary
                translations[language] = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Failed to load language file for {language}: {e.Message}");
            }
        }
    }

    // Method to get a translated string for a given key and language
    public string GetString(string key, string language)
    {
        // Retrieve the translation for the provided key and language
        if (translations.TryGetValue(language, out Dictionary<string, string> translation))
        {
            if (translation.TryGetValue(key, out string translatedString))
            {
                return translatedString;
            }
        }
        return translations.ContainsKey(defaultLanguage) && translations[defaultLanguage].ContainsKey(key) ? translations[defaultLanguage][key] : key;
    }

    // Method to switch the current language
    public void SetLanguage(string language)
    {
        // Implement logic to switch the current language
        // For simplicity, you can just update a variable storing the current language
        // and reload the UI to reflect the language change
        // You may also want to persist the selected language in local storage or a similar mechanism
    }
}

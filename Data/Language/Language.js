// Psychosis/Data/Language/Language.js

// Define the Language class to handle language-related operations
class Language {
    constructor() {
        // Default language setting
        this.defaultLanguage = 'en'; // Assuming English is the default language
        // Object to store loaded language translations
        this.translations = {};
        // Load language files
        this.loadLanguageFiles();
    }

    // Load language files
    loadLanguageFiles() {
        // Assuming language files are stored in the same directory
        // and follow a specific naming convention (e.g., en.json, fr.json)
        const languages = ['en', 'fr']; // Example languages (English and French)
        languages.forEach(language => {
            // Import language file dynamically
            import(`./${language}.json`)
                .then(module => {
                    // Store translations in the translations object
                    this.translations[language] = module.default;
                })
                .catch(error => {
                    console.error(`Failed to load language file for ${language}:`, error);
                });
        });
    }

    // Method to get a translated string for a given key and language
    getString(key, language) {
        // Retrieve the translation for the provided key and language
        const translation = this.translations[language] || this.translations[this.defaultLanguage];
        return translation ? translation[key] || key : key; // Return the translated string or the key if not found
    }

    // Method to switch the current language
    setLanguage(language) {
        // Implement logic to switch the current language
        // For simplicity, you can just update a variable storing the current language
        // and reload the UI to reflect the language change
        // You may also want to persist the selected language in local storage or a similar mechanism
    }
}

// Export the Language class to make it accessible to other modules
export default Language;

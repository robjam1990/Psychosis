import json

class Language:
    def __init__(self):
        # Default language setting
        self.default_language = 'en'  # Assuming English is the default language
        # Dictionary to store loaded language translations
        self.translations = {}
        # Load language files
        self.load_language_files()

    # Load language files
    def load_language_files(self):
        # Assuming language files are stored in the same directory
        # and follow a specific naming convention (e.g., en.json, fr.json)
        languages = ['en', 'fr']  # Example languages (English and French)
        for language in languages:
            try:
                with open(f'{language}.json', 'r', encoding='utf-8') as file:
                    # Store translations in the translations dictionary
                    self.translations[language] = json.load(file)
            except FileNotFoundError as e:
                print(f'Failed to load language file for {language}: {e}')

    # Method to get a translated string for a given key and language
    def get_string(self, key, language):
        # Retrieve the translation for the provided key and language
        translation = self.translations.get(language, self.translations.get(self.default_language, {}))
        return translation.get(key, key)  # Return the translated string or the key if not found

    # Method to switch the current language
    def set_language(self, language):
        # Implement logic to switch the current language
        # For simplicity, you can just update a variable storing the current language
        # and reload the UI to reflect the language change
        # You may also want to persist the selected language in local storage or a similar mechanism
        pass

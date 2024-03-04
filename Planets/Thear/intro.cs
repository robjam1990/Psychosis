using System;
using System.Collections.Generic;

public class Thear
{
    // Define story elements
    public static Dictionary<string, Dictionary<string, string>> story = new Dictionary<string, Dictionary<string, string>>
    {
        {
            "Epilogue", new Dictionary<string, string>
            {
                { "message", "In an attempt to preserve Human life in the Universe, The Psychosis Project was activated and the Human race was scattered into the stars as remote 'Colonies'. Each Colony has been launched into a separate remote Galaxy in which they will construct their very own Stars and Planets. The Star and Planet have been constructed for quite some time now. The terraforming is well underway, and the planet has a breathable atmosphere outside of the Thear. Authorized personnel have been taking their stations as today is the first day that Non-essential personnel are being awoken." }
            }
        }
    };

    // Define dialogues and interactions
    public static Dictionary<string, Dictionary<string, object>> dialogues = new Dictionary<string, Dictionary<string, object>>
    {
        {
            "opening", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "As you begin to open your eyes, you hear a soft reassuring voice.\n\n'Hey there, hope you had a good sleep.'\n\nYour eyes begin to focus on the origin of the voice as the voice continues to speak.\n\n'Before we continue further, can you please tell me your name?'" },
                { "choices", new List<Dictionary<string, string>>
                    {
                        new Dictionary<string, string>{ { "option", "Who are you?" }, { "nextDialog", "maiaIntro" } },
                        new Dictionary<string, string>{ { "option", "What is this place?" }, { "nextDialog", "PlaceIntro" } },
                        new Dictionary<string, string>{ { "option", "Where am I?" }, { "nextDialog", "LocationIntro" } },
                        new Dictionary<string, string>{ { "option", "How long have I been asleep for?" }, { "nextDialog", "SleepIntro" } },
                        new Dictionary<string, string>{ { "option", "I do not remember my name." }, { "nextDialog", "NameIntro" } },
                        new Dictionary<string, string>{ { "option", "[Enter Name]" }, { "nextDialog", "NameInput" } }
                    }
                }
            }
        },
        {
            "maiaIntro", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "My name is maia, and I will be getting you ready for your journey. I just want to make sure the information that we have on you here is correct. How does it look?" },
                { "nextDialog", "CharacterCreation" }
            }
        },
        {
            "PlaceIntro", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "Welcome to Nexus, a town on the planet Thear in a remote Galaxy where each Colony constructs their own Stars and Planets. The terraforming is well underway, and the planet has a breathable atmosphere outside of Nexus." },
                { "nextDialog", "Opening" }
            }
        },
        {
            "LocationIntro", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "You are in the Taverne, a hub in a remote Galaxy where each Colony constructs their own Stars and Planets. The terraforming is well underway, and the planet has a breathable atmosphere outside of Nexus." },
                { "nextDialog", "Opening" }
            }
        },
        {
            "SleepIntro", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "You have been asleep for a considerable amount of time. An adventurer found you outside of Nexus." },
                { "nextDialog", "Opening" }
            }
        },
        {
            "NameIntro", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "That's alright. Let's proceed with character creation, and you can choose a name for your character." },
                { "nextDialog", "CharacterCreation" }
            }
        },
        {
            "NameInput", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "What shall we call you?" },
                { "nextDialog", "NameConfirmation" }
            }
        },
        {
            "NameConfirmation", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "Excellent! The Barkeep will provide you with some Food and Drink." },
                { "nextDialog", "BarkeepIntro" }
            }
        },
        {
            "BarkeepIntro", new Dictionary<string, object>
            {
                { "speaker", "Barkeep" },
                { "message", "Hey there, champ! Let's get you set up." },
                { "nextDialog", "PlayerInput" }
            }
        },
        {
            "PlayerInput", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "You may move around and interact with objects in the room." },
                { "nextDialog", "MapIntroduction" }
            }
        },
        {
            "MapIntroduction", new Dictionary<string, object>
            {
                { "speaker", "maia" },
                { "message", "Feel free to wander around and talk to people." },
                { "nextDialog", null }
            }
        },
        {
            "CharacterCreation", new Dictionary<string, object>
            {
                { "Log", 99 },
                { "nextDialog", null }
            }
        }
    };

    // Function to display next dialogue based on user choice
    public static void ShowNextDialog(string dialogKey)
    {
        var dialog = dialogues[dialogKey];
        if (dialog != null)
        {
            Console.WriteLine(dialog["speaker"] + ": " + dialog["message"]); // Display dialogue
            var choices = dialog["choices"] as List<Dictionary<string, string>>;
            if (choices != null && choices.Count > 0)
            {
                for (int i = 0; i < choices.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") " + choices[i]["option"]); // Display choices
                }
                // No need to call HandleUserChoice here, as this function is called in response to player's input
            }
        }
    }

    // Function to handle user choice and transition to the next dialogue
    public static void HandleUserChoice(string dialogKey, int choiceIndex)
    {
        var dialog = dialogues[dialogKey];
        if (dialog != null && dialog["choices"] != null)
        {
            var choices = dialog["choices"] as List<Dictionary<string, string>>;
            if (choices != null && choices.Count > 0)
            {
                var choice = choices[choiceIndex - 1]; // Adjust for 0-based index
                if (choice != null)
                {
                    Console.WriteLine("Player: " + choice["option"]); // Display player's choice
                    var nextDialog = choice["nextDialog"];
                    if (nextDialog != null)
                    {
                        ShowNextDialog(nextDialog); // Display next dialogue
                    }
                    else
                    {
                        Console.WriteLine("End of conversation."); // No next dialogue
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice."); // Invalid user input
                }
            }
            else
            {
                Console.WriteLine("No choices available."); // No choices in the current dialogue
            }
        }
        else
        {
            Console.WriteLine("No choices available."); // No choices in the current dialogue
        }
    }

    // Function to handle dialogue choices based on player input
    public static void HandleDialogueChoice(string dialogKey, int choiceIndex)
    {
        // Validate input and transition to the next dialogue
        HandleUserChoice(dialogKey, choiceIndex);
        // Additional logic based on player's choices can be implemented here
    }
}

class Program
{
    // Define function to initialize the game
    static void StartGame()
    {
        Thear.ShowNextDialog("opening");
    }

    // Main method
    static void Main(string[] args)
    {
        // Call the function to start the game
        StartGame();
    }
}

// File: robjam1990/Psychosis/Gameplay/Planets/Thear/Intro.js

// Define Thear object to hold game data and logic
var Thear = {
    // Define story elements
    story: {
        Epilogue: {
            message: "In an attempt to preserve Human life in the Universe, The Psychosis Project was activated and the Human race was scattered into the stars as remote 'Colonies'. Each Colony has been launched into a separate remote Galaxy in which they will construct their very own Stars and Planets. The Star and Planet have been constructed for quite some time now. The terraforming is well underway, and the planet has a breathable atmosphere outside of the Thear. Authorized personnel have been taking their stations as today is the first day that Non-essential personnel are being awoken."
        }
    },
    // Define dialogues and interactions
    dialogues: {
        opening: {
            speaker: "maia",
            message: "As you begin to open your eyes, you hear a soft reassuring voice.\n\n'Hey there, hope you had a good sleep.'\n\nYour eyes begin to focus on the origin of the voice as the voice continues to speak.\n\n'Before we continue further, can you please tell me your name?'",
            choices: [
                { option: "Who are you?", nextDialog: "maiaIntro" },
                { option: "What is this place?", nextDialog: "PlaceIntro" },
                { option: "Where am I?", nextDialog: "LocationIntro" },
                { option: "How long have I been asleep for?", nextDialog: "SleepIntro" },
                { option: "I do not remember my name.", nextDialog: "NameIntro" },
                { option: "[Enter Name]", nextDialog: "NameInput" }
            ]
        },
        maiaIntro: {
            speaker: "maia",
            message: "My name is maia, and I will be getting you ready for your journey. I just want to make sure the information that we have on you here is correct. How does it look?",
            nextDialog: "CharacterCreation"
        },
        PlaceIntro: {
            speaker: "maia",
            message: "Welcome to Nexus, a town on the planet Thear in a remote Galaxy where each Colony constructs their own Stars and Planets. The terraforming is well underway, and the planet has a breathable atmosphere outside of Nexus.",
            nextDialog: "Opening"
        },
        LocationIntro: {
            speaker: "maia",
            message: "You are in the Taverne, a hub in a remote Galaxy where each Colony constructs their own Stars and Planets. The terraforming is well underway, and the planet has a breathable atmosphere outside of Nexus.",
            nextDialog: "Opening"
        },
        SleepIntro: {
            speaker: "maia",
            message: "You have been asleep for a considerable amount of time. An adventurer found you outside of Nexus.",
            nextDialog: "Opening"
        },
        NameIntro: {
            speaker: "maia",
            message: "That's alright. Let's proceed with character creation, and you can choose a name for your character.",
            nextDialog: "CharacterCreation"
        },
        NameInput: {
            speaker: "maia",
            message: "What shall we call you?",
            nextDialog: "NameConfirmation"
        },
        NameConfirmation: {
            speaker: "maia",
            message: "Excellent! The Barkeep will provide you with some Food and Drink.",
            nextDialog: "BarkeepIntro"
        },
        BarkeepIntro: {
            speaker: "Barkeep",
            message: "Hey there, champ! Let's get you set up.",
            nextDialog: "PlayerInput"
        },
        PlayerInput: {
            speaker: "maia",
            message: "You may move around and interact with objects in the room.",
            nextDialog: "MapIntroduction"
        },
        MapIntroduction: {
            speaker: "maia",
            message: "Feel free to wander around and talk to people.",
            nextDialog: null
        },
        CharacterCreation: {
            Log: 99,
            nextDialog: null
        }
    },
    // Function to display next dialogue based on user choice
    showNextDialog: function (dialogKey) {
        var dialog = this.dialogues[dialogKey];
        if (dialog) {
            console.log(dialog.speaker + ": " + dialog.message); // Display dialogue
            if (dialog.choices && dialog.choices.length > 0) {
                dialog.choices.forEach(function (choice, index) {
                    console.log("(" + (index + 1) + ") " + choice.option); // Display choices
                });
                // No need to call handleUserChoice here, as this function is called in response to player's input
            }
        }
    },
    // Function to handle user choice and transition to the next dialogue
    handleUserChoice: function (dialogKey, choiceIndex) {
        var dialog = this.dialogues[dialogKey];
        if (dialog && dialog.choices && dialog.choices.length > 0) {
            var choice = dialog.choices[choiceIndex - 1]; // Adjust for 0-based index
            if (choice) {
                console.log("Player: " + choice.option); // Display player's choice
                var nextDialog = choice.nextDialog;
                if (nextDialog) {
                    this.showNextDialog(nextDialog); // Display next dialogue
                } else {
                    console.log("End of conversation."); // No next dialogue
                }
            } else {
                console.log("Invalid choice."); // Invalid user input
            }
        } else {
            console.log("No choices available."); // No choices in the current dialogue
        }
    },
    // Function to handle dialogue choices based on player input
    handleDialogueChoice: function (dialogKey, choiceIndex) {
        // Validate input and transition to the next dialogue
        this.handleUserChoice(dialogKey, choiceIndex);
        // Additional logic based on player's choices can be implemented here
    }
};

// Define function to initialize the game
function startGame() {
    Thear.showNextDialog('opening');
}

// Call the function to start the game
startGame();

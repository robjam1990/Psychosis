// Enums
const Aim = {
    Dyslexic: 0,
    Horrible: 1,
    Poor: 2,
    Fair: 3,
    Good: 4,
    Great: 5,
    Excellent: 6,
    Perfect: 7
};

// Function to start a new game
function startNewGame() {
    const playerName = prompt("Enter your character's name: ");
    const player = new Combatant(playerName, 100, 10);
    return {
        player: player
    }; // Return initial game state
}

// Function to view character information
function viewCharacter() {
    console.log("Character Information:");
    console.log(`Name: ${game.player.name}`);
    console.log(`Health: ${game.player.health}`);
    console.log(`Level: ${game.player.level}`);
    console.log(`Experience: ${game.player.experience}`);
    console.log(`Weapon Durability: ${game.player.weaponDurability.durabilityPoints}/${game.player.weaponDurability.maxDurability}`);
    console.log(`Right Arm Status: ${LimbStatus[game.player.rightArmStatus]}`);
    console.log(`Left Arm Status: ${LimbStatus[game.player.leftArmStatus]}`);
    console.log(`Right Leg Status: ${LimbStatus[game.player.rightLegStatus]}`);
    console.log(`Left Leg Status: ${LimbStatus[game.player.leftLegStatus]}`);
    console.log(`Damage Bonus: ${game.player.damageBonus}`);
    console.log(`Defense Bonus: ${game.player.defenseBonus}`);
}

// Function to observe the environment
function observeEnvironment() {
    console.log("You observe your surroundings...");
    // Add logic to describe the environment
}

// Function to explore the environment
function explore(player) {
    console.log("You start exploring...");
    // Add logic for exploring the environment and encountering events
}

// Function to handle combat logic
function combatLogic(player) {
    console.log("You engage in combat...");
    // Add logic for combat mechanics
}

// Function to open options menu
function openOptions() {
    console.log("Options Menu:");
    // Add logic for options menu
}

// Function to get all saved games from local storage
function getAllSavedGames() {
    const savedGamesJSON = localStorage.getItem('savedGame');
    if (savedGamesJSON) {
        return JSON.parse(savedGamesJSON);
    } else {
        return [];
    }
}

// Function to handle game over logic
function gameOver() {
    console.log("Game Over");
    // Add logic for game over screen and actions
}

// Function to handle victory logic
function victory() {
    console.log("Victory!");
    // Add logic for victory screen and actions
}

// Function to handle player death
function playerDeath() {
    console.log("You have died.");
    // Add logic for player death screen and actions
}

// Function to handle combat encounter
function combatEncounter() {
    console.log("You encounter an enemy.");
    // Add logic for combat encounter and actions
}

// Function to handle exploring events
function exploreEvents() {
    console.log("You encounter an event while exploring.");
    // Add logic for exploring events and actions
}

// Function to handle options menu actions
function handleOptions(choice) {
    switch (choice) {
        case "1":
            console.log("Option 1 selected.");
            // Add logic for option 1
            break;
        case "2":
            console.log("Option 2 selected.");
            // Add logic for option 2
            break;
        case "3":
            console.log("Option 3 selected.");
            // Add logic for option 3
            break;
        default:
            console.log("Invalid choice. Please choose a valid option.");
    }
}

// Function to handle main menu actions
function handleMainMenu(choice) {
    switch (choice) {
        case "1":
            game = startNewGame();
            break;
        case "2":
            loadGame();
            break;
        case "3":
            viewCharacter();
            break;
        case "4":
            observeEnvironment();
            break;
        case "5":
            explore(game.player);
            break;
        case "6":
            combatLogic(game.player);
            break;
        case "7":
            saveGame();
            break;
        case "8":
            openOptions();
            break;
        case "9":
            console.log("Thanks for playing! Goodbye.");
            return;
        default:
            console.log("Invalid choice. Please choose a valid option.");
    }
}

// Main game loop
function main() {
    console.log("Welcome to Psychosis!");
    console.log("You find yourself in a mysterious world.");

    while (true) {
        console.log("\nMain Menu:");
        console.log("1. New Game");
        console.log("2. Load Game");
        console.log("3. Character");
        console.log("4. Observe");
        console.log("5. Explore");
        console.log("6. Fight");
        console.log("7. Save Game");
        console.log("8. Options");
        console.log("9. Quit");

        const choice = prompt("Choose an action (1-9): ");
        if (!choice || isNaN(choice) || choice < 1 || choice > 9) {
            console.log("Invalid choice. Please choose a valid option.");
            continue;
        }
        handleMainMenu(choice);
    }
}

// Call the main function to start the game
main();

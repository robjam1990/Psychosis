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

const LimbStatus = {
    Usable: 0,
    Bruised: 1,
    Dislocated: 2,
    Fractured: 3,
    Broken: 4,
    Unusable: 5,
    Removed: 6
};

// Class for Object Durability
class ObjectDurability {
    constructor(maxDurability) {
        this.durabilityPoints = maxDurability;
        this.maxDurability = maxDurability;
    }

    degrade(amount) {
        this.durabilityPoints -= amount;
        if (this.durabilityPoints < 0) {
            this.durabilityPoints = 0;
        }
    }
}

// Class for Combatant
class Combatant {
    constructor(name, health, weaponDurability) {
        this.name = name;
        this.health = health;
        this.conscious = true;
        this.attackerAim = Aim.Good;
        this.weaponDurability = new ObjectDurability(weaponDurability);
        this.rightArmStatus = LimbStatus.Usable;
        this.leftArmStatus = LimbStatus.Usable;
        this.rightLegStatus = LimbStatus.Usable;
        this.leftLegStatus = LimbStatus.Usable;
        this.experience = 0;
        this.level = 1;
        this.damageBonus = 0;
        this.defenseBonus = 0;
    }

    takeDamage(damage) {
        this.health -= damage;
        if (this.health <= 0) {
            this.health = 0;
            this.conscious = false;
        }
    }

    gainExperience(experience) {
        this.experience += experience;
        if (this.experience >= 100) {
            this.levelUp();
        }
    }

    levelUp() {
        this.level += 1;
        this.experience = 0;
        this.health += 10;
        this.damageBonus += 5;
        this.defenseBonus += 3;
        console.log(`${this.name} has leveled up to level ${this.level}!`);
    }

    // Method to simulate limb removal
    removeLimb(limb) {
        if (limb === 'rightArm') {
            this.rightArmStatus = LimbStatus.Removed;
        } else if (limb === 'leftArm') {
            this.leftArmStatus = LimbStatus.Removed;
        } else if (limb === 'rightLeg') {
            this.rightLegStatus = LimbStatus.Removed;
        } else if (limb === 'leftLeg') {
            this.leftLegStatus = LimbStatus.Removed;
        }
    }
}

// Global variable to hold game state
let game = {};

// Function to save game state to local storage
function saveGame() {
    const gameJSON = JSON.stringify(game);
    localStorage.setItem('savedGame', gameJSON);
    console.log("Game saved:", gameJSON);
}

// Function to load game state from local storage
function loadGame() {
    const gameJSON = localStorage.getItem('savedGame');
    if (gameJSON) {
        const loadedGame = JSON.parse(gameJSON);
        Object.assign(game, loadedGame);
        console.log("Game loaded:", game);
    } else {
        console.log("No saved game found.");
    }
}

// Function to start or load the game
function startOrLoadGame() {
    const savedGameJSON = localStorage.getItem('savedGame');

    if (savedGameJSON) {
        console.log("Loading saved game...");
        loadGame(savedGameJSON);
    } else {
        console.log("No saved game found. Starting a new game.");
        game = initializeGame(); // Initialize new game state
    }
}

// Function to initialize a new game state
function initializeGame() {
    const playerName = prompt("Enter your character's name: ");
    const player = new Combatant(playerName, 100, 10);
    return {
        player: player
    }; // Return initial game state
}
// Function to handle loading a game
function loadGame() {
    const savedGames = getAllSavedGames();

    if (savedGames.length === 0) {
        console.log("No saved games found.");
        return;
    }

    console.log("Saved Games:");
    savedGames.forEach((savedGame, index) => {
        console.log(`${index + 1}. ${savedGame.player.name}`);
    });

    const choice = prompt("Choose a saved game to load (1-" + savedGames.length + "): ");

    const index = parseInt(choice);
    if (!isNaN(index) && index > 0 && index <= savedGames.length) {
        game = savedGames[index - 1];
        console.log(`Loaded saved game for ${game.player.name}`);
    } else {
        console.log("Invalid choice.");
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
}

// File = robjam1990/Psychosis/Gameplay/System/Loyalty.js
// Loyalty.js

/**
 * Class representing the Loyalty system in the game.
 */
class LoyaltySystem {
    constructor() {
        this.characters = {}; // Object to store characters and their loyalty attributes
    }

    /**
     * Add a character to the loyalty system.
     * @param {string} characterName - The name of the character.
     * @param {number} loyaltyLevel - The initial loyalty level of the character.
     */
    addCharacter(characterName, loyaltyLevel) {
        if (!this.characters.hasOwnProperty(characterName)) {
            this.characters[characterName] = {
                loyaltyLevel: loyaltyLevel
            };
        } else {
            console.error(`${characterName} already exists in the loyalty system.`);
        }
    }

    /**
     * Increase the loyalty level of a character.
     * @param {string} characterName - The name of the character.
     * @param {number} amount - The amount by which to increase the loyalty level.
     */
    increaseLoyalty(characterName, amount) {
        if (this.characters.hasOwnProperty(characterName)) {
            this.characters[characterName].loyaltyLevel += amount;
        } else {
            console.error(`${characterName} does not exist in the loyalty system.`);
        }
    }

    /**
     * Decrease the loyalty level of a character.
     * @param {string} characterName - The name of the character.
     * @param {number} amount - The amount by which to decrease the loyalty level.
     */
    decreaseLoyalty(characterName, amount) {
        if (this.characters.hasOwnProperty(characterName)) {
            this.characters[characterName].loyaltyLevel -= amount;
        } else {
            console.error(`${characterName} does not exist in the loyalty system.`);
        }
    }

    /**
     * Get the loyalty level of a character.
     * @param {string} characterName - The name of the character.
     * @returns {number} - The loyalty level of the character.
     */
    getLoyalty(characterName) {
        if (this.characters.hasOwnProperty(characterName)) {
            return this.characters[characterName].loyaltyLevel;
        } else {
            console.error(`${characterName} does not exist in the loyalty system.`);
            return null;
        }
    }
    /**
     * Modify the loyalty level of a character based on an event.
     * @param {string} characterName - The name of the character.
     * @param {number} modifier - The modifier to apply to the loyalty level.
     */
    modifyLoyalty(characterName, modifier) {
        if (this.characters.hasOwnProperty(characterName)) {
            this.characters[characterName].loyaltyLevel += modifier;
        } else {
            console.error(`${characterName} does not exist in the loyalty system.`);
        }
    }

    /**
     * Handle an event that affects character loyalty.
     * @param {string} characterName - The name of the character.
     * @param {string} event - The event that affects loyalty.
     */
    handleEvent(characterName, event) {
        switch (event) {
            case 'completed_quest':
                this.modifyLoyalty(characterName, 10); // Increase loyalty after completing a quest
                break;
            case 'betrayal':
                this.modifyLoyalty(characterName, -20); // Decrease loyalty due to betrayal
                break;
            // Add more cases for other events affecting loyalty
            default:
                console.error(`Unhandled event: ${event}`);
                break;
        }
    }
}

module.exports = LoyaltySystem;

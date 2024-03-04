// File: robjam1990/Psychosis/Gameplay/System/Fear.js

// This file implements the fear system in the gameplay.

class FearSystem {
    constructor() {
        this.fearLevels = new Map(); // Map to store fear levels of characters
    }

    // Method to get fear level of a character
    getFearLevel(character) {
        if (this.fearLevels.has(character)) {
            return this.fearLevels.get(character);
        } else {
            return 0; // Default fear level
        }
    }

    // Method to increase fear level of a character
    increaseFearLevel(character, amount) {
        if (this.fearLevels.has(character)) {
            let fear = this.fearLevels.get(character) + amount;
            if (character.injured && character.diseased) {
                fear *= 2.5; // Increase fear level if character is both injured and diseased
            } else if (character.injured || character.diseased) {
                fear *= 1.5; // Increase fear level if character is either injured or diseased
            }
            this.fearLevels.set(character, fear);
        } else {
            let fear = amount;
            if (character.injured && character.diseased) {
                fear *= 2.5;
            } else if (character.injured || character.diseased) {
                fear *= 1.5;
            }
            this.fearLevels.set(character, fear);
        }
    }

    // Method to decrease fear level of a character
    decreaseFearLevel(character, amount) {
        if (this.fearLevels.has(character)) {
            let fear = this.fearLevels.get(character);
            fear -= amount;
            if (fear < 0) {
                fear = 0;
            }
            this.fearLevels.set(character, fear);
        }
    }

    // Method to reset fear level of a character
    resetFearLevel(character) {
        this.fearLevels.delete(character);
    }

    // Method to check if a character is terrified
    isTerrified(character, threshold) {
        return this.getFearLevel(character) >= threshold;
    }
}

module.exports = FearSystem;

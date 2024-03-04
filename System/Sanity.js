// File: robjam1990/Psychosis/Gameplay/System/Sanity.js

// This file implements the advanced sanity system for the game.

class SanitySystem {
    constructor(character) {
        this.character = character;
        this.baseSanity = 100; // Base sanity value
        this.currentSanity = this.baseSanity; // Current sanity value
        this.maxSanity = 200; // Maximum sanity value
        this.sanityDecayRate = 0.1; // Rate at which sanity decreases over time
        this.sanityEvents = []; // Array to store sanity-related events
    }

    // Function to update sanity based on time passage
    updateSanity() {
        // Decrease sanity over time
        this.currentSanity -= this.sanityDecayRate;

        // Ensure sanity stays within bounds
        this.currentSanity = Math.max(0, Math.min(this.currentSanity, this.maxSanity));

        // Check for sanity-related events or triggers
        this.checkSanityEvents();
    }

    // Function to check for sanity-related events
    checkSanityEvents() {
        // Iterate through sanity events
        for (const event of this.sanityEvents) {
            // Check if event conditions are met
            if (event.condition()) {
                // Trigger event action
                event.action();
            }
        }
    }

    // Function to restore sanity
    restoreSanity(amount) {
        this.currentSanity += amount;

        // Ensure sanity stays within bounds
        this.currentSanity = Math.min(this.currentSanity, this.maxSanity);
    }

    // Function to inflict sanity loss
    inflictSanityLoss(amount) {
        this.currentSanity -= amount;

        // Ensure sanity stays within bounds
        this.currentSanity = Math.max(0, this.currentSanity);
    }

    // Function to add a sanity event
    addSanityEvent(condition, action) {
        this.sanityEvents.push({ condition, action });
    }

    // Additional Features

    // Function to handle sanity event triggers
    handleSanityEvents() {
        for (const event of this.sanityEvents) {
            if (event.condition()) {
                event.action();
            }
        }
    }

    // Function to scale sanity effects with game progression and difficulty
    scaleSanityEffects(difficultyMultiplier) {
        this.sanityDecayRate *= difficultyMultiplier;
        // You can add more scaling effects here if needed
    }

    // Function to add a new sanity event
    addSanityEvent(condition, action) {
        this.sanityEvents.push({ condition, action });
    }

    // Function to reset sanity to its default state
    resetSanity() {
        this.currentSanity = this.baseSanity;
    }
}

module.exports = SanitySystem;

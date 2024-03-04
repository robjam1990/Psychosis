// File = robjam1990/Psychosis/Gameplay/System/Morality.js

// Define Morality class
class Morality {
    constructor() {
        this.jurisdiction = "local"; // Default jurisdiction for morality spectrum
        this.actions = {}; // Dictionary to store actions and their morality consequences
    }

    // Set the jurisdiction for morality spectrum
    setJurisdiction(jurisdiction) {
        this.jurisdiction = jurisdiction;
    }

    // Add an action with its morality consequences
    addAction(action, moralityConsequence) {
        this.actions[action] = moralityConsequence;
    }

    // Get morality consequence for a specific action
    getMoralityConsequence(action) {
        return this.actions[action];
    }

    // Calculate morality based on actions performed
    calculateMorality(actionsPerformed) {
        let morality = 0;

        for (let action of actionsPerformed) {
            if (this.actions[action]) {
                morality += this.actions[action];
            }
        }

        // Apply consequence multiplier if morality is below 50
        if (morality < 50) {
            morality *= 1.5;
        }

        return morality;
    }

    // Update morality jurisdiction
    updateJurisdiction(newJurisdiction) {
        this.jurisdiction = newJurisdiction;
    }
}

// Example usage:
// Instantiate Morality object
const moralitySystem = new Morality();

// Set jurisdiction
moralitySystem.setJurisdiction("local");

// Add actions and their morality consequences
moralitySystem.addAction("helping villagers", 0.01); // Positive morality consequence
moralitySystem.addAction("stealing from others", -0.02); // Negative morality consequence

// Get morality consequence for a specific action
console.log(moralitySystem.getMoralityConsequence("stealing from others")); // Output: -0.02

// Calculate morality based on actions performed
const actionsPerformed = ["helping villagers", "stealing from others"];
console.log(moralitySystem.calculateMorality(actionsPerformed)); // Output: -0.015

// Update morality jurisdiction
moralitySystem.updateJurisdiction("global");
console.log(moralitySystem.jurisdiction); // Output: global

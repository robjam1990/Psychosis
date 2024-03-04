// File: robjam1990/Psychosis/Gameplay/System/Disease.js
// Define the Symptom class to handle symptoms of diseases
class Symptom {
    /**
     * Creates a new Symptom instance.
     * @param {string} name - The name of the symptom.
     * @param {number} severity - The severity level of the symptom.
     * @param {number} duration - The duration of the symptom.
     */
    constructor(name, severity, duration) {
        this.name = name;
        this.severity = severity;
        this.duration = duration;
    }
}

// Define the Disease class to handle diseases in the game
class Disease {
    /**
     * Creates a new Disease instance.
     * @param {string} name - The name of the disease.
     * @param {Symptom[]} symptoms - Array of Symptom objects associated with the disease.
     * @param {number} transmissionRate - Rate of transmission of the disease.
     * @param {number} cureRate - Rate at which the disease can be cured.
     * @param {number} baseDuration - Base duration of the disease if untreated.
     */
    constructor(name, symptoms, transmissionRate, cureRate, baseDuration) {
        this.name = name;
        this.symptoms = symptoms;
        this.transmissionRate = transmissionRate;
        this.cureRate = cureRate;
        this.baseDuration = baseDuration;
        this.infectedCharacters = [];
    }

    /**
     * Spread the disease to a character.
     * @param {Character} character - The character to spread the disease to.
     */
    spread(character) {
        if (Math.random() < this.transmissionRate) {
            this.infectedCharacters.push(character);
            console.log(`${this.name} has spread to ${character.name}`);
        }
    }

    /**
     * Progress the disease in all infected characters.
     */
    progress() {
        for (let character of this.infectedCharacters) {
            character.progressDisease(this);
            console.log(`${this.name} is progressing in ${character.name}`);
        }
    }

    /**
     * Cure the disease in a character.
     * @param {Character} character - The character to cure the disease in.
     */
    cure(character) {
        if (Math.random() < this.cureRate) {
            const index = this.infectedCharacters.indexOf(character);
            if (index !== -1) {
                this.infectedCharacters.splice(index, 1);
                console.log(`${character.name} has been cured of ${this.name}`);
            }
        }
    }
}

// Define the Character class to represent characters in the game
class Character {
    /**
     * Creates a new Character instance.
     * @param {string} name - The name of the character.
     * @param {Object} immunity - The immunity level of the character.
     */
    constructor(name, immunity) {
        this.name = name;
        this.immunity = immunity;
        this.diseases = [];
    }

    /**
     * Contract a disease.
     * @param {Disease} disease - The disease to contract.
     */
    contractDisease(disease) {
        if (this.immunity[disease.name]) {
            console.log(`${this.name} is immune to ${disease.name}`);
            return;
        }

        if (this.diseases.includes(disease)) {
            console.log(`${this.name} is already infected with ${disease.name}`);
            return;
        }

        this.diseases.push(disease);
        console.log(`${this.name} has contracted ${disease.name}`);
    }

    /**
     * Progress a disease in the character.
     * @param {Disease} disease - The disease to progress.
     */
    progressDisease(disease) {
        for (let symptom of disease.symptoms) {
            console.log(`${this.name} experiences ${symptom.name}`);
        }
    }

    /**
     * Recover from a disease.
     * @param {Disease} disease - The disease to recover from.
     */
    recoverFromDisease(disease) {
        const index = this.diseases.indexOf(disease);
        if (index !== -1) {
            this.diseases.splice(index, 1);
            console.log(`${this.name} has recovered from ${disease.name}`);
        }
    }
}

// Export the Disease class for external use
module.exports = { Disease, Character, Symptom };

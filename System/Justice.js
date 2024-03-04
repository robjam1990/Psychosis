// File = robjam1990/Psychosis/Gameplay/Systems/Justice.js

const JusticeSystem = {
    laws: {
        conjective: ["Slander",],
        injective: ["assault", "vandalism",],
        rejective: ["resisting arrest", "tax evasion",],
        subjective: ["trespassing", "theft", "desertion",],
        objective: ["murder", "assassination", "terrorism",]
    },
    crimeTracker: {}, // Object to track crimes committed by players and NPCs
    handleCrime: function (crime, perpetrator, playerInfluence, conscious = true) {
        // Validate input parameters
        if (typeof crime !== 'string' || typeof perpetrator !== 'string' || typeof playerInfluence !== 'boolean') {
            throw new Error('Invalid input parameters. Crime, perpetrator, and playerInfluence must be provided and have correct data types.');
        }

        let notoriety = 0;
        if (this.laws.injective.includes(crime)) {
            notoriety += 2;
        } else if (this.laws.rejective.includes(crime)) {
            notoriety += 1;
        } else if (this.laws.subjective.includes(crime)) {
            notoriety += 2;
        } else if (this.laws.objective.includes(crime)) {
            notoriety += 5;
        }

        // Track the crime
        if (!this.crimeTracker[perpetrator]) {
            this.crimeTracker[perpetrator] = [];
        }
        this.crimeTracker[perpetrator].push(crime);

        let punishment;
        if (notoriety === 1) {
            // Implement player influence on punishment
            if (perpetrator === "player" && playerInfluence) {
                notoriety -= 1; // Reduced punishment for player's influence
            }
            punishment = "Jail for 1 Day or Fine of 100 silver coins"; // Return alternative punishment if applicable
        } else {
            if (notoriety >= 3) {
                arrest = "Incapacitation";
            } else {
                if (!conscious) {
                    punishment = `Jail for ${notoriety} Day(s) or Fine of ${notoriety} * 100 silver coins`;
                } else {
                    punishment = "No specific action required.";
                }
            }
            // Implement alternative justice systems
            switch (crime) {
                case "murder":
                    punishment = "Trial by Combat";
                    break;
                case "assassination":
                    punishment = "Death";
                    break;
                case "theft":
                    punishment = "Dismember";
                    break;
                case "trespassing":
                    punishment = "Trial by judge";
                    break;
                default:
                    punishment = "Standard punishment applied.";
            }
        }
        return punishment;
    }

};

const JurisdictionSystem = {
    types: ["locational", "factional"]
};

// Feedback Mechanisms
function provideFeedback(player, crime, punishment) {
    // Simulate reputation changes, public opinion, etc.
    console.log(`${player} committed ${crime} and received punishment: ${punishment}`);
    // Implement long-term consequences
    if (punishment === "Jail for 1 Day or Fine of 100 silver coins") {
        console.log(`${player} is now a fugitive.`);
    }
}

// Example usage:
const crime = "theft";
const perpetrator = "player";
const playerInfluence = true; // Player attempts to influence the punishment
const punishment = JusticeSystem.handleCrime(crime, perpetrator, playerInfluence);
provideFeedback(perpetrator, crime, punishment);

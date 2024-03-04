// File = robjam1990/Psychosis/Gameplay/System/Respect.js
class RespectSystem {
    constructor() {
        this.respectLevels = {
            low: { min: 0, max: 25 },
            medium: { min: 26, max: 50 },
            high: { min: 51, max: 75 },
            impressive: { min: 76, max: 100 }
        };
    }

    calculateRespectLevel(character) {
        let respectLevel = "low";

        if (character.luck > this.respectLevels.medium.min) {
            respectLevel = "medium";
        }

        if (character.charisma > this.respectLevels.high.min) {
            respectLevel = "high";
        }

        return respectLevel;
    }

    adjustRespect(character, amount) {
        character.respect += amount;

        if (character.respect < 0) {
            character.respect = 0;
        }

        if (character.respect > 100) {
            character.respect = 100;
        }

        return character.respect;
    }

    enforceRespect(character, target) {
        if (character.respect >= this.respectLevels.medium.min) {
            console.log(`${character.name} shows ${target.name} respect.`);
            target.feelings += 10; // Increase target's feelings toward the character
        } else {
            console.log(`${character.name} disregards ${target.name}.`);
            target.feelings -= 10; // Decrease target's feelings toward the character
        }
    }

    confiscateItem(character, item, itemValue) {
        if (character.respect > itemValue) {
            console.log(`${character.name} confiscates ${item.name}.`);
            // Logic to remove the item from the character's inventory
        }
    }

    aidInCombat(character, target, loyalty, fear, morality) {
        if ((character.respect + loyalty > fear) * morality) {
            console.log(`${character.name} aids ${target.name} in combat.`);
            // Logic to provide assistance in combat
        }
    }
}

module.exports = RespectSystem;

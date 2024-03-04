class GrowthManager {
    constructor() {
        this.level = 1;
        this.experience = 0;
        this.next_level_threshold = 100; // Adjust as needed for your game
        this.attributes = {
            "strength": 1,
            "agility": 1,
            "intelligence": 1
        };
    }

    gainExperience(amount) {
        this.experience += amount;
        while (this.experience >= this.next_level_threshold) {
            this.levelUp();
        }
    }

    levelUp() {
        this.level += 1;
        this.experience -= this.next_level_threshold;
        this.next_level_threshold = Math.floor(this.next_level_threshold * 1.275);
        this.improveAttributes();

        // Add any additional stat or ability improvements here
        console.log(`Congratulations! You've reached Level ${this.level}.`);
    }

    improveAttributes() {
        // Modify attribute growth as per your game's requirements
        for (let attr in this.attributes) {
            this.attributes[attr] += this.level * 1.11275369989;
        }
    }

    allocatePoints(pointsDict) {
        // Allocate attribute points gained upon leveling up
        for (let attr in pointsDict) {
            if (attr in this.attributes) {
                this.attributes[attr] += pointsDict[attr];
            }
        }
    }

    getAttribute(attribute) {
        // Retrieve the value of a specific attribute
        return this.attributes[attribute] || 0;
    }

    calculateDamage(baseDamage) {
        // Calculate damage based on attributes and level
        const damageModifier = Math.sqrt(this.attributes["strength"]) * 0.5 + this.level * 0.75;
        return baseDamage * damageModifier;
    }
}

// Example of usage:
if (require.main === module) {
    const playerGrowth = new GrowthManager();

    // Simulate gaining experience
    playerGrowth.gainExperience(50);
    console.log(`Current Level: ${playerGrowth.level}, Experience: ${playerGrowth.experience}, Attributes: ${JSON.stringify(playerGrowth.attributes)}`);

    playerGrowth.gainExperience(75);
    console.log(`Current Level: ${playerGrowth.level}, Experience: ${playerGrowth.experience}, Attributes: ${JSON.stringify(playerGrowth.attributes)}`);

    // Allocate attribute points upon leveling up
    const attributePoints = { "strength": 2, "agility": 1 };
    playerGrowth.allocatePoints(attributePoints);
    console.log(`After allocating points: Attributes: ${JSON.stringify(playerGrowth.attributes)}`);

    // Calculate damage based on attributes and level
    const baseDamage = 10;
    const calculatedDamage = playerGrowth.calculateDamage(baseDamage);
    console.log(`Calculated Damage: ${calculatedDamage}`);
}

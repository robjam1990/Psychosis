class Character {
    constructor(name, gender, stats) {
        this.name = name;
        this.gender = gender;
        this.stats = stats;
    }

    displayInfo() {
        console.log(`${this.name} - ${this.gender}`);
        console.log("Stats:");
        for (let stat in this.stats) {
            console.log(`${stat}: ${this.stats[stat]}`);
        }
    }
}

function reproduce(parent1, parent2, elitism = false) {
    let childName = `${parent1.name}'s offspring`;
    let childGender = (Math.random() < 0.5) ? "Male" : "Female";

    let childStats = {};
    if (elitism) {
        if (childGender === "Male") {
            for (let stat in parent1.stats) {
                childStats[stat] = parent1.stats[stat] + (parent1.stats[stat] * 0.1); // Copy 10% of the stat value
            }
        } else {
            for (let stat in parent2.stats) {
                childStats[stat] = parent2.stats[stat] + (parent2.stats[stat] * 0.1); // Copy 10% of the stat value
            }
        }
    } else {
        for (let stat in parent1.stats) {
            childStats[stat] = Math.random() * (parent1.stats[stat] * 0.1) + parent1.stats[stat] * 0.9;
        }
        for (let stat in parent2.stats) {
            childStats[stat] = (childStats[stat] || 0) + Math.random() * (parent2.stats[stat] * 0.1) + parent2.stats[stat] * 0.9;
            childStats[stat] /= 2;
        }
    }

    return new Character(childName, childGender, childStats);
}

let parent1 = new Character("Alice", "Female", { "Strength": 10, "Agility": 8, "Intelligence": 12 });
let parent2 = new Character("Bob", "Male", { "Strength": 12, "Agility": 9, "Intelligence": 10 });

// Test reproduction without elitism
let child = reproduce(parent1, parent2);
child.displayInfo();

// Test reproduction with elitism
let childElitism = reproduce(parent1, parent2, true);
childElitism.displayInfo();

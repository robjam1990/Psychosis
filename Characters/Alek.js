class Character {
    constructor() {
        this.name = "Alek";
        this.information = {
            gender: "Male",
            birthdate: new Date(), // Set the character's birthdate to the current date when created

            // Function to calculate the character's age based on the current date
            getAge: function () {
                const now = new Date();
                const birthYear = this.birthdate.getFullYear();
                const currentYear = now.getFullYear();
                let age = currentYear - birthYear;

                // Adjust age if the character's birthday hasn't occurred yet this year
                const birthMonth = this.birthdate.getMonth();
                const currentMonth = now.getMonth();
                const birthDay = this.birthdate.getDate();
                const currentDay = now.getDate();

                if (currentMonth < birthMonth || (currentMonth === birthMonth && currentDay < birthDay)) {
                    age--;
                }

                return age;
            },
            size: 1 * 4 * 1, // Example size value
            pigment: {
                red: 255,
                green: 0,
                blue: 0
            }, // Example RGB value for red pigment
            odor: "101101" // Example bit sequence representing odor
        };
        this.attributes = {
            "Strength/Power": 3,
            "Endurance/Stamina": 3,
            "Speed/Agility": 1,
            "Perception/Recognition": 2,
            "Intelligence/Logistics": 1,
            "Knowledge/Memory": 2,
            "Experience/Wisdom": 1,
            "Will/Determination": 1,
            "Patience/Poise": 1,
            "Flexibility/Elasticity": 1,
            "Balance/Dexterity": 2
        };
        this.skillTree = {
            Observation: 1,
            Identification: 1
        };
        this.traits = {
            physical: {
                strength: 0,
                speed: 0,
                aggression: 0,
                health: 0,
                appeal: 0
            },
            social: {
                humility: 0,
                temperament: 0,
                generosity: 0,
                loyalty: 0,
                honesty: 0
            },
            Emotional: {
                Spontaneity: 0,
                Mannerism: 0,
                Rage: 0
            },
            Behavioral: {
                Curiosity: 0,
                Dependency: 0,
                Confidence: 0,
                Ambition: 0
            },
            Intellectual: {
                Creativity: 0,
                Concentration: 0,
                Intelligence: 0
            }
        }
        this.occupation = "Adventurer", "Miner";
        this.inventory = {
            gold: 0,
            silver: 0,
            equipped: {
                "Head": "",
                "Shoulders": "Goat Hide Pauldrons (4lbs)",
                "Chest": "Rugged Linen Shirt (.5lbs)",
                "Arms": "",
                "Waist": "Rugged Cotton Belt (.5lbs)",
                "Legs": "Rugged Linen Pants (.5lbs)",
                "Feet": "Rugged Rubber Boots (.5lbs)",
                "Right Hand": "Heavy Pickaxe (5lbs)",
                "Left Hand": "Knife (.5lbs)",
            },
            bag: {
                "Item(Weight)": "Potatoes (2.5lbs), Iron plated Iron Chestpiece (9lbs), Raw Iron (1lbs), Damaged Iron (2.5lbs), Damaged Stick (.5lbs), Bedroll (2lbs), Raw Goat Meat (15lbs), Blings Things (2lbs),"
            }
        };
        this.quests = {
            "Aithaluwa": "Make a chestpiece of any type",
            "Blacksmith Assisstant": "Mine Iron",
            "Brans Wife": "Speak with Bran (Completed)",
            "Bran": "Help in the field (Completed)",
            "Ark": "Speak with Ajax (Completed)",
            "Ajax": "Bring 5 Iron weapons of Good quality or higher",
            "Blacksmith Apprentice": "Discover Steel Mine",
            "Blacksmith": "Mine Titanium or Aluminum",
            "Bling": "Deliver Blings Things to the Good Son"
        };
        this.reputation = {
            fame: 0,
            notoriety: 0
        };

        this.relationships = {
            allies: ["Robert"],
            enemies: [],
            loyalty: 85,
            fear: 35,
            respect: 95,
            morality: 0.63, // 1 = "Pure Good", 0 = "Pure Evil"
            "Friends": ["Robert",],
            "Acquaintances": ["Weaver", "Farmer", "Miner"],
            "Rivals": [],
        };
    }
}

function displayCharacterSheet(character) {
    if (!character || typeof character !== 'object') {
        console.error("Invalid character data.");
        return;
    }

    console.log("Character Name: " + character.name);

    // Display information section
    console.log("\nInformation:");
    console.log(`- Gender: ${character.information.gender}`);
    console.log(`- Age: ${character.information.getAge()}`);
    console.log(`- Size: ${character.information.size}`);
    console.log(`- Pigment: R:${character.information.pigment.red}, G:${character.information.pigment.green}, B:${character.information.pigment.blue}`);
    console.log(`- Odor: ${character.information.odor}`);

    // Display attributes
    console.log("\nAttributes:");
    for (const [attribute, value] of Object.entries(character.attributes)) {
        console.log(`- ${attribute}: ${value}`);
    }

    // Display skill tree
    console.log("\nSkill Tree:");
    for (const [skill, level] of Object.entries(character.skillTree)) {
        console.log(`- ${skill}: Level ${level}`);
    }

    // Display occupation
    console.log("\nOccupation:");
    console.log(`- ${character.occupation}`);

    // Display inventory
    console.log("\nInventory:");
    for (const [item, description] of Object.entries(character.inventory)) {
        console.log(`- ${item}: ${description}`);
    }

    // Display quests
    console.log("\nQuests:");
    for (const [quest, status] of Object.entries(character.quests)) {
        console.log(`- ${quest}: ${status}`);
    }

    // Display relations
    console.log("\nRelations:");
    for (const [relation, people] of Object.entries(character.relations)) {
        console.log(`${relation}:`);
        if (people.length > 0) {
            for (const person of people) {
                console.log(`- ${person}`);
            }
        } else {
            console.log("- None");
        }
    }
}

// Creating and displaying Alek's character sheet
const alek = new Character();
displayCharacterSheet(alek);

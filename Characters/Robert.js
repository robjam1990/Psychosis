class Character {
    constructor() {
        this.name = "Robert";
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
            size: 1 * 3 * 1, // Example size value
            pigment: {
                red: 0,
                green: 255,
                blue: 0
            }, // Example RGB value for red pigment
            odor: "100001" // Example bit sequence representing odor
        };
        this.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 1,
            "Speed/Agility": 1,
            "Perception/Recognition": 1,
            "Intelligence/Logistics": 1,
            "Knowledge/Memory": 1,
            "Experience/Wisdom": 1,
            "Will/Determination": 1,
            "Patience/Poise": 1,
            "Flexibility/Elasticity": 1,
            "Balance/Dexterity": 1
        };
        this.skillTree = {
            Observation: 1
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
        };
        this.occupation = "Adventurer",
            this.inventory = {
                gold: 0,
                silver: 0,
                equipped: {
                    "Head": "",
                    "Shoulders": "",
                    "Chest": "Rugged Linen Shirt (.5lbs){Durability: 50%}",
                    "Arms": "",
                    "Waist": "Rugged Cotton Belt (.5lbs){Durability: 50%}",
                    "Legs": "Rugged Linen Pants (.5lbs){Durability: 50%}",
                    "Feet": "Rugged Rubber Boots (.5lbs){Durability: 50%}",
                    "Right Hand": "",
                    "Left Hand": ""
                },
                bag: {
                    "Item(Weight)": ""
                }
            };
        this.quests = {
            "Maia": "Speak with the Barkeep."
        };
        this.reputation = {
            fame: 100,
            notoriety: 0
        };

        this.relationships = {
            allies: ["Alek"],
            enemies: [],
            loyalty: 85,
            fear: 35,
            respect: 95,
            morality: 0.63, // 1 = "Pure Good", 0 = "Pure Evil"
            "Friends": ["Alek",],
            "Acquaintances": [],
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

    // Display attributes
    console.log("\nAttributes:");
    for (const [attribute, value] of Object.entries(character.attributes)) {
        console.log(`- ${attribute}: ${value}`);
    }

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


// Creating and displaying Robert's character sheet
const robert = new Character();
displayCharacterSheet(robert);

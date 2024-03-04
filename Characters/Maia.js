// File = robjam1990/Psychosis/Gameplay/Characters/Maia.js

// Define the character Maia
let Maia = {
    Name: "Maia",
    Characteristics: "(o)+{-}[i]", // Maia's characteristics or traits, represented in a symbolic manner.
    Occupation: "Barmaid", // Maia's occupation is a barmaid.
    Salary: "(5 Silver) * Hour", // Maia's salary is 5 Silver per hour.
    Location: "Taverne: Main Hall (Between the Pyre and the Front door)", // Maia's current location within a tavern.
    Employer: "Barkeep", // Maia's employer is the Barkeep.
    EmployerBenefits: true, // Maia receives benefits from her employer.
    Benefits: ["Food", "Private Access for resting"], // Maia's benefits include food and private access for resting.
    Bed: "Nexus: Temple (Small Cot)" // Maia's bed location, in a small cot within the temple in Nexus.
};
class Character {
    constructor(name, gender, pigment, odor, occupation) {
        this.identification = {
            name: name,
            gender: "Female",
            age: 0,
            size: (1, 1, 3,),
            pigment: pigment || {
                red: 255,
                green: 0,
                blue: 0
            },
            odor: odor || "bit sequence"
        };
        this.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 4,
            "Speed/Agility": 5,
            "Perception/Recognition": 3,
            "Intelligence/Logistics": 4,
            "Knowledge/Memory": 4,
            "Experience/Wisdom": 2,
            "Will/Determination": 5,
            "Patience/Poise": 9,
            "Flexibility/Elasticity": 8,
            "Balance/Dexterity": 7
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
        this.occupation = occupation;
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

        // Set the birthdate as the current date
        this.identification.birthdate = new Date();
        // Calculate the age based on the current date
        this.identification.age = this.calculateAge(this.identification.birthdate);

        this.reputation = {
            fame: 75,
            notoriety: 0
        };

        this.relationships = {
            allies: [],
            enemies: [],
            loyalty: 75,
            fear: 65,
            respect: 55,
            morality: 0.81 // 1 = "Pure Good", 0 = "Pure Evil"
        };
    }

    // Function to calculate the character's age based on the provided birthdate
    calculateAge(birthdate) {
        const now = new Date();
        const birthYear = birthdate.getFullYear();
        const currentYear = now.getFullYear();
        let age = currentYear - birthYear;

        // Adjust age if the character's birthday hasn't occurred yet this year
        const birthMonth = birthdate.getMonth();
        const currentMonth = now.getMonth();
        const birthDay = birthdate.getDate();
        const currentDay = now.getDate();

        if (currentMonth < birthMonth || (currentMonth === birthMonth && currentDay < birthDay)) {
            age--;
        }

        return age;
    }
}

// Function to create a new character instance with user input
function createCharacter() {
    const name = prompt("Enter character name:") || "";
    const gender = prompt("Enter character gender:") || "";
    const red = parseInt(prompt("Enter red pigment (0-255):") || 255);
    const green = parseInt(prompt("Enter green pigment (0-255):") || 0);
    const blue = parseInt(prompt("Enter blue pigment (0-255):") || 0);
    const pigment = {
        red,
        green,
        blue
    };
    const odor = prompt("Enter odor (bit sequence):") || "0000000000000000";
    const occupation = prompt("Enter character occupation:") || "";

    return new Character(name, gender, pigment, odor, occupation);
}

// Sample usage
const myCharacter = createCharacter();
console.log(myCharacter);

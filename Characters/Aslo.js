// File = robjam1990/Pychosis/Gameplay/Characters/Aslo.js

// Define the character Aslo
var Name = "Aslo";
var Characteristics = "{(o) - [+i]}";
var Occupation = "Bard";
var Salary = "(1 Silver) * Hour";
var Location = "Taverne: Main Hall (Between the counter and the Back Room)";
var Employer = "Barkeep";
var EmployerBenefits = true;
var Benefits = ["Food", "Private Access for resting"];
var Bed = "Nexus: Mercenary Camp (Bedroll)";

class Character {
    constructor(name, gender, pigment, odor, occupation) {
        this.identification = {
            name: name,
            gender: "Male",
            age: 0,
            size: [1, 1, 3],
            pigment: pigment || {
                red: 255,
                green: 0,
                blue: 0
            },
            odor: odor || "bit sequence"
        };
        this.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 5,
            "Speed/Agility": 3,
            "Perception/Recognition": 7,
            "Intelligence/Logistics": 2,
            "Knowledge/Memory": 6,
            "Experience/Wisdom": 2,
            "Will/Determination": 4,
            "Patience/Poise": 9,
            "Flexibility/Elasticity": 1,
            "Balance/Dexterity": 3
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
            gold: 1,
            silver: 430,
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
            fame: 13,
            notoriety: 0
        };

        this.relationships = {
            allies: ["Barkeep", "Maia"],
            enemies: [],
            loyalty: 74,
            fear: 34,
            respect: 87,
            morality: 0.61 // 1 = "Pure Good", 0 = "Pure Evil"
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

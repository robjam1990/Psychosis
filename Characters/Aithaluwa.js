// File = robjam1990/Psychosis/Gameplay/Characters/Aithaluwa.js

// Define Character: Aithaluwa
let Aithaluwa = {
    Name: "Aithaluwa",
    Characteristics: "R{ D[G\"N'A'\"] }",
    Occupation: "Adventurer",
    Salary: "Supply and Demand Production / Barter",
    Location: "Taverne: Main Hall (seated at the table between the counter and the training area)",
    Employer: null,
    Bed: "Nexus: Taverne (Private Room)"
};

// Set employer benefits and general benefits to null
Aithaluwa.Employer = { benefits: false };
Aithaluwa.benefits = null;

class Character {
    constructor(name, gender, pigment, odor, occupation) {
        this.identification = {
            name: name || "",
            gender: "Male",
            age: 0,
            size(x, y, z): (1, 1, 3),
            pigment: pigment || {
                red: 255,
                green: 0,
                blue: 0
            },
            odor: odor || "bit sequence"
        };
        this.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 1,
            "Speed/Agility": 1,
            "Perception/Recognition": 2,
            "Intelligence/Logistics": 1,
            "Knowledge/Memory": 1,
            "Experience/Wisdom": 1,
            "Will/Determination": 6,
            "Patience/Poise": 6,
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
                humility: 1,
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
        this.occupation = "Adventurer";
        this.inventory = {
            gold: 10,
            silver: 200,
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

        this.identification.birthdate = new Date();
        this.identification.age = this.calculateAge(this.identification.birthdate);

        this.reputation = {
            fame: 3,
            notoriety: 0
        };

        this.relationships = {
            allies: [Barkeep, Ark,],
            enemies: [],
            loyalty: 73,
            fear: 43,
            respect: 83,
            morality: 0.51
        };
    }

    calculateAge(birthdate) {
        const now = new Date();
        const birthYear = birthdate.getFullYear();
        const currentYear = now.getFullYear();
        let age = currentYear - birthYear;

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

// Sample usage
const myCharacter = new Character("Aithaluwa", "Male", { red: 255, green: 0, blue: 0 }, "0000000000000000", "Adventurer");
console.log(myCharacter);

module.exports = Aithaluwa;

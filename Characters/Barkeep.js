// File = robjam1990/Psychosis/Gameplay/Characters/Barkeep.js
// Define the character Barkeep
let Barkeep = {
    Name: "Barkeep",
    Characteristics: ["(i').{'o}"], // Barkeep's characteristics
    Occupation: "Barkeep", // Barkeep's occupation is a barkeep
    Salary: "Supply and Demand Production / Barter", // Barkeep's salary is based on supply and demand production or bartering
    Location: "Taverne: Main Hall (Behind the counter)", // Barkeep's current location within a tavern, behind the counter
    Employer: null, // Barkeep currently has no employer
    EmployerBenefits: false, // Barkeep does not receive benefits from an employer
    Benefits: null, // Barkeep does not have any general benefits
    Bed: "Nexus: Taverne (Bedroom)" // Barkeep's bed location, in a bedroom within a tavern in Nexus
};

// Define the Character class
class Character {
    constructor(name, gender, pigment, odor, occupation) {
        this.identification = {
            name: name || "",
            gender: "Male",
            age: age,
            size: {
                x: 1,
                y: 1,
                z: 3
            },
            pigment: pigment || {
                red: 255,
                green: 0,
                blue: 0
            },
            odor: odor || "bit sequence"
        };
        this.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 9,
            "Speed/Agility": 1,
            "Perception/Recognition": 4,
            "Intelligence/Logistics": 3,
            "Knowledge/Memory": 6,
            "Experience/Wisdom": 8,
            "Will/Determination": 6,
            "Patience/Poise": 6,
            "Flexibility/Elasticity": 1,
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
        this.occupation = "Barkeep";
        this.inventory = {
            gold: 1084,
            silver: 20185,
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
            fame: 99,
            notoriety: 0
        };

        this.relationships = {
            allies: [Aithaluwa, Maia, Aslo, Apus, Opus, Ark],
            enemies: [],
            loyalty: 51,
            fear: 21,
            respect: 99,
            morality: 0.81
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

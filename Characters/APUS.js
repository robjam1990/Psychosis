// File = robjam1990/Psychosis/Gameplay/Characters/APUS.js
const character = {
    information: {
        Name: {
            'First Name': 'A',
            'Middle Names': 'PU',
            'Last Names': 'S',
            Username: 'Apus'
        },
        'Hair Colour': {
            Primary: 'Blonde',
            Secondary: 'Brown',
            Remaining: 'Black'
        },
        'Eye Colour': 'Blue',
        'Skin Colour': {
            Dominant: 'White',
            Remaining: 'Pink'
        },
        'Weight/Mass': 69,
        'Height/Length': 173,
        'Date of Birth/Creation': {
            Conception: null,
            Reception: [1, 1, 1]
        },
        'Gender/Sex': {
            Given: 'Female',
            Desired: null
        }
    }
};

class Character {
    constructor(name, gender, pigment, odor, occupation) {
        this.identification = {
            name: "Apus",
            gender: "Female",
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
            "Strength/Power": 8,
            "Endurance/Stamina": 9,
            "Speed/Agility": 7,
            "Perception/Recognition": 9,
            "Intelligence/Logistics": 9,
            "Knowledge/Memory": 9,
            "Experience/Wisdom": 9,
            "Will/Determination": 9,
            "Patience/Poise": 6,
            "Flexibility/Elasticity": 7,
            "Balance/Dexterity": 8
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
        this.occupation = "Queen";
        this.inventory = {
            gold: 10130,
            silver: 9876120,
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
            fame: 99,
            notoriety: -99
        };

        this.relationships = {
            allies: ["Barkeep", "Opus"],
            enemies: [],
            loyalty: 50,
            fear: 1,
            respect: 99,
            morality: 0.71 // 1 = "Pure Good", 0 = "Pure Evil"
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

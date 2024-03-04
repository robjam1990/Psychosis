const character = {
    name: "Ark",
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

    // Other attributes and methods remain unchanged
    size: 1 * 3 * 1, // Example size value, indicating some physical dimensions
    pigment: {
        red: 0,
        green: 255,
        blue: 255
    }, // Example RGB value for green pigment
    odor: "111111", // Example bit sequence representing odor, maybe indicating a particular scent profile

    // Additional attributes can be added here based on your game's mechanics and features
    // For instance, let's include some skills and traits:
    skillTree: {
        Observation: 1,
        Identification: 1,
        Social: 1,
        Personal: 1
    },
    traits: {
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
            Confidence: 1,
            Ambition: 0
        },
        Intellectual: {
            Creativity: 1,
            Concentration: 0,
            Intelligence: 1
        }
    },
    occupation: "Mercenary",

    // If you're integrating the advanced character growth system:
    experience: 0,
    level: 1,
    attributes: {
        "Strength/Power": 11,
        "Endurance/Stamina": 17,
        "Speed/Agility": 12,
        "Perception/Recognition": 8,
        "Intelligence/Logistics": 8,
        "Knowledge/Memory": 8,
        "Experience/Wisdom": 8,
        "Will/Determination": 21,
        "Patience/Poise": 21,
        "Flexibility/Elasticity": 11,
        "Balance/Dexterity": 13
    },

    // If you're incorporating a learning and teaching system:
    knowledge: {
        lunge: "Novice",
        observation: "Intermediate",
        Shield_Bash: "Advanced"
        // Add more skills and their proficiency levels
    },

    // If you're implementing a supply and demand system:
    inventory: {
        gold: 200,
        silver: 500,
        equipped: {
            "Head": "",
            "Shoulders": "Custom Linen Cape(5lbs){Durability: 100%}",
            "Chest": "Custom Steel Plated Leather Vest (5lbs){Durability: 100%}",
            "Arms": "Custom Steel Plated Leather Bracers(4lbs){Durability: 100%}",
            "Waist": "Custom Steel Plated Leather Girdle (3lbs){Durability: 100%}",
            "Legs": "Custom Steel Plated Leather Grieves (4lbs){Durability: 100%}",
            "Feet": "Custom Steel Plated Rubber Boots (2lbs){Durability: 100%}",
            "Right Hand": "Custom Diamond Tipped Steel Scimitar (7lbs){Durability: 100%}",
            "Left Hand": "Custom Steel Plated Aluminum Shield (22lbs){Durability: 100%}"
        },
        bag: {
            "Item(Weight)": ""
        }
    },

    // If there's a social infrastructure with a bounty system:
    reputation: {
        fame: 50,
        notoriety: 20
    },

    // If there's an individual loyalty, fear, respect, and morality spectrum:
    relationships: {
        allies: ["Sir Marcus", "Lady Eleanor", "Hammerhead Mercenaries", "Barkeep"],
        enemies: ["Bandit Leader"],
        loyalty: 99,
        fear: 1,
        respect: 86,
        morality: 0.98642174532 // 1 = "Pure Good", 0 = "Pure Evil"
    },
    quests: {
        "Aithaluwa": "Protect Aithaluwa",
        "Ajax": "Protect the Barkeep",
        "Barkeep": "Protect Ye Olde Taverne",
    },
    // If there's an advanced survival system:
    health: {
        currentHealth: 100,
        maxHealth: 100,
        conditions: ["Healthy"]
        // Add more conditions as needed (e.g., "Hunger", "Fatigue", "Wounded")
    },

    // If you're incorporating futuristic character customization:
    appearance: {
        facialMapping: "Strong jawline, sharp features",
        voiceSynthesis: "Deep and commanding"
    },

    // If there's a genetic manipulation aspect:
    genetics: {
        mutations: ["Enhanced strength", "Improved metabolism"]
        // Add more mutations as needed
    }
};
// In the main file or wherever Ark is defined
const Ark = {
    /* Ark's properties and methods */
};

// In the code where you create a new Mercenary instance
const mercenary = new Mercenary(Ark);
mercenary.visitTavern();

// File = robjam1990/Psychosis/Gameplay/Characters/Stats.js
class Stats {
    constructor() {
        this.health = 100;
        this.energy = 100;
        this.hunger = 0;
        this.thirst = 0;
        this.strength = 5;
        this.endurance = 5;
        this.speed = 5;
        this.perception = 5;
        this.intelligence = 5;
        this.knowledge = 5;
        this.experience = 0;
        this.will = 5;
        this.patience = 5;
        this.flexibility = 5;
        this.balance = 5;
        this.charisma = 5;
    }
}

const Traits = {
    physical: { strength: 0, speed: 0, aggression: 0, health: 0, appeal: 0 },
    social: { humility: 0, temperament: 0, generosity: 0, loyalty: 0, honesty: 0 },
    Emotional: { Spontaneity: 0, Mannerism: 0, Rage: 0 },
    Behavioral: { Curiosity: 0, Dependency: 0, Confidence: 0, Ambition: 0 },
    Intellectual: { Creativity: 0, Concentration: 0, Intelligence: 0 }
};

const Occupation = {
    Royalty: ["King", "Queen", "Lord", "Lady"],
    Military: ["Guard", "Soldier", "Captain", "Commander", "General"],
    Civilian: ["Bard", "Alchemist", "Tanner", "Healer", "Farmer", "Blacksmith", "Barkeep", "Barmaid", "ShopKeep", "Apprentice", "Assistant", "Fletcher", "Butcher", "Weaver", "Potter"],
    Labour: ["Miner", "Hunter", "Athlete", "Scavenger", "Servant"],
    Criminal: ["Thief", "Murderer", "Assassin", "Pirate", "Bandit"],
    Traversal: ["Slave", "Settler", "Adventurer", "Explorer"],
    Dangerous: ["Mercenary"],
    School: ["Doctor", "Teacher", "Scholar", "Genius"],
    Specialist: ["Researcher", "Engineer", "Inventor", "Architect", "Plumber", "Pilot"],
    Other: ["Idiot", "Jester", "Judge", "Executioner", "Vagrant", "Priest"]
};

const myCharacter = {
    stats: new Stats(),
    traits: Traits,
    occupation: Occupation
};

console.log(myCharacter);

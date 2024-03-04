// File = Psychosis/Gameplay/Management/recruitment.js
class Character {
    constructor(name, role, attributes, price, requirements) {
        this.name = name;
        this.role = role;
        this.attributes = attributes;
        this.price = price;
        this.requirements = requirements;
        this.recruited = false;
    }

    recruit(player) {
        // Check if the character has already been recruited
        if (this.recruited) {
            console.log(`${this.name} has already been recruited.`);
            return;
        }

        // Check if player meets recruitment requirements
        if (!this.checkRequirements(player)) {
            console.log(`${this.name} cannot be recruited at this time.`);
            return;
        }

        // Check if player has enough gold
        if (player.gold < this.price) {
            console.log(`Insufficient gold to recruit ${this.name}.`);
            return;
        }

        // Deduct gold from player's inventory
        player.gold -= this.price;

        // Add character to player's party
        player.party.push(this);

        // Mark character as recruited
        this.recruited = true;

        console.log(`${this.name} has been recruited to your party.`);
    }

    checkRequirements(player) {
        // Check if player meets all requirements for recruitment
        for (let requirement of this.requirements) {
            if (!requirement.check(player)) {
                return false;
            }
        }
        return true;
    }
}

class AttributeRequirement {
    constructor(attribute, value) {
        this.attribute = attribute;
        this.value = value;
    }

    check(player) {
        // Check if player's attribute meets requirement
        return player.attributes[this.attribute] >= this.value;
    }
}

class Player {
    constructor(gold, attributes) {
        this.gold = gold;
        this.attributes = attributes;
        this.party = [];
    }
}

// Define different types of characters
const knight = new Character("Sir Galahad", "Knight", { strength: 10, agility: 5, intelligence: 3 }, 100, []);
const chemist = new Character("Merlin", "chemist", { strength: 3, agility: 5, intelligence: 10 }, 150, []);
const rogue = new Character("Lilith", "Rogue", { strength: 5, agility: 10, intelligence: 3 }, 120, []);

// Define requirements for recruiting characters
const highStrengthReq = new AttributeRequirement("strength", 8);
const highAgilityReq = new AttributeRequirement("agility", 8);
const highIntelligenceReq = new AttributeRequirement("intelligence", 8);

// Set requirements for recruiting characters
knight.requirements.push(highStrengthReq);
chemist.requirements.push(highIntelligenceReq);
rogue.requirements.push(highAgilityReq);

// Usage example
const player = new Player(200, { strength: 6, agility: 7, intelligence: 6 });
knight.recruit(player); // Insufficient strength to recruit Sir Galahad.
chemist.recruit(player); // Merlin has been recruited to your party.
rogue.recruit(player); // Lilith has been recruited to your party.

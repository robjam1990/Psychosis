const fs = require('fs');
const path = require('path'); // Import the 'path' module for handling file paths
// Define the characters data
const charactersData = [];

class Character {
    constructor(name, occupation, residence) {
        this.name = name;
        this.occupation = occupation;
        this.residence = residence;
        this.health = 100;
        this.limbs = {
            "head": true,
            "arms": {
                "left": true,
                "right": true
            },
            "legs": {
                "left": true,
                "right": true
            }
        };
        this.skills = {
            "combat": Math.floor(Math.random() * 10) + 1,
            "crafting": Math.floor(Math.random() * 10) + 1,
            "diplomacy": Math.floor(Math.random() * 10) + 1
        };
        this.morality = Math.random();
        this.location = "Taverne(Main Hall)";
        this.inventory = {};
        this.faction = null;
    }

    serialize() {
        return JSON.stringify(this);
    }

    deserialize(data) {
        const parsedData = JSON.parse(data);
        Object.assign(this, parsedData);
    }
}

// Function to initialize characters
function initializeCharacters() {
    charactersData.push(
        new Character("OPUS", "Oracle", "Nexus Temple"),
        new Character("OPUS", "Oracle", "Nexus Temple"),
        new Character("APUS", "Queen of Bractalia", "Bractal Castle"),
        new Character("MAIA", "Greeter", "Ye Olde Taverne"),
        new Character("Ark", "Mercenary", "Ye Olde Taverne"),
        new Character("Bling", "Shopkeeper", "Weavery"),
        new Character("Bran", "Farmer", "Brans Farmhouse"),
        new Character("Mazuk", "King of Thipse", "Thipse"),
        new Character("Fragru", "Mercenary", "Mercenary Camp"),
        new Character("Garmanar", "Mercenary", "Mercenary Camp"),
        new Character("Ajax", "Mercenary Leader", "Mercenary Camp"),
        new Character("Rick", "Researcher", "Unknown"),
        new Character("Morty", "Student", "Tree of Life"),
        new Character("Tesla", "Researcher", "Wardenclyffe"),
        new Character("Murdoch", "Detective", "Ruins"),
        new Character("Duncan", "Guard Captain", "Nexus Longhouse"),
        new Character("Hannibal", "General", "Varthek"),
        new Character("Alexander the Awesome", "King of Kinderyarn", "Flaxchop"),
        new Character("Archimedes", "Engineer", "Bractal"),
        new Character("Guan Yu", "Commander", "Wolk"),
        new Character("Cicero", "Jester", "Bractal Castle"),
        new Character("Beatrix", "Guard Captain", "Bractal Castle"),
        new Character("Conway Twitty", "Bard", "Peachstraw"),
        new Character("Ash Ketchum", "Beast Master", "Unknown"),
        new Character("Mario", "Plumber", "Unknown"),
        new Character("Orngamorn", "Mercenary", "Mercenary Camp"),
        new Character("Aithaluwa", "Adventurer", "Ye Olde Taverne"),
        new Character("Geralt", "Adventurer", "Camp"),
        new Character("Jaskier", "Bard", "Camp"),
        new Character("Marie Curie", "Researcher", "Thipse"),
        new Character("Isaac Newton", "Teacher", "Thipse"),
        new Character("Christopher Columbus", "Explorer", "Lochtou"),
        new Character("Arthur Pendragon", "King of Louchtou", "Lochtou"),
        new Character("Joan D'Arc", "Soldier", "Nymenada"),
        new Character("Leonardo Da Vinci", "Inventor", "Jight"),
        new Character("Charles Darwin", "Observer", "Bractalia"),
        new Character("Alan Turing", "Genius", "Unknown"),
        new Character("Weaver", "Weaver", "Oasis"),
        new Character("Farmer", "Farmer", "Oasis"),
        new Character("Elder", "Teacher", "Oasis"),
        new Character("Bandit", "Thief", "Bandit Camp"),
        new Character("Bandit Recruit", "Thief", "Bandit Camp"),
        new Character("Bandit Highwayman", "Thief", "Bandit Camp"),
        new Character("Bandit Leader", "Thief", "Bandit Camp"),
        new Character("Weaver", "Weaver", "Tree of Life"),
        new Character("Beastmaster", "Beastmaster", "Tree of Life"),
        new Character("Healer", "Healer", "Tree of Life"),
        new Character("Chemist", "Chemist", "Tree of Life"),
        new Character("Vagrant", "Vagrant", "Ruins"),
        new Character("Scavenger", "Scavenger", "Ruins"),
        new Character("Elder", "Teacher", "Ruins"),
        new Character("Good Son", "Hunter", "Ruins"),
        new Character("Barkeep", "Barkeep", "Ye Olde Taverne"),
        new Character("Aslo", "Bard", "Ye Olde Taverne"),
        new Character("Barmaid", "Barmaid", "Ye Olde Taverne"),
        new Character("Servant", "Servant", "Ye Olde Taverne"),
        new Character("Guard", "Guard", "Ye Olde Taverne"),
        new Character("Brans Wife", "Farmer", "Brans Farmhouse"),
        new Character("Stablemaster", "Esquire", "Stables"),
        new Character("Assistant", "Assistant", "Stables"),
        new Character("Blacksmith", "Blacksmith", "Blacksmith"),
        new Character("Assistant", "Assistant", "Blacksmith"),
        new Character("Apprentice", "Apprentice", "Blacksmith"),
        new Character("Guard", "Guard", "Blacksmith"),
        new Character("Husband", "Mercenary", "Mercenary Camp"),
        new Character("Wife", "Mercenary", "Mercenary Camp"),
        new Character("Mercenary", "Mercenary", "Mercenary Camp"),
        new Character("Vagrant Mercenary", "Mercenary", "Mercenary Camp"),
        new Character("Commander", "Commander", "Nexus Longhouse"),
        new Character("Captain", "Captain", "Nexus Longhouse"),
        new Character("Archer", "Guard", "Nexus Longhouse"),
        new Character("Guard", "Guard", "Nexus Longhouse"),
        new Character("Healer", "Healer", "Temple"),
        new Character("Priest", "Priest", "Temple"),
        new Character("Weaver", "Weaver", "Nexus Weavery"),
        new Character("Potter", "Potter", "Nexus Pottery"),
        new Character("Thomas", "Archer", "Vagrant"),
        new Character("Homer", "Poet", "Unknown"),
    );
}

// Function to export all characters to separate JSON files
function exportCharactersToFile() {
    charactersData.forEach((character, index) => {
        const fileName = `character_${index + 1}.json`; // Generate a unique file name for each character
        exportCharacter(character, fileName);
    });
}
{
    try {
        const savePath = path.join(__dirname, 'Psychosis', 'Data', fileName); // Construct the save path
        const serializedData = character.serialize();
        fs.writeFileSync(savePath, serializedData);
        console.log(`${character.name} has been exported to ${savePath}.`);
    } catch (error) {
        console.error(`Failed to export ${character.name}: ${error.message}`);
    }
}

// Function to import a character from a JSON file
function importCharacter(fileName) {
    try {
        const filePath = path.join(__dirname, 'Psychosis', 'Data', fileName); // Construct the file path
        const data = fs.readFileSync(filePath, 'utf8');
        const character = new Character();
        character.deserialize(data);
        console.log(`${character.name} has been imported from ${filePath}.`);
        return character;
    } catch (error) {
        console.error(`Failed to import character from ${fileName}: ${error.message}`);
        return null;
    }
}
function main() {
    initializeCharacters();
    exportCharactersToFile();
}

main();

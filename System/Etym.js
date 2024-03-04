// fileHandler.js
const fs = require('fs');

function readJSONFile(filePath) {
    try {
        const data = fs.readFileSync(filePath, 'utf8');
        return JSON.parse(data);
    } catch (err) {
        throw new Error("Error reading file: " + err.message);
    }
}

module.exports = {
    readJSONFile
};

// insectActions.js
const playerInventory = require('./playerInventory');

// Function to capture an insect
function capture(index) {
    if (isNaN(index)) {
        console.log("Invalid input. Index must be a number.");
        return;
    }
    if (insects && index >= 0 && index < insects.length) {
        console.log("You captured a " + insects[index].name + "!");
        playerInventory.addInsect(insects[index]);
    } else {
        console.log("Invalid insect index or 'insects' array is not defined or empty.");
    }
}

// Function to study the behavior of an insect
function study(index) {
    if (isNaN(index)) {
        console.log("Invalid input. Index must be a number.");
        return;
    }
    if (insects && index >= 0 && index < insects.length) {
        console.log("Behavior of " + insects[index].name + ": " + insects[index].behavior);
        // Additional logic for studying the insect's behavior can be added here
    } else {
        console.log("Invalid insect index or 'insects' array is not defined or empty.");
    }
}

// Function to assess the ecological impact of an insect
function assessEcologicalImpact(index) {
    if (isNaN(index)) {
        console.log("Invalid input. Index must be a number.");
        return;
    }
    if (insects && index >= 0 && index < insects.length) {
        console.log("Ecological Impact of " + insects[index].name + ": " + insects[index].ecologicalImpact);
        // Additional logic for assessing ecological impact can be added here
    } else {
        console.log("Invalid insect index or 'insects' array is not defined or empty.");
    }
}

module.exports = {
    capture,
    study,
    assessEcologicalImpact
};

// playerInventory.js
let playerInventory = [];

function addInsect(insect) {
    playerInventory.push(insect);
    console.log("Added " + insect.name + " to player's inventory.");
}

module.exports = {
    addInsect
};

// main.js
const fileHandler = require('./fileHandler');
const insectActions = require('./insectActions');

// Load insects from the JSON file
const insects = fileHandler.readJSONFile('insect.json');

// Example usage:
insectActions.capture(2); // Capture the Beetle at index 2
insectActions.study(0);   // Study the behavior of the Bee at index 0
insectActions.assessEcologicalImpact(3); // Assess the ecological impact of the Ant at index 3

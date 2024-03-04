// File: robjam1990/Psychosis/Gameplay/Planets/Thear/Objects.js

// Define the Furniture object outside the Objects function
const Furniture = {
    Stool: {
        "Main Hall": 38,
        "Back Room": 10,
        "Training Room": 0,
        "Office": 2,
        "Storage Room": 0,
        "Bedroom": 0
    },
    Table: {
        "Main Hall": 11,
        "Back Room": 1,
        "Training Room": 0,
        "Office": 1,
        "Storage Room": 0,
        "Bedroom": 0
    },
    Storage: {
        "Main Hall": 5,
        "Back Room": 4,
        "Training Room": 0,
        "Office": 0,
        "Storage Room": 8,
        "Bedroom": 7
    }
};

/**
 * Retrieves the quantity of furniture in a specific room.
 * @param {string} type - The type of furniture (e.g., "Stool", "Table", "Storage").
 * @param {string} room - The room where the furniture is located.
 * @returns {number} The quantity of furniture in the specified room, or 0 if the type or room doesn't exist.
 */
function getFurnitureQuantity(type, room) {
    if (Furniture[type] && Furniture[type][room]) {
        return Furniture[type][room];
    } else {
        console.error(`Invalid type (${type}) or room (${room}). Please provide valid arguments.`);
        return 0;
    }
}

// Example usage:
console.log(getFurnitureQuantity("Stool", "Main Hall")); // Output: 38
console.log(getFurnitureQuantity("Table", "Office")); // Output: 1
console.log(getFurnitureQuantity("Storage", "Bedroom")); // Output: 7
console.log(getFurnitureQuantity("Chair", "Main Hall")); // Output: 0 (Invalid type)

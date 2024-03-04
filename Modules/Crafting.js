// File: Psychosis/Gameplay/Systems/Crafting.js
// Define crafting system
const Crafting = {
    // Define crafting recipes, skill tree, and crafting events
    recipes: {
        "wooden_sword": {
            "materials": {
                "wood": 5,
                "iron": 2
            },
            "tools": ["hammer", "saw"],
            "skillRequired": 10
        },
        "health_potion": {
            "materials": {
                "herbs": 3,
                "water": 1
            },
            "tools": ["cauldron"],
            "skillRequired": 5
        },
        // Add more recipes as needed
    },
    skillTree: {
        blacksmithing: {
            level: 0,
            unlocked: true,
            abilities: {
                tempering: {
                    unlocked: true,
                    description: "Improves durability of crafted weapons.",
                    effect: () => {
                        // Implement tempering effect
                    }
                },
                forging: {
                    unlocked: false,
                    description: "Unlocks advanced weapon crafting recipes.",
                    effect: () => {
                        // Implement forging effect
                    }
                }
            }
        },
        alchemy: {
            level: 0,
            unlocked: false,
            abilities: {
                brewing: {
                    unlocked: false,
                    description: "Unlocks potion crafting recipes.",
                    effect: () => {
                        // Implement brewing effect
                    }
                }
            }
        },
        woodworking: {
            level: 0,
            unlocked: false,
            abilities: {
                carving: {
                    unlocked: false,
                    description: "Unlocks woodworking crafting recipes.",
                    effect: () => {
                        // Implement carving effect
                    }
                }
            }
        },
        // Define additional crafting disciplines as needed
    },
    craftingEvents: {
        puzzle: {
            execute(player) {
                // Implement puzzle logic here
                console.log("You encountered a crafting puzzle!");
                // Example: Player has to solve a riddle to complete crafting
            }
        },
        encounter: {
            execute(player) {
                // Implement encounter logic here
                console.log("You encountered a crafting encounter!");
                // Example: Player faces off against a creature while crafting
            }
        },
        gathering: {
            execute(player) {
                // Implement gathering logic here
                console.log("You encountered a crafting gathering event!");
                // Example: Player needs to gather rare materials to continue crafting
            }
        },
    },

    // Function to check available recipes based on player's inventory and skill level
    checkAvailableRecipes(player) {
        const availableRecipes = {};
        for (const recipeName in this.recipes) {
            const recipe = this.recipes[recipeName];
            if (player.skillLevel >= recipe.skillRequired) {
                let canCraft = true;
                for (const material in recipe.materials) {
                    if (!player.inventory[material] || player.inventory[material] < recipe.materials[material]) {
                        canCraft = false;
                        break;
                    }
                }
                if (canCraft) {
                    availableRecipes[recipeName] = recipe;
                }
            }
        }
        return availableRecipes;
    },

    // Function to craft items
    craftItem(player, itemName) {
        const recipe = this.recipes[itemName];
        if (!recipe) {
            console.log("Recipe not found!");
            return;
        }

        // Check if player has required skill level and materials
        if (player.skillLevel < recipe.skillRequired) {
            console.log("You don't have enough skill to craft this item!");
            return;
        }

        for (const material in recipe.materials) {
            if (!player.inventory[material] || player.inventory[material] < recipe.materials[material]) {
                console.log("You don't have enough materials to craft this item!");
                return;
            }
        }

        // Deduct materials from player's inventory
        for (const material in recipe.materials) {
            player.inventory[material] -= recipe.materials[material];
        }

        // Remove used tools from player's inventory
        for (const tool of recipe.tools) {
            const toolIndex = player.inventory.tools.indexOf(tool);
            if (toolIndex !== -1) {
                player.inventory.tools.splice(toolIndex, 1);
            }
        }

        // Add crafted item to player's inventory
        if (!player.inventory.items[itemName]) {
            player.inventory.items[itemName] = 0;
        }
        player.inventory.items[itemName]++;

        // Increase player's crafting skill
        player.skillLevel += 1;

        console.log(`You have crafted a ${itemName}!`);
    },

    // Function to handle crafting events
    handleCraftingEvent(player) {
        // Randomly select a crafting event
        const eventKeys = Object.keys(this.craftingEvents);
        const randomEventKey = eventKeys[Math.floor(Math.random() * eventKeys.length)];
        const event = this.craftingEvents[randomEventKey];

        // Execute the selected event
        event.execute(player);
    },

    // Function to simulate crafting events
    simulateCraftingEvent(player) {
        // Example: 50% chance of encountering a crafting event
        if (Math.random() < 0.5) {
            this.handleCraftingEvent(player);
        }
    }
};

// Example usage:
const player = {
    skillLevel: 15,
    inventory: {
        wood: 20,
        iron: 10,
        herbs: 5,
        water: 3,
        tools: ["hammer", "saw", "cauldron"],
        items: {}
    }
};

// Other functions remain the same...

// Test the crafting system
const availableRecipes = Crafting.checkAvailableRecipes(player);
console.log("Available recipes:", availableRecipes);

// Craft a wooden sword
Crafting.craftItem(player, "wooden_sword");
console.log("Player's inventory after crafting:", player.inventory);

// Simulate crafting event
Crafting.simulateCraftingEvent(player);

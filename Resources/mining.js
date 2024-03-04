class Player {
    constructor() {
        this.inventory = {
            "Lithium": 0, "Chromium": 0, "Tungsten": 0, "Mercury": 0, "Uranium": 0,
            "Magnesium": 0, "Gallium": 0, "Iron": 0, "Aluminum": 0, "Titanium": 0,
            "Steel": 0, "Gold": 0, "Silver": 0, "Bronze": 0, "Copper": 0, "Flint": 0,
            "Nickel": 0, "Malachite": 0, "Lead": 0, "Tin": 0, "Zinc": 0, "Cobalt": 0,
            "Coal": 0, "Obsidian": 0, "Clay": 0, "Oil": 0, "Marble": 0, "Sand": 0, "Stone": 0,
            "Diamond": 0, "Ruby": 0, "Sapphire": 0, "Garnet": 0, "Emerald": 0, "Topaz": 0,
            "Amethyst": 0, "Quartz": 0
        };
        this.attributes = {
            "OxygenLevel": 100, "BodyTemperature": 20, "Disease": 0, "Hunger": 0,
            "Energy": 100, "Sanity": 100, "Hygiene": 100, "Waste": 0, "Stamina": 100
        };
        this.tools = { "pickaxe": { "efficiency": 1, "upgrade_cost": 10 } };
    }
}

class Mining {
    constructor() {
        this.player = new Player();
    }

    *mine() {
        if (this.player.attributes["Energy"] <= 0) {
            console.log("You're too exhausted to mine. Rest or use energy potions.");
            return;
        }

        console.log("Mining...");
        const minedMetal = this.chooseMetalToMine();
        const yieldAmount = this.calculateYieldAmount(minedMetal);

        console.log(`You mined ${yieldAmount} ${minedMetal}!`);

        // Update player inventory
        this.player.inventory[minedMetal] += yieldAmount;

        // Update attributes
        this.updatePlayerAttributes();

        // Consume energy
        this.player.attributes["Energy"] -= 10;

        // Check for negative attributes and cap BodyTemperature
        this.checkNegativeAttributes();

        // Check for special events
        this.checkSpecialEvents();
    }

    chooseMetalToMine() {
        // Placeholder for future implementation of location-based resource distribution
        const metals = Object.keys(this.player.inventory);
        return metals[Math.floor(Math.random() * metals.length)];
    }

    calculateYieldAmount(metal) {
        return Math.floor(Math.random() * 5 + 1) * this.player.tools["pickaxe"]["efficiency"];
    }

    updatePlayerAttributes() {
        this.player.attributes["OxygenLevel"] -= 5;
        this.player.attributes["BodyTemperature"] += 2.5;
        this.player.attributes["Disease"] += 5;
        this.player.attributes["Sanity"] -= 2.5;
        this.player.attributes["Waste"] += 5;
    }

    checkNegativeAttributes() {
        for (const [attribute, value] of Object.entries(this.player.attributes)) {
            if (value < 0) {
                this.player.attributes[attribute] = 0;
            }
        }

        // Cap BodyTemperature at 40
        if (this.player.attributes["BodyTemperature"] > 40) {
            this.player.attributes["BodyTemperature"] = 40;
        }
    }

    checkSpecialEvents() {
        // Placeholder for future implementation of special events
    }

    upgradeTool() {
        if (this.player.inventory["Gems"] >= this.player.tools["pickaxe"]["upgrade_cost"]) {
            console.log("Upgrading pickaxe...");
            this.player.tools["pickaxe"]["efficiency"] += 1;
            this.player.inventory["Gems"] -= this.player.tools["pickaxe"]["upgrade_cost"];
            console.log("Pickaxe upgraded!");
        } else {
            console.log("You don't have enough gems to upgrade your pickaxe.");
        }
    }

    rest() {
        console.log("Resting...");
        // Increase energy to full
        this.player.attributes["Energy"] = 100;
        // Reset attributes
        this.player.attributes["OxygenLevel"] = 100;
        this.player.attributes["BodyTemperature"] = 20;
        this.player.attributes["Disease"] = 0;
        this.player.attributes["Sanity"] += 20;
        this.player.attributes["Waste"] = 0;
        console.log("You feel refreshed!");
    }

    displayStatus() {
        console.log("Attributes:");
        for (const [attribute, value] of Object.entries(this.player.attributes)) {
            console.log(`${attribute}: ${value}`);
        }

        console.log("\nInventory:");
        for (const [metal, amount] of Object.entries(this.player.inventory)) {
            console.log(`${metal}: ${amount}`);
        }
    }
}

function main() {
    const action = new Mining();

    while (true) {
        console.log("\nOptions:");
        console.log("1. Mine");
        console.log("2. Upgrade Pickaxe");
        console.log("3. Rest");
        console.log("4. Quit");

        const choice = parseInt(prompt("Enter your choice: "));

        if (isNaN(choice)) {
            console.log("Invalid input. Please enter a number.");
            continue;
        }

        switch (choice) {
            case 1:
                action.mine();
                break;
            case 2:
                action.upgradeTool();
                break;
            case 3:
                action.rest();
                break;
            case 4:
                console.log("Quitting the Action. Goodbye!");
                return;
            default:
                console.log("Invalid choice. Please choose again.");
        }

        // Display player status after each action
        action.displayStatus();
    }
}

main();

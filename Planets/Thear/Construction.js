class Season {
    constructor() {
        this.Spring = 0;
        this.Summer = 1;
        this.Autumn = 2;
        this.Winter = 3;
    }
}

class Resource {
    constructor(name, amount) {
        this.name = name;
        this.amount = amount;
    }
}

class Structure {
    constructor(name, required_resources, durability) {
        this.name = name;
        this.required_resources = required_resources;
        this.durability = durability;
        this.max_durability = durability;
    }

    checkRequirements(player_inventory) {
        for (let resource of this.required_resources) {
            if (!(resource.name in player_inventory) || player_inventory[resource.name] < resource.amount) {
                return false;
            }
        }
        return true;
    }

    deductResources(player_inventory) {
        for (let resource of this.required_resources) {
            player_inventory[resource.name] -= resource.amount;
        }
    }

    repair(player_inventory) {
        let repair_cost = (this.max_durability - this.durability) * 5;  // Example repair cost formula
        if ("gold" in player_inventory && player_inventory["gold"] >= repair_cost) {
            player_inventory["gold"] -= repair_cost;
            this.durability = this.max_durability;
            console.log(`${this.name} repaired.`);
        } else {
            console.log("Insufficient resources to repair.");
        }
    }
}

class World {
    constructor() {
        this.Locations = [];
        this.CurrentSeason = new Season().Spring;
        this.CurrentDay = 1;
        this.CurrentHour = 0;
        this.IsDaytime = true;
    }

    simulateStructureDegradation() {
        for (let location of this.Locations) {
            for (let i = location.Structures.length - 1; i >= 0; i--) {
                let structure = location.Structures[i];
                // Simulate degradation by reducing durability
                structure.durability -= 1;
                if (structure.durability <= 0) {
                    location.Structures.splice(i, 1);
                    console.log(`${structure.name} degraded and destroyed in ${location.Name}.`);
                }
            }
        }
    }

    constructStructure(locationName, structure, player_inventory) {
        let location = this.Locations.find(l => l.Name === locationName);
        if (location) {
            if (structure.checkRequirements(player_inventory)) {
                structure.deductResources(player_inventory);
                location.Structures.push(structure);
                console.log(`${structure.name} constructed in ${locationName}.`);
            } else {
                console.log(`Insufficient resources to construct ${structure.name}.`);
            }
        } else {
            console.log(`Location ${locationName} not found.`);
        }
    }

    repairStructure(locationName, structureName, player_inventory) {
        let location = this.Locations.find(l => l.Name === locationName);
        if (location) {
            let structure = location.Structures.find(s => s.name === structureName);
            if (structure) {
                structure.repair(player_inventory);
            } else {
                console.log(`Structure ${structureName} not found in ${locationName}.`);
            }
        } else {
            console.log(`Location ${locationName} not found.`);
        }
    }
}

if (require.main === module) {
    let world = new World();
    let player_inventory = { "wood": 100, "stone": 50, "gold": 200 };  // Example player inventory

    // Example usage
    let house_resources = [new Resource("wood", 20), new Resource("stone", 10)];
    let house = new Structure("House", house_resources, 50);
    world.constructStructure("Village A", house, player_inventory);

    // Simulate structure degradation
    world.simulateStructureDegradation();

    // Repair a structure
    world.repairStructure("Village A", "House", player_inventory);
}

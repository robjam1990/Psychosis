// File: robjam1990/Psychosis/Gameplay/System/Solar.js
class StarSystem {
    constructor() {
        this.planets = [];
    }

    addPlanet(planet) {
        this.planets.push(planet);
    }

    travelToPlanet(planet) {
        // Logic for traveling to the specified planet within the star system
    }
}

class Planet {
    constructor(name, shape = "round", isDefault = false) {
        this.name = name;
        this.shape = shape;
        this.locations = [];
        this.starSystem = null;
        this.isDefault = isDefault; // Added a new property to indicate if the planet is the default spawn point
    }

    setStarSystem(starSystem) {
        this.starSystem = starSystem;
    }
}
// Assuming you have a StarSystem instance named 'thearSystem'
const thear = new Planet("Thear", "round", true);
thear.setStarSystem(thearSystem);

// Add Thear to the star system
thearSystem.addPlanet(thear);

class Hazard {
    constructor(name, severity) {
        this.name = name;
        this.severity = severity;
    }
}

class Location {
    constructor(name) {
        this.name = name;
        this.objects = [];
        this.hazards = [];
    }

    addHazard(hazard) {
        this.hazards.push(hazard);
    }
}


class Resource {
    constructor(name, renewable = false, abundance = "low") {
        this.name = name;
        this.renewable = renewable;
        this.abundance = abundance;
    }
}
class Recipe {
    constructor(name, ingredients, product) {
        this.name = name;
        this.ingredients = ingredients;
        this.product = product;
    }
}

class CraftingSystem {
    constructor() {
        this.recipes = [];
    }

    addRecipe(recipe) {
        this.recipes.push(recipe);
    }
}


class SurvivalSystem {
    constructor() {
        this.stats = {
            O2: 100,
            Temperature: 98.6,
            Disease: 0,
            Hunger: 100,
            Energy: 100,
            Sanity: 100,
            Hygiene: 100,
            Waste: 0,
        };
        class Event {
            constructor(description, choices, consequences) {
                this.description = description;
                this.choices = choices;
                this.consequences = consequences;
            }
        }

        class NarrativeManager {
            constructor() {
                this.events = [];
            }

            addEvent(event) {
                this.events.push(event);
            }
        }

    }

    updateStats() {
        // Logic for updating survival stats
    }
}

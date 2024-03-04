class MiningResources {
    constructor() {
        this.resources = {};
    }

    // Method to randomly generate resources for a planet
    generateResources() {
        const numResources = Math.floor(Math.random() * (11 - 5)) + 5; // Generate between 5 to 10 resources per planet
        for (let i = 0; i < numResources; i++) {
            const index = Math.floor(Math.random() * ResourceList.allResources.length); // Choose a random resource from the master list
            const resource = ResourceList.allResources[index];
            const quantity = Math.floor(Math.random() * (201 - 50)) + 50; // Generate a random quantity for the resource
            this.resources[resource] = quantity;
        }
    }
}

// Class to hold a list of all available resources
class ResourceList {
    static allResources = [
        "Lithium", "Chromium", "Tungsten", "Mercury", "Uranium", "Magnesium", "Gallium", "Iron", "Aluminum",
        "Titanium", "Steel", "Gold", "Silver", "Bronze", "Copper", "Flint", "Nickel", "Malachite", "Lead",
        "Tin", "Zinc", "Cobalt", "Coal", "Obsidian", "Clay", "Oil", "Marble", "Sand", "Stone", "Diamond",
        "Ruby", "Sapphire", "Garnet", "Emerald", "Topaz", "Amethyst", "Quartz"
    ];
}

class Planet {
    constructor(name, radius, atmosphereComposition, temperature) {
        this.name = name;
        this.radius = radius;
        this.atmosphereComposition = atmosphereComposition;
        this.temperature = temperature;
        this.miningResources = new MiningResources();
        this.landmarks = [];
        this.creatures = [];
        this.explored = false;

        // Initialize additional attributes
        this.weatherPatterns = [];
        this.terrainTypes = [];
    }

    explore() {
        console.log(`You are exploring ${this.name}. It has a radius of ${this.radius} units.`);
        console.log(`The landscape is ${this.getLandscapeDescription()}.`);
        console.log(`The temperature is ${this.temperature} degrees Celsius.`);
        console.log(`The atmosphere composition is ${this.atmosphereComposition}.`);

        if (!this.explored) {
            console.log("You have discovered the following landmarks:");
            this.landmarks.forEach(landmark => {
                console.log(`- ${landmark}`);
            });

            console.log("You have encountered the following creatures:");
            this.creatures.forEach(creature => {
                console.log(`- ${creature}`);
            });

            console.log("You have found the following resources:");
            for (const resource in this.miningResources.resources) {
                if (this.miningResources.resources.hasOwnProperty(resource)) {
                    console.log(`- ${resource}: ${this.miningResources.resources[resource]}`);
                }
            }

            // Display additional information
            console.log("The weather patterns on this planet include:");
            this.weatherPatterns.forEach(weatherPattern => {
                console.log(`- ${weatherPattern}`);
            });

            console.log("The terrain types on this planet include:");
            this.terrainTypes.forEach(terrainType => {
                console.log(`- ${terrainType}`);
            });

            this.explored = true;
        } else {
            console.log("You have already explored this planet.");
        }
    }

    getLandscapeDescription() {
        // Generate a random landscape description for each planet
        const landscapes = ["rocky", "barren", "lush", "volcanic", "icy", "deserted", "forested"];
        const index = Math.floor(Math.random() * landscapes.length);
        return landscapes[index];
    }
}

class SolarSystem {
    constructor() {
        this.planets = [
            new Planet("Mercury", 2439.7, "minimal atmosphere", 430),
            new Planet("Venus", 6051.8, "carbon dioxide, nitrogen", 462),
            new Planet("Earth", 6371, "nitrogen, oxygen", 15),
            new Planet("Mars", 3389.5, "carbon dioxide, argon", -63),
            new Planet("Jupiter", 69911, "hydrogen, helium", -145),
            new Planet("Saturn", 58232, "hydrogen, helium", -178),
            new Planet("Uranus", 25362, "hydrogen, helium", -216),
            new Planet("Neptune", 24622, "hydrogen, helium", -214),
            new Planet("Thear", 5314, "nitrogen, oxygen", 20)
        ];

        // Generate resources, landmarks, and creatures for each planet
        this.planets.forEach(planet => {
            planet.miningResources.generateResources();
            this.generateLandmarks(planet);
            this.generateCreatures(planet);
            this.generateWeatherPatterns(planet);
            this.generateTerrainTypes(planet);
        });
    }

    generateLandmarks(planet) {
        const numLandmarks = Math.floor(Math.random() * (6 - 3)) + 3; // Generate between 3 to 5 landmarks per planet
        for (let i = 0; i < numLandmarks; i++) {
            const landmark = `Landmark${i + 1}`;
            planet.landmarks.push(landmark);
        }
    }

    generateCreatures(planet) {
        const numCreatures = Math.floor(Math.random() * (5 - 2)) + 2; // Generate between 2 to 4 creatures per planet
        for (let i = 0; i < numCreatures; i++) {
            const creature = `Creature${i + 1}`;
            planet.creatures.push(creature);
        }
    }

    // Additional methods for generating weather patterns and terrain types
    generateWeatherPatterns(planet) {
        // Generate random weather patterns
        const weatherOptions = ["Sunny", "Stormy", "Windy", "Foggy", "Freezing", "Hot"];
        const numWeatherPatterns = Math.floor(Math.random() * (5 - 2)) + 2; // Generate between 2 to 4 weather patterns per planet
        for (let i = 0; i < numWeatherPatterns; i++) {
            const weatherPattern = weatherOptions[Math.floor(Math.random() * weatherOptions.length)];
            planet.weatherPatterns.push(weatherPattern);
        }
    }

    generateTerrainTypes(planet) {
        // Generate random terrain types
        const terrainOptions = ["Mountains", "Plains", "Deserts", "Forests", "Oceans", "Tundra"];
        const numTerrainTypes = Math.floor(Math.random() * (5 - 2)) + 2; // Generate between 2 to 4 terrain types per planet
        for (let i = 0; i < numTerrainTypes; i++) {
            const terrainType = terrainOptions[Math.floor(Math.random() * terrainOptions.length)];
            planet.terrainTypes.push(terrainType);
        }
    }

    explorePlanet(planetIndex) {
        if (planetIndex >= 0 && planetIndex < this.planets.length) {
            this.planets[planetIndex].explore();
        } else {
            console.log("Invalid planet index.");
        }
    }
}

const solarSystem = new SolarSystem();

console.log("Welcome to the Solar System Explorer!");

while (true) {
    console.log("Choose a planet to explore (0-8):");
    solarSystem.planets.forEach((planet, index) => {
        console.log(`${index}. ${planet.name}`);
    });

    const choice = parseInt(prompt("Enter your choice:"));

    if (!isNaN(choice)) {
        solarSystem.explorePlanet(choice);
    } else {
        console.log("Invalid input. Please enter a number.");
    }
}

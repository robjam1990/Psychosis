const fs = require('fs');

class Biome {
    constructor(name) {
        this.name = name;
        this.organisms = [];
    }

    loadOrganismsFromJson(filePath) {
        return JSON.parse(fs.readFileSync(filePath, 'utf8'));
    }

    addOrganismsFromJson(filePath) {
        const organismsData = this.loadOrganismsFromJson(filePath);
        organismsData.forEach(organismData => {
            let organism;
            if (organismData.hasOwnProperty('limbs')) {
                organism = new Animal(organismData.species, organismData.age, organismData.limbs, organismData.habitat);
            } else {
                organism = new Plant(organismData.species, organismData.age, organismData.habitat);
            }
            this.addOrganism(organism);
        });
    }

    addOrganism(organism) {
        this.organisms.push(organism);
    }

    simulateDay() {
        console.log(`Simulating a day in the ${this.name} Biome:`);
        this.organisms.forEach(organism => {
            if (organism.isAlive) {
                organism.move();
                organism.eat();
                organism.reproduce();
                if (organism instanceof Animal) {
                    const prey = this.findPrey(organism);
                    if (prey) {
                        console.log(`${organism.species} is hunting ${prey.species}.`);
                        prey.die();
                        // Implement limb removal for the prey
                        prey.loseLimb();
                    }
                    // Simulate animal communication
                    this.animalCommunication(organism);
                }
            } else {
                console.log(`${organism.species} is dead and cannot perform any actions.`);
            }
        });
    }

    findPrey(predator) {
        const preyCandidates = this.organisms.filter(org => org instanceof Animal && org !== predator);
        if (preyCandidates.length > 0) {
            return preyCandidates[Math.floor(Math.random() * preyCandidates.length)];
        }
        return null;
    }

    animalCommunication(organism) {
        // Simulate animal communication
        console.log(`${organism.species} is communicating with other ${organism.species}.`);
    }
}

class Organism {
    constructor(species, age) {
        this.species = species;
        this.age = age;
        this.isAlive = true;
    }

    move() {
        console.log(`${this.species} is moving.`);
    }

    eat() {
        console.log(`${this.species} is eating.`);
    }

    reproduce() {
        console.log(`${this.species} is reproducing.`);
    }

    die() {
        console.log(`${this.species} has died.`);
        this.isAlive = false;
    }
}

class Plant extends Organism {
    constructor(species, age, habitat) {
        super(species, age);
        this.habitat = habitat;
    }

    move() {
        console.log(`${this.species} can't move, it's a plant in the ${this.habitat} habitat.`);
    }

    eat() {
        console.log(`${this.species} is absorbing nutrients from the soil in the ${this.habitat} habitat.`);
    }

    reproduce() {
        console.log(`${this.species} is spreading seeds in the ${this.habitat} habitat.`);
    }
}

class Animal extends Organism {
    constructor(species, age, limbs, habitat) {
        super(species, age);
        this.limbs = limbs;
        this.habitat = habitat;
    }

    move() {
        console.log(`${this.species} is moving in the ${this.habitat} habitat.`);
    }

    eat() {
        console.log(`${this.species} is hunting for food.`);
    }

    reproduce() {
        console.log(`${this.species} is mating.`);
    }

    loseLimb() {
        if (this.limbs > 0) {
            this.limbs--;
            console.log(`${this.species} lost a limb! Remaining limbs: ${this.limbs}`);
        } else {
            this.die();
        }
    }
}

// Sample usage
const biomeForest = new Biome("Forest");
biomeForest.addOrganismsFromJson('animals.json');
biomeForest.addOrganismsFromJson('plants.json');

biomeForest.simulateDay();

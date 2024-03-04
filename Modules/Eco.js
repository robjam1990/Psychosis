const fs = require('fs');

class Entity {
    constructor(name) {
        this.name = name;
    }
}

class Organism extends Entity {
    constructor(name, species, age) {
        super(name);
        this.species = species;
        this.age = age;
        this.is_alive = true;
        this.health = 100;
        this.oxygen = 100;
        this.temperature_tolerance = {
            min: 0,
            max: 100
        };
        this.disease_resistance = 100;
        this.sanity = 100;
    }

    move() {
        console.log(`${this.species} ${this.name} is moving.`);
    }

    eat() {
        console.log(`${this.species} ${this.name} is eating.`);
    }

    reproduce() {
        console.log(`${this.species} ${this.name} is reproducing.`);
    }

    die() {
        console.log(`${this.species} ${this.name} has died.`);
        this.is_alive = false;
    }

    adjustOxygen(amount) {
        this.oxygen += amount;
        console.log(`${this.species} ${this.name} oxygen level adjusted to ${this.oxygen}.`);
    }

    adjustTemperature(amount) {
        this.temperature_tolerance.min += amount;
        this.temperature_tolerance.max += amount;
        console.log(`${this.species} ${this.name} temperature tolerance adjusted to ${this.temperature_tolerance.min}-${this.temperature_tolerance.max}°C.`);
    }

    adjustDiseaseResistance(amount) {
        this.disease_resistance += amount;
        console.log(`${this.species} ${this.name} disease resistance adjusted to ${this.disease_resistance}.`);
    }

    adjustSanity(amount) {
        this.sanity += amount;
        console.log(`${this.species} ${this.name} sanity adjusted to ${this.sanity}.`);
    }
}

class Animal extends Organism {
    constructor(name, species, age, limbs, temperature_preference) {
        super(name, species, age);
        this.limbs = limbs;
        this.hunger = 10;
        this.strength = 1;
        this.gender = Math.random() < 0.5 ? 'male' : 'female';
        this.temperature_preference = temperature_preference;
        this.is_hungry = true;
    }

    attack(type) {
        let damage = 0;
        if (type === 'bite') {
            damage = this.strength * 2;
        } else if (type === 'claw') {
            damage = this.strength * 1.5;
        } else if (type === 'tailSwipe') {
            damage = this.strength * 1.2;
        } else {
            damage = this.strength;
        }
        console.log(`${this.species} ${this.name} performs a ${type} attack, dealing ${damage} damage.`);
        return damage;
    }

    defend() {
        console.log(`${this.species} ${this.name} is defending.`);
    }

    evade() {
        console.log(`${this.species} ${this.name} is evading.`);
    }

    move() {
        console.log(`${this.species} ${this.name} is running.`);
    }

    eat() {
        console.log(`${this.species} ${this.name} is hunting.`);
        this.hunger -= 20;
        if (this.hunger <= 0) {
            this.is_hungry = false;
        }
    }

    lose_limb() {
        if (this.limbs > 0) {
            this.limbs -= 1;
            console.log(`${this.species} ${this.name} lost a limb! Remaining limbs: ${this.limbs}`);
        } else {
            this.die();
        }
    }

    adjustHealth(amount) {
        this.health += amount;
        console.log(`${this.species} ${this.name} health adjusted to ${this.health}.`);
    }
}

class Ecosystem {
    constructor() {
        this.entities = [];
        this.temperature = 25;
        this.log = [];
        this.day = 0;
    }

    add_entity(entity) {
        this.entities.push(entity);
    }

    simulate_day() {
        console.log(`Simulating Day ${this.day} in the ecosystem:`);
        this.entities.forEach(entity => {
            if (entity instanceof Organism && entity.is_alive) {
                entity.move();
                entity.eat();
                entity.reproduce();
                entity.adjustOxygen(-5);
                entity.adjustTemperature(1);
                entity.adjustDiseaseResistance(-1);
                entity.adjustSanity(-1);
                if (entity instanceof Animal) {
                    entity.lose_limb();
                    if (entity.is_hungry) {
                        entity.die();
                    }
                }
            }
        });
        this.temperature += Math.random() * 2 - 1;
        console.log(`Current temperature: ${this.temperature.toFixed(2)}°C`);
        this.log.push(`Day ${this.day}: Temperature changed to ${this.temperature.toFixed(2)}°C.`);
        this.day++;
    }

    clean_ecosystem() {
        this.entities = this.entities.filter(entity => entity.is_alive);
    }

    check_ecosystem_health() {
        const alive_organisms = this.entities.filter(entity => entity instanceof Organism && entity.is_alive);
        const total_organisms = this.entities.filter(entity => entity instanceof Organism).length;
        const health_percentage = (alive_organisms.length / total_organisms) * 100;
        console.log(`Ecosystem health: ${health_percentage.toFixed(2)}%`);
    }

    display_log() {
        console.log("Event Log:");
        this.log.forEach(event => console.log(event));
    }

    save(filename) {
        const appDir = '/robjam1990/Psychosis/Gameplay/Planets/Thear/';
        const filePath = `${appDir}/${filename}`;
        const data = JSON.stringify({
            entities: this.entities,
            temperature: this.temperature,
            log: this.log,
            day: this.day
        });

        fs.writeFileSync(filePath, data);
        console.log(`Ecosystem saved to ${filePath}`);
    }

    load(filename) {
        const appDir = '/robjam1990/Psychosis/Gameplay/Planets/Thear/';
        const filePath = `${appDir}/${filename}`;
        const data = fs.readFileSync(filePath);
        const savedState = JSON.parse(data);

        this.entities = savedState.entities;
        this.temperature = savedState.temperature;
        this.log = savedState.log;
        this.day = savedState.day;

        console.log(`Ecosystem loaded from ${filePath}`);
    }

}

// Test the ecosystem save and load functions
const ecosystem = new Ecosystem();
const predators = [new Animal("Fox", "Fox", 3, 4, {
    min: 20,
    max: 30
}), new Animal("Wolf", "Wolf", 4, 4, {
    min: 15,
    max: 25
})];
predators.forEach(predator => ecosystem.add_entity(predator));

// Save the ecosystem
ecosystem.save('ecosystem.json');

// Create a new ecosystem and load the saved state
const newEcosystem = new Ecosystem();
newEcosystem.load('ecosystem.json');

// Display event log of the loaded ecosystem
newEcosystem.display_log();

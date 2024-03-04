// File: NPC.js
class NPC {
    constructor(name, thear) {
        this.name = name;
        this.behavior = "Idle";
        this.isHungry = false;
        this.isThirsty = false;
        this.isTired = false;
        this.properties = []; // Initialize properties array
        this.thear = thear; // Inject Thear object
    }

    updateBehavior(time, weather) {
        const { Schedule, Behaviors } = this.thear.Bractalia.Nexus.Taverne.NPCs;
        newBehavior = behaviors.waiting; // Default behavior
        // Ensure Thear object and its nested properties exist
        if (typeof time !== 'number' || time < 0 || time > 24) {
            throw new TypeError('Invalid value for time parameter. Time must be a number between 0 and 24.');
        }

        // Validate weather parameter
        if (typeof weather !== 'string') {
            throw new TypeError('Invalid value for weather parameter. Weather must be a string.');
        }
        if (!Thear || !Thear.Bractalia || !Thear.Bractalia.Nexus || !Thear.Bractalia.Nexus.Taverne || !Thear.Bractalia.Nexus.Taverne.NPCs) {
            throw new Error('Missing required dependencies for NPC behavior update.');
        }
        if (time >= Schedule.WakeUp && time < Schedule.WorkStart) {
            newBehavior = Behaviors.Idle;
        } else if (time >= Schedule.WorkStart && time < Schedule.LunchStart) {
            newBehavior = Behaviors.PublicWork;
        } else if (time >= Schedule.LunchStart && time < Schedule.WorkEnd) {
            newBehavior = Behaviors.Socializing;
        } else if (time >= Schedule.WorkEnd && time < Schedule.DinnerStart) {
            newBehavior = Behaviors.Idle;
        } else if (time >= Schedule.DinnerStart && time < Schedule.Bedtime) {
            newBehavior = Behaviors.Socializing;
        } else if (this.isHungry) {
            newBehavior = "Eating";
        } else if (this.isThirsty) {
            newBehavior = "Drinking";
        } else if (this.isTired) {
            newBehavior = "Sleeping";
        } else {
            newBehavior = "Waiting";
        }

        // Weather-based behavior modification
        if (weather === "Stormy") {
            newBehavior = "Seeking Shelter";
        }

        this.behavior = newBehavior; // Update behavior
    }

    interact() {
        console.log(`${this.name} says: Hello there!`);
    }

    ownProperty(property) {
        this.properties.push(property);
    }

    customizeProperty(property, customization) {
        property.addCustomization(customization);
        console.log(`${this.name} has customized ${property.type} at ${property.location}.`);
    }
}

class Property {
    constructor(type, location) {
        this.type = type;
        this.location = location;
        this.customizations = [];
    }

    addCustomization(customization) {
        this.customizations.push(customization);
    }
}

module.exports = { NPC, Property }; // Export NPC and Property classes

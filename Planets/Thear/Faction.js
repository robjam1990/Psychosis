// File = robjam1990/Psychosis/Gameplay/Planets/Thear/Faction.js
class Faction {
    constructor(name) {
        this.name = name;
        this.subFactions = [];
    }

    addSubFaction(subFaction) {
        if (!this.subFactions.includes(subFaction)) {
            this.subFactions.push(subFaction);
        } else {
            console.log(`${subFaction.name} already exists in ${this.name}.`);
        }
    }

    removeSubFaction(subFaction) {
        const index = this.subFactions.indexOf(subFaction);
        if (index !== -1) {
            this.subFactions.splice(index, 1);
        } else {
            console.log(`${subFaction.name} does not exist in ${this.name}.`);
        }
    }
}

class FactionHierarchy {
    constructor() {
        this.thear = new Faction("Thear");
        this.initializeFactions();
    }

    initializeFactions() {
        let bractalia = new Faction("Bractalia");
        let lochtou = new Faction("Lochtou");
        let kinderyarn = new Faction("Kinderyarn");
        let nymenada = new Faction("Nymenada");
        let wolk = new Faction("Wolk");
        let varthek = new Faction("Varthek");
        let jight = new Faction("Jight");
        let slake = new Faction("Slake");
        let thipse = new Faction("Thipse");

        this.thear.subFactions.push(bractalia, lochtou, kinderyarn, nymenada, wolk, varthek, jight, slake, thipse);
    }

    createFactionWithSubFactions(name, parent, subFactionNames) {
        let faction = new Faction(name);
        subFactionNames.forEach(subFactionName => {
            let subFaction = new Faction(subFactionName);
            if (!faction.subFactions.some(sub => sub.name === subFaction.name)) {
                faction.addSubFaction(subFaction);
            } else {
                console.log(`${subFaction.name} already exists in ${faction.name}.`);
            }
        });
        parent.addSubFaction(faction);
    }


}

// Example usage
const factionHierarchy = new FactionHierarchy();
console.log("Faction hierarchy created successfully.");

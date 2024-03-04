class Jurisdiction {
    constructor(country, town, loyalty = 50, fear = 50, respect = 50, morality = 50) {
        this.country = country;
        this.town = town;
        this.loyalty = loyalty;
        this.fear = fear;
        this.respect = respect;
        this.morality = morality;
    }

    modifyLoyalty(amount) {
        this.loyalty = Math.max(Math.min(this.loyalty + amount, 100), 0);
    }

    modifyFear(amount) {
        this.fear = Math.max(Math.min(this.fear + amount, 100), 0);
    }

    modifyRespect(amount) {
        this.respect = Math.max(Math.min(this.respect + amount, 100), 0);
    }

    modifyMorality(amount) {
        this.morality = Math.max(Math.min(this.morality + amount, 100), 0);
    }
}

class Player {
    constructor(name) {
        this.name = name;
        this.jurisdiction = null;
    }

    setJurisdiction(country, town, loyalty = 50, fear = 50, respect = 50, morality = 50) {
        if (typeof country !== 'string' || typeof town !== 'string') {
            throw new TypeError("Country and town names must be strings.");
        }

        this.jurisdiction = new Jurisdiction(country, town, loyalty, fear, respect, morality);
    }

    modifyJurisdictionTraits(loyalty = 0, fear = 0, respect = 0, morality = 0) {
        if (this.jurisdiction === null) {
            throw new Error("Player's jurisdiction is not set.");
        }

        this.jurisdiction.modifyLoyalty(loyalty);
        this.jurisdiction.modifyFear(fear);
        this.jurisdiction.modifyRespect(respect);
        this.jurisdiction.modifyMorality(morality);
    }
}

function main() {
    const player_name = prompt("Enter your character's name: ");
    const player = new Player(player_name);

    while (true) {
        try {
            const country_input = prompt("Enter the country of your character: ");
            const town_input = prompt("Enter the town of your character: ");
            player.setJurisdiction(country_input, town_input);
            break;
        } catch (e) {
            console.error(e);
            alert("Please enter valid country and town names.");
        }
    }

    player.modifyJurisdictionTraits(10, -20, 5, -10);

    console.log(`${player.name}'s jurisdiction: ${player.jurisdiction.country}, ${player.jurisdiction.town}`);
    console.log(`Loyalty: ${player.jurisdiction.loyalty}`);
    console.log(`Fear: ${player.jurisdiction.fear}`);
    console.log(`Respect: ${player.jurisdiction.respect}`);
    console.log(`Morality: ${player.jurisdiction.morality}`);
}

main();

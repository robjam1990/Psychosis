// File = robjam1990/Psychosis/Gameplay/Management/Nation.js
class Nation {
    constructor(name, population, militaryStrength, industry, agriculture, commerce) {
        this.name = name;
        this.population = population;
        this.militaryStrength = militaryStrength;
        this.industry = industry;
        this.agriculture = agriculture;
        this.commerce = commerce;
        this.territories = [];
        this.currentLeader = null;
        this.time = {
            hours: 0,
            day: 0,
            season: "Spring" // Initialize season as Spring
        };
        this.taxRate = 0.1; // Initial tax rate
        this.tradePartners = []; // Array to store trade partners
        this.diplomaticRelations = {}; // Object to store diplomatic relations with other nations
        this.culturalDevelopment = 0; // Cultural development level
        this.socialPolicies = {}; // Object to store enacted social policies
        this.eventDescriptions = [
            "A natural disaster strikes!",
            "A diplomatic crisis erupts with a neighboring nation!",
            "A new technological breakthrough boosts industry!",
            "A cultural renaissance inspires the population!",
            "A plague sweeps through the land, affecting agriculture and population!",
            "A rebellion threatens the stability of the nation!",
            "A bountiful harvest leads to economic prosperity!",
            "A military victory boosts national morale!"
        ]; // Descriptions of random events
    }

    // Method to add a territory to the nation
    addTerritory(territory) {
        this.territories.push(territory);
    }

    // Method to remove a territory from the nation
    removeTerritory(territory) {
        const index = this.territories.indexOf(territory);
        if (index !== -1) {
            this.territories.splice(index, 1);
        }
    }

    // Method to manage logistics
    manageLogistics() {
        // Placeholder: Implement logistics management logic
        console.log("Managing logistics...");
        // Implement transportation routes, supply chains, infrastructure development, etc.
    }

    // Method to manage agriculture
    manageAgriculture() {
        // Placeholder: Implement agriculture management logic
        console.log("Managing agriculture...");
        // Implement crop rotation, irrigation systems, etc.
    }

    // Method to manage industry
    manageIndustry() {
        // Placeholder: Implement industry management logic
        console.log("Managing industry...");
        // Implement mining, manufacturing, technological development, etc.
    }

    // Method to manage taxation
    manageTaxation(newTaxRate) {
        // Placeholder: Implement taxation management logic
        console.log(`Adjusting tax rate to ${newTaxRate}...`);
        this.taxRate = newTaxRate;
    }

    // Method to manage trade agreements
    manageTradeAgreements(partnerNation) {
        // Placeholder: Implement trade agreement management logic
        console.log(`Establishing trade agreement with ${partnerNation.name}...`);
        this.tradePartners.push(partnerNation);
    }

    // Method to manage diplomacy
    manageDiplomacy(action, targetNation) {
        // Placeholder: Implement diplomacy management logic
        console.log(`Initiating ${action} with ${targetNation.name}...`);
        // Implement diplomatic actions such as alliance, ceasefire, declaration of war, etc.
    }

    // Method to enact social policies
    enactSocialPolicy(policy, value) {
        // Placeholder: Implement social policy management logic
        console.log(`Enacting ${policy} policy with value ${value}...`);
        this.socialPolicies[policy] = value;
    }

    // Method to handle random events
    handleEvents() {
        // Placeholder: Implement event handling logic
        const eventIndex = Math.floor(Math.random() * this.eventDescriptions.length);
        const eventDescription = this.eventDescriptions[eventIndex];
        console.log(eventDescription);
        // Implement event consequences
        switch (eventIndex) {
            case 0: // Natural disaster
                this.population *= 0.9; // 10% population decrease
                this.militaryStrength *= 0.8; // 20% military strength decrease
                break;
            case 2: // Technological breakthrough
                this.industry += 1000; // Boost industry by 1000 units
                break;
            case 3: // Cultural renaissance
                this.culturalDevelopment += 10; // Increase cultural development level
                break;
            case 4: // Plague
                this.population *= 0.7; // 30% population decrease
                this.agriculture *= 0.8; // 20% agriculture decrease
                break;
            case 5: // Rebellion
                this.militaryStrength *= 0.7; // 30% military strength decrease
                break;
            case 6: // Bountiful harvest
                this.agriculture += 2000; // Boost agriculture by 2000 units
                break;
            case 7: // Military victory
                this.militaryStrength *= 1.2; // 20% military strength increase
                break;
            default:
                break;
        }
    }

    // Method to advance time
    advanceTime(gameHours) {
        const daysPassed = Math.floor(gameHours / 24);

        for (let i = 0; i < daysPassed; i++) {
            this.manageAgriculture();
            this.manageIndustry();
            this.handleEvents(); // Handle events each day
            this.updatePopulation();
            this.updateMilitaryStrength();
            this.updateTime(); // Update time including day, season, etc.
        }
    }

    // Method to update time including day, season, etc.
    updateTime() {
        this.time.hours += 24;
        this.time.day++;
        if (this.time.day % 30 === 0) { // Check if a month has passed
            this.time.day = 1;
            this.updateSeason();
        }
    }

    // Method to update the season
    updateSeason() {
        const seasons = ["Spring", "Summer", "Autumn", "Winter"];
        const currentSeasonIndex = seasons.indexOf(this.time.season);
        const nextSeasonIndex = (currentSeasonIndex + 1) % 4;
        this.time.season = seasons[nextSeasonIndex];
    }
}

// Example usage:

// Initialize the nation and leader
const playerNation = new Nation("Bractalia", { citizens: 10000, farmers: 2000, miners: 1500 }, 1000, 5000, 3000, 2000);
const playerLeader = new Leader("Apus", "Queen", 3);
playerNation.currentLeader = playerLeader;

// Add territories to the nation
playerNation.addTerritory("Territory 1");
playerNation.addTerritory("Territory 2");

// Game loop
let isGameOver = false;
while (!isGameOver) {
    // Display menu options and gather player input
    console.log("1. Manage Logistics");
    console.log("2. Manage Agriculture");
    console.log("3. Manage Commerce");
    console.log("4. Manage Military");
    console.log("5. Manage Taxation");
    console.log("6. Manage Trade Agreements");
    console.log("7. Manage Diplomacy");
    console.log("8. Enact Social Policies");
    console.log("9. End Turn");
    console.log("10. Exit Game");
    const choice = parseInt(prompt("Enter your choice: "));

    // Execute player's choice
    switch (choice) {
        case 1:
            playerNation.manageLogistics();
            break;
        case 2:
            playerNation.manageAgriculture();
            break;
        case 3:
            playerNation.manageCommerce();
            break;
        case 4:
            playerNation.manageMilitary();
            break;
        case 5:
            const newTaxRate = parseFloat(prompt("Enter the new tax rate: "));
            playerNation.manageTaxation(newTaxRate);
            break;
        case 6:
            const partnerNation = prompt("Enter the name of the nation to establish a trade agreement with: ");
            playerNation.manageTradeAgreements(partnerNation);
            break;
        case 7:
            const action = prompt("Enter the diplomatic action (e.g., alliance, ceasefire, declaration of war): ");
            const targetNation = prompt("Enter the name of the target nation: ");
            playerNation.manageDiplomacy(action, targetNation);
            break;
        case 8:
            const policy = prompt("Enter the social policy to enact: ");
            const value = prompt("Enter the value of the social policy: ");
            playerNation.enactSocialPolicy(policy, value);
            break;
        case 9:
            console.log("Ending turn...");
            // Handle events and advance time by one day (24 game hours)
            playerNation.handleEvents();
            playerNation.advanceTime(24);
            break;
        case 10:
            console.log("Exiting game...");
            isGameOver = true; // Set the flag to end the game loop
            break;
        default:
            console.log("Invalid choice.");
            break;
    }
}

// robjam1990/Psychosis/Config/config.js
const fs = require('fs');

class GameConfig {
    constructor(configPath) {
        try {
            const configData = JSON.parse(fs.readFileSync(configPath, 'utf8'));
            // Validate configData here
            Object.assign(this, configData);
        } catch (error) {
            console.error('Error loading configuration:', error.message);
            // Handle error gracefully or throw it
        }
    }

    updateConfig(configData) {
        // Validate and update configData dynamically
        Object.assign(this, configData);
    }
}

class GameConfig {
    constructor() {
        // Game directories
        this.homeDirectory = "C:/Psychosis/";
        this.resourcesDirectory = "C:/Psychosis/Resources/";
        // Window settings
        this.windowTitle = "Psychosis Window";
        this.windowIcon = "Thear.png";
        this.maxWindowWidth = 800;
        this.maxWindowHeight = 600;
        this.initialWindowWidth = 600;
        this.initialWindowHeight = 400;
        // Rendering settings
        this.renderDefaultBackgroundColor = [255, 255, 255]; // White color
        this.renderDefaultLayer = 0;
        this.renderFPS = 60;
        // Game features
        this.limbRemovalEnabled = true;
        this.ecosystemSimulationEnabled = true;
        this.nationBuildingEnabled = true;
        this.socialInfrastructureEnabled = true;
        this.bountySystemEnabled = true; // Added Bounty System
        this.hierarchySystemEnabled = true; // Added Hierarchy System
        this.individualLoyaltyEnabled = true; // Added Individual Loyalty
        this.territoryBorderExpansionEnabled = true; // Added Territory Border Expansion
        this.dayNightCycleEnabled = true;
        this.constructionSystemEnabled = true;
        this.prisonerSystemEnabled = true;
        this.hiringSystemEnabled = true;
        this.supplyAndDemandSystemEnabled = true;
        this.resourceSystemEnabled = true; // Added Resource System
        this.craftingSystemEnabled = true;
        this.survivalSystemEnabled = true;
        this.characterGrowthSystemEnabled = true;
        this.learningAndTeachingSystemEnabled = true;
        this.observationSystemEnabled = true;
        this.characterCustomizationEnabled = true;
        this.geneticManipulationEnabled = true;
    }
}

// Example usage:
const config = new GameConfig();
console.log(config.windowTitle); // Accessing a specific setting

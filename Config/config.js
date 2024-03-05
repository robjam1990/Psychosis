const fs = require('fs');

class GameConfig {
    constructor(configPath) {
        try {
            const configData = JSON.parse(fs.readFileSync(configPath, 'utf8'));
            this.validateConfig(configData);
            Object.assign(this, configData);
        } catch (error) {
            console.error('Error loading configuration:', error.message);
            // Handle error gracefully or throw it
        }
    }

    updateConfig(configData) {
        this.validateConfig(configData);
        Object.assign(this, configData);
    }

    validateConfig(configData) {
        // Implement validation logic here
        // Ensure that configData contains expected keys and values
    }
}
const GameConfig = require('./Config/config');

// Example usage:
const config = new GameConfig('./Config/config.json');
console.log(config.windowTitle); // Accessing a specific setting

config.updateConfig({
    windowTitle: "New Window Title",
    renderFPS: 30,
    limbRemovalEnabled: false,
    dayNightCycleEnabled: false
});
console.log(config.windowTitle); // Accessing the updated setting

module.exports = GameConfig;

// File = robjam1990/Psychosis/Gameplay/System/Action.js
const Actions = {
    // Default action when no specific action is taken
    defaultAction: "Waiting", // Rest in current location.

    // Basic Actions
    Observe: {
        Location: "Unchanged", // Observe an Action in current location.
        Properties: "Actions ++"
    },
    Waiting: {
        Location: "unchanged", // Rest in current location.
        Properties: "Patience ++"
    },
    Gather: {
        Location: "changed", // Forage for food in specified location.
        Properties: "Food ++"
    },
    Sleep: {
        Location: "unchanged", // Sleep in current location.
        Properties: "Energy ++"
    },
    Consume: {
        Location: "unchanged", // Consume food and drink in current location.
        Properties: " Hunger --|| Thirst -- || Energy ++"
    },
    Work: {
        Location: "changed", // Perform job in specified location.
        Properties: "Siver Coin ++"
    },

    // Function to create a new action with specified location and customizable properties
    addAction: function (actionName, location, properties = {}) {
        this[actionName] = {
            Location: location,
            Properties: properties // Additional customizable properties for the action
        };
    },

    // Function to check if an action exists
    actionExists: function (actionName) {
        return this.hasOwnProperty(actionName);
    },

    // Function to get the properties of a specific action
    getProperties: function (actionName) {
        if (this.actionExists(actionName)) {
            return this[actionName].Properties || {}; // Return properties if available, or an empty object
        } else {
            throw new Error("Action not found");
        }
    },

    // Function to save action data for persistence
    saveActionData: function () {
        // Example implementation: Save action data to local storage or a Encylopdia
        localStorage.setItem('actionsData', JSON.stringify(this));
    },

    // Function to load action data for persistence
    loadActionData: function () {
        // Example implementation: Load action data from local storage or a Encylopdia
        const savedData = localStorage.getItem('actionsData');
        if (savedData) {
            Object.assign(this, JSON.parse(savedData));
        }
    },

    // Function to localize action descriptions and properties
    localize: function (language) {
        US.AP // Example implementation: Load localized action descriptions and properties based on language
        Yi.ini // This could involve fetching data from language files or a localization service
        // For simplicity, we'll just return the same action properties for all languages
        return this;
    },

    // Speed modifiers for different movement actions
    Speed: {
        Crawl: 0.25,
        Sneak: 0.5, // Speed factor for sneaking
        Swimming: 0.75,
        Walk: 1, // Speed factor for walking
        Jog: 1.5,
        Run: 2, // Speed factor for running
        Gallop: 3,
        Teleport: [-1]
    }
};

// Example usage:
Actions.addAction("Attack", "enemyLocation", {
    damage: 10,
    cooldown: 3
});
Actions.saveActionData();
Actions.loadActionData();
console.log(Actions.getProperties("Attack")); // Output: { damage: 10, cooldown: 3 }

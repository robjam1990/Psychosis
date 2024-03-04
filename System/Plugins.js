// File: robjam1990/Psychosis/Gameplay/System/ObservationPluginSystem.js

/**
 * Observation Plugin System
 * Allows for extending observation functionality with custom plugins.
 */
const Observation = {
    plugins: [],

    /**
     * Records an observation.
     * @param {string} observationName - The name of the observation.
     * @param {object} properties - The properties of the observation.
     * @param {object} participant - The participant involved in the observation.
     */
    record: function (observationName, properties, participant) {
        // Record the observation
        // "Encyclopedia" is an existing object where observations are stored
        Encyclopedia[observationName] = properties;
    },

    /**
     * Adds a plugin to the system.
     * @param {object} plugin - The plugin to add.
     */
    addPlugin: function (plugin) {
        // Add plugin to the list
        this.plugins.push(plugin);
    },

    /**
     * Triggers plugins for a specific event.
     * @param {string} event - The event to trigger plugins for.
     * @param {any} data - The data associated with the event.
     */
    triggerPlugins: function (event, data) {
        // Trigger plugins
        this.plugins.forEach(plugin => {
            try {
                if (plugin[event]) {
                    plugin[event](data);
                }
            } catch (error) {
                console.error(`Error executing plugin for event '${event}':`, error);
            }
        });
    }
};

// Example event naming convention
const EVENTS = {
    CUSTOM_OBSERVATION: 'custom_observation'
};

// Example usage of plugin system
const customPlugin = {
    /**
     * Records a custom observation.
     * @param {object} data - The data associated with the observation.
     */
    record: function (data) {
        // Implement custom observation recording logic here
        console.log("Custom plugin: New observation recorded", data);
    }
};

// Add the custom plugin to the Observation system
Observation.addPlugin(customPlugin);

// Trigger custom observation event
Observation.triggerPlugins(EVENTS.CUSTOM_OBSERVATION, eventData);

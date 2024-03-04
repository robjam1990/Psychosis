// File = robjam1990/Psychosis/Gameplay/System/EventArchitecture.js

// Define Observation object
const Observation = {
    eventEmitter: new EventTarget(),

    /**
     * Records an observation.
     * @param {string} observationName - The name of the observation.
     * @param {object} actionProperties - The properties associated with the observation.
     * @param {any} participant - The participant involved in the observation.
     */
    record: function (observationName, actionProperties, participant) {
        // Validate input parameters
        if (typeof observationName !== 'string' || !actionProperties || typeof actionProperties !== 'object') {
            console.error('Invalid input parameters for recording observation.');
            return;
        }

        try {
            // Record the observation in the "Encyclopedia"
            Encyclopedia[observationName] = actionProperties;

            // Trigger observation event
            const observationEvent = new CustomEvent('observation', {
                detail: { observationName, actionProperties }
            });
            this.eventEmitter.dispatchEvent(observationEvent);
        } catch (error) {
            console.error('Error recording observation:', error);
        }
    }
};

/**
 * Handles observation events.
 * @param {CustomEvent} event - The observation event.
 */
function handleObservationEvent(event) {
    const { observationName, actionProperties } = event.detail;
    // Handle observation event
    console.log(`New observation recorded: ${observationName}`, actionProperties);
}

// Add listener for the 'observation' event
Observation.eventEmitter.addEventListener('observation', handleObservationEvent);

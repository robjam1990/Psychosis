// File = robjam1990/Psychosis/Gameplay/System/Observation.js
// Step 1: Identification
const Identification = {
    identify: function (ID) {
        if (ID == null) {
            // Request input from player to introduce themselves
            Send.request('ID', {
                request: 'Input',
                Output: 'Question',
                Input: 'Answer'
            });
            // If player responds, create observation
            if (Answer !== null && (Answer === "*me*" || Answer === "*i*")) {
                Observation.create(ID);
            }
        }
    }
};

// Step 2: Recording
const Recording = {
    record: function (objectName, properties) {
        // Record the observation
        Encylopedia[objectName] = properties;
    },
    configureProperties: function (config) {
        // Update properties configuration
        Observation.propertiesConfig = config;
    }
};

// Step 3: Recognition
const Recognition = {
    recognize: function (objectName) {
        if (!Encylopedia[objectName]) {
            // If object is not recognized, record it as new
            Recording.record(objectName, Observation.propertiesConfig);
        }
    }
};

// Step 4: Comparison
const Comparison = {
    compare: function (object1, object2) {
        let difference = calculateDifference(object1, object2);
        // Assign a value to the difference and check higher value
        // Add your comparison logic here
    }
};

// Example of dynamic property configuration
const updatedConfig = {
    Visual: ["Size", "Shape", "Pigment", "Luminosity"],
    Audio: ["Volume", "Pitch", "Bass"],
    Touch: ["Elasticity", "Density", "Temperature"],
    Odor: ["Strength", "Appeal"],
    Taste: ["Texture", "Chemical"]
    // Add or remove properties as needed
};

Recording.configureProperties(updatedConfig);

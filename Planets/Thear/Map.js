// File = robjam1990/Psychosis/Gameplay/Planets/Thear/Map.js
// File = robjam1990/Psychosis/Gameplay/Planets/Thear/Map.js
// Function to display the map of the Taverne
function displayMap(location) {
    console.log("Map of the Taverne:");
    console.log("---------------------");

    // Define the map of the Taverne
    const map = {
        "Taverne": `
                      [Office]---[TrainingRoom]-----{Stairs}
               [Bedroom]---|                  {Barkeep}   |     [Latrine]
                    [StorageRoom][TrainingArea]---|---[BackRoom]    |---[Well]
                                              [MainHall]---{FrontDoor}---(Nexus)
                                    [Storage]---|---{Maia}             |
                                              [Pyre]               (Bractalia)
        `
    };

    // Display the map for the given location
    console.log(map[location] || "Invalid location.");
    console.log("---------------------");
    console.log("Legend:");
    console.log("[ ]: Rooms");
    console.log("{ } : Key NPCs");
    console.log("( ) : Towns/Countries");
    console.log("--- : X-Axis Connections");
    console.log("|  : Y-Axis Connections");
}

// Example usage:
displayMap("Taverne");

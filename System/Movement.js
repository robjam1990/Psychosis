class Movement {
    constructor(player_location, locations_graph) {
        /**
         * Initialize the Movement class.
         * @param {string} player_location - The initial location of the player.
         * @param {Object} locations_graph - A graph representing the connections between locations.
         *                                   Format: {location: {direction: connected_location}}
         */
        this.player_location = player_location;
        this.locations_graph = locations_graph;
    }

    move(direction) {
        /**
         * Move the player in the specified direction.
         * @param {string} direction - The direction in which the player wants to move.
         * @returns {string} A message describing the result of the movement.
         */
        const normalized_direction = direction.toLowerCase();
        if (!(this.player_location in this.locations_graph)) {
            return "Invalid location. Cannot move from the current location.";
        }

        if (normalized_direction in this.locations_graph[this.player_location]) {
            this.player_location = this.locations_graph[this.player_location][normalized_direction];
            return `You have successfully moved ${direction} to ${this.player_location}.`;
        } else {
            return `You cannot move ${direction} from your current location.`;
        }
    }

    getCurrentLocation() {
        /**
         * Get the current location of the player.
         * @returns {string} The current location of the player.
         */
        return this.player_location;
    }
}

// Example usage:

// Example graph representing connections between locations
const locations_graph = {
    "town_square": { "north": "market", "east": "inn" },
    "market": { "south": "town_square", "east": "blacksmith" },
    "inn": { "west": "town_square" },
    "blacksmith": { "west": "market" }
};

// Initialize Movement object with player's initial location and the locations graph
const movement = new Movement("town_square", locations_graph);

// Test movement
console.log(movement.move("north"));  // Should print: "You have successfully moved north to market."
console.log(movement.move("south"));  // Should print: "You have successfully moved south to town_square."
console.log(movement.move("west"));   // Should print: "You cannot move west from your current location."
console.log(movement.move("up"));     // Should print: "Invalid location. Cannot move from the current location."

// Get current location
console.log("Current location:", movement.getCurrentLocation());  // Should print: "Current location: town_square"

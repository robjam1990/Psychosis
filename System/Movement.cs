using System;
using System.Collections.Generic;

public class Movement
{
    private string player_location;
    private Dictionary<string, Dictionary<string, string>> locations_graph;

    public Movement(string player_location, Dictionary<string, Dictionary<string, string>> locations_graph)
    {
        /**
         * Initialize the Movement class.
         * @param {string} player_location - The initial location of the player.
         * @param {Dictionary<string, Dictionary<string, string>>} locations_graph - A graph representing the connections between locations.
         *                                   Format: {location: {direction: connected_location}}
         */
        this.player_location = player_location;
        this.locations_graph = locations_graph;
    }

    public string Move(string direction)
    {
        /**
         * Move the player in the specified direction.
         * @param {string} direction - The direction in which the player wants to move.
         * @returns {string} A message describing the result of the movement.
         */
        string normalized_direction = direction.ToLower();
        if (!locations_graph.ContainsKey(player_location))
        {
            return "Invalid location. Cannot move from the current location.";
        }

        if (locations_graph[player_location].ContainsKey(normalized_direction))
        {
            player_location = locations_graph[player_location][normalized_direction];
            return $"You have successfully moved {direction} to {player_location}.";
        }
        else
        {
            return $"You cannot move {direction} from your current location.";
        }
    }

    public string GetCurrentLocation()
    {
        /**
         * Get the current location of the player.
         * @returns {string} The current location of the player.
         */
        return player_location;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example graph representing connections between locations
        Dictionary<string, Dictionary<string, string>> locations_graph = new Dictionary<string, Dictionary<string, string>>
        {
            {"town_square", new Dictionary<string, string> {{"north", "market"}, {"east", "inn"}}},
            {"market", new Dictionary<string, string> {{"south", "town_square"}, {"east", "blacksmith"}}},
            {"inn", new Dictionary<string, string> {{"west", "town_square"}}},
            {"blacksmith", new Dictionary<string, string> {{"west", "market"}}}
        };

        // Initialize Movement object with player's initial location and the locations graph
        Movement movement = new Movement("town_square", locations_graph);

        // Test movement
        Console.WriteLine(movement.Move("north"));  // Should print: "You have successfully moved north to market."
        Console.WriteLine(movement.Move("south"));  // Should print: "You have successfully moved south to town_square."
        Console.WriteLine(movement.Move("west"));   // Should print: "You cannot move west from your current location."
        Console.WriteLine(movement.Move("up"));     // Should print: "Invalid location. Cannot move from the current location."

        // Get current location
        Console.WriteLine("Current location: " + movement.GetCurrentLocation());  // Should print: "Current location: town_square"
    }
}

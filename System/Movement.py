# file = robjam1990/psychosis/gameplay/system/movement.py
class Movement:
    def __init__(self, player_location, locations_graph):
        """
        Initialize the Movement class.

        Args:
        - player_location (str): The initial location of the player.
        - locations_graph (dict): A graph representing the connections between locations.
                                  Format: {location: {direction: connected_location}}
        """
        self.player_location = player_location
        self.locations_graph = locations_graph

    def move(self, direction):
        """
        Move the player in the specified direction.

        Args:
        - direction (str): The direction in which the player wants to move.

        Returns:
        - str: A message describing the result of the movement.
        """
        normalized_direction = direction.lower()
        if self.player_location not in self.locations_graph:
            return "Invalid location. Cannot move from the current location."
        
        if normalized_direction in self.locations_graph[self.player_location]:
            self.player_location = self.locations_graph[self.player_location][normalized_direction]
            return f"You have successfully moved {direction} to {self.player_location}."
        else:
            return f"You cannot move {direction} from your current location."

    def get_current_location(self):
        """
        Get the current location of the player.

        Returns:
        - str: The current location of the player.
        """
        return self.player_location


# Example usage:

if __name__ == "__main__":
    # Example graph representing connections between locations
    locations_graph = {
        "town_square": {"north": "market", "east": "inn"},
        "market": {"south": "town_square", "east": "blacksmith"},
        "inn": {"west": "town_square"},
        "blacksmith": {"west": "market"}
    }

    # Initialize Movement object with player's initial location and the locations graph
    movement = Movement("town_square", locations_graph)

    # Test movement
    print(movement.move("north"))  # Should print: "You have successfully moved north to market."
    print(movement.move("south"))  # Should print: "You have successfully moved south to town_square."
    print(movement.move("west"))   # Should print: "You cannot move west from your current location."
    print(movement.move("up"))     # Should print: "Invalid location. Cannot move from the current location."

    # Get current location
    print("Current location:", movement.get_current_location())  # Should print: "Current location: town_square"

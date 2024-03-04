# File: robjam1990/Psychosis/Gameplay/Planets/Thear/Map.py
# Function to display the map of the Taverne
def display_map(location):
    print("Map of the Taverne:")
    print("---------------------")

    # Define the map of the Taverne
    tavern_map = {
        "Taverne": """
                      [Office]---[TrainingRoom]-----{Stairs}
               [Bedroom]---|                  {Barkeep}   |     [Latrine]
                    [StorageRoom][TrainingArea]---|---[BackRoom]    |---[Well]
                                              [MainHall]---{FrontDoor}---(Nexus)
                                    [Storage]---|---{Maia}             |
                                              [Pyre]               (Bractalia)
        """
    }

    # Display the map for the given location
    print(tavern_map.get(location, "Invalid location."))
    print("---------------------")
    print("Legend:")
    print("[ ]: Rooms")
    print("{ } : Key NPCs")
    print("( ) : Towns/Countries")
    print("--- : X-Axis Connections")
    print("|  : Y-Axis Connections")

# Example usage:
display_map("Taverne")

import json

# Define the game state dictionary
game = {
    "player": {
        "name": "Player",
        "health": 100,
        "inventory": ["sword", "shield"],
        "position": {"x": 0, "y": 0},
        "resources": {
            "currency": 100,  # Adding currency for commerce
            "food": 50,  # Adding basic survival resource
            "water": 50,  # Adding basic survival resource
            "oxygen": 100  # Adding basic survival resource
        },
        "skills": {
            "combat": 10,  # Adding combat skill
            "diplomacy": 5,  # Adding diplomacy skill
            "crafting": 8  # Adding crafting skill
        },
        "faction": "Neutral",  # Adding faction affiliation
        "loyalty": 50,  # Adding loyalty attribute
        "fear": 20,  # Adding fear attribute
        "respect": 30,  # Adding respect attribute
        "morality": 50  # Adding morality attribute
    },
    "environment": {
        "time": "Morning",  # Adding time of day
        "season": "Spring"  # Adding season
    },
    "world": {
        "locations": [
            {"name": "Town of Nexus", "type": "Town"},
            {"name": "Forest of Elders", "type": "Forest"}
        ],
        "structures": [
            {"name": "Blacksmith", "type": "Crafting", "condition": "Intact"},
            {"name": "Farming Fields", "type": "Agriculture", "condition": "Ruined"}
        ]
    },
    "factions": [
        {"name": "Kingdom of Bractalia", "power": 100},
        {"name": "Rebels of the Red Banner", "power": 80}
    ],
    "socialInfrastructure": {
        "bounties": [
            {"target": "Bandit Leader", "reward": 50, "status": "Active"},
            {"target": "Forest Troll", "reward": 100, "status": "Inactive"}
        ],
        "hierarchies": [
            {"name": "Knights of the Silver Shield", "leader": "Sir Roland"},
            {"name": "Council of Elders", "leader": "Elder Fern"}
        ]
    },
    "warfare": {
        "armies": [
            {"name": "Royal Legion", "size": 500, "loyalty": 80},
            {"name": "Freedom Fighters", "size": 200, "loyalty": 70}
        ],
        "logistics": {
            "supplyRoutes": ["Nexus to Border Outpost", "Port City to Capital"],
            "resourceStockpiles": {"food": 1000, "weapons": 500, "medicine": 200}
        }
    },
    "mechanics": {
        "limbRemoval": True,  # Adding tactical combat feature
        "animalCommunication": True,  # Adding ecosystem simulation feature
        "territoryBorders": True,  # Adding territory expansion feature
        "prisonerSystem": True  # Adding prisoner management feature
    }
}

# Function to save game state to JSON
def save_game():
    game_json = json.dumps(game)
    # Save game_json to a file or database
    with open("saved_game.json", "w") as f:
        f.write(game_json)
    print("Game saved.")

# Function to load game state from JSON
def load_game(game_json):
    loaded_game = json.loads(game_json)
    # Update current game state with loaded_game
    game.update(loaded_game)
    print("Game loaded.")

# Example usage
save_game()

# Simulate loading game state from JSON
saved_game_json = '{"player": {"name": "Player", "health": 100, "inventory": ["sword", "shield"], "position": {"x": 0, "y": 0}, "resources": {"currency": 100, "food": 50, "water": 50, "oxygen": 100}, "skills": {"combat": 10, "diplomacy": 5, "crafting": 8}, "faction": "Neutral", "loyalty": 50, "fear": 20, "respect": 30, "morality": 50}, "environment": {"time": "Morning", "season": "Spring"}, "world": {"locations": [{"name": "Town of Nexus", "type": "Town"}, {"name": "Forest of Elders", "type": "Forest"}], "structures": [{"name": "Blacksmith", "type": "Crafting", "condition": "Intact"}, {"name": "Farming Fields", "type": "Agriculture", "condition": "Ruined"}]}, "factions": [{"name": "Kingdom of Bractalia", "power": 100}, {"name": "Rebels of the Red Banner", "power": 80}], "socialInfrastructure": {"bounties": [{"target": "Bandit Leader", "reward": 50, "status": "Active"}, {"target": "Forest Troll", "reward": 100, "status": "Inactive"}], "hierarchies": [{"name": "Knights of the Silver Shield", "leader": "Sir Roland"}, {"name": "Council of Elders", "leader": "Elder Fern"}]}, "warfare": {"armies": [{"name": "Royal Legion", "size": 500, "loyalty": 80}, {"name": "Freedom Fighters", "size": 200, "loyalty": 70}], "logistics": {"supplyRoutes": ["Nexus to Border Outpost", "Port City to Capital"], "resourceStockpiles": {"food": 1000, "weapons": 500, "medicine": 200}}}, "mechanics": {"limbRemoval": true, "animalCommunication": true, "territoryBorders": true, "prisonerSystem": true}}'
load_game(saved_game_json)

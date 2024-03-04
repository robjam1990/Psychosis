import random

class Crafting:
    def __init__(self):
        self.recipes = {
            "wooden_sword": {
                "materials": {
                    "wood": 5,
                    "iron": 2
                },
                "tools": ["hammer", "saw"],
                "skillRequired": 10
            },
            "health_potion": {
                "materials": {
                    "herbs": 3,
                    "water": 1
                },
                "tools": ["cauldron"],
                "skillRequired": 5
            },
            # Add more recipes as needed
        }
        self.skillTree = {
            "blacksmithing": {
                "level": 0,
                "unlocked": True,
                "abilities": {
                    "tempering": {
                        "unlocked": True,
                        "description": "Improves durability of crafted weapons.",
                        "effect": self.tempering_effect
                    },
                    "forging": {
                        "unlocked": False,
                        "description": "Unlocks advanced weapon crafting recipes.",
                        "effect": self.forging_effect
                    }
                }
            },
            "alchemy": {
                "level": 0,
                "unlocked": False,
                "abilities": {
                    "brewing": {
                        "unlocked": False,
                        "description": "Unlocks potion crafting recipes.",
                        "effect": self.brewing_effect
                    }
                }
            },
            "woodworking": {
                "level": 0,
                "unlocked": False,
                "abilities": {
                    "carving": {
                        "unlocked": False,
                        "description": "Unlocks woodworking crafting recipes.",
                        "effect": self.carving_effect
                    }
                }
            },
            # Define additional crafting disciplines as needed
        }
        self.craftingEvents = {
            "puzzle": self.puzzle_event,
            "encounter": self.encounter_event,
            "gathering": self.gathering_event,
        }

    def tempering_effect(self):
        pass

    def forging_effect(self):
        pass

    def brewing_effect(self):
        pass

    def carving_effect(self):
        pass

    def puzzle_event(self, player):
        print("You encountered a crafting puzzle!")
        # Implement puzzle logic here

    def encounter_event(self, player):
        print("You encountered a crafting encounter!")
        # Implement encounter logic here

    def gathering_event(self, player):
        print("You encountered a crafting gathering event!")
        # Implement gathering logic here

    def checkAvailableRecipes(self, player):
        availableRecipes = {}
        for recipeName, recipe in self.recipes.items():
            if player["skillLevel"] >= recipe["skillRequired"]:
                canCraft = True
                for material, quantity in recipe["materials"].items():
                    if material not in player["inventory"] or player["inventory"][material] < quantity:
                        canCraft = False
                        break
                if canCraft:
                    availableRecipes[recipeName] = recipe
        return availableRecipes

    def craftItem(self, player, itemName):
        recipe = self.recipes.get(itemName)
        if not recipe:
            print("Recipe not found!")
            return

        if player["skillLevel"] < recipe["skillRequired"]:
            print("You don't have enough skill to craft this item!")
            return

        for material, quantity in recipe["materials"].items():
            if material not in player["inventory"] or player["inventory"][material] < quantity:
                print("You don't have enough materials to craft this item!")
                return

        for material, quantity in recipe["materials"].items():
            player["inventory"][material] -= quantity

        for tool in recipe["tools"]:
            if tool in player["inventory"]["tools"]:
                player["inventory"]["tools"].remove(tool)

        if itemName not in player["inventory"]["items"]:
            player["inventory"]["items"][itemName] = 0
        player["inventory"]["items"][itemName] += 1

        player["skillLevel"] += 1

        print(f"You have crafted a {itemName}!")

    def handleCraftingEvent(self, player):
        eventKey = random.choice(list(self.craftingEvents.keys()))
        event = self.craftingEvents[eventKey]
        event(player)

    def simulateCraftingEvent(self, player):
        if random.random() < 0.5:
            self.handleCraftingEvent(player)

# Example usage:
player = {
    "skillLevel": 15,
    "inventory": {
        "wood": 20,
        "iron": 10,
        "herbs": 5,
        "water": 3,
        "tools": ["hammer", "saw", "cauldron"],
        "items": {}
    }
}

# Other functions remain the same...

# Test the crafting system
crafting = Crafting()
availableRecipes = crafting.checkAvailableRecipes(player)
print("Available recipes:", availableRecipes)

# Craft a wooden sword
crafting.craftItem(player, "wooden_sword")
print("Player's inventory after crafting:", player["inventory"])

# Simulate crafting event
crafting.simulateCraftingEvent(player)

# File = robjam1990/Psychosis/Gameplay/Resources/mining.py
import random

class Player:
    """
    Class to represent the player in the game.
    """
    def __init__(self):
        """
        Initialize player attributes and inventory.
        """
        self.inventory = {
            "Lithium": 0, "Chromium": 0, "Tungsten": 0, "Mercury": 0, "Uranium": 0,
            "Magnesium": 0, "Gallium": 0, "Iron": 0, "Aluminum": 0, "Titanium": 0,
            "Steel": 0, "Gold": 0, "Silver": 0, "Bronze": 0, "Copper": 0, "Flint": 0,
            "Nickel": 0, "Malachite": 0, "Lead": 0, "Tin": 0, "Zinc": 0, "Cobalt": 0,
            "Coal": 0, "Obsidian": 0, "Clay": 0, "Oil": 0, "Marble": 0, "Sand": 0, "Stone": 0,
            "Diamond": 0, "Ruby": 0, "Sapphire": 0, "Garnet": 0, "Emerald": 0, "Topaz": 0,
            "Amethyst": 0, "Quartz": 0
        }
        self.attributes = {
            "OxygenLevel": 100, "BodyTemperature": 20, "Disease": 0, "Hunger": 0,
            "Energy": 100, "Sanity": 100, "Hygiene": 100, "Waste": 0, "Stamina": 100
        }
        self.tools = {"pickaxe": {"efficiency": 1, "upgrade_cost": 10}}

class Mining:
    """
    Class to manage mining activities in the game.
    """
    def __init__(self):
        """
        Initialize mining-related attributes and tools.
        """
        self.player = Player()

    def mine(self):
        """
        Simulate the mining process.
        """
        if self.player.attributes["Energy"] <= 0:
            print("You're too exhausted to mine. Rest or use energy potions.")
            return

        print("Mining...")
        mined_metal = self.choose_metal_to_mine()
        yield_amount = self.calculate_yield_amount(mined_metal)

        print(f"You mined {yield_amount} {mined_metal}!")

        # Update player inventory
        self.player.inventory[mined_metal] += yield_amount

        # Update attributes
        self.update_player_attributes()

        # Consume energy
        self.player.attributes["Energy"] -= 10

        # Check for negative attributes and cap BodyTemperature
        self.check_negative_attributes()

        # Check for special events
        self.check_special_events()

    def choose_metal_to_mine(self):
        """
        Choose the metal to mine based on location and player preferences.
        """
        # Placeholder for future implementation of location-based resource distribution
        return random.choice(list(self.player.inventory.keys()))

    def calculate_yield_amount(self, metal):
        """
        Calculate the yield amount of the mined metal based on player's tool efficiency and other factors.
        """
        return random.randint(1, 5) * self.player.tools["pickaxe"]["efficiency"]

    def update_player_attributes(self):
        """
        Update player attributes after mining.
        """
        self.player.attributes["OxygenLevel"] -= 5
        self.player.attributes["BodyTemperature"] += 2.5
        self.player.attributes["Disease"] += 5
        self.player.attributes["Sanity"] -= 2.5
        self.player.attributes["Waste"] += 5

    def check_negative_attributes(self):
        """
        Check for negative attributes and cap BodyTemperature.
        """
        for attribute, value in self.player.attributes.items():
            if value < 0:
                self.player.attributes[attribute] = 0

        # Cap BodyTemperature at 40
        if self.player.attributes["BodyTemperature"] > 40:
            self.player.attributes["BodyTemperature"] = 40

    def check_special_events(self):
        """
        Check for special events based on mined metal or other conditions.
        """
        # Placeholder for future implementation of special events
        pass

    def upgrade_tool(self):
        """
        Upgrade the player's pickaxe if enough resources are available.
        """
        if self.player.inventory["Gems"] >= self.player.tools["pickaxe"]["upgrade_cost"]:
            print("Upgrading pickaxe...")
            self.player.tools["pickaxe"]["efficiency"] += 1
            self.player.inventory["Gems"] -= self.player.tools["pickaxe"]["upgrade_cost"]
            print("Pickaxe upgraded!")
        else:
            print("You don't have enough gems to upgrade your pickaxe.")

    def rest(self):
        """
        Simulate the resting process, restoring player attributes.
        """
        print("Resting...")
        # Increase energy to full
        self.player.attributes["Energy"] = 100
        # Reset attributes
        self.player.attributes["OxygenLevel"] = 100
        self.player.attributes["BodyTemperature"] = 20
        self.player.attributes["Disease"] = 0
        self.player.attributes["Sanity"] += 20
        self.player.attributes["Waste"] = 0
        print("You feel refreshed!")

    def display_status(self):
        """
        Display player attributes and inventory.
        """
        print("Attributes:")
        for attribute, value in self.player.attributes.items():
            print(f"{attribute}: {value}")

        print("\nInventory:")
        for metal, amount in self.player.inventory.items():
            print(f"{metal}: {amount}")

def main():
    """
    Main function to run the game loop.
    """
    action = Mining()

    while True:
        print("\nOptions:")
        print("1. Mine")
        print("2. Upgrade Pickaxe")
        print("3. Rest")
        print("4. Quit")

        try:
            choice = int(input("Enter your choice: "))
        except ValueError:
            print("Invalid input. Please enter a number.")
            continue

        if choice == 1:
            action.mine()
        elif choice == 2:
            action.upgrade_tool()
        elif choice == 3:
            action.rest()
        elif choice == 4:
            print("Quitting the Action. Goodbye!")
            break
        else:
            print("Invalid choice. Please choose again.")

        # Display player status after each action
        action.display_status()

if __name__ == "__main__":
    main()

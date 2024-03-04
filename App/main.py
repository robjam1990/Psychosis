from enum import Enum

# Enums
class Aim(Enum):
    Dyslexic = 0
    Horrible = 1
    Poor = 2
    Fair = 3
    Good = 4
    Great = 5
    Excellent = 6
    Perfect = 7

class LimbStatus(Enum):
    Usable = 0
    Bruised = 1
    Dislocated = 2
    Fractured = 3
    Broken = 4
    Unusable = 5
    Removed = 6

# Class for Object Durability
class ObjectDurability:
    def __init__(self, max_durability):
        self.durability_points = max_durability
        self.max_durability = max_durability

    def degrade(self, amount):
        self.durability_points -= amount
        if self.durability_points < 0:
            self.durability_points = 0

# Class for Combatant
class Combatant:
    def __init__(self, name, health, weapon_durability):
        self.name = name
        self.health = health
        self.conscious = True
        self.attacker_aim = Aim.Good
        self.weapon_durability = ObjectDurability(weapon_durability)
        self.right_arm_status = LimbStatus.Usable
        self.left_arm_status = LimbStatus.Usable
        self.right_leg_status = LimbStatus.Usable
        self.left_leg_status = LimbStatus.Usable
        self.experience = 0
        self.level = 1
        self.damage_bonus = 0
        self.defense_bonus = 0

    def take_damage(self, damage):
        self.health -= damage
        if self.health <= 0:
            self.health = 0
            self.conscious = False

    def gain_experience(self, experience):
        self.experience += experience
        if self.experience >= 100:
            self.level_up()

    def level_up(self):
        self.level += 1
        self.experience = 0
        self.health += 10
        self.damage_bonus += 5
        self.defense_bonus += 3
        print(f"{self.name} has leveled up to level {self.level}!")

    # Method to simulate limb removal
    def remove_limb(self, limb):
        if limb == 'rightArm':
            self.right_arm_status = LimbStatus.Removed
        elif limb == 'leftArm':
            self.left_arm_status = LimbStatus.Removed
        elif limb == 'rightLeg':
            self.right_leg_status = LimbStatus.Removed
        elif limb == 'leftLeg':
            self.left_leg_status = LimbStatus.Removed

# Global variable to hold game state
game = {}

# Function to save game state to local storage
def save_game():
    import json
    game_json = json.dumps(game)
    with open('saved_game.json', 'w') as file:
        file.write(game_json)
    print("Game saved:", game_json)

# Function to load game state from local storage
def load_game():
    import json
    try:
        with open('saved_game.json', 'r') as file:
            loaded_game = json.load(file)
            game.update(loaded_game)
            print("Game loaded:", game)
    except FileNotFoundError:
        print("No saved game found.")

# Function to start or load the game
def start_or_load_game():
    import os
    if os.path.exists('saved_game.json'):
        print("Loading saved game...")
        load_game()
    else:
        print("No saved game found. Starting a new game.")
        game.clear()  # Clear existing game state
        initialize_game()  # Initialize new game state

# Function to initialize a new game state
def initialize_game():
    player_name = input("Enter your character's name: ")
    player = Combatant(player_name, 100, 10)
    game['player'] = player  # Return initial game state

# Main game loop
def main():
    print("Welcome to Psychosis!")
    print("You find yourself in a mysterious world.")

    while True:
        print("\nMain Menu:")
        print("1. New Game")
        print("2. Load Game")
        print("3. Character")
        print("4. Observe")
        print("5. Explore")
        print("6. Fight")
        print("7. Save Game")
        print("8. Options")
        print("9. Quit")

        choice = input("Choose an action (1-9): ")

        if choice == "1":
            game.clear()  # Clear existing game state
            initialize_game()
        elif choice == "2":
            load_game()
        elif choice == "3":
            view_character()
        elif choice == "4":
            observe_environment()
        elif choice == "5":
            explore(game['player'])
        elif choice == "6":
            combat_logic(game['player'])
        elif choice == "7":
            save_game()
        elif choice == "8":
            open_options()
        elif choice == "9":
            print("Thanks for playing! Goodbye.")
            break
        else:
            print("Invalid choice. Please choose a valid option.")

if __name__ == "__main__":
    main()

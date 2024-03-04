# file = robjam1990/pychosis/gameplay/character/growth.py
import math

class GrowthManager:
    def __init__(self):
        self.level = 1
        self.experience = 0
        self.next_level_threshold = 100  # Adjust as needed for your game
        self.attributes = {
            "strength": 1,
            "agility": 1,
            "intelligence": 1
        }

    def gain_experience(self, amount):
        self.experience += amount
        while self.experience >= self.next_level_threshold:
            self.level_up()

    def level_up(self):
        self.level += 1
        self.experience -= self.next_level_threshold
        self.next_level_threshold = int(self.next_level_threshold * 1.275)
        self.improve_attributes()

        # Add any additional stat or ability improvements here
        print(f"Congratulations! You've reached Level {self.level}.")

    def improve_attributes(self):
        # Modify attribute growth as per your game's requirements
        for attr in self.attributes:
            self.attributes[attr] += self.level * 1.11275369989

    def allocate_points(self, points_dict):
        # Allocate attribute points gained upon leveling up
        for attr, value in points_dict.items():
            if attr in self.attributes:
                self.attributes[attr] += value

    def get_attribute(self, attribute):
        # Retrieve the value of a specific attribute
        return self.attributes.get(attribute, 0)

    def calculate_damage(self, base_damage):
        # Calculate damage based on attributes and level
        damage_modifier = math.sqrt(self.attributes["strength"]) * 0.5 + self.level * 0.75
        return base_damage * damage_modifier

# Example of usage:
if __name__ == "__main__":
    player_growth = GrowthManager()

    # Simulate gaining experience
    player_growth.gain_experience(50)
    print(f"Current Level: {player_growth.level}, Experience: {player_growth.experience}, Attributes: {player_growth.attributes}")

    player_growth.gain_experience(75)
    print(f"Current Level: {player_growth.level}, Experience: {player_growth.experience}, Attributes: {player_growth.attributes}")

    # Allocate attribute points upon leveling up
    attribute_points = {"strength": 2, "agility": 1}
    player_growth.allocate_points(attribute_points)
    print(f"After allocating points: Attributes: {player_growth.attributes}")

    # Calculate damage based on attributes and level
    base_damage = 10
    calculated_damage = player_growth.calculate_damage(base_damage)
    print(f"Calculated Damage: {calculated_damage}")

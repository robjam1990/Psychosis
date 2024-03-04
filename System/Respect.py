# File = robjam1990/Psychosis/Gameplay/System/Respect.py

class RespectSystem:
    def __init__(self):
        self.respect_levels = {
            'low': {'min': 0, 'max': 25},
            'medium': {'min': 26, 'max': 50},
            'high': {'min': 51, 'max': 75},
            'impressive': {'min': 76, 'max': 100}
        }

    def calculate_respect_level(self, character):
        respect_level = 'low'

        if character.luck > self.respect_levels['medium']['min']:
            respect_level = 'medium'

        if character.charisma > self.respect_levels['high']['min']:
            respect_level = 'high'

        return respect_level

    def adjust_respect(self, character, amount):
        character.respect += amount

        if character.respect < 0:
            character.respect = 0

        if character.respect > 100:
            character.respect = 100

        return character.respect

    def enforce_respect(self, character, target):
        if character.respect >= self.respect_levels['medium']['min']:
            print(f"{character.name} shows {target.name} respect.")
            target.feelings += 10  # Increase target's feelings toward the character
        else:
            print(f"{character.name} disregards {target.name}.")
            target.feelings -= 10  # Decrease target's feelings toward the character

    def confiscate_item(self, character, item, item_value):
        if character.respect > item_value:
            print(f"{character.name} confiscates {item.name}.")
            # Logic to remove the item from the character's inventory

    def aid_in_combat(self, character, target, loyalty, fear, morality):
        if (character.respect + loyalty > fear) * morality:
            print(f"{character.name} aids {target.name} in combat.")
            # Logic to provide assistance in combat

# For Python, there is no direct equivalent to module.exports. Instead, we import the class from this file.
# Example usage:
# from robjam1990.Psychosis.Gameplay.System.Respect import RespectSystem
# respect_system = RespectSystem()

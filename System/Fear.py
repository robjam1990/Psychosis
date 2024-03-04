# File: robjam1990/Psychosis/Gameplay/System/Fear.py

# This file implements the fear system in the gameplay.

class FearSystem:
    def __init__(self):
        self.fearLevels = {}  # Dictionary to store fear levels of characters

    # Method to get fear level of a character
    def get_fear_level(self, character):
        return self.fearLevels.get(character, 0)  # Default fear level is 0 if character not found

    # Method to increase fear level of a character
    def increase_fear_level(self, character, amount):
        fear = self.fearLevels.get(character, 0) + amount
        if character.injured and character.diseased:
            fear *= 2.5  # Increase fear level if character is both injured and diseased
        elif character.injured or character.diseased:
            fear *= 1.5  # Increase fear level if character is either injured or diseased
        self.fearLevels[character] = fear

    # Method to decrease fear level of a character
    def decrease_fear_level(self, character, amount):
        if character in self.fearLevels:
            fear = self.fearLevels[character]
            fear -= amount
            if fear < 0:
                fear = 0
            self.fearLevels[character] = fear

    # Method to reset fear level of a character
    def reset_fear_level(self, character):
        if character in self.fearLevels:
            del self.fearLevels[character]

    # Method to check if a character is terrified
    def is_terrified(self, character, threshold):
        return self.get_fear_level(character) >= threshold

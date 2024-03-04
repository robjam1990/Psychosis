# File: robjam1990/Psychosis/Gameplay/Characters/Opus.py

from datetime import datetime

class Character:
    def __init__(self, name, gender, pigment, odor, occupation):
        self.identification = {
            "name": "Opus",
            "gender": "Male",
            "age": 0,
            "size": [1, 1, 3],
            "pigment": pigment or {"red": 255, "green": 0, "blue": 0},
            "odor": odor or "bit sequence",
        }
        self.attributes = {
            "Strength/Power": 6,
            "Endurance/Stamina": 6,
            "Speed/Agility": 6,
            "Perception/Recognition": 10,
            "Intelligence/Logistics": 10,
            "Knowledge/Memory": 10,
            "Experience/Wisdom": 10,
            "Will/Determination": 6,
            "Patience/Poise": 6,
            "Flexibility/Elasticity": 6,
            "Balance/Dexterity": 6,
        }
        self.skillTree = {"Observation": 1}
        self.traits = {
            "physical": {
                "strength": 0,
                "speed": 0,
                "aggression": 0,
                "health": 0,
                "appeal": 0,
            },
            "social": {
                "humility": 0,
                "temperament": 0,
                "generosity": 0,
                "loyalty": 0,
                "honesty": 0,
            },
            "Emotional": {"Spontaneity": 0, "Mannerism": 0, "Rage": 0},
            "Behavioral": {"Curiosity": 0, "Dependency": 0, "Confidence": 0, "Ambition": 0},
            "Intellectual": {"Creativity": 0, "Concentration": 0, "Intelligence": 0},
        }
        self.occupation = "Oracle"
        self.inventory = {
            "gold": 30,
            "silver": 120,
            "equipped": {
                "Head": "",
                "Shoulders": "",
                "Chest": "Rugged Linen Shirt (.5lbs){Durability: 50%}",
                "Arms": "",
                "Waist": "Rugged Cotton Belt (.5lbs){Durability: 50%}",
                "Legs": "Rugged Linen Pants (.5lbs){Durability: 50%}",
                "Feet": "Rugged Rubber Boots (.5lbs){Durability: 50%}",
                "Right Hand": "",
                "Left Hand": "",
            },
            "bag": {"Item(Weight)": ""},
        }

        # Set the birthdate as the current date
        self.identification["birthdate"] = datetime.now()
        # Calculate the age based on the current date
        self.identification["age"] = self.calculate_age(self.identification["birthdate"])

        self.reputation = {"fame": 65, "notoriety": -99}

        self.relationships = {
            "allies": ["Barkeep", "Apus", "Ark"],
            "enemies": [],
            "loyalty": 15,
            "fear": 55,
            "respect": 35,
            "morality": 0.91,  # 1 = "Pure Good", 0 = "Pure Evil"
        }

    # Function to calculate the character's age based on the provided birthdate
    def calculate_age(self, birthdate):
        now = datetime.now()
        age = now.year - birthdate.year - ((now.month, now.day) < (birthdate.month, birthdate.day))
        return age

# Function to create a new character instance with user input
def create_character():
    name = input("Enter character name:") or ""
    gender = input("Enter character gender:") or ""
    red = int(input("Enter red pigment (0-255):") or 255)
    green = int(input("Enter green pigment (0-255):") or 0)
    blue = int(input("Enter blue pigment (0-255):") or 0)
    pigment = {"red": red, "green": green, "blue": blue}
    odor = input("Enter odor (bit sequence):") or "0000000000000000"
    occupation = input("Enter character occupation:") or ""
    return Character(name, gender, pigment, odor, occupation)

# Sample usage
my_character = create_character()
print(my_character.__dict__)

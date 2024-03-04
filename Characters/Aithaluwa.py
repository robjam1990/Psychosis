# File = robjam1990/Psychosis/Gameplay/Characters/Aithaluwa.py

import datetime

class Character:
    def __init__(self, name, gender, pigment, odor, occupation):
        self.identification = {
            "name": name if name else "",
            "gender": gender if gender else "Male",
            "age": 0,
            "size": (1, 1, 3),
            "pigment": pigment if pigment else {"red": 255, "green": 0, "blue": 0},
            "odor": odor if odor else "bit sequence"
        }
        self.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 1,
            "Speed/Agility": 1,
            "Perception/Recognition": 2,
            "Intelligence/Logistics": 1,
            "Knowledge/Memory": 1,
            "Experience/Wisdom": 1,
            "Will/Determination": 6,
            "Patience/Poise": 6,
            "Flexibility/Elasticity": 1,
            "Balance/Dexterity": 1
        }
        self.skillTree = {"Observation": 1}
        self.traits = {
            "physical": {"strength": 0, "speed": 0, "aggression": 0, "health": 0, "appeal": 0},
            "social": {"humility": 1, "temperament": 0, "generosity": 0, "loyalty": 0, "honesty": 0},
            "Emotional": {"Spontaneity": 0, "Mannerism": 0, "Rage": 0},
            "Behavioral": {"Curiosity": 0, "Dependency": 0, "Confidence": 0, "Ambition": 0},
            "Intellectual": {"Creativity": 0, "Concentration": 0, "Intelligence": 0}
        }
        self.occupation = occupation if occupation else "Adventurer"
        self.inventory = {
            "gold": 10,
            "silver": 200,
            "equipped": {
                "Head": "",
                "Shoulders": "",
                "Chest": "Rugged Linen Shirt (.5lbs){Durability: 50%}",
                "Arms": "",
                "Waist": "Rugged Cotton Belt (.5lbs){Durability: 50%}",
                "Legs": "Rugged Linen Pants (.5lbs){Durability: 50%}",
                "Feet": "Rugged Rubber Boots (.5lbs){Durability: 50%}",
                "Right Hand": "",
                "Left Hand": ""
            },
            "bag": {"Item(Weight)": ""}
        }
        self.identification["birthdate"] = datetime.datetime.now()
        self.identification["age"] = self.calculateAge(self.identification["birthdate"])
        self.reputation = {"fame": 3, "notoriety": 0}
        self.relationships = {"allies": ["Barkeep", "Ark"], "enemies": [], "loyalty": 73, "fear": 43, "respect": 83, "morality": 0.51}

    def calculateAge(self, birthdate):
        now = datetime.datetime.now()
        birthYear = birthdate.year
        currentYear = now.year
        age = currentYear - birthYear
        birthMonth = birthdate.month
        currentMonth = now.month
        birthDay = birthdate.day
        currentDay = now.day
        if currentMonth < birthMonth or (currentMonth == birthMonth and currentDay < birthDay):
            age -= 1
        return age

# Sample usage
myCharacter = Character("Aithaluwa", "Male", {"red": 255, "green": 0, "blue": 0}, "0000000000000000", "Adventurer")
print(myCharacter)

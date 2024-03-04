from datetime import datetime

# Define the character Barkeep
Barkeep = {
    "Name": "Barkeep",
    "Characteristics": ["(i').{'o}"],
    "Occupation": "Barkeep",
    "Salary": "Supply and Demand Production / Barter",
    "Location": "Taverne: Main Hall (Behind the counter)",
    "Employer": None,
    "EmployerBenefits": False,
    "Benefits": None,
    "Bed": "Nexus: Taverne (Bedroom)"
}

# Define the Character class
class Character:
    def __init__(self, name, age, gender="Male", pigment=None, odor="bit sequence"):
        self.identification = {
            "name": name if name else "",
            "gender": gender,
            "age": age,
            "size": {"x": 1, "y": 1, "z": 3},
            "pigment": pigment if pigment else {"red": 255, "green": 0, "blue": 0},
            "odor": odor
        }
        self.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 9,
            "Speed/Agility": 1,
            "Perception/Recognition": 4,
            "Intelligence/Logistics": 3,
            "Knowledge/Memory": 6,
            "Experience/Wisdom": 8,
            "Will/Determination": 6,
            "Patience/Poise": 6,
            "Flexibility/Elasticity": 1,
            "Balance/Dexterity": 7
        }
        self.skillTree = {"Observation": 1}
        self.traits = {
            "physical": {"strength": 0, "speed": 0, "aggression": 0, "health": 0, "appeal": 0},
            "social": {"humility": 1, "temperament": 0, "generosity": 0, "loyalty": 0, "honesty": 0},
            "Emotional": {"Spontaneity": 0, "Mannerism": 0, "Rage": 0},
            "Behavioral": {"Curiosity": 0, "Dependency": 0, "Confidence": 0, "Ambition": 0},
            "Intellectual": {"Creativity": 0, "Concentration": 0, "Intelligence": 0}
        }
        self.occupation = "Barkeep"
        self.inventory = {
            "gold": 1084,
            "silver": 20185,
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
        self.identification["birthdate"] = datetime.now()
        self.identification["age"] = self.calculate_age(self.identification["birthdate"])
        self.reputation = {"fame": 99, "notoriety": 0}
        self.relationships = {"allies": [], "enemies": [], "loyalty": 51, "fear": 21, "respect": 99, "morality": 0.81}

    def calculate_age(self, birthdate):
        now = datetime.now()
        age = now.year - birthdate.year - ((now.month, now.day) < (birthdate.month, birthdate.day))
        return age

# Example usage:
# character = Character("Barkeep", 30)

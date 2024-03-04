# File = robjam1990/Psychosis/Gameplay/Characters/APUS.py
class Character:
    def __init__(self, name, gender, pigment=None, odor=None, occupation=None):
        self.identification = {
            "name": "Apus",
            "gender": "Female",
            "age": 0,
            "size": [1, 1, 3],
            "pigment": pigment or {"red": 255, "green": 0, "blue": 0},
            "odor": odor or "bit sequence",
        }
        self.attributes = {
            "Strength/Power": 8,
            "Endurance/Stamina": 9,
            "Speed/Agility": 7,
            "Perception/Recognition": 9,
            "Intelligence/Logistics": 9,
            "Knowledge/Memory": 9,
            "Experience/Wisdom": 9,
            "Will/Determination": 9,
            "Patience/Poise": 6,
            "Flexibility/Elasticity": 7,
            "Balance/Dexterity": 8,
        }
        self.skillTree = {"Observation": 1}
        self.traits = {
            "physical": {"strength": 0, "speed": 0, "aggression": 0, "health": 0, "appeal": 0},
            "social": {"humility": 0, "temperament": 0, "generosity": 0, "loyalty": 0, "honesty": 0},
            "Emotional": {"Spontaneity": 0, "Mannerism": 0, "Rage": 0},
            "Behavioral": {"Curiosity": 0, "Dependency": 0, "Confidence": 0, "Ambition": 0},
            "Intellectual": {"Creativity": 0, "Concentration": 0, "Intelligence": 0},
        }
        self.occupation = "Queen"
        self.inventory = {
            "gold": 10130,
            "silver": 9876120,
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
        self.identification["birthdate"] = datetime.datetime.now()
        # Calculate the age based on the current date
        self.identification["age"] = self.calculateAge(self.identification["birthdate"])

        self.reputation = {"fame": 99, "notoriety": -99}

        self.relationships = {
            "allies": ["Barkeep", "Opus"],
            "enemies": [],
            "loyalty": 50,
            "fear": 1,
            "respect": 99,
            "morality": 0.71,  # 1 = "Pure Good", 0 = "Pure Evil"
        }

    # Function to calculate the character's age based on the provided birthdate
    def calculateAge(self, birthdate):
        now = datetime.datetime.now()
        age = now.year - birthdate.year - ((now.month, now.day) < (birthdate.month, birthdate.day))
        return age

# Function to create a new character instance with user input
def createCharacter():
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
myCharacter = createCharacter()
print(myCharacter.__dict__)

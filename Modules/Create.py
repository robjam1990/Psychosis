import datetime

class Character:
    def __init__(self, name="", gender="", pigment=None, odor="bit sequence", occupation="Adventurer"):
        self.identification = {
            "name": name,
            "gender": gender,
            "age": 0,
            "size": 3,
            "pigment": pigment or {"red": 255, "green": 0, "blue": 0},
            "odor": odor
        }
        self.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 1,
            "Speed/Agility": 1,
            "Perception/Recognition": 1,
            "Intelligence/Logistics": 1,
            "Knowledge/Memory": 1,
            "Experience/Wisdom": 1,
            "Will/Determination": 1,
            "Patience/Poise": 1,
            "Flexibility/Elasticity": 1,
            "Balance/Dexterity": 1
        }
        self.skillTree = {"Observation": 1}
        self.traits = {
            "physical": {"strength": 0, "speed": 0, "aggression": 0, "health": 0, "appeal": 0},
            "social": {"humility": 0, "temperament": 0, "generosity": 0, "loyalty": 0, "honesty": 0},
            "Emotional": {"Spontaneity": 0, "Mannerism": 0, "Rage": 0},
            "Behavioral": {"Curiosity": 0, "Dependency": 0, "Confidence": 0, "Ambition": 0},
            "Intellectual": {"Creativity": 0, "Concentration": 0, "Intelligence": 0}
        }
        self.occupation = occupation
        self.inventory = {
            "gold": 0,
            "silver": 0,
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
        # Set the birthdate as the current date
        self.identification["birthdate"] = datetime.datetime.now()
        # Calculate the age based on the current date
        self.identification["age"] = self.calculate_age(self.identification["birthdate"])

        self.reputation = {"fame": 0, "notoriety": 0}
        self.relationships = {"allies": [], "enemies": [], "loyalty": 50, "fear": 50, "respect": 50, "morality": 0.51}

    # Function to calculate the character's age based on the provided birthdate
    def calculate_age(self, birthdate):
        now = datetime.datetime.now()
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

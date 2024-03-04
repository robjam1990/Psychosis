import datetime

# Define the character Aslo
Name = "Aslo"
Characteristics = "{(o) - [+i]}"
Occupation = "Bard"
Salary = "(1 Silver) * Hour"
Location = "Taverne: Main Hall (Between the counter and the Back Room)"
Employer = "Barkeep"
EmployerBenefits = True
Benefits = ["Food", "Private Access for resting"]
Bed = "Nexus: Mercenary Camp (Bedroll)"

class Character:
    def __init__(self, name, gender, pigment=None, odor=None, occupation=""):
        self.identification = {
            "name": name,
            "gender": "Male",
            "age": 0,
            "size": [1, 1, 3],
            "pigment": pigment or {"red": 255, "green": 0, "blue": 0},
            "odor": odor or "bit sequence"
        }
        self.attributes = {
            "Strength/Power": 1,
            "Endurance/Stamina": 5,
            "Speed/Agility": 3,
            "Perception/Recognition": 7,
            "Intelligence/Logistics": 2,
            "Knowledge/Memory": 6,
            "Experience/Wisdom": 2,
            "Will/Determination": 4,
            "Patience/Poise": 9,
            "Flexibility/Elasticity": 1,
            "Balance/Dexterity": 3
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
            "gold": 1,
            "silver": 430,
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
        self.identification["age"] = self.calculateAge(self.identification["birthdate"])

        self.reputation = {"fame": 13, "notoriety": 0}
        self.relationships = {"allies": ["Barkeep", "Maia"], "enemies": [], "loyalty": 74, "fear": 34, "respect": 87, "morality": 0.61}  # 1 = "Pure Good", 0 = "Pure Evil"

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

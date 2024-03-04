from datetime import datetime

class Character:
    def __init__(self, name, gender):
        self.name = name
        self.gender = gender
        self.birthdate = datetime.now()  # Set the character's birthdate to the current date when created
        self.size = 1 * 3 * 1  # Example size value, indicating some physical dimensions
        self.pigment = {"red": 0, "green": 255, "blue": 255}  # Example RGB value for green pigment
        self.odor = "111111"  # Example bit sequence representing odor, maybe indicating a particular scent profile
        self.skill_tree = {"Observation": 1, "Identification": 1, "Social": 1, "Personal": 1}
        self.traits = {
            "physical": {"strength": 0, "speed": 0, "aggression": 0, "health": 0, "appeal": 0},
            "social": {"humility": 0, "temperament": 0, "generosity": 0, "loyalty": 0, "honesty": 0},
            "Emotional": {"Spontaneity": 0, "Mannerism": 0, "Rage": 0},
            "Behavioral": {"Curiosity": 0, "Dependency": 0, "Confidence": 1, "Ambition": 0},
            "Intellectual": {"Creativity": 1, "Concentration": 0, "Intelligence": 1}
        }
        self.occupation = "Mercenary"
        self.experience = 0
        self.level = 1
        self.attributes = {
            "Strength/Power": 11, "Endurance/Stamina": 17, "Speed/Agility": 12,
            "Perception/Recognition": 8, "Intelligence/Logistics": 8, "Knowledge/Memory": 8,
            "Experience/Wisdom": 8, "Will/Determination": 21, "Patience/Poise": 21,
            "Flexibility/Elasticity": 11, "Balance/Dexterity": 13
        }
        self.knowledge = {"lunge": "Novice", "observation": "Intermediate", "Shield_Bash": "Advanced"}
        self.inventory = {
            "gold": 200, "silver": 500,
            "equipped": {
                "Head": "", "Shoulders": "Custom Linen Cape(5lbs){Durability: 100%}",
                "Chest": "Custom Steel Plated Leather Vest (5lbs){Durability: 100%}",
                "Arms": "Custom Steel Plated Leather Bracers(4lbs){Durability: 100%}",
                "Waist": "Custom Steel Plated Leather Girdle (3lbs){Durability: 100%}",
                "Legs": "Custom Steel Plated Leather Grieves (4lbs){Durability: 100%}",
                "Feet": "Custom Steel Plated Rubber Boots (2lbs){Durability: 100%}",
                "Right Hand": "Custom Diamond Tipped Steel Scimitar (7lbs){Durability: 100%}",
                "Left Hand": "Custom Steel Plated Aluminum Shield (22lbs){Durability: 100%}"
            },
            "bag": {"Item(Weight)": ""}
        }
        self.reputation = {"fame": 50, "notoriety": 20}
        self.relationships = {
            "allies": ["Sir Marcus", "Lady Eleanor", "Hammerhead Mercenaries", "Barkeep"],
            "enemies": ["Bandit Leader"],
            "loyalty": 99, "fear": 1, "respect": 86, "morality": 0.98642174532  # 1 = "Pure Good", 0 = "Pure Evil"
        }
        self.quests = {"Aithaluwa": "Protect Aithaluwa", "Ajax": "Protect the Barkeep", "Barkeep": "Protect Ye Olde Taverne"}
        self.health = {"currentHealth": 100, "maxHealth": 100, "conditions": ["Healthy"]}
        self.appearance = {"facialMapping": "Strong jawline, sharp features", "voiceSynthesis": "Deep and commanding"}
        self.genetics = {"mutations": ["Enhanced strength", "Improved metabolism"]}


# In the main file or wherever Ark is defined
Ark = Character("Ark", "Male")

# In the code where you create a new Mercenary instance
class Mercenary:
    def __init__(self, character):
        self.character = character

    def visit_tavern(self):
        pass  # Your implementation here

mercenary = Mercenary(Ark)
mercenary.visit_tavern()

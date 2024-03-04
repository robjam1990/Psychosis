from datetime import datetime

class Character:
    def __init__(self):
        self.name = "Robert"
        self.information = {
            "gender": "Male",
            "birthdate": datetime.now(), # Set the character's birthdate to the current date when created

            # Function to calculate the character's age based on the current date
            "getAge": lambda self: self.calculate_age(),
            "size": 1 * 3 * 1, # Example size value
            "pigment": {
                "red": 0,
                "green": 255,
                "blue": 0
            }, # Example RGB value for red pigment
            "odor": "100001" # Example bit sequence representing odor
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
        self.skill_tree = {
            "Observation": 1
        }
        self.traits = {
            "physical": {
                "strength": 0,
                "speed": 0,
                "aggression": 0,
                "health": 0,
                "appeal": 0
            },
            "social": {
                "humility": 0,
                "temperament": 0,
                "generosity": 0,
                "loyalty": 0,
                "honesty": 0
            },
            "Emotional": {
                "Spontaneity": 0,
                "Mannerism": 0,
                "Rage": 0
            },
            "Behavioral": {
                "Curiosity": 0,
                "Dependency": 0,
                "Confidence": 0,
                "Ambition": 0
            },
            "Intellectual": {
                "Creativity": 0,
                "Concentration": 0,
                "Intelligence": 0
            }
        }
        self.occupation = "Adventurer"
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
            "bag": {
                "Item(Weight)": ""
            }
        }
        self.quests = {
            "Maia": "Speak with the Barkeep."
        }
        self.reputation = {
            "fame": 100,
            "notoriety": 0
        }

        self.relationships = {
            "allies": ["Alek"],
            "enemies": [],
            "loyalty": 85,
            "fear": 35,
            "respect": 95,
            "morality": 0.63, # 1 = "Pure Good", 0 = "Pure Evil"
            "Friends": ["Alek"],
            "Acquaintances": [],
            "Rivals": []
        }

    def calculate_age(self):
        now = datetime.now()
        birth_year = self.information["birthdate"].year
        current_year = now.year
        age = current_year - birth_year

        # Adjust age if the character's birthday hasn't occurred yet this year
        birth_month = self.information["birthdate"].month
        current_month = now.month
        birth_day = self.information["birthdate"].day
        current_day = now.day

        if current_month < birth_month or (current_month == birth_month and current_day < birth_day):
            age -= 1

        return age

def display_character_sheet(character):
    if not isinstance(character, Character):
        print("Invalid character data.")
        return

    print("Character Name:", character.name)

    # Display attributes
    print("\nAttributes:")
    for attribute, value in character.attributes.items():
        print(f"- {attribute}: {value}")

    # Display inventory
    print("\nInventory:")
    for item, description in character.inventory.items():
        print(f"- {item}: {description}")

    # Display quests
    print("\nQuests:")
    for quest, status in character.quests.items():
        print(f"- {quest}: {status}")

    # Display relations
    print("\nRelations:")
    for relation, people in character.relationships.items():
        print(f"{relation}:")
        if people:
            for person in people:
                print(f"- {person}")
        else:
            print("- None")

# Creating and displaying Robert's character sheet
robert = Character()
display_character_sheet(robert)

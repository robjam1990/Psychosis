from datetime import datetime

class Character:
    def __init__(self):
        self.name = "Alek"
        self.information = {
            "gender": "Male",
            "birthdate": datetime.now(),  # Set the character's birthdate to the current date when created
            # Function to calculate the character's age based on the current date
            "getAge": lambda self: (datetime.now() - self.birthdate).days // 365,
            "size": 1 * 4 * 1,  # Example size value
            "pigment": {
                "red": 255,
                "green": 0,
                "blue": 0
            },  # Example RGB value for red pigment
            "odor": "101101"  # Example bit sequence representing odor
        }
        self.attributes = {
            "Strength/Power": 3,
            "Endurance/Stamina": 3,
            "Speed/Agility": 1,
            "Perception/Recognition": 2,
            "Intelligence/Logistics": 1,
            "Knowledge/Memory": 2,
            "Experience/Wisdom": 1,
            "Will/Determination": 1,
            "Patience/Poise": 1,
            "Flexibility/Elasticity": 1,
            "Balance/Dexterity": 2
        }
        self.skillTree = {
            "Observation": 1,
            "Identification": 1
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
        self.occupation = "Adventurer", "Miner"
        self.inventory = {
            "gold": 0,
            "silver": 0,
            "equipped": {
                "Head": "",
                "Shoulders": "Goat Hide Pauldrons (4lbs)",
                "Chest": "Rugged Linen Shirt (.5lbs)",
                "Arms": "",
                "Waist": "Rugged Cotton Belt (.5lbs)",
                "Legs": "Rugged Linen Pants (.5lbs)",
                "Feet": "Rugged Rubber Boots (.5lbs)",
                "Right Hand": "Heavy Pickaxe (5lbs)",
                "Left Hand": "Knife (.5lbs)",
            },
            "bag": {
                "Item(Weight)": "Potatoes (2.5lbs), Iron plated Iron Chestpiece (9lbs), Raw Iron (1lbs), Damaged Iron (2.5lbs), Damaged Stick (.5lbs), Bedroll (2lbs), Raw Goat Meat (15lbs), Blings Things (2lbs),"
            }
        }
        self.quests = {
            "Aithaluwa": "Make a chestpiece of any type",
            "Blacksmith Assisstant": "Mine Iron",
            "Brans Wife": "Speak with Bran (Completed)",
            "Bran": "Help in the field (Completed)",
            "Ark": "Speak with Ajax (Completed)",
            "Ajax": "Bring 5 Iron weapons of Good quality or higher",
            "Blacksmith Apprentice": "Discover Steel Mine",
            "Blacksmith": "Mine Titanium or Aluminum",
            "Bling": "Deliver Blings Things to the Good Son"
        }
        self.reputation = {
            "fame": 0,
            "notoriety": 0
        }

        self.relationships = {
            "allies": ["Robert"],
            "enemies": [],
            "loyalty": 85,
            "fear": 35,
            "respect": 95,
            "morality": 0.63,  # 1 = "Pure Good", 0 = "Pure Evil"
            "Friends": ["Robert",],
            "Acquaintances": ["Weaver", "Bran", "Miner"],
            "Rivals": [],
        }

def displayCharacterSheet(character):
    if not isinstance(character, Character):
        print("Invalid character data.")
        return

    print("Character Name:", character.name)

    # Display information section
    print("\nInformation:")
    print("- Gender:", character.information["gender"])
    print("- Age:", character.information["getAge"]())
    print("- Size:", character.information["size"])
    print("- Pigment: R:{}, G:{}, B:{}".format(character.information["pigment"]["red"],
                                                character.information["pigment"]["green"],
                                                character.information["pigment"]["blue"]))
    print("- Odor:", character.information["odor"])

    # Display attributes
    print("\nAttributes:")
    for attribute, value in character.attributes.items():
        print(f"- {attribute}: {value}")

    # Display skill tree
    print("\nSkill Tree:")
    for skill, level in character.skillTree.items():
        print(f"- {skill}: Level {level}")

    # Display occupation
    print("\nOccupation:")
    print("- {}".format(character.occupation))

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

# Creating and displaying Alek's character sheet
alek = Character()
displayCharacterSheet(alek)

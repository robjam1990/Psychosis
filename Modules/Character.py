import json
import os

# Define the characters data
characters_data = []


class Character:
    def __init__(self, name, occupation, residence):
        self.name = name
        self.occupation = occupation
        self.residence = residence
        self.health = 100
        self.limbs = {
            "head": True,
            "arms": {"left": True, "right": True},
            "legs": {"left": True, "right": True},
        }
        self.skills = {
            "combat": randint(1, 10),
            "crafting": randint(1, 10),
            "diplomacy": randint(1, 10),
        }
        self.morality = random()
        self.location = "Taverne(Main Hall)"
        self.inventory = {}
        self.faction = None

    def serialize(self):
        return json.dumps(self.__dict__)

    def deserialize(self, data):
        parsed_data = json.loads(data)
        self.__dict__.update(parsed_data)


# Function to initialize characters
def initialize_characters():
    characters_data.extend(
        [
            Character("OPUS", "Oracle", "Nexus Temple"),
            Character("OPUS", "Oracle", "Nexus Temple"),
            Character("APUS", "Queen of Bractalia", "Bractal Castle"),
            Character("MAIA", "Greeter", "Ye Olde Taverne"),
            Character("Ark", "Mercenary", "Ye Olde Taverne"),
            Character("Bling", "Shopkeeper", "Weavery"),
            Character("Bran", "Farmer", "Brans Farmhouse"),
            Character("Mazuk", "King of Thipse", "Thipse"),
            Character("Fragru", "Mercenary", "Mercenary Camp"),
            Character("Garmanar", "Mercenary", "Mercenary Camp"),
            Character("Ajax", "Mercenary Leader", "Mercenary Camp"),
            Character("Rick", "Researcher", "Unknown"),
            Character("Morty", "Student", "Tree of Life"),
            Character("Tesla", "Researcher", "Wardenclyffe"),
            Character("Murdoch", "Detective", "Ruins"),
            Character("Duncan", "Guard Captain", "Nexus Longhouse"),
            Character("Hannibal", "General", "Varthek"),
            Character("Alexander the Awesome", "King of Kinderyarn", "Flaxchop"),
            Character("Archimedes", "Engineer", "Bractal"),
            Character("Guan Yu", "Commander", "Wolk"),
            Character("Cicero", "Jester", "Bractal Castle"),
            Character("Beatrix", "Guard Captain", "Bractal Castle"),
            Character("Conway Twitty", "Bard", "Peachstraw"),
            Character("Ash Ketchum", "Beast Master", "Unknown"),
            Character("Mario", "Plumber", "Unknown"),
            Character("Orngamorn", "Mercenary", "Mercenary Camp"),
            Character("Aithaluwa", "Adventurer", "Ye Olde Taverne"),
            Character("Geralt", "Adventurer", "Camp"),
            Character("Jaskier", "Bard", "Camp"),
            Character("Marie Curie", "Researcher", "Thipse"),
            Character("Isaac Newton", "Teacher", "Thipse"),
            Character("Christopher Columbus", "Explorer", "Lochtou"),
            Character("Arthur Pendragon", "King of Louchtou", "Lochtou"),
            Character("Joan D'Arc", "Soldier", "Nymenada"),
            Character("Leonardo Da Vinci", "Inventor", "Jight"),
            Character("Charles Darwin", "Observer", "Bractalia"),
            Character("Alan Turing", "Genius", "Unknown"),
            Character("Weaver", "Weaver", "Oasis"),
            Character("Farmer", "Farmer", "Oasis"),
            Character("Elder", "Teacher", "Oasis"),
            Character("Bandit", "Thief", "Bandit Camp"),
            Character("Bandit Recruit", "Thief", "Bandit Camp"),
            Character("Bandit Highwayman", "Thief", "Bandit Camp"),
            Character("Bandit Leader", "Thief", "Bandit Camp"),
            Character("Weaver", "Weaver", "Tree of Life"),
            Character("Beastmaster", "Beastmaster", "Tree of Life"),
            Character("Healer", "Healer", "Tree of Life"),
            Character("Chemist", "Chemist", "Tree of Life"),
            Character("Vagrant", "Vagrant", "Ruins"),
            Character("Scavenger", "Scavenger", "Ruins"),
            Character("Elder", "Teacher", "Ruins"),
            Character("Good Son", "Hunter", "Ruins"),
            Character("Barkeep", "Barkeep", "Ye Olde Taverne"),
            Character("Aslo", "Bard", "Ye Olde Taverne"),
            Character("Barmaid", "Barmaid", "Ye Olde Taverne"),
            Character("Servant", "Servant", "Ye Olde Taverne"),
            Character("Guard", "Guard", "Ye Olde Taverne"),
            Character("Brans Wife", "Farmer", "Brans Farmhouse"),
            Character("Stablemaster", "Esquire", "Stables"),
            Character("Assistant", "Assistant", "Stables"),
            Character("Blacksmith", "Blacksmith", "Blacksmith"),
            Character("Assistant", "Assistant", "Blacksmith"),
            Character("Apprentice", "Apprentice", "Blacksmith"),
            Character("Guard", "Guard", "Blacksmith"),
            Character("Husband", "Mercenary", "Mercenary Camp"),
            Character("Wife", "Mercenary", "Mercenary Camp"),
            Character("Mercenary", "Mercenary", "Mercenary Camp"),
            Character("Vagrant Mercenary", "Mercenary", "Mercenary Camp"),
            Character("Commander", "Commander", "Nexus Longhouse"),
            Character("Captain", "Captain", "Nexus Longhouse"),
            Character("Archer", "Guard", "Nexus Longhouse"),
            Character("Guard", "Guard", "Nexus Longhouse"),
            Character("Healer", "Healer", "Temple"),
            Character("Priest", "Priest", "Temple"),
            Character("Weaver", "Weaver", "Nexus Weavery"),
            Character("Potter", "Potter", "Nexus Pottery"),
            Character("Thomas", "Archer", "Vagrant"),
            Character("Homer", "Poet", "Unknown"),
        ]
    )


# Function to export all characters to separate JSON files
def export_characters_to_file():
    for index, character in enumerate(characters_data):
        file_name = f"character_{index + 1}.json"  # Generate a unique file name for each character
        export_character(character, file_name)


def export_character(character, file_name):
    try:
        save_path = os.path.join("Psychosis", "Data", file_name)  # Construct the save path
        serialized_data = character.serialize()
        with open(save_path, "w") as file:
            file.write(serialized_data)
        print(f"{character.name} has been exported to {save_path}.")
    except Exception as e:
        print(f"Failed to export {character.name}: {e}")


# Function to import a character from a JSON file
def import_character(file_name):
    try:
        file_path = os.path.join("Psychosis", "Data", file_name)  # Construct the file path
        with open(file_path, "r") as file:
            data = file.read()
        character = Character("", "", "")  # Initialize an empty character
        character.deserialize(data)
        print(f"{character.name} has been imported from {file_path}.")
        return character
    except Exception as e:
        print(f"Failed to import character from {file_name}: {e}")
        return None


def main():
    initialize_characters()
    export_characters_to_file()


if __name__ == "__main__":
    main()

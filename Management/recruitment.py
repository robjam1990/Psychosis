# File: Psychosis/Gameplay/Management/recruitment.py

class Character:
    def __init__(self, name, role, attributes, price, requirements):
        self.name = name
        self.role = role
        self.attributes = attributes
        self.price = price
        self.requirements = requirements
        self.recruited = False

    def recruit(self, player):
        # Check if the character has already been recruited
        if self.recruited:
            print(f"{self.name} has already been recruited.")
            return

        # Check if player meets recruitment requirements
        if not self.check_requirements(player):
            print(f"{self.name} cannot be recruited at this time.")
            return

        # Check if player has enough gold
        if player.gold < self.price:
            print(f"Insufficient gold to recruit {self.name}.")
            return

        # Deduct gold from player's inventory
        player.gold -= self.price

        # Add character to player's party
        player.party.append(self)

        # Mark character as recruited
        self.recruited = True

        print(f"{self.name} has been recruited to your party.")

    def check_requirements(self, player):
        # Check if player meets all requirements for recruitment
        for requirement in self.requirements:
            if not requirement.check(player):
                return False
        return True


class AttributeRequirement:
    def __init__(self, attribute, value):
        self.attribute = attribute
        self.value = value

    def check(self, player):
        # Check if player's attribute meets requirement
        return player.attributes.get(self.attribute, 0) >= self.value


class Player:
    def __init__(self, gold, attributes):
        self.gold = gold
        self.attributes = attributes
        self.party = []


# Define different types of characters
knight = Character("Sir Galahad", "Knight", {"strength": 10, "agility": 5, "intelligence": 3}, 100, [])
chemist = Character("Merlin", "chemist", {"strength": 3, "agility": 5, "intelligence": 10}, 150, [])
rogue = Character("Lilith", "Rogue", {"strength": 5, "agility": 10, "intelligence": 3}, 120, [])

# Define requirements for recruiting characters
high_strength_req = AttributeRequirement("strength", 8)
high_agility_req = AttributeRequirement("agility", 8)
high_intelligence_req = AttributeRequirement("intelligence", 8)

# Set requirements for recruiting characters
knight.requirements.append(high_strength_req)
chemist.requirements.append(high_intelligence_req)
rogue.requirements.append(high_agility_req)

# Usage example
player = Player(200, {"strength": 6, "agility": 7, "intelligence": 6})
knight.recruit(player)  # Insufficient strength to recruit Sir Galahad.
chemist.recruit(player)  # Merlin has been recruited to your party.
rogue.recruit(player)  # Lilith has been recruited to your party.

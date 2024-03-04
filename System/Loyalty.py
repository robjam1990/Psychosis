# File = robjam1990/Psychosis/Gameplay/System/Loyalty.py
# Loyalty.py

class LoyaltySystem:
    def __init__(self):
        self.characters = {}  # Dictionary to store characters and their loyalty attributes

    def add_character(self, character_name, loyalty_level):
        """
        Add a character to the loyalty system.
        :param character_name: The name of the character.
        :param loyalty_level: The initial loyalty level of the character.
        """
        if character_name not in self.characters:
            self.characters[character_name] = {
                'loyalty_level': loyalty_level
            }
        else:
            print(f"{character_name} already exists in the loyalty system.")

    def increase_loyalty(self, character_name, amount):
        """
        Increase the loyalty level of a character.
        :param character_name: The name of the character.
        :param amount: The amount by which to increase the loyalty level.
        """
        if character_name in self.characters:
            self.characters[character_name]['loyalty_level'] += amount
        else:
            print(f"{character_name} does not exist in the loyalty system.")

    def decrease_loyalty(self, character_name, amount):
        """
        Decrease the loyalty level of a character.
        :param character_name: The name of the character.
        :param amount: The amount by which to decrease the loyalty level.
        """
        if character_name in self.characters:
            self.characters[character_name]['loyalty_level'] -= amount
        else:
            print(f"{character_name} does not exist in the loyalty system.")

    def get_loyalty(self, character_name):
        """
        Get the loyalty level of a character.
        :param character_name: The name of the character.
        :return: The loyalty level of the character.
        """
        if character_name in self.characters:
            return self.characters[character_name]['loyalty_level']
        else:
            print(f"{character_name} does not exist in the loyalty system.")
            return None

    def modify_loyalty(self, character_name, modifier):
        """
        Modify the loyalty level of a character based on an event.
        :param character_name: The name of the character.
        :param modifier: The modifier to apply to the loyalty level.
        """
        if character_name in self.characters:
            self.characters[character_name]['loyalty_level'] += modifier
        else:
            print(f"{character_name} does not exist in the loyalty system.")

    def handle_event(self, character_name, event):
        """
        Handle an event that affects character loyalty.
        :param character_name: The name of the character.
        :param event: The event that affects loyalty.
        """
        if event == 'completed_quest':
            self.modify_loyalty(character_name, 10)  # Increase loyalty after completing a quest
        elif event == 'betrayal':
            self.modify_loyalty(character_name, -20)  # Decrease loyalty due to betrayal
        else:
            print(f"Unhandled event: {event}")

# file = robjam1990/psychosis/gameplay/system/jurisdiction.py
class Jurisdiction:
    def __init__(self, country, town, loyalty=50, fear=50, respect=50, morality=50):
        self.country = country
        self.town = town
        self.loyalty = loyalty
        self.fear = fear
        self.respect = respect
        self.morality = morality

    def modify_loyalty(self, amount):
        self.loyalty = max(min(self.loyalty + amount, 100), 0)

    def modify_fear(self, amount):
        self.fear = max(min(self.fear + amount, 100), 0)

    def modify_respect(self, amount):
        self.respect = max(min(self.respect + amount, 100), 0)

    def modify_morality(self, amount):
        self.morality = max(min(self.morality + amount, 100), 0)

class Player:
    def __init__(self, name):
        self.name = name
        self.jurisdiction = None

    def set_jurisdiction(self, country, town, loyalty=50, fear=50, respect=50, morality=50):
        if not isinstance(country, str) or not isinstance(town, str):
            raise TypeError("Country and town names must be strings.")

        self.jurisdiction = Jurisdiction(country, town, loyalty, fear, respect, morality)

    def modify_jurisdiction_traits(self, loyalty=0, fear=0, respect=0, morality=0):
        if self.jurisdiction is None:
            raise ValueError("Player's jurisdiction is not set.")

        self.jurisdiction.modify_loyalty(loyalty)
        self.jurisdiction.modify_fear(fear)
        self.jurisdiction.modify_respect(respect)
        self.jurisdiction.modify_morality(morality)

def main():
    # Creating a player
    player_name = input("Enter your character's name: ")
    player = Player(player_name)

    # Setting jurisdiction for the player
    while True:
        try:
            country_input = input("Enter the country of your character: ")
            town_input = input("Enter the town of your character: ")
            player.set_jurisdiction(country_input, town_input)
            break
        except TypeError as e:
            print(e)
            print("Please enter valid country and town names.")

    # Modifying jurisdiction traits
    player.modify_jurisdiction_traits(loyalty=10, fear=-20, respect=5, morality=-10)

    # Displaying player's jurisdiction
    print(f"{player.name}'s jurisdiction: {player.jurisdiction.country}, {player.jurisdiction.town}")
    print(f"Loyalty: {player.jurisdiction.loyalty}")
    print(f"Fear: {player.jurisdiction.fear}")
    print(f"Respect: {player.jurisdiction.respect}")
    print(f"Morality: {player.jurisdiction.morality}")

if __name__ == "__main__":
    main()

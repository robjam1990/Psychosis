# File = robjam1990/Psychosis/Gameplay/Systems/Justice.py

class JusticeSystem:
    def __init__(self):
        self.laws = {
            'conjective': ["Slander"],
            'injective': ["assault", "vandalism"],
            'rejective': ["resisting arrest", "tax evasion"],
            'subjective': ["trespassing", "theft", "desertion"],
            'objective': ["murder", "assassination", "terrorism"]
        }
        self.crime_tracker = {}  # Dictionary to track crimes committed by players and NPCs

    def handle_crime(self, crime, perpetrator, player_influence, conscious=True):
        # Validate input parameters
        if not all(isinstance(param, str) for param in (crime, perpetrator)) or not isinstance(player_influence, bool):
            raise ValueError('Invalid input parameters. Crime, perpetrator, and player_influence must be provided and have correct data types.')

        notoriety = 0
        if crime in self.laws['injective']:
            notoriety += 2
        elif crime in self.laws['rejective']:
            notoriety += 1
        elif crime in self.laws['subjective']:
            notoriety += 2
        elif crime in self.laws['objective']:
            notoriety += 5

        # Track the crime
        if perpetrator not in self.crime_tracker:
            self.crime_tracker[perpetrator] = []
        self.crime_tracker[perpetrator].append(crime)

        if notoriety == 1:
            # Implement player influence on punishment
            if perpetrator == "player" and player_influence:
                notoriety -= 1  # Reduced punishment for player's influence
            punishment = "Jail for 1 Day or Fine of 100 silver coins"  # Return alternative punishment if applicable
        else:
            if notoriety >= 3:
                arrest = "Incapacitation"
            else:
                if not conscious:
                    punishment = f"Jail for {notoriety} Day(s) or Fine of {notoriety * 100} silver coins"
                else:
                    punishment = "No specific action required."

            # Implement alternative justice systems
            if crime == "murder":
                punishment = "Trial by Combat"
            elif crime == "assassination":
                punishment = "Death"
            elif crime == "theft":
                punishment = "Dismember"
            elif crime == "trespassing":
                punishment = "Trial by judge"
            else:
                punishment = "Standard punishment applied."

        return punishment


class JurisdictionSystem:
    types = ["locational", "factional"]


# Feedback Mechanisms
def provide_feedback(player, crime, punishment):
    # Simulate reputation changes, public opinion, etc.
    print(f"{player} committed {crime} and received punishment: {punishment}")
    # Implement long-term consequences
    if punishment == "Jail for 1 Day or Fine of 100 silver coins":
        print(f"{player} is now a fugitive.")


# Example usage:
crime = "theft"
perpetrator = "player"
player_influence = True  # Player attempts to influence the punishment
justice_system = JusticeSystem()
punishment = justice_system.handle_crime(crime, perpetrator, player_influence)
provide_feedback(perpetrator, crime, punishment)

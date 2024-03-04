# File = robjam1990/Psychosis/Gameplay/System/Morality.py

# Define Morality class
class Morality:
    def __init__(self):
        self.jurisdiction = "local"  # Default jurisdiction for morality spectrum
        self.actions = {}  # Dictionary to store actions and their morality consequences

    # Set the jurisdiction for morality spectrum
    def set_jurisdiction(self, jurisdiction):
        self.jurisdiction = jurisdiction

    # Add an action with its morality consequences
    def add_action(self, action, morality_consequence):
        self.actions[action] = morality_consequence

    # Get morality consequence for a specific action
    def get_morality_consequence(self, action):
        return self.actions.get(action)

    # Calculate morality based on actions performed
    def calculate_morality(self, actions_performed):
        morality = 0

        for action in actions_performed:
            if action in self.actions:
                morality += self.actions[action]

        # Apply consequence multiplier if morality is below 50
        if morality < 50:
            morality *= 1.5

        return morality

    # Update morality jurisdiction
    def update_jurisdiction(self, new_jurisdiction):
        self.jurisdiction = new_jurisdiction


# Example usage:
# Instantiate Morality object
morality_system = Morality()

# Set jurisdiction
morality_system.set_jurisdiction("local")

# Add actions and their morality consequences
morality_system.add_action("helping villagers", 0.01)  # Positive morality consequence
morality_system.add_action("stealing from others", -0.02)  # Negative morality consequence

# Get morality consequence for a specific action
print(morality_system.get_morality_consequence("stealing from others"))  # Output: -0.02

# Calculate morality based on actions performed
actions_performed = ["helping villagers", "stealing from others"]
print(morality_system.calculate_morality(actions_performed))  # Output: -0.015

# Update morality jurisdiction
morality_system.update_jurisdiction("global")
print(morality_system.jurisdiction)  # Output: global

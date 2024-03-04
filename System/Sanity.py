# File: robjam1990/Psychosis/Gameplay/System/Sanity.py

# This file implements the advanced sanity system for the game.

class SanitySystem:
    def __init__(self, character):
        self.character = character
        self.baseSanity = 100  # Base sanity value
        self.currentSanity = self.baseSanity  # Current sanity value
        self.maxSanity = 200  # Maximum sanity value
        self.sanityDecayRate = 0.1  # Rate at which sanity decreases over time
        self.sanityEvents = []  # Array to store sanity-related events

    # Function to update sanity based on time passage
    def updateSanity(self):
        # Decrease sanity over time
        self.currentSanity -= self.sanityDecayRate

        # Ensure sanity stays within bounds
        self.currentSanity = max(0, min(self.currentSanity, self.maxSanity))

        # Check for sanity-related events or triggers
        self.checkSanityEvents()

    # Function to check for sanity-related events
    def checkSanityEvents(self):
        # Iterate through sanity events
        for event in self.sanityEvents:
            # Check if event conditions are met
            if event['condition']():
                # Trigger event action
                event['action']()

    # Function to restore sanity
    def restoreSanity(self, amount):
        self.currentSanity += amount

        # Ensure sanity stays within bounds
        self.currentSanity = min(self.currentSanity, self.maxSanity)

    # Function to inflict sanity loss
    def inflictSanityLoss(self, amount):
        self.currentSanity -= amount

        # Ensure sanity stays within bounds
        self.currentSanity = max(0, self.currentSanity)

    # Function to add a sanity event
    def addSanityEvent(self, condition, action):
        self.sanityEvents.append({'condition': condition, 'action': action})

    # Additional Features

    # Function to handle sanity event triggers
    def handleSanityEvents(self):
        for event in self.sanityEvents:
            if event['condition']():
                event['action']()

    # Function to scale sanity effects with game progression and difficulty
    def scaleSanityEffects(self, difficultyMultiplier):
        self.sanityDecayRate *= difficultyMultiplier
        # You can add more scaling effects here if needed

    # Function to add a new sanity event
    def addSanityEvent(self, condition, action):
        self.sanityEvents.append({'condition': condition, 'action': action})

    # Function to reset sanity to its default state
    def resetSanity(self):
        self.currentSanity = self.baseSanity

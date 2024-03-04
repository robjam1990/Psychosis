# File: NPC.py

class NPC:
    def __init__(self, name, thear):
        self.name = name
        self.behavior = "Idle"
        self.isHungry = False
        self.isThirsty = False
        self.isTired = False
        self.properties = []  # Initialize properties array
        self.thear = thear  # Inject Thear object

    def updateBehavior(self, time, weather):
        Schedule = self.thear.Bractalia.Nexus.Taverne.NPCs.Schedule
        Behaviors = self.thear.Bractalia.Nexus.Taverne.NPCs.Behaviors
        newBehavior = Behaviors.Idle  # Default behavior
        # Ensure Thear object and its nested properties exist
        if not isinstance(time, int) or time < 0 or time > 24:
            raise TypeError('Invalid value for time parameter. Time must be a number between 0 and 24.')

        # Validate weather parameter
        if not isinstance(weather, str):
            raise TypeError('Invalid value for weather parameter. Weather must be a string.')
        if not self.thear or not self.thear.Bractalia or not self.thear.Bractalia.Nexus \
                or not self.thear.Bractalia.Nexus.Taverne or not self.thear.Bractalia.Nexus.Taverne.NPCs:
            raise Error('Missing required dependencies for NPC behavior update.')
        if time >= Schedule.WakeUp and time < Schedule.WorkStart:
            newBehavior = Behaviors.Idle
        elif time >= Schedule.WorkStart and time < Schedule.LunchStart:
            newBehavior = Behaviors.PublicWork
        elif time >= Schedule.LunchStart and time < Schedule.WorkEnd:
            newBehavior = Behaviors.Socializing
        elif time >= Schedule.WorkEnd and time < Schedule.DinnerStart:
            newBehavior = Behaviors.Idle
        elif time >= Schedule.DinnerStart and time < Schedule.Bedtime:
            newBehavior = Behaviors.Socializing
        elif self.isHungry:
            newBehavior = "Eating"
        elif self.isThirsty:
            newBehavior = "Drinking"
        elif self.isTired:
            newBehavior = "Sleeping"
        else:
            newBehavior = "Waiting"

        # Weather-based behavior modification
        if weather == "Stormy":
            newBehavior = "Seeking Shelter"

        self.behavior = newBehavior  # Update behavior

    def interact(self):
        print(f"{self.name} says: Hello there!")

    def ownProperty(self, property):
        self.properties.append(property)

    def customizeProperty(self, property, customization):
        property.addCustomization(customization)
        print(f"{self.name} has customized {property.type} at {property.location}.")

class Property:
    def __init__(self, type, location):
        self.type = type
        self.location = location
        self.customizations = []

    def addCustomization(self, customization):
        self.customizations.append(customization)

# Export NPC and Property classes
__all__ = ['NPC', 'Property']

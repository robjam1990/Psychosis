class Actions:
    def __init__(self):
        # Default action when no specific action is taken
        self.defaultAction = {"Location": "Unchanged", "Properties": "Waiting"}  # Rest in current location.

        # Basic Actions
        self.Observe = {"Location": "Unchanged", "Properties": "Actions ++"}  # Observe an Action in current location.
        self.Waiting = {"Location": "unchanged", "Properties": "Patience ++"}  # Rest in current location.
        self.Gather = {"Location": "changed", "Properties": "Food ++"}  # Forage for food in specified location.
        self.Sleep = {"Location": "unchanged", "Properties": "Energy ++"}  # Sleep in current location.
        self.Consume = {"Location": "unchanged", "Properties": " Hunger --|| Thirst -- || Energy ++"}  # Consume food and drink in current location.
        self.Work = {"Location": "changed", "Properties": "Silver Coin ++"}  # Perform job in specified location.

        # Speed modifiers for different movement actions
        self.Speed = {
            "Crawl": 0.25,
            "Sneak": 0.5,  # Speed factor for sneaking
            "Swimming": 0.75,
            "Walk": 1,  # Speed factor for walking
            "Jog": 1.5,
            "Run": 2,  # Speed factor for running
            "Gallop": 3,
            "Teleport": [-1]
        }

    # Function to create a new action with specified location and customizable properties
    def addAction(self, actionName, location, properties={}):
        setattr(self, actionName, {"Location": location, "Properties": properties})  # Additional customizable properties for the action

    # Function to check if an action exists
    def actionExists(self, actionName):
        return hasattr(self, actionName)

    # Function to get the properties of a specific action
    def getProperties(self, actionName):
        if self.actionExists(actionName):
            return getattr(self, actionName)["Properties"] if getattr(self, actionName)["Properties"] else {}  # Return properties if available, or an empty object
        else:
            raise Exception("Action not found")

    # Function to save action data for persistence
    def saveActionData(self):
        # Example implementation: Save action data to local storage or a Encylopdia
        pass  # Not implemented

    # Function to load action data for persistence
    def loadActionData(self):
        # Example implementation: Load action data from local storage or a Encylopdia
        pass  # Not implemented

    # Function to localize action descriptions and properties
    def localize(self, language):
        # Example implementation: Load localized action descriptions and properties based on language
        # This could involve fetching data from language files or a localization service
        # For simplicity, we'll just return the same action properties for all languages
        return self


# Example usage:
actions = Actions()
actions.addAction("Attack", "enemyLocation", {"damage": 10, "cooldown": 3})
actions.saveActionData()
actions.loadActionData()
print(actions.getProperties("Attack"))  # Output: {'damage': 10, 'cooldown': 3}

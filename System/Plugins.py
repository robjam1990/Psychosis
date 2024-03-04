# File: Psychosis/Gameplay/System/ObservationPluginSystem.py

class Observation:
    def __init__(self):
        self.plugins = []

    def record(self, observation_name, properties, participant):
        # Record the observation
        # "Encyclopedia" is an existing object where observations are stored
        Encyclopedia[observation_name] = properties

    def add_plugin(self, plugin):
        # Add plugin to the list
        self.plugins.append(plugin)

    def trigger_plugins(self, event, data):
        # Trigger plugins
        for plugin in self.plugins:
            try:
                if hasattr(plugin, event):
                    getattr(plugin, event)(data)
            except Exception as e:
                print(f"Error executing plugin for event '{event}': {e}")

# Example event naming convention
EVENTS = {
    'CUSTOM_OBSERVATION': 'custom_observation'
}

# Example usage of plugin system
class CustomPlugin:
    def record(self, data):
        # Implement custom observation recording logic here
        print("Custom plugin: New observation recorded", data)

# Create an instance of the Observation class
observation = Observation()

# Add the custom plugin to the Observation system
custom_plugin = CustomPlugin()
observation.add_plugin(custom_plugin)

# Trigger custom observation event
event_data = {}  # Assuming eventData is defined somewhere
observation.trigger_plugins(EVENTS['CUSTOM_OBSERVATION'], event_data)

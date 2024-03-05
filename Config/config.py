import json

class GameConfig:
    def __init__(self, config_path):
        try:
            with open(config_path, 'r') as file:
                config_data = json.load(file)
                self.validate_config(config_data)
                self.__dict__.update(config_data)
        except Exception as error:
            print('Error loading configuration:', error)
            # Handle error gracefully or throw it

    def update_config(self, config_data):
        self.validate_config(config_data)
        self.__dict__.update(config_data)

    def validate_config(self, config_data):
        # Implement validation logic here
        # Ensure that config_data contains expected keys and values
        pass

# Example usage:
config = GameConfig('./Config/config.json')
print(config.windowTitle)  # Accessing a specific setting

config.update_config({
    'windowTitle': "New Window Title",
    'renderFPS': 30,
    'limbRemovalEnabled': False,
    'dayNightCycleEnabled': False
})
print(config.windowTitle)  # Accessing the updated setting

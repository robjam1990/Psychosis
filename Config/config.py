import json

class GameConfig:
    def __init__(self, config_path):
        try:
            with open(config_path, 'r') as f:
                config_data = json.load(f)
                # Validate configData here
                for key, value in config_data.items():
                    setattr(self, key, value)
        except Exception as error:
            print('Error loading configuration:', str(error))
            # Handle error gracefully or throw it

    def update_config(self, config_data):
        # Validate and update configData dynamically
        for key, value in config_data.items():
            setattr(self, key, value)

class GameConfigDefaults:
    def __init__(self):
        # Game directories
        self.home_directory = "C:/Psychosis/"
        self.resources_directory = "C:/Psychosis/Resources/"
        # Window settings
        self.window_title = "Psychosis Window"
        self.window_icon = "Thear.png"
        self.max_window_width = 800
        self.max_window_height = 600
        self.initial_window_width = 600
        self.initial_window_height = 400
        # Rendering settings
        self.render_default_background_color = [255, 255, 255]  # White color
        self.render_default_layer = 0
        self.render_fps = 60
        # Game features
        self.limb_removal_enabled = True
        self.ecosystem_simulation_enabled = True
        self.nation_building_enabled = True
        self.social_infrastructure_enabled = True
        self.bounty_system_enabled = True  # Added Bounty System
        self.hierarchy_system_enabled = True  # Added Hierarchy System
        self.individual_loyalty_enabled = True  # Added Individual Loyalty
        self.territory_border_expansion_enabled = True  # Added Territory Border Expansion
        self.day_night_cycle_enabled = True
        self.construction_system_enabled = True
        self.prisoner_system_enabled = True
        self.hiring_system_enabled = True
        self.supply_and_demand_system_enabled = True
        self.resource_system_enabled = True  # Added Resource System
        self.crafting_system_enabled = True
        self.survival_system_enabled = True
        self.character_growth_system_enabled = True
        self.learning_and_teaching_system_enabled = True
        self.observation_system_enabled = True
        self.character_customization_enabled = True
        self.genetic_manipulation_enabled = True

# Example usage:
config_path = "// robjam1990/Psychosis/Config/config.json"
config = GameConfig(config_path)
print(config.window_title)  # Accessing a specific setting

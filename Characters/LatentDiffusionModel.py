class GameConfig:
    def __init__(self, name, setting, genre, version):
        self.name = name
        self.setting = setting
        self.genre = genre
        self.version = version

class ModelConfig:
    def __init__(self, base_learning_rate, target, exploration_factor, combat_factor, num_timesteps, log_every_t):
        self.base_learning_rate = base_learning_rate
        self.target = target
        self.exploration_factor = exploration_factor
        self.combat_factor = combat_factor
        self.num_timesteps = num_timesteps
        self.log_every_t = log_every_t

class FeatureConfig:
    def __init__(self, **kwargs):
        for key, value in kwargs.items():
            setattr(self, key, value)

game_config = GameConfig(name="Psychosis", setting="Thear", genre="Adventure-RPG", version="0.6")

model_config = ModelConfig(base_learning_rate=1.0e-04, target="LatentDiffusionModel", exploration_factor=0.75,
                           combat_factor=0.25, num_timesteps=1000, log_every_t=200)

features_config = FeatureConfig(
    character_traits=dict(loyalty=0.5, fear=0.3, respect=0.7, morality=0.6),
    environment_settings=dict(time_cycle=True, season_cycle=True, territory_expansion=True, structure_management=True),
    social_system=dict(hierarchy_creation=True, bounty_system=True, loyalty_management=True,
                       community_interaction=True, faction_system=True, reputation_system=True,
                       diplomacy_system=True),
    combat_system=dict(limb_removal=True, tactical_combat=True, dynamic_combat_events=True,
                       skill_based_combat=True, damage_types=["physical", "magical", "elemental"],
                       status_effects=["poison", "paralysis", "stun"]),
    crafting_system=dict(advanced_crafting=True, metallurgy=True, alchemy=True, enchanting=True,
                         blueprint_system=True, experimentation_system=True),
    survival_system=dict(advanced_survival=True, sanity_management=True, temperature_regulation=True,
                         disease_management=True, hunger_and_thirst=True, hygiene_system=True),
    character_progression=dict(skill_learning=True, talent_trees=True, experience_system=True,
                               specialization_paths=True, mentorship_system=True, dynamic_questing=True),
    customization_system=dict(facial_mapping=True, voice_synthesis=True, body_modification=True,
                              clothing_and_armor=True, cosmetic_options=True, user_generated_content=True),
    resource_management=dict(supply_demand=True, renewable_resources=True, non_renewable_resources=True,
                             harvesting_and_extraction=True, trading_system=True, resource_scarcity=True),
    nation_building=dict(logistics_management=True, agriculture_management=True, commerce_management=True,
                         infrastructure_development=True, military_expansion=True, cultural_advancement=True),
    genetic_manipulation=True,
    ecosystem_simulation=True,
    communication_system=True,
    animal_domestication=True,
    territory_claiming=True,
    location_management=True,
    player_housing=True,
    delegation_system=True,
    prisoner_management=True,
    army_management=True
)

# Example usage:
print(game_config.name)
print(model_config.base_learning_rate)
print(features_config.character_traits)

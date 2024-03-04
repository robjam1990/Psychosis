# File: robjam1990/Psychosis/Gameplay/System/Solar.py

class StarSystem:
    def __init__(self):
        self.planets = []

    def add_planet(self, planet):
        self.planets.append(planet)

    def travel_to_planet(self, planet):
        # Logic for traveling to the specified planet within the star system
        pass

class Planet:
    def __init__(self, name, shape="round", is_default=False):
        self.name = name
        self.shape = shape
        self.locations = []
        self.star_system = None
        self.is_default = is_default  # Added a new property to indicate if the planet is the default spawn point

    def set_star_system(self, star_system):
        self.star_system = star_system

class Hazard:
    def __init__(self, name, severity):
        self.name = name
        self.severity = severity

class Location:
    def __init__(self, name):
        self.name = name
        self.objects = []
        self.hazards = []

    def add_hazard(self, hazard):
        self.hazards.append(hazard)

class Resource:
    def __init__(self, name, renewable=False, abundance="low"):
        self.name = name
        self.renewable = renewable
        self.abundance = abundance

class Recipe:
    def __init__(self, name, ingredients, product):
        self.name = name
        self.ingredients = ingredients
        self.product = product

class CraftingSystem:
    def __init__(self):
        self.recipes = []

    def add_recipe(self, recipe):
        self.recipes.append(recipe)

class SurvivalSystem:
    def __init__(self):
        self.stats = {
            "O2": 100,
            "Temperature": 98.6,
            "Disease": 0,
            "Hunger": 100,
            "Energy": 100,
            "Sanity": 100,
            "Hygiene": 100,
            "Waste": 0,
        }

    def update_stats(self):
        # Logic for updating survival stats
        pass

class Event:
    def __init__(self, description, choices, consequences):
        self.description = description
        self.choices = choices
        self.consequences = consequences

class NarrativeManager:
    def __init__(self):
        self.events = []

    def add_event(self, event):
        self.events.append(event)

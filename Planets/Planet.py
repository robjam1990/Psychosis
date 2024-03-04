import random

class MiningResources:
    def __init__(self):
        self.resources = {}

    # Method to randomly generate resources for a planet
    def generate_resources(self):
        num_resources = random.randint(5, 10)  # Generate between 5 to 10 resources per planet
        for _ in range(num_resources):
            resource = random.choice(ResourceList.all_resources)  # Choose a random resource from the master list
            quantity = random.randint(50, 200)  # Generate a random quantity for the resource
            self.resources[resource] = quantity

# Class to hold a list of all available resources
class ResourceList:
    all_resources = [
        "Lithium", "Chromium", "Tungsten", "Mercury", "Uranium", "Magnesium", "Gallium", "Iron", "Aluminum",
        "Titanium", "Steel", "Gold", "Silver", "Bronze", "Copper", "Flint", "Nickel", "Malachite", "Lead",
        "Tin", "Zinc", "Cobalt", "Coal", "Obsidian", "Clay", "Oil", "Marble", "Sand", "Stone", "Diamond",
        "Ruby", "Sapphire", "Garnet", "Emerald", "Topaz", "Amethyst", "Quartz"
    ]

class Planet:
    def __init__(self, name, radius, atmosphere_composition, temperature):
        self.name = name
        self.radius = radius
        self.atmosphere_composition = atmosphere_composition
        self.temperature = temperature
        self.mining_resources = MiningResources()
        self.landmarks = []
        self.creatures = []
        self.explored = False

        # Initialize additional attributes
        self.weather_patterns = []
        self.terrain_types = []

    def explore(self):
        print(f"You are exploring {self.name}. It has a radius of {self.radius} units.")
        print(f"The landscape is {self.get_landscape_description()}.")
        print(f"The temperature is {self.temperature} degrees Celsius.")
        print(f"The atmosphere composition is {self.atmosphere_composition}.")

        if not self.explored:
            print("You have discovered the following landmarks:")
            for landmark in self.landmarks:
                print(f"- {landmark}")

            print("You have encountered the following creatures:")
            for creature in self.creatures:
                print(f"- {creature}")

            print("You have found the following resources:")
            for resource, quantity in self.mining_resources.resources.items():
                print(f"- {resource}: {quantity}")

            # Display additional information
            print("The weather patterns on this planet include:")
            for weather_pattern in self.weather_patterns:
                print(f"- {weather_pattern}")

            print("The terrain types on this planet include:")
            for terrain_type in self.terrain_types:
                print(f"- {terrain_type}")

            self.explored = True
        else:
            print("You have already explored this planet.")

    def get_landscape_description(self):
        # Generate a random landscape description for each planet
        landscapes = ["rocky", "barren", "lush", "volcanic", "icy", "deserted", "forested"]
        return random.choice(landscapes)

class SolarSystem:
    def __init__(self):
        self.planets = [
            Planet("Mercury", 2439.7, "minimal atmosphere", 430),
            Planet("Venus", 6051.8, "carbon dioxide, nitrogen", 462),
            Planet("Earth", 6371, "nitrogen, oxygen", 15),
            Planet("Mars", 3389.5, "carbon dioxide, argon", -63),
            Planet("Jupiter", 69911, "hydrogen, helium", -145),
            Planet("Saturn", 58232, "hydrogen, helium", -178),
            Planet("Uranus", 25362, "hydrogen, helium", -216),
            Planet("Neptune", 24622, "hydrogen, helium", -214),
            Planet("Thear", 5314, "nitrogen, oxygen", 20)
        ]

        # Generate resources, landmarks, and creatures for each planet
        for planet in self.planets:
            planet.mining_resources.generate_resources()
            self.generate_landmarks(planet)
            self.generate_creatures(planet)
            self.generate_weather_patterns(planet)
            self.generate_terrain_types(planet)

    def generate_landmarks(self, planet):
        num_landmarks = random.randint(3, 5)  # Generate between 3 to 5 landmarks per planet
        for i in range(num_landmarks):
            landmark = f"Landmark{i + 1}"
            planet.landmarks.append(landmark)

    def generate_creatures(self, planet):
        num_creatures = random.randint(2, 4)  # Generate between 2 to 4 creatures per planet
        for i in range(num_creatures):
            creature = f"Creature{i + 1}"
            planet.creatures.append(creature)

    # Additional methods for generating weather patterns and terrain types
    def generate_weather_patterns(self, planet):
        # Generate random weather patterns
        weather_options = ["Sunny", "Stormy", "Windy", "Foggy", "Freezing", "Hot"]
        num_weather_patterns = random.randint(2, 4)  # Generate between 2 to 4 weather patterns per planet
        for i in range(num_weather_patterns):
            weather_pattern = random.choice(weather_options)
            planet.weather_patterns.append(weather_pattern)

    def generate_terrain_types(self, planet):
        # Generate random terrain types
        terrain_options = ["Mountains", "Plains", "Deserts", "Forests", "Oceans", "Tundra"]
        num_terrain_types = random.randint(2, 4)  # Generate between 2 to 4 terrain types per planet
        for i in range(num_terrain_types):
            terrain_type = random.choice(terrain_options)
            planet.terrain_types.append(terrain_type)

    def explore_planet(self, planet_index):
        if 0 <= planet_index < len(self.planets):
            self.planets[planet_index].explore()
        else:
            print("Invalid planet index.")

solar_system = SolarSystem()

print("Welcome to the Solar System Explorer!")

while True:
    print("Choose a planet to explore (0-8):")
    for i, planet in enumerate(solar_system.planets):
        print(f"{i}. {planet.name}")

    choice = input("Enter your choice: ")

    if choice.isdigit():
        solar_system.explore_planet(int(choice))
    else:
        print("Invalid input. Please enter a number.")

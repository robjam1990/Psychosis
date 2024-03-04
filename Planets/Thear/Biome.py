# File = robjam1990/Psychosis/Gameplay/Planets/Thear/Biome.py
import random
import json

class Biome:
    def __init__(self, name):
        self.name = name
        self.organisms = []

    def load_organisms_from_json(self, file_path):
        with open(file_path, 'r') as file:
            data = json.load(file)
        return data

    def add_organisms_from_json(self, file_path):
        organisms_data = self.load_organisms_from_json(file_path)
        for organism_data in organisms_data:
            if 'limbs' in organism_data:  # Assuming 'limbs' only for animals
                organism = Animal(organism_data['species'], organism_data['age'], organism_data['limbs'], organism_data['habitat'])
            else:
                organism = Plant(organism_data['species'], organism_data['age'], organism_data['habitat'])
            self.add_organism(organism)

    def add_organism(self, organism):
        self.organisms.append(organism)

    def simulate_day(self):
        print(f"Simulating a day in the {self.name} Biome:")
        for organism in self.organisms:
            if organism.is_alive:
                organism.move()
                organism.eat()
                organism.reproduce()
                if isinstance(organism, Animal):
                    prey = self.find_prey(organism)
                    if prey:
                        print(f"{organism.species} is hunting {prey.species}.")
                        prey.die()
                        # Implement limb removal for the prey
                        prey.lose_limb()
                    # Simulate animal communication
                    self.animal_communication(organism)
            else:
                print(f"{organism.species} is dead and cannot perform any actions.")

    def find_prey(self, predator):
        prey_candidates = [org for org in self.organisms if isinstance(org, Animal) and org != predator]
        if prey_candidates:
            return random.choice(prey_candidates)
        return None

    def animal_communication(self, organism):
        # Simulate animal communication
        print(f"{organism.species} is communicating with other {organism.species}.")

class Organism:
    def __init__(self, species, age):
        self.species = species
        self.age = age
        self.is_alive = True

    def move(self):
        print(f"{self.species} is moving.")

    def eat(self):
        print(f"{self.species} is eating.")

    def reproduce(self):
        print(f"{self.species} is reproducing.")

    def die(self):
        print(f"{self.species} has died.")
        self.is_alive = False

class Plant(Organism):
    def __init__(self, species, age, habitat):
        super().__init__(species, age)
        self.habitat = habitat

    def move(self):
        print(f"{self.species} can't move, it's a plant in the {self.habitat} habitat.")

    def eat(self):
        print(f"{self.species} is absorbing nutrients from the soil in the {self.habitat} habitat.")

    def reproduce(self):
        print(f"{self.species} is spreading seeds in the {self.habitat} habitat.")

class Animal(Organism):
    def __init__(self, species, age, limbs, habitat):
        super().__init__(species, age)
        self.limbs = limbs
        self.habitat = habitat

    def move(self):
        print(f"{self.species} is moving in the {self.habitat} habitat.")

    def eat(self):
        print(f"{self.species} is hunting for food.")

    def reproduce(self):
        print(f"{self.species} is mating.")

    def lose_limb(self):
        if self.limbs > 0:
            self.limbs -= 1
            print(f"{self.species} lost a limb! Remaining limbs: {self.limbs}")
        else:
            self.die()

# Sample usage
biome_forest = Biome("Forest")
biome_forest.add_organisms_from_json('animals.json')
biome_forest.add_organisms_from_json('plants.json')

biome_forest.simulate_day()

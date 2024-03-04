import json
import os

class Entity:
    def __init__(self, name):
        self.name = name

class Organism(Entity):
    def __init__(self, name, species, age):
        super().__init__(name)
        self.species = species
        self.age = age
        self.is_alive = True
        self.health = 100
        self.oxygen = 100
        self.temperature_tolerance = {'min': 0, 'max': 100}
        self.disease_resistance = 100
        self.sanity = 100

    def move(self):
        print(f"{self.species} {self.name} is moving.")

    def eat(self):
        print(f"{self.species} {self.name} is eating.")

    def reproduce(self):
        print(f"{self.species} {self.name} is reproducing.")

    def die(self):
        print(f"{self.species} {self.name} has died.")
        self.is_alive = False

    def adjust_oxygen(self, amount):
        self.oxygen += amount
        print(f"{self.species} {self.name} oxygen level adjusted to {self.oxygen}.")

    def adjust_temperature(self, amount):
        self.temperature_tolerance['min'] += amount
        self.temperature_tolerance['max'] += amount
        print(f"{self.species} {self.name} temperature tolerance adjusted to {self.temperature_tolerance['min']}-{self.temperature_tolerance['max']}°C.")

    def adjust_disease_resistance(self, amount):
        self.disease_resistance += amount
        print(f"{self.species} {self.name} disease resistance adjusted to {self.disease_resistance}.")

    def adjust_sanity(self, amount):
        self.sanity += amount
        print(f"{self.species} {self.name} sanity adjusted to {self.sanity}.")

class Animal(Organism):
    def __init__(self, name, species, age, limbs, temperature_preference):
        super().__init__(name, species, age)
        self.limbs = limbs
        self.hunger = 10
        self.strength = 1
        self.gender = 'male' if random.random() < 0.5 else 'female'
        self.temperature_preference = temperature_preference
        self.is_hungry = True

    def attack(self, type):
        damage = 0
        if type == 'bite':
            damage = self.strength * 2
        elif type == 'claw':
            damage = self.strength * 1.5
        elif type == 'tailSwipe':
            damage = self.strength * 1.2
        else:
            damage = self.strength
        print(f"{self.species} {self.name} performs a {type} attack, dealing {damage} damage.")
        return damage

    def defend(self):
        print(f"{self.species} {self.name} is defending.")

    def evade(self):
        print(f"{self.species} {self.name} is evading.")

    def move(self):
        print(f"{self.species} {self.name} is running.")

    def eat(self):
        print(f"{self.species} {self.name} is hunting.")
        self.hunger -= 20
        if self.hunger <= 0:
            self.is_hungry = False

    def lose_limb(self):
        if self.limbs > 0:
            self.limbs -= 1
            print(f"{self.species} {self.name} lost a limb! Remaining limbs: {self.limbs}")
        else:
            self.die()

    def adjust_health(self, amount):
        self.health += amount
        print(f"{self.species} {self.name} health adjusted to {self.health}.")

class Ecosystem:
    def __init__(self):
        self.entities = []
        self.temperature = 25
        self.log = []
        self.day = 0

    def add_entity(self, entity):
        self.entities.append(entity)

    def simulate_day(self):
        print(f"Simulating Day {self.day} in the ecosystem:")
        for entity in self.entities:
            if isinstance(entity, Organism) and entity.is_alive:
                entity.move()
                entity.eat()
                entity.reproduce()
                entity.adjust_oxygen(-5)
                entity.adjust_temperature(1)
                entity.adjust_disease_resistance(-1)
                entity.adjust_sanity(-1)
                if isinstance(entity, Animal):
                    entity.lose_limb()
                    if entity.is_hungry:
                        entity.die()
        self.temperature += random.uniform(-1, 1)
        print(f"Current temperature: {self.temperature:.2f}°C")
        self.log.append(f"Day {self.day}: Temperature changed to {self.temperature:.2f}°C.")
        self.day += 1

    def clean_ecosystem(self):
        self.entities = [entity for entity in self.entities if entity.is_alive]

    def check_ecosystem_health(self):
        alive_organisms = [entity for entity in self.entities if isinstance(entity, Organism) and entity.is_alive]
        total_organisms = len([entity for entity in self.entities if isinstance(entity, Organism)])
        health_percentage = (len(alive_organisms) / total_organisms) * 100
        print(f"Ecosystem health: {health_percentage:.2f}%")

    def display_log(self):
        print("Event Log:")
        for event in self.log:
            print(event)

    def save(self, filename):
        app_dir = '/robjam1990/Psychosis/Gameplay/Planets/Thear/'
        file_path = os.path.join(app_dir, filename)
        data = {
            'entities': [entity.__dict__ for entity in self.entities],
            'temperature': self.temperature,
            'log': self.log,
            'day': self.day
        }
        with open(file_path, 'w') as file:
            json.dump(data, file)
        print(f"Ecosystem saved to {file_path}")

    def load(self, filename):
        app_dir = '/robjam1990/Psychosis/Gameplay/Planets/Thear/'
        file_path = os.path.join(app_dir, filename)
        with open(file_path, 'r') as file:
            saved_state = json.load(file)
            self.entities = [Organism(**entity) if 'limbs' not in entity else Animal(**entity) for entity in saved_state['entities']]
            self.temperature = saved_state['temperature']
            self.log = saved_state['log']
            self.day = saved_state['day']
        print(f"Ecosystem loaded from {file_path}")

# Test the ecosystem save and load functions
ecosystem = Ecosystem()
predators = [Animal("Fox", "Fox", 3, 4, {'min': 20, 'max': 30}), Animal("Wolf", "Wolf", 4, 4, {'min': 15, 'max': 25})]
for predator in predators:
    ecosystem.add_entity(predator)

# Save the ecosystem
ecosystem.save('ecosystem.json')

# Create a new ecosystem and load the saved state
new_ecosystem = Ecosystem()
new_ecosystem.load('ecosystem.json')

# Display event log of the loaded ecosystem
new_ecosystem.display_log()

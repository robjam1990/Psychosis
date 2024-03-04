# file = robjam1990/psychosis/gameplay/system/reproduction.py
import random


class Character:
    def __init__(self, name, gender, stats):
        self.name = name
        self.gender = gender
        self.stats = stats

    def display_info(self):
        print(f"{self.name} - {self.gender}")
        print("Stats:")
        for stat, value in self.stats.items():
            print(f"{stat}: {value}")


def reproduce(parent1, parent2, elitism=False):
    child_name = f"{parent1.name}'s offspring"
    child_gender = random.choice(["Male", "Female"])

    if elitism:
        if child_gender == "Male":
            child_stats = {}
            for stat, value in parent1.stats.items():
                child_stats[stat] = value + (parent1.stats[stat] * 0.1)  # Copy 10% of the stat value
        else:
            child_stats = {}
            for stat, value in parent2.stats.items():
                child_stats[stat] = value + (parent2.stats[stat] * 0.1)  # Copy 10% of the stat value
    else:
        child_stats = {}
        for stat, value in parent1.stats.items():
            child_stats[stat] = random.uniform(value * 0.9, value * 1.1)
        for stat, value in parent2.stats.items():
            child_stats[stat] = (child_stats.get(stat, 0) + random.uniform(value * 0.9, value * 1.1)) / 2

    return Character(child_name, child_gender, child_stats)


parent1 = Character("Alice", "Female", {"Strength": 10, "Agility": 8, "Intelligence": 12})
parent2 = Character("Bob", "Male", {"Strength": 12, "Agility": 9, "Intelligence": 10})

# Test reproduction without elitism
child = reproduce(parent1, parent2)
child.display_info()

# Test reproduction with elitism
child_elitism = reproduce(parent1, parent2, elitism=True)
child_elitism.display_info()

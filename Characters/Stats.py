class Stats:
    def __init__(self):
        self.health = 100
        self.energy = 100
        self.hunger = 0
        self.thirst = 0
        self.strength = 5
        self.endurance = 5
        self.speed = 5
        self.perception = 5
        self.intelligence = 5
        self.knowledge = 5
        self.experience = 0
        self.will = 5
        self.patience = 5
        self.flexibility = 5
        self.balance = 5
        self.charisma = 5

traits = {
    'physical': {'strength': 0, 'speed': 0, 'aggression': 0, 'health': 0, 'appeal': 0},
    'social': {'humility': 0, 'temperament': 0, 'generosity': 0, 'loyalty': 0, 'honesty': 0},
    'Emotional': {'Spontaneity': 0, 'Mannerism': 0, 'Rage': 0},
    'Behavioral': {'Curiosity': 0, 'Dependency': 0, 'Confidence': 0, 'Ambition': 0},
    'Intellectual': {'Creativity': 0, 'Concentration': 0, 'Intelligence': 0}
}

occupation = {
    'Royalty': ["King", "Queen", "Lord", "Lady"],
    'Military': ["Guard", "Soldier", "Captain", "Commander", "General"],
    'Civilian': ["Bard", "Alchemist", "Tanner", "Healer", "Farmer", "Blacksmith", "Barkeep", "Barmaid", "ShopKeep", "Apprentice", "Assistant", "Fletcher", "Butcher", "Weaver", "Potter"],
    'Labour': ["Miner", "Hunter", "Athlete", "Scavenger", "Servant"],
    'Criminal': ["Thief", "Murderer", "Assassin", "Pirate", "Bandit"],
    'Traversal': ["Slave", "Settler", "Adventurer", "Explorer"],
    'Dangerous': ["Mercenary"],
    'School': ["Doctor", "Teacher", "Scholar", "Genius"],
    'Specialist': ["Researcher", "Engineer", "Inventor", "Architect", "Plumber", "Pilot"],
    'Other': ["Idiot", "Jester", "Judge", "Executioner", "Vagrant", "Priest"]
}

my_character = {
    'stats': Stats(),
    'traits': traits,
    'occupation': occupation
}

print(my_character)

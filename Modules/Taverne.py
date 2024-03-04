import random

# Quest Management Object
class QuestManager:
    def __init__(self):
        self.activeQuests = []
        self.completedQuests = []

    def startQuest(self, quest):
        self.activeQuests.append(quest)
        print(f'Quest "{quest.name}" started.')

    def completeQuest(self, quest):
        if quest in self.activeQuests:
            self.activeQuests.remove(quest)
            self.completedQuests.append(quest)
            print(f'Quest "{quest.name}" completed.')
            # Grant rewards and handle quest completion logic
        else:
            print(f'Quest "{quest.name}" not found.')

# NPC Class with Behavior and Interaction
class NPC:
    def __init__(self, name, description, location, quests):
        self.name = name
        self.description = description
        self.location = location
        self.quests = quests
        self.behavior = self.getRandomBehavior()

    def getRandomBehavior(self):
        behaviors = ["Friendly", "Neutral", "Aggressive"]
        return random.choice(behaviors)

    def interact(self):
        if self.behavior == "Friendly":
            print(f'{self.name} greets you warmly.')
        elif self.behavior == "Neutral":
            print(f'{self.name} acknowledges your presence.')
        elif self.behavior == "Aggressive":
            print(f'{self.name} eyes you warily.')
        else:
            print(f'{self.name} has an invalid behavior.')

class Town:
    def __init__(self, name):
        self.name = name

class Structure:
    def __init__(self, name, type, size):
        self.name = name
        self.type = type
        self.size = size

class Room:
    def __init__(self, name, type, size):
        self.name = name
        self.type = type
        self.size = size

barkeep_quest_1 = {"name": "Delivery", "description": "The barkeep needs someone to deliver a shipment of ale to a nearby village. Are you up for the task?", "reward": "5 Silver coins and the gratitude of the barkeep."}
barkeep_quest_2 = {"name": "Scouting", "description": "The barkeep has heard rumors of strange occurrences in the nearby forest. Can you investigate and report back? [Optional: will pay for Ginger and Barley.]", "reward": "10 silver coins for Valuable Information as well as 2 Silver coins per Barley and 3 per Ginger."}

maia_quest = {"name": "Welcome", "description": "You are Hungry and Thirsty, go see the Barkeep for some Charity.", "reward": "Leg of Phesant, Cup of Juice, Half of Bread Loaf, Potatoe."}

barkeep = NPC("Barkeep", "The barkeep is a stout and friendly figure, always ready with a warm smile and a kind word for patrons. He's the heart and soul of Ye Olde Taverne, keeping spirits high and glasses full.", [0, 0, 0], [barkeep_quest_1, barkeep_quest_2])

maia = NPC("Maia", "Maia is a slim and friendly figure, always ready with a warm smile and a kind word for patrons. She's the Lungs of Ye Olde Taverne, bringing in new patrons.", [26, -5, 0], [maia_quest])

interactiveElements = [
    {"name": "Barkeep", "description": "The jovial barkeep stands behind the polished bar, ready to serve patrons with a welcoming smile and a quick wit. You can {talk} to him or {order} a drink."},
    {"name": "Maia", "description": "The capricious greeter stand near the entrance, constantly greeting patrons with a welcoming smile, friendly demeanor and a quick wit. You can {talk} to her."},
    {"name": "Notice Board", "description": "A notice board hangs on the wall, covered in various parchments and flyers. You can {read} the notices for information on available quests or tasks."},
    {"name": "Training Area", "description": "In the corner of the taverne, a training area beckons to those seeking to hone their skills. You can {practice} your combat techniques here."},
    {"name": "Seating", "description": "In the center of the taverne, a seating area for adventurers to connect. You can make friends and be {social} here."},
    {"name": "Pyre", "description": "Near the entrance, a hearth to keep warm. You can {cook} food here."},
    {"name": "Latrines", "description": "Just outside the entrance, a public Latrine. You can empty {waste} here."},
    {"name": "Well", "description": "Outside by the walking path, a working well water source. You can get fresh water here."},
    {"name": "Back Room", "description": "Reservable for private parties, with a Private Table, Chests and Beds. Speak with the barkeep for more information."},
    {"name": "Storage", "description": "Scattered all over the Main hall, public barrels, chests and cupboards sit. You can use these to store and take items."}
]

Location = {
    "name": "Ye Olde Taverne",
    "image": ["Taverne.jpg", "Taverne(upstairs).jpg"],
    "description": "You step into the Main hall of Ye Olde Taverne, a warm and inviting establishment nestled in the heart of Nexus. It's a place where weary travelers find respite, adventurers plan their next quests, and locals gather for camaraderie and revelry.",
    "interactiveElements": interactiveElements,
    "npc": [barkeep, maia]
}

# UI Interaction Methods
def interactWithBarkeep(action):
    if action == "talk":
        print("You engage the barkeep in conversation about the latest gossip and happenings in the Taverne.")
        # Implement conversation options
    elif action == "order":
        print("You order a drink from the barkeep, who quickly serves you a frothy mug of ale.")
        # Implement ordering functionality
    else:
        print("Invalid action:", action)

def interactWithMaia(action):
    if action == "talk":
        print("You engage Maia in conversation about the latest gossip and happenings in Nexus.")
        # Implement conversation options
    else:
        print("Invalid action:", action)

def readNoticeBoard():
    print("You approach the notice board and scan the various notices pinned to it, looking for...")
    # Code to display available quests or tasks
    print("Decree: Messages directly from the jurisdictional commanding Royal Family")
    print("Notice: Messages from the establishment")
    print("Bounty: Messages from NPCs")
    print("Request: Messages from Humans")
    print("Write: Write a message")

def practiceCombat():
    print("You spend some time practicing your combat skills in the training area, honing your techniques for future battles.")
    # Code to simulate combat practice
    print("Exercise: Choose an Exercise")
    print("Time: Choose a Duration Goal")
    print("Companion: Choose a Sparring Companion")
    print("Trainer: Choose your trainer")

def Seating():
    print("You approach the seating area and scan the various empty and full tables, looking for...")
    # Code to display available quests or tasks
    print("Tables: List of available tables")
    print("Stools: List of available seating")
    print("Person: List of recognized people")

def Pyre():
    print("You approach the hearth and notice the temperature increase associated with it, ready to cook.")
    # Code to display available quests or tasks
    print("Cook: Place on the fire")
    print("Warm: Place near the fire")
    print("Rest: Rest near the fire")

def Well():
    print("You approach the well and scan the interior, looking for...")
    # Code to display available quests or tasks
    print("Harvest: Gather some drinking water")
    print("Pollute: Pollute the drinking water")

def Latrine():
    print("You approach the public latrines and scan the various stalls, looking for...")
    # Code to display available quests or tasks
    print("Evacuate: Dispel waste")
    print("Clean: Clean latrine")

def BackRoom():
    print("You approach the back room and scan the long room, looking for...")
    # Code to display available quests or tasks
    print("Enter: Attempt to enter the back room")

def Storage():
    print("You approach the storage containers and scan the various compartments, looking for...")
    # Code to display available quests or tasks
    print("Barrel: Open barrel")
    print("Chest: Open chest")
    print("Cupboard: Open cupboard")

# Example interactions
interactWithBarkeep("talk")
interactWithBarkeep("order")
readNoticeBoard()
practiceCombat()

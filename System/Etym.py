# fileHandler.py
import json

def read_json_file(file_path):
    try:
        with open(file_path, 'r') as file:
            data = json.load(file)
            return data
    except Exception as e:
        raise ValueError("Error reading file: " + str(e))

# insectActions.py
from playerInventory import add_insect

# Function to capture an insect
def capture(insects, index):
    if not str(index).isdigit():
        print("Invalid input. Index must be a number.")
        return
    if insects and 0 <= index < len(insects):
        print("You captured a " + insects[index]["name"] + "!")
        add_insect(insects[index])
    else:
        print("Invalid insect index or 'insects' list is not defined or empty.")

# Function to study the behavior of an insect
def study(insects, index):
    if not str(index).isdigit():
        print("Invalid input. Index must be a number.")
        return
    if insects and 0 <= index < len(insects):
        print("Behavior of " + insects[index]["name"] + ": " + insects[index]["behavior"])
        # Additional logic for studying the insect's behavior can be added here
    else:
        print("Invalid insect index or 'insects' list is not defined or empty.")

# Function to assess the ecological impact of an insect
def assess_ecological_impact(insects, index):
    if not str(index).isdigit():
        print("Invalid input. Index must be a number.")
        return
    if insects and 0 <= index < len(insects):
        print("Ecological Impact of " + insects[index]["name"] + ": " + insects[index]["ecologicalImpact"])
        # Additional logic for assessing ecological impact can be added here
    else:
        print("Invalid insect index or 'insects' list is not defined or empty.")

# playerInventory.py
player_inventory = []

def add_insect(insect):
    player_inventory.append(insect)
    print("Added " + insect["name"] + " to player's inventory.")

# main.py
from fileHandler import read_json_file
from insectActions import capture, study, assess_ecological_impact

# Load insects from the JSON file
insects = read_json_file('insect.json')

# Example usage:
capture(insects, 2)  # Capture the Beetle at index 2
study(insects, 0)    # Study the behavior of the Bee at index 0
assess_ecological_impact(insects, 3)  # Assess the ecological impact of the Ant at index 3

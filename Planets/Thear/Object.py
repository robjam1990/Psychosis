# Define the Furniture dictionary
Furniture = {
    "Stool": {
        "Main Hall": 38,
        "Back Room": 10,
        "Training Room": 0,
        "Office": 2,
        "Storage Room": 0,
        "Bedroom": 0
    },
    "Table": {
        "Main Hall": 11,
        "Back Room": 1,
        "Training Room": 0,
        "Office": 1,
        "Storage Room": 0,
        "Bedroom": 0
    },
    "Storage": {
        "Main Hall": 5,
        "Back Room": 4,
        "Training Room": 0,
        "Office": 0,
        "Storage Room": 8,
        "Bedroom": 7
    }
}

def get_furniture_quantity(type, room):
    if type in Furniture and room in Furniture[type]:
        return Furniture[type][room]
    else:
        print(f"Invalid type ({type}) or room ({room}). Please provide valid arguments.")
        return 0

# Example usage:
print(get_furniture_quantity("Stool", "Main Hall"))  # Output: 38
print(get_furniture_quantity("Table", "Office"))    # Output: 1
print(get_furniture_quantity("Storage", "Bedroom")) # Output: 7
print(get_furniture_quantity("Chair", "Main Hall")) # Output: 0 (Invalid type)

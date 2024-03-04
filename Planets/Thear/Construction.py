# File = robjam1990/Psychosis/Gameplay/Planets/Thear/Construction.py
class Season:
    Spring = 0
    Summer = 1
    Autumn = 2
    Winter = 3

class Resource:
    def __init__(self, name, amount):
        self.name = name
        self.amount = amount

class Structure:
    def __init__(self, name, required_resources, durability):
        self.name = name
        self.required_resources = required_resources
        self.durability = durability
        self.max_durability = durability

    def check_requirements(self, player_inventory):
        for resource in self.required_resources:
            if resource.name not in player_inventory or player_inventory[resource.name] < resource.amount:
                return False
        return True

    def deduct_resources(self, player_inventory):
        for resource in self.required_resources:
            player_inventory[resource.name] -= resource.amount

    def repair(self, player_inventory):
        repair_cost = (self.max_durability - self.durability) * 5  # Example repair cost formula
        if "gold" in player_inventory and player_inventory["gold"] >= repair_cost:
            player_inventory["gold"] -= repair_cost
            self.durability = self.max_durability
            print(f"{self.name} repaired.")
        else:
            print("Insufficient resources to repair.")


class World:
    def __init__(self):
        self.Locations = []
        self.CurrentSeason = Season.Spring
        self.CurrentDay = 1
        self.CurrentHour = 0
        self.IsDaytime = True

    def SimulateStructureDegradation(self):
        for location in self.Locations:
            for structure in location.Structures:
                # Simulate degradation by reducing durability
                structure.durability -= 1
                if structure.durability <= 0:
                    location.Structures.remove(structure)
                    print(f"{structure.name} degraded and destroyed in {location.Name}.")

    def ConstructStructure(self, locationName, structure, player_inventory):
        location = next((l for l in self.Locations if l.Name == locationName), None)
        if location:
            if structure.check_requirements(player_inventory):
                structure.deduct_resources(player_inventory)
                location.Structures.append(structure)
                print(f"{structure.name} constructed in {locationName}.")
            else:
                print(f"Insufficient resources to construct {structure.name}.")
        else:
            print(f"Location {locationName} not found.")

    def RepairStructure(self, locationName, structureName, player_inventory):
        location = next((l for l in self.Locations if l.Name == locationName), None)
        if location:
            structure = next((s for s in location.Structures if s.name == structureName), None)
            if structure:
                structure.repair(player_inventory)
            else:
                print(f"Structure {structureName} not found in {locationName}.")
        else:
            print(f"Location {locationName} not found.")


if __name__ == "__main__":
    world = World()
    player_inventory = {"wood": 100, "stone": 50, "gold": 200}  # Example player inventory

    # Example usage
    house_resources = [Resource("wood", 20), Resource("stone", 10)]
    house = Structure("House", house_resources, durability=50)
    world.ConstructStructure("Village A", house, player_inventory)

    # Simulate structure degradation
    world.SimulateStructureDegradation()

    # Repair a structure
    world.RepairStructure("Village A", "House", player_inventory)


    # Simulate time for 24 hours
    world.SimulateTime(24)

    # Take a prisoner
    world.TakePrisoners("Village A", "Enemy Soldier")

    # Rename a location
    world.RenameLocation("Village A", "New Village A")

    # Rename a structure
    world.RenameStructure("Village B", "House", "New House")

    # Simulate structure degradation
    world.SimulateStructureDegradation()

# File: Psychosis/Gameplay/Management/logistics.py

class LogisticsManager:
    def __init__(self):
        self.resources = {}  # Dictionary to store available resources and their quantities
        self.transportationNetwork = {}  # Dictionary to store transportation routes and methods
        self.distributionCenters = []  # List to store distribution centers for resources

    # Method to add resources to the logistics system
    def add_resources(self, resource, quantity):
        if resource in self.resources:
            self.resources[resource] += quantity
        else:
            self.resources[resource] = quantity

    # Method to remove resources from the logistics system
    def remove_resources(self, resource, quantity):
        if resource in self.resources:
            if self.resources[resource] >= quantity:
                self.resources[resource] -= quantity
            else:
                print(f"Insufficient {resource} available.")
        else:
            print(f"No {resource} available.")

    # Method to add a transportation route
    def add_transportation_route(self, route_name, origin, destination, distance):
        if route_name not in self.transportationNetwork:
            self.transportationNetwork[route_name] = {"origin": origin, "destination": destination, "distance": distance}
        else:
            print(f"Route {route_name} already exists.")

    # Method to add a distribution center
    def add_distribution_center(self, center):
        self.distributionCenters.append(center)

    # Method to handle resource distribution
    def distribute_resources(self):
        # Implementation logic for distributing resources among distribution centers
        # and managing transportation routes goes here
        pass

# Example Usage:
logistics = LogisticsManager()

# Add resources to the logistics system
logistics.add_resources('food', 100)
logistics.add_resources('water', 50)

# Remove resources from the logistics system
logistics.remove_resources('food', 20)

# Add transportation route
logistics.add_transportation_route('Nexus to Bractalia', 'Nexus', 'Bractalia', 100)  # Example distance: 100 units

# Add distribution center
logistics.add_distribution_center('Nexus Distribution Center')

# Distribute resources
logistics.distribute_resources()

# Exporting the class for external usage
if __name__ == "__main__":
    import sys
    sys.path.append("..")
    from Gameplay.Management.logistics import LogisticsManager
    export_logistics_manager = LogisticsManager()
    export_logistics_manager.add_resources('food', 100)
    print(export_logistics_manager.resources)

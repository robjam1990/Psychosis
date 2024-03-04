# Define the Resource class
class Resource:
    def __init__(self, type, renewable, quantity):
        self.type = type
        self.renewable = renewable
        self.quantity = quantity

# Define a resource node class
class ResourceNode:
    def __init__(self, resource, maxQuantity):
        self.resource = resource
        self.maxQuantity = maxQuantity
        self.currentQuantity = maxQuantity

    # Method to gather resources from the node
    def gather(self, amount):
        if self.currentQuantity >= amount:
            self.currentQuantity -= amount
            return amount
        else:
            remaining = self.currentQuantity
            self.currentQuantity = 0
            return remaining

    # Method to check if the node is depleted
    def isDepleted(self):
        return self.currentQuantity == 0

# Function to gather resources
def gatherResources(node, amount):
    gatheredAmount = node.gather(amount)
    if gatheredAmount > 0:
        print(f"Gathered {gatheredAmount} {node.resource.type} resources.")
    else:
        print(f"Warning: {node.resource.type} resource node depleted.")

# Example usage:
discoveredResource = Resource("type", True, 100)  # Example: Replace "type" with the actual type of resource discovered
discoveredNode = ResourceNode(discoveredResource, 100)
gatherResources(discoveredNode, 10)  # Gather 10 resources from the discovered node
gatherResources(discoveredNode, 100)  # Try to gather more resources after depletion

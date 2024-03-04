// File = robjam1990/Psychosis/Gameplay/Resources/resources.js
// Define the Resource class
class Resource {
    constructor(type, renewable, quantity) {
        this.type = type;
        this.renewable = renewable;
        this.quantity = quantity;
    }
}

// Define a resource node class
class ResourceNode {
    constructor(resource, maxQuantity) {
        this.resource = resource;
        this.maxQuantity = maxQuantity;
        this.currentQuantity = maxQuantity;
    }

    // Method to gather resources from the node
    gather(amount) {
        if (this.currentQuantity >= amount) {
            this.currentQuantity -= amount;
            return amount;
        } else {
            const remaining = this.currentQuantity;
            this.currentQuantity = 0;
            return remaining;
        }
    }

    // Method to check if the node is depleted
    isDepleted() {
        return this.currentQuantity === 0;
    }
}

// Function to gather resources
const gatherResources = (node, amount) => {
    const gatheredAmount = node.gather(amount);
    if (gatheredAmount > 0) {
        console.log(`Gathered ${gatheredAmount} ${node.resource.type} resources.`);
    } else {
        console.log(`Warning: ${node.resource.type} resource node depleted.`);
    }
};

// Example usage:
const discoveredResource = new Resource("type", true, 100); // Example: Replace "type" with the actual type of resource discovered
const discoveredNode = new ResourceNode(discoveredResource, 100);
gatherResources(discoveredNode, 10); // Gather 10 resources from the discovered node
gatherResources(discoveredNode, 100); // Try to gather more resources after depletion

module.exports = { Resource, ResourceNode, gatherResources };

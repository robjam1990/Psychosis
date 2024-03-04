using System;

// Define the Resource class
public class Resource
{
    public string Type { get; }
    public bool Renewable { get; }
    public int Quantity { get; }

    public Resource(string type, bool renewable, int quantity)
    {
        Type = type;
        Renewable = renewable;
        Quantity = quantity;
    }
}

// Define a resource node class
public class ResourceNode
{
    public Resource Resource { get; }
    public int MaxQuantity { get; }
    public int CurrentQuantity { get; set; }

    public ResourceNode(Resource resource, int maxQuantity)
    {
        Resource = resource;
        MaxQuantity = maxQuantity;
        CurrentQuantity = maxQuantity;
    }

    // Method to gather resources from the node
    public int Gather(int amount)
    {
        if (CurrentQuantity >= amount)
        {
            CurrentQuantity -= amount;
            return amount;
        }
        else
        {
            int remaining = CurrentQuantity;
            CurrentQuantity = 0;
            return remaining;
        }
    }

    // Method to check if the node is depleted
    public bool IsDepleted()
    {
        return CurrentQuantity == 0;
    }
}

public class Program
{
    // Function to gather resources
    public static void GatherResources(ResourceNode node, int amount)
    {
        int gatheredAmount = node.Gather(amount);
        if (gatheredAmount > 0)
        {
            Console.WriteLine($"Gathered {gatheredAmount} {node.Resource.Type} resources.");
        }
        else
        {
            Console.WriteLine($"Warning: {node.Resource.Type} resource node depleted.");
        }
    }

    public static void Main(string[] args)
    {
        // Example usage:
        Resource discoveredResource = new Resource("type", true, 100); // Replace "type" with the actual type of resource discovered
        ResourceNode discoveredNode = new ResourceNode(discoveredResource, 100);
        GatherResources(discoveredNode, 10); // Gather 10 resources from the discovered node
        GatherResources(discoveredNode, 100); // Try to gather more resources after depletion
    }
}

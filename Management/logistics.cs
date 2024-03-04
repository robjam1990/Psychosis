using System;
using System.Collections.Generic;

namespace Psychosis.Gameplay.Management
{
    // File: Psychosis/Gameplay/Management/LogisticsManager.cs
    public class LogisticsManager
    {
        private Dictionary<string, int> resources; // Dictionary to store available resources and their quantities
        private Dictionary<string, Dictionary<string, object>> transportationNetwork; // Dictionary to store transportation routes and methods
        private List<string> distributionCenters; // List to store distribution centers for resources

        public LogisticsManager()
        {
            resources = new Dictionary<string, int>();
            transportationNetwork = new Dictionary<string, Dictionary<string, object>>();
            distributionCenters = new List<string>();
        }

        // Method to add resources to the logistics system
        public void AddResources(string resource, int quantity)
        {
            if (resources.ContainsKey(resource))
            {
                resources[resource] += quantity;
            }
            else
            {
                resources[resource] = quantity;
            }
        }

        // Method to remove resources from the logistics system
        public void RemoveResources(string resource, int quantity)
        {
            if (resources.ContainsKey(resource))
            {
                if (resources[resource] >= quantity)
                {
                    resources[resource] -= quantity;
                }
                else
                {
                    Console.WriteLine($"Insufficient {resource} available.");
                }
            }
            else
            {
                Console.WriteLine($"No {resource} available.");
            }
        }

        // Method to add a transportation route
        public void AddTransportationRoute(string routeName, string origin, string destination, int distance)
        {
            if (!transportationNetwork.ContainsKey(routeName))
            {
                transportationNetwork[routeName] = new Dictionary<string, object>
                {
                    { "origin", origin },
                    { "destination", destination },
                    { "distance", distance }
                };
            }
            else
            {
                Console.WriteLine($"Route {routeName} already exists.");
            }
        }

        // Method to add a distribution center
        public void AddDistributionCenter(string center)
        {
            distributionCenters.Add(center);
        }

        // Method to handle resource distribution
        public void DistributeResources()
        {
            // Implementation logic for distributing resources among distribution centers
            // and managing transportation routes goes here
        }

        // Example Usage:
        static void Main(string[] args)
        {
            LogisticsManager logistics = new LogisticsManager();

            // Add resources to the logistics system
            logistics.AddResources("food", 100);
            logistics.AddResources("water", 50);

            // Remove resources from the logistics system
            logistics.RemoveResources("food", 20);

            // Add transportation route
            logistics.AddTransportationRoute("Nexus to Bractalia", "Nexus", "Bractalia", 100); // Example distance: 100 units

            // Add distribution center
            logistics.AddDistributionCenter("Nexus Distribution Center");

            // Distribute resources
            logistics.DistributeResources();
        }
    }
}

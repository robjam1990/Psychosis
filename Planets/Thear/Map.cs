using System;

namespace Psychosis.Gameplay.Planets.Thear
{
    // Class for managing the map of the Taverne
    public class Map
    {
        // Function to display the map of the Taverne
        public static void DisplayMap(string location)
        {
            Console.WriteLine("Map of the Taverne:");
            Console.WriteLine("---------------------");

            // Define the map of the Taverne
            var tavernMap = new System.Collections.Generic.Dictionary<string, string>
            {
                ["Taverne"] = @"
                      [Office]---[TrainingRoom]-----{Stairs}
               [Bedroom]---|                  {Barkeep}   |     [Latrine]
                    [StorageRoom][TrainingArea]---|---[BackRoom]    |---[Well]
                                              [MainHall]---{FrontDoor}---(Nexus)
                                    [Storage]---|---{Maia}             |
                                              [Pyre]               (Bractalia)"
            };

            // Display the map for the given location
            Console.WriteLine(tavernMap.ContainsKey(location) ? tavernMap[location] : "Invalid location.");
            Console.WriteLine("---------------------");
            Console.WriteLine("Legend:");
            Console.WriteLine("[ ]: Rooms");
            Console.WriteLine("{ } : Key NPCs");
            Console.WriteLine("( ) : Towns/Countries");
            Console.WriteLine("--- : X-Axis Connections");
            Console.WriteLine("|  : Y-Axis Connections");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            Map.DisplayMap("Taverne");
        }
    }
}

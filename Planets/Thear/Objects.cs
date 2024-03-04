using System;
using System.Collections.Generic;

public class Objects
{
    // Define the Furniture dictionary
    private static Dictionary<string, Dictionary<string, int>> Furniture = new Dictionary<string, Dictionary<string, int>>
    {
        {"Stool", new Dictionary<string, int>
            {
                {"Main Hall", 38},
                {"Back Room", 10},
                {"Training Room", 0},
                {"Office", 2},
                {"Storage Room", 0},
                {"Bedroom", 0}
            }
        },
        {"Table", new Dictionary<string, int>
            {
                {"Main Hall", 11},
                {"Back Room", 1},
                {"Training Room", 0},
                {"Office", 1},
                {"Storage Room", 0},
                {"Bedroom", 0}
            }
        },
        {"Storage", new Dictionary<string, int>
            {
                {"Main Hall", 5},
                {"Back Room", 4},
                {"Training Room", 0},
                {"Office", 0},
                {"Storage Room", 8},
                {"Bedroom", 7}
            }
        }
    };

    // Retrieves the quantity of furniture in a specific room
    public static int GetFurnitureQuantity(string type, string room)
    {
        if (Furniture.ContainsKey(type) && Furniture[type].ContainsKey(room))
        {
            return Furniture[type][room];
        }
        else
        {
            Console.WriteLine($"Invalid type ({type}) or room ({room}). Please provide valid arguments.");
            return 0;
        }
    }

    // Example usage
    public static void Main(string[] args)
    {
        Console.WriteLine(GetFurnitureQuantity("Stool", "Main Hall"));  // Output: 38
        Console.WriteLine(GetFurnitureQuantity("Table", "Office"));     // Output: 1
        Console.WriteLine(GetFurnitureQuantity("Storage", "Bedroom"));  // Output: 7
        Console.WriteLine(GetFurnitureQuantity("Chair", "Main Hall"));   // Output: 0 (Invalid type)
    }
}

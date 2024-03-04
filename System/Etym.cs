using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

// FileHandler.cs
public static class FileHandler
{
    public static List<Insect> ReadJsonFile(string filePath)
    {
        try
        {
            string jsonData = File.ReadAllText(filePath);
            List<Insect> insects = JsonConvert.DeserializeObject<List<Insect>>(jsonData);
            return insects;
        }
        catch (Exception e)
        {
            throw new Exception("Error reading file: " + e.Message);
        }
    }
}

// InsectActions.cs
public static class InsectActions
{
    public static void Capture(List<Insect> insects, int index)
    {
        if (!int.TryParse(index.ToString(), out int result))
        {
            Console.WriteLine("Invalid input. Index must be a number.");
            return;
        }
        if (insects != null && index >= 0 && index < insects.Count)
        {
            Console.WriteLine("You captured a " + insects[index].Name + "!");
            PlayerInventory.AddInsect(insects[index]);
        }
        else
        {
            Console.WriteLine("Invalid insect index or 'insects' list is not defined or empty.");
        }
    }

    public static void Study(List<Insect> insects, int index)
    {
        if (!int.TryParse(index.ToString(), out int result))
        {
            Console.WriteLine("Invalid input. Index must be a number.");
            return;
        }
        if (insects != null && index >= 0 && index < insects.Count)
        {
            Console.WriteLine("Behavior of " + insects[index].Name + ": " + insects[index].Behavior);
            // Additional logic for studying the insect's behavior can be added here
        }
        else
        {
            Console.WriteLine("Invalid insect index or 'insects' list is not defined or empty.");
        }
    }

    public static void AssessEcologicalImpact(List<Insect> insects, int index)
    {
        if (!int.TryParse(index.ToString(), out int result))
        {
            Console.WriteLine("Invalid input. Index must be a number.");
            return;
        }
        if (insects != null && index >= 0 && index < insects.Count)
        {
            Console.WriteLine("Ecological Impact of " + insects[index].Name + ": " + insects[index].EcologicalImpact);
            // Additional logic for assessing ecological impact can be added here
        }
        else
        {
            Console.WriteLine("Invalid insect index or 'insects' list is not defined or empty.");
        }
    }
}

// PlayerInventory.cs
public static class PlayerInventory
{
    public static List<Insect> playerInventory = new List<Insect>();

    public static void AddInsect(Insect insect)
    {
        playerInventory.Add(insect);
        Console.WriteLine("Added " + insect.Name + " to player's inventory.");
    }
}

// Insect.cs (Model class representing an insect)
public class Insect
{
    public string Name { get; set; }
    public string Behavior { get; set; }
    public string EcologicalImpact { get; set; }
}

// Main.cs
class MainClass
{
    public static void Main(string[] args)
    {
        // Load insects from the JSON file
        List<Insect> insects = FileHandler.ReadJsonFile("insect.json");

        // Example usage:
        InsectActions.Capture(insects, 2); // Capture the Beetle at index 2
        InsectActions.Study(insects, 0);   // Study the behavior of the Bee at index 0
        InsectActions.AssessEcologicalImpact(insects, 3); // Assess the ecological impact of the Ant at index 3
    }
}

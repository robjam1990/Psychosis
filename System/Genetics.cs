// File: robjam1990/Psychosis/Gameplay/System/Genetics.cs

using System;
using System.Collections.Generic;

public class Genetics
{
    private List<string> DNA;
    private List<string> RNA;
    private List<string> GNA;

    public Genetics()
    {
        // Initialize genetic engineering parameters
        DNA = new List<string>();
        RNA = new List<string>();
        GNA = new List<string>();
    }

    // Method to bio-engineer DNA, RNA, and GNA
    public void BioEngineer(string newDNA, string newRNA, string newGNA)
    {
        DNA.Add(newDNA);
        RNA.Add(newRNA);
        GNA.Add(newGNA);
        Console.WriteLine($"DNA successfully engineered: {newDNA}");
        Console.WriteLine($"RNA successfully engineered: {newRNA}");
        Console.WriteLine($"GNA successfully engineered: {newGNA}");
    }

    // Method to analyze genetic composition
    public void AnalyzeGenetics()
    {
        Console.WriteLine("Analyzing genetic composition...");
        Console.WriteLine($"DNA: {string.Join(", ", DNA)}");
        Console.WriteLine($"RNA: {string.Join(", ", RNA)}");
        Console.WriteLine($"GNA: {string.Join(", ", GNA)}");
    }

    // Method to modify existing genetic traits
    public void ModifyGenetics(int index, string newDNA, string newRNA, string newGNA)
    {
        if (index >= 0 && index < DNA.Count)
        {
            DNA[index] = newDNA;
            RNA[index] = newRNA;
            GNA[index] = newGNA;
            Console.WriteLine($"Genetic traits at index {index} successfully modified.");
        }
        else
        {
            Console.WriteLine("Invalid index. Unable to modify genetic traits.");
        }
    }

    // Method to remove genetic traits
    public void RemoveGenetics(int index)
    {
        if (index >= 0 && index < DNA.Count)
        {
            DNA.RemoveAt(index);
            RNA.RemoveAt(index);
            GNA.RemoveAt(index);
            Console.WriteLine($"Genetic traits at index {index} successfully removed.");
        }
        else
        {
            Console.WriteLine("Invalid index. Unable to remove genetic traits.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage:
        Genetics geneticsSystem = new Genetics();
        geneticsSystem.BioEngineer("AGCT", "AGCU", "AGCN");
        geneticsSystem.AnalyzeGenetics();
        geneticsSystem.ModifyGenetics(0, "TGCA", "UGCA", "CGAN");
        geneticsSystem.RemoveGenetics(1);
        geneticsSystem.AnalyzeGenetics();
    }
}

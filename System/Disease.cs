// File: robjam1990/Psychosis/Gameplay/System/Disease.cs

using System;
using System.Collections.Generic;

public class Symptom
{
    // Define the Symptom class to handle symptoms of diseases

    // Properties
    public string Name { get; }
    public int Severity { get; }
    public int Duration { get; }

    // Constructor
    public Symptom(string name, int severity, int duration)
    {
        Name = name;
        Severity = severity;
        Duration = duration;
    }
}

public class Disease
{
    // Define the Disease class to handle diseases in the game

    // Properties
    public string Name { get; }
    public List<Symptom> Symptoms { get; }
    public double TransmissionRate { get; }
    public double CureRate { get; }
    public int BaseDuration { get; }
    public List<Character> InfectedCharacters { get; }

    // Constructor
    public Disease(string name, List<Symptom> symptoms, double transmissionRate, double cureRate, int baseDuration)
    {
        Name = name;
        Symptoms = symptoms;
        TransmissionRate = transmissionRate;
        CureRate = cureRate;
        BaseDuration = baseDuration;
        InfectedCharacters = new List<Character>();
    }

    // Methods
    public void Spread(Character character)
    {
        if (new Random().NextDouble() < TransmissionRate)
        {
            InfectedCharacters.Add(character);
            Console.WriteLine($"{Name} has spread to {character.Name}");
        }
    }

    public void Progress()
    {
        foreach (Character character in InfectedCharacters)
        {
            character.ProgressDisease(this);
            Console.WriteLine($"{Name} is progressing in {character.Name}");
        }
    }

    public void Cure(Character character)
    {
        if (new Random().NextDouble() < CureRate)
        {
            if (InfectedCharacters.Contains(character))
            {
                InfectedCharacters.Remove(character);
                Console.WriteLine($"{character.Name} has been cured of {Name}");
            }
        }
    }
}

public class Character
{
    // Define the Character class to represent characters in the game

    // Properties
    public string Name { get; }
    public Dictionary<string, bool> Immunity { get; }
    public List<Disease> Diseases { get; }

    // Constructor
    public Character(string name, Dictionary<string, bool> immunity)
    {
        Name = name;
        Immunity = immunity;
        Diseases = new List<Disease>();
    }

    // Methods
    public void ContractDisease(Disease disease)
    {
        if (Immunity.ContainsKey(disease.Name) && Immunity[disease.Name])
        {
            Console.WriteLine($"{Name} is immune to {disease.Name}");
            return;
        }

        if (Diseases.Contains(disease))
        {
            Console.WriteLine($"{Name} is already infected with {disease.Name}");
            return;
        }

        Diseases.Add(disease);
        Console.WriteLine($"{Name} has contracted {disease.Name}");
    }

    public void ProgressDisease(Disease disease)
    {
        foreach (Symptom symptom in disease.Symptoms)
        {
            Console.WriteLine($"{Name} experiences {symptom.Name}");
        }
    }

    public void RecoverFromDisease(Disease disease)
    {
        if (Diseases.Contains(disease))
        {
            Diseases.Remove(disease);
            Console.WriteLine($"{Name} has recovered from {disease.Name}");
        }
    }
}

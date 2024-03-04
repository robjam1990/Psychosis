// File: robjam1990/psychosis/gameplay/management/Formations.cs

using System;
using System.Collections.Generic;

public class Formation
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    private List<string> members;

    public Formation(string name, string description, List<string> members = null)
    {
        Name = name;
        Description = description;
        this.members = members ?? new List<string>();
    }

    public void AddMember(string character)
    {
        if (!members.Contains(character))
        {
            members.Add(character);
            Console.WriteLine($"{character} added to {Name}.");
        }
    }

    public void RemoveMember(string character)
    {
        if (members.Contains(character))
        {
            members.Remove(character);
            Console.WriteLine($"{character} removed from {Name}.");
        }
    }

    public void DisplayMembers()
    {
        Console.WriteLine($"Members of {Name}:");
        foreach (var member in members)
        {
            Console.WriteLine($"- {member}");
        }
    }

    public void MoveMember(string character, string destination)
    {
        if (members.Contains(character))
        {
            Console.WriteLine($"{character} moved to {destination} in formation {Name}.");
            // Add logic to move character to specified position in formation
        }
    }

    public void RotateFormation(string direction)
    {
        Console.WriteLine($"Formation {Name} rotated {direction}.");
        // Add logic to rotate the formation clockwise or counterclockwise
    }

    public void Disband()
    {
        Console.WriteLine($"Formation {Name} disbanded.");
        members.Clear();
    }

    public string GetLeader()
    {
        // Add logic to retrieve the leader of the formation
        return null;
    }

    public void SetLeader(string character)
    {
        // Add logic to set a new leader for the formation
    }

    public int GetMemberCount()
    {
        return members.Count;
    }

    public bool IsFull()
    {
        // Add logic to check if the formation is full
        return false;
    }

    public bool IsEmpty()
    {
        return members.Count == 0;
    }
}

using System;
using System.Collections.Generic;

public class NPC
{
    public string Name { get; }
    public string Behavior { get; private set; }
    public bool IsHungry { get; set; }
    public bool IsThirsty { get; set; }
    public bool IsTired { get; set; }
    private List<Property> properties = new List<Property>();
    private dynamic thear;

    public NPC(string name, dynamic thear)
    {
        Name = name;
        Behavior = "Idle";
        IsHungry = false;
        IsThirsty = false;
        IsTired = false;
        this.thear = thear; // Inject Thear object
    }

    public void UpdateBehavior(double time, string weather)
    {
        dynamic Schedule = thear.Bractalia.Nexus.Taverne.NPCs.Schedule;
        dynamic Behaviors = thear.Bractalia.Nexus.Taverne.NPCs.Behaviors;
        string newBehavior = Behaviors.Idle; // Default behavior

        // Ensure Thear object and its nested properties exist
        if (!(time is double) || time < 0 || time > 24)
        {
            throw new ArgumentException("Invalid value for time parameter. Time must be a number between 0 and 24.");
        }

        // Validate weather parameter
        if (!(weather is string))
        {
            throw new ArgumentException("Invalid value for weather parameter. Weather must be a string.");
        }

        if (time >= Schedule.WakeUp && time < Schedule.WorkStart)
        {
            newBehavior = Behaviors.Idle;
        }
        else if (time >= Schedule.WorkStart && time < Schedule.LunchStart)
        {
            newBehavior = Behaviors.PublicWork;
        }
        else if (time >= Schedule.LunchStart && time < Schedule.WorkEnd)
        {
            newBehavior = Behaviors.Socializing;
        }
        else if (time >= Schedule.WorkEnd && time < Schedule.DinnerStart)
        {
            newBehavior = Behaviors.Idle;
        }
        else if (time >= Schedule.DinnerStart && time < Schedule.Bedtime)
        {
            newBehavior = Behaviors.Socializing;
        }
        else if (IsHungry)
        {
            newBehavior = "Eating";
        }
        else if (IsThirsty)
        {
            newBehavior = "Drinking";
        }
        else if (IsTired)
        {
            newBehavior = "Sleeping";
        }
        else
        {
            newBehavior = "Waiting";
        }

        // Weather-based behavior modification
        if (weather == "Stormy")
        {
            newBehavior = "Seeking Shelter";
        }

        Behavior = newBehavior; // Update behavior
    }

    public void Interact()
    {
        Console.WriteLine($"{Name} says: Hello there!");
    }

    public void OwnProperty(Property property)
    {
        properties.Add(property);
    }

    public void CustomizeProperty(Property property, string customization)
    {
        property.AddCustomization(customization);
        Console.WriteLine($"{Name} has customized {property.Type} at {property.Location}.");
    }
}

public class Property
{
    public string Type { get; }
    public string Location { get; }
    private List<string> customizations = new List<string>();

    public Property(string type, string location)
    {
        Type = type;
        Location = location;
    }

    public void AddCustomization(string customization)
    {
        customizations.Add(customization);
    }
}

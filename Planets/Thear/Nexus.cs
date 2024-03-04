using System;

public class Town
{
    public string Name { get; private set; }
    public Taverne Taverne { get; private set; }

    public Town(string name)
    {
        Name = name;
        Taverne = new Taverne();
    }
}

public class Taverne
{
    public Weather Weather { get; private set; }
    public NPCs NPCs { get; private set; }
    public Mechanics Mechanics { get; private set; }

    public Taverne()
    {
        Weather = new Weather();
        NPCs = new NPCs();
        Mechanics = new Mechanics();
    }
}

public class Weather
{
    public double Rainy { get; private set; }
    public double Snowy { get; private set; }
    public double Stormy { get; private set; }

    public Weather()
    {
        Rainy = 0.1; // Daily probability of rain
        Snowy = 0.05; // Daily probability of snow
        Stormy = 0.025; // Daily probability of storm
    }
}

public class NPCs
{
    public Schedule Schedule { get; private set; }
    public Behaviors Behaviors { get; private set; }

    public NPCs()
    {
        Schedule = new Schedule();
        Behaviors = new Behaviors();
    }
}

public class Schedule
{
    public int WakeUp { get; private set; }
    public int PrivateWorkStart { get; private set; }
    public int PublicWorkStart { get; private set; }
    public int LunchStart { get; private set; }
    public int WorkEnd { get; private set; }
    public int DinnerStart { get; private set; }
    public int Bedtime { get; private set; }

    public Schedule()
    {
        WakeUp = 9; // Time NPCs wake up (in hours)
        PrivateWorkStart = 10; // Time NPCs start working (in hours)
        PublicWorkStart = 12; // Time NPCs start working (in hours)
        LunchStart = 18; // Time NPCs take lunch break (in hours)
        WorkEnd = 20; // Time NPCs finish working (in hours)
        DinnerStart = 21; // Time NPCs have dinner (in hours)
        Bedtime = 30; // Time NPCs go to bed (in hours)
    }
}

public class Behaviors
{
    public string Idle { get; private set; }
    public string PrivateWork { get; private set; }
    public string PublicWork { get; private set; }
    public string Socializing { get; private set; }

    public Behaviors()
    {
        Idle = "Relaxing at the Taverne";
        PrivateWork = "Performing tasks around Home";
        PublicWork = "Performing tasks around Nexus";
        Socializing = "Interacting with other NPCs";
    }
}

public class Mechanics
{
    public double HungerRate { get; private set; }
    public double ThirstRate { get; private set; }
    public double FatigueRate { get; private set; }
    public double RecoveryRate { get; private set; }

    public Mechanics()
    {
        HungerRate = 2; // Rate at which hunger increases (per hour)
        ThirstRate = 2.5; // Rate at which thirst increases (per hour)
        FatigueRate = 1.75; // Rate at which fatigue increases (per hour)
        RecoveryRate = 4; // Rate at which fatigue decreases while asleep (per hour)
    }
}

public static class Program
{
    public static void Main()
    {
        Town Nexus = new Town("Nexus");

        // Example of how NPCs behave based on the time of day
        Console.WriteLine(simulate_NPC_behavior(11));
    }

    public static string simulate_NPC_behavior(int time)
    {
        try
        {
            string behavior = "";
            Schedule schedule = Nexus.Taverne.NPCs.Schedule;
            Behaviors behaviors = Nexus.Taverne.NPCs.Behaviors;

            if (time >= schedule.WakeUp && time < schedule.PrivateWorkStart)
            {
                behavior = behaviors.Idle;
            }
            else if (time >= schedule.PrivateWorkStart && time < schedule.PublicWorkStart)
            {
                behavior = behaviors.PrivateWork;
            }
            else if (time >= schedule.PublicWorkStart && time < schedule.LunchStart)
            {
                behavior = behaviors.PublicWork;
            }
            else if (time >= schedule.LunchStart && time < schedule.WorkEnd)
            {
                behavior = behaviors.Socializing;
            }
            else if (time >= schedule.WorkEnd && time < schedule.DinnerStart)
            {
                behavior = behaviors.Idle;
            }
            else if (time >= schedule.DinnerStart && time < schedule.Bedtime)
            {
                behavior = behaviors.Socializing;
            }
            else
            {
                behavior = "Waiting";
            }
            return behavior;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in simulating NPC behavior: {e.Message}");
            return behavior;
        }
    }
}

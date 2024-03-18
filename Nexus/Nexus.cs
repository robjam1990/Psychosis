using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Nexus
{
    public class Nexus
    {
        public static void Main()
        {
            Biome biome = new Biome("89% Grassland, 11% Desert");
            AddOrganismsFromJson("animals.json");
            AddOrganismsFromJson("animals.json");
            AddOrganismsFromJson("plants.json");
            AddOrganismsFromJson("plants.json");

            SimulateDay();

            // Create a new Town object
            Town nexusTown = new Town("Nexus");

            // Example of how NPCs behave based on the time of day
            Console.WriteLine(SimulateNPCBehavior(nexusTown, 11));
            Console.ReadLine();
        }

        public static void AddOrganismsFromJson(string fileName)
        {
            // Add logic to read and process organisms from JSON file
            Console.WriteLine($"Adding organisms from {fileName}");
        }

        public static string SimulateNPCBehavior(Town town, int time)
        {
            Console.WriteLine("Simulating NPC behavior...");
            string behavior = string.Empty;

            try
            {
                Schedule schedule = town.NPCs.Schedule;
                SimulateNPCBehavior behaviors = town.NPCs.Behaviors;

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
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in simulating NPC behavior: {e.Message}");
                behavior = "Error: Unable to simulate behavior";
            }

            return behavior;
        }

        public static void SimulateDay()
        {
            Console.WriteLine("Simulating a day in Nexus...");
        }
    }

    public class Town
    {
        public List<NPC> NPCs { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Structures { get; set; }
        public string Biome { get; set; }
        public string Weather { get; set; }
        public string Time { get; set; }
        public string Temperature { get; set; }

        public Town(string name)
        {
            NPCs = new List<NPC>();
            Name = name;
        }
    }

    public class NPC
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Type { get; set; }
        public string Behavior { get; set; }
        public string Schedule { get; set; }
        public string Work { get; set; }
        public string Socialize { get; set; }
        public string Sleep { get; set; }
        public string WakeUp { get; set; }
        public string PrivateWorkStart { get; set; }
        public string PublicWorkStart { get; set; }
        public string LunchStart { get; set; }
        public string WorkEnd { get; set; }
        public string DinnerStart { get; set; }
        public string Bedtime { get; set; }

        public NPC(string name, Location location)
        {
            Name = name;
            Location = location;
        }
    }

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class Biome
    {
        public string Name { get; set; }
        public int Temperature { get; set; }
        public int Rainfall { get; set; }

        public Biome(string name)
        {
            Name = name;
        }
    }
}

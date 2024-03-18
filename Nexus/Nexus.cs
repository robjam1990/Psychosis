namespace Nexus
{
    Nexus Biome = new Biome("89% Grassland, 11% Desert");
    AddOrganismsFromJson("animals.json");
    AddOrganismsFromJson("animals.json");
    AddOrganismsFromJson("plants.json");
    AddOrganismsFromJson("plants.json");

    SimulateDay();
{
    // Create a new Town object
    Town Nexus = new Town(string Nexus);

    // Example of how NPCs behave based on the time of day
    Console.WriteLine(SimulateNPCBehavior(Nexus, 11));
        Console.ReadLine(string Behavior);
}

bool SimulateNPCBehavior(Town nexus, int v)
{
    console.WriteLine("Simulating NPC behavior...");
    return true;
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


    public Town(string v)
    {
        NPCs = new List<NPC>();
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

public static class SimulateNPCBehavior
{
    private static Random = new Random();

    public static string SimulateNPCBehavior(Town town, int time)
    {
        foreach (var npc in town.NPCs)
        {
            // Simulate NPC movement to a random location within the town
            int newX = random.Next(0, town.MaxSize);
            int newY = random.Next(0, town.MaxSize);
            int newZ = random.Next(0, town.MaxSize);
            Location newLocation = new Location(newX, newY, newZ);
            npc.Location = newLocation;

            Console.WriteLine($"{time}: {npc.Name} moved to ({newX}, {newY}, {newZ})");

        }
    }

    internal class Schedule
    {
        public static void NPCbehavior(int time)
        {
            try
            {
                Console.WriteLine(string Behavior);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in simulating NPC behavior: {e.Message}");
                behavior = "Error: Unable to simulate behavior";
            }
            try
            {
                Schedule schedule = town.Taverne.NPCs.Schedule;
                SimulateNPCBehavior behaviors = town.Taverne.NPCs.Behaviors;

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
    }
    string jsonData = "[{\"Name\": \"Tropical Rainforest\", \"Temperature\": 25, \"Rainfall\": 2000}, {\"Name\": \"Desert\", \"Temperature\": 35, \"Rainfall\": 100}]";

    List<Biome> biomes = JsonSerializer.Deserialize<List<Biome>>(jsonData);

foreach (var biome in biomes)
{
    Console.WriteLine($"Name: {biome.Name}, Temperature: {biome.Temperature}, Rainfall: {biome.Rainfall}");
}
}
}
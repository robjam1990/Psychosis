using System;
using System.Collections.Generic;
using System.Text.Json;
using static Taverne;

namespace Nexus
{
    public class Nexus
    {
        public static void Main(string[] args)
        {
            QuestManager questManager = new QuestManager();

            Quest barkeepQuest1 = new Quest("Delivery", "The barkeep needs someone to deliver a shipment of ale to a nearby village. Are you up for the task?", "5 Silver coins and the gratitude of the barkeep.");
            Quest barkeepQuest2 = new Quest("Scouting", "The barkeep has heard rumors of strange occurrences in the nearby forest. Can you investigate and report back? [Optional: will pay for Ginger and Barley.]", "10 silver coins for Valuable Information as well as 2 Silver coins per Barley and 3 per Ginger.");
            List<Quest> barkeepQuests = new List<Quest> { barkeepQuest1, barkeepQuest2 };

            NPC barkeep = new NPC("Barkeep", "The barkeep is a stout and friendly figure, always ready with a warm smile and a kind word for patrons. He's the heart and soul of Ye Olde Taverne, keeping spirits high and glasses full.", new int[] { 0, 0, 0 }, barkeepQuests);

            Quest maiaQuest = new Quest("Welcome", "You are Hungry and Thirsty, go see the Barkeep for some Charity.", "Leg of Phesant, Cup of Juice, Half of Bread Loaf, Potatoe.");
            List<Quest> maiaQuests = new List<Quest> { maiaQuest };

            NPC maia = new NPC("Maia", "Maia is a slim and friendly figure, always ready with a warm smile and a kind word for patrons. She's the Lungs of Ye Olde Taverne, bringing in new patrons.", new int[] { 26, -5, 0 }, maiaQuests);

            List<InteractiveElement> interactiveElements = new List<InteractiveElement>
        {
            new InteractiveElement("Barkeep", "The jovial barkeep stands behind the polished bar, ready to serve patrons with a welcoming smile and a quick wit. You can {talk} to him or {order} a drink."),
            new InteractiveElement("Maia", "The capricious greeter stand near the entrance, constantly greeting patrons with a welcoming smile, friendly demeanor and a quick wit. You can {talk} to her."),
            new InteractiveElement("Notice Board", "A notice board hangs on the wall, covered in various parchments and flyers. You can {read} the notices for information on available quests or tasks."),
            new InteractiveElement("Training Area", "In the corner of the taverne, a training area beckons to those seeking to hone their skills. You can {practice} your combat techniques here."),
            new InteractiveElement("Seating", "In the center of the taverne, a seating area for adventurers to connect. You can make friends and be {social} here."),
            new InteractiveElement("Pyre", "Near the entrance, a hearth to keep warm. You can {cook} food here."),
            new InteractiveElement("Latrines", "Just outside the entrance, a public Latrine. You can empty {waste} here."),
            new InteractiveElement("Well", "Outside by the walking path, a working well water source. You can get fresh water here."),
            new InteractiveElement("Back Room", "Reservable for private parties, with a Private Table, Chests and Beds. Speak with the barkeep for more information."),
            new InteractiveElement("Storage", "Scattered all over the Main hall, public barrels, chests and cupboards sit. You can use these to store and take items.")
        };

            Location location = new Location("Ye Olde Taverne", "Taverne.jpg", "You step into the Main hall of Ye Olde Taverne, a warm and inviting establishment nestled in the heart of Nexus. It's a place where weary travelers find respite, adventurers plan their next quests, and locals gather for camaraderie and revelry.", interactiveElements, new List<NPC> { barkeep, maia });
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
        private string v1;
        private string v2;
        private int[] ints;
        private List<Quest> barkeepQuests;

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

        public NPC(string v1, string v2, int[] ints, List<Quest> barkeepQuests)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.ints = ints;
            this.barkeepQuests = barkeepQuests;
        }
    }

    public class Location
    {
        private string v1;
        private string v2;
        private string v3;
        private List<InteractiveElement> interactiveElements;
        private List<NPC> nPCs;

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Location(string v1, string v2, string v3, List<InteractiveElement> interactiveElements, List<NPC> nPCs)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.interactiveElements = interactiveElements;
            this.nPCs = nPCs;
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
using System;
using System.Collections.Generic;

public class QuestManager
{
    public List<Quest> activeQuests = new List<Quest>();
    public List<Quest> completedQuests = new List<Quest>();

    public void StartQuest(Quest quest)
    {
        activeQuests.Add(quest);
        Console.WriteLine($"Quest \"{quest.name}\" started.");
    }

    public void CompleteQuest(Quest quest)
    {
        if (activeQuests.Contains(quest))
        {
            activeQuests.Remove(quest);
            completedQuests.Add(quest);
            Console.WriteLine($"Quest \"{quest.name}\" completed.");
            // Grant rewards and handle quest completion logic
        }
        else
        {
            Console.WriteLine($"Quest \"{quest.name}\" not found.");
        }
    }
}

public class NPC
{
    public string name;
    public string description;
    public int[] location;
    public List<Quest> quests;
    public string behavior;

    public NPC(string name, string description, int[] location, List<Quest> quests)
    {
        this.name = name;
        this.description = description;
        this.location = location;
        this.quests = quests;
        this.behavior = GetRandomBehavior();
    }

    public string GetRandomBehavior()
    {
        string[] behaviors = { "Friendly", "Neutral", "Aggressive" };
        Random rnd = new Random();
        return behaviors[rnd.Next(behaviors.Length)];
    }

    public void Interact()
    {
        switch (behavior)
        {
            case "Friendly":
                Console.WriteLine($"{name} greets you warmly.");
                break;
            case "Neutral":
                Console.WriteLine($"{name} acknowledges your presence.");
                break;
            case "Aggressive":
                Console.WriteLine($"{name} eyes you warily.");
                break;
            default:
                Console.WriteLine($"{name} has an invalid behavior.");
                break;
        }
    }
}

public class Quest
{
    public string name;
    public string description;
    public string reward;

    public Quest(string name, string description, string reward)
    {
        this.name = name;
        this.description = description;
        this.reward = reward;
    }
}

public class Taverne
{

}

public class InteractiveElement
{
    public string name;
    public string description;

    public InteractiveElement(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
}

public class Location
{
    public string name;
    public string image;
    public string description;
    public List<InteractiveElement> interactiveElements;
    public List<NPC> npc;

    public Location(string name, string image, string description, List<InteractiveElement> interactiveElements, List<NPC> npc)
    {
        this.name = name;
        this.image = image;
        this.description = description;
        this.interactiveElements = interactiveElements;
        this.npc = npc;
    }

    public void ReadNoticeBoard()
    {
        Console.WriteLine("You approach the notice board and scan the various notices pinned to it, looking for...");
        // Code to display available quests or tasks
        Console.WriteLine("Decree: Messages directly from the jurisdictional commanding Royal Family");
        Console.WriteLine("Notice: Messages from the establishment");
        Console.WriteLine("Bounty: Messages from NPCs");
        Console.WriteLine("Request: Messages from Humans");
        Console.WriteLine("Write: Write a message");
    }

    public void PracticeCombat()
    {
        Console.WriteLine("You spend some time practicing your combat skills in the training area, honing your techniques for future battles.");
        // Code to simulate combat practice
        Console.WriteLine("Exercise: Choose an Exercise");
        Console.WriteLine("Time: Choose a Duration Goal");
        Console.WriteLine("Companion: Choose a Sparring Companion");
        Console.WriteLine("Trainer: Choose your trainer");
    }
}

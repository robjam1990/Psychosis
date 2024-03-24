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

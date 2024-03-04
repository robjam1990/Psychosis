using System;
using System.Collections.Generic;

public class Character
{
    public string Name { get; set; }
    public int Gold { get; set; }
    public Dictionary<string, int> Relations { get; set; } = new Dictionary<string, int>();
    public List<Character> HireableCharacters { get; set; } = new List<Character>();
    public List<Soldier> Army { get; set; } = new List<Soldier>();
    public int Price { get; set; }
    public Dictionary<string, int> Traits { get; set; } = new Dictionary<string, int>();
    public Dictionary<string, int> Skills { get; set; } = new Dictionary<string, int>();

    public Character(string name, Dictionary<string, int> traits = null)
    {
        Name = name;
        Gold = 0;
        Traits = traits ?? new Dictionary<string, int>();
    }

    public void Hire(Character character, int hiringCost)
    {
        if (Gold >= hiringCost && Relations.GetValueOrDefault(character.Name, 0) >= CharacterConstants.FRIEND)
        {
            Gold -= hiringCost;
            HireableCharacters.Add(character);
            Console.WriteLine($"{character.Name} hired as a friend!");
        }
        else
        {
            Console.WriteLine("Unable to hire this character.");
        }
    }

    public void SellYourself(int price)
    {
        Price = price;
        Console.WriteLine($"{Name} is now available for hire at a price of {price} gold.");
    }

    public bool Buy(Character character)
    {
        if (Gold >= character.Price)
        {
            Gold -= character.Price;
            Console.WriteLine($"{Name} has hired {character.Name} for {character.Price} gold.");
            return true;
        }
        else
        {
            Console.WriteLine($"Not enough gold to hire {character.Name}.");
            return false;
        }
    }

    public void SetRelation(Character character, int value)
    {
        Relations[character.Name] = value;
    }

    public void InteractWith(Character character)
    {
        Random rand = new Random();
        int interaction = rand.Next(0, 101); // Random interaction value
        int relationChange = interaction - 50; // Change in relation based on interaction
        Relations[character.Name] += relationChange;
        Console.WriteLine($"{Name} interacts with {character.Name}. Relation change: {relationChange}");
    }

    public void RaiseArmy(int numberOfSoldiers)
    {
        for (int i = 0; i < numberOfSoldiers; i++)
        {
            Soldier soldier = new Soldier();
            soldier.ChooseEquipment(); // Choose equipment for the soldier
            Army.Add(soldier);
        }
    }

    // Add a method to delegate tasks to hired characters
    public void DelegateTask(string task, Character hiredCharacter)
    {
        Console.WriteLine($"{Name} delegates {task} to {hiredCharacter.Name}.");
        // Implement task delegation logic here
    }
}

public static class CharacterConstants
{
    public const int FRIEND = 63;
}

public class Soldier
{
    public void ChooseEquipment()
    {
        Console.WriteLine("Choosing equipment for the soldier...");
    }
}

public class Game
{
    public Character Player { get; set; }

    public Game(string playerName)
    {
        Player = new Character(playerName, new Dictionary<string, int> { { "leadership", 50 } }); // Example: Player has leadership skill
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine($"Player: {Player.Name}");
        // You can add more initialization logic here
        // For example:
        // Player.RaiseArmy(5); // Raise an army with 5 soldiers
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a new game instance
        Game game = new Game("PlayerName");
        game.Start();

        // Test the new functionality
        Character player = game.Player;
        Character npc = new Character("NPC", new Dictionary<string, int> { { "diplomacy", 70 } }); // Example: NPC has diplomacy trait
        player.InteractWith(npc); // Simulate interaction between player and NPC
        Console.WriteLine($"Player's relations with NPC: {player.Relations.GetValueOrDefault(npc.Name, 0)}"); // Check relation change

        // Example usage of delegation
        player.DelegateTask("scouting", hiredCharacter);
    }
}

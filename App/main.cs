using System;
using System.IO;
using System.Text.Json;

// Enums
public enum Aim
{
    Dyslexic = 0,
    Horrible = 1,
    Poor = 2,
    Fair = 3,
    Good = 4,
    Great = 5,
    Excellent = 6,
    Perfect = 7
}

public enum LimbStatus
{
    Usable = 0,
    Bruised = 1,
    Dislocated = 2,
    Fractured = 3,
    Broken = 4,
    Unusable = 5,
    Removed = 6
}

// Class for Object Durability
public class ObjectDurability
{
    public int durabilityPoints;
    public int maxDurability;

    public ObjectDurability(int maxDurability)
    {
        this.durabilityPoints = maxDurability;
        this.maxDurability = maxDurability;
    }

    public void Degrade(int amount)
    {
        durabilityPoints -= amount;
        if (durabilityPoints < 0)
        {
            durabilityPoints = 0;
        }
    }
}

// Class for Combatant
public class Combatant
{
    public string name;
    public int health;
    public bool conscious;
    public Aim attackerAim;
    public ObjectDurability weaponDurability;
    public LimbStatus rightArmStatus;
    public LimbStatus leftArmStatus;
    public LimbStatus rightLegStatus;
    public LimbStatus leftLegStatus;
    public int experience;
    public int level;
    public int damageBonus;
    public int defenseBonus;

    public Combatant(string name, int health, int weaponDurability)
    {
        this.name = name;
        this.health = health;
        this.conscious = true;
        this.attackerAim = Aim.Good;
        this.weaponDurability = new ObjectDurability(weaponDurability);
        this.rightArmStatus = LimbStatus.Usable;
        this.leftArmStatus = LimbStatus.Usable;
        this.rightLegStatus = LimbStatus.Usable;
        this.leftLegStatus = LimbStatus.Usable;
        this.experience = 0;
        this.level = 1;
        this.damageBonus = 0;
        this.defenseBonus = 0;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            conscious = false;
        }
    }

    public void GainExperience(int experience)
    {
        this.experience += experience;
        if (this.experience >= 100)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level += 1;
        experience = 0;
        health += 10;
        damageBonus += 5;
        defenseBonus += 3;
        Console.WriteLine($"{name} has leveled up to level {level}!");
    }

    // Method to simulate limb removal
    public void RemoveLimb(string limb)
    {
        if (limb == "rightArm")
        {
            rightArmStatus = LimbStatus.Removed;
        }
        else if (limb == "leftArm")
        {
            leftArmStatus = LimbStatus.Removed;
        }
        else if (limb == "rightLeg")
        {
            rightLegStatus = LimbStatus.Removed;
        }
        else if (limb == "leftLeg")
        {
            leftLegStatus = LimbStatus.Removed;
        }
    }
}

// Game class to manage game state
public static class Game
{
    public static Combatant player;

    // Function to save game state to a JSON file
    public static void SaveGame()
    {
        string gameJSON = JsonSerializer.Serialize(player);
        File.WriteAllText("savedGame.json", gameJSON);
        Console.WriteLine("Game saved: " + gameJSON);
    }

    // Function to load game state from a JSON file
    public static void LoadGame()
    {
        try
        {
            string gameJSON = File.ReadAllText("savedGame.json");
            player = JsonSerializer.Deserialize<Combatant>(gameJSON);
            Console.WriteLine("Game loaded: " + gameJSON);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No saved game found.");
        }
    }

    // Function to initialize a new game state
    public static void InitializeGame()
    {
        Console.Write("Enter your character's name: ");
        string playerName = Console.ReadLine();
        player = new Combatant(playerName, 100, 10);
    }
}

// Main class for the game
public class MainGame
{
    // Main game loop
    public static void Main()
    {
        Console.WriteLine("Welcome to Psychosis!");
        Console.WriteLine("You find yourself in a mysterious world.");

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Character");
            Console.WriteLine("4. Observe");
            Console.WriteLine("5. Explore");
            Console.WriteLine("6. Fight");
            Console.WriteLine("7. Save Game");
            Console.WriteLine("8. Options");
            Console.WriteLine("9. Quit");

            Console.Write("Choose an action (1-9): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Game.InitializeGame();
                    break;
                case "2":
                    Game.LoadGame();
                    break;
                case "3":
                    ViewCharacter();
                    break;
                case "4":
                    ObserveEnvironment();
                    break;
                case "5":
                    Explore();
                    break;
                case "6":
                    Fight();
                    break;
                case "7":
                    Game.SaveGame();
                    break;
                case "8":
                    OpenOptions();
                    break;
                case "9":
                    Console.WriteLine("Thanks for playing! Goodbye.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }

    // Placeholder methods for game actions
    public static void ViewCharacter()
    {
        Console.WriteLine("Viewing character...");
    }

    public static void ObserveEnvironment()
    {
        Console.WriteLine("Observing environment...");
    }

    public static void Explore()
    {
        Console.WriteLine("Exploring...");
    }

    public static void Fight()
    {
        Console.WriteLine("Fighting...");
    }

    public static void OpenOptions()
    {
        Console.WriteLine("Opening options...");
    }
}

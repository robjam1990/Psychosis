using System;

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
    public int DurabilityPoints { get; private set; }
    public int MaxDurability { get; private set; }

    public ObjectDurability(int maxDurability)
    {
        DurabilityPoints = maxDurability;
        MaxDurability = maxDurability;
    }

    public void Degrade(int amount)
    {
        DurabilityPoints -= amount;
        if (DurabilityPoints < 0)
        {
            DurabilityPoints = 0;
        }
    }
}

// Class for Combatant
public class Combatant
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public bool Conscious { get; private set; }
    public Aim AttackerAim { get; private set; }
    public ObjectDurability WeaponDurability { get; private set; }
    public LimbStatus RightArmStatus { get; private set; }
    public LimbStatus LeftArmStatus { get; private set; }
    public LimbStatus RightLegStatus { get; private set; }
    public LimbStatus LeftLegStatus { get; private set; }
    public int Experience { get; private set; }
    public int Level { get; private set; }
    public int DamageBonus { get; private set; }
    public int DefenseBonus { get; private set; }

    public Combatant(string name, int health, int weaponDurability)
    {
        Name = name;
        Health = health;
        Conscious = true;
        AttackerAim = Aim.Good;
        WeaponDurability = new ObjectDurability(weaponDurability);
        RightArmStatus = LimbStatus.Usable;
        LeftArmStatus = LimbStatus.Usable;
        RightLegStatus = LimbStatus.Usable;
        LeftLegStatus = LimbStatus.Usable;
        Experience = 0;
        Level = 1;
        DamageBonus = 0;
        DefenseBonus = 0;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            Conscious = false;
        }
    }

    public void GainExperience(int experience)
    {
        Experience += experience;
        if (Experience >= 100)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        Experience = 0;
        Health += 10;
        DamageBonus += 5;
        DefenseBonus += 3;
        Console.WriteLine($"{Name} has leveled up to level {Level}!");
    }

    // Method to simulate limb removal
    public void RemoveLimb(string limb)
    {
        switch (limb)
        {
            case "rightArm":
                RightArmStatus = LimbStatus.Removed;
                break;
            case "leftArm":
                LeftArmStatus = LimbStatus.Removed;
                break;
            case "rightLeg":
                RightLegStatus = LimbStatus.Removed;
                break;
            case "leftLeg":
                LeftLegStatus = LimbStatus.Removed;
                break;
            default:
                break;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Usage example:
        // Create a combatant
        Combatant player = new Combatant("Player", 100, 50);

        // Simulate taking damage
        player.TakeDamage(20);
        Console.WriteLine(player.Health);  // Output: 80

        // Gain experience
        player.GainExperience(50);
        Console.WriteLine(player.Level);  // Output: 1 (since experience < 100)

        player.GainExperience(60);
        Console.WriteLine(player.Level);  // Output: 2 (since experience >= 100, level up occurred)
    }
}

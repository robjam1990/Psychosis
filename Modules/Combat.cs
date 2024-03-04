using System;

// Enums
public enum Tactic
{
    Default,
    Custom,
    Panic,
    Defensive,
    Aggressive,
    Combo
}

// Class for Combat System
public class CombatSystem
{
    public CombatSystem() { }

    public void Initiate(Character attacker, Character defender, Tactic tactic)
    {
        switch (tactic)
        {
            case Tactic.Custom:
                Attack(attacker, defender);
                break;
            case Tactic.Panic:
                HandlePanic(defender);
                break;
            case Tactic.Defensive:
                DefensiveAttack(attacker, defender);
                break;
            case Tactic.Aggressive:
                AggressiveAttack(attacker, defender);
                break;
            case Tactic.Combo:
                ComboAttack(attacker, defender);
                break;
            default:
                break;
        }
    }

    public void Attack(Character attacker, Character defender)
    {
        Console.WriteLine($"{attacker.Name} attacks {defender.Name}.");
        Random rand = new Random();
        int baseDamage = rand.Next(10, 21); // Random base damage between 10 and 20
        int totalDamage = baseDamage + attacker.DamageBonus; // Add attacker's damage bonus
        defender.TakeDamage(totalDamage);
        Console.WriteLine($"{defender.Name} takes {totalDamage} damage. Current health: {defender.Health}");

        // Additional logic for gaining experience upon successful attack
        attacker.GainExperience(20); // Example: Gain 20 experience points per successful attack
    }

    // Defensive tactic: Focus on blocking and counter-attacks
    public void DefensiveAttack(Character attacker, Character defender)
    {
        Console.WriteLine($"{attacker.Name} takes a defensive stance.");
        // Add logic here for defensive actions such as blocking or counter-attacks
    }

    // Aggressive tactic: Focus on overwhelming the opponent with relentless attacks
    public void AggressiveAttack(Character attacker, Character defender)
    {
        Console.WriteLine($"{attacker.Name} goes on the offensive!");
        // Add logic here for aggressive attacks, possibly with increased damage but higher risk
    }

    // Combo tactic: Execute a series of coordinated attacks for increased damage
    public void ComboAttack(Character attacker, Character defender)
    {
        Console.WriteLine($"{attacker.Name} unleashes a devastating combo!");
        // Add logic here for executing combo attacks, possibly requiring specific conditions to trigger
    }

    public void HandlePanic(Character combatant)
    {
        if (combatant.Health < 35)
        {
            Console.WriteLine($"{combatant.Name} is panicking!");
            combatant.Conscious = false;
        }
    }
}

// Example Character class
public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int DamageBonus { get; set; }
    public bool Conscious { get; set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void GainExperience(int experience)
    {
        // Logic for gaining experience
    }
}

// Example usage:
// CombatSystem combatSystem = new CombatSystem();
// Tactic tactic = Tactic.Custom;
// Character attacker = new Character();
// Character defender = new Character();
// combatSystem.Initiate(attacker, defender, tactic);

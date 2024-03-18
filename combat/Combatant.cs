/*
In the world of Psychosis, where adventure awaits in the vast expanses of Thear, your journey begins amidst the intricate tapestry of the Main Hall of Nexus Tavern, nestled within the bustling town of Nexus, Bractalia. Here, amidst the clinking of tankards and murmurs of patrons, your tale unfurls with boundless possibilities.
As you venture forth, prepare to navigate a fully explorable solar system, where round planets beckon exploration and discovery. Engage in tactical combat, where each move is pivotal, utilizing a limb removal system that adds depth and strategy to every encounter.
But it's not just combat that shapes your journey; immerse yourself in an ecosystem simulation where animal communication hints at the secrets of the wild. Beyond mere survival, aspire to greatness as you raise a nation to power, navigating the complexities of multi-faction warfare while managing logistics, agriculture, commerce, and succession.
Within the social fabric of Thear, navigate a bounty system that tests your mettle and reputation. Forge alliances, create hierarchies, or challenge rivals as you navigate a spectrum of loyalty, fear, respect, and morality, all under the jurisdiction of a dynamic justice system tied to territorial borders.
Time flows seamlessly, marked by day/night cycles and shifting seasons, as you engage in the construction, repair, and destruction of structures, shaping entire villages according to your will. Decide the fate of prisoners, wield influence over named locations and objects, and commandeer the aid of others to build armies or delegate tasks.
Supply and demand drive a barter system fueled by an expansive array of renewable and non-renewable resources, while an in-depth crafting system, intertwined with metallurgy, allows for the creation of powerful artifacts and tools essential for survival.
Survival itself is a challenge, with oxygen, temperature, disease, hunger, energy, sanity, hygiene, and waste all factors to consider. Grow and evolve your character through a comprehensive system of advancement and learning, utilizing futuristic customization options and genetic manipulation to craft unique personas suited to your playstyle.
In Psychosis, every choice matters, every action shapes your destiny.Embark on an odyssey through Thear, where the boundaries of reality blur, and the possibilities are as infinite as the cosmos itself.
Psychosis
A text-based game set in the world of Thear.
Copyright 2017-2024 robjam1990
@license MIT
*/
using static Combat.CombatSystem;

class combatSystem
{
    static void Main(string[] args)
    {
        // Usage example:
        // Create a combatant
        Combat.Character player = new Combat.Character();
        player.Name = "Player";
        player.Health = 100;
        player.DamageBonus = 50;

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
namespace Combat
{
    public partial class Program
    {
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
                int experienceThreshold = 100;
                int levelUpBonus = 10;

                // Logic for gaining experience
                Experience += experience;
                if (Experience >= experienceThreshold)
                {
                    int levelIncrease = Experience / experienceThreshold;
                    Level += levelIncrease;
                    Experience %= experienceThreshold;
                    DamageBonus += levelIncrease * levelUpBonus;
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
            void HandlePanic(Character combatant)
            {
                if (combatant.Health < 35)
                {
                    Console.WriteLine($"{combatant.Name} is panicking!");
                    combatant.Conscious = false;
                }
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
    }
}
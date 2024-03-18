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

namespace Combat
{
    // Enums
    public enum Tactic
    {
        Default,
        Custom,
        Flee,
        Panic,
        Passive,
        Conservative,
        Defensive,
        Aggressive,
        Combo
    }

    // Class for Combat System
    public class CombatSystem
    {
        // Properties for Combat System
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public int DamageBonus { get; private set; }


        public CombatSystem()
        {
            Experience = 0;
            Level = 1;
            DamageBonus = 0;

            void Combat(Character attacker, Character defender, Tactic tactic)
            {
                switch (tactic)
                {
                    case Tactic.Default:
                        DefaultAttack(attacker, defender);
                        break;
                    case Tactic.Custom:
                        CustomAttack(attacker, defender);
                        break;
                    case Tactic.Flee:
                        Console.WriteLine($"{attacker.Name} flees from the battle with {defender.Name}!");
                        break;
                    case Tactic.Panic:
                        Console.WriteLine($"{attacker.Name} panics and loses control against {defender.Name}!");
                        break;
                    case Tactic.Passive:
                        Console.WriteLine($"{attacker.Name} takes a passive stance against {defender.Name}.");
                        break;
                    case Tactic.Conservative:
                        Console.WriteLine($"{attacker.Name} takes a conservative stance against {defender.Name}.");
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


            void DefaultAttack(Character attacker, Character defender)
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
            void CustomAttack(Character attacker, Character defender)
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
            void Flee(Character attacker, Character defender)
            {
                Console.WriteLine($"{attacker.Name} flees from the battle!");
                // Add logic here for fleeing from the battle
            }
            void Panic(Character attacker, Character defender)
            {
                Console.WriteLine($"{attacker.Name} panics and loses control!");
                // Add logic here for panicking and losing control
            }
            void Passive(Character attacker, Character defender)
            {
                Console.WriteLine($"{attacker.Name} takes a passive stance.");
                // Add logic here for passive actions such as evading or dodging
            }
            void Conservative(Character attacker, Character defender)
            {
                Console.WriteLine($"{attacker.Name} takes a conservative stance.");
                // Add logic here for conservative actions such as minimizing risk and focusing on defense
            }

            // Defensive tactic: Focus on blocking and counter-attacks
            void DefensiveAttack(Character attacker, Character defender)
            {
                Console.WriteLine($"{attacker.Name} takes a defensive stance.");
                // Add logic here for defensive actions such as blocking or counter-attacks
            }

            // Aggressive tactic: Focus on overwhelming the opponent with relentless attacks
            void AggressiveAttack(Character attacker, Character defender)
            {
                Console.WriteLine($"{attacker.Name} goes on the offensive!");
                // Add logic here for aggressive attacks, possibly with increased damage but higher risk
            }

            // Combo tactic: Execute a series of coordinated attacks for increased damage
            void ComboAttack(Character attacker, Character defender)
            {
                Console.WriteLine($"{attacker.Name} unleashes a devastating combo!");
                // Add logic here for executing combo attacks, possibly requiring specific conditions to trigger
            }


        }
    }
    // Example Character class
    public class Character
    {
        public string Name { get; set; } = ""; // Providing a default value
        public string Description { get; set; } = ""; // Providing a default value
        public int Health { get; set; } // Example: 10 by default
        public int DamageBonus { get; set; } // Example: 0 by default
        public bool Conscious { get; set; } // Example: true by default
        public int Experience { get; set; } // Example: 0 by default
        public int Level { get; set; } // Example: Level 1 by default

        // Constructor with explicit setting of Name
        public Character()

        {
            Name = Name;
        }


        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Conscious = false;
            }
            if (Health <= 35)
            {
                Console.WriteLine($"{Name} is panicking!");
                Conscious = true;
            }
            else if (Health > 85)
            {
                Console.WriteLine(Console.ReadLine() + $"{Name} is going berzerk!");
                Console.WriteLine($"{Name} is conscious.");
            }
        }

        public void GainExperience(int experience)
        {
            const int experienceThreshold = 100;
            const int levelUpBonus = 10;

            // Ensure that the experience gained is non-negative
            if (experience < 0)
            {
                throw new ArgumentException("Experience gained must be non-negative.");
            }

            // Logic for gaining experience
            Experience += experience;

            while (Experience >= experienceThreshold)
            {
                Level++;
                Experience -= experienceThreshold;
                DamageBonus += levelUpBonus;
            }
        }
    }
}

    
/*
Example usage:
CombatSystem combatSystem = new CombatSystem();
Tactic tactic = Tactic.Custom;
Character attacker = new Character();
Character defender = new Character();
combatSystem.Initiate(attacker, defender, tactic);
*/
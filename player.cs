// Player created and maintained by AI in C# for a text-based game called Psychosis.
using System;
using System.Collections.Generic;

namespace Psychosis
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public Position Position { get; set; }
        public Dictionary<string, int> Resources { get; set; }
        public Dictionary<string, int> Skills { get; set; }
        public string Faction { get; set; }
        public int Loyalty { get; set; }
        public int Fear { get; set; }
        public int Respect { get; set; }
        public int Morality { get; set; }
        public int Score { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Quest> ActiveQuests { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            Inventory = new List<InventoryItem>();
            Position = new Position(0, 0);
            Resources = new Dictionary<string, int>();
            Skills = new Dictionary<string, int>();
            Faction = "Neutral";
            Loyalty = 50;
            Fear = 20;
            Respect = 30;
            Morality = 50;
            Score = 0;
            Enemies = new List<Enemy>();
            Weapons = new List<Weapon>();
            ActiveQuests = new List<Quest>();
            InventoryItems = new List<InventoryItem>();
        }
        public class Character
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public int Experience { get; set; }
            public Dictionary<string, int> Skills { get; set; }
            public Character(string name)
            {
                Name = name;
                Level = 1;
                Experience = 0;
                Skills = new Dictionary<string, int>();
            }
            public void AddExperience(int amount)
            {
                Experience += amount;
                if (Experience >= Level * 100)
                {
                    LevelUp();
                }
            }
            private void LevelUp()
            {
                Level++;
                Experience = 0;
                Console.WriteLine($"Congratulations, {Name}! You are now level {Level}!");
            }
            public void Move(int x, int y)
            {
                Position.X += x;
                Position.Y += y;
            }

            public void AddResource(string resource, int quantity)
            {
                if (Resources.ContainsKey(resource))
                {
                    Resources[resource] += quantity;
                }
                else
                {
                    Resources.Add(resource, quantity);
                }
            }

            public void RemoveResource(string resource, int quantity)
            {
                if (Resources.ContainsKey(resource))
                {
                    Resources[resource] -= quantity;
                    if (Resources[resource] <= 0)
                    {
                        Resources.Remove(resource);
                    }
                }
            }

            public void IncreaseSkill(string skill, int amount)
            {
                if (Skills.ContainsKey(skill))
                {
                    Skills[skill] += amount;
                }
                else
                {
                    Skills.Add(skill, amount);
                }
            }

            public void DecreaseSkill(string skill, int amount)
            {
                if (Skills.ContainsKey(skill))
                {
                    Skills[skill] -= amount;
                    if (Skills[skill] <= 0)
                    {
                        Skills.Remove(skill);
                    }
                }
            }
            public void Attack(Enemy enemy, Weapon weapon)
            {
                int damage = weapon.Damage;
                enemy.TakeDamage(damage);
            }

            public void UseItem(InventoryItem item)
            {
                // Add item usage logic here
                if (item.Name == "Health Potion")
                {
                    // Increase player's health by a certain amount
                    Health += 50;
                    Console.WriteLine("Player's health increased by 50.");
                }
                else if (item.Name == "Attack Boost")
                {
                    // Increase player's attack damage by a certain amount
                    foreach (Weapon weapon in Weapons)
                    {
                        weapon.Damage += 10;
                    }
                    Console.WriteLine("Player's attack damage increased by 10.");
                }
                else
                {
                    Console.WriteLine("Item cannot be used.");
                }
            }
            public void StartQuest(Quest quest)
            {
                ActiveQuests.Add(quest);
            }

            public void AbandonQuest(Quest quest)
            {
                ActiveQuests.Remove(quest);
            }
            public void CompleteQuest(Quest quest)
            {
                quest.CompleteQuest();
                ActiveQuests.Remove(quest);
            }
            public void RemoveQuest(Quest quest)
            {
                ActiveQuests.Remove(quest);
            }
            public void AddEnemy(Enemy enemy)
            {
                Enemies.Add(enemy);
            }

            public void RemoveEnemy(Enemy enemy)
            {
                Enemies.Remove(enemy);
            }

            public void AddWeapon(Weapon weapon)
            {
                Weapons.Add(weapon);
            }

            public void RemoveWeapon(Weapon weapon)
            {
                Weapons.Remove(weapon);
            }

            public void AddInventoryItem(InventoryItem item)
            {
                InventoryItems.Add(item);
            }

            public void RemoveInventoryItem(InventoryItem item)
            {
                InventoryItems.Remove(item);
            }
            public void UseSkill(string skill)
            {
                if (Skills.ContainsKey(skill))
                {
                    // Implement logic to use the skill
                    Console.WriteLine($"Using skill: {skill}");
                }
                else
                {
                    Console.WriteLine($"Skill not found: {skill}");
                }
            }
            public void TakeDamage(int damage)
            {
                Health -= damage;
                if (Health <= 0)
                {
                    Console.WriteLine("Player has been defeated!");
                }
            }
            public void DecreaseScore(int points)
            {
                Score -= points;
            }
            public void IncreaseScore(int points)
            {
                Score += points;
            }
        }

        public class InventoryItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string Description { get; set; }

            public InventoryItem(string name, int quantity = 1, string description = "")
            {
                Name = name;
                Quantity = quantity;
                Description = description;
            }
            public override string ToString()
            {
                return $"Player: {Name}, Health: {Health}, Position: ({Position.X}, {Position.Y}), Score: {Score}";
            }
        }
    }
}

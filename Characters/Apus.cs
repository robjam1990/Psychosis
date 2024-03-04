using System;

namespace Psychosis.Gameplay.Characters
{
    public class Character
    {
        public string Name { get; }
        public string Gender { get; }
        public int Age { get; }
        public double[] Size { get; }
        public Pigment Pigment { get; }
        public string Odor { get; }
        public Occupation Occupation { get; }
        public Attributes Attributes { get; }
        public SkillTree SkillTree { get; }
        public Traits Traits { get; }
        public Inventory Inventory { get; }
        public Reputation Reputation { get; }
        public Relationships Relationships { get; }

        public Character(string name, string gender, Pigment pigment = null, string odor = null, Occupation occupation = null)
        {
            Name = name;
            Gender = gender;
            Pigment = pigment ?? new Pigment(255, 0, 0);
            Odor = odor ?? "bit sequence";
            Occupation = occupation ?? new Occupation("Queen");

            Age = CalculateAge(DateTime.Now);
            Size = new double[] { 1, 1, 3 };

            Attributes = new Attributes
            {
                StrengthPower = 8,
                EnduranceStamina = 9,
                SpeedAgility = 7,
                PerceptionRecognition = 9,
                IntelligenceLogistics = 9,
                KnowledgeMemory = 9,
                ExperienceWisdom = 9,
                WillDetermination = 9,
                PatiencePoise = 6,
                FlexibilityElasticity = 7,
                BalanceDexterity = 8
            };

            SkillTree = new SkillTree { Observation = 1 };

            Traits = new Traits
            {
                Physical = new PhysicalTraits(),
                Social = new SocialTraits(),
                Emotional = new EmotionalTraits(),
                Behavioral = new BehavioralTraits(),
                Intellectual = new IntellectualTraits()
            };

            Inventory = new Inventory
            {
                Gold = 10130,
                Silver = 9876120,
                Equipped = new EquippedItems
                {
                    Head = "",
                    Shoulders = "",
                    Chest = "Rugged Linen Shirt (.5lbs) {Durability: 50%}",
                    Arms = "",
                    Waist = "Rugged Cotton Belt (.5lbs) {Durability: 50%}",
                    Legs = "Rugged Linen Pants (.5lbs) {Durability: 50%}",
                    Feet = "Rugged Rubber Boots (.5lbs) {Durability: 50%}",
                    RightHand = "",
                    LeftHand = ""
                },
                Bag = new Bag { ItemWeight = "" }
            };

            Reputation = new Reputation { Fame = 99, Notoriety = -99 };

            Relationships = new Relationships
            {
                Allies = new string[] { "Barkeep", "Opus" },
                Enemies = new string[] { },
                Loyalty = 50,
                Fear = 1,
                Respect = 99,
                Morality = 0.71 // 1 = "Pure Good", 0 = "Pure Evil"
            };
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
                age--;
            return age;
        }
    }

    public class Pigment
    {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public Pigment(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }

    public class Occupation
    {
        public string Name { get; }

        public Occupation(string name)
        {
            Name = name;
        }
    }

    public class Attributes
    {
        public int StrengthPower { get; set; }
        public int EnduranceStamina { get; set; }
        public int SpeedAgility { get; set; }
        public int PerceptionRecognition { get; set; }
        public int IntelligenceLogistics { get; set; }
        public int KnowledgeMemory { get; set; }
        public int ExperienceWisdom { get; set; }
        public int WillDetermination { get; set; }
        public int PatiencePoise { get; set; }
        public int FlexibilityElasticity { get; set; }
        public int BalanceDexterity { get; set; }
    }

    public class SkillTree
    {
        public int Observation { get; set; }
    }

    public class Traits
    {
        public PhysicalTraits Physical { get; set; }
        public SocialTraits Social { get; set; }
        public EmotionalTraits Emotional { get; set; }
        public BehavioralTraits Behavioral { get; set; }
        public IntellectualTraits Intellectual { get; set; }
    }

    public class PhysicalTraits
    {
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Aggression { get; set; }
        public int Health { get; set; }
        public int Appeal { get; set; }
    }

    public class SocialTraits
    {
        public int Humility { get; set; }
        public int Temperament { get; set; }
        public int Generosity { get; set; }
        public int Loyalty { get; set; }
        public int Honesty { get; set; }
    }

    public class EmotionalTraits
    {
        public int Spontaneity { get; set; }
        public int Mannerism { get; set; }
        public int Rage { get; set; }
    }

    public class BehavioralTraits
    {
        public int Curiosity { get; set; }
        public int Dependency { get; set; }
        public int Confidence { get; set; }
        public int Ambition { get; set; }
    }

    public class IntellectualTraits
    {
        public int Creativity { get; set; }
        public int Concentration { get; set; }
        public int Intelligence { get; set; }
    }

    public class Inventory
    {
        public int Gold { get; set; }
        public int Silver { get; set; }
        public EquippedItems Equipped { get; set; }
        public Bag Bag { get; set; }
    }

    public class EquippedItems
    {
        public string Head { get; set; }
        public string Shoulders { get; set; }
        public string Chest { get; set; }
        public string Arms { get; set; }
        public string Waist { get; set; }
        public string Legs { get; set; }
        public string Feet { get; set; }
        public string RightHand { get; set; }
        public string LeftHand { get; set; }
    }

    public class Bag
    {
        public string ItemWeight { get; set; }
    }

    public class Reputation
    {
        public int Fame { get; set; }
        public int Notoriety { get; set; }
    }

    public class Relationships
    {
        public string[] Allies { get; set; }
        public string[] Enemies { get; set; }
        public int Loyalty { get; set; }
        public int Fear { get; set; }
        public int Respect { get; set; }
        public double Morality { get; set; } // 1 = "Pure Good", 0 = "Pure Evil"
    }
}

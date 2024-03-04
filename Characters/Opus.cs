using System;

namespace Psychosis.Gameplay.Characters
{
    public class Character
    {
        public dynamic identification;
        public dynamic attributes;
        public dynamic skillTree;
        public dynamic traits;
        public string occupation;
        public dynamic inventory;
        public dynamic reputation;
        public dynamic relationships;

        public Character(string name, string gender, dynamic pigment, string odor, string occupation)
        {
            identification = new
            {
                name = "Opus",
                gender = "Male",
                age = 0,
                size = new[] { 1, 1, 3 },
                pigment = pigment ?? new { red = 255, green = 0, blue = 0 },
                odor = odor ?? "bit sequence"
            };
            attributes = new
            {
                Strength_Power = 6,
                Endurance_Stamina = 6,
                Speed_Agility = 6,
                Perception_Recognition = 10,
                Intelligence_Logistics = 10,
                Knowledge_Memory = 10,
                Experience_Wisdom = 10,
                Will_Determination = 6,
                Patience_Poise = 6,
                Flexibility_Elasticity = 6,
                Balance_Dexterity = 6
            };
            skillTree = new { Observation = 1 };
            traits = new
            {
                physical = new { strength = 0, speed = 0, aggression = 0, health = 0, appeal = 0 },
                social = new { humility = 0, temperament = 0, generosity = 0, loyalty = 0, honesty = 0 },
                Emotional = new { Spontaneity = 0, Mannerism = 0, Rage = 0 },
                Behavioral = new { Curiosity = 0, Dependency = 0, Confidence = 0, Ambition = 0 },
                Intellectual = new { Creativity = 0, Concentration = 0, Intelligence = 0 }
            };
            this.occupation = "Oracle";
            inventory = new
            {
                gold = 30,
                silver = 120,
                equipped = new
                {
                    Head = "",
                    Shoulders = "",
                    Chest = "Rugged Linen Shirt (.5lbs){Durability: 50%}",
                    Arms = "",
                    Waist = "Rugged Cotton Belt (.5lbs){Durability: 50%}",
                    Legs = "Rugged Linen Pants (.5lbs){Durability: 50%}",
                    Feet = "Rugged Rubber Boots (.5lbs){Durability: 50%}",
                    RightHand = "",
                    LeftHand = ""
                },
                bag = new { Item_Weight = "" }
            };

            // Set the birthdate as the current date
            identification.birthdate = DateTime.Now;
            // Calculate the age based on the current date
            identification.age = CalculateAge(identification.birthdate);

            reputation = new { fame = 65, notoriety = -99 };

            relationships = new { allies = new[] { "Barkeep", "Apus", "Ark" }, enemies = new string[] { }, loyalty = 15, fear = 55, respect = 35, morality = 0.91 }; // 1 = "Pure Good", 0 = "Pure Evil"
        }

        // Function to calculate the character's age based on the provided birthdate
        private int CalculateAge(DateTime birthdate)
        {
            var now = DateTime.Now;
            var age = now.Year - birthdate.Year - ((now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day)) ? 1 : 0);
            return age;
        }
    }

    public static class Program
    {
        // Function to create a new character instance with user input
        public static Character CreateCharacter()
        {
            Console.Write("Enter character name: ");
            var name = Console.ReadLine() ?? "";
            Console.Write("Enter character gender: ");
            var gender = Console.ReadLine() ?? "";
            Console.Write("Enter red pigment (0-255): ");
            var red = int.TryParse(Console.ReadLine(), out int redValue) ? redValue : 255;
            Console.Write("Enter green pigment (0-255): ");
            var green = int.TryParse(Console.ReadLine(), out int greenValue) ? greenValue : 0;
            Console.Write("Enter blue pigment (0-255): ");
            var blue = int.TryParse(Console.ReadLine(), out int blueValue) ? blueValue : 0;
            var pigment = new { red, green, blue };
            Console.Write("Enter odor (bit sequence): ");
            var odor = Console.ReadLine() ?? "0000000000000000";
            Console.Write("Enter character occupation: ");
            var occupation = Console.ReadLine() ?? "";
            return new Character(name, gender, pigment, odor, occupation);
        }

        public static void Main(string[] args)
        {
            var myCharacter = CreateCharacter();
            Console.WriteLine(myCharacter);
        }
    }
}

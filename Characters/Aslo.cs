using System;

// Define the character Aslo
public class Aslo
{
    public string Name = "Aslo";
    public string Characteristics = "{(o) - [+i]}";
    public string Occupation = "Bard";
    public string Salary = "(1 Silver) * Hour";
    public string Location = "Taverne: Main Hall (Between the counter and the Back Room)";
    public string Employer = "Barkeep";
    public bool EmployerBenefits = true;
    public string[] Benefits = new string[] { "Food", "Private Access for resting" };
    public string Bed = "Nexus: Mercenary Camp (Bedroll)";

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
                name = name,
                gender = "Male",
                age = 0,
                size = new int[] { 1, 1, 3 },
                pigment = pigment ?? new { red = 255, green = 0, blue = 0 },
                odor = odor ?? "bit sequence"
            };

            attributes = new
            {
                Strength_Power = 1,
                Endurance_Stamina = 5,
                Speed_Agility = 3,
                Perception_Recognition = 7,
                Intelligence_Logistics = 2,
                Knowledge_Memory = 6,
                Experience_Wisdom = 2,
                Will_Determination = 4,
                Patience_Poise = 9,
                Flexibility_Elasticity = 1,
                Balance_Dexterity = 3
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

            this.occupation = occupation;

            inventory = new
            {
                gold = 1,
                silver = 430,
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

            reputation = new { fame = 13, notoriety = 0 };

            relationships = new { allies = new string[] { "Barkeep", "Maia" }, enemies = new string[] { }, loyalty = 74, fear = 34, respect = 87, morality = 0.61 }; // 1 = "Pure Good", 0 = "Pure Evil"
        }

        // Function to calculate the character's age based on the provided birthdate
        public int CalculateAge(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;

            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }

            return age;
        }
    }

    // Function to create a new character instance with user input
    public static Character CreateCharacter()
    {
        Console.Write("Enter character name: ");
        string name = Console.ReadLine();
        Console.Write("Enter character gender: ");
        string gender = Console.ReadLine();
        Console.Write("Enter red pigment (0-255): ");
        int red = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter green pigment (0-255): ");
        int green = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter blue pigment (0-255): ");
        int blue = Convert.ToInt32(Console.ReadLine());
        dynamic pigment = new { red, green, blue };
        Console.Write("Enter odor (bit sequence): ");
        string odor = Console.ReadLine();
        Console.Write("Enter character occupation: ");
        string occupation = Console.ReadLine();

        return new Character(name, gender, pigment, odor, occupation);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Aslo.Character myCharacter = Aslo.CreateCharacter();
        Console.WriteLine(myCharacter);
    }
}

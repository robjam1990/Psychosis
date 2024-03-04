using System;

// Define the character Barkeep
public class Barkeep
{
    public string Name { get; set; } = "Barkeep";
    public string[] Characteristics { get; set; } = new string[] { "(i').{'o}" };
    public string Occupation { get; set; } = "Barkeep";
    public string Salary { get; set; } = "Supply and Demand Production / Barter";
    public string Location { get; set; } = "Taverne: Main Hall (Behind the counter)";
    public object Employer { get; set; } = null;
    public bool EmployerBenefits { get; set; } = false;
    public object Benefits { get; set; } = null;
    public string Bed { get; set; } = "Nexus: Taverne (Bedroom)";
}

// Define the Character class
public class Character
{
    public dynamic identification { get; set; }
    public dynamic attributes { get; set; }
    public dynamic skillTree { get; set; }
    public dynamic traits { get; set; }
    public string occupation { get; set; }
    public dynamic inventory { get; set; }
    public dynamic reputation { get; set; }
    public dynamic relationships { get; set; }

    public Character(string name, int age, string gender = "Male", dynamic pigment = null, string odor = "bit sequence")
    {
        identification = new
        {
            name = name ?? "",
            gender = gender,
            age = age,
            size = new { x = 1, y = 1, z = 3 },
            pigment = pigment ?? new { red = 255, green = 0, blue = 0 },
            odor = odor
        };
        attributes = new
        {
            Strength_Power = 1,
            Endurance_Stamina = 9,
            Speed_Agility = 1,
            Perception_Recognition = 4,
            Intelligence_Logistics = 3,
            Knowledge_Memory = 6,
            Experience_Wisdom = 8,
            Will_Determination = 6,
            Patience_Poise = 6,
            Flexibility_Elasticity = 1,
            Balance_Dexterity = 7
        };
        skillTree = new { Observation = 1 };
        traits = new
        {
            physical = new { strength = 0, speed = 0, aggression = 0, health = 0, appeal = 0 },
            social = new { humility = 1, temperament = 0, generosity = 0, loyalty = 0, honesty = 0 },
            Emotional = new { Spontaneity = 0, Mannerism = 0, Rage = 0 },
            Behavioral = new { Curiosity = 0, Dependency = 0, Confidence = 0, Ambition = 0 },
            Intellectual = new { Creativity = 0, Concentration = 0, Intelligence = 0 }
        };
        occupation = "Barkeep";
        inventory = new
        {
            gold = 1084,
            silver = 20185,
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

        identification.birthdate = DateTime.Now;
        identification.age = CalculateAge(identification.birthdate);
        reputation = new { fame = 99, notoriety = 0 };
        relationships = new { allies = new object[] { }, enemies = new object[] { }, loyalty = 51, fear = 21, respect = 99, morality = 0.81 };
    }

    private int CalculateAge(DateTime birthdate)
    {
        var now = DateTime.Now;
        int age = now.Year - birthdate.Year;
        if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
        {
            age--;
        }
        return age;
    }
}

// Example usage:
// var character = new Character("Barkeep", 30);

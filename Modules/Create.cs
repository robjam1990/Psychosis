using System;

public class Character
{
    public string Name { get; }
    public string Gender { get; }
    public int Age { get; private set; }
    public int Size { get; } = 3;
    public Pigment Pigment { get; }
    public string Odor { get; }
    public string Occupation { get; }
    public Attributes Attributes { get; } = new Attributes();
    public SkillTree SkillTree { get; } = new SkillTree();
    public Traits Traits { get; } = new Traits();
    public Inventory Inventory { get; } = new Inventory();
    public DateTime Birthdate { get; }
    public Reputation Reputation { get; } = new Reputation();
    public Relationships Relationships { get; } = new Relationships();

    public Character(string name, string gender, Pigment pigment, string odor, string occupation)
    {
        Name = name;
        Gender = gender;
        Pigment = pigment ?? new Pigment(255, 0, 0);
        Odor = odor ?? "bit sequence";
        Occupation = occupation ?? "Adventurer";

        Birthdate = DateTime.Now;
        Age = CalculateAge(Birthdate);
    }

    private int CalculateAge(DateTime birthdate)
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

public class Attributes
{
    public int StrengthPower { get; } = 1;
    public int EnduranceStamina { get; } = 1;
    public int SpeedAgility { get; } = 1;
    public int PerceptionRecognition { get; } = 1;
    public int IntelligenceLogistics { get; } = 1;
    public int KnowledgeMemory { get; } = 1;
    public int ExperienceWisdom { get; } = 1;
    public int WillDetermination { get; } = 1;
    public int PatiencePoise { get; } = 1;
    public int FlexibilityElasticity { get; } = 1;
    public int BalanceDexterity { get; } = 1;
}

public class SkillTree
{
    public int Observation { get; } = 1;
}

public class Traits
{
    public PhysicalTraits Physical { get; } = new PhysicalTraits();
    public SocialTraits Social { get; } = new SocialTraits();
    public EmotionalTraits Emotional { get; } = new EmotionalTraits();
    public BehavioralTraits Behavioral { get; } = new BehavioralTraits();
    public IntellectualTraits Intellectual { get; } = new IntellectualTraits();
}

public class PhysicalTraits
{
    public int Strength { get; } = 0;
    public int Speed { get; } = 0;
    public int Aggression { get; } = 0;
    public int Health { get; } = 0;
    public int Appeal { get; } = 0;
}

public class SocialTraits
{
    public int Humility { get; } = 0;
    public int Temperament { get; } = 0;
    public int Generosity { get; } = 0;
    public int Loyalty { get; } = 0;
    public int Honesty { get; } = 0;
}

public class EmotionalTraits
{
    public int Spontaneity { get; } = 0;
    public int Mannerism { get; } = 0;
    public int Rage { get; } = 0;
}

public class BehavioralTraits
{
    public int Curiosity { get; } = 0;
    public int Dependency { get; } = 0;
    public int Confidence { get; } = 0;
    public int Ambition { get; } = 0;
}

public class IntellectualTraits
{
    public int Creativity { get; } = 0;
    public int Concentration { get; } = 0;
    public int Intelligence { get; } = 0;
}

public class Inventory
{
    public int Gold { get; }
    public int Silver { get; }
    public Equipped Equipped { get; } = new Equipped();
    public Bag Bag { get; } = new Bag();

    public Inventory()
    {
        // Initialize gold and silver to 0
    }
}

public class Equipped
{
    public string Head { get; set; } = "";
    public string Shoulders { get; set; } = "";
    public string Chest { get; set; } = "Rugged Linen Shirt (.5lbs){Durability: 50%}";
    public string Arms { get; set; } = "";
    public string Waist { get; set; } = "Rugged Cotton Belt (.5lbs){Durability: 50%}";
    public string Legs { get; set; } = "Rugged Linen Pants (.5lbs){Durability: 50%}";
    public string Feet { get; set; } = "Rugged Rubber Boots (.5lbs){Durability: 50%}";
    public string RightHand { get; set; } = "";
    public string LeftHand { get; set; } = "";
}

public class Bag
{
    public string ItemWeight { get; } = "";
}

public class Reputation
{
    public int Fame { get; } = 0;
    public int Notoriety { get; } = 0;
}

public class Relationships
{
    public string[] Allies { get; } = { };
    public string[] Enemies { get; } = { };
    public int Loyalty { get; } = 50;
    public int Fear { get; } = 50;
    public int Respect { get; } = 50;
    public double Morality { get; } = 0.51; // 1 = "Pure Good", 0 = "Pure Evil"
}

class Program
{
    static void Main(string[] args)
    {
        Character myCharacter = CreateCharacter();
        Console.WriteLine($"Name: {myCharacter.Name}, Age: {myCharacter.Age}");
    }

    static Character CreateCharacter()
    {
        Console.Write("Enter character name:");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter character gender:");
        string gender = Console.ReadLine() ?? "";
        Console.Write("Enter red pigment (0-255):");
        int red = int.TryParse(Console.ReadLine(), out int redValue) ? redValue : 255;
        Console.Write("Enter green pigment (0-255):");
        int green = int.TryParse(Console.ReadLine(), out int greenValue) ? greenValue : 0;
        Console.Write("Enter blue pigment (0-255):");
        int blue = int.TryParse(Console.ReadLine(), out int blueValue) ? blueValue : 0;
        Pigment pigment = new Pigment(red, green, blue);
        Console.Write("Enter odor (bit sequence):");
        string odor = Console.ReadLine() ?? "0000000000000000";
        Console.Write("Enter character occupation:");
        string occupation = Console.ReadLine() ?? "";
        return new Character(name, gender, pigment, odor, occupation);
    }
}

using System;

namespace Psychosis.Gameplay.Characters
{
    public class Character
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public Tuple<int, int, int> Size { get; set; }
        public Tuple<int, int, int> Pigment { get; set; }
        public string Odor { get; set; }
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
        public int Observation { get; set; }
        public int PhysicalStrength { get; set; }
        public int PhysicalSpeed { get; set; }
        public int PhysicalAggression { get; set; }
        public int PhysicalHealth { get; set; }
        public int PhysicalAppeal { get; set; }
        public int SocialHumility { get; set; }
        public int SocialTemperament { get; set; }
        public int SocialGenerosity { get; set; }
        public int SocialLoyalty { get; set; }
        public int SocialHonesty { get; set; }
        public int EmotionalSpontaneity { get; set; }
        public int EmotionalMannerism { get; set; }
        public int EmotionalRage { get; set; }
        public int BehavioralCuriosity { get; set; }
        public int BehavioralDependency { get; set; }
        public int BehavioralConfidence { get; set; }
        public int BehavioralAmbition { get; set; }
        public int IntellectualCreativity { get; set; }
        public int IntellectualConcentration { get; set; }
        public int IntellectualIntelligence { get; set; }
        public string Occupation { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public string Head { get; set; }
        public string Shoulders { get; set; }
        public string Chest { get; set; }
        public string Arms { get; set; }
        public string Waist { get; set; }
        public string Legs { get; set; }
        public string Feet { get; set; }
        public string RightHand { get; set; }
        public string LeftHand { get; set; }
        public DateTime Birthdate { get; set; }
        public int Fame { get; set; }
        public int Notoriety { get; set; }
        public string[] Allies { get; set; }
        public string[] Enemies { get; set; }
        public int Loyalty { get; set; }
        public int Fear { get; set; }
        public int Respect { get; set; }
        public double Morality { get; set; }

        public Character(string name, string gender, Tuple<int, int, int> pigment, string odor, string occupation)
        {
            Name = name;
            Gender = gender;
            Size = new Tuple<int, int, int>(1, 1, 3);
            Pigment = pigment ?? new Tuple<int, int, int>(255, 0, 0);
            Odor = odor ?? "bit sequence";
            StrengthPower = 1;
            EnduranceStamina = 1;
            SpeedAgility = 1;
            PerceptionRecognition = 2;
            IntelligenceLogistics = 1;
            KnowledgeMemory = 1;
            ExperienceWisdom = 1;
            WillDetermination = 6;
            PatiencePoise = 6;
            FlexibilityElasticity = 1;
            BalanceDexterity = 1;
            Observation = 1;
            PhysicalStrength = 0;
            PhysicalSpeed = 0;
            PhysicalAggression = 0;
            PhysicalHealth = 0;
            PhysicalAppeal = 0;
            SocialHumility = 1;
            SocialTemperament = 0;
            SocialGenerosity = 0;
            SocialLoyalty = 0;
            SocialHonesty = 0;
            EmotionalSpontaneity = 0;
            EmotionalMannerism = 0;
            EmotionalRage = 0;
            BehavioralCuriosity = 0;
            BehavioralDependency = 0;
            BehavioralConfidence = 0;
            BehavioralAmbition = 0;
            IntellectualCreativity = 0;
            IntellectualConcentration = 0;
            IntellectualIntelligence = 0;
            Occupation = occupation;
            Gold = 10;
            Silver = 200;
            Chest = "Rugged Linen Shirt (.5lbs){Durability: 50%}";
            Waist = "Rugged Cotton Belt (.5lbs){Durability: 50%}";
            Legs = "Rugged Linen Pants (.5lbs){Durability: 50%}";
            Feet = "Rugged Rubber Boots (.5lbs){Durability: 50%}";
            Birthdate = DateTime.Now;
            Fame = 3;
            Notoriety = 0;
            Allies = new string[] { "Barkeep", "Ark" };
            Enemies = new string[] { };
            Loyalty = 73;
            Fear = 43;
            Respect = 83;
            Morality = 0.51;
        }

        public int CalculateAge(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
                age--;
            return age;
        }
    }

    public class Aithaluwa
    {
        public string Name { get; set; } = "Aithaluwa";
        public string Characteristics { get; set; } = "R{ D[G\"N'A'\"] }";
        public string Occupation { get; set; } = "Adventurer";
        public string Salary { get; set; } = "Supply and Demand Production / Barter";
        public string Location { get; set; } = "Taverne: Main Hall (seated at the table between the counter and the training area)";
        public object Employer { get; set; } = null;
        public string Bed { get; set; } = "Nexus: Taverne (Private Room)";

        public Aithaluwa()
        {
            Employer = new { benefits = false };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var aithaluwa = new Aithaluwa();
            Console.WriteLine("Aithaluwa:");
            Console.WriteLine($"Name: {aithaluwa.Name}");
            Console.WriteLine($"Characteristics: {aithaluwa.Characteristics}");
            Console.WriteLine($"Occupation: {aithaluwa.Occupation}");
            Console.WriteLine($"Salary: {aithaluwa.Salary}");
            Console.WriteLine($"Location: {aithaluwa.Location}");
            Console.WriteLine($"Employer benefits: {(aithaluwa.Employer != null ? aithaluwa.Employer.benefits : "None")}");
            Console.WriteLine($"Bed: {aithaluwa.Bed}");

            var myCharacter = new Character("Aithaluwa", "Male", new Tuple<int, int, int>(255, 0, 0), "0000000000000000", "Adventurer");
            Console.WriteLine("\nMy Character:");
            Console.WriteLine($"Name: {myCharacter.Name}");
            Console.WriteLine($"Age: {myCharacter.CalculateAge(myCharacter.Birthdate)}");
        }
    }
}

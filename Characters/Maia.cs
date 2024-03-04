using System;

public class Character
{
    public string Name { get; set; }
    public string Characteristics { get; set; }
    public string Occupation { get; set; }
    public string Salary { get; set; }
    public string Location { get; set; }
    public string Employer { get; set; }
    public bool EmployerBenefits { get; set; }
    public string[] Benefits { get; set; }
    public string Bed { get; set; }

    public Character(string name, string characteristics, string occupation, string salary, string location, string employer, bool employerBenefits, string[] benefits, string bed)
    {
        Name = name;
        Characteristics = characteristics;
        Occupation = occupation;
        Salary = salary;
        Location = location;
        Employer = employer;
        EmployerBenefits = employerBenefits;
        Benefits = benefits;
        Bed = bed;
    }
}

public class Maia : Character
{
    public Maia() : base(
        name: "Maia",
        characteristics: "(o)+{-}[i]",
        occupation: "Barmaid",
        salary: "(5 Silver) * Hour",
        location: "Taverne: Main Hall (Between the Pyre and the Front door)",
        employer: "Barkeep",
        employerBenefits: true,
        benefits: new string[] { "Food", "Private Access for resting" },
        bed: "Nexus: Temple (Small Cot)")
    {
    }

    public override string ToString()
    {
        return $"Name: {Name}, Occupation: {Occupation}, Location: {Location}";
    }
}

class Program
{
    static Character CreateCharacter()
    {
        Console.Write("Enter character name:");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter character characteristics:");
        string characteristics = Console.ReadLine() ?? "";

        Console.Write("Enter character occupation:");
        string occupation = Console.ReadLine() ?? "";

        Console.Write("Enter character salary:");
        string salary = Console.ReadLine() ?? "";

        Console.Write("Enter character location:");
        string location = Console.ReadLine() ?? "";

        Console.Write("Enter character employer:");
        string employer = Console.ReadLine() ?? "";

        Console.Write("Does the character receive benefits from the employer? (True/False):");
        bool employerBenefits = Console.ReadLine()?.ToLower() == "true";

        Console.Write("Enter character benefits (separate by comma if multiple):");
        string[] benefits = Console.ReadLine()?.Split(',') ?? new string[] { };

        Console.Write("Enter character bed location:");
        string bed = Console.ReadLine() ?? "";

        return new Character(name, characteristics, occupation, salary, location, employer, employerBenefits, benefits, bed);
    }

    static void Main(string[] args)
    {
        Maia maia = new Maia();
        Console.WriteLine(maia);

        Character myCharacter = CreateCharacter();
        foreach (var prop in myCharacter.GetType().GetProperties())
        {
            Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(myCharacter, null));
        }
    }
}

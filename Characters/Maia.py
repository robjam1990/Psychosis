import datetime

class Character:
    def __init__(self, name, characteristics, occupation, salary, location, employer, employer_benefits, benefits, bed):
        self.Name = name
        self.Characteristics = characteristics
        self.Occupation = occupation
        self.Salary = salary
        self.Location = location
        self.Employer = employer
        self.EmployerBenefits = employer_benefits
        self.Benefits = benefits
        self.Bed = bed

class Maia(Character):
    def __init__(self):
        super().__init__(
            name="Maia",
            characteristics="(o)+{-}[i]",
            occupation="Barmaid",
            salary="(5 Silver) * Hour",
            location="Taverne: Main Hall (Between the Pyre and the Front door)",
            employer="Barkeep",
            employer_benefits=True,
            benefits=["Food", "Private Access for resting"],
            bed="Nexus: Temple (Small Cot)"
        )

    def __str__(self):
        return f"Name: {self.Name}, Occupation: {self.Occupation}, Location: {self.Location}"

# Function to create a new character instance with user input
def create_character():
    name = input("Enter character name:") or ""
    characteristics = input("Enter character characteristics:") or ""
    occupation = input("Enter character occupation:") or ""
    salary = input("Enter character salary:") or ""
    location = input("Enter character location:") or ""
    employer = input("Enter character employer:") or ""
    employer_benefits = input("Does the character receive benefits from the employer? (True/False):").lower() == "true"
    benefits = input("Enter character benefits (separate by comma if multiple):").split(",") or []
    bed = input("Enter character bed location:") or ""
    return Character(name, characteristics, occupation, salary, location, employer, employer_benefits, benefits, bed)

# Sample usage
maia = Maia()
print(maia)
my_character = create_character()
print(my_character.__dict__)

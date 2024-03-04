using System;

class Mercenary
{
    private Character character;

    public Mercenary(Character character)
    {
        this.character = character;
    }

    public void VisitTavern()
    {
        // Logic for the mercenary visiting the tavern
        Console.WriteLine($"{character.Name} the mercenary enters the tavern.");
    }

    // Other methods specific to the Mercenary class
}

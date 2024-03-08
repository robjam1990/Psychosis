using System.Diagnostics;
using System.Reflection;

public class DialogueManager
{
    private NameGenerator nameGenerator;
    private DialogueGenerator dialogueGenerator;

    public DialogueManager(NameGenerator nameGenerator, DialogueGenerator dialogueGenerator)
    {
        this.nameGenerator = nameGenerator;
        this.dialogueGenerator = dialogueGenerator;
    }

    public string GetCharacterName(Binder gender, Trace race)
    {
        return nameGenerator.GetRandomName(gender, race);
    }

    public string GenerateGreeting(string characterName)
    {
        return dialogueGenerator.GenerateGreeting(characterName);
    }

    internal string GetCharacterName(object male, object human)
    {
        throw new NotImplementedException();
    }

    internal string GetCharacterName(string Gender, string Race)
    {
        throw new NotImplementedException();
    }

    // Add more methods as needed for other dialogue interactions
}

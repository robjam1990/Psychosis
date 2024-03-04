// File = robjam1990/Psychosis/Gameplay/System/Observation.cs

using System.Collections.Generic;

public static class Identification
{
    public static void Identify(object ID)
    {
        if (ID == null)
        {
            // Request input from player to introduce themselves
            Send.Request("ID", new Dictionary<string, object>
            {
                { "request", "Input" },
                { "Output", "Question" },
                { "Input", "Answer" }
            });

            // If player responds, create observation
            if (Answer != null && (Answer == "*me*" || Answer == "*i*"))
            {
                Observation.Create(ID);
            }
        }
    }
}

public static class Recording
{
    public static void Record(string objectName, Dictionary<string, object> properties)
    {
        // Record the observation
        Encylopedia[objectName] = properties;
    }

    public static void ConfigureProperties(Dictionary<string, string[]> config)
    {
        // Update properties configuration
        Observation.PropertiesConfig = config;
    }
}

public static class Recognition
{
    public static void Recognize(string objectName)
    {
        if (!Encylopedia.ContainsKey(objectName))
        {
            // If object is not recognized, record it as new
            Recording.Record(objectName, Observation.PropertiesConfig);
        }
    }
}

public static class Comparison
{
    public static void Compare(object object1, object object2)
    {
        double difference = CalculateDifference(object1, object2);
        // Assign a value to the difference and check higher value
        // Add your comparison logic here
    }

    private static double CalculateDifference(object object1, object object2)
    {
        // Implement your logic to calculate the difference
        return 0.0;
    }
}

// Example of dynamic property configuration
Dictionary<string, string[]> updatedConfig = new Dictionary<string, string[]>
{
    { "Visual", new string[] { "Size", "Shape", "Pigment", "Luminosity" } },
    { "Audio", new string[] { "Volume", "Pitch", "Bass" } },
    { "Touch", new string[] { "Elasticity", "Density", "Temperature" } },
    { "Odor", new string[] { "Strength", "Appeal" } },
    { "Taste", new string[] { "Texture", "Chemical" } }
    // Add or remove properties as needed
};

Recording.ConfigureProperties(updatedConfig);

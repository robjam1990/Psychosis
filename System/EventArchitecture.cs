using System;
using System.Collections.Generic;

public class EventTarget
{
    // Placeholder for EventTarget functionality
}

public class Observation
{
    private static EventTarget eventEmitter = new EventTarget();
    private static Dictionary<string, Dictionary<string, object>> encyclopedia = new Dictionary<string, Dictionary<string, object>>();

    public static void Record(string observationName, Dictionary<string, object> actionProperties, object participant)
    {
        if (observationName.GetType() != typeof(string) || actionProperties == null || actionProperties.GetType() != typeof(Dictionary<string, object>))
        {
            Console.WriteLine("Invalid input parameters for recording observation.");
            return;
        }

        try
        {
            encyclopedia[observationName] = actionProperties;
            Dictionary<string, object> observationEvent = new Dictionary<string, object>()
            {
                { "observationName", observationName },
                { "actionProperties", actionProperties }
            };
            eventEmitter.DispatchEvent("observation", observationEvent);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error recording observation: " + e.Message);
        }
    }
}

public static class EventExtensions
{
    public static void DispatchEvent(this EventTarget target, string eventType, Dictionary<string, object> eventData)
    {
        // Implement dispatching event functionality
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        // Define handleObservationEvent function
        Action<Dictionary<string, object>> handleObservationEvent = (eventData) =>
        {
            string observationName = (string)eventData["observationName"];
            Dictionary<string, object> actionProperties = (Dictionary<string, object>)eventData["actionProperties"];
            Console.WriteLine($"New observation recorded: {observationName}");
            foreach (var entry in actionProperties)
            {
                Console.WriteLine($" - {entry.Key}: {entry.Value}");
            }
        };

        // Add listener for the 'observation' event
        Observation.eventEmitter.AddEventListener("observation", handleObservationEvent);
    }
}

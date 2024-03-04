using System;
using System.Collections.Generic;

// File: Psychosis/Gameplay/System/ObservationPluginSystem.cs

public class Observation
{
    private List<object> plugins;

    public Observation()
    {
        plugins = new List<object>();
    }

    public void Record(string observationName, object properties, object participant)
    {
        // Record the observation
        // "Encyclopedia" is an existing object where observations are stored
        Encyclopedia[observationName] = properties;
    }

    public void AddPlugin(object plugin)
    {
        // Add plugin to the list
        plugins.Add(plugin);
    }

    public void TriggerPlugins(string eventName, object data)
    {
        // Trigger plugins
        foreach (var plugin in plugins)
        {
            try
            {
                var method = plugin.GetType().GetMethod(eventName);
                if (method != null)
                {
                    method.Invoke(plugin, new object[] { data });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing plugin for event '{eventName}': {ex.Message}");
            }
        }
    }
}

// Example usage of plugin system
public class CustomPlugin
{
    public void Record(object data)
    {
        // Implement custom observation recording logic here
        Console.WriteLine("Custom plugin: New observation recorded " + data.ToString());
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the Observation class
        Observation observation = new Observation();

        // Add the custom plugin to the Observation system
        CustomPlugin customPlugin = new CustomPlugin();
        observation.AddPlugin(customPlugin);

        // Trigger custom observation event
        object eventData = new object(); // Assuming eventData is defined somewhere
        observation.TriggerPlugins("CUSTOM_OBSERVATION", eventData);
    }
}

using System;
using System.Collections.Generic;

namespace Psychosis.Gameplay.System
{
    public class ActionSystem
    {
        public Dictionary<string, Action> Actions { get; private set; }

        public ActionSystem()
        {
            Actions = new Dictionary<string, Action>();

            // Default action when no specific action is taken
            Actions.Add("defaultAction", new Action("Waiting", "unchanged", "Rest in current location."));

            // Basic Actions
            Actions.Add("Observe", new Action("Unchanged", "Observe an Action in current location.", "Actions ++"));
            Actions.Add("Waiting", new Action("unchanged", "Rest in current location.", "Patience ++"));
            Actions.Add("Gather", new Action("changed", "Forage for food in specified location.", "Food ++"));
            Actions.Add("Sleep", new Action("unchanged", "Sleep in current location.", "Energy ++"));
            Actions.Add("Consume", new Action("unchanged", "Consume food and drink in current location.", "Hunger -- || Thirst -- || Energy ++"));
            Actions.Add("Work", new Action("changed", "Perform job in specified location.", "Silver Coin ++"));

            // Speed modifiers for different movement actions
            Actions.Add("Speed", new Action("Speed modifiers", "Speed modifiers for different movement actions."));
            Actions["Speed"].Properties.Add("Crawl", 0.25);
            Actions["Speed"].Properties.Add("Sneak", 0.5); // Speed factor for sneaking
            Actions["Speed"].Properties.Add("Swimming", 0.75);
            Actions["Speed"].Properties.Add("Walk", 1); // Speed factor for walking
            Actions["Speed"].Properties.Add("Jog", 1.5);
            Actions["Speed"].Properties.Add("Run", 2); // Speed factor for running
            Actions["Speed"].Properties.Add("Gallop", 3);
            Actions["Speed"].Properties.Add("Teleport", -1);
        }

        // Function to create a new action with specified location and customizable properties
        public void AddAction(string actionName, string location, string properties = "")
        {
            Actions.Add(actionName, new Action(location, properties));
        }

        // Function to check if an action exists
        public bool ActionExists(string actionName)
        {
            return Actions.ContainsKey(actionName);
        }

        // Function to get the properties of a specific action
        public string GetProperties(string actionName)
        {
            if (Actions.ContainsKey(actionName))
            {
                return Actions[actionName].Properties;
            }
            else
            {
                throw new KeyNotFoundException("Action not found");
            }
        }

        // Function to save action data for persistence
        public void SaveActionData()
        {
            // Example implementation: Save action data to local storage or a database
            // Here, we'll just print out the action data
            foreach (var action in Actions)
            {
                Console.WriteLine($"Action: {action.Key}, Location: {action.Value.Location}, Properties: {action.Value.Properties}");
            }
        }

        // Function to load action data for persistence
        public void LoadActionData()
        {
            // Example implementation: Load action data from local storage or a database
            // Here, we'll just print a message
            Console.WriteLine("Loading action data...");
        }
    }

    public class Action
    {
        public string Location { get; private set; }
        public string Description { get; private set; }
        public string Properties { get; set; }

        public Action(string location, string description, string properties = "")
        {
            Location = location;
            Description = description;
            Properties = properties;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ActionSystem actionSystem = new ActionSystem();

            // Example usage:
            actionSystem.AddAction("Attack", "enemyLocation", "damage: 10, cooldown: 3");
            actionSystem.SaveActionData();
            Console.WriteLine(actionSystem.GetProperties("Attack")); // Output: damage: 10, cooldown: 3
        }
    }
}

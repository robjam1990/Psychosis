using System;
using System.Collections.Generic;
using System.Threading;

namespace Psychosis.Gameplay.Planets.Thear
{
    public class Thear
    {
        public Dictionary<string, dynamic> Time { get; set; }
        public Dictionary<string, dynamic> Bractalia { get; set; }

        public Thear()
        {
            Time = new Dictionary<string, dynamic>
            {
                { "Year", 360 }, // Days
                { "Seasons", 4 }, // Spring, Summer, Autumn, Winter
                { "Months", 30 }, // Days
                { "Weeks", 5 }, // Days
                { "Day", 36 }, // Hours
                { "Daytime", 18 }, // Hours
                { "Nighttime", 18 }, // Hours
                { "GameTimeToRealTimeRatio", new List<string> { "4:1" } } // 1 hour (in-game) equals 15 minutes (real-time)
            };

            Bractalia = new Dictionary<string, dynamic>
            {
                {
                    "Nexus", new Dictionary<string, dynamic>
                    {
                        {
                            "Taverne", new Dictionary<string, dynamic>
                            {
                                {
                                    "Weather", new Dictionary<string, dynamic>
                                    {
                                        { "Rainy", 0.1 }, // Daily probability of rain
                                        { "Snowy", 0.05 }, // Daily probability of snow
                                        { "Stormy", 0.025 } // Daily probability of storm
                                    }
                                },
                                {
                                    "NPCs", new Dictionary<string, dynamic>
                                    {
                                        {
                                            "Schedule", new Dictionary<string, dynamic>
                                            {
                                                { "WakeUp", 9 }, // Time NPCs wake up (in hours)
                                                { "PrivateWorkStart", 10 }, // Time NPCs start working (in hours)
                                                { "PublicWorkStart", 12 }, // Time NPCs start working (in hours)
                                                { "LunchStart", 18 }, // Time NPCs take lunch break (in hours)
                                                { "WorkEnd", 20 }, // Time NPCs finish working (in hours)
                                                { "DinnerStart", 21 }, // Time NPCs have dinner (in hours)
                                                { "Bedtime", 30 } // Time NPCs go to bed (in hours)
                                            }
                                        },
                                        {
                                            "Behaviors", new Dictionary<string, string>
                                            {
                                                { "Idle", "Relaxing at the Taverne" },
                                                { "PrivateWork", "Performing tasks around Home" },
                                                { "PublicWork", "Performing tasks around Nexus" },
                                                { "Socializing", "Interacting with other NPCs" }
                                            }
                                        }
                                    }
                                },
                                {
                                    "Mechanics", new Dictionary<string, double>
                                    {
                                        { "HungerRate", 2 }, // Rate at which hunger increases (per hour)
                                        { "ThirstRate", 2.5 }, // Rate at which thirst increases (per hour)
                                        { "FatigueRate", 1.75 }, // Rate at which fatigue increases (per hour)
                                        { "RecoveryRate", 4 } // Rate at which fatigue decreases while asleep (per hour)
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }

    public class Quest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Quest(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }

    public class Game
    {
        private static void Main(string[] args)
        {
            var thear = new Thear();

            // Example of optimization: Caching frequently accessed properties
            var taverneTime = thear.Bractalia["Nexus"]["Taverne"]["Weather"];
            var taverneNPCs = thear.Bractalia["Nexus"]["Taverne"]["NPCs"];
            var taverneMechanics = thear.Bractalia["Nexus"]["Taverne"]["Mechanics"];

            // Example of adding new quests to the game
            var newQuest = new Quest("Retrieve the Lost Artifact", "Embark on a journey to retrieve the ancient artifact lost in the depths of the forest.");

            // Example of how time progresses in the game
            ProgressTime(thear);
        }

        public static void ProgressTime(Thear thear)
        {
            var day = thear.Time["Day"];
            var gameToRealTimeRatio = double.Parse(thear.Time["GameTimeToRealTimeRatio"][0]);
            var realTimeIncrement = 1.0 / gameToRealTimeRatio; // Increment in real-time (minutes)
            var inGameTime = 0.0; // Initialize in-game time (hours)

            while (true)
            {
                inGameTime += realTimeIncrement;

                // Convert real-time to in-game time
                if (inGameTime >= 60)
                {
                    inGameTime -= 60;
                }

                Console.WriteLine($"Current in-game time: {Math.Floor(inGameTime)}:00");
                // Other simulations can be called here
                Thread.Sleep((int)(day * 60 * 1000)); // Convert day to minutes and set interval in milliseconds
            }
        }
    }
}

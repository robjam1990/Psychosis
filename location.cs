// "Location, Map, and related classes created and maintained by AI in C# for a text-based game called Psychosis."
using System;
using System.Collections.Generic;
using System.Linq;

namespace Psychosis
{
    public class Location
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Dictionary<string, int> Resources { get; set; }
        public Dictionary<string, int> Skills { get; set; }
        public Position Position { get; set; }
        public static List<Location> Locations { get; set; } = new List<Location>();


        /// <summary>
        /// Initializes the game locations by setting up map-specific locations such as towns, shops, and quest destinations.
        /// </summary>
        /// <returns>A boolean indicating whether the initialization was successful.</returns>
        public static bool InitializeGameLocations()
        {
            try
            {
                // Load location data from a configuration file or database
                var locationData = LoadLocationDataFromConfig();

                // Initialize locations based on the loaded data
                InitializeLocationsFromData(locationData);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing game locations: {ex.Message}");
                return false;
            }
        }

        private static LocationData LoadLocationDataFromConfig()
        {
            var configPath = "location_config.json";

            try
            {
                var json = System.IO.File.ReadAllText(configPath);
                return JsonConvert.DeserializeObject<LocationData>(json);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Config file not found at path: {configPath}");
                return null;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine($"Error parsing JSON from config file: {ex.Message}");
                return null;
            }
        }

        private static void InitializeLocationsFromData(LocationData locationData)
        {
            if (locationData == null)
            {
                Console.WriteLine("No location data provided.");
                return;
            }

            Console.WriteLine($"Initializing {locationData.LocationName} ({locationData.LocationType}) at ({locationData.X}, {locationData.Y})");
            // Implement the logic to initialize locations in your game based on the location data
        }



        public Location GetLocationByCoordinates(int x, int y)
        {
            return Locations.FirstOrDefault(l => l.X == x && l.Y == y);
        }

        public static void AddLocation(Location location)
        {
            Locations.Add(location);
        }

        public static void RemoveLocation(Location location)
        {
            Locations.Remove(location);
        }

        public List<Location> GetLocationsByResource(string resourceName)
        {
            return Locations.Where(l => l.Resources.ContainsKey(resourceName)).ToList();
        }

        public List<Location> GetLocationsBySkill(string skillName)
        {
            return Locations.Where(l => l.Skills.ContainsKey(skillName)).ToList();
        }

        public Location(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
            Resources = new Dictionary<string, int>();
            Skills = new Dictionary<string, int>();
            Position = new Position(x, y, 0);
        }

        public static Location CreateLocation(string name, int x, int y)
        {
            Location location = new Location(name, x, y);
            AddLocation(location);
            return location;
        }

        public Location GetLocationByName(string name)
        {
            return Locations.FirstOrDefault(l => l.Name == name);
        }

        public void AddResource(string resourceName, int quantity)
        {
            if (Resources.ContainsKey(resourceName))
            {
                Resources[resourceName] += quantity;
            }
            else
            {
                Resources.Add(resourceName, quantity);
            }
        }

        public bool HasResource(string resourceName)
        {
            return Resources.ContainsKey(resourceName);
        }

        public void SetResourceQuantity(string resourceName, int quantity)
        {
            if (Resources.ContainsKey(resourceName))
            {
                Resources[resourceName] = quantity;
            }
            else
            {
                Resources.Add(resourceName, quantity);
            }
        }

        public int GetResourceQuantity(string resourceName)
        {
            if (Resources.ContainsKey(resourceName))
            {
                return Resources[resourceName];
            }
            else
            {
                return 0;
            }
        }

        public void UpdateResource(string resourceName, int quantity)
        {
            if (Resources.ContainsKey(resourceName))
            {
                Resources[resourceName] += quantity;
            }
            else
            {
                Resources.Add(resourceName, quantity);
            }
        }

        public void RemoveResource(string resourceName, int quantity)
        {
            if (Resources.ContainsKey(resourceName))
            {
                Resources[resourceName] -= quantity;
                if (Resources[resourceName] <= 0)
                {
                    Resources.Remove(resourceName);
                }
            }
        }

        public void UpdatePosition(int x, int y, int z)
        {
            Position = new Position(x, y, z);
            Console.WriteLine($"Position updated to ({x}, {y}, {z})");
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class Map
    {
        public List<Location> Locations { get; set; }

        public Map()
        {
            Locations = new List<Location>();
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location);
        }

        public void RemoveLocation(Location location)
        {
            Locations.Remove(location);
        }
    }
}

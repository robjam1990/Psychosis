// Location Data created and maintained by AI in C# for a text-based game called Psychosis.
using System;
using System.Collections.Generic;

namespace Psychosis
{
    public class LocationData
    {
        public string LocationName { get; set; }
        public string LocationType { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string Description { get; set; }
        public bool IsAccessible { get; set; }
        public List<string> ConnectedLocations { get; set; }

        public LocationData(string locationName, string locationType, int x, int y, int z, string description, bool isAccessible, List<string> connectedLocations)
        {
            LocationName = locationName;
            LocationType = locationType;
            X = x;
            Y = y;
            Z = z;
            Description = description;
            IsAccessible = isAccessible;
            ConnectedLocations = connectedLocations;
        }

        public double CalculateDistanceTo(LocationData otherLocation)
        {
            double dx = X - otherLocation.X;
            double dy = Y - otherLocation.Y;
            double dz = Z - otherLocation.Z;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }
}

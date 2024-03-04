using System;

namespace InjuryApp
{
    public class Injury
    {
        public string Type { get; set; }
        public string Severity { get; set; }
        public string AffectedLimb { get; set; }

        public Injury(string type, string severity, string affectedLimb = null)
        {
            Type = type;
            Severity = severity;
            AffectedLimb = affectedLimb;
        }

        public string GetDescription()
        {
            return Type switch
            {
                "laceration" => GetLacerationDescription(),
                "fracture" => GetFractureDescription(),
                "burn" => GetBurnDescription(),
                _ => "Unknown injury"
            };
        }

        private string GetLacerationDescription()
        {
            return Severity switch
            {
                "mild" => $"You have a shallow cut on your {AffectedLimb}.",
                "moderate" => $"You have a deep gash on your {AffectedLimb}.",
                "severe" => $"Your {AffectedLimb} is torn open from a deep laceration.",
                _ => "Unknown laceration"
            };
        }

        private string GetFractureDescription()
        {
            return Severity switch
            {
                "mild" => $"You have a hairline fracture in your {AffectedLimb}.",
                "moderate" => $"You have a broken bone in your {AffectedLimb}.",
                "severe" => $"Your {AffectedLimb} is shattered from a severe fracture.",
                _ => "Unknown fracture"
            };
        }

        private string GetBurnDescription()
        {
            return Severity switch
            {
                "mild" => $"You have a minor burn on your {AffectedLimb}.",
                "moderate" => $"You have second-degree burns on your {AffectedLimb}.",
                "severe" => $"Your entire body is charred from severe burns.",
                _ => "Unknown burn"
            };
        }
    }
}

using System;
using System.IO;
using Newtonsoft.Json;

public class GameConfig
{
    public GameConfig(string configPath)
    {
        try
        {
            string json = File.ReadAllText(configPath);
            dynamic configData = JsonConvert.DeserializeObject(json);
            // Validate configData here
            foreach (var property in configData)
            {
                string propertyName = ((Newtonsoft.Json.Linq.JProperty)property).Name;
                object propertyValue = ((Newtonsoft.Json.Linq.JProperty)property).Value;
                typeof(GameConfig).GetProperty(propertyName)?.SetValue(this, propertyValue, null);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("Error loading configuration: " + error.Message);
            // Handle error gracefully or throw it
        }
    }

    public void UpdateConfig(dynamic configData)
    {
        // Validate and update configData dynamically
        foreach (var property in configData)
        {
            string propertyName = ((Newtonsoft.Json.Linq.JProperty)property).Name;
            object propertyValue = ((Newtonsoft.Json.Linq.JProperty)property).Value;
            typeof(GameConfig).GetProperty(propertyName)?.SetValue(this, propertyValue, null);
        }
    }
}

public class GameConfigDefaults
{
    // Game directories
    public string HomeDirectory { get; set; } = "C:/Psychosis/";
    public string ResourcesDirectory { get; set; } = "C:/Psychosis/Resources/";
    // Window settings
    public string WindowTitle { get; set; } = "Psychosis Window";
    public string WindowIcon { get; set; } = "Thear.png";
    public int MaxWindowWidth { get; set; } = 800;
    public int MaxWindowHeight { get; set; } = 600;
    public int InitialWindowWidth { get; set; } = 600;
    public int InitialWindowHeight { get; set; } = 400;
    // Rendering settings
    public int[] RenderDefaultBackgroundColor { get; set; } = new int[] { 255, 255, 255 }; // White color
    public int RenderDefaultLayer { get; set; } = 0;
    public int RenderFPS { get; set; } = 60;
    // Game features
    public bool LimbRemovalEnabled { get; set; } = true;
    public bool EcosystemSimulationEnabled { get; set; } = true;
    public bool NationBuildingEnabled { get; set; } = true;
    public bool SocialInfrastructureEnabled { get; set; } = true;
    public bool BountySystemEnabled { get; set; } = true; // Added Bounty System
    public bool HierarchySystemEnabled { get; set; } = true; // Added Hierarchy System
    public bool IndividualLoyaltyEnabled { get; set; } = true; // Added Individual Loyalty
    public bool TerritoryBorderExpansionEnabled { get; set; } = true; // Added Territory Border Expansion
    public bool DayNightCycleEnabled { get; set; } = true;
    public bool ConstructionSystemEnabled { get; set; } = true;
    public bool PrisonerSystemEnabled { get; set; } = true;
    public bool HiringSystemEnabled { get; set; } = true;
    public bool SupplyAndDemandSystemEnabled { get; set; } = true;
    public bool ResourceSystemEnabled { get; set; } = true; // Added Resource System
    public bool CraftingSystemEnabled { get; set; } = true;
    public bool SurvivalSystemEnabled { get; set; } = true;
    public bool CharacterGrowthSystemEnabled { get; set; } = true;
    public bool LearningAndTeachingSystemEnabled { get; set; } = true;
    public bool ObservationSystemEnabled { get; set; } = true;
    public bool CharacterCustomizationEnabled { get; set; } = true;
    public bool GeneticManipulationEnabled { get; set; } = true;
}

class Program
{
    static void Main(string[] args)
    {
        string configPath = "// robjam1990/Psychosis/Config/config.json";
        GameConfig config = new GameConfig(configPath);
        Console.WriteLine(config.WindowTitle); // Accessing a specific setting
    }
}

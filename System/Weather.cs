using System;

public class Weather
{
    private string[] weatherTypes = { "Scorching", "Drought", "Hot", "Sunny", "Clear", "Overcast", "Drizzle", "Rain", "Snow", "Storm", "Tornado", "Blizzard" };
    private string[] seasons = { "Spring", "Summer", "Autumn", "Winter" };

    public string CurrentWeather { get; private set; }
    public string CurrentSeason { get; private set; }
    public string TimeOfDay { get; private set; } = "Day"; // Assume day as default

    public Weather()
    {
        CurrentWeather = GenerateWeather();
        CurrentSeason = GenerateSeason();
    }

    private string GenerateWeather()
    {
        // Randomly select a weather type
        Random random = new Random();
        int randomIndex = random.Next(0, weatherTypes.Length);
        return weatherTypes[randomIndex];
    }

    private string GenerateSeason()
    {
        // Randomly select a season
        Random random = new Random();
        int randomIndex = random.Next(0, seasons.Length);
        return seasons[randomIndex];
    }

    public void ChangeWeather()
    {
        // Simulate weather change based on time of day and season
        if (TimeOfDay == "Day")
        {
            // During the day, weather changes are more frequent
            CurrentWeather = GenerateWeather();
        }
        else
        {
            // During the night, weather remains relatively stable
            // Consider adding moon phases for further complexity
            // For simplicity, weather remains the same during the night
        }
    }

    public void ChangeSeason()
    {
        // Simulate season change
        CurrentSeason = GenerateSeason();
    }

    // Implement day/night cycle
    public void SetTimeOfDay(string timeOfDay)
    {
        TimeOfDay = timeOfDay;
    }

    public string GetCurrentWeather()
    {
        return CurrentWeather;
    }

    public string GetCurrentSeason()
    {
        return CurrentSeason;
    }
}

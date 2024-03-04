// File: robjam1990/Psychosis/Gameplay/System/Weather.js
class Weather {
    constructor() {
        this.weatherTypes = ["Scorching", "Drought", "Hot", "Sunny", "Clear", "Overcast", "Drizzle", "Rain", "Snow", "Storm", "Tornado", "Blizzard"];
        this.currentWeather = this.generateWeather();
        this.seasons = ["Spring", "Summer", "Autumn", "Winter"];
        this.currentSeason = this.generateSeason();
        this.timeOfDay = "Day"; // Assume day as default
    }

    generateWeather() {
        // Randomly select a weather type
        const randomIndex = Math.floor(Math.random() * this.weatherTypes.length);
        return this.weatherTypes[randomIndex];
    }

    generateSeason() {
        // Randomly select a season
        const randomIndex = Math.floor(Math.random() * this.seasons.length);
        return this.seasons[randomIndex];
    }

    changeWeather() {
        // Simulate weather change based on time of day and season
        if (this.timeOfDay === "Day") {
            // During the day, weather changes are more frequent
            this.currentWeather = this.generateWeather();
        } else {
            // During the night, weather remains relatively stable
            // Consider adding moon phases for further complexity
            // For simplicity, weather remains the same during the night
        }
    }

    changeSeason() {
        // Simulate season change
        this.currentSeason = this.generateSeason();
    }

    // Implement day/night cycle
    setTimeOfDay(timeOfDay) {
        this.timeOfDay = timeOfDay;
    }

    getCurrentWeather() {
        return this.currentWeather;
    }

    getCurrentSeason() {
        return this.currentSeason;
    }
}

module.exports = Weather;

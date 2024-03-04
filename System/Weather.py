import random

class Weather:
    def __init__(self):
        self.weather_types = ["Scorching", "Drought", "Hot", "Sunny", "Clear", "Overcast", "Drizzle", "Rain", "Snow", "Storm", "Tornado", "Blizzard"]
        self.current_weather = self.generate_weather()
        self.seasons = ["Spring", "Summer", "Autumn", "Winter"]
        self.current_season = self.generate_season()
        self.time_of_day = "Day"  # Assume day as default

    def generate_weather(self):
        # Randomly select a weather type
        random_index = random.randint(0, len(self.weather_types) - 1)
        return self.weather_types[random_index]

    def generate_season(self):
        # Randomly select a season
        random_index = random.randint(0, len(self.seasons) - 1)
        return self.seasons[random_index]

    def change_weather(self):
        # Simulate weather change based on time of day and season
        if self.time_of_day == "Day":
            # During the day, weather changes are more frequent
            self.current_weather = self.generate_weather()
        else:
            # During the night, weather remains relatively stable
            # Consider adding moon phases for further complexity
            # For simplicity, weather remains the same during the night
            pass

    def change_season(self):
        # Simulate season change
        self.current_season = self.generate_season()

    # Implement day/night cycle
    def set_time_of_day(self, time_of_day):
        self.time_of_day = time_of_day

    def get_current_weather(self):
        return self.current_weather

    def get_current_season(self):
        return self.current_season

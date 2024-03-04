# File: robjam1990/Psychosis/Gameplay/Planets/Thear/Cycles.py

class Thear:
    def __init__(self):
        self.Time = {
            "Year": 360,  # Days
            "Seasons": 4,  # Spring, Summer, Autumn, Winter
            "Months": 30,  # Days
            "Weeks": 5,  # Days
            "Day": 36,  # Hours
            "Daytime": 18,  # Hours
            "Nighttime": 18,  # Hours
            "GameTimeToRealTimeRatio": ['4:1'],  # 1 hour (in-game) equals 15 minutes (real-time)
        }
        self.Bractalia = {
            "Nexus": {
                "Taverne": {
                    "Weather": {
                        "Rainy": 0.1,  # Daily probability of rain
                        "Snowy": 0.05,  # Daily probability of snow
                        "Stormy": 0.025  # Daily probability of storm
                    },
                    "NPCs": {
                        "Schedule": {
                            "WakeUp": 9,  # Time NPCs wake up (in hours)
                            "PrivateWorkStart": 10,  # Time NPCs start working (in hours)
                            "PublicWorkStart": 12,  # Time NPCs start working (in hours)
                            "LunchStart": 18,  # Time NPCs take lunch break (in hours)
                            "WorkEnd": 20,  # Time NPCs finish working (in hours)
                            "DinnerStart": 21,  # Time NPCs have dinner (in hours)
                            "Bedtime": 30  # Time NPCs go to bed (in hours)
                        },
                        "Behaviors": {
                            "Idle": "Relaxing at the Taverne",
                            "PrivateWork": "Performing tasks around Home",
                            "PublicWork": "Performing tasks around Nexus",
                            "Socializing": "Interacting with other NPCs"
                        }
                    },
                    "Mechanics": {
                        "HungerRate": 2,  # Rate at which hunger increases (per hour)
                        "ThirstRate": 2.5,  # Rate at which thirst increases (per hour)
                        "FatigueRate": 1.75,  # Rate at which fatigue increases (per hour)
                        "RecoveryRate": 4  # Rate at which fatigue decreases while asleep (per hour)
                    }
                }
            }
        }

# Example of optimization: Caching frequently accessed properties
taverneTime = Thear().Bractalia["Nexus"]["Taverne"]["Weather"]
taverneNPCs = Thear().Bractalia["Nexus"]["Taverne"]["NPCs"]
taverneMechanics = Thear().Bractalia["Nexus"]["Taverne"]["Mechanics"]

# Example of adding new quests to the game
class Quest:
    def __init__(self, title, description):
        self.title = title
        self.description = description

newQuest = Quest("Retrieve the Lost Artifact", "Embark on a journey to retrieve the ancient artifact lost in the depths of the forest.")

def simulate_NPC_behavior(time):
    behavior = ""
    schedule = Thear().Bractalia["Nexus"]["Taverne"]["NPCs"]["Schedule"]
    behaviors = Thear().Bractalia["Nexus"]["Taverne"]["NPCs"]["Behaviors"]
    
    if time < 0 or time >= Thear().Time["Day"]:
        raise ValueError("Invalid time parameter")
        
    if time >= schedule["WakeUp"] and time < schedule["PrivateWorkStart"]:
        behavior = behaviors["Idle"]
    elif time >= schedule["PrivateWorkStart"] and time < schedule["LunchStart"]:
        behavior = behaviors["PublicWork"]
    elif time >= schedule["LunchStart"] and time < schedule["WorkEnd"]:
        behavior = behaviors["Socializing"]
    elif time >= schedule["WorkEnd"] and time < schedule["DinnerStart"]:
        behavior = behaviors["Idle"]
    elif time >= schedule["DinnerStart"] and time < schedule["Bedtime"]:
        behavior = behaviors["Socializing"]
    else:
        behavior = "Waiting"
        
    return behavior

def simulate_weather():
    weather = Thear().Bractalia["Nexus"]["Taverne"]["Weather"]
    weather_types = ["Clear", "Rainy", "Snowy", "Stormy"]
    random_value = random.random()

    if random_value < weather["Rainy"]:
        return weather_types[1]
    elif random_value < weather["Snowy"]:
        return weather_types[2]
    elif random_value < weather["Stormy"]:
        return weather_types[3]
    else:
        return weather_types[0]

def simulate_time_based_mechanics(time):
    mechanics = Thear().Bractalia["Nexus"]["Taverne"]["Mechanics"]
    hunger_rate = mechanics["HungerRate"]
    thirst_rate = mechanics["ThirstRate"]
    fatigue_rate = mechanics["FatigueRate"]
    recovery_rate = mechanics["RecoveryRate"]

    hunger_increase = hunger_rate * time
    thirst_increase = thirst_rate * time
    fatigue_increase = fatigue_rate * time
    fatigue_decrease = recovery_rate * time

    return {
        "hunger": hunger_increase,
        "thirst": thirst_increase,
        "fatigue": fatigue_increase,
        "fatigueDecrease": fatigue_decrease
    }

# Example of how time progresses in the game
def progress_time():
    day = Thear().Time["Day"]
    game_time_to_real_time_ratio = Thear().Time["GameTimeToRealTimeRatio"]
    real_time_increment = 1 / game_time_to_real_time_ratio  # Increment in real-time (minutes)
    in_game_time = 0  # Initialize in-game time (hours)

    def update_time():
        nonlocal in_game_time
        in_game_time += real_time_increment

        # Convert real-time to in-game time
        if in_game_time >= 60:
            in_game_time -= 60

        print(f"Current in-game time: {math.floor(in_game_time)}:00")
        print(f"NPC behavior: {simulate_NPC_behavior(math.floor(in_game_time))}")
        print(f"Weather: {simulate_weather()}")
        print(f"Time-based mechanics: {json.dumps(simulate_time_based_mechanics(math.floor(in_game_time)))}")

    while True:
        update_time()
        time.sleep(day * 60 * 1000)  # Convert day to minutes and set interval in milliseconds

# Example of checking platform compatibility before executing platform-specific code
def play_sound(sound_file):
    if is_mobile_platform():
        # Code to play sound on mobile platform
        pass
    else:
        # Code to play sound on other platforms
        pass

# Start the game
progress_time()

# Define get_real_time_passed function
def get_real_time_passed(game_hours):
    return game_hours * 15  # Assuming 15 real minutes per game hour

# Define save function
def save():
    return {
        "year": year,
        "seasonCount": season_count,
        "month": month,
        "day": day,
        "hour": hour,
        "currentSeason": current_season,
        "isDaytime": is_daytime
    }

# Define load function
def load(saved_data):
    year = saved_data["year"]
    season_count = saved_data["seasonCount"]
    month = saved_data["month"]
    day = saved_data["day"]
    hour = saved_data["hour"]
    current_season = saved_data["currentSeason"]
    is_daytime = saved_data["isDaytime"]

# Instantiate the ThearTime object
game_clock = Thear()

# Example: Advance time by 222 hours
hours_to_advance = 222
game_clock.advance_time(hours_to_advance)

# Save the game state
saved_data = save()
print('Game state saved:', saved_data)

# Simulate loading the game state
loaded_data = saved_data  # In a real game, this data would come from a file or storage
load(loaded_data)
print('Game state loaded:', loaded_data)

# Display current in-game time after loading
print(f"Current in-game time after loading: Year {game_clock.year}, Season {game_clock.current_season}, Month {game_clock.month}, Day {game_clock.day}, Hour {game_clock.hour}.")
print(f"It is currently {'daytime' if game_clock.is_daytime else 'nighttime'}.")

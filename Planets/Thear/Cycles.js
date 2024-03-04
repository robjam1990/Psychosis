// File = robjam1990/Psychosis/Gameplay/Planets/Thear/Cycles.js
const Thear = {

    Time: {
        Year: 360, // Days
        Seasons: 4, // Spring, Summer, Autumn, Winter
        Months: 30, // Days
        Weeks: 5, // Days
        Day: 36, // Hours
        Daytime: 18, // Hours
        Nighttime: 18, // Hours
        GameTimeToRealTimeRatio: ['4:1'], // 1 hour (in-game) equals 15 minutes (real-time)
    },
    Bractalia: {
        Nexus: {
            Taverne: {
                Weather: {
                    Rainy: 0.1, // Daily probability of rain
                    Snowy: 0.05, // Daily probability of snow
                    Stormy: 0.025 // Daily probability of storm
                },
                NPCs: {
                    Schedule: {
                        WakeUp: 9, // Time NPCs wake up (in hours)
                        PrivateWorkStart: 10, // Time NPCs start working (in hours)
                        PublicWorkStart: 12, // Time NPCs start working (in hours)
                        LunchStart: 18, // Time NPCs take lunch break (in hours)
                        WorkEnd: 20, // Time NPCs finish working (in hours)
                        DinnerStart: 21, // Time NPCs have dinner (in hours)
                        Bedtime: 30 // Time NPCs go to bed (in hours)
                    },
                    Behaviors: {
                        Idle: "Relaxing at the Taverne",
                        PrivateWork: "Performing tasks around Home",
                        PublicWork: "Performing tasks around Nexus",
                        Socializing: "Interacting with other NPCs"
                    }
                },
                Mechanics: {
                    HungerRate: 2, // Rate at which hunger increases (per hour)
                    ThirstRate: 2.5, // Rate at which thirst increases (per hour)
                    FatigueRate: 1.75, // Rate at which fatigue increases (per hour)
                    RecoveryRate: 4 // Rate at which fatigue decreases while asleep (per hour)
                }
            }
        }
    }
};
// Example of optimization: Caching frequently accessed properties
const taverneTime = Thear.Bractalia.Nexus.Taverne.Time;
const taverneNPCs = taverneTime.NPCs;
const taverneMechanics = Thear.Bractalia.Nexus.Taverne.Mechanics;

// Example of adding new quests to the game
class Quest {
    constructor(title, description) {
        this.title = title;
        this.description = description;
    }
}

const newQuest = new Quest("Retrieve the Lost Artifact", "Embark on a journey to retrieve the ancient artifact lost in the depths of the forest.");


function simulateNPCBehavior(time) {
    let behavior = "";
    const { Schedule, Behaviors } = Thear.Bractalia.Nexus.Taverne.NPCs; // Fixed variable scope issue

    if (time < 0 || time >= Thear.Bractalia.Nexus.Taverne.Time.Day) {
        throw new Error("Invalid time parameter");
    }
    if (time >= Schedule.WakeUp && time < Schedule.WorkStart) {
        behavior = Behaviors.Idle;
    } else if (time >= Schedule.WorkStart && time < Schedule.LunchStart) {
        behavior = Behaviors.PublicWork;
    } else if (time >= Schedule.LunchStart && time < Schedule.WorkEnd) {
        behavior = Behaviors.Socializing;
    } else if (time >= Schedule.WorkEnd && time < Schedule.DinnerStart) {
        behavior = Behaviors.Idle;
    } else if (time >= Schedule.DinnerStart && time < Schedule.Bedtime) {
        behavior = Behaviors.Socializing;
    } else if (Hungry) {
        behavior = "Eating";
    } else if (Thirsty) {
        behavior = "Drinking";
    } else if (Tired) {
        behavior = "Sleeping";
    } else {
        behavior = "Waiting";
    }

    return behavior;
}

function simulateWeather() {
    const { Weather } = Thear.Bractalia.Nexus.Taverne;
    const weatherTypes = ["Clear", "Rainy", "Snowy", "Stormy"];
    const randomValue = Math.random();

    if (randomValue < Weather.Rainy) {
        return weatherTypes[1];
    } else if (randomValue < Weather.Snowy) {
        return weatherTypes[2];
    } else if (randomValue < Weather.Stormy) {
        return weatherTypes[3];
    } else {
        return weatherTypes[0];
    }
}


function simulateTimeBasedMechanics(time) {
    const { Mechanics } = Thear.Bractalia.Nexus.Taverne;
    const { HungerRate, ThirstRate, FatigueRate, RecoveryRate } = Mechanics;

    // Simulate increase in hunger, thirst, and fatigue over time
    let hungerIncrease = HungerRate * time;
    let thirstIncrease = ThirstRate * time;
    let fatigueIncrease = FatigueRate * time;
    let fatigueDecrease = RecoveryRate * time;

    return {
        hunger: hungerIncrease,
        thirst: thirstIncrease,
        fatigue: fatigueIncrease,
        fatigueDecrease: fatigueDecrease // Fixed typo
    };
}

// Example of how time progresses in the game
function progressTime() {
    const {
        Day,
        GameTimeToRealTimeRatio
    } = Thear.Bractalia.Nexus.Taverne.Time;
    const realTimeIncrement = 1 / GameTimeToRealTimeRatio; // Increment in real-time (minutes)
    let inGameTime = 0; // Initialize in-game time (hours)

    setInterval(() => {
        inGameTime += realTimeIncrement;

        // Convert real-time to in-game time
        if (inGameTime >= 60) {
            inGameTime -= 60;
        }

        console.log(`Current in-game time: ${Math.floor(inGameTime)}:00`);
        console.log(`NPC behavior: ${simulateNPCBehavior(Math.floor(inGameTime))}`);
        console.log(`Weather: ${simulateWeather()}`);
        console.log(`Time-based mechanics: ${JSON.stringify(simulateTimeBasedMechanics(Math.floor(inGameTime)))}`);
    }, Day * 60 * 1000); // Convert day to minutes and set interval in milliseconds
}
// Example of checking platform compatibility before executing platform-specific code
function playSound(soundFile) {
    if (isMobilePlatform()) {
        // Code to play sound on mobile platform
    } else {
        // Code to play sound on other platforms
    }
}

// Start the game
progressTime();

// Define getRealTimePassed function
function getRealTimePassed(gameHours) {
    return gameHours * 15; // Assuming 15 real minutes per game hour
}

// Define save function
function save() {
    return {
        year: this.year,
        seasonCount: this.seasonCount,
        month: this.month,
        day: this.day,
        hour: this.hour,
        currentSeason: this.currentSeason,
        isDaytime: this.isDaytime
    };
}

// Define load function
function load(savedData) {
    this.year = savedData.year;
    this.seasonCount = savedData.seasonCount;
    this.month = savedData.month;
    this.day = savedData.day;
    this.hour = savedData.hour;
    this.currentSeason = savedData.currentSeason;
    this.isDaytime = savedData.isDaytime;
}

// Instantiate the ThearTime object
const gameClock = new ThearTime();

// Example: Advance time by 222 hours
const hoursToAdvance = 222;
gameClock.advanceTime(hoursToAdvance);

// Save the game state
const savedData = gameClock.save();
console.log('Game state saved:', savedData);

// Simulate loading the game state
const loadedData = savedData; // In a real game, this data would come from a file or storage
gameClock.load(loadedData);
console.log('Game state loaded:', loadedData);

// Display current in-game time after loading
console.log(`Current in-game time after loading: Year ${gameClock.year}, Season ${gameClock.currentSeason}, Month ${gameClock.month}, Day ${gameClock.day}, Hour ${gameClock.hour}.`);
console.log(`It is currently ${gameClock.isDaytime ? 'daytime' : 'nighttime'}.`);

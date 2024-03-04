class Town {
    constructor(name) {
        this.name = name;
        this.Taverne = {
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
        };
    }
}

const Nexus = new Town("Nexus");

// Example of how NPCs behave based on the time of day
function simulateNPCBehavior(time) {
    try {
        let behavior = "";
        const { Schedule, Behaviors } = Nexus.Taverne.NPCs;

        if (time >= Schedule.WakeUp && time < Schedule.PrivateWorkStart) {
            behavior = Behaviors.Idle;
        } else if (time >= Schedule.PrivateWorkStart && time < Schedule.PublicWorkStart) {
            behavior = Behaviors.PrivateWork;
        } else if (time >= Schedule.PublicWorkStart && time < Schedule.LunchStart) {
            behavior = Behaviors.PublicWork;
        } else if (time >= Schedule.LunchStart && time < Schedule.WorkEnd) {
            behavior = Behaviors.Socializing;
        } else if (time >= Schedule.WorkEnd && time < Schedule.DinnerStart) {
            behavior = Behaviors.Idle;
        } else if (time >= Schedule.DinnerStart && time < Schedule.Bedtime) {
            behavior = Behaviors.Socializing;
        } else {
            behavior = "Waiting";
        }
        return behavior;
    } catch (error) {
        console.error(`Error in simulating NPC behavior: ${error.message}`);
        return behavior;
    }
}

// Example of optimizing weather simulation function by caching probabilities
const weatherProbabilities = {
    Rainy: Nexus.Taverne.Weather.Rainy,
    Snowy: Nexus.Taverne.Weather.Snowy,
    Stormy: Nexus.Taverne.Weather.Stormy
};

// Example interactions specific to Nexus
NexusLocation.showNextDialog("opening");

// Export Nexus for use in other modules
module.exports = Nexus;

// File: robjam1990/Psychosis/Gameplay/Planets/Thear/Taverne.js

// Quest Management Object
const QuestManager = {
    activeQuests: [],
    completedQuests: [],
    startQuest: function (quest) {
        this.activeQuests.push(quest);
        console.log(`Quest "${quest.name}" started.`);
    },
    completeQuest: function (quest) {
        const index = this.activeQuests.indexOf(quest);
        if (index !== -1) {
            this.activeQuests.splice(index, 1);
            this.completedQuests.push(quest);
            console.log(`Quest "${quest.name}" completed.`);
            // Grant rewards and handle quest completion logic
        } else {
            console.error(`Quest "${quest.name}" not found.`);
        }
    },
};

// NPC Class with Behavior and Interaction
class NPC {
    constructor(name, description, location, quests) {
        this.name = name;
        this.description = description;
        this.location = location;
        this.quests = quests;
        this.behavior = this.getRandomBehavior();
    }

    getRandomBehavior() {
        const behaviors = ["Friendly", "Neutral", "Aggressive"];
        return behaviors[Math.floor(Math.random() * behaviors.length)];
    }

    interact() {
        switch (this.behavior) {
            case "Friendly":
                console.log(`${this.name} greets you warmly.`);
                break;
            case "Neutral":
                console.log(`${this.name} acknowledges your presence.`);
                break;
            case "Aggressive":
                console.log(`${this.name} eyes you warily.`);
                break;
            default:
                console.error(`${this.name} has an invalid behavior.`);
        }
    }
}

const taverne = new Structure("Ye Olde Taverne", "(Residential, Commercial)", "[x*y*z]");

const mainHall = new Room("Main Hall", "Public", "[19*29*8]");
const backRoom = new Room("Back Room", "Private", "[7*20*8]");
const storage = new Room("Storage", "Restricted", "[5*9*6]");
const trainingRoom = new Room("Training Room", "Restricted", "[6*14*6]");
const office = new Room("Office", "Restricted", "[5*5*6]");
const bedroom = new Room("Bedroom", "Restricted", "[14*14*6]");

const barkeep = new NPC(
    "Barkeep",
    "The barkeep is a stout and friendly figure, always ready with a warm smile and a kind word for patrons. He's the heart and soul of Ye Olde Taverne, keeping spirits high and glasses full.",
    [0, 0, 0],
    [
        { name: "Delivery", description: "The barkeep needs someone to deliver a shipment of ale to a nearby village. Are you up for the task?", reward: "5 Silver coins and the gratitude of the barkeep." },
        { name: "Scouting", description: "The barkeep has heard rumors of strange occurrences in the nearby forest. Can you investigate and report back? [Optional: will pay for Ginger and Barley.]", reward: "10 silver coins for Valuable Information as well as 2 Silver coins per Barley and 3 per Ginger." }
    ]
);

const maia = new NPC(
    "Maia",
    "Maia is a slim and friendly figure, always ready with a warm smile and a kind word for patrons. She's the Lungs of Ye Olde Taverne, bringing in new patrons.",
    [26, -5, 0],
    [
        { name: "Welcome", description: "You are Hungry and Thirsty, go see the Barkeep for some Charity.", reward: "Leg of Phesant, Cup of Juice, Half of Bread Loaf, Potatoe." }
    ]
);

const interactiveElements = [
    { name: "Barkeep", description: "The jovial barkeep stands behind the polished bar, ready to serve patrons with a welcoming smile and a quick wit. You can {talk} to him or {order} a drink." },
    { name: "Maia", description: "The capricious greeter stand near the entrance, constantly greeting patrons with a welcoming smile, friendly demeanor and a quick wit. You can {talk} to her." },
    { name: "Notice Board", description: "A notice board hangs on the wall, covered in various parchments and flyers. You can {read} the notices for information on available quests or tasks." },
    { name: "Training Area", description: "In the corner of the taverne, a training area beckons to those seeking to hone their skills. You can {practice} your combat techniques here." },
    { name: "Seating", description: "In the center of the taverne, a seating area for adventurers to connect. You can make friends and be {social} here." },
    { name: "Pyre", description: "Near the entrance, a hearth to keep warm. You can {cook} food here." },
    { name: "Latrines", description: "Just outside the entrance, a public Latrine. You can empty {waste} here." },
    { name: "Well", description: "Outside by the walking path, a working well water source. You can get fresh water here." },
    { name: "Back Room", description: "Reservable for private parties, with a Private Table, Chests and Beds. Speak with the barkeep for more information." },
    { name: "Storage", description: "Scattered all over the Main hall, public barrels, chests and cupboards sit. You can use these to store and take items." }
];

const Location = {
    name: "Ye Olde Taverne",
    image: ["Taverne.jpg", "Taverne(upstairs).jpg"],
    description: "You step into the Main hall of Ye Olde Taverne, a warm and inviting establishment nestled in the heart of Nexus. It's a place where weary travelers find respite, adventurers plan their next quests, and locals gather for camaraderie and revelry.",
    interactiveElements: interactiveElements,
    npc: [barkeep, maia],

    interactWithBarkeep: function (action) {
        switch (action) {
            case "talk":
                console.log("You engage the barkeep in conversation about the latest gossip and happenings in the Taverne.");
                // Implement conversation options
                break;
            case "order":
                console.log("You order a drink from the barkeep, who quickly serves you a frothy mug of ale.");
                // Implement ordering functionality
                break;
            default:
                console.error("Invalid action:", action);
        }
    },

    interactWithMaia: function (action) {
        switch (action) {
            case "talk":
                console.log("You engage Maia in conversation about the latest gossip and happenings in Nexus.");
                // Implement conversation options
                break;
            default:
                console.error("Invalid action:", action);
        }
    },

    readNoticeBoard: function () {
        console.log("You approach the notice board and scan the various notices pinned to it, looking for...");
        // Code to display available quests or tasks
        console.log("Decree: Messages directly from the jurisdictional commanding Royal Family");
        console.log("Notice: Messages from the establishment");
        console.log("Bounty: Messages from NPCs");
        console.log("Request: Messages from Humans");
        console.log("Write: Write a message");
    },

    practiceCombat: function () {
        console.log("You spend some time practicing your combat skills in the training area, honing your techniques for future battles.");
        // Code to simulate combat practice
        console.log("Exercise: Choose an Exercise");
        console.log("Time: Choose a Duration Goal");
        console.log("Companion: Choose a Sparring Companion");
        console.log("Trainer: Choose your trainer");
    },

    Seating: function () {
        console.log("You approach the seating area and scan the various empty and full tables, looking for...");
        // Code to display available quests or tasks
        console.log("Tables: List of available tables");
        console.log("Stools: List of available seating");
        console.log("Person: List of recognized people");
    },

    Pyre: function () {
        console.log("You approach the hearth and notice the temperature increase associated with it, ready to cook.");
        // Code to display available quests or tasks
        console.log("Cook: Place on the fire");
        console.log("Warm: Place near the fire");
        console.log("Rest: Rest near the fire");
    },

    Well: function () {
        console.log("You approach the well and scan the interior, looking for...");
        // Code to display available quests or tasks
        console.log("Harvest: Gather some drinking water");
        console.log("Pollute: Pollute the drinking water");
    },

    Latrine: function () {
        console.log("You approach the public latrines and scan the various stalls, looking for...");
        // Code to display available quests or tasks
        console.log("Evacuate: Dispel waste");
        console.log("Clean: Clean latrine");
    },

    BackRoom: function () {
        console.log("You approach the back room and scan the long room, looking for...");
        // Code to display available quests or tasks
        console.log("Enter: Attempt to enter the back room");
    },

    Storage: function () {
        console.log("You approach the storage containers and scan the various compartments, looking for...");
        // Code to display available quests or tasks
        console.log("Barrel: Open barrel");
        console.log("Chest: Open chest");
        console.log("Cupboard: Open cupboard");
    },

    // UI Interaction Methods
    showLocationImage: function () {
        console.log("Displaying location image:", this.image);
        // Code to display location image
    },

    displayDialog: function (dialog) {
        console.log("Displaying dialog:", dialog);
        // Code to display dialog in UI
    }
};

// Example interactions
Location.interactWithBarkeep("talk");
Location.interactWithBarkeep("order");
Location.readNoticeBoard();
Location.practiceCombat();

// Set language and localize
Localization.setLanguage("English");
console.log(Localization.localize("greeting")); // Output: Hello!

Thear.showNextDialog("opening");

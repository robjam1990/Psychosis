// File = robjam1990/Psychosis/Gameplay/System/gamelogic.ts
// Define initial game state
const initialState: State = {
    solarSystem: {
        planets: [
            { name: "Thear", type: "terrestrial" },
            { name: "Aurora", type: "gas giant" },
            { name: "Nebula Prime", type: "ice planet" }
        ],
        currentPlanet: "Thear",
        roundPlanets: true,
        // Additional solar system details (e.g., orbits, celestial events)
        orbits: [
            { planet: "Thear", orbitPath: "elliptical" },
            { planet: "Aurora", orbitPath: "circular" },
            { planet: "Nebula Prime", orbitPath: "eccentric" }
        ],
        celestialEvents: [
            { name: "Solar Eclipse", frequency: "monthly", description: "A rare event where Thear is eclipsed by its moon." },
            { name: "Comet Shower", frequency: "annually", description: "A spectacular display of comets passing through the solar system." }
        ]
    },
    combat: {
        tactical: true,
        limbRemoval: true,
        // Additional combat details (e.g., weapon diversity, environmental interactions)
        weapons: [
            { name: "Sword", type: "melee", damage: 20 },
            { name: "Blaster", type: "ranged", damage: 30 }
        ],
        combatStyles: [
            { name: "Aggressive", description: "Focuses on dealing high damage but sacrifices defense." },
            { name: "Defensive", description: "Prioritizes defense and counterattacks." }
        ],
        environmentalInteractions: [
            { name: "Weather Effects", description: "Weather conditions affect visibility and movement speed in combat." },
            { name: "Terrain Advantage", description: "Certain terrain types provide bonuses or penalties during combat." }
        ]
    },
    ecosystem: {
        simulation: true,
        animalCommunication: true,
        // Additional ecosystem details (e.g., dynamic ecosystem, ecological events)
        dynamicEcosystem: true,
        ecologicalEvents: [
            { name: "Predator Outbreak", frequency: "seasonally", description: "A surge in predator populations leads to increased danger for prey animals." },
            { name: "Plant Disease", frequency: "random", description: "A disease spreads among plant life, affecting ecosystem balance." }
        ]
    },
    nation: {
        power: 100,
        multiFactionWar: true,
        logistics: true,
        agriculture: true,
        commerce: true,
        succession: true,
        // Additional nation details (e.g., diplomacy, espionage, cultural development)
        diplomacy: true,
        espionage: true,
        culturalDevelopment: true
    },
    socialInfrastructure: {
        bountySystem: true,
        hierarchies: [{ name: "Default", members: [] }],
        // Additional social infrastructure details (e.g., political intrigue, reputation system)
        politicalIntrigue: true,
        reputationSystem: true
    },
    loyalty: {
        fear: 50,
        respect: 50,
        morality: 50,
        jurisdictionBasedJusticeSystem: true,
        // Additional loyalty details (e.g., consequence system, nuanced justice)
        consequenceSystem: true,
        nuancedJustice: true
    },
    territory: {
        borderExpansion: true,
        // Additional territory details (e.g., resource management, colonization)
        resourceManagement: true,
        colonization: true
    },
    time: {
        cycles: true,
        dayNightCycle: true,
        seasonCycle: true,
        // Additional time details (e.g., seasonal effects, cyclical events)
        seasonalEffects: true,
        cyclicalEvents: true
    },
    construction: {
        structures: [],
        // Additional construction details (e.g., technology advancement)
        technologyAdvancement: true
    },
    prisoners: {
        takePrisoners: true,
        // Additional prisoner details (e.g., prisoner interactions, rehabilitation)
        prisonerInteractions: true,
        rehabilitation: true
    },
    naming: {
        renameLocations: true,
        renameObjects: true,
        // Additional naming details (e.g., lore creation, naming ceremonies)
        loreCreation: true,
        namingCeremonies: true
    },
    hiring: {
        hireOthers: true,
        raiseArmy: true,
        // Additional hiring details (e.g., mercenary contracts, loyalty quests)
        mercenaryContracts: true,
        loyaltyQuests: true
    },
    delegation: {
        militaryFormations: true,
        // Additional delegation details (e.g., command structures, tactical formations)
        commandStructures: true,
        tacticalFormations: true
    },
    supplyDemand: {
        barterSystem: true,
        // Additional supply and demand details (e.g., trade routes, market dynamics)
        tradeRoutes: true,
        marketDynamics: true
    },
    resources: {
        renewable: [{ type: "water", amount: 1000 }],
        nonRenewable: [{ type: "metal", amount: 500 }],
        // Additional resource details (e.g., rare resources, resource depletion)
        rareResources: [{ type: "rareMetal", amount: 100 }],
        resourceDepletion: true
    },
    crafting: {
        depth: true,
        metallurgySystem: true,
        // Additional crafting details (e.g., specialized crafting skills, artifact creation)
        specializedCrafting: true,
        artifactCreation: true
    },
    survival: {
        oxygen: true,
        temperature: true,
        disease: true,
        hunger: true,
        energy: true,
        sanity: true,
        hygiene: true,
        waste: true,
        // Additional survival details (e.g., environmental hazards, psychological effects)
        environmentalHazards: true,
        psychologicalEffects: true
    },
    characterGrowth: {
        advancedSystem: true,
        // Additional character growth details (e.g., mentorship, character arcs)
        mentorship: true,
        characterArcs: true
    },
    learning: {
        advancedSystem: true,
        // Additional learning details (e.g., skill books, knowledge quests)
        skillBooks: true,
        knowledgeQuests: true
    },
    observation: {
        empatheticLearning: true,
        // Additional observation details (e.g., NPC routines, environmental clues)
        NPCRoutines: true,
        environmentalClues: true
    },
    customization: {
        facialMapping: true,
        voiceSynthesizing: true,
        multiplePlayableCharacters: true,
        enhancedReproduction: true,
        // Additional customization details (e.g., character backstory, appearance evolution)
        characterBackstory: true,
        appearanceEvolution: true
    },
    genetics: {
        manipulation: true,
        // Additional genetics details (e.g., genetic engineering quests, ethical dilemmas)
        geneticEngineeringQuests: true,
        ethicalDilemmas: true
    }
};

// File = robjam1990/Psychosis/Gameplay.EntityCollection.js
class EntityCollection {
    constructor() {
        this.allEntities = {};
        this.entityCache = {}; // New property for caching loaded entities
        this.cacheExpiration = 3600; // Cache expiration time in seconds (default: 1 hour)
    }

    async loadEntityData(entityType, fetchFunction) {
        try {
            // Check if entity data is already cached and not expired
            const cachedData = this.getCachedEntityData(entityType);
            if (cachedData) {
                console.log(`${entityType} data loaded from cache.`);
                return cachedData;
            }

            const data = await fetchFunction();
            this.validateEntityData(data);

            // Store loaded data in cache
            this.cacheEntityData(entityType, data);

            console.log(`${entityType} data loaded successfully.`);
            return data;
        } catch (error) {
            console.error(`Error loading ${entityType} data:`, error);
            throw error;
        }
    }

    validateEntityData(data) {
        // Implement validation logic here (e.g., check data structure)
        // Throw an error if data is invalid
        if (!data) {
            throw new Error('Invalid entity data format.');
        }
    }

    getCachedEntityData(entityType) {
        const cachedData = this.entityCache[entityType];
        if (cachedData && Date.now() - cachedData.timestamp < this.cacheExpiration * 1000) {
            return cachedData.data;
        }
        return null;
    }

    cacheEntityData(entityType, data) {
        this.entityCache[entityType] = {
            data: data,
            timestamp: Date.now()
        };
    }

    getEntitiesByType(entityType) {
        return this.allEntities[entityType] || [];
    }

    clearEntityCache() {
        this.entityCache = {}; // Clear the entity cache
        console.log('Entity cache cleared.');
    }

    async fetchEntityDataFromFile(filePath) {
        const response = await fetch(filePath);
        if (!response.ok) {
            throw new Error(`Failed to fetch entity data. Status: ${response.status}`);
        }
        return await response.json();
    }

    async loadEntitiesFromFile(entityType, filePath) {
        return await this.loadEntityData(entityType, () => this.fetchEntityDataFromFile(filePath));
    }

    async loadEntitiesFromDatabase(entityType, databaseQuery) {
        // Implement database loading logic here
        // Example: const data = await database.query(databaseQuery);
        // Ensure to return data in the expected format
    }

    // Other methods for dynamic entity management, integration with other systems, etc.
}

import time

class EntityCollection:
    def __init__(self):
        self.allEntities = {}
        self.entityCache = {}  # New property for caching loaded entities
        self.cacheExpiration = 3600  # Cache expiration time in seconds (default: 1 hour)

    async def loadEntityData(self, entityType, fetchFunction):
        try:
            # Check if entity data is already cached and not expired
            cachedData = self.getCachedEntityData(entityType)
            if cachedData:
                print(f"{entityType} data loaded from cache.")
                return cachedData

            data = await fetchFunction()
            self.validateEntityData(data)

            # Store loaded data in cache
            self.cacheEntityData(entityType, data)

            print(f"{entityType} data loaded successfully.")
            return data
        except Exception as error:
            print(f"Error loading {entityType} data:", error)
            raise error

    def validateEntityData(self, data):
        # Implement validation logic here (e.g., check data structure)
        # Throw an error if data is invalid
        if not data:
            raise ValueError('Invalid entity data format.')

    def getCachedEntityData(self, entityType):
        cachedData = self.entityCache.get(entityType)
        if cachedData and time.time() - cachedData['timestamp'] < self.cacheExpiration:
            return cachedData['data']
        return None

    def cacheEntityData(self, entityType, data):
        self.entityCache[entityType] = {
            'data': data,
            'timestamp': time.time()
        }

    def getEntitiesByType(self, entityType):
        return self.allEntities.get(entityType, [])

    def clearEntityCache(self):
        self.entityCache = {}  # Clear the entity cache
        print('Entity cache cleared.')

    async def fetchEntityDataFromFile(self, filePath):
        # Simulate file fetching
        # You can replace this with actual file fetching logic
        print(f"Fetching entity data from file: {filePath}")
        # Assuming filePath is the path to a JSON file
        with open(filePath, 'r') as file:
            data = json.load(file)
        return data

    async def loadEntitiesFromFile(self, entityType, filePath):
        return await self.loadEntityData(entityType, lambda: self.fetchEntityDataFromFile(filePath))

    async def loadEntitiesFromDatabase(self, entityType, databaseQuery):
        # Implement database loading logic here
        # Example: data = await database.query(databaseQuery)
        # Ensure to return data in the expected format
        pass

    # Other methods for dynamic entity management, integration with other systems, etc.


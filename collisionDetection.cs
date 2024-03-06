// "Collision Detection created and maintained by AI in C# for a text-based game called Psychosis."
using System;
namespace Psychosis
{
    public static class CollisionDetection
    {
        public static bool CheckCollision(Entity entity1, Entity entity2)
        {
            // Implement the collision detection logic using the entities' properties
            // For example, you can use the entities' positions and bounding boxes for collision detection
            // Example collision detection logic using bounding boxes
            var entity1X = entity1.Position.X;
            var entity1Y = entity1.Position.Y;
            var entity1Width = entity1.BoundingBox.Width;
            var entity1Height = entity1.BoundingBox.Height;

            var entity2X = entity2.Position.X;
            var entity2Y = entity2.Position.Y;
            var entity2Width = entity2.BoundingBox.Width;
            var entity2Height = entity2.BoundingBox.Height;

            // Check for collision using the Axis-Aligned Bounding Box (AABB) collision detection algorithm
            if (
                    entity1X < entity2X + entity2Width && entity1X + entity1Width > entity2X &&
                    entity1Y < entity2Y + entity2Height && entity1Y + entity1Height > entity2Y
                )
            {
                // Collision detected
                return true;
            }
            else
            {
                // No collision
                return false;
            }
        }


        public static bool CheckCollision(Entity entity, Obstacle obstacle)
        {
            // Implement the collision detection logic using the entity and obstacle properties
            // For example, you can use the entity's and obstacle's positions and bounding boxes for collision detection
            // Example collision detection logic using bounding boxes
            var entityX = entity.Position.X;
            var entityY = entity.Position.Y;
            var entityWidth = entity.BoundingBox.Width;
            var entityHeight = entity.BoundingBox.Height;

            var obstacleX = obstacle.Position.X;
            var obstacleY = obstacle.Position.Y;
            var obstacleWidth = obstacle.BoundingBox.Width;
            var obstacleHeight = obstacle.BoundingBox.Height;

            // Check for collision using the Axis-Aligned Bounding Box (AABB) collision detection algorithm
            if (
                    entityX < obstacleX + obstacleWidth && entityX + entityWidth > obstacleX &&
                    entityY < obstacleY + obstacleHeight && entityY + entityHeight > obstacleY
                )
            {
                // Collision detected
                return true;
            }
            else
            {
                // No collision
                return false;
            }
        }


        public static bool CheckCollision(Entity entity, Structure structure)
        {
            // Implement the collision detection logic using the entity and structure properties
            // For example, you can use the entity's and structure's positions and bounding boxes for collision detection
            // Example collision detection logic using bounding boxes
            var entityX = entity.Position.X;
            var entityY = entity.Position.Y;
            var entityWidth = entity.BoundingBox.Width;
            var entityHeight = entity.BoundingBox.Height;

            var structureX = structure.Position.X;
            var structureY = structure.Position.Y;
            var structureWidth = structure.BoundingBox.Width;
            var structureHeight = structure.BoundingBox.Height;

            // Check for collision using the Axis-Aligned Bounding Box (AABB) collision detection algorithm
            if (
                    entityX < structureX + structureWidth && entityX + entityWidth > structureX &&
                    entityY < structureY + structureHeight && entityY + entityHeight > structureY
                )
            {
                // Collision detected
                return true;
            }
            else
            {
                // No collision
                return false;
            }
        }


        public static bool CheckCollision(Entity entity, Projectile projectile)
        {
            // Implement the collision detection logic using the entity and projectile properties
            // For example, you can use the entity's and projectile's positions and bounding boxes for collision detection
            // Example collision detection logic using bounding boxes
            var entityX = entity.Position.X;
            var entityY = entity.Position.Y;
            var entityWidth = entity.BoundingBox.Width;
            var entityHeight = entity.BoundingBox.Height;

            var projectileX = projectile.Position.X;
            var projectileY = projectile.Position.Y;
            var projectileWidth = projectile.BoundingBox.Width;
            var projectileHeight = projectile.BoundingBox.Height;

            // Check for collision using the Axis-Aligned Bounding Box (AABB) collision detection algorithm
            if (
                    entityX < projectileX + projectileWidth && entityX + entityWidth > projectileX &&
                    entityY < projectileY + projectileHeight && entityY + entityHeight > projectileY
                )
            {
                // Collision detected
                return true;
            }
            else
            {
                // No collision
                return false;
            }
        }

    }
}
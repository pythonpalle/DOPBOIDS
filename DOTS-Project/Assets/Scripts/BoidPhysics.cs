using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoidPhysics
{
    public static Vector2 GetAverageBoidVector(BoidEntity boid, bool comparePosition, float maxDistance = 2f, int maxCapacity = 10)
    {
        float maxSquareDistance = maxDistance * maxDistance;

        var boidPos = boid.Position;

        var averagePos = Vector2.zero;
        int count = 0;

        foreach (var otherBoid in BoidManager.Instance.Boids)
        {
            if (count > maxCapacity - 1)
                break;

            if (otherBoid == boid)
                continue;
            
            if (SquareDistance(boidPos, otherBoid.Position) < maxSquareDistance)
            {
                if (comparePosition)
                {
                    averagePos += otherBoid.Position;
                }
                else
                {
                    averagePos += otherBoid.Heading;
                }
                
                count++;
            }
        }

        if (count == 0)
            return Vector2.zero;
        
        return averagePos/count;
    }
    
    public static Vector2 GetAverageBoidVectorFromGrid(BoidEntity boid, bool comparePosition, float maxDistance = 2f)
    {
        var nearbyBoids = GridManager.Instance.GetNearbyBoids(boid.Position);

        if (nearbyBoids.Count == 0)
            return Vector2.zero; 

        var averageVector = Vector2.zero;
        foreach (var otherBoid in nearbyBoids)
        {
            if (comparePosition)
            {
                averageVector += otherBoid.Position;
            }
            else
            {
                averageVector += otherBoid.Heading;
            }
        }

        return averageVector / nearbyBoids.Count;
    }

    public static float SquareDistance(Vector2 a, Vector2 b)
    {
        float dX = b.x - a.x;
        float dY = b.y - a.y;

        return dX * dX + dY * dY;
    }
    
    


}

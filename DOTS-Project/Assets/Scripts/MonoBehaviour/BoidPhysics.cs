using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoidPhysics
{
    
    public static Vector2 GetAverageBoidVectorFromGrid(BoidEntity boid, bool comparePosition)
    {
        var nearbyBoids = GridManager.Instance.GetNearbyBoids3x3(boid.Position);

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

    public static Vector2 GetAverageBoidVectorFromGrid(Vector2 boidPos, bool comparePosition)
    {
        return GridManager.Instance.GetAverageVector(boidPos, comparePosition, 2);
    }

    public static float SquareDistance(Vector2 a, Vector2 b)
    {
        float dX = b.x - a.x;
        float dY = b.y - a.y;

        return dX * dX + dY * dY;
    }
    
    


}

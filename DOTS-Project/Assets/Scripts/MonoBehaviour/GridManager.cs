using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float gridSize = 1.0f;
    private Dictionary<Vector2Int, List<BoidEntity>> grid = new Dictionary<Vector2Int, List<BoidEntity>>();

    [SerializeField] private BoidEntitySet _entitySet;
    
    public static GridManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        
        InvokeRepeating("SetupGrid", 1f, 1f);
    }

    private void OnDrawGizmos()
    {
        if (grid.Count == 0) return;
        
        foreach (var vector in grid.Keys)
        {
            Vector3 center = new Vector3(vector.x, vector.y, 0);
            Gizmos.DrawCube(center, Vector3.one * gridSize);
        }
    }

    public void SetupGrid()
    {
        grid.Clear();

        foreach (var boid in _entitySet.Boids)
        {
            Vector2Int cell = WorldToGrid(boid.Position);
            if (!grid.ContainsKey(cell))
            {
                grid[cell] = new List<BoidEntity>();
            }

            grid[cell].Add(boid);
        }
    }

    private Vector2Int WorldToGrid(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSize);
        int y = Mathf.FloorToInt(worldPosition.y / gridSize);
        return new Vector2Int(x, y);
    }

    public List<BoidEntity> GetNearbyBoids3x3(Vector3 position)
    {
        Vector2Int cell = WorldToGrid(position);
        List<BoidEntity> nearbyBoids = new List<BoidEntity>();

        for (int xOffset = -1; xOffset <= 1; xOffset++)
        {
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                Vector2Int neighborCell = cell + new Vector2Int(xOffset, yOffset);
                if (grid.ContainsKey(neighborCell))
                {
                    nearbyBoids.AddRange(grid[neighborCell]);
                }
            }
        }

        return nearbyBoids;
    }

    public Vector2 GetAverageVector(Vector3 position, bool usePosition, int offset = 1)
    {
        Vector2Int cell = WorldToGrid(position);
        Vector2 average = Vector2.zero;

        int count = 0;
        
        for (int xOffset = -offset; xOffset <= offset; xOffset++)
        {
            for (int yOffset = -offset; yOffset <= offset; yOffset++)
            {
                Vector2Int neighborCell = cell + new Vector2Int(xOffset, yOffset);
                if (grid.ContainsKey(neighborCell))
                {
                    foreach (var boid in grid[neighborCell])
                    {
                        if (usePosition)
                        {
                            average += boid.Position;
                        }
                        else
                        {
                            average += boid.Heading;
                        }

                        count++;
                    }
                }
            }
        }

        if (count == 0)
            return Vector2.zero;
        else
            return average / count;
    }
}

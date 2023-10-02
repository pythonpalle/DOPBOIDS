using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float gridSize = 1.0f;
    private Dictionary<Vector2Int, List<BoidEntity>> grid;

    [SerializeField] private BoidEntitySet _entitySet;
    
    public static GridManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetupGrid()
    {
        grid = new Dictionary<Vector2Int, List<BoidEntity>>();

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

    public List<BoidEntity> GetNearbyBoids(Vector3 position)
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
}

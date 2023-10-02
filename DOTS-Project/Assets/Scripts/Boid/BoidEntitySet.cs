using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid Entity Set")]
public class BoidEntitySet : ScriptableObject
{
    [SerializeField] private BoidEntity boidEntityPrefab;
    public BoidEntity BoidEntityPrefab => boidEntityPrefab;
    private List<BoidEntity> _boids = new List<BoidEntity>();
    public List<BoidEntity> Boids => _boids;

    public void ClearAgents()
    {
        _boids.Clear();
    }

    public void AddAgent(BoidEntity boidEntity)
    {
        _boids.Add(boidEntity);
    }
}
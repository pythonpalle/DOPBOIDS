using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    [Header("Boid Set")]
    [SerializeField] private BoidEntitySet _boidEntitySet;
    
    [Header("Boid Rules")]
    [SerializeField] private BoidRuleContainer ruleContainer;
    
    public static BoidManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Dictionary<Collider2D, BoidEntity> colliderEntities { get; private set; } =
        new Dictionary<Collider2D, BoidEntity>();

    public List<BoidEntity> Boids { get; private set; } = new List<BoidEntity>();

    public void BuildBoidDictionary()
    {
        foreach (var boid in _boidEntitySet.Boids)
        {
            colliderEntities.Add(boid.Collider, boid);
            Boids.Add(boid);
        }
        
        Debug.Log("Entities: " + colliderEntities.Count); 
    }

    private void FixedUpdate()
    {
        foreach (var ruleConfiguration in ruleContainer.RuleConfigurations)
        {
            if (!ruleConfiguration.active)
                continue;
            
            foreach (var boid in _boidEntitySet.Boids)
            {
                ruleConfiguration.rule.UpdateBoid(boid);
            }
        }
    }
}

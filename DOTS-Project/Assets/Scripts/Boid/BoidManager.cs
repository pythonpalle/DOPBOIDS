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

    public List<BoidEntity> Boids { get; private set; } = new List<BoidEntity>();

    public void BuildBoidDictionary()
    {
        Boids = new List<BoidEntity>(_boidEntitySet.Boids);
    }

    private void Update()
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

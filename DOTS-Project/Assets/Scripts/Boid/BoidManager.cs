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

    private void FixedUpdate()
    {
        foreach (var rule in ruleContainer.Rules)
        {
            foreach (var boid in _boidEntitySet.Boids)
            {
                rule.UpdateBoid(boid);
            }
        }
    }
}

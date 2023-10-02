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
        foreach (var ruleConfiguration in ruleContainer.RuleConfigurations)
        {
            if (!ruleConfiguration.active)
                continue;

            int ruleCount = ruleContainer.ActiveRuleCount;
            
            foreach (var boid in _boidEntitySet.Boids)
            {
                ruleConfiguration.rule.UpdateBoid(boid, ruleCount);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    [Header("Boid Set")]
    [SerializeField] private BoidEntitySet _boidEntitySet;
    
    [Header("Boid Rules")]
    [SerializeField] private List<BoidRule> boidRules = new List<BoidRule>();

    private void Update()
    {
        foreach (var rule in boidRules)
        {
            foreach (var boid in _boidEntitySet.Boids)
            {
                rule.UpdateBoid(boid);
            }
        }
    }
}

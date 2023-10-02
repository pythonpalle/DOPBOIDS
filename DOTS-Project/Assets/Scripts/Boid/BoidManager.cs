using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    [SerializeField] private List<BoidRule> boidRules = new List<BoidRule>();
    [SerializeField] private BoidEntitySet _boidEntitySet;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Cohesion")]
public class BoidCohesion : BoidRule
{
    [SerializeField] private float maxRotationSpeed = 10f;

    public override void UpdateBoid(BoidEntity boid)
    {
        UpdateBoidRotationFromAverageVector(boid, maxRotationSpeed, true);
    }
}

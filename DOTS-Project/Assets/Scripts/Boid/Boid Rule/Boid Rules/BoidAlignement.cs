using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Alignment")]
public class BoidAlignement : BoidRule
{
    [SerializeField] private float maxRotationSpeed = 10f;
    
    public override void UpdateBoid(BoidEntity boid)
    {
        UpdateBoidRotationFromAverageVector(boid, maxRotationSpeed, false);
    }
}

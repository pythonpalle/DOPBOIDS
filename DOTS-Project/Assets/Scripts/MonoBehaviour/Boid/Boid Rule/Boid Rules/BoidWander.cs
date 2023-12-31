using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Wander")]
public class BoidWander : BoidRule
{
    [SerializeField] private float pushForce = 0.15f;
    [SerializeField] private float maxTurnAngle = 0.5f;
    
    public override void UpdateBoid(BoidEntity boid)
    {
        float turnAngle = Random.Range(-maxTurnAngle, maxTurnAngle);
        boid.Rotation = Quaternion.RotateTowards(boid.Rotation, Quaternion.Euler(0, 0, turnAngle) * boid.Rotation, 
            GetWeightedTorque(maxTurnAngle*Time.deltaTime));
        
        boid.transform.position += (Vector3)boid.Heading * GetWeightedForce(pushForce) * Time.deltaTime;
    }
} 

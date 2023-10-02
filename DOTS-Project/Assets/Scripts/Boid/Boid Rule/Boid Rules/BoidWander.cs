using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Wander")]
public class BoidWander : BoidRule
{
    [SerializeField] private float pushForce = 1.5f;
    [SerializeField] private float maxTurnAngle = 0.5f;
    
    public override void UpdateBoid(BoidEntity boid, int ruleCount)
    {
        var force = pushForce * boid.Heading;
        boid.Rigidbody.AddForce(force / ruleCount);

        float turnAngle = Random.Range(-maxTurnAngle, maxTurnAngle);
        boid.Rigidbody.AddTorque(turnAngle / ruleCount); 
    }
}

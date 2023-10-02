using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Wander")]
public class BoidWander : BoidRule
{
    [SerializeField] private float pushForce = 1.5f;
    [SerializeField] private float maxTurnAngle = 0.5f;
    
    public override void UpdateBoid(BoidEntity boid)
    {
        var force = pushForce * boid.Heading;
        boid.Rigidbody.AddForce(GetWeightedForce(force));
        //boid.transform.position += boid.transform.right * Time.fixedDeltaTime;

        float turnAngle = Random.Range(-maxTurnAngle, maxTurnAngle);
        boid.Rigidbody.AddTorque(GetWeightedTorque(turnAngle)); 
    }
}

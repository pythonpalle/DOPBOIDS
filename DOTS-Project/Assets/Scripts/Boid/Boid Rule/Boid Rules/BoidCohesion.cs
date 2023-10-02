using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Cohesion")]
public class BoidCohesion : BoidRule
{
    [SerializeField] private float neighbourRadius = 1f;
    
    [SerializeField] private float maxRotationSpeed = 10f;
    [SerializeField] private float rotationDamping = 1;
    [SerializeField] private float pushForce = 1;

    public override void UpdateBoid(BoidEntity boid, int ruleCount)
    {
        var neighbours = Physics2D.CircleCastAll(boid.Position, neighbourRadius, Vector2.up);

        Vector2 averagePosition = Vector2.zero;
        int neighbourCount = 0;
        
        foreach (var neighbour in neighbours)
        {
            BoidEntity neighbourBoid = neighbour.collider.GetComponent<BoidEntity>();
            if (neighbourBoid && neighbourBoid != boid)
            {
                averagePosition += neighbourBoid.Heading;
                neighbourCount++;
            }
        }

        if (neighbourCount <= 0) 
            return;

        averagePosition /= neighbourCount;

        var directionToAverage = averagePosition - boid.Position;
        
        float angle = Vector2.SignedAngle(boid.Heading, directionToAverage);

        float desiredVelocity = angle * maxRotationSpeed;
        Rigidbody2D rb = boid.Rigidbody;
        
        float torque = rb.inertia * Mathf.Clamp(desiredVelocity - rb.angularVelocity, -maxRotationSpeed, maxRotationSpeed);
        
        float dampModifier = rb.angularVelocity > 1 ? rb.angularVelocity : 1;
        
        torque /= (rotationDamping * dampModifier);

        const float epsilon = 0.001f;
        if (Mathf.Abs(torque) > epsilon)
        {
            boid.Rigidbody.AddTorque(torque / ruleCount);
        }
        

        boid.Rigidbody.AddForce(boid.Heading * pushForce / ruleCount);
    }
}

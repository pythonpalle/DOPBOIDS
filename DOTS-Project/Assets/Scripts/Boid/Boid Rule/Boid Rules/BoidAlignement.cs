using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Alignment")]
public class BoidAlignement : BoidRule
{
    [SerializeField] private float neighbourRadius = 1f;
    [SerializeField] private float maxRotationSpeed = 10f;
    [SerializeField] private float rotationDamping = 1;
    [SerializeField] private float pushForce = 0.2f;
    
    
    public override void UpdateBoid(BoidEntity boid)
    {
        var neighbours = Physics2D.CircleCastAll(boid.Position, neighbourRadius, Vector2.up);

        Vector2 averageHeading = Vector2.zero;
        int neighbourCount = 0;
        
        foreach (var neighbour in neighbours)
        {
            BoidEntity neighbourBoid = neighbour.collider.GetComponent<BoidEntity>();
            if (neighbourBoid && neighbourBoid != boid)
            {
                averageHeading += neighbourBoid.Heading;
                neighbourCount++;
            }
        }

        if (neighbourCount <= 0) 
            return;
        
        averageHeading.Normalize();
        float angle = Vector2.SignedAngle(boid.Heading, averageHeading);

        float desiredVelocity = angle * maxRotationSpeed;
        Rigidbody2D rb = boid.Rigidbody;
        
        float torque = rb.inertia * Mathf.Clamp(desiredVelocity - rb.angularVelocity, -maxRotationSpeed, maxRotationSpeed);
        
        float dampModifier = rb.angularVelocity > 1 ? rb.angularVelocity : 1;
        
        torque /= (rotationDamping * dampModifier);

        const float epsilon = 0.001f;
        if (Mathf.Abs(torque) > epsilon)
        {
            boid.Rigidbody.AddTorque(torque);
        }
        
        boid.Rigidbody.AddForce(pushForce * boid.Heading);
    }
}

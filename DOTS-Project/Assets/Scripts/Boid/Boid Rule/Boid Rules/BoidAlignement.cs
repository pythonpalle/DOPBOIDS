using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Alignment")]
public class BoidAlignement : BoidRule
{
    [SerializeField] private float neighbourRadius = 1f;
    [SerializeField] private float rotationSpeed = 20f;
    
    
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

        var boidTransform = boid.transform;
        var boidRotation = boidTransform.rotation;

        averageHeading.Normalize();
        float angle = Vector2.SignedAngle(boid.Heading, averageHeading);
        float rotationStep = rotationSpeed * Time.deltaTime;
        boidTransform.rotation = Quaternion.RotateTowards(boidRotation,
            Quaternion.Euler(0, 0, angle) * boidRotation, rotationStep);
    }
}

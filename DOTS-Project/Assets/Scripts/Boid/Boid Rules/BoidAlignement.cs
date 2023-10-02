using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAlignement : BoidRule
{
    [SerializeField] private float neighbourRadius = 3f;
    [SerializeField] private float rotationSpeed = 2f;
    
    
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
        float rotationStep = rotationSpeed * Time.deltaTime;
        boid.transform.rotation = Quaternion.RotateTowards(boid.transform.rotation,
            Quaternion.Euler(0, 0, angle) * transform.rotation, rotationStep);
    }
}

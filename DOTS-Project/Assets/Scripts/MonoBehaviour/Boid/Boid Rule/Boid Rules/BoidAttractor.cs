using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Attractor")]
public class BoidAttractor : BoidRule
{
    [SerializeField] private float pushForce = 0.15f;
    [SerializeField] private float maxTurnAngle = 0.5f;
    [SerializeField] private float offset = 1f;
    
    public override void UpdateBoid(BoidEntity boid)
    {
        var boidPos = boid.Position;

        bool outSideOfScreen = (boidPos.x < ScreenManager.Instance.BottomLeft.x - offset ||
                                boidPos.x > ScreenManager.Instance.TopRight.x + offset ||
                                boidPos.y < ScreenManager.Instance.BottomLeft.y - offset ||
                                boidPos.y > ScreenManager.Instance.TopRight.y + offset);
        if (outSideOfScreen)
        {
            var boidToMid = (ScreenManager.Instance.Mid - boidPos).normalized;
            
            float angle = Vector2.SignedAngle(boid.Heading, boidToMid);
            boid.Rotation = Quaternion.RotateTowards(boid.Rotation, Quaternion.Euler(0, 0, angle) * boid.Rotation, 
                maxTurnAngle*Time.deltaTime);
            
            boid.transform.position += (Vector3)boidToMid * GetWeightedForce(pushForce) * Time.deltaTime;
        }
    }
}

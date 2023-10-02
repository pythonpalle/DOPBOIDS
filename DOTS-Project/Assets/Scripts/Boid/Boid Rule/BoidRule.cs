using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoidRule : ScriptableObject
{
   [SerializeField] private float weight = 1;
   public abstract void UpdateBoid(BoidEntity boid);

   protected float GetWeightedTorque(float inTorque)
   {
      return inTorque * weight;
   }
   
   protected Vector2 GetWeightedForce(Vector2 inForce)
   {
      return inForce * weight;
   }
   
   protected void UpdateBoidRotationFromAverageVector(BoidEntity boid, float maxRotSpeed, bool checkPosition)
   {
      Vector2 averageVector = GetAverageFromNearbyBoids(boid, false);
      if (averageVector == Vector2.zero)
         return;

      float angle;
      if (checkPosition)
      {
         var directionToMid = averageVector - boid.Position;
         angle = Vector2.SignedAngle(boid.Heading, directionToMid);
      }
      else
      {
         angle = Vector2.SignedAngle(boid.Heading, averageVector);
      }

      float step = maxRotSpeed * Time.deltaTime;
      boid.Rotation = Quaternion.RotateTowards(boid.Rotation, Quaternion.Euler(0, 0, angle) * boid.Rotation, step);
   }

   private Vector2 GetAverageFromNearbyBoids(BoidEntity boid, bool checkPosition)
   {
      return BoidPhysics.GetAverageBoidVectorFromGrid(boid, checkPosition);
   }
}

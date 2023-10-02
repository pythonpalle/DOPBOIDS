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

   protected Vector2 GetAverageFromNearbyBoids(BoidEntity boid, float neighbourRadius, bool checkPosition)
   {
      bool useMyPhysics = true;
      
      if (useMyPhysics)
      {
         return BoidPhysics.GetAverageBoidVectorFromGrid(boid, checkPosition, neighbourRadius);
         //return BoidPhysics.GetAverageBoidVector(boid, checkPosition, neighbourRadius);
      }
      else
      {
         Vector2 averageVector = Vector2.zero;

         var neighbours = Physics2D.OverlapCircleAll(boid.Position, neighbourRadius);
         int neighbourCount = 0;
      
         var boidDictionary = BoidManager.Instance.colliderEntities;
         foreach (var neighbour in neighbours)
         {
            if (neighbourCount >= 10)
               break;
            
            BoidEntity neighbourBoid = boidDictionary[neighbour];
            
            if (neighbourBoid && neighbourBoid != boid)
            {
               if (checkPosition)
               {
                  averageVector += neighbourBoid.Position;
               }
               else
               {
                  averageVector += neighbourBoid.Heading;
               }
            
               neighbourCount++;
            }
         }
      
         if (neighbourCount <= 0) 
            return Vector2.zero;

         return averageVector / neighbourCount;
      }
   }
}

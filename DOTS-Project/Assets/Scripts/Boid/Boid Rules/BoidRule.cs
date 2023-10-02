using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoidRule : MonoBehaviour
{
   // public void UpdateBoids(List<BoidEntity> boids)
   // {
   //    foreach (var boid in boids)
   //    {
   //       UpdateBoid(boid);
   //    }
   // }

   public abstract void UpdateBoid(BoidEntity boid);
}

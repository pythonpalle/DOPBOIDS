using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoidRule : ScriptableObject
{
   
   public abstract void UpdateBoid(BoidEntity boid);
}

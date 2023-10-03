using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[CreateAssetMenu(menuName = "Rules/Separation")]
public class BoidSeparation : BoidRule
{
    public override void UpdateBoid(BoidEntity boid)
    {
        // Profiler.BeginSample("Separation");
        //
        // var boidsInRange = BoidManager.Instance.Boids.FindAll(b => b != boid &&
        //                                                            (boid.Position - b.Position).magnitude < 1f);
        //
        // Profiler.EndSample();
    }
}

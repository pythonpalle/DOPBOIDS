using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Wander")]
public class BoidWander : BoidRule
{
    [SerializeField] private float pushForce;
    
    public override void UpdateBoid(BoidEntity boid)
    {
        var force = pushForce * boid.Heading;
        boid.Rigidbody.AddForce(force);
        
        Debug.Log("Force: " + force);
        Debug.Log("Magnitude: " + force.magnitude);
    }
}

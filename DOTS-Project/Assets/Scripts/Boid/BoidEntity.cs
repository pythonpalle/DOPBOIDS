using UnityEngine;

public class BoidEntity : MonoBehaviour
{
    public Vector2 Position => transform.position;
    // public Quaternion Rotation => transform.rotation;
    // public float ZOrientation => transform.rotation.eulerAngles.z;

    public Vector2 Heading => transform.up;
}
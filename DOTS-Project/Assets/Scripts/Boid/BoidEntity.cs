using System;
using UnityEngine;

public class BoidEntity : MonoBehaviour
{
    public Vector2 Position => transform.position;

    public Vector2 Heading => transform.right;

    public Quaternion Rotation
    {
        get => transform.rotation;
        set => transform.rotation = value;
    }
}
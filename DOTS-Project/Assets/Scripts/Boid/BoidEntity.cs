using UnityEngine;

public class BoidEntity : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody => _rigidbody;
    
    public Vector2 Position => transform.position;

    public Vector2 Heading => transform.right;
}
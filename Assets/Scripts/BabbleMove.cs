using UnityEngine;

public class BabbleMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _babbleRb;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _distanceToDestroy;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _babbleRb.velocity=new Vector2(_direction.x ,_direction.y);
        
        if (transform.position.x < _distanceToDestroy)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

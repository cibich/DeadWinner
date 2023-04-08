using UnityEngine;

public class SwimPrefab : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _raftRb;
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _raftRb.velocity = new Vector2(_speed, _raftRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && transform.position.x > 0)
            _speed = -_speed;

        else if (collision.gameObject.CompareTag("Ground") && transform.position.x < 0)
            _speed = -_speed;

        if (collision.gameObject.CompareTag("Raft"))
        {
            _speed = -_speed;
        }
    }
}

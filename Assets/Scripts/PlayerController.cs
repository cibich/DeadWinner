using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _springForce;
    private bool _isJumpSpring=false;
    private bool _isOnGround = true;

    [SerializeField] private GameObject _deathPrefab;
    [SerializeField] private GameObject _raftPrefab;
    [SerializeField] private GameObject _flyBabblePrefab;

    [SerializeField] private Door _door;

    private void Start()
    {
        _door=FindObjectOfType<Door>();
    }

    private void Update()
    {
        Movement();
        Jump();
        JumpSpring(_isJumpSpring);
    }

    private void Movement()
    {
        _playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _playerRb.velocity.y);
    }

    private void Jump()
    {
        if (_isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            _playerRb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isOnGround = false;
        }
    }

    private void JumpSpring(bool isJump)
    {
        _isJumpSpring= isJump;
        if (_isJumpSpring)
        {
            _playerRb.AddForce(Vector2.up * _springForce,ForceMode2D.Impulse);
            _isJumpSpring= false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Pike"))
        {
            Instantiate(_deathPrefab, transform.position, Quaternion.identity);
            transform.position=_startPosition; 
        }

        if (collision.gameObject.CompareTag("DeathPrefab"))
        {
            _isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Raft"))
        {
            _isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Babble"))
        {
            Instantiate(_flyBabblePrefab, transform.position, Quaternion.identity);
            transform.position=_startPosition;
        }

        if (collision.gameObject.CompareTag("FlyBabble"))
        {
            JumpSpring(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            _door.OpenDoor();
        }

        if (collision.CompareTag("Spring"))
        {
            JumpSpring(true);
        }

        if (collision.CompareTag("Water"))
        {
            Instantiate(_raftPrefab, transform.position, Quaternion.identity);
            transform.position = _startPosition;
        }
    }
}

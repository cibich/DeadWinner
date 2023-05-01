using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _springForce;
    private int _deathCount;
    private bool _isJumpSpring = false;
    private bool _isOnGround = true;

    [SerializeField] private GameObject _deathPrefab;
    [SerializeField] private GameObject _raftPrefab;
    [SerializeField] private GameObject _flyBabblePrefab;

    [SerializeField] private Door _door;

    [Header("Sound")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _jumpBubbleSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _deathBubbleSound;
    [SerializeField] private AudioClip _takeKeySound;

    [Header("Animation")]
    [SerializeField] private Animator _animPlayer;

    [Header("Ui")]
    [SerializeField] private Text _textDeathCount;

    private void Start()
    {
        _door = FindObjectOfType<Door>();
    }

    private void Update()
    {
        JumpSpring(_isJumpSpring);
    }

    public void StopMove()
    {
        _playerRb.velocity = new Vector2(0, _playerRb.velocity.y);
        _animPlayer.SetBool("IsRun", false);
    }

    public void MoveLeft()
    {
        _playerRb.velocity = new Vector2(-_speed, _playerRb.velocity.y);
        _playerSprite.flipX= true;
        _animPlayer.SetBool("IsRun", true);
    }

    public void MoveRight()
    {
        _playerRb.velocity = new Vector2(_speed, _playerRb.velocity.y);
        _playerSprite.flipX = false;
        _animPlayer.SetBool("IsRun", true);
    }

    public void Jump()
    {
        if (_isOnGround)
        {
            _playerRb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isOnGround = false;
            _audioSource.PlayOneShot(_jumpSound, 1f);
        }
    }

    private void JumpSpring(bool isJump)
    {
        _isJumpSpring = isJump;
        if (_isJumpSpring)
        {
            _playerRb.AddForce(Vector2.up * _springForce, ForceMode2D.Impulse);
            _isJumpSpring = false;
            _audioSource.PlayOneShot(_jumpBubbleSound, 1f);
        }
    }

    private void Death(GameObject prefab, AudioClip clip)
    {
        StopMove();
        Instantiate(prefab, transform.position, Quaternion.identity);
        transform.position = _startPosition;
        _audioSource.PlayOneShot(clip, 1f);
        _deathCount++;
        _textDeathCount.text = _deathCount.ToString();
        _door.Save(_deathCount);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Pike"))
        {
            Death(_deathPrefab, _deathSound);
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
            Death(_flyBabblePrefab, _deathBubbleSound);
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
            _audioSource.PlayOneShot(_takeKeySound, 1f);
        }

        if (collision.CompareTag("Spring"))
        {
            JumpSpring(true);
        }

        if (collision.CompareTag("Water"))
        {
            Death(_raftPrefab, _deathSound);
        }
    }
}

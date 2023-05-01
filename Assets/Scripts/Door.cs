using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _doorCollider;
    [SerializeField] private int _keyCount;
    [SerializeField] private int _deathCount;
    [SerializeField] private string _saveNameButton;
    [SerializeField] private string _saveNameMedal;
    [SerializeField] private int _lvl;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _openDoor;
    [SerializeField] private Sprite _closeDoor;

    [SerializeField] private GameObject _panel;

    private void Start()
    {
        _spriteRenderer.sprite = _closeDoor;
        _panel.SetActive(false);
    }

    public void OpenDoor()
    {
        _keyCount++;
        if (_keyCount==3)
            _spriteRenderer.sprite= _openDoor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _keyCount==3)
        {
            _panel.SetActive(true);
            Save();Save(_deathCount);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt(_saveNameButton, _lvl);
    }
    public void Save(int deaths)
    {
        _deathCount = deaths;
        PlayerPrefs.SetInt(_saveNameMedal, _deathCount);
    }
}

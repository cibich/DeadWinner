using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _doorCollider;
    [SerializeField] private int _keyCount;
    [SerializeField] private int _nextLvl;

    public void OpenDoor()
    {
        _keyCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _keyCount==3)
        {
            SceneManager.LoadScene(_nextLvl);
        }
    }
}

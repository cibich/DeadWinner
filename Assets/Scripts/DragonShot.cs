using UnityEngine;

public class DragonShot : MonoBehaviour
{
    [SerializeField] private GameObject _babblePrefab;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Animator _anim;

    private void Start()
    {
        InvokeRepeating("Spawn", 1, 3.5f);
    }

    void Spawn()
    {
        Instantiate(_babblePrefab, _shotPoint.position, Quaternion.identity);
    }
}

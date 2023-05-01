using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speedRotate;

    private void Update()
    {
        transform.Rotate(0, 0, _speedRotate);
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _player.position;
    }

    private void Update()
    {
        transform.position = _player.position + _offset;
    }
}

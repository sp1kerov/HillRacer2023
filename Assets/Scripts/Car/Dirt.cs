using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Dirt : MonoBehaviour
{
    [SerializeField] private Transform _wheel;
    [SerializeField] private Transform _car;
    [SerializeField] private ParticleSystem _dirtParticles;

    private Vector3 _positionOffset;
    private Vector3 _rotationOffset;

    private void Start()
    {
        _positionOffset = transform.position - _wheel.position;
        _rotationOffset = transform.eulerAngles - _car.eulerAngles;
    }

    private void Update()
    {
        FollowWheel();
    }

    private void FollowWheel()
	{
        transform.position = _wheel.position + _positionOffset;
        transform.eulerAngles = _car.eulerAngles + _rotationOffset;
	}
}

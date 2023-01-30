using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WheelJoint2D))]
[RequireComponent(typeof(WheelJoint2D))]
public class CarController : MonoBehaviour
{
    [Header("Required components")]
    [SerializeField] private Rigidbody2D _carRigidbody;
    [SerializeField] private Wheel _driveWheel;
    [SerializeField] private Wheel _secondWheel;

    [Header("Rotation")]
    [SerializeField] private float _onAirRotationSpeed = 8f;
    [SerializeField] private float _onGroundRotationSpeed = 1f;
    [SerializeField] private GameManager _gameManager;

    private float _brakeInput;
    private float _gasInput;
    private float _finalInput;
    private float _brakeRawInput;
    private float _gasRawInput;
    private float _finalRawInput;

    private void Update()
    {
        TakeInput();
    }

    private void FixedUpdate()
    {
        if (_brakeRawInput == 1f && _carRigidbody.velocity.x > 3f)
        {
            Stop();
        }
        else if (_brakeRawInput == 0f && _gasRawInput == 0f || !_gameManager.IsFuel())
        {
            Idle();
        }
        else
        {
            Move();
            Rotate();
        }
    }

    public float GetInput()
    {
        return _finalInput;
    }

    private void TakeInput()
	{
        _brakeInput = PlayerInput.GetDampedBrakeInput();
        _gasInput = -PlayerInput.GetDampedGasInput();
        _brakeRawInput = PlayerInput.GetRawBrakeInput();
        _gasRawInput = -PlayerInput.GetRawGasInput();

        _finalInput = _brakeRawInput > 0f ? _brakeInput : _gasInput;
        _finalRawInput = _brakeRawInput > 0f ? _brakeRawInput : _gasRawInput;
    }

    private void Idle()
    {
        _driveWheel.Idle();
        _secondWheel.Idle();
    }

    private void Stop()
	{
        _driveWheel.Stop();
        _secondWheel.Stop();
	}

    private void Move()
    {
        _driveWheel.Move(_finalInput);
        _secondWheel.Idle();
    }

    private void Rotate()
	{
		if (!OnGround()) _carRigidbody.AddTorque(-_finalRawInput * _onAirRotationSpeed);
		else _carRigidbody.AddTorque(-_finalRawInput * _onGroundRotationSpeed);
	}

    private bool OnGround()
	{
        return _driveWheel.OnGround() || _secondWheel.OnGround();
	}
}

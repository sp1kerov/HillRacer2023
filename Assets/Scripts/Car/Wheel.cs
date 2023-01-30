using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Wheel : MonoBehaviour
{
    enum State
    {
        Moves,
        Braking,
        Idle
    }

    [SerializeField] WheelJoint2D wheelJoint;
    [SerializeField] private ParticleSystem _dirtParticles;

    [Header("Speed and power")]
    [SerializeField] private float _maxSpeed = 1500f;
    [SerializeField] private float _power = 1000f;

    private const string _groundTag = "Ground";

    private State _state = State.Idle;
    private bool _onGround;

    void Update()
    {
        HandleParticles();
    }

    void HandleParticles()
	{
        if (_state == State.Idle || !OnGround()) { _dirtParticles.Stop(); return; }
        else if (OnGround()) _dirtParticles.Play();

		var velocityOverLifetime = _dirtParticles.velocityOverLifetime;
		if (_state == State.Moves)
		{
            if (wheelJoint.motor.motorSpeed < 0)
            {
                velocityOverLifetime.xMultiplier = -7f;
            }
            else if (wheelJoint.motor.motorSpeed > 0)
            {
                velocityOverLifetime.xMultiplier = 7f;
            }
        }
		else if (_state == State.Braking) velocityOverLifetime.xMultiplier = 7f;
	}

    public void Move(float input)
	{
        _state = State.Moves;
        wheelJoint.useMotor = true;
        wheelJoint.motor = new JointMotor2D { motorSpeed = input * _maxSpeed, maxMotorTorque = _power };
    }

    public void Stop()
	{
        _state = State.Braking;
        wheelJoint.useMotor = true;
        wheelJoint.motor = new JointMotor2D { motorSpeed = 0f, maxMotorTorque = _power };
    }

    public void Idle()
    {
        _state = State.Idle;
        wheelJoint.useMotor = false;
    }

    public bool OnGround()
	{
        return _onGround;
	}

    public float GetMaxSpeed()
	{
        return _maxSpeed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag(_groundTag))
		{
            _onGround = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.transform.CompareTag(_groundTag))
        {
            _onGround = false;
        }
    }
}

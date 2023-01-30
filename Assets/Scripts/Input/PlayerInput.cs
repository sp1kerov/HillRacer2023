using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private TouchDetector _buttonBrake;
	[SerializeField] private TouchDetector _buttonGas;
	[SerializeField] private float _brakeSmoothTime = 0.1f;
	[SerializeField] private float _gasSmoothTime = 0.1f;

    private bool _isAndroid = true;
    private static float _rawBrakeInput;
    private static float _rawGasInput;
    private static float _dampedBrakeInput;
    private static float _dampedGasInput;

	void Update()
	{
#if UNITY_EDITOR
        KeyboardInput();
#endif
        if (_isAndroid == true)
        {
            TouchInput();
        }
    }

    private void KeyboardInput()
	{
        _isAndroid = false;
        if (Input.GetKey(KeyCode.A))
        {
            _rawBrakeInput = 1f;
            _dampedBrakeInput = ValueDamper.Damp(_dampedBrakeInput, _rawBrakeInput, _brakeSmoothTime);
        }
        else
        {
            _rawBrakeInput = 0f;
            _dampedBrakeInput = ValueDamper.Damp(_dampedBrakeInput, _rawBrakeInput, _brakeSmoothTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rawGasInput = 1f;
            _dampedGasInput = ValueDamper.Damp(_dampedGasInput, _rawGasInput, _gasSmoothTime);
        }
        else
        {
            _rawGasInput = 0f;
            _dampedGasInput = ValueDamper.Damp(_dampedGasInput, 0f, _gasSmoothTime);
        }
    }

    private void TouchInput()
    {
        if (_buttonBrake.IsTouched())
        {
            _rawBrakeInput = 1f;
            _dampedBrakeInput = ValueDamper.Damp(_dampedBrakeInput, _rawBrakeInput, _brakeSmoothTime);
        }
        else
        {
            _rawBrakeInput = 0f;
            _dampedBrakeInput = ValueDamper.Damp(_dampedBrakeInput, _rawBrakeInput, _brakeSmoothTime);
        }

        if (_buttonGas.IsTouched())
        {
            _rawGasInput = 1f;
            _dampedGasInput = ValueDamper.Damp(_dampedGasInput, _rawGasInput, _gasSmoothTime);
        }
        else
        {
            _rawGasInput = 0f;
            _dampedGasInput = ValueDamper.Damp(_dampedGasInput, 0f, _gasSmoothTime);
        }
    }

    public static float GetDampedBrakeInput()
	{
        return _dampedBrakeInput;
	}

	public static float GetDampedGasInput()
	{
        return _dampedGasInput;
	}

	public static float GetRawBrakeInput()
	{
        return _rawBrakeInput;
	}

	public static float GetRawGasInput()
	{
        return _rawGasInput;
	}
}

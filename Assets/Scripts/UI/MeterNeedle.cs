using UnityEngine;

public class MeterNeedle : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float _multiplier = 0.5f;
    [SerializeField] private float _minRotation = 135f;
    [SerializeField] private float _maxRotation = -135f;
    [SerializeField] private CarController _carController;

    private void Update()
    {
        RotateNeedle(Mathf.Abs(_carController.GetInput()));
    }

    public void RotateNeedle(float percent)
	{
        percent = percent > 1f ? 1f : percent;
        percent = percent < 0f ? 0f : percent;
        transform.eulerAngles = Vector3.forward * (_minRotation + percent * 2f * _maxRotation * _multiplier);
    }
}

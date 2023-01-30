using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
public class LowFuelIndicator : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float _maxWarningLevel = 0.2f;
    [SerializeField] private Image _image;
    [SerializeField] private Animation _blinkingAnimation;
    [SerializeField] private GameManager _gameManger;

    private void Update()
    {
        if (_gameManger.GetFuelLevel() <= _maxWarningLevel && _gameManger.GetFuelLevel() > 0f)
        {
            Blink(true);
        }
        else
        {
            Blink(false);
        }
    }

    private void Blink(bool blink)
    {
        Color color = _image.color;

        if (blink)
		{
            color.a = 0f;
            _blinkingAnimation.Play();
		}
        else
		{
            color.a = 1f;
            _blinkingAnimation.Stop();
		}

        _image.color = color;
    }
}

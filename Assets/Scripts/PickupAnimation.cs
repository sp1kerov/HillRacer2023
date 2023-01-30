using System.Collections;
using UnityEngine;

public class PickupAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private AnimationCurve _verticalMovementCurve;
	[SerializeField] private AnimationCurve _disapperingCurve;

    private bool _started;
    private float _timeElapsed;
    private Vector2 _startPosition;
    private Color _currentColor;

    private void Start()
	{
		_startPosition = transform.localPosition;
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_currentColor = _spriteRenderer.color;
	}

    private void Update()
	{
		if (_started) _timeElapsed += Time.deltaTime;
	}

    public void Play()
	{
		_started = true;
		StartCoroutine(Rise());
		StartCoroutine(Disappear());
	}

    private IEnumerator Rise()
	{
		while (true)
		{
			transform.localPosition = _startPosition + Vector2.up * _verticalMovementCurve.Evaluate(_timeElapsed);
			yield return null;
		}
	}

    private IEnumerator Disappear()
	{
		while (true)
		{
			_currentColor.a = _disapperingCurve.Evaluate(_timeElapsed);
			_spriteRenderer.color = _currentColor;
			yield return null;
		}
	}
}

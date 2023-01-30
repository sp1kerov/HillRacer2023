using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Death : MonoBehaviour
{
	[SerializeField] private float _timeReoledScene = 2f;
	[SerializeField] private UnityEvent _onPlayerDeath;

    private bool _isDie = false;
    private const string _groundTag = "Ground";

    private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag(_groundTag))
		{
			if (_isDie == false)
			{
                StartCoroutine(Die());
                _isDie = true;
            }
        }
    }

    private IEnumerator Die()
	{
		yield return new WaitForSeconds(_timeReoledScene);
		_onPlayerDeath?.Invoke();
	}
}

using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
	[SerializeField] private int _coinValue = 5;
	[SerializeField] private UnityEvent _onnPickupEvent;

    public static Action<int> AddCoin;

    private const string _playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(_playerTag))
		{
            _onnPickupEvent?.Invoke();
            AddCoin?.Invoke(_coinValue);
			Destroy(gameObject, 2f);
		}
	}
}

using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Fuel : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnPickupEvent;

    private const string _playerTag = "Player";

    public static Action PickUpFuel;

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(_playerTag))
		{
            _OnPickupEvent.Invoke();
            PickUpFuel?.Invoke();
            Destroy(gameObject, 2f);
		}
	}
}

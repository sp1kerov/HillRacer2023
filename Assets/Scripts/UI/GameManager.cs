using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private float _fuelUsage = 0.05f;
    [SerializeField] private UIController _uiController;
    [SerializeField] private PanelController _panelController;

    private float _fuelLevel = 1f;
	private const string _keyCoins = "coins";

	private void OnEnable()
	{
		Coin.AddCoin += AddCoins;
		Fuel.PickUpFuel += Refuel;
    }

	private void OnDisable()
	{
		Coin.AddCoin -= AddCoins;
		Fuel.PickUpFuel -= Refuel;
    }

    private void Start()
	{
		Time.timeScale = 0.9f;
		_uiController.UpdateCoins(PlayerPrefs.GetInt(_keyCoins).ToString());
	}

	private void Update()
	{
		UseFuel();
	}

    private void UseFuel()
	{
		_fuelLevel -= _fuelUsage * Time.deltaTime;
		_uiController.UpdateFuelLevel(_fuelLevel);

		if (_fuelLevel <= 0)
		{
			_panelController.OnGameOver();
        }
	}

	public void Refuel()
	{
		_fuelLevel = 1f;
	}

	public float GetFuelLevel()
	{
		return _fuelLevel;
	}

	public bool IsFuel()
	{
		return _fuelLevel > 0 ? true : false;
	}

	public void AddCoins(int coinsToAdd)
	{
		var coins = PlayerPrefs.GetInt(_keyCoins) + coinsToAdd;
		PlayerPrefs.SetInt(_keyCoins, coins);
		_uiController.UpdateCoins(coins.ToString());
	}
}

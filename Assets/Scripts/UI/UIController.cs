using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider _fuelLevelSlider;
    [SerializeField] private TMP_Text _coinsText;

    [Header("Pedals")]
    [SerializeField] private GameObject _imageBrakeNormal;
    [SerializeField] private GameObject _imageBrakePressed;
    [SerializeField] private GameObject _imageGasNorma;
    [SerializeField] private GameObject _imageGasPressed;

    private void Update()
	{
        float brakeInput = PlayerInput.GetRawBrakeInput();
        float gasInput = PlayerInput.GetRawGasInput();

        if (brakeInput > 0)
        {
            DisplayBrakePressed(true);
        }
        else
        {
            DisplayBrakePressed(false);
        }

        if (gasInput > 0)
        {
            DisplayGasPressed(true);
        }
        else
        {
            DisplayGasPressed(false);
        }
    }

    public void UpdateFuelLevel(float newLevel)
	{
        _fuelLevelSlider.value = newLevel;
	}

    public void UpdateCoins(string newScore)
	{
        _coinsText.text = newScore;
	}

	public void DisplayBrakePressed(bool isPressed)
	{
        _imageBrakeNormal.SetActive(!isPressed);
        _imageBrakePressed.SetActive(isPressed);
	}

    public void DisplayGasPressed(bool isPressed)
	{
        _imageGasNorma.SetActive(!isPressed);
        _imageGasPressed.SetActive(isPressed);
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmountCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountCoins;

    private const string _tagCoins = "coins";

    private void Start()
    {
        _amountCoins.text = PlayerPrefs.GetInt(_tagCoins).ToString();
    }
}

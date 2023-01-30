using TMPro;
using UnityEngine;

public class BestDistance : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestDistance;

    private const string _bestDistanceVarName = "BestDistance";

    private void Start()
    {
        _bestDistance.text = PlayerPrefs.GetInt(_bestDistanceVarName) + "ì.";
    }
}

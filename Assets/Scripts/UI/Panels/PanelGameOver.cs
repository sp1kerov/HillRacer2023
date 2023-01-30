using TMPro;
using UnityEngine;

public class PanelGameOver : Panel
{
    [SerializeField] private Distance _distance;
    [SerializeField] private TMP_Text _textDistance;

    private void Start()
    {
        _textDistance.text = _distance.CurrentDistance.ToString();
    }
}

using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Distance : MonoBehaviour
{
    [SerializeField] private Transform _car;
    [SerializeField] private TMP_Text _textDistance;

    private int _traveledDistance = -1;
    private int _currentDistance;
    private int _bestDistance;

    public int CurrentDistance => _currentDistance;

    private const string _bestDistanceVarName = "BestDistance";

    private void Start()
    {
        _bestDistance = PlayerPrefs.GetInt(_bestDistanceVarName, 0);
    }

    private void Update()
    {
        _currentDistance = Mathf.RoundToInt(_car.position.x - Vector2.zero.x);

        if (_traveledDistance < _currentDistance)
        {
            _textDistance.text = _currentDistance.ToString();
            _traveledDistance = _currentDistance;
        }
    }

    public void SaveBestDistance()
	{
        if (_currentDistance > _bestDistance)
        {
            PlayerPrefs.SetInt(_bestDistanceVarName, Mathf.RoundToInt(_currentDistance));
        }
    }
}

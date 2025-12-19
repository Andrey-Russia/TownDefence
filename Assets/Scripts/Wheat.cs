using System.Collections;
using TMPro;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    public TMP_Text WheatText;
    public UnitSpawner UnitSpawner;

    private int _currentWheat = 0;
    private float _productionTimer = 0f;
    private const float _updateInterval = 1f;
    private int _baseProductionRate = 2;
    private const int _maxWheatLimit = 20;

    public int CurrentWheat => _currentWheat;

    void Start()
    {
        UpdateText();
    }

    public bool CanSpend(int amount)
    {
        return _currentWheat >= amount;
    }

    public void SpendWheat(int amount)
    {
        if (CanSpend(amount))
        {
            _currentWheat -= amount;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        WheatText.text = $"ѕшеница: {_currentWheat}";
    }

    void Update()
    {
        _productionTimer += Time.deltaTime;

        if (_productionTimer >= _updateInterval)
        {
            _productionTimer -= _updateInterval;
            int totalProductionRate = (int)(_baseProductionRate + (UnitSpawner.FarmersCount * 1f));
            if (_currentWheat + totalProductionRate <= _maxWheatLimit)
                _currentWheat += Mathf.RoundToInt(totalProductionRate);
            else
                _currentWheat = _maxWheatLimit;

            UpdateText();
        }
    }
}
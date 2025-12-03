using System.Collections;
using TMPro;
using UnityEngine;
public class Wheat : MonoBehaviour
{
    public TMP_Text wheatText;
    public UnitSpawner unitSpawner;

    private int currentWheat = 0;
    private float productionTimer = 0f;
    private const float updateInterval = 1f;
    private int baseProductionRate = 2;
    private const int maxWheatLimit = 20;

    public int CurrentWheat => currentWheat;

    void Start()
    {
        UpdateText();
    }

    public bool CanSpend(int amount)
    {
        return currentWheat >= amount;
    }

    public void SpendWheat(int amount)
    {
        if (CanSpend(amount))
        {
            currentWheat -= amount;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        wheatText.text = $"ѕшеница: {currentWheat}";
    }

    void Update()
    {
        productionTimer += Time.deltaTime;

        if (productionTimer >= updateInterval)
        {
            productionTimer -= updateInterval;
            int totalProductionRate = (int)(baseProductionRate + (unitSpawner.FarmersCount * 0.5f));
            if (currentWheat + totalProductionRate <= maxWheatLimit)
                currentWheat += Mathf.RoundToInt(totalProductionRate);
            else
                currentWheat = maxWheatLimit; 

            UpdateText();
        }
    }
}

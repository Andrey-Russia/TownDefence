using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public Button FarmerButton;
    public Button WarriorButton;
    public Transform[] SpawnPoints;
    public GameObject FarmerPrefab;
    public GameObject WarriorPrefab;

    private int _maxFarmers = 5;
    private int _maxWarriors = 10;
    private int _farmersCount = 0;
    private int _warriorsCount = 0;
    private Wheat _wheatManager;

    public int FarmersCount => _farmersCount;

    void Start()
    {
        _wheatManager = FindObjectOfType<Wheat>();

        FarmerButton.onClick.AddListener(() =>
        {
            TrySpawnUnit(FarmerPrefab, ref _farmersCount, _maxFarmers, 5);
        });

        WarriorButton.onClick.AddListener(() =>
        {
            TrySpawnUnit(WarriorPrefab, ref _warriorsCount, _maxWarriors, 10);
        });
    }

    private void TrySpawnUnit(GameObject prefab, ref int count, int limit, int cost)
    {
        if (count < limit && _wheatManager.CanSpend(cost))
        {
            Vector3 spawnPosition = GetNearbySpawnPoint();
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            count++;
            _wheatManager.SpendWheat(cost);
        }
        else
        {
            BlockButtonsIfNeeded();
        }
    }

    private Vector3 GetNearbySpawnPoint()
    {
        if (SpawnPoints.Length > 0)
        {
            int index = Random.Range(0, SpawnPoints.Length);
            Transform chosenPoint = SpawnPoints[index];
            float offsetX = Random.Range(-2f, 2f);
            float offsetY = Random.Range(-2f, 2f);

            return chosenPoint.position + new Vector3(offsetX, offsetY, 0f);
        }
        else
        {
            Debug.LogError("Нет доступных точек спавна!");
            return Vector3.zero;
        }
    }

    private void BlockButtonsIfNeeded()
    {
        FarmerButton.interactable = _farmersCount < _maxFarmers && _wheatManager.CurrentWheat >= 5;
        WarriorButton.interactable = _warriorsCount < _maxWarriors && _wheatManager.CurrentWheat >= 10;
    }

    void Update()
    {
        BlockButtonsIfNeeded();
    }
}
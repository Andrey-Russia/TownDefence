using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public Button farmerButton;
    public Button warriorButton;
    public Transform[] spawnPoints;  
    public GameObject farmerPrefab;
    public GameObject warriorPrefab;

    private int maxFarmers = 5;
    private int maxWarriors = 10;
    private int farmersCount = 0;
    private int warriorsCount = 0;

    private Wheat wheatManager;

    public int FarmersCount => farmersCount;

    void Start()
    {
        wheatManager = FindObjectOfType<Wheat>();

        farmerButton.onClick.AddListener(() =>
        {
            TrySpawnUnit(farmerPrefab, ref farmersCount, maxFarmers, 5);
        });

        warriorButton.onClick.AddListener(() =>
        {
            TrySpawnUnit(warriorPrefab, ref warriorsCount, maxWarriors, 10);
        });
    }

    private void TrySpawnUnit(GameObject prefab, ref int count, int limit, int cost)
    {
        if (count < limit && wheatManager.CanSpend(cost))
        {
            Vector3 spawnPosition = GetNearbySpawnPoint();
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            count++;
            wheatManager.SpendWheat(cost);
        }
        else
        {
            BlockButtonsIfNeeded();
        }
    }

    private Vector3 GetNearbySpawnPoint()
    {
        if (spawnPoints.Length > 0)
        {
            int index = Random.Range(0, spawnPoints.Length);
            Transform chosenPoint = spawnPoints[index];
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
        farmerButton.interactable = farmersCount < maxFarmers && wheatManager.CurrentWheat >= 5;
        warriorButton.interactable = warriorsCount < maxWarriors && wheatManager.CurrentWheat >= 10;
    }

    void Update()
    {
        BlockButtonsIfNeeded();
    }
}
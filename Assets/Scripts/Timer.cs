using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform spawnPoint; 
    public float spawnInterval = 10f; 
    public int maxWaves = 10;
    public int enemiesPerWave = 1;
    public GameObject victoryPanel;
    public GameObject gameOverPanel;

    private int currentWave = 1;
    private float nextSpawnTime;
    

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && currentWave <= maxWaves)
        {
            SpawnWave();
            nextSpawnTime = Time.time + spawnInterval;
            currentWave++;
        }

        if (currentWave > maxWaves)
        {
            ShowVictoryPanel();
        }

        if (GameObject.FindGameObjectsWithTag("House").Length == 0)
        {
            ShowGameOverPanel();
        }
    }

    void SpawnWave()
    {
        int enemiesToSpawn = enemiesPerWave * currentWave;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}

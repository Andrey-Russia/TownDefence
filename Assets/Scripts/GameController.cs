using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public TMP_Text timerText;
    public GameObject victoryPanel;
    public int enemiesPerWave = 5;
    public int wavesToWin = 5;

    private float timeRemaining = 30f;
    private int completedWaves = 0;
    private bool gameInProgress = true;

    void Start()
    {
        victoryPanel.SetActive(false);
    }

    void Update()
    {
        if (gameInProgress)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0f)
            {
                SpawnWave();
                timeRemaining = 30f;
            }

            string minutes = ((int)(timeRemaining / 60)).ToString("00");
            string seconds = ((int)(timeRemaining % 60)).ToString("00");
            timerText.text = $"{minutes}:{seconds}";
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
        completedWaves++;
        CheckForVictory();
    }

    private void CheckForVictory()
    {
        if (completedWaves >= wavesToWin)
        {
            gameInProgress = false;
            victoryPanel.SetActive(true);
        }
    }
}
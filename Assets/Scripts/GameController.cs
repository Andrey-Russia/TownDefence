using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform SpawnPoint;
    public TMP_Text TimerText;
    public GameObject VictoryPanel;
    public GameObject GameOverPanel;
    public int EnemiesToDestroy = 2;

    private float _timeRemaining = 5f;
    private int _destroyedEnemies = 0;
    private bool _gameInProgress = true;

    void Start()
    {
        VictoryPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (_gameInProgress)
        {
            _timeRemaining -= Time.deltaTime;

            if (_timeRemaining <= 0f)
            {
                SpawnWave();
                _timeRemaining = 30f;
            }

            string minutes = ((int)(_timeRemaining / 60)).ToString("00");
            string seconds = ((int)(_timeRemaining % 60)).ToString("00");
            TimerText.text = $"{minutes}:{seconds}";
        }
    }

    internal void OnEnemyDestroyed(GameObject enemy)
    {
        _destroyedEnemies++;

        if (_destroyedEnemies >= EnemiesToDestroy)
        {
            _gameInProgress = false;
            VictoryPanel.SetActive(true);
        }
    }

    private void SpawnWave()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity); 
    }
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class knight : MonoBehaviour
{
    public GameObject knightPrefab; 
    public Transform spawnPosition; 
    public float spawnRadius = 5f; 
    public Button spawnButton; 
    public TMP_Text wheatText; 

    void Start()
    {
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(SpawnKnight);
        }
    }

    void SpawnKnight()
    {
        Vector3 randomPosition = spawnPosition.position + Random.insideUnitSphere * spawnRadius;
        Instantiate(knightPrefab, randomPosition, Quaternion.identity);
    }

    void SpawnItem()
    {
        int wheatCount = int.Parse(wheatText.text.Split(':')[1].Trim()); 

        if (wheatCount >= 10)
        {
            Vector3 randomPosition = spawnPosition.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(knightPrefab, randomPosition, Quaternion.identity);
            wheatCount -= 10; 
            wheatText.text = $"Кол-во пшеницы: {wheatCount}"; 
        }
        else
        {
            Debug.Log("Недостаточно пшеницы для спавна предмета.");
        }
    }    
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wheatmen : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform spawnPosition; 
    public float spawnRadius = 5f; 
    public Button spawnButton; 
    public TMP_Text wheatText; 

    void Start()
    {
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(SpawnItem);
        }
    }

    void SpawnItem()
    {
        int wheatCount = int.Parse(wheatText.text.Split(':')[1].Trim()); 

        if (wheatCount >= 5)
        {
            Vector3 randomPosition = spawnPosition.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(itemPrefab, randomPosition, Quaternion.identity);
            wheatCount -= 5; 
            wheatText.text = $"Кол-во пшеницы: {wheatCount}"; 
        }
        else
        {
            Debug.Log("Недостаточно пшеницы для спавна предмета.");
        }
    }
}

using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Wheat : MonoBehaviour
{
    public static Wheat instance;
    public TMP_Text textField;
    public int totalWheatCollected = 0;
    public float collectionInterval = 10f;
    public int baseResourceAmountPerCollection = 10;
    public Button button5Wheat;
    public Button button10Wheat;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(CollectResources());
    }

    IEnumerator CollectResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(collectionInterval);
            GiveResource();
        }
    }

    void GiveResource()
    {
        int warriorCount = GameObject.FindGameObjectsWithTag("warrior").Length;
        int resourceAmount = baseResourceAmountPerCollection - warriorCount;

        if (resourceAmount > 0)
        {
            Debug.Log($"Выдана пшеница: {resourceAmount}");
            AddWheat(resourceAmount);
        }
        else
        {
            Debug.Log("Количество пшеницы не может быть отрицательным.");
        }
    }

    public void AddWheat(int amount)
    {
        totalWheatCollected += amount;
        UpdateText();
        UpdateButtons();
    }

    private void UpdateText()
    {
        textField.text = $"Кол-во пшеницы: {totalWheatCollected}";
    }

    private void UpdateButtons()
    {
        if (totalWheatCollected >= 5)
        {
            button5Wheat.interactable = true;
        }
        else
        {
            button5Wheat.interactable = false;
        }

        if (totalWheatCollected >= 10)
        {
            button10Wheat.interactable = true;
        }
        else
        {
            button10Wheat.interactable = false;
        }
    }
}
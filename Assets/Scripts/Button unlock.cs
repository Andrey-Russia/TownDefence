using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonUnlock : MonoBehaviour
{
    public Button button5Wheat;
    public Button button10Wheat;
    public TMP_Text wheatText; 

    void Update()
    {
        int wheatCount = int.Parse(wheatText.text.Split(':')[1].Trim());
        if (wheatCount >= 5)
        {
            button5Wheat.interactable = true;
        }
        else
        {
            button5Wheat.interactable = false;
        }

        if (wheatCount >= 10)
        {
            button10Wheat.interactable = true;
        }
        else
        {
            button10Wheat.interactable = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePanel : MonoBehaviour
{
    public GameObject Panel;

    void Start()
    {
        Panel.SetActive(false);
    }

    public void OpenPanel()
    {
        Panel.SetActive(true);
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
    }
}
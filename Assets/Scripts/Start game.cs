using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Panel : MonoBehaviour
{
    public Image FadePanel;
    private float _fadeDuration = 2f;


    void Start()
    {
        if (FadePanel != null)
        FadePanel.color = Color.clear;
    }

    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(FadeToBlack(sceneName));
    }

    IEnumerator FadeToBlack(string nextScene)
    {
        float elapsedTime = 0f;
        while (elapsedTime < _fadeDuration)
        {
            float panelalpha = Mathf.Lerp(0, 1, elapsedTime / _fadeDuration);

            FadePanel.color = new Color(FadePanel.color.r, FadePanel.color.g, FadePanel.color.b, panelalpha);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        SceneManager.LoadScene(nextScene); 
    }
}

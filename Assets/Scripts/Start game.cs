using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Panel : MonoBehaviour
{
    public Image fadePanel;
    private float fadeDuration = 2f;


    void Start()
    {
        if (fadePanel != null)
        fadePanel.color = Color.clear;
    }

    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(FadeToBlack(sceneName));
    }

    IEnumerator FadeToBlack(string nextScene)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float panelalpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);

            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, panelalpha);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        SceneManager.LoadScene(nextScene); 
    }
}

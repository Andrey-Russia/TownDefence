using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public int sceneIndex; 

    public void OnButtonClick() 
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

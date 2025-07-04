using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int startMenuIndex, mainSceneIndex, testSceneIndex;

    public void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

    public void LoadTestScene()
    {
        SceneManager.LoadScene(testSceneIndex);
    }

}

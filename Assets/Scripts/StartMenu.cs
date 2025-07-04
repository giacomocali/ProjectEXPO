using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int startMenuIndex, mainSceneIndex;

    public void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

}

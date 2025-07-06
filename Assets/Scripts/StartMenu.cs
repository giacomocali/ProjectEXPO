using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int startMenuIndex, mainSceneIndex, testSceneIndex;

    [Header("Loading")]
    public GameObject loadingScreen;
    public Slider loadingBar;

    public void LoadMainScene()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadMainAsync());
    }

    IEnumerator LoadMainAsync()
    {
        Shader.WarmupAllShaders();
        AsyncOperation operation = SceneManager.LoadSceneAsync(mainSceneIndex);

        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;

            yield return null;
        }
    }

    public void LoadTestScene()
    {
        SceneManager.LoadScene(testSceneIndex);
    }

}

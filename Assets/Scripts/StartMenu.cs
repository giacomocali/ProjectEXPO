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
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            loadingBar.value = operation.progress;

            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        operation.allowSceneActivation = true;

    }

    public void LoadTestScene()
    {
        SceneManager.LoadScene(testSceneIndex);
    }

}

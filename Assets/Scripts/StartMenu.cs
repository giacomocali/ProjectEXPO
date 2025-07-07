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
        Physics.autoSimulation = false;

        AsyncOperation operation = SceneManager.LoadSceneAsync(mainSceneIndex);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            loadingBar.value = operation.progress;

            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        operation.allowSceneActivation = true;
        Physics.autoSimulation = true;
    }

    public void LoadTestScene()
    {
        SceneManager.LoadScene(testSceneIndex);
    }

}

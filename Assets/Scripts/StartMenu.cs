using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [Header("Scene indexes")]
    public int startMenuIndex, mainSceneIndex, testSceneIndex;

    [Header("Buttons stagger animation")]
    public GameObject[] menuButtons;
    public float delay;
    int currentButton = 0;

    [Header("Language select box")]
    public GameObject languageSelect;

    [Header("Loading")]
    public GameObject loadingScreen;
    public Slider loadingBar;

    private void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.HasKey("lang"))
        {
            languageSelect.SetActive(false);
        }
        StaggerAnimation();
    }
    
    public void StaggerAnimation()
    {
        Invoke("ActivateNextButton", delay);
    }

    void ActivateNextButton()
    {
        if(currentButton < menuButtons.Length)
        {
            menuButtons[currentButton].SetActive(true); 
            Invoke("ActivateNextButton", delay);
            currentButton++;
        }
    }

    public void LoadMainScene()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadMainAsync());
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
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

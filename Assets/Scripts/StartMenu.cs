using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [Header("Scene indexes")]
    public int startMenuIndex, mainSceneIndex;

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
            StaggerAnimation();
        }
    }
    
    public void ChooseLanguageAgain()
    {
        PlayerPrefs.DeleteKey("lang");
    }

    public void DeactivateLanguageSelect()
    {
        print("DeactivateLangSel");
        StartCoroutine("WaitBeforeDeactivation");
    }

    IEnumerator WaitBeforeDeactivation()
    {
        yield return new WaitForSecondsRealtime(1f);
        languageSelect.SetActive(false);
        print("deactivating language select");
    }

    public void StaggerAnimation()
    {
        Invoke("ActivateNextButton", delay);
    }

    void ActivateNextButton()
    {
        if (currentButton < menuButtons.Length)
        {
            menuButtons[currentButton].SetActive(true);
            Invoke("ActivateNextButton", delay);
            currentButton++;
        }
    }

    bool increaseLoadingBar = false;

    public void LoadMainScene()
    {
        loadingScreen.SetActive(true);
        increaseLoadingBar = true;
        SceneManager.LoadScene(1);
    }

    private void FixedUpdate()
    {
        if (increaseLoadingBar)
        {
            loadingBar.value++;
        }
    }

}

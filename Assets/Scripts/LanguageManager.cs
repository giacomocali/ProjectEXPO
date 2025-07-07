using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    [System.Serializable]
    public class TextToTranslate
    {
        public TextMeshProUGUI tmPro;
        [TextArea] public string italianText;
        [TextArea] public string englishText;
    }

    [Header("Testi in scena da tradurre")]
    public List<TextToTranslate> translatableTexts = new List<TextToTranslate>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        UpdateAllTexts();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateAllTexts();
    }

    public void SetToItalian()
    {
        PlayerPrefs.SetString("lang", "ita");
        PlayerPrefs.Save();
        UpdateAllTexts();
    }

    public void SetToEnglish()
    {
        PlayerPrefs.SetString("lang", "eng");
        PlayerPrefs.Save();
        UpdateAllTexts();
    }

    void UpdateAllTexts()
    {
        foreach (var entry in translatableTexts)
        {
            if(PlayerPrefs.GetString("lang") == "ita")
            {
                entry.tmPro.text = entry.italianText;
            }
            else if(PlayerPrefs.GetString("lang") == "eng")
            {
                entry.tmPro.text = entry.englishText;
            }    
            
        }
    }
}

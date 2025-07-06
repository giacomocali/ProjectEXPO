using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    [System.Serializable]
    public class LocalizedPrefab
    {
        public TextMeshProUGUI prefab; // il prefab collegato da Assets
        [TextArea] public string italianText;
        [TextArea] public string englishText;
    }

    [Header("Lista dei prefab testuali da localizzare")]
    public List<LocalizedPrefab> localizedPrefabs = new List<LocalizedPrefab>();

    [Header("Toggle lingua")]
    public Button toggleLanguageButton;

    private bool isItalian = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (toggleLanguageButton != null)
            toggleLanguageButton.onClick.AddListener(ToggleLanguage);

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

    public void ToggleLanguage()
    {
        isItalian = !isItalian;
        UpdateAllTexts();
    }

    void UpdateAllTexts()
    {
        TextMeshProUGUI[] textsInScene = FindObjectsOfType<TextMeshProUGUI>(true);

        foreach (var entry in localizedPrefabs)
        {
            if (entry.prefab == null) continue;

            string prefabName = entry.prefab.name;

            foreach (var sceneText in textsInScene)
            {
                if (sceneText.name.StartsWith(prefabName))
                {
                    sceneText.text = isItalian ? entry.italianText : entry.englishText;
                }
            }
        }
    }
}

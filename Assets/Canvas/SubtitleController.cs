using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour
{
    public TextMeshProUGUI subtitleText; // Il TextMeshPro per mostrare i sottotitoli

    [System.Serializable]
    public class Subtitle
    {
        public string text;       // Testo del sottotitolo
        public float duration;    // Per quanto tempo mostrarlo (secondi)
    }

    public Subtitle[] allSubtitleTexts;  // Lista dei sottotitoli

    public Subtitle[] allSubtitleTextsEng;  // Lista dei sottotitoli

    [HideInInspector]
    public int index = 0;

    private void Start()
    {
        ChangeSubtitle();
    }

    void ChangeSubtitle()
    {
        
        if (index < allSubtitleTexts.Length)
        {
            if(PlayerPrefs.GetString("lang") == "ita")
            {
                subtitleText.text = allSubtitleTexts[index].text;
                Invoke("ChangeSubtitle", allSubtitleTexts[index].duration);    
            }
            else if(PlayerPrefs.GetString("lang") == "eng")
            {
                subtitleText.text = allSubtitleTextsEng[index].text;
                Invoke("ChangeSubtitle", allSubtitleTextsEng[index].duration);
            }


                index = index + 1;
        }
        else
        {
            return;
        }
        
    }

    /*
    private void Start()
    {
        StartCoroutine(ShowSubtitles());
    }

    IEnumerator ShowSubtitles()
    {
        foreach (Subtitle s in subtitles)
        {
            Debug.LogWarning("NEW CYCLE");
            subtitleText.text = s.text;      // Mostra il sottotitolo
            yield return new WaitForSecondsRealtime(s.duration); // Aspetta
        }

        subtitleText.text = ""; // Pulisci il testo alla fine
    }

    */
}

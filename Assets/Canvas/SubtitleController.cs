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

    public Subtitle[] subtitles;  // Lista dei sottotitoli

    private void Start()
    {
        StartCoroutine(ShowSubtitles());
    }

    IEnumerator ShowSubtitles()
    {
        foreach (Subtitle s in subtitles)
        {
            subtitleText.text = s.text;      // Mostra il sottotitolo
            yield return new WaitForSeconds(s.duration); // Aspetta
        }

        subtitleText.text = ""; // Pulisci il testo alla fine
    }
}

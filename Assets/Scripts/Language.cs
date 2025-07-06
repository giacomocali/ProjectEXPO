using UnityEngine;

public class Language : MonoBehaviour
{ 

    public void SetToItalian()
    {
        PlayerPrefs.SetString("language", "italian");
        PlayerPrefs.Save();
    }
    public void SetToEnglish()
    {
        PlayerPrefs.SetString("language", "english");
        PlayerPrefs.Save();
    }
}

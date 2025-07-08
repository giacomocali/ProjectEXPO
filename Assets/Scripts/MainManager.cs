using UnityEngine;

public class MainManager : MonoBehaviour
{   
    private void Start()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    
}

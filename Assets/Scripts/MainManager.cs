using UnityEngine;

public class MainManager : MonoBehaviour
{   
    private void Start()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    
}

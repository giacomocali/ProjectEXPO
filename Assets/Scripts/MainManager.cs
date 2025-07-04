using UnityEngine;

public class MainManager : MonoBehaviour
{   
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}

using UnityEngine;

public class MainManager : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

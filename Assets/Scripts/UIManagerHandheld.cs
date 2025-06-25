using UnityEngine;

public class UIManagerHandheld : MonoBehaviour
{
    public GameObject videoControls;
    public static UIManagerHandheld instance;

    private void Awake()
    {
        instance = this;
    }


    public static void ShowPlayerControls(bool show)
    {
        if (instance != null)
        {
            instance.videoControls.SetActive(show);
        }
    }
}

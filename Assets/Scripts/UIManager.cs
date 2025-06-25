using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiTooltip;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static void ShowTooltip()
    {
        if(instance != null)
        {
            if (instance.uiTooltip.active)
            {
                instance.uiTooltip.SetActive(false);
            }
            else
            {
                instance.uiTooltip.SetActive(true);
            }
        }
    }

}

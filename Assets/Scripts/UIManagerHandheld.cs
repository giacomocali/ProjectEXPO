using UnityEngine;

public class UIManagerHandheld : MonoBehaviour
{
    public GameObject pressETooltip;
    public static UIManagerHandheld instance;

    private void Awake()
    {
        instance = this;
    }


    public static void ShowTooltip(bool show, string sAction)
    {
        if (instance != null)
        {

        }
    }
}

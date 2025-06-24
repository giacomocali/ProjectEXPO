using UnityEngine;

public class VideoManager : MonoBehaviour, I_Interactable
{
    public Material red;

    void I_Interactable.Interact()
    {
        this.GetComponent<Renderer>().material = red;
    }
}

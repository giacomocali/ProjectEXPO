using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour, I_Interactable
{
    public VideoPlayer player;

    void I_Interactable.Interact()
    {
        player.Play();
        Debug.Log("starting video");
    }
}

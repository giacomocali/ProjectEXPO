using UnityEngine;
using UnityEngine.Video;

public class InteractableVideo : MonoBehaviour, I_Interactable
{
    VideoPlayer player;
    bool playPauseButton;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
    }

    void I_Interactable.Interact()
    {
        if (playPauseButton)
        {
            if (player.isPaused)
            {
                player.Play();
            }
            else if (player.isPlaying)
            {
                player.Stop();
            }
        }
        else
        {
            player.frame = 0;
            player.Play();
        }

        Debug.Log("starting video");
    }

    void I_Interactable.Selected()
    {
        
    }
}

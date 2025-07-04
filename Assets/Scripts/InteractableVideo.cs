using UnityEngine;
using UnityEngine.Video;

public class InteractableVideo : MonoBehaviour, I_Interactable
{
    VideoPlayer player;
    bool playPauseButton;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
        try
        {
            player.url = System.IO.Path.Combine(Application.streamingAssetsPath, "testvideo.mp4");
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
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

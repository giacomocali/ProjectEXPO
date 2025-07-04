using UnityEngine;
using UnityEngine.UI;

public class UIManagerHandheld : MonoBehaviour
{
    public GameObject videoControls;
    public static UIManagerHandheld instance;

    public Image playPauseImage;
    public Sprite pauseIcon;
    public Sprite playIcon;

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

    public void PlayOrPauseVideo()
    {
        if (Interact.selectedPlayer.isPlaying)
        {
            playPauseImage.sprite = playIcon;
            Interact.selectedPlayer.Pause();
        }
        else
        {
            playPauseImage.sprite = pauseIcon;
            try
            {
                Interact.selectedPlayer.Play();
            }
            catch(System.Exception e) 
            { 
                Debug.LogException(e);
            }

        }
    }

    public void RewindVideo()
    {
        playPauseImage.sprite = pauseIcon;
        Interact.selectedPlayer.frame = 0;
        Interact.selectedPlayer.Play();
    }
}

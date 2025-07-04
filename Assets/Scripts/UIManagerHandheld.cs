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
        if (Interact.selectedVideo.isPlaying)
        {
            playPauseImage.sprite = playIcon;
            Interact.selectedVideo.Pause();
        }
        else
        {
            playPauseImage.sprite = pauseIcon;
            Interact.selectedVideo.Play();
        }
    }

    public void RewindVideo()
    {
        playPauseImage.sprite = pauseIcon;
        Interact.selectedVideo.frame = 0;
        Interact.selectedVideo.Play();
    }
}

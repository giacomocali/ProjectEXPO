using TMPro;
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

    public void SetTargetFPS(int tgt)
    {
        Application.targetFrameRate = tgt;
    }

    public static void ShowPlayerControls(bool show)
    {
        if (instance != null)
        {
            instance.videoControls.SetActive(show);
        }
    }

    private void Update()
    {
        if (Interact.selectedPlayer != null)
        {
            if (Interact.selectedPlayer.player.isPlaying)
            {
                playPauseImage.sprite = pauseIcon;
            }
            else
            {
                playPauseImage.sprite = playIcon;
            }
        }
    }

    public void PlayOrPauseVideo()
    {        
        Interact.selectedPlayer.PlayPause();
    }

    public void RewindVideo()
    {
        Interact.selectedPlayer.Rewind();
    }
}

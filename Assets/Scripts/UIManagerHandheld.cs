using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManagerHandheld : MonoBehaviour
{
    public GameObject videoControls;
    public static UIManagerHandheld instance;

    public Image playPauseImage;
    public Sprite pauseIcon;
    public Sprite playIcon;

    public VideoPlayer[] allVideoPlayers;

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

    // VIDEO
    public void PlayOrPauseVideo()
    {        
        Interact.selectedPlayer.PlayPause();
    }

    public void RewindVideo()
    {
        Interact.selectedPlayer.Rewind();
    }


    // PAUSE MENU
    public void Pause()
    {
        Time.timeScale = 0f;
        for (int i = 0; i < allVideoPlayers.Length; i++)
        {
            allVideoPlayers[i].Pause();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}

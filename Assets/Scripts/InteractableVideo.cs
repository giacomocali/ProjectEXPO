using UnityEngine;
using UnityEngine.Video;

public class InteractableVideo : MonoBehaviour
{
    public string videoSource;
    public GameObject screenOffEffect;

    [HideInInspector] public VideoPlayer player;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();

        player.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoSource);
    }
    
    public void PlayPause()
    {
        print("playorpause");
        screenOffEffect.SetActive(false);
        if (!player.isPlaying)
        {
            print("play");
            player.Play();
        }
        else
        {
            print("pause");
            player.Stop();
        }
    }
    public void Rewind()
    {
        print("rewind");
        screenOffEffect.SetActive(false);
        player.frame = 0;
        player.Play();
    }
}

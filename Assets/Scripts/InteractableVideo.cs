using UnityEngine;
using UnityEngine.Video;

public class InteractableVideo : MonoBehaviour
{
    public string videoSource;
    public Material screenOn;

    [HideInInspector] public VideoPlayer player;
    MeshRenderer mr;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
        mr = GetComponent<MeshRenderer>();

        player.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoSource);
    }
    

    public void PlayPause()
    {
        mr.material = screenOn;
        if (!player.isPlaying)
        {
            player.Play();
        }
        else
        {
            player.Pause();
        }
    }
    public void Rewind()
    {
        mr.material = screenOn;
        player.frame = 0;
        player.Play();
    }
}

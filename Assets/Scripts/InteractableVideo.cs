using UnityEngine;
using UnityEngine.Video;

public class InteractableVideo : MonoBehaviour
{
    public string videoSource;
    public GameObject unselectedFX;
    public GameObject selectedFX;
    public GameObject led;
    public Material screenOn;


    bool tvOn = false;

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
        tvOn = true;
        led.SetActive(false);
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
        tvOn = true;
        led.SetActive(false);
        mr.material = screenOn;
        player.frame = 0;
        player.Play();
    }

    public void SelectedEffects()
    {
        if (tvOn)
        {
            unselectedFX.SetActive(false);
            selectedFX.SetActive(false);
            return;
        }
        unselectedFX.SetActive(false);
        selectedFX.SetActive(true);
    }

    public void UnselectedEffects()
    {
        if (tvOn)
        {
            unselectedFX.SetActive(false);
            selectedFX.SetActive(false);
            return;
        }
        unselectedFX.SetActive(true);
        selectedFX.SetActive(false);
    }
}

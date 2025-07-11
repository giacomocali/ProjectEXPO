using UnityEngine;
using UnityEngine.Video;

public class InteractableVideo : MonoBehaviour
{
    [Header("Video name")]
    public string videoSource;

    [Header("Automatic control")]
    public Transform playerT;
    public AudioSource ambience;
    float maxDistance = 5;

    [Header("Effects")]
    public GameObject unselectedFX;
    public GameObject selectedFX;
    public Material screenOn;

    [Header("Subtitles")]
    public GameObject subtitleController;

    bool tvOn = false;
    float currentDistance;

    [HideInInspector] public VideoPlayer player;
    MeshRenderer mr;

    private void OnEnable()
    {
        player.Prepare();
        TickSystem.OnTickAction += Tick;
    }

    private void OnDisable()
    {
        TickSystem.OnTickAction -= Tick;
    }

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
        mr = GetComponent<MeshRenderer>();

        player.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoSource);
    }


    private void Tick()
    {
        if (player.isPlaying)
        {
            //subtitles
            subtitleController.SetActive(true);

            //ambience volume
            ambience.volume = 0f;

            //autostop
            currentDistance = Vector3.Distance(transform.position, playerT.position);

            if(currentDistance > maxDistance)
            {
                player.Pause();
            }
        }
        else if(!player.isPlaying)
        {
            //subtitles
            subtitleController.SetActive(false);

            ambience.volume = 1f;
        }
    }

    public void PlayPause()
    {
        tvOn = true;
        mr.material = screenOn;

        if (!player.isPlaying && player.isPrepared)
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
        mr.material = screenOn;
        player.frame = 0;
        player.Play();
        
        if(subtitleController.GetComponent<SubtitleController>() != null)
        {
            subtitleController.GetComponent<SubtitleController>().index = 0;
        }

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

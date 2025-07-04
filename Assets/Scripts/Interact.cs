using UnityEngine;
using UnityEngine.Video;

public class Interact : MonoBehaviour
{
    public float rayLength;
    Vector2 mousePos;
    Ray ray;
    RaycastHit hit;

    public static VideoPlayer selectedVideo;

    private void Update()
    {
        mousePos = Input.mousePosition;
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, rayLength))
        {
            if (hit.collider.TryGetComponent(out VideoPlayer player))
            {
                UIManagerHandheld.ShowPlayerControls(true);
                print("raycast hit a videoplayer");
                selectedVideo = player;
            }
            else
            {
                UIManagerHandheld.ShowPlayerControls(false);
            }
        }
        else
        {
            UIManagerHandheld.ShowPlayerControls(false);
        }

    }


}

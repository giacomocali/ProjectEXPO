using UnityEngine;
using UnityEngine.Video;

public class Interact : MonoBehaviour
{
    public float rayLength;
    Vector2 mousePos;
    Ray ray;
    RaycastHit hit;

    public static InteractableVideo selectedPlayer;

    private void Update()
    {
        mousePos = Input.mousePosition;
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, rayLength))
        {
            if (hit.collider.TryGetComponent(out InteractableVideo player))
            {
                //print("raycast hit a videoplayer");
                UIManagerHandheld.ShowPlayerControls(true);
                selectedPlayer = player;
                selectedPlayer.SelectedEffects();
            }
            else
            {
                if(selectedPlayer != null)
                {
                    selectedPlayer.UnselectedEffects();
                }
                UIManagerHandheld.ShowPlayerControls(false);
            }
        }
        else
        {
            if (selectedPlayer != null)
            {
                selectedPlayer.UnselectedEffects();
            }
            UIManagerHandheld.ShowPlayerControls(false);
        }

    }


}

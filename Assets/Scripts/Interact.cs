using UnityEngine;

public class Interact : MonoBehaviour
{
    public float rayLength;
    Vector2 mousePos;
    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        mousePos = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, rayLength))
        {
            if (hit.collider.TryGetComponent(out I_Interactable interactable))
            {
                
            }
        }
    }


}

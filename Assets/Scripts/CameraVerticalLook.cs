using UnityEngine;

public class CameraVerticalLook : MonoBehaviour
{
    public float verticalSens;
    public bool invertVertical;

    float mouseY;

    void CameraVerticalRotation()
    {
        if (!invertVertical)
        {
            mouseY -= Input.GetAxisRaw("Mouse Y") * verticalSens * Time.deltaTime;
        }
        else
        {
            mouseY -= -Input.GetAxisRaw("Mouse Y") * verticalSens * Time.deltaTime;
        }

        mouseY = Mathf.Clamp(mouseY, -70, 70);

        transform.localRotation = Quaternion.Euler(mouseY, 0, 0);
    }

    void Update()
    {
        CameraVerticalRotation();
    }
}

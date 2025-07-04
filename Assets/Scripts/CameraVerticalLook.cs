using UnityEngine;

public class CameraVerticalLook : MonoBehaviour
{
    [Header("References")]
    public bool touchControls;
    public Joystick lookJoystick;

    [Header("Parameters")]
    public float verticalSens;
    public bool invertVertical;

    float vInput;

    void CameraVerticalRotation()
    {
        if (touchControls)
        {
            vInput -= lookJoystick.Vertical * verticalSens * Time.deltaTime;
        }
        else
        {
            vInput -= Input.GetAxisRaw("Mouse Y") * verticalSens * Time.deltaTime;
        }

        //inputY = Mathf.Clamp(inputY, -70, 70);

        transform.localRotation = Quaternion.Euler(vInput, 0, 0);
    }

    void Update()
    {
        CameraVerticalRotation();
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Touch settings")]
    public Joystick walkJoystick;
    public Joystick lookJoystick;
    public bool touchControls;

    [Header("Parameters")]
    public float walkSpeed;
    public float horizontalLookSensitivity;

    private CharacterController charController;
    Vector2 look;

    float hInput;
    float vInput;

    readonly float gravity = -9.81f;

    private void Start()
    {
        print("Running on: " + SystemInfo.deviceType);
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }
    private void InputManagement()
    {
        // change inputs based on device
        if (!touchControls)
        { 
            look.x = Input.GetAxisRaw("Mouse X") * horizontalLookSensitivity * Time.deltaTime;

            hInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            vInput = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        }
        else
        {
            look.x = lookJoystick.Horizontal * horizontalLookSensitivity * Time.deltaTime;

            hInput = walkJoystick.Horizontal * Time.deltaTime;
            vInput = walkJoystick.Vertical * Time.deltaTime;
        }
    }

    void Movement()
    {
        Vector3 movement = new Vector3(hInput, gravity, vInput);

        movement = transform.TransformDirection(movement);
        movement *= walkSpeed;

        charController.Move(movement);

        transform.Rotate(0, look.x, 0);
    }


}

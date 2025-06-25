using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController charController;

    [Header("Movement settings")]
    public float walkSpeed;
    public float lookSensitivity;

    Vector2 mouseLook;
    float moveInput;
    float turnInput;

    readonly float gravity = -9.81f;

    private void Start()
    {
        print("Running on: " + SystemInfo.deviceType);
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }
    private void InputManagement()
    {
        // change inputs based on device

        mouseLook.x = Input.GetAxisRaw("Mouse X") * lookSensitivity * Time.deltaTime;

        moveInput = Input.GetAxisRaw("Horizontal");
        turnInput = Input.GetAxisRaw("Vertical");
    
    }

    void Movement()
    {
        Vector3 movement = new Vector3(moveInput, gravity, turnInput);

        movement = transform.TransformDirection(movement);
        movement *= walkSpeed;

        charController.Move(movement * Time.deltaTime);

        transform.Rotate(0, mouseLook.x, 0);
    }


}

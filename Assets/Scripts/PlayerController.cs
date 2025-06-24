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

    private void Start()
    {
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
        print("Running on: "+SystemInfo.deviceType);

        mouseLook.x = Input.GetAxisRaw("Mouse X") * lookSensitivity * Time.deltaTime;
        mouseLook.y = Input.GetAxisRaw("Mouse Y") * lookSensitivity * Time.deltaTime;  

        moveInput = Input.GetAxisRaw("Horizontal");
        turnInput = Input.GetAxisRaw("Vertical");
    
    }

    void Movement()
    {
        Vector3 movement = new Vector3(moveInput, 0, turnInput);

        movement.y = 0; // just in case

        movement *= walkSpeed;


        charController.Move(movement * Time.deltaTime);

        transform.Rotate(0, mouseLook.x, 0);
    }


}

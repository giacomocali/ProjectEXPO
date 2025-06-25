using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public float speed;
    public float xSens;

    Rigidbody rb;
    float inputX, inputY;
    float mouseX;
    Vector3 movementDir;
    Quaternion rotQuat;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CollectInputs();
    }

    private void FixedUpdate()
    {
        movementDir = new Vector3(inputX, 0, inputY);
        movementDir = transform.TransformDirection(movementDir);
        movementDir.Normalize();
        movementDir *= speed;
        // move player
        //rb.linearVelocity = movementDir;
        rb.MovePosition(movementDir);

        // rotate horizontally along the y axis
        rotQuat = Quaternion.Euler(rb.rotation.x, mouseX * xSens, rb.rotation.z);
        rb.MoveRotation(rotQuat);

    }

    void CollectInputs()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }
}

using UnityEngine;
using System.Collections;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 150.0f;
    public float boostMultiplier = 1.5f; // Speed multiplier during boost
    public float boostDuration = 0.5f; // Duration of the boost
    public Transform cameraTransform; // Assign this to the camera in the Inspector
    public Vector3 cameraOffset = new Vector3(0, 2.0f, -5.0f); // Offset to keep the camera behind and above the cube
    public float cameraSmoothSpeed = 0.125f; // Smooth speed for camera movement

    public float jumpHeight = 5.0f; // Height of the jump
    private bool isGrounded; // Check if the cube is grounded
    private Rigidbody rb; // Reference to the Rigidbody

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    private void Update()
    {
        // Get the input for forward/backward movement and turning
        float zDirection = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        // Move the cube forward/backward
        transform.Translate(0, 0, zDirection);

        // Rotate the cube left/right
        transform.Rotate(0, rotation, 0);

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Follow the cube with the camera (smoothly)
        Vector3 desiredPosition = transform.position + transform.TransformDirection(cameraOffset);
        Vector3 smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, cameraSmoothSpeed);
        cameraTransform.position = smoothedPosition;

        // Make the camera look at the cube
        cameraTransform.LookAt(transform.position + Vector3.up * 1.0f);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        isGrounded = false; // Set grounded state to false
    }

    private void FixedUpdate()
    {
        // Raycast to check if grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f); // Adjust the distance as needed
    }

    public void ActivateSpeedBoost()
    {
        StartCoroutine(SpeedBoostCoroutine());
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        float originalSpeed = moveSpeed;
        moveSpeed *= boostMultiplier;

        yield return new WaitForSeconds(boostDuration);

        moveSpeed = originalSpeed; // Reset speed
    }
}
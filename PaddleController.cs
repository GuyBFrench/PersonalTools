using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this value to control the paddle's speed.

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 moveInput = Vector2.zero;

        // Check for keyboard input.
        moveInput.x = Input.GetAxis("Horizontal");

        // Check for touch input on mobile devices.
        /*if (Touchscreen.current.primaryTouch.isInProgress)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();

            // Calculate the movement based on the touch delta.
            moveInput = touchPos - (Vector2)transform.position;
            moveInput.Normalize(); // Normalize to prevent fast movement.

            // Multiply by a factor to control the sensitivity of touch input.
            moveInput *= moveSpeed * Time.deltaTime;
        }*/

        // Calculate the velocity for the paddle's movement.
        Vector3 moveVelocity = new Vector3(moveInput.x, 0, 0) * moveSpeed;

        // Apply the velocity to the paddle's Rigidbody.
        rb.velocity = moveVelocity;
    }
}
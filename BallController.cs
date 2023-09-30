using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public UnityEvent collideEvent;
    public float initialSpeed = 5.0f; // Adjust this value for the initial ball speed.
    public float maxSpeed = 10.0f;    // Adjust this value for the maximum ball speed.

    private Rigidbody rb;
    private Vector3 initialPosition;
    private bool isBallInPlay = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Check if the ball is not in play (e.g., at the start of the level).
        if (!isBallInPlay)
        {
            // Launch the ball when the player presses a key or taps the screen.
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
            {
                LaunchBall();
            }
        }

        // Limit the ball's speed to the specified maximum speed.
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Add some randomness to the ball's direction upon collision.
        Vector3 randomDirection = new Vector3(Random.Range(-0.2f, 0.2f), 0, Random.Range(-0.2f, 0.2f));
        rb.velocity += randomDirection * 3;
        Debug.Log(randomDirection);
    }

    private void LaunchBall()
    {
        // Set the ball in motion when launching.
        rb.velocity = Vector3.up * initialSpeed;
        isBallInPlay = true;
    }

    // Call this method to reset the ball to its initial position.
    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        transform.position = initialPosition;
        isBallInPlay = false;
    }
}
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveSmoothness = 0.1f;
    public float tiltAngle = 10f;
    public float stopThreshold = 0.1f;
    public float screenLeftBoundary = -5f;
    public float screenRightBoundary = 5f;

    private Rigidbody2D rb;

    private float moveInput;
    private bool isMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isMoving = Mathf.Abs(rb.velocity.x) > stopThreshold;
    }

    private void FixedUpdate()
    {
        float xVelocity = rb.velocity.x;
        float targetVelocity = moveInput * moveSpeed;

        rb.velocity = new Vector2(Mathf.SmoothDamp(xVelocity, targetVelocity, ref xVelocity, moveSmoothness), rb.velocity.y);

        if (isMoving)
        {
            float tiltAmount = rb.velocity.x > 0 ? -tiltAngle : tiltAngle;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, tiltAmount);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
        }
        else
        {
            // Reset tilt when not moving
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
        }

        // Clamp player position to screen boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, screenLeftBoundary, screenRightBoundary);
        transform.position = clampedPosition;
    }
}
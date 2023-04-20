using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Transform playerSprite;

    private Vector2 moveDirection;

    private void Update()
    {
        ProcessInputs();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void RotatePlayer()
    {
        if (moveDirection.x > 0 && moveDirection.y == 0)
        {
            playerSprite.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (moveDirection.x < 0 && moveDirection.y == 0)
        {
            playerSprite.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (moveDirection.x == 0 && moveDirection.y > 0)
        {
            playerSprite.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveDirection.x == 0 && moveDirection.y < 0)
        {
            playerSprite.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (moveDirection.x > 0 && moveDirection.y > 0)
        {
            playerSprite.rotation = Quaternion.Euler(0, 0, 315);
        }
        else if (moveDirection.x < 0 && moveDirection.y > 0)
        {
            playerSprite.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (moveDirection.x < 0 && moveDirection.y < 0)
        {
            playerSprite.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (moveDirection.x > 0 && moveDirection.y < 0)
        {
            playerSprite.rotation = Quaternion.Euler(0, 0, 225);
        }
    }
}
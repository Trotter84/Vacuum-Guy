using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 5f;
    public float speedBoost = 1.5f;
    public bool isSpeedBoostActive = false;
    public bool canMoveDiagonally = true;
    private Rigidbody2D rb;
    private Gravity2D gravity;
    private Vector2 movement;
    private bool isMovingHorizontally = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<Gravity2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (canMoveDiagonally)
        {
            movement = new Vector2(horizontalInput, verticalInput);

            RotatePlayer(horizontalInput, verticalInput);
        }
        else
        {
            if (horizontalInput != 0)
            {
                isMovingHorizontally = true;
            }
            else if (verticalInput != 0)
            {
                isMovingHorizontally = false;
            }

            if (isMovingHorizontally)
            {
                movement = new Vector2(horizontalInput, 0);
                RotatePlayer(horizontalInput, 0);
            }
            else
            {
                movement = new Vector2(0, verticalInput);
                RotatePlayer(0, verticalInput);
            }
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSpeedBoostActive = true;
        }
        else
        {
            isSpeedBoostActive = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            gravity.ActivateGravity();
        }
    }

    void FixedUpdate()
    {

        if (isSpeedBoostActive)
        {
            rb.linearVelocity = movement * (speed * speedBoost);
        }
        else
        {
            rb.linearVelocity = movement * speed;
        }
    }

    void RotatePlayer(float x, float y)
    {
        if (x == 0 && y == 0) return;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void ResetPlayer()
    {
        transform.position = new Vector3(transform.position.x, 3.78999996f, 0);
    }
}

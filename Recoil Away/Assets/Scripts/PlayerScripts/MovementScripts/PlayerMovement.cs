using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
    public float speed;
    public float jumpForce;
    public int extraJumps;
    public float jumpTimer;
    private int jumpReset;

    private float moveInput;
    private float lastMoveInput;
    private float checkRadius = 0.25f;
    private float jumpTimerReset;
    private float maxSpeed;
    private float maxJumpSpeed;

    private bool facingRight = true;
    public bool isGrounded;
    private bool isJumping;


    Vector2 velocity;

    Rigidbody2D rb;

    public Transform groundCheck;

    public LayerMask whatIsGround;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        jumpReset = extraJumps;
        jumpTimerReset = jumpTimer;
        maxSpeed = 2.9f;
        maxJumpSpeed = 5f;
    }

    void Update()
    {
        lastMoveInput = moveInput;

        Move();

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            Jump();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            AdvancedJump();
        }

        if (isGrounded)
        {
            extraJumps = jumpReset;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10);
    }

    private void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");

        if (rb.velocity.magnitude < maxSpeed)
        {
            Vector2 movement = new Vector2(moveInput, 0);
            rb.AddForce(speed * movement);
        }

        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }

    private void Jump()
    {
        //velocity = Vector2.up * jumpForce;
        //rb.velocity = velocity;

        Vector2 jumpMovement = new Vector2(0, jumpForce);
        rb.AddForce(jumpMovement);
        extraJumps--;
        isJumping = true;
        jumpTimer = jumpTimerReset;
    }

    private void AdvancedJump()
    {
        if (jumpTimer > 0 && rb.velocity.magnitude < maxJumpSpeed)
        {
            Vector2 jumpMovement = new Vector2(0, jumpForce);
            rb.AddForce(jumpMovement);
            jumpTimer -= Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }

    void Flip()
    {
        GameObject weapon;
        weapon = GameObject.Find("WeaponHolder");

        Vector3 weaponScale = weapon.transform.localScale;
        weaponScale.x *= -1;

        facingRight = !facingRight;
        Vector3 scalar = transform.localScale;
        scalar.x *= -1;
        transform.localScale = scalar;

        weapon.transform.localScale = weaponScale;
    }
}

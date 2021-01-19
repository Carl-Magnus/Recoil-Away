using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
    public float speed;
    public float jumpForce;
    public int extraJumps;
    private int jumpReset;

    private float moveInput;
    private float checkRadius = 0.5f;

    private bool facingRight = true;
    private bool isGrounded;


    Vector2 velocity;

    Rigidbody2D rb;

    public Transform groundCheck;

    public LayerMask whatIsGround;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        jumpReset = extraJumps;
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            Jump();
        }

        if (isGrounded)
        {
            extraJumps = jumpReset;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");

        velocity = new Vector2(moveInput * speed, rb.velocity.y);

        rb.velocity = velocity;

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
        velocity = Vector2.up * jumpForce;
        rb.velocity = velocity;
        extraJumps--;
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

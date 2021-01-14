using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
    public float speed;
    public float jumpForce;

    private float moveInput;

    Vector2 velocity;

    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();   
    }

    private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        velocity = new Vector2(moveInput * speed, rb.velocity.y);

        rb.velocity = velocity;
    }
}

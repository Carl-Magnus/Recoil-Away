using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 velocity;

    public float speed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        ProjectileFlight();
    }

    private void ProjectileFlight()
    {
        rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ignore collison between player bullets and the actual player.
        Physics2D.IgnoreLayerCollision(9, 10, true);

        if (collision.collider.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}

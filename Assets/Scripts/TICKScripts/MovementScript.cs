using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float horz;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jppower = 16f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform gc;
    [SerializeField] private LayerMask gl;

    void Update()
    {
        horz = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && OnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jppower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(gc.position, 0.2f, gl);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horz * speed, rb.velocity.y);
    }
}

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
    private Animator anim;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        horz = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && OnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jppower);
            anim.SetBool("Jumpin", true);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        

        movement = rb.velocity;

        if (movement.x != 0)
        {
            anim.SetFloat("X", movement.x);
            anim.SetBool("IsWalkin", true);
        }
        else
        {
            anim.SetBool("IsWalkin", false);
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

    //private void OnMovement()
    //{
        //movement = rb.velocity;

        //if (movement.x != 0)
        //{
            //anim.SetFloat("X", movement.x);           ;
        //}
    //}
}

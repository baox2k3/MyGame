using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite; //tự xoay anh
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private AudioSource jum;

    [SerializeField] private LayerMask jumpabGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumForce = 14f;
    private bool canDoubleJum;


    // [SerializeField] private Joystick Joystick;
    private enum movementSAtate
    {
        idle,
        running,
        jum,
        falling,
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // _Move();
        //
        // float verticalMoVe = Joystick.Vertical;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumButton();

            if (IsGrounded())
            {
                canDoubleJum = true;
            }
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        movementSAtate state;
        if (dirX > 0f)
        {
            state = movementSAtate.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = movementSAtate.running;
            sprite.flipX = true;
        }
        else
        {
            state = movementSAtate.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = movementSAtate.jum;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementSAtate.falling;
        }
        
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpabGround);
    }

    private void Jum()
    {
        jum.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumForce);
    }

    private void JumButton()
    {
        if (IsGrounded())
        {
            Jum();
        }
        else if (canDoubleJum)
        {
            canDoubleJum = false;
            Jum();
        }
    }


    // private void _Move()
    // {
    //     dirX = Joystick.Horizontal; 
    //    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    //    
    // }
}
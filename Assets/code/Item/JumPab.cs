using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumPab : MonoBehaviour
{
    [SerializeField] private float bouce = 20f;
    private Animator anim;
    [SerializeField] private AudioSource Trampoline;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Trampoline = GetComponent < AudioSource>();

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Trampoline.Play();
            anim.SetBool("abc", true);
        }
        if (col.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = bouce;
                rb.velocity = velocity;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            anim.SetBool("abc", false);
        }

        if (other.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = bouce;
                rb.velocity = velocity;
            }
        }
    }
    



//     private void OnCollisionEnter2D(Collision2D col)
//     {
//         if (col.gameObject.CompareTag("Player"))
//         {
//        
//             col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bouce,ForceMode2D.Impulse);
//         }
//         else
//         {
//
//             col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bouce,ForceMode2D.Impulse);
//         }
//     }

}

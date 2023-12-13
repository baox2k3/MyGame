using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatForm : MonoBehaviour
{
    [SerializeField] private float fallDelay = 0.5f;
    [SerializeField] private float destroyDelay = 1f;
    [SerializeField] private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource FallingFlatform;

    private void Start()
    {
        anim = GetComponent<Animator>();
        FallingFlatform = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetBool("dung", true);
            FallingFlatform.Play();
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
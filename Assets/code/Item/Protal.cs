using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protal : MonoBehaviour
{
    private Transform destination;

    public bool isOrange;
    public float distance = 0.2f;


    private void Start()
    {
        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("orange prota").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("blu prota").GetComponent<Transform>();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (Vector2.Distance(transform.position,col.transform.position) > distance)
        {
            col.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Saw : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Player")
        {
           col.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

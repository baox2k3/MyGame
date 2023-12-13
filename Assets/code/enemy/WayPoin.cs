using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoin : MonoBehaviour
{
    [SerializeField] private  GameObject[] waypoin;
    private int currentWaypoinIndex = 0;
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if (Vector2.Distance(waypoin[currentWaypoinIndex].transform.position,transform.position) < .1f)
        {
            currentWaypoinIndex++;
            if (currentWaypoinIndex >= waypoin.Length)
            {
                currentWaypoinIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoin[currentWaypoinIndex]
                .transform.position,Time.deltaTime * speed);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkHead : enymyDamage
{
    [Header("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];//doi mang thanh 8 de di chuyen 8 huong
    private float checkTime;
    private Vector3 destination;
    private bool attacking;
    
    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        if (attacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTime += Time.deltaTime;
            if (checkTime > checkDelay)
            {
                checkForPlayer();
            }
        }
    }

    private void checkForPlayer()
    {
        calculationDirection();
        //
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position,directions[i],Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTime = 0;
            }
        }
    }

    private void calculationDirection()
    {
        directions[0] = transform.right * range;// right direction
        directions[1] = -transform.right * range; //left
        directions[2] = transform.up * range;// up
        directions[3] = -transform.up * range;// douw
        // directions[4] = (transform.right + transform.up) * range;// up_right
        // directions[5] = (transform.right + (-transform.up)) * range;// douw_right
        // directions[6] = ((-transform.right) + transform.up) * range;// up_left
        // directions[7] = ((-transform.right)+ (-transform.up)) * range;// douw_left

    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        Stop();
    }
    private void Stop()
    {
        destination = transform.position;
        attacking = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyWaypoin : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")//cho nv dung treen flatforms di chuyen theo
        {
            col.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}

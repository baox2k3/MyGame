using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{
   private int cherries = 0;

   [SerializeField] private Text cherriesText;
   [SerializeField] private AudioSource itemSound;
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.CompareTag("Cherry"))
      {
         itemSound.Play();
         Destroy(col.gameObject);
         cherries++;
         // Debug.Log("cherries: "+cherries);
         cherriesText.text = "Cherry:" +cherries;
      }
   }
}

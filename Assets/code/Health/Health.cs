using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private float startingHealth;
   [SerializeField] private AudioSource die;
   [SerializeField] private AudioSource hurtSound;
   public float currenHealth { get; private set; }
   private Animator anim;
   private bool dead;
   

   private void Awake()
   {
      currenHealth = startingHealth;
      anim = GetComponent<Animator>();
   }

   public void TakeDamage(float damege)
   {
      currenHealth = Mathf.Clamp(currenHealth - damege, 0, startingHealth);

      if (currenHealth > 0)
      {
         hurtSound.Play();
         anim.SetTrigger("hurt");
         
      }
      else
      {
         if (!dead)
         {
            die.Play();
            anim.SetTrigger("death");
            GetComponent<PlayerMovement>().enabled = false;
            dead = true;
         }
        
      }
   }

   public void AddHealth(float value)
   {
      currenHealth = Mathf.Clamp(currenHealth + value, 0, startingHealth);
   }

  
}

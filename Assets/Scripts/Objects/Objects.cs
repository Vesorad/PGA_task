using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Objects : MonoBehaviour
{ 
   [Header("To Fill")]
   public GameController gameController;
   public AudioManager audioManager;
   [SerializeField] private Material material;
   public bool nearPlayer;
   private void OnMouseEnter()
  {
     material.color = Color.gray;
  }
   private void OnMouseExit()
  {
     material.color = Color.white;
  }
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.tag=="Player")
      {
         nearPlayer = true;
      }
   }
   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.tag=="Player")
      {
         nearPlayer = false;
      }
   }

   
   
   
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{ 
   
  [Header("Chest")]
  [SerializeField] private GameObject closeChest;
  [SerializeField] private GameObject openChest;
  [SerializeField] private Material chestMaterial;
  [SerializeField] private GameObject decisonPanel;
  
  private bool _nearChest;
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.tag=="Player")
      {
         _nearChest = true;
      }
   }

   private void OnMouseEnter()
   {
      chestMaterial.color = Color.gray;
   }

   private void OnMouseExit()
   {
      chestMaterial.color = Color.white;
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.tag=="Player")
      {
         _nearChest = false;
      }
   }

   private void OnMouseDown()
   {
      if (_nearChest)
      {
         openChest.SetActive(true);
         closeChest.SetActive(false);
      }
   }
   
}

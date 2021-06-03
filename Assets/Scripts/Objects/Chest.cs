using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Objects
{
    [SerializeField] private GameObject closeChest;
    [SerializeField] private GameObject openChest;
    [SerializeField] private GameObject key;
    
    public void OpenChest()
    {
        closeChest.SetActive(false);
        openChest.SetActive(true);
        gameController.isChestOpen = true;
        key.SetActive(true);
        audioManager.Play("Chest");
    }

    public void CloseChest()
    {
        closeChest.SetActive(true);
        openChest.SetActive(false);
        gameController.isChestOpen = false;
    }
    private  void OnMouseDown()
    {
        if (nearPlayer)
        {
            if (!gameController.isChestOpen)
            {
                gameController.Decison("Open?");
            }
        }
    }
}

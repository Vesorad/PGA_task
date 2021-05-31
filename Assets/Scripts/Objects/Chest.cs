using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Objects
{
    [SerializeField] private GameObject closeChest;
    [SerializeField] private GameObject openChest;
    
    public void OpenChest()
    {
        closeChest.SetActive(false);
        openChest.SetActive(true);
        gameController.isOpen = true;
    }

    public void CloseChest()
    {
        closeChest.SetActive(true);
        openChest.SetActive(false);
        gameController.isOpen = false;
    }
    private  void OnMouseDown()
    {
        if (nearPlayer)
        {
            if (!gameController.isOpen)
            {
                gameController.Decison("Open?");
            }
        }
    }
}

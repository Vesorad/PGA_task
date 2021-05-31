using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Objects
{

    private  void OnMouseDown()
    {
        if (nearPlayer)
        {
            if (!gameController.keyTaken)
            {
                gameController.Decison("Take?");
            }
        }
    }
    public void TakeKey()
    {
        if (gameController.isOpen)
        {
            gameObject.SetActive(false);
            gameController.keyTaken = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Objects
{
    private  void OnMouseDown()
    {
        if (nearPlayer)
        {
            if (!gameController.keyTaken)
            {
                gameController.NeedKeyPanel();
            }
            else
            {
                gameController.Decison("Open?");
            }
        }
    }
    public void OpenDoor()
    {
        if (gameController.keyTaken)
        {
            audioManager.Play("Door");
            gameObject.SetActive(false);
            gameController.isPaused = true;
            gameController.GameOver();
        }
    }
}

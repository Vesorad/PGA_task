using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
   [SerializeField] private GameObject decisonPanel;
   [SerializeField] private GameObject needKeyPanel;
   [SerializeField] private GameObject startGamePanel;
   [SerializeField] private Text panelText;
   [SerializeField] private Text timer;
   
   [HideInInspector] public bool isPaused=true;
   [HideInInspector] public bool isOpen;
   [HideInInspector] public bool keyTaken;

   private float _time=0;
   private bool _startTime;
   private void Update()
   {
      if (_startTime)
      {
         _time += (1 * Time.deltaTime);
         timer.text = _time.ToString();
      }
     
   }

   private void PauseGame()
   {
      isPaused = true;
   }
   public void ResumeGame()
   {
      isPaused = false;
   }

   public void StartGame()
   {
      _startTime = true;
      startGamePanel.SetActive(false);
      ResumeGame();
   }
   public void NeedKeyPanel()
   {
      needKeyPanel.SetActive(true);
      PauseGame();
   }
   public void Decison(string textInPanel)
   {
      panelText.text = textInPanel;
      PauseGame();
      decisonPanel.SetActive(true);
   }
}

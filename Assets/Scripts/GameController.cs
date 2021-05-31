using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = System.Random;

public class GameController : MonoBehaviour
{
   [Header("Panels")]
   [SerializeField] private GameObject decisonPanel;
   [SerializeField] private GameObject needKeyPanel;
   [SerializeField] private GameObject startGamePanel;
   [SerializeField] private GameObject endGamePanel;
   
   [Header("Texts")]
   [SerializeField] private Text textInPanelDec;
   [SerializeField] private Text timer;
   [SerializeField] private Text endGameTimer;
   
   [Header("Objects")]
   [SerializeField] private Transform door;
   [SerializeField] private Transform player;
   [SerializeField] private GameObject main;
   [SerializeField] private Chest chest;
   
   
   [HideInInspector] public bool isPaused=true;
   [HideInInspector] public bool isOpen;
   [HideInInspector] public bool keyTaken;
   [HideInInspector] public bool isDoorOpen;
   private float _time;
   private bool _startTime;
   private void Start()
   {
      isPaused = true;
   }
   private void Update()
   {
      if (_startTime && !isDoorOpen)
      {
         _time += (1 * Time.deltaTime);
         timer.text = _time.ToString();
      }
   }
   public void ResumeGame()
   {
      isPaused = false;
   }

   public void StartGame()
   {
      ///////////////////////// RESTART GAME
      keyTaken = false;
      isDoorOpen = false;
      chest.CloseChest();
      main.SetActive(true);
      player.position = new Vector3(10, 1, -10);
      _time = 0;
      /////////////////////////START GAME
      Random random = new Random();
      chest.transform.position = new Vector3(random.Next(1, 19), 1, random.Next(-18, -9));
      door.transform.position = new Vector3(random.Next(0, 16), 1, random.Next(-9, 0));
      _startTime = true;
      startGamePanel.SetActive(false);
      ResumeGame();

   }

   public void GameOver()
   {
      isDoorOpen = true;
      endGamePanel.SetActive(true);
      endGameTimer.text = _time.ToString();
   }
   public void NeedKeyPanel()
   {
      needKeyPanel.SetActive(true);
      isPaused = true;
   }
   public void Decison(string textInPanel)
   {
      textInPanelDec.text = textInPanel;
      isPaused = true;
      decisonPanel.SetActive(true);
   }
}

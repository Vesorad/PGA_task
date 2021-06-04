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
   [Header("Decison Panel")]
   [SerializeField] private GameObject decisonPanel;
   [SerializeField] private Text textInPanelDec;
   
   [Header("Start Game Panel")]
   [SerializeField] private GameObject startGamePanel;
   [SerializeField] private Text bestTimeStart;
   
   [Header("End Game Panel")]
   [SerializeField] private GameObject endGamePanel;
   [SerializeField] private Text bestTimeEnd;
   
   [Header("In Game Canvas")]
   [SerializeField] private GameObject needKeyPanel;
   [SerializeField] private Text timer;
   [SerializeField] private Text endGameTimer;
   
   [Header("Objects")]
   [SerializeField] private Transform door;
   [SerializeField] private Door main;
   [SerializeField] private Chest chest;
   [SerializeField] private Key key;
   [SerializeField] private Transform player;

   [HideInInspector] public bool isPaused=true;
   [HideInInspector] public bool isChestOpen;
   [HideInInspector] public bool keyTaken;
   [HideInInspector] public bool isDoorOpen;
   private float _time;
   private bool _startTime;
   
   private void Start()
   {
      isPaused = true;
      UpdateBestTime();
   }
   private void Update()
   {
      if (_startTime && !isDoorOpen)
      {
         _time += (1 * Time.deltaTime);
         timer.text = _time.ToString();
      }
   }

   private void UpdateBestTime()
   {
      bestTimeStart.text = PlayerPrefs.GetFloat("BestTime",0).ToString();
      bestTimeEnd.text = PlayerPrefs.GetFloat("BestTime",0).ToString();
   }

   public void Result()
   {
      if (!isDoorOpen && keyTaken)
      {
         main.OpenDoor();
      }
      if (!keyTaken && isChestOpen)
      {
         key.TakeKey();
      }
      if (!isChestOpen)
      {
         chest.OpenChest();
      }
   }

   public void ResumeGame()
   {
      isPaused = false;
   }

   public void StartGame()
   {
      /////////////////////////GAME RESTART
      keyTaken = false;
      isDoorOpen = false;
      chest.CloseChest();
      main.gameObject.SetActive(true);
      player.position = new Vector3(10, 1, -10);
      _time = 0;
      /////////////////////////START GAME
      Random random = new Random();
      chest.transform.position = new Vector3(1, 1, random.Next(-19, -1));
      door.transform.position = new Vector3(random.Next(2, 16), 1, 0);
      _startTime = true;
      startGamePanel.SetActive(false);
      ResumeGame();

   }

   public void GameOver()
   {
      if (_time< PlayerPrefs.GetFloat("BestTime",0))
      {
         PlayerPrefs.SetFloat("BestTime", _time);
      }
      isDoorOpen = true;
      endGamePanel.SetActive(true);
      endGameTimer.text = _time.ToString();
      UpdateBestTime();
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

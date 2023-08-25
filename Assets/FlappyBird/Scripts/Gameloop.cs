using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gameloop : MonoBehaviour
{
    public GameObject Player;
    public bool GameIsRunning =false;

    void Start()
    {
        PauseGame();
        endMenu.SetActive(false);
    }


    void PauseGame()
    {
        Time.timeScale = 0;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        GameIsRunning=false;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        GameIsRunning = true;
    }
 
    //---------------------------------------------------UI ZONE
    public GameObject startButton;
    public GameObject endMenu;
    public TextMeshProUGUI hp_text;
    public Hp life_point;
    public void StartGame()
    {
        ResumeGame();
        startButton.SetActive(false);
    }
    public void EndGame()
    {
        PauseGame();
        endMenu.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        hp_text.SetText("Current HP: " +life_point.currenthp.ToString());
    }
}

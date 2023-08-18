using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameloop : MonoBehaviour
{
    public Action OnPressed;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
        OnPressed += ResumeGame;
        endMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //OnPressed?.Invoke();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
 
    //---------------------------------------------------UI ZONE
    public GameObject startButton;
    public GameObject endMenu;
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
}

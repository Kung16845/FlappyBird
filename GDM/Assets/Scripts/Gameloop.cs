using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameloop : MonoBehaviour
{
    public Action OnPressed;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = findPlayer();
        PauseGame();
        OnPressed += ResumeGame;
    }

    // Update is called once per frame
    void Update()
    {
        OnPressed?.Invoke();
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
    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    GameObject findPlayer()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Player");

        if (gameObjects.Length == 0)
        {
            Debug.Log("No GameObjects are tagged with 'Player'");
            return null;
        }
        return gameObjects[0];
    }

}

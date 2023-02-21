using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool canPause = true;
    public bool canUnpause = false;

    public GameObject pauseMenu;

    void Start()
    {
        canPause = true;
        pauseMenu = GameObject.FindGameObjectWithTag("DarkScreen");
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && canPause)
        {
            PauseGame();
        }

        if (canPause == false && Input.GetKeyDown(KeyCode.O))
        {
            ResumeGame();
        }

        if (canPause == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
        canPause = false;
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        canPause = true;
        pauseMenu.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject confirmationMenu;

    public static bool isPaused = false;

    void Start() {
        pauseMenu.SetActive(false);
        confirmationMenu.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            //PauseTheGame();
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("RESUMED");
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("PAUSED");
    }

    public void PreExitTheGame() {
        confirmationMenu.SetActive(true);
    }

    public void ExitTheGame() {
        Application.Quit();
    }
}

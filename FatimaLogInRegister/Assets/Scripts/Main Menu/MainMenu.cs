using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button startButton;
    public Button loadButton;
    public Button optionsButton;
    public Button exitButton;

    /*public string playGame;
    public string loadGame;
    public string options;
    public string exitGame;*/

    void Start()
    {
        ButtonsAppear();
    }

    IEnumerator ButtonsAppear()
    {
        startButton.interactable = false;
        loadButton.interactable = false;
        optionsButton.interactable = false;
        exitButton.interactable = false;
        yield return new WaitForSeconds(4000);
        startButton.interactable = true;
        loadButton.interactable = true;
        optionsButton.interactable = true;
        exitButton.interactable = true;
    }

    public void StartGame() {

        PlayerPrefs.SetInt("CurrentCredibilityScore", 0);
        PlayerPrefs.SetInt("CurrentXPScore", 0);

        //SceneManager.LoadScene("JobInterview");
        SceneManager.LoadScene("ScenarioChoice");
    }

    public void LoadGame() {
        //load the Load Game canvas or scene

    }

    public void Options() {
        //load the Options canvas or scene
        SceneManager.LoadScene("Options");
    }

    public void ExitGame() {
        Application.Quit();
    }
}

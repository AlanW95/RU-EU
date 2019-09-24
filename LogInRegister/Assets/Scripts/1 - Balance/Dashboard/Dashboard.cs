﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dashboard : MonoBehaviour
{

    public Slider proAntiSlider;

    public Slider topThemeSlider, secondTopThemeSlider, thirdTopThemeSlider; //used to update score with theme score

    public TextMeshProUGUI topTheme, secondTopTheme, thirdTopTheme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("CurrentSocialScore");
        PlayerPrefs.GetInt("CurrentEnvironmentScore");
        PlayerPrefs.GetInt("CurrentRightsAndResponsibilitiesScore");
        PlayerPrefs.GetInt("CurrentSafetyAndSecurityScore");
        PlayerPrefs.GetInt("CurrentEmotionalScore");
        PlayerPrefs.GetInt("CurrentEconomyScore");
        PlayerPrefs.GetInt("CurrentPoliticalScore");
        PlayerPrefs.GetInt("CurrentHistoricScore");
        PlayerPrefs.GetInt("CurrentCultureScore");
        PlayerPrefs.GetInt("CurrentGeographyScore");

        proAntiSlider.value = PlayerPrefs.GetInt("CredibilityScore");
        //topThemeSlider.value = PlayerPrefs.GetInt("");

        topTheme.text = PlayerPrefs.GetString("TopTheme");
        secondTopTheme.text = PlayerPrefs.GetString("SecondTheme");

        TopThemeSliderValue();
        SecondThemeSliderValue();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Journalist");
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ReturnToWorkplace() {
        SceneManager.LoadScene("Journalist");
    }

    public void LoadFinalAssignment() {
        SceneManager.LoadScene("FinalAssignment");
    }

    public void TopThemeSliderValue() {

        if (topTheme.text == "Social") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Environment") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Rights & Responsibilities") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Security") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Emotional") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Economy") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Political") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Historic") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Culture") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Geography") {
            int topScore = PlayerPrefs.GetInt("TopThemeScore");
            topThemeSlider.value = topScore;
        }
    }

    public void SecondThemeSliderValue() {
        if (secondTopTheme.text == "Social") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Environment") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Rights & Responsibilities") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Security") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Emotional") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Economy") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Political") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Historic") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Culture") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Geography") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeScore");
            secondTopThemeSlider.value = secondTopScore;
        }
    }
}

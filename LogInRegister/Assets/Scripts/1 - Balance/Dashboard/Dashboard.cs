using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dashboard : MonoBehaviour
{

    public Slider proAntiSlider;

    public Slider topThemeSlider; //used to update score with theme score

    public TextMeshProUGUI topTheme;

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

        TopThemeSliderValue();

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

    public void TopThemeSliderValue() {

        if (topTheme.text == "Social") {
            int topScore = PlayerPrefs.GetInt("CurrentSocialScore");
            topThemeSlider.value = topScore;

        }

        if (topTheme.text == "Environment") {
            int topScore = PlayerPrefs.GetInt("CurrentEnvironmentScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Rights & Responsibilities") {
            int topScore = PlayerPrefs.GetInt("CurrentRightsAndResponsibilitiesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Safety & Security") {
            int topScore = PlayerPrefs.GetInt("CurrentSafetyAndSecurityScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Emotional") {
            int topScore = PlayerPrefs.GetInt("CurrentEmotionalScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Economy") {
            int topScore = PlayerPrefs.GetInt("CurrentEconomyScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Political") {
            int topScore = PlayerPrefs.GetInt("CurrentPoliticalScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Historic") {
            int topScore = PlayerPrefs.GetInt("CurrentHistoricScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Culture") {
            int topScore = PlayerPrefs.GetInt("CurrentCultureScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Geography") {
            int topScore = PlayerPrefs.GetInt("CurrentGeographyScore");
            topThemeSlider.value = topScore;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dashboard : MonoBehaviour
{

    public Slider proAntiSlider;
    public Slider topThemeSlider;

    public TextMeshProUGUI topTheme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        proAntiSlider.value = PlayerPrefs.GetInt("ProAntiSlider");
        topThemeSlider.value = PlayerPrefs.GetInt("");

        topTheme.text = PlayerPrefs.GetString("TopTheme");

        TopThemeSliderValue();       
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void TopThemeSliderValue() {
        if (topTheme.text == "Social") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentSocialScore");
        }

        if (topTheme.text == "Environment") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentEnvironmentScore");
        }

        if (topTheme.text == "Rights & Responsibilities") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentRightsAndResponsibilitiesScore");
        }

        if (topTheme.text == "Safety & Security") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentSafetyAndSecurityScore");
        }

        if (topTheme.text == "Emotional") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentEmotionalScore");
        }

        if (topTheme.text == "Economy") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentEconomyScore");
        }

        if (topTheme.text == "Political") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentPoliticalScore");
        }

        if (topTheme.text == "Historic") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentHistoricScore");
        }

        if (topTheme.text == "Culture") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentCultureScore");
        }

        if (topTheme.text == "Geography") {
            topThemeSlider.value = PlayerPrefs.GetInt("CurrentGeographyScore");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DashboardAttitudes : MonoBehaviour
{
    public Slider proAntiSlider;

    public Slider topThemeSlider, secondTopThemeSlider; //used to update score with theme score

    public TextMeshProUGUI topTheme, secondTopTheme;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        PlayerPrefs.GetInt("CurrentAttitudesSocialScore");
        PlayerPrefs.GetInt("CurrentAttitudesEnvironmentScore");
        PlayerPrefs.GetInt("CurrentAttitudesRightsAndResponsibilitiesScore");
        PlayerPrefs.GetInt("CurrentAttitudesSafetyAndSecurityScore");
        PlayerPrefs.GetInt("CurrentAttitudesEmotionalScore");
        PlayerPrefs.GetInt("CurrentAttitudesEconomyScore");
        PlayerPrefs.GetInt("CurrentAttitudesPoliticalScore");
        PlayerPrefs.GetInt("CurrentAttitudesHistoricScore");
        PlayerPrefs.GetInt("CurrentAttitudesCultureScore");
        PlayerPrefs.GetInt("CurrentAttitudesGeographyScore");

        proAntiSlider.value = PlayerPrefs.GetInt("CredibilityAttitudesScore");
        //topThemeSlider.value = PlayerPrefs.GetInt("");

        topTheme.text = PlayerPrefs.GetString("TopAttitudesTheme");
        secondTopTheme.text = PlayerPrefs.GetString("SecondAttitudesTheme");

        TopThemeSliderValue();
        SecondThemeSliderValue();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("AttitudesMobileWorkplace");
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ReturnToWorkplace() {
        SceneManager.LoadScene("AttitudesMobileWorkplace");
    }

    public void LoadFinalAssignment() {
        SceneManager.LoadScene("FinalAssignmentAttitudes");
    }

    public void TopThemeSliderValue() {

        if (topTheme.text == "Social") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Environment") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Rights & Responsibilities") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Security") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Emotional") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Economy") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Political") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Historic") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Culture") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Geography") {
            int topScore = PlayerPrefs.GetInt("TopThemeAttitudesScore");
            topThemeSlider.value = topScore;
        }
    }

    public void SecondThemeSliderValue() {
        if (secondTopTheme.text == "Social") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Environment") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Rights & Responsibilities") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Security") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Emotional") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Economy") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Political") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Historic") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Culture") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Geography") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeAttitudesScore");
            secondTopThemeSlider.value = secondTopScore;
        }
    }
}

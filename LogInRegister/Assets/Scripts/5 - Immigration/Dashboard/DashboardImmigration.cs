using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DashboardImmigration : MonoBehaviour
{
    public Slider proAntiSlider;

    public Slider topThemeSlider, secondTopThemeSlider; //used to update score with theme score

    public TextMeshProUGUI topTheme, secondTopTheme;

    private bool isScenarioComplete = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        PlayerPrefs.GetInt("CurrentImmigrationSocialScore");
        PlayerPrefs.GetInt("CurrentImmigrationEnvironmentScore");
        PlayerPrefs.GetInt("CurrentImmigrationRightsAndResponsibilitiesScore");
        PlayerPrefs.GetInt("CurrentImmigrationSafetyAndSecurityScore");
        PlayerPrefs.GetInt("CurrentImmigrationEmotionalScore");
        PlayerPrefs.GetInt("CurrentImmigrationEconomyScore");
        PlayerPrefs.GetInt("CurrentImmigrationPoliticalScore");
        PlayerPrefs.GetInt("CurrentImmigrationHistoricScore");
        PlayerPrefs.GetInt("CurrentImmigrationCultureScore");
        PlayerPrefs.GetInt("CurrentImmigrationGeographyScore");

        proAntiSlider.value = PlayerPrefs.GetInt("CredibilityImmigrationScore");
        //topThemeSlider.value = PlayerPrefs.GetInt("");

        topTheme.text = PlayerPrefs.GetString("TopImmigrationTheme");
        secondTopTheme.text = PlayerPrefs.GetString("SecondImmigrationTheme");

        TopThemeSliderValue();
        SecondThemeSliderValue();

        Debug.Log(PlayerPrefs.GetString("TopImmigrationTheme"));
        Debug.Log(PlayerPrefs.GetString("SecondImmigrationTheme"));

        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("ImmigrationJournalist");
        }*/
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ReturnToWorkplace() {
        SceneManager.LoadScene("ImmigrationJournalist");
    }

    public void LoadFinalAssignment() {
        SceneManager.LoadScene("FinalAssignmentImmigration");
    }

    public void ReturnToMap() {
        //good to say that the scenario has been complete
        //use the boolToInt, intToBool functions to help
        isScenarioComplete = true;
        //Add in PlayerPrefs to set this
        PlayerPrefs.SetInt("GreeceScenarioComplete", boolToInt(isScenarioComplete));

        SceneManager.LoadScene("ScenarioChoice");
    }

    public void TopThemeSliderValue() {

        if (topTheme.text == "Social") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Environment") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Rights & Responsibilities") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Security") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Emotional") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Economy") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Political") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Historic") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Culture") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }

        if (topTheme.text == "Geography") {
            int topScore = PlayerPrefs.GetInt("TopThemeImmigrationScore");
            topThemeSlider.value = topScore;
        }
    }

    public void SecondThemeSliderValue() {
        if (secondTopTheme.text == "Social") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Environment") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Rights & Responsibilities") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Security") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Emotional") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Economy") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Political") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Historic") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Culture") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }

        if (secondTopTheme.text == "Geography") {
            int secondTopScore = PlayerPrefs.GetInt("SecondThemeImmigrationScore");
            secondTopThemeSlider.value = secondTopScore;
        }
    }

    int boolToInt(bool val) {
        if (val) {
            return 1;
        }
        else {
            return 0;
        }
    }

    bool intToBool(int val) {
        if (val != 0) {
            return true;
        }
        else {
            return false;
        }
    }
}

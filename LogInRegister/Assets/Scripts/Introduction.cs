using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Introduction : MonoBehaviour
{
    private string introductoryEN, introductoryGR, introductoryDE, introductoryNL, introductoryHR;
    //public TextMeshProUGUI introductoryText;
    public Text introductoryText;
    private bool english = false;
    private bool greek = false;
    private bool german = false;
    private bool dutch = false;
    private bool croatian = false;

    private bool ukScenarioComplete = false;
    private bool germanyScenarioComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        english = intToBool(PlayerPrefs.GetInt("EnglishSelected"));
        greek = intToBool(PlayerPrefs.GetInt("GreekSelected"));
        german = intToBool(PlayerPrefs.GetInt("GermanSelected"));
        dutch = intToBool(PlayerPrefs.GetInt("DutchSelected"));
        croatian = intToBool(PlayerPrefs.GetInt("CroatianSelected"));

        //english = true;
        //greek = false;

        //later languages
        //german = false;
        //dutch = false;
        //croatian = false;

        //Introductory Text for English being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryEnglish", "Hello and welcome to RU EU, the educational game around issues of identity in Europe and the European Union. " +
            "\n\nThe game will begin with you going through the process of being “hired” as a journalist to complete an assignment around identity and Europe. " +
            "As such you will be asked a series of initial questions including some demographic data and attitudes about identity. " +
            "\n\nAfter these questions you will be hired and then asked to complete 5 scenarios. Each scenario provides a series of tasks choosing information from simulated interviews, " +
            "newsfeeds, discussions and developing them into an outline for a magazine article. Although you never have to write the article in the game, you do have to at various points of each scenario, " +
            "select information that could be included in the article itself. At the end of each scenario, you will have to choose and further refine from the information you have selected in that scenario. " +
            "\n\nOnce you have completed all the scenarios, the game will then end with a series of questions around the issues of identity around Europe. Once you have answered these, you have completed the RU EU educational game. " +
            "\n\nThank you for selecting this game and good luck, we hope you enjoy playing it!");

        //Introductory Text for Greek being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryGreek", "Hello and welcome to RU EU, the educational game around issues of identity in Europe and the European Union. " +
            "\n\nThe game will begin with you going through the process of being “hired” as a journalist to complete an assignment around identity and Europe. " +
            "As such you will be asked a series of initial questions including some demographic data and attitudes about identity. " +
            "\n\nAfter these questions you will be hired and then asked to complete 5 scenarios. Each scenario provides a series of tasks choosing information from simulated interviews, " +
            "newsfeeds, discussions and developing them into an outline for a magazine article. Although you never have to write the article in the game, you do have to at various points of each scenario, " +
            "select information that could be included in the article itself. At the end of each scenario, you will have to choose and further refine from the information you have selected in that scenario. " +
            "\n\nOnce you have completed all the scenarios, the game will then end with a series of questions around the issues of identity around Europe. Once you have answered these, you have completed the RU EU educational game. " +
            "\n\nThank you for selecting this game and good luck, we hope you enjoy playing it!");

        //Introductory Text for German being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryGerman", "[INSERT TEXT HERE]");

        //Introductory Text for Dutch being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryDutch", "[INSERT TEXT HERE]");

        //Introductory Text for Croatian being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryCroatian", "[INSERT TEXT HERE]");

        //Reading all previous set PlayerPrefs so they can be set depending on the bool state of each language in the Update()
        introductoryEN = PlayerPrefs.GetString("IntroductoryEnglish");
        introductoryGR = PlayerPrefs.GetString("IntroductoryGreek");

        //debugging for starting game
        ukScenarioComplete = false;
        germanyScenarioComplete = false;
        PlayerPrefs.SetInt("UKScenarioComplete", boolToInt(ukScenarioComplete));
        PlayerPrefs.SetInt("GermanyScenarioComplete", boolToInt(germanyScenarioComplete));
    }

    // Update is called once per frame
    void Update()
    {
        if (english) {
            introductoryText.text = introductoryEN;
        }

        if (greek) {
            introductoryText.text = introductoryGR;
        }

        if (german) {
            introductoryText.text = introductoryDE;
        }

        if (dutch) {
            introductoryText.text = introductoryNL;
        }

        if (croatian) {
            introductoryText.text = introductoryHR;
        }
    }

    public void Continue() {
        //continue after pressing -> button
        SceneManager.LoadScene("Start");
    }

    int boolToInt(bool val) {
        if (val) {
            return 1;
        } else {
            return 0;
        }
    }

    bool intToBool(int val) {
        if (val != 0) {
            return true;
        } else {
            return false;
        }
    }
}

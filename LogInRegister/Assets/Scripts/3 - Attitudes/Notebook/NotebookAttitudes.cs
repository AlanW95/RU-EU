﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NotebookAttitudes : MonoBehaviour
{
    public GameObject[] notebook;

    //public TextMeshProUGUI[] interview1TextDisplay;
    public TextMeshProUGUI interview1TextDisplay1;
    public TextMeshProUGUI interview1TextDisplay2;
    public TextMeshProUGUI interview1TextDisplay3;
    public TextMeshProUGUI interview1TextDisplay4;
    public TextMeshProUGUI[] interview2TextDisplay;
    public TextMeshProUGUI[] discussionTextDisplay;
    public TextMeshProUGUI discussionTextDisplay1, discussionTextDisplay2, discussionTextDisplay3, discussionTextDisplay4;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
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

        //Interview 1
        interview1TextDisplay1.text = PlayerPrefs.GetString("AttitudesInterview1-1");
        interview1TextDisplay2.text = PlayerPrefs.GetString("AttitudesInterview1-2");
        interview1TextDisplay3.text = PlayerPrefs.GetString("AttitudesInterview1-3");
        interview1TextDisplay4.text = "";

        //Interview 2
        interview2TextDisplay[0].text = PlayerPrefs.GetString("AttitudesInterview2-1");
        interview2TextDisplay[1].text = PlayerPrefs.GetString("AttitudesInterview2-2");
        interview2TextDisplay[2].text = PlayerPrefs.GetString("AttitudesInterview2-3");
        interview2TextDisplay[3].text = "";

        //Discussion
        discussionTextDisplay1.text = PlayerPrefs.GetString("NewAttitudesDiscussion1");
        discussionTextDisplay2.text = PlayerPrefs.GetString("NewAttitudesDiscussion2");
        discussionTextDisplay3.text = "";
        discussionTextDisplay4.text = "";

        //Temp for example
        //discussionTextDisplay1.text = PlayerPrefs.GetString("NewLorryTruckDiscussion1");
        //discussionTextDisplay2.text = PlayerPrefs.GetString("NewLorryTruckDiscussion2");


        //Newsflash
    }

    public void HomePage() {
        notebook[0].SetActive(true);
        notebook[1].SetActive(false);
        notebook[2].SetActive(false);
        notebook[3].SetActive(false);
        notebook[4].SetActive(false);
    }

    public void Interview1() {
        notebook[0].SetActive(false);
        notebook[1].SetActive(true);
        notebook[2].SetActive(false);
        notebook[3].SetActive(false);
        notebook[4].SetActive(false);
    }

    public void Interview2() {
        notebook[0].SetActive(false);
        notebook[1].SetActive(false);
        notebook[2].SetActive(true);
        notebook[3].SetActive(false);
        notebook[4].SetActive(false);
    }

    public void Discussion() {
        notebook[0].SetActive(false);
        notebook[1].SetActive(false);
        notebook[2].SetActive(false);
        notebook[3].SetActive(true);
        notebook[4].SetActive(false);
    }

    public void Newsflash() {
        notebook[0].SetActive(false);
        notebook[1].SetActive(false);
        notebook[2].SetActive(false);
        notebook[3].SetActive(false);
        notebook[4].SetActive(true);
    }

    public void ReturnToWorkplace() {
        SceneManager.LoadScene("Journalist");
    }
}
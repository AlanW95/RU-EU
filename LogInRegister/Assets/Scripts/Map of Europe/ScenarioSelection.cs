﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScenarioSelection : MonoBehaviour {

    public Button uk, germany, netherlands, croatia, greece;

    public GameObject startCanvas, mapCanvas;

    public GameObject balanceUK; //UK
    public GameObject attitudesDE; //Germany
    public GameObject workPartnerNL; //Netherlands
    public GameObject identityHR; //Croatia
    public GameObject immigrationGR; //Greece

    private bool ukScenarioComplete = false;
    private bool germanyScenarioComplete = false;
    private bool greeceScenarioComplete = false;
    private bool croatiaScenarioComplete = false;
    private bool netherlandsScenarioComplete = false;

    public GameObject[] scenarioInformation;
    
    // Start is called before the first frame update
    void Start() {

        startCanvas.SetActive(true);

        ukScenarioComplete = intToBool(PlayerPrefs.GetInt("UKScenarioComplete"));
        germanyScenarioComplete = intToBool(PlayerPrefs.GetInt("GermanyScenarioComplete"));
        greeceScenarioComplete = intToBool(PlayerPrefs.GetInt("GreeceScenarioComplete"));
        croatiaScenarioComplete = intToBool(PlayerPrefs.GetInt("CroatiaScenarioComplete"));
        netherlandsScenarioComplete = intToBool(PlayerPrefs.GetInt("NetherlandsScenarioComplete"));
    }

    void Update() {
        if (ukScenarioComplete == true) {
            PlayerPrefs.SetInt("UKScenarioComplete", boolToInt(ukScenarioComplete));
            uk.interactable = false;
        }

        if (germanyScenarioComplete == true) {
            PlayerPrefs.SetInt("GermanyScenarioComplete", boolToInt(germanyScenarioComplete));
            germany.interactable = false;
        }

        if (greeceScenarioComplete == true) {
            PlayerPrefs.SetInt("GreeceScenarioComplete", boolToInt(greeceScenarioComplete));
            greece.interactable = false;
        }

        if (croatiaScenarioComplete == true) {
            PlayerPrefs.SetInt("CroatiaScenarioComplete", boolToInt(croatiaScenarioComplete));
            croatia.interactable = false;
        }

        if (netherlandsScenarioComplete == true) {
            PlayerPrefs.SetInt("NetherlandsScenarioComplete", boolToInt(netherlandsScenarioComplete));
            netherlands.interactable = false;
        }

        if (ukScenarioComplete == true && germanyScenarioComplete == true && greeceScenarioComplete == true && croatiaScenarioComplete == true && netherlandsScenarioComplete == true) {
            //this might change to have a thank you for playing screen
            SceneManager.LoadScene("PostQuestions");
        }
    }

    public void MapCanvas() {
        startCanvas.SetActive(false);
        mapCanvas.SetActive(true);

        balanceUK.SetActive(true);
        attitudesDE.SetActive(true);
        workPartnerNL.SetActive(true);
        identityHR.SetActive(true);
        immigrationGR.SetActive(true);
    }

    public void BalanceScenario() {
        SceneManager.LoadScene("MobilePhone");
    }

    public void AttitudesScenario() {
        //germanyScenarioComplete = true;
        //PlayerPrefs.SetInt("GermanyComplete", boolToInt(germanyScenarioComplete));

        germany.interactable = false;
        SceneManager.LoadScene("MobilePhoneAttitudes");
        //Debug.Log("This will go to the Germany themed Journalist's Desk!");
    }

    public void WorkingPartnerCountriesScenario() {
        SceneManager.LoadScene("MobilePhoneNL");
    }

    public void EuropeanIdentityScenario() {
        SceneManager.LoadScene("MobilePhoneChanges");
    }

    public void ImmigrationScenario() {
        SceneManager.LoadScene("MobilePhoneImmigration");
    }

    //When a Scenario is selected on the map, the box to accept or decline appears. When the user presses the 'X' the box will disappear
    public void DeclineScenario()
    {
        //boxUK.SetActive(false);
        //boxNL.SetActive(false);
        //boxDE.SetACtive(false);
        //boxHR.SetActive(false);
        //boxGR.SetActive(false);
    }

    public void UKInfo() {
        scenarioInformation[0].SetActive(true);
        scenarioInformation[1].SetActive(false);
        scenarioInformation[2].SetActive(false);
        scenarioInformation[3].SetActive(false);
        scenarioInformation[4].SetActive(false);
    }

    public void NetherlandsInfo() {
        scenarioInformation[0].SetActive(false);
        scenarioInformation[1].SetActive(true);
        scenarioInformation[2].SetActive(false);
        scenarioInformation[3].SetActive(false);
        scenarioInformation[4].SetActive(false);
    }

    public void GermanyInfo() {
        scenarioInformation[0].SetActive(false);
        scenarioInformation[1].SetActive(false);
        scenarioInformation[2].SetActive(true);
        scenarioInformation[3].SetActive(false);
        scenarioInformation[4].SetActive(false);
    }

    public void CroatiaInfo() {
        scenarioInformation[0].SetActive(false);
        scenarioInformation[1].SetActive(false);
        scenarioInformation[2].SetActive(false);
        scenarioInformation[3].SetActive(true);
        scenarioInformation[4].SetActive(false);
    }

    public void GreeceInfo() {
        scenarioInformation[0].SetActive(false);
        scenarioInformation[1].SetActive(false);
        scenarioInformation[2].SetActive(false);
        scenarioInformation[3].SetActive(false);
        scenarioInformation[4].SetActive(true);
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

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

    //public GameObject boxUK;
    //public GameObject boxNL;
    //public GameObject boxDE;
    //public GameObject boxHR;
    //public GameObject boxGR;

    private bool ukScenarioComplete, germanyScenarioComplete;

    public GameObject[] scenarioInformation;
    //scenarioInformation[0] = UK, scenarioInformation[1] = Netherlands, scenarioInformation[2] = Germany, scenarioInformation[3] = Croatia, scenarioInformation[4] = Greece

    // Start is called before the first frame update
    void Start() {

        startCanvas.SetActive(true);

        ukScenarioComplete = intToBool(PlayerPrefs.GetInt("UKComplete"));
        germanyScenarioComplete = intToBool(PlayerPrefs.GetInt("GermanyComplete"));
    }

    void Update() {
        /*if (ukScenarioComplete && germanyScenarioComplete) {
            SceneManager.LoadScene("PostQuestions");
        }*/
    }

    public void MapCanvas() {
        startCanvas.SetActive(false);
        mapCanvas.SetActive(true);

        balanceUK.SetActive(true);
        attitudesDE.SetActive(true);
        workPartnerNL.SetActive(true);
        identityHR.SetActive(true);
        immigrationGR.SetActive(true);

        //boxUK.SetActive(false);
        //boxNL.SetActive(false);
        //boxDE.SetActive(false);
        //boxHR.SetActive(false);
        //boxGR.SetActive(false);
    }

    public void BalanceScenario() {
        ukScenarioComplete = true;
        PlayerPrefs.SetInt("UKComplete", boolToInt(ukScenarioComplete));

        uk.interactable = false;
        SceneManager.LoadScene("MobilePhone");
    }

    public void AttitudesScenario() {
        germanyScenarioComplete = true;
        PlayerPrefs.SetInt("GermanyComplete", boolToInt(germanyScenarioComplete));

        germany.interactable = false;
        SceneManager.LoadScene("MobilePhoneAttitudes");
        //Debug.Log("This will go to the Germany themed Journalist's Desk!");
    }

    public void WorkingPartnerCountriesScenario() {
        Debug.Log("This will go to the Netherlands themed Journalist's Desk!");
    }

    public void EuropeanIdentityScenario() {
        Debug.Log("This will go to the Croatia themed Journalist's Desk!");
    }

    public void ImmigrationScenario() {
        Debug.Log("This will go to the Greece themed Journalist's Desk!");
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

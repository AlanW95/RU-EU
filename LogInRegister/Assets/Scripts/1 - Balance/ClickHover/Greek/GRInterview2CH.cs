﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GRInterview2CH : GRBrexitWorkplace
{
    public GameObject interviewTool;

    void OnMouseDown() {
        SceneManager.LoadScene("GRLeaverInterview");
        Interview2();

        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);
    }

    private void OnMouseOver() {
        Debug.Log("You are hovering over this object.");

        interviewTool.SetActive(true); ;
    }

    private void OnMouseExit() {
        interviewTool.SetActive(false);
    }
}
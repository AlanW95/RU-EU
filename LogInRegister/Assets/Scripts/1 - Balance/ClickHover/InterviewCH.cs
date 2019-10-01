using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterviewCH : BrexitWorkplace
{
    public GameObject interviewTool;

    void OnMouseDown() {
        Interview1();
        SceneManager.LoadScene("RemainInterview");

        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        interviewTool.SetActive(true);
    }

    void OnMouseExit() {
        interviewTool.SetActive(false);
    }
}

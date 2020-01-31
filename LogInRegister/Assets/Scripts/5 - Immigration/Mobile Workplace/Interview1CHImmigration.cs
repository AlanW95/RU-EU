using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interview1CHImmigration : MobileWorkplaceImmigration
{
    public GameObject interviewTool;

    void OnMouseDown() {
        SceneManager.LoadScene("ImmigrationInterview1");
        Interview1();

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

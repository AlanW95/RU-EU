using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalAssignmentCHImmigration : MobileWorkplaceImmigration
{
    public GameObject finalAssignmentTool;

    void OnMouseDown() {
        //SceneManager.LoadScene("DashboardAttitudes"); //still to be added
        SceneManager.LoadScene("OpeningFAImmigration");
        //FinalAssignment();
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        finalAssignmentTool.SetActive(true);
    }

    void OnMouseExit() {
        finalAssignmentTool.SetActive(false);
    }
}

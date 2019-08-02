using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalAssignmentCH : MonoBehaviour
{
    public GameObject finalAssignmentTool;

    void OnMouseDown() {
        //SceneManager.LoadScene("FinalAssignment");
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        finalAssignmentTool.SetActive(true);
    }

    void OnMouseExit() {
        finalAssignmentTool.SetActive(false);
    }
}

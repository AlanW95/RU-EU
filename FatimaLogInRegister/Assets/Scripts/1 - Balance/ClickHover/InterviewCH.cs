using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterviewCH : MonoBehaviour
{
    public GameObject interviewTool;

    void OnMouseDown() {
        SceneManager.LoadScene("ProInterview");    
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        interviewTool.SetActive(true);
    }

    void OnMouseExit() {
        interviewTool.SetActive(false);
    }
}

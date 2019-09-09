using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interview2CH : MonoBehaviour
{

    public GameObject interviewTool;

    void OnMouseDown() {
        SceneManager.LoadScene("LeaverInterview");    
    }

    private void OnMouseOver() {
        Debug.Log("You are hovering over this object.");

        interviewTool.SetActive(true); ;
    }

    private void OnMouseExit() {
        interviewTool.SetActive(false);
    }
}

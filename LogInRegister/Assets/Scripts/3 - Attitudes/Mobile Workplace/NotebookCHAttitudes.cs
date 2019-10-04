using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotebookCHAttitudes : AttitudesMobileWorkplace
{
    public GameObject notebookTool;

    void OnMouseDown() {
        SceneManager.LoadScene("NotebookAttitudes"); //still to be added
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        notebookTool.SetActive(true);
    }

    void OnMouseExit() {
        notebookTool.SetActive(false);
    }
}

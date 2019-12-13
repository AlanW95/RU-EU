using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GRNotebookCH : GRBrexitWorkplace
{
    public GameObject notebookTool;

    void OnMouseDown() {
        SceneManager.LoadScene("GRNotebook");
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        notebookTool.SetActive(true);
    }

    void OnMouseExit() {
        notebookTool.SetActive(false);
    }
}

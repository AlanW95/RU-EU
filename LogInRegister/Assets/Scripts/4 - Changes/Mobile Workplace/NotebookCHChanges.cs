using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotebookCHChanges : MobileWorkplaceChanges
{
    public GameObject notebookTool;

    void OnMouseDown() {
        SceneManager.LoadScene("NotebookChanges"); //change depending on scenario
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        notebookTool.SetActive(true);
    }

    void OnMouseExit() {
        notebookTool.SetActive(false);
    }
}

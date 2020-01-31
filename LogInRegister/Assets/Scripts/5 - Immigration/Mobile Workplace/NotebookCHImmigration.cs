using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotebookCHImmigration : MobileWorkplaceImmigration
{
    public GameObject notebookTool;

    void OnMouseDown() {
        SceneManager.LoadScene("NotebookImmigration"); //change depending on scenario
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        notebookTool.SetActive(true);
    }

    void OnMouseExit() {
        notebookTool.SetActive(false);
    }
}

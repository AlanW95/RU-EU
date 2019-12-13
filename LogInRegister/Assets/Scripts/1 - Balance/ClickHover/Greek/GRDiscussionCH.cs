using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GRDiscussionCH : GRBrexitWorkplace
{
    public GameObject discussionAnimationTool;

    void OnMouseDown() {
        SceneManager.LoadScene("GRDiscussionTool");
        Discussion();

        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        discussionAnimationTool.SetActive(true);
    }

    void OnMouseExit() {
        discussionAnimationTool.SetActive(false);
    }
}

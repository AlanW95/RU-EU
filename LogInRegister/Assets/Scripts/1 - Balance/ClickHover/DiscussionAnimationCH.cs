using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscussionAnimationCH : BrexitWorkplace
{
    public GameObject discussionAnimationTool;

    void OnMouseDown() {
        SceneManager.LoadScene("DiscussionTool");
        //Interview2();

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

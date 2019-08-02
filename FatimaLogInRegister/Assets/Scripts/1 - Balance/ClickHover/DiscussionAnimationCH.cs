using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscussionAnimationCH : MonoBehaviour
{
    public GameObject discussionAnimationTool;

    void OnMouseDown() {
        SceneManager.LoadScene("DiscussionTool");
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        discussionAnimationTool.SetActive(true);
    }

    void OnMouseExit() {
        discussionAnimationTool.SetActive(false);
    }
}

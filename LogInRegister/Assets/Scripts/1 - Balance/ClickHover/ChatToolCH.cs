using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChatToolCH : MonoBehaviour {

    /*
     * Basic script ready to use when dealing with the 3D Objects on the Journalist's Mobile
     * Workplace.
     * On Mouse Down, you will most likely want to load a new scene.
     * Just replace Destroy(gameObject); with the necessary statement to do this.
     * This was basically used for testing purposes that the script was working as it should.
     * 
     * Already incorporating "using UnityEngine.SceneManagement;" for the scene change.
     * 
     * All you have to do is load statement below, replacing "SceneName" with the name of the scene.
     * SceneManager.LoadScene("SceneName");
     */

    public GameObject chatTool;

    void OnMouseDown() {
        SceneManager.LoadScene("MobilePhoneTool");
    }

    void OnMouseOver() {
        Debug.Log("You are hovering over this object");

        chatTool.SetActive(true);
    }

    void OnMouseExit() {
        chatTool.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalAssignment : MonoBehaviour {

    public GameObject[] tools;

    // Start is called before the first frame update
    void Start() {
        Interview1Tab();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Interview1Tab() {
        tools[0].SetActive(true); //Interview 1
        tools[1].SetActive(false); //Interview 2
        tools[2].SetActive(false); //Discussion
        tools[3].SetActive(false); //Newsflash
    }

    public void Interview2Tab() {
        tools[0].SetActive(false); //Interview 1
        tools[1].SetActive(true); //Interview 2
        tools[2].SetActive(false); //Discussion
        tools[3].SetActive(false); //Newsflash
    }

    public void DiscussionTab() {
        tools[0].SetActive(false); //Interview 1
        tools[1].SetActive(false); //Interview 2
        tools[2].SetActive(true); //Discussion
        tools[3].SetActive(false); //Newsflash}
    }

    public void NewsflashTab() {
        tools[0].SetActive(false); //Interview 1
        tools[1].SetActive(false); //Interview 2
        tools[2].SetActive(false); //Discussion
        tools[3].SetActive(true); //Newsflash
    }
}

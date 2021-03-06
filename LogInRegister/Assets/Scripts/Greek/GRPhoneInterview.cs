﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GRPhoneInterview : MonoBehaviour
{
    //public GameObject startCanvas, mainCanvas;
    public GameObject c1, c2; //, c3, c4, c5, c6, c7; //continue buttons
    public GameObject b1, b2;
    public GameObject finishedButton;

    public GameObject[] text;
    // Start is called before the first frame update
    void Start()
    {
        //mainCanvas.SetActive(true);
        Set1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //after clicking the button to pick up the phone... the start canvas disappears and the text appears.
    public void Set1() {
        //startCanvas.SetActive(false);
        //mainCanvas.SetActive(true);
        text[0].SetActive(true);
        text[1].SetActive(true);
        text[2].SetActive(true);

        text[3].SetActive(false);
        text[4].SetActive(false);
        text[5].SetActive(false);

        text[6].SetActive(false);
        text[7].SetActive(false);
        text[8].SetActive(false);

        //continue buttons
        c1.SetActive(true);
        c2.SetActive(false);

        b1.SetActive(false);
        b2.SetActive(false);

        finishedButton.SetActive(false);
    }

    public void Set2() {
        text[0].SetActive(false);
        text[1].SetActive(false);
        text[2].SetActive(false);
        c1.SetActive(false);
        b2.SetActive(false);

        text[3].SetActive(true);
        text[4].SetActive(true);
        text[5].SetActive(true);
        c2.SetActive(true);
        b1.SetActive(true);

        text[6].SetActive(false);
        text[7].SetActive(false);
        text[8].SetActive(false);
        finishedButton.SetActive(false);
    }

    public void Set3() {
        text[0].SetActive(false);
        text[1].SetActive(false);
        text[2].SetActive(false);

        text[3].SetActive(false);
        text[4].SetActive(false);
        text[5].SetActive(false);
        c2.SetActive(false);
        b1.SetActive(false);

        text[6].SetActive(true);
        text[7].SetActive(true);
        text[8].SetActive(true);
        finishedButton.SetActive(true);
        b2.SetActive(true);
    }

    public void Finished() {
        SceneManager.LoadScene("JobInterview");
        //SceneManager.LoadScene("GRJobInterview");
    }
}

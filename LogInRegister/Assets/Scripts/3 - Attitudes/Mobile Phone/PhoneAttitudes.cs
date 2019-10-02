using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PhoneAttitudes : MonoBehaviour
{
    public GameObject startCanvas, mainCanvas;
    public GameObject c1, c2, c3, c4, c5, c6, c7; //continue buttons
    public GameObject finishedButton;

    public GameObject[] text;

    // Start is called before the first frame update
    void Start() {
        startCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        //Set1();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("AttitudesMobileWorkplace");
        }
    }

    //after clicking the button to pick up the phone... the start canvas disappears and the text appears.
    public void Set1() {
        startCanvas.SetActive(false);
        mainCanvas.SetActive(true);

        text[0].SetActive(true);
        text[1].SetActive(true);
        text[2].SetActive(true);
        text[3].SetActive(false);
        text[4].SetActive(false);
        text[5].SetActive(false);
        text[6].SetActive(false);
        text[7].SetActive(false);
        text[8].SetActive(false);
        text[9].SetActive(false);
        text[10].SetActive(false);
        text[11].SetActive(false);
        text[12].SetActive(false);
        text[13].SetActive(false);
        text[14].SetActive(false);
        text[15].SetActive(false);
        text[16].SetActive(false);
        text[17].SetActive(false);
        text[18].SetActive(false);
        text[19].SetActive(false);
        text[20].SetActive(false);
        text[21].SetActive(false);
        text[22].SetActive(false);
        text[23].SetActive(false);

        //continue buttons
        c1.SetActive(true);
        c2.SetActive(false);
        c3.SetActive(false);
        c4.SetActive(false);
        c5.SetActive(false);
        c6.SetActive(false);
        c7.SetActive(false);

        finishedButton.SetActive(false);
    }

    public void Set2() {
        text[0].SetActive(false);
        text[1].SetActive(false);
        text[2].SetActive(false);
        c1.SetActive(false);

        text[3].SetActive(true);
        text[4].SetActive(true);
        text[5].SetActive(true);
        c2.SetActive(true);
    }

    public void Set3() {
        text[3].SetActive(false);
        text[4].SetActive(false);
        text[5].SetActive(false);
        c2.SetActive(false);

        text[6].SetActive(true);
        text[7].SetActive(true);
        text[8].SetActive(true);
        c3.SetActive(true);
    }

    public void Set4() {
        text[6].SetActive(false);
        text[7].SetActive(false);
        text[8].SetActive(false);
        c3.SetActive(false);

        text[9].SetActive(true);
        text[10].SetActive(true);
        text[11].SetActive(true);
        c4.SetActive(true);
    }

    public void Set5() {
        text[9].SetActive(false);
        text[10].SetActive(false);
        text[11].SetActive(false);
        c4.SetActive(false);

        text[12].SetActive(true);
        text[13].SetActive(true);
        text[14].SetActive(true);
        c5.SetActive(true);
    }

    public void Set6() {
        text[12].SetActive(false);
        text[13].SetActive(false);
        text[14].SetActive(false);
        c5.SetActive(false);

        text[15].SetActive(true);
        text[16].SetActive(true);
        text[17].SetActive(true);
        c6.SetActive(true);
    }

    public void Set7() {
        text[15].SetActive(false);
        text[16].SetActive(false);
        text[17].SetActive(false);
        c6.SetActive(false);

        text[18].SetActive(true);
        text[19].SetActive(true);
        text[20].SetActive(true);
        c7.SetActive(true);
    }

    public void Set8() {
        text[18].SetActive(false);
        text[19].SetActive(false);
        text[20].SetActive(false);
        c7.SetActive(false);

        text[21].SetActive(true);
        text[22].SetActive(true);
        text[23].SetActive(true);
        finishedButton.SetActive(true);
    }

    public void Finished() {
        SceneManager.LoadScene("OpeningJournalistAttitude");
    }
}

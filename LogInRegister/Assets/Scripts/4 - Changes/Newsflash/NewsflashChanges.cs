using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NewsflashChanges : MonoBehaviour
{
    public GameObject startCanvas, newsflashCanvas, feedbackCanvas, finishCanvas;

    private int selection = 0; //do this after each time they select the CONTINUE button the Feedback Canvas.

    public GameObject statement1, statement2, statement3, statement4, statement5, statement6;
    public GameObject statement1Continue, statement2Continue, statement3Continue, statement4Continue, statement5Continue, statement6Continue;
    public GameObject correct, incorrect;

    // Start is called before the first frame update
    void Start() {
        startCanvas.SetActive(true);
        newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(false); //feedbackCanvas will happen after each selection is made by clicking a theme, depending on theme selected it will be right or wrong but won't matter
        finishCanvas.SetActive(false);
        selection = 0;
    }

    // Update is called once per frame
    void Update() {
        if (selection == 7) {
            //go to feedback screen
            //feedback.SetActive(true);
            //ogCanvas.SetActive(false);
            //feedbackCanvas.SetActive(true);

            startCanvas.SetActive(false);
            newsflashCanvas.SetActive(false);
            feedbackCanvas.SetActive(false);

            //give overall feedback
            finishCanvas.SetActive(true);
        }

        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("ChangesJournalist");
        }*/
    }

    public void ReturnToJournalist() {
        //Application.Quit();
        SceneManager.LoadScene("ChangesJournalist");
    }

    public void Statement1() { //this will appear when the start button is selected to start the tool
        //in addition to it show this, we must make the canvas visible and have the Start Canvas when availble, to SetActive(false).
        startCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement1.SetActive(true);
        selection++;
    }

    public void Statement2() {
        statement1Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement1.SetActive(false);
        statement2.SetActive(true);
        selection++; //adds one each time the continue button from feedback is clicked.
    }

    public void Statement3() {
        statement2Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement2.SetActive(false);
        statement3.SetActive(true);
        selection++;
    }

    public void Statement4() {
        statement3Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement3.SetActive(false);
        statement4.SetActive(true);
        selection++;
    }

    public void Statement5() {
        statement4Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement4.SetActive(false);
        statement5.SetActive(true);
        selection++;
    }

    public void Statement6() {
        statement5Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement5.SetActive(false);
        statement6.SetActive(true);
        selection++;
    }
    //---------------------------------------------------------------------------------------------
    /*
     * Going to simplify this down at a later date, for the moment this way has been taken
     */

    public void Statement1Correct() {
        //Geography
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement1Continue.SetActive(true);
    }

    public void Statement1Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement1Continue.SetActive(true);
    }

    public void Statement2Correct() {
        //Political
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement2Continue.SetActive(true);
    }

    public void Statement2Incorrect() {
        newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement2Continue.SetActive(true);
    }

    public void Statement3Correct() {
        //Economy
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement3Continue.SetActive(true);
    }

    public void Statement3Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement3Continue.SetActive(true);
    }

    public void Statement4Correct() {
        //Political
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement4Continue.SetActive(true);
    }

    public void Statement4Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement4Continue.SetActive(true);
    }

    public void Statement5Correct() {
        //Emotions
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement5Continue.SetActive(true);
    }

    public void Statement5Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement5Continue.SetActive(true);
    }

    public void Statement6Correct() {
        //Culture
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement6Continue.SetActive(true);
    }

    public void Statement6Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement6Continue.SetActive(true);
    }
}

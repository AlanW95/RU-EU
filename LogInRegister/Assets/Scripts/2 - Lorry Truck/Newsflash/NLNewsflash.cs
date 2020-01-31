using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NLNewsflash : MonoBehaviour
{
    public GameObject startCanvas, newsflashCanvas, feedbackCanvas, finishCanvas;

    private int selection = 0; //do this after each time they select the CONTINUE button the Feedback Canvas.

    public GameObject statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8, statement9, statement10, statement11, statement12, statement13, statement14;
    public GameObject statement1Continue, statement2Continue, statement3Continue, statement4Continue, statement5Continue, statement6Continue, statement7Continue, statement8Continue, statement9Continue, statement10Continue, statement11Continue, statement12Continue, statement13Continue, statement14Continue;
    public GameObject correct, incorrect;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(false); //feedbackCanvas will happen after each selection is made by clicking a theme, depending on theme selected it will be right or wrong but won't matter
        finishCanvas.SetActive(false);
        selection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (selection == 15) {
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

        //Debugging only
        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("AttitudesMobileWorkplace");
        }*/
    }

    public void ReturnToJournalist() {
        //Application.Quit();
        SceneManager.LoadScene("LorryTruckJournalist");
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

    public void Statement7() {
        statement6Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement6.SetActive(false);
        statement7.SetActive(true);
        selection++;
    }

    public void Statement8() {
        statement7Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement7.SetActive(false);
        statement8.SetActive(true);
        selection++;
    }

    public void Statement9() {
        statement8Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement8.SetActive(false);
        statement9.SetActive(true);
        selection++;
    }

    public void Statement10() {
        statement9Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement9.SetActive(false);
        statement10.SetActive(true);
        selection++;
    }

    public void Statement11() {
        statement10Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement10.SetActive(false);
        statement11.SetActive(true);
        selection++;
    }

    public void Statement12() {
        statement11Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement11.SetActive(false);
        statement12.SetActive(true);
        selection++;
    }

    public void Statement13() {
        statement12Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement12.SetActive(false);
        statement13.SetActive(true); //if needed once all statements are complete... you can put the statement13.SetActive(false); in the Update()
        selection++;
    }

    public void Statement14() {
        statement13Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement13.SetActive(false);
        statement14.SetActive(true);
        selection++;
    }
    //---------------------------------------------------------------------------------------------
    /*
     * Going to simplify this down at a later date, for the moment this way has been taken
     */

    public void Statement1Correct() {
        //Social
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
        //Social
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
        //Social
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
        //Economy
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
        //Environmental
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

    public void Statement7Correct() {
        //Social
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement7Continue.SetActive(true);
    }

    public void Statement7Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement7Continue.SetActive(true);
    }

    public void Statement8Correct() {
        //Social
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement8Continue.SetActive(true);
    }

    public void Statement8Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement8Continue.SetActive(true);
    }

    public void Statement9Correct() {
        //Social
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement9Continue.SetActive(true);
    }

    public void Statement9Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement9Continue.SetActive(true);
    }

    public void Statement10Correct() {
        //Economy
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement10Continue.SetActive(true);
    }

    public void Statement10Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement10Continue.SetActive(true);
    }

    public void Statement11Correct() {
        //Social
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement11Continue.SetActive(true);
    }

    public void Statement11Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement11Continue.SetActive(true);
    }

    public void Statement12Correct() {
        //Social
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement12Continue.SetActive(true);
    }

    public void Statement12Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement12Continue.SetActive(true);
    }

    public void Statement13Correct() {
        //Rights & Responsibilities
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement13Continue.SetActive(true);
    }

    public void Statement13Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement13Continue.SetActive(true);
    }
    public void Statement14Correct() {
        //Social
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement14Continue.SetActive(true);
    }

    public void Statement14Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement14Continue.SetActive(true);
    }
}

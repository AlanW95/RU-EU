﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ImmigrationDiscussion2 : MonoBehaviour
{
    public GameObject[] statements;
    public TextMeshProUGUI statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8, statement9, statement10;
    public Button btnS1, btnS2, btnS3, btnS4, btnS5, btnS6, btnS7, btnS8, btnS9, btnS10;

    //public GameObject[] newStatements;
    //public TextMeshProUGUI newStatement1, newStatement2, newStatement3, newStatement4;

    public GameObject feedbackCanvas;

    private int task3Counter = 4; //after each choice the counter goes down
    private int predictorCounter = 4; //help with decided which slot the new statement goes to

    // Start is called before the first frame update
    void Start()
    {
        //Dialogue 1 statements appear first
        //Statements 1-5 (Discussion1-5)
        statements[0].SetActive(true);

        statement1.text = PlayerPrefs.GetString("ImmigrationDiscussion1");
        statement2.text = PlayerPrefs.GetString("ImmigrationDiscussion2");
        statement3.text = PlayerPrefs.GetString("ImmigrationDiscussion3");
        statement4.text = PlayerPrefs.GetString("ImmigrationDiscussion4");
        statement5.text = PlayerPrefs.GetString("ImmigrationDiscussion5");

        statements[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (task3Counter == 4) {
            //4 remaining text will appear
        }

        if (task3Counter == 3) {
            //3 remaining text will appear
        }

        if (task3Counter == 2) {
            //2 remaining text will appear

            statements[0].SetActive(false);

            statements[1].SetActive(true);

            //Dialogue 2 statements appear
            //Statements 6-10 (Discussion6-10)
            statement6.text = PlayerPrefs.GetString("ImmigrationDiscussion6");
            statement7.text = PlayerPrefs.GetString("ImmigrationDiscussion7");
            statement8.text = PlayerPrefs.GetString("ImmigrationDiscussion8");
            statement9.text = PlayerPrefs.GetString("ImmigrationDiscussion9");
            statement10.text = PlayerPrefs.GetString("ImmigrationDiscussion10");
        }

        if (task3Counter == 1) {
            //1 remaining text will appear
        }

        if (task3Counter == 0) {
            /*newStatements[0].SetActive(true);
            newStatements[1].SetActive(true);
            newStatements[2].SetActive(true);
            newStatements[3].SetActive(true);
            newStatement1.text = PlayerPrefs.GetString("NewDiscussion1");
            newStatement2.text = PlayerPrefs.GetString("NewDiscussion2");
            newStatement3.text = PlayerPrefs.GetString("NewDiscussion3");
            newStatement4.text = PlayerPrefs.GetString("NewDiscussion4");*/
            //go to feedback
            feedbackCanvas.SetActive(true);
        }

        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Journalist");
        }*/

        Debug.Log("Predictor Counter: " + predictorCounter);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ReturnToMobileWorkplace() {
        SceneManager.LoadScene("ImmigrationJournalist");
    }

    public void Statement1() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS1.interactable = false;
    }

    public void Statement1Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion1", statement1.text);
        }

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion2", statement1.text);
        }
    }

    public void Statement2() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS2.interactable = false;
    }

    public void Statement2Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion1", statement2.text);
        }

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion2", statement2.text);
        }
    }

    public void Statement3() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS3.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion1", statement3.text);
        }

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion2", statement3.text);
        }
    }

    public void Statement3Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion1", statement3.text);
        }

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion2", statement3.text);
        }
    }

    public void Statement4() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS4.interactable = false;
    }

    public void Statement4Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion1", statement4.text);
        }

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion2", statement4.text);
        }
    }

    public void Statement5() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS5.interactable = false;
    }

    public void Statement5Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion1", statement5.text);
        }

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion2", statement5.text);
        }
    }

    public void Statement6() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS6.interactable = false;
    }

    public void Statement6Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion3", statement6.text);
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion4", statement6.text);
        }
    }

    public void Statement7() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS7.interactable = false;
    }

    public void Statement7Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion3", statement7.text);
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion4", statement7.text);
        }
    }

    public void Statement8() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS8.interactable = false;
    }

    public void Statement8Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion3", statement8.text);
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion4", statement8.text);
        }
    }

    public void Statement9() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS9.interactable = false;
    }

    public void Statement9Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion3", statement9.text);
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion4", statement9.text);
        }
    }

    public void Statement10() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS10.interactable = false;
    }

    public void Statement10Selected() {

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion3", statement10.text);
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewImmigrationDiscussion4", statement10.text);
        }
    }
}

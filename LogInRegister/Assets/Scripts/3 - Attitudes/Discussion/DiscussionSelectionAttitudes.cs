using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DiscussionSelectionAttitudes : MonoBehaviour
{
    public GameObject[] statements;
    public TextMeshProUGUI statement1, statement2, statement3, statement4, statement5, statement6;
    public Button btnS1, btnS2, btnS3, btnS4, btnS5, btnS6;

    //public GameObject[] newStatements;
    //public TextMeshProUGUI newStatement1, newStatement2, newStatement3, newStatement4;

    public GameObject feedbackCanvas;

    private int task3Counter = 2; //after each choice the counter goes down
    private int predictorCounter = 2; //help with decided which slot the new statement goes to

    // Start is called before the first frame update
    void Start()
    {
        //Dialogue 1 statements appear first
        //Statements 1-5 (Discussion1-5)
        statements[0].SetActive(true);

        statement1.text = PlayerPrefs.GetString("AttitudesDiscussion1");
        statement2.text = PlayerPrefs.GetString("AttitudesDiscussion2");
        statement3.text = PlayerPrefs.GetString("AttitudesDiscussion3");
        statement4.text = PlayerPrefs.GetString("AttitudesDiscussion4");
        statement5.text = PlayerPrefs.GetString("AttitudesDiscussion5");
        statement6.text = PlayerPrefs.GetString("AttitudesDiscussion6");
    }

    // Update is called once per frame
    void Update()
    {

        //would be good to add an option to unselect one you have already selected.
        if (task3Counter == 1) {
            //1 remaining text will appear
            Debug.Log("You have one selection left.");
        }

        if (task3Counter == 0) {
            //go to feedback
            feedbackCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MobileWorkplaceAttitudes");
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void Statement1() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS1.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion1", "");
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion2", "");
        }
    }

    public void Statement2() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS2.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion1", "");
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion2", "");
        }
    }

    public void Statement3() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS3.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion1", "");
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion2", "");
        }
    }

    public void Statement4() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS4.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion1", "");
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion2", "");
        }
    }

    public void Statement5() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS5.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion1", "");
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion2", "");
        }
    }

    public void Statement6() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS6.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion1", "");
        }

        if (predictorCounter == 0) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewAttitudesDiscussion2", "");
        }
    }
}

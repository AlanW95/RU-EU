using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiscussionTask3 : MonoBehaviour
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

        statement1.text = PlayerPrefs.GetString("Discussion1");
        statement2.text = PlayerPrefs.GetString("Discussion2");
        statement3.text = PlayerPrefs.GetString("Discussion3");
        statement4.text = PlayerPrefs.GetString("Discussion4");
        statement5.text = PlayerPrefs.GetString("Discussion5");

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
            statement6.text = PlayerPrefs.GetString("Discussion6");
            statement7.text = PlayerPrefs.GetString("Discussion7");
            statement8.text = PlayerPrefs.GetString("Discussion8");
            statement9.text = PlayerPrefs.GetString("Discussion9");
            statement10.text = PlayerPrefs.GetString("Discussion10");
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

        if (predictorCounter == 4) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion1", "");
        }

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion2", "");
        }
    }

    public void Statement2() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS2.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 4) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion1", "");
        }

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion2", "");
        }
    }

    public void Statement3() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS3.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 4) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion1", "");
        }

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion2", "");
        }
    }

    public void Statement4() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS4.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 4) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion1", "");
        }

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion2", "");
        }
    }

    public void Statement5() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS5.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 4) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion1", "");
        }

        if (predictorCounter == 3) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion2", "");
        }
    }

    public void Statement6() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS6.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion3", "");
        }

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion4", "");
        }
    }

    public void Statement7() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS7.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion3", "");
        }

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion4", "");
        }
    }

    public void Statement8() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS8.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion3", "");
        }

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion4", "");
        }
    }

    public void Statement9() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS9.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion3", "");
        }

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion4", "");
        }
    }

    public void Statement10() {
        //counter goes down 1 for both the Task3Counter and PredictorCounter
        task3Counter--;
        predictorCounter--;
        //button for statement gets disabled
        btnS10.interactable = false;

        //there will only be two because we change to the second set of dialogue to choose

        if (predictorCounter == 2) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion3", "");
        }

        if (predictorCounter == 1) {
            //add to new PlayerPrefs
            PlayerPrefs.SetString("NewDiscussion4", "");
        }
    }
}

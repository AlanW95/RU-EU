﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AttitudesMobileWorkplace : MonoBehaviour
{
    public GameObject interview1, interview2, discussion, newsflash, finalAssignment, notebook;
    private bool interview1Completed, interview2Completed, discussionCompleted, newsflashCompleted;

    public MeshCollider discussionCollider;
    public BoxCollider interview1Collider, interview2Collider, finalAssignmentCollider;

    public TextMeshProUGUI textDisplay, toolCompletionText;
    public static string toolCompletion;

    public int toolObjectiveCountdown = 8;

    // Start is called before the first frame update
    void Start() {

        //for displaying the completion of tools
        PlayerPrefs.GetString("ToolsCompletedAttitudes");
        PlayerPrefs.SetString("ToolsCompletedAttitudes", toolCompletion);

        //DEBUGGING PURPOSE---------
        /*PlayerPrefs.SetString("ToolCompletionAttitudesText", "");
        PlayerPrefs.SetInt("ObjectiveCountdownAttitudes", 8);
        interview1Completed = false;
        PlayerPrefs.SetInt("AttitudesInterview1Completed", boolToInt(interview1Completed));
        interview2Completed = false;
        PlayerPrefs.SetInt("AttitudesInterview2Completed", boolToInt(interview2Completed));
        discussionCompleted = false;
        PlayerPrefs.SetInt("AttitudesDiscussionCompleted", boolToInt(discussionCompleted));
        newsflashCompleted = false;
        PlayerPrefs.SetInt("AttitudesNewsflashCompleted", boolToInt(newsflashCompleted));*/
        //--------------------------

        toolObjectiveCountdown = PlayerPrefs.GetInt("ObjectiveCountdownAttitudes");
        PlayerPrefs.SetInt("ObjectiveCountdownAttitudes", toolObjectiveCountdown);
        Debug.Log(toolObjectiveCountdown);


        interview1Completed = intToBool(PlayerPrefs.GetInt("Interview1AttitudesCompleted"));
        interview2Completed = intToBool(PlayerPrefs.GetInt("Interview2AttitudesCompleted"));
        discussionCompleted = intToBool(PlayerPrefs.GetInt("DiscussionAttitudesCompleted"));
        newsflashCompleted = intToBool(PlayerPrefs.GetInt("NewsflashAttitudesCompleted"));

        toolCompletion = PlayerPrefs.GetString("ToolCompletionAttitudesText");
        toolCompletion = toolCompletionText.text;
        Debug.Log("LOADING IN TEXT: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));

        interview1.SetActive(false);
        interview2.SetActive(false);
        discussion.SetActive(false);
        newsflash.SetActive(false);
        //final assignment will appear when all four main tools have been completed
        finalAssignment.SetActive(false);
        notebook.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("Objective Countdown: " + toolObjectiveCountdown);

        toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText");

        textDisplay.text = "Choose from any of the 4 tools on the desk; Interview 1, Interview 2, the Public Discussion and the Newsflashes.";

        if (interview1Completed == false) {
            interview1.SetActive(true);
            notebook.SetActive(true);

            finalAssignment.SetActive(false);
            Debug.Log("Interview 1 is not complete");
        }

        if (interview2Completed == false) {
            interview2.SetActive(true);
            notebook.SetActive(true);

            finalAssignment.SetActive(false);
            Debug.Log("Interview 2 is not complete");
        }

        if (discussionCompleted == false) {
            discussion.SetActive(true);
            notebook.SetActive(true);

            finalAssignment.SetActive(false);
            Debug.Log("Discussion is not complete");
        }

        if (newsflashCompleted == false) {
            newsflash.SetActive(true);
            notebook.SetActive(true);

            finalAssignment.SetActive(false);
            Debug.Log("Newsflash is not complete");
        }
        
        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            finalAssignment.SetActive(true);
            notebook.SetActive(true);
            Debug.Log("All have been complete");
            textDisplay.text = "You have completed all the necessary tools to build your report. Head to the laptop to construct your report.";
        }

        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }*/
    }

    public void LoadDashboard() {
        SceneManager.LoadScene("DashboardAttitudes");
    }

    public void AddToToolAvailability() {
        //helps recognise when to activate other tools
        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdownAttitudes", toolObjectiveCountdown);
        Debug.Log("Objective Countdown" + PlayerPrefs.GetInt("ObjectiveCountdownAttitudes"));
    }

    public void Interview1() {
        //Interview 1 becomes available
        //interview1.SetActive(true);
        interview1Collider.GetComponent<BoxCollider>().enabled = false;
        interview1Completed = true;
        PlayerPrefs.SetInt("Interview1AttitudesCompleted", boolToInt(interview1Completed));



        if (interview1Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText") + "\n" + "Interview 1 complete";
            PlayerPrefs.SetString("ToolCompletionAttitudesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));
            interview1.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionAttitudesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));
        }
    }

    public void Interview2() {

        //interview2.SetActive(true);
        interview2Collider.GetComponent<BoxCollider>().enabled = false;
        interview2Completed = true;
        PlayerPrefs.SetInt("Interview2AttitudesCompleted", boolToInt(interview2Completed));


        if (interview2Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText") + "\n" + "Interview 2 complete";
            PlayerPrefs.SetString("ToolCompletionAttitudesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));
            interview2.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionAttitudesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));
        }
    }

    public void Discussion() {

        //discussion.SetActive(true);
        discussionCollider.GetComponent<MeshCollider>().enabled = false;
        discussionCompleted = true;
        PlayerPrefs.SetInt("DiscussionAttitudesCompleted", boolToInt(discussionCompleted));

        if (discussionCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText") + "\n" + "Public Discussion complete";
            PlayerPrefs.SetString("ToolCompletionAttitudesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));
            discussion.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionAttitudesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));
        }
    }

    public void Newsflash() {

        //newsflash.SetActive(false);
        newsflashCompleted = true;
        PlayerPrefs.SetInt("NewsflashAttitudesCompleted", boolToInt(newsflashCompleted));

        if (newsflashCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText") + "\n" + "Newsflash complete";
            PlayerPrefs.SetString("ToolCompletionAttitudesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));
            newsflash.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionAttitudesText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionAttitudesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionAttitudesText"));
        }
    }

    public void FinalAssignment() {

        finalAssignment.SetActive(true);
        notebook.SetActive(true);
        finalAssignmentCollider.GetComponent<BoxCollider>().enabled = true;

        textDisplay.text = "You have completed all the necessary tools to build your report. Head to the laptop to construct your report.";
    }

    int boolToInt(bool val) {
        if (val) {
            return 1;
        } else {
            return 0;
        }
    }

    bool intToBool(int val) {
        if (val != 0) {
            return true;
        } else {
            return false;
        }
    }
}

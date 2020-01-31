using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MobileWorkplaceNL : MonoBehaviour
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
        PlayerPrefs.GetString("ToolsCompletedLorryTruck");
        PlayerPrefs.SetString("ToolsCompletedLorryTruck", toolCompletion);

        //DEBUGGING PURPOSE---------
        /*PlayerPrefs.SetString("ToolCompletionLorryTruckText", "");
        PlayerPrefs.SetInt("ObjectiveCountdownLorryTruck", 8);
        interview1Completed = false;
        PlayerPrefs.SetInt("LorryTruckInterview1Completed", boolToInt(interview1Completed));
        interview2Completed = false;
        PlayerPrefs.SetInt("LorryTruckInterview2Completed", boolToInt(interview2Completed));
        discussionCompleted = false;
        PlayerPrefs.SetInt("LorryTruckDiscussionCompleted", boolToInt(discussionCompleted));
        newsflashCompleted = false;
        PlayerPrefs.SetInt("LorryTruckNewsflashCompleted", boolToInt(newsflashCompleted));*/
        //--------------------------

        toolObjectiveCountdown = PlayerPrefs.GetInt("ObjectiveCountdownLorryTruck");
        PlayerPrefs.SetInt("ObjectiveCountdownLorryTruck", toolObjectiveCountdown);
        Debug.Log(toolObjectiveCountdown);


        interview1Completed = intToBool(PlayerPrefs.GetInt("Interview1LorryTruckCompleted"));
        interview2Completed = intToBool(PlayerPrefs.GetInt("Interview2LorryTruckCompleted"));
        discussionCompleted = intToBool(PlayerPrefs.GetInt("DiscussionLorryTruckCompleted"));
        newsflashCompleted = intToBool(PlayerPrefs.GetInt("NewsflashLorryTruckCompleted"));

        toolCompletion = PlayerPrefs.GetString("ToolCompletionLorryTruckText");
        toolCompletion = toolCompletionText.text;
        Debug.Log("LOADING IN TEXT: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));

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

        toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText");

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
        SceneManager.LoadScene("DashboardNL");
    }

    public void AddToToolAvailability() {
        //helps recognise when to activate other tools
        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdownLorryTruck", toolObjectiveCountdown);
        Debug.Log("Objective Countdown" + PlayerPrefs.GetInt("ObjectiveCountdownLorryTruck"));
    }

    public void Interview1() {
        //Interview 1 becomes available
        //interview1.SetActive(true);
        interview1Collider.GetComponent<BoxCollider>().enabled = false;
        interview1Completed = true;
        PlayerPrefs.SetInt("Interview1LorryTruckCompleted", boolToInt(interview1Completed));



        if (interview1Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText") + "\n" + "Interview 1 complete";
            PlayerPrefs.SetString("ToolCompletionLorryTruckText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));
            interview1.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionLorryTruckText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));
        }
    }

    public void Interview2() {

        //interview2.SetActive(true);
        interview2Collider.GetComponent<BoxCollider>().enabled = false;
        interview2Completed = true;
        PlayerPrefs.SetInt("Interview2LorryTruckCompleted", boolToInt(interview2Completed));


        if (interview2Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText") + "\n" + "Interview 2 complete";
            PlayerPrefs.SetString("ToolCompletionLorryTruckText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));
            interview2.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionLorryTruckText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));
        }
    }

    public void Discussion() {

        //discussion.SetActive(true);
        discussionCollider.GetComponent<MeshCollider>().enabled = false;
        discussionCompleted = true;
        PlayerPrefs.SetInt("DiscussionLorryTruckCompleted", boolToInt(discussionCompleted));

        if (discussionCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText") + "\n" + "Public Discussion complete";
            PlayerPrefs.SetString("ToolCompletionLorryTruckText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));
            discussion.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionLorryTruckText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));
        }
    }

    public void Newsflash() {

        //newsflash.SetActive(false);
        newsflashCompleted = true;
        PlayerPrefs.SetInt("NewsflashLorryTruckCompleted", boolToInt(newsflashCompleted));

        if (newsflashCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText") + "\n" + "Newsflash complete";
            PlayerPrefs.SetString("ToolCompletionLorryTruckText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));
            newsflash.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionLorryTruckText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionLorryTruckText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionLorryTruckText"));
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
        }
        else {
            return 0;
        }
    }

    bool intToBool(int val) {
        if (val != 0) {
            return true;
        }
        else {
            return false;
        }
    }
}

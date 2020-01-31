using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MobileWorkplaceChanges : MonoBehaviour
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
        PlayerPrefs.GetString("ToolsCompletedChanges");
        PlayerPrefs.SetString("ToolsCompletedChanges", toolCompletion);

        //DEBUGGING PURPOSE---------
        /*PlayerPrefs.SetString("ToolCompletionChangesText", "");
        PlayerPrefs.SetInt("ObjectiveCountdownChanges", 8);
        interview1Completed = false;
        PlayerPrefs.SetInt("ChangesInterview1Completed", boolToInt(interview1Completed));
        interview2Completed = false;
        PlayerPrefs.SetInt("ChangesInterview2Completed", boolToInt(interview2Completed));
        discussionCompleted = false;
        PlayerPrefs.SetInt("ChangesDiscussionCompleted", boolToInt(discussionCompleted));
        newsflashCompleted = false;
        PlayerPrefs.SetInt("ChangesNewsflashCompleted", boolToInt(newsflashCompleted));*/
        //--------------------------

        toolObjectiveCountdown = PlayerPrefs.GetInt("ObjectiveCountdownChanges");
        PlayerPrefs.SetInt("ObjectiveCountdownChanges", toolObjectiveCountdown);
        Debug.Log(toolObjectiveCountdown);


        interview1Completed = intToBool(PlayerPrefs.GetInt("Interview1ChangesCompleted"));
        interview2Completed = intToBool(PlayerPrefs.GetInt("Interview2ChangesCompleted"));
        discussionCompleted = intToBool(PlayerPrefs.GetInt("DiscussionChangesCompleted"));
        newsflashCompleted = intToBool(PlayerPrefs.GetInt("NewsflashChangesCompleted"));

        toolCompletion = PlayerPrefs.GetString("ToolCompletionChangesText");
        toolCompletion = toolCompletionText.text;
        Debug.Log("LOADING IN TEXT: " + PlayerPrefs.GetString("ToolCompletionChangesText"));

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

        toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText");

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
        SceneManager.LoadScene("DashboardChanges");
    }

    public void AddToToolAvailability() {
        //helps recognise when to activate other tools
        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdownChanges", toolObjectiveCountdown);
        Debug.Log("Objective Countdown" + PlayerPrefs.GetInt("ObjectiveCountdownChanges"));
    }

    public void Interview1() {
        //Interview 1 becomes available
        //interview1.SetActive(true);
        interview1Collider.GetComponent<BoxCollider>().enabled = false;
        interview1Completed = true;
        PlayerPrefs.SetInt("Interview1ChangesCompleted", boolToInt(interview1Completed));



        if (interview1Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText") + "\n" + "Interview 1 complete";
            PlayerPrefs.SetString("ToolCompletionChangesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionChangesText"));
            interview1.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionChangesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionChangesText"));
        }
    }

    public void Interview2() {

        //interview2.SetActive(true);
        interview2Collider.GetComponent<BoxCollider>().enabled = false;
        interview2Completed = true;
        PlayerPrefs.SetInt("Interview2ChangesCompleted", boolToInt(interview2Completed));


        if (interview2Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText") + "\n" + "Interview 2 complete";
            PlayerPrefs.SetString("ToolCompletionChangesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionChangesText"));
            interview2.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionChangesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionChangesText"));
        }
    }

    public void Discussion() {

        //discussion.SetActive(true);
        discussionCollider.GetComponent<MeshCollider>().enabled = false;
        discussionCompleted = true;
        PlayerPrefs.SetInt("DiscussionChangesCompleted", boolToInt(discussionCompleted));

        if (discussionCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText") + "\n" + "Public Discussion complete";
            PlayerPrefs.SetString("ToolCompletionChangesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionChangesText"));
            discussion.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionChangesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionChangesText"));
        }
    }

    public void Newsflash() {

        //newsflash.SetActive(false);
        newsflashCompleted = true;
        PlayerPrefs.SetInt("NewsflashChangesCompleted", boolToInt(newsflashCompleted));

        if (newsflashCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText") + "\n" + "Newsflash complete";
            PlayerPrefs.SetString("ToolCompletionChangesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionChangesText"));
            newsflash.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionChangesText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionChangesText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionChangesText"));
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

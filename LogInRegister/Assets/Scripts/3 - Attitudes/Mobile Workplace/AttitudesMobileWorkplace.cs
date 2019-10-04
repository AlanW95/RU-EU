using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AttitudesMobileWorkplace : MonoBehaviour
{
    public GameObject interview1, interview2, discussion, newsflash, finalAssignment;//, mobilePhone;
    private bool interview1Completed, interview2Completed, discussionCompleted, newsflashCompleted;

    public MeshCollider discussionCollider;
    public BoxCollider interview1Collider, interview2Collider, finalAssignmentCollider;

    public TextMeshProUGUI textDisplay, toolCompletionText;
    public static string toolCompletion;

    public int toolObjectiveCountdown = 8;

    // Start is called before the first frame update
    void Start() {

        //for displaying the completion of tools
        PlayerPrefs.GetString("ToolsCompleted");
        PlayerPrefs.SetString("ToolsCompleted", toolCompletion);

        //DEBUGGING PURPOSE---------
        //PlayerPrefs.SetString("ToolCompletionText", "");
        //PlayerPrefs.SetInt("ObjectiveCountdown", 8);
        //--------------------------

        toolObjectiveCountdown = PlayerPrefs.GetInt("ObjectiveCountdown");
        PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);
        Debug.Log(toolObjectiveCountdown);


        interview1Completed = intToBool(PlayerPrefs.GetInt("Interview1Completed"));
        interview2Completed = intToBool(PlayerPrefs.GetInt("Interview2Completed"));
        discussionCompleted = intToBool(PlayerPrefs.GetInt("DiscussionCompleted"));
        newsflashCompleted = intToBool(PlayerPrefs.GetInt("NewsflashCompleted"));

        toolCompletion = PlayerPrefs.GetString("ToolCompletionText");
        toolCompletion = toolCompletionText.text;
        Debug.Log("LOADING IN TEXT: " + PlayerPrefs.GetString("ToolCompletionText"));

        interview1.SetActive(true);
        interview2.SetActive(true);
        discussion.SetActive(true);
        newsflash.SetActive(true);
        //final assignment will appear when all four main tools have been completed
        finalAssignment.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("Objective Countdown: " + toolObjectiveCountdown);

        toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText");

        textDisplay.text = "Choose from any of the 4 tools on the desk; the Remain Interview, the Leaver Interview, the Pub Discussion or the Newsflash.";
        
        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            finalAssignment.SetActive(true);
        }

        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }*/
    }

    public void LoadDashboard() {
        SceneManager.LoadScene("Dashboard");
    }

    public void AddToToolAvailability() {
        //helps recognise when to activate other tools
        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);
        Debug.Log("Objective Countdown" + PlayerPrefs.GetInt("ObjectiveCountdown"));
    }

    public void Interview1() {
        //Interview 1 becomes available
        interview1.SetActive(true);
        interview1Collider.GetComponent<BoxCollider>().enabled = false;
        interview1Completed = true;
        PlayerPrefs.SetInt("Interview1Completed", boolToInt(interview1Completed));



        if (interview1Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "Remain Interview complete";
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }
    }

    public void Interview2() {

        interview2.SetActive(true);
        interview2Collider.GetComponent<BoxCollider>().enabled = false;
        interview2Completed = true;
        PlayerPrefs.SetInt("Interview2Completed", boolToInt(interview2Completed));


        if (interview2Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "Leaver Interview complete";
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }
    }

    public void Discussion() {

        discussion.SetActive(true);
        discussionCollider.GetComponent<MeshCollider>().enabled = false;
        discussionCompleted = true;
        PlayerPrefs.SetInt("DiscussionCompleted", boolToInt(discussionCompleted));

        if (discussionCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "Discussion in Pub complete";
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }
    }

    public void Newsflash() {

        newsflash.SetActive(false);
        newsflashCompleted = true;
        PlayerPrefs.SetInt("NewsflashCompleted", boolToInt(newsflashCompleted));

        if (newsflashCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "Newsflash complete";
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "All are now complete. You may progress to your article.";
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }
    }

    public void FinalAssignment() {

        finalAssignment.SetActive(true);
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

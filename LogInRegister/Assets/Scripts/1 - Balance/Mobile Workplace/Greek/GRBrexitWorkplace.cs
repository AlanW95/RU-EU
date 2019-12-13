using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GRBrexitWorkplace : MonoBehaviour
{
    public GameObject interview1, interview2, discussion, newsflash, finalAssignment, mobilePhone, notebook;
    private bool interview1Completed, interview2Completed, discussionCompleted, newsflashCompleted;

    public MeshCollider discussionCollider;
    public BoxCollider interview1Collider, interview2Collider, finalAssignmentCollider;

    public TextMeshProUGUI textDisplay, toolCompletionText;
    public static string toolCompletion;

    //public int toolAvailability = 0;
    public int toolObjectiveCountdown = 8;

    // Start is called before the first frame update
    void Start()
    {
        //for displaying the completion of tools
        PlayerPrefs.GetString("ToolsCompleted");
        PlayerPrefs.SetString("ToolsCompleted", toolCompletion);

        //DEBUGGING PURPOSE---------
        /*PlayerPrefs.SetString("ToolCompletionText", "");
        PlayerPrefs.SetInt("ObjectiveCountdown", 8);
        interview1Completed = false;
        PlayerPrefs.SetInt("Interview1Completed", boolToInt(interview1Completed));
        interview2Completed = false;
        PlayerPrefs.SetInt("Interview2Completed", boolToInt(interview2Completed));
        discussionCompleted = false;
        PlayerPrefs.SetInt("DiscussionCompleted", boolToInt(discussionCompleted));
        newsflashCompleted = false;
        PlayerPrefs.SetInt("NewsflashCompleted", boolToInt(newsflashCompleted));*/
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

        interview1.SetActive(false);
        interview2.SetActive(false);
        discussion.SetActive(false);
        newsflash.SetActive(false);
        //final assignment and notebook will appear when all four main tools have been completed
        finalAssignment.SetActive(false);
        notebook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Objective Countdown: " + toolObjectiveCountdown);

        toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText");


        //if (toolObjectiveCountdown == 8) {        //toolAvailability == 0) {
        //textDisplay.text = "You are receiving a call from your mentor... pick it up!";
        textDisplay.text = "Choose from any of the 4 tools on the desk; the Remain Interview, the Leaver Interview, the Pub Discussion or the Newsflash.";
        //PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);

        /*textDisplay.text = "You are receiving a call from your mentor... pick it up!";
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);*/
        //}

        //if (toolObjectiveCountdown == 7) {
        textDisplay.text = "Choose from any of the 4 tools on the desk; the Remain Interview, the Leaver interview, the Pub Discussion or the Newsflash.";
        // }

        if (interview1Completed == false) {
            interview1.SetActive(true);
            notebook.SetActive(true);
        }

        if (interview2Completed == false) {
            interview2.SetActive(true);
            notebook.SetActive(true);
        }

        if (discussionCompleted == false) {
            discussion.SetActive(true);
            notebook.SetActive(true);
        }

        if (newsflashCompleted == false) {
            newsflash.SetActive(true);
            notebook.SetActive(true);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            finalAssignment.SetActive(true);
            notebook.SetActive(true);
            textDisplay.text = "You have completed all the necessary tools to build your report. Head to the laptop to construct your report.";
        }

        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }*/
    }

    public void LoadDashboard() {
        SceneManager.LoadScene("GRDashboard");
    }

    public void AddToToolAvailability() {
        //helps recognise when to activate other tools
        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);
        Debug.Log("Objective Countdown" + PlayerPrefs.GetInt("ObjectiveCountdown"));


        //Debug.Log("Tool Objective Countdown: " + toolObjectiveCountdown);
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/
    }

    public void Interview1() {
        //toolAvailability++;
        //PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        //Debug.Log("Tool Availability: " + toolAvailability);

        //Interview 1 becomes available
        //interview1.SetActive(true);
        interview1Collider.GetComponent<BoxCollider>().enabled = false;
        interview1Completed = true;
        PlayerPrefs.SetInt("Interview1Completed", boolToInt(interview1Completed));



        if (interview1Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "Remain Interview complete";
            //toolCompletionText.text = toolCompletion;
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
            interview1.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "All are now complete. You may progress to your article.";
            //toolCompletionText.text = toolCompletion;
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }
    }

    public void Interview2() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        //interview2.SetActive(true);
        interview2Collider.GetComponent<BoxCollider>().enabled = false;
        interview2Completed = true;
        PlayerPrefs.SetInt("Interview2Completed", boolToInt(interview2Completed));


        if (interview2Completed == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "Leaver Interview complete";
            //toolCompletionText.text = toolCompletion;
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
            interview2.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "All are now complete. You may progress to your article.";
            //toolCompletionText.text = toolCompletion;
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }
    }

    public void Discussion() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        //discussion.SetActive(true);
        discussionCollider.GetComponent<MeshCollider>().enabled = false;
        discussionCompleted = true;
        PlayerPrefs.SetInt("DiscussionCompleted", boolToInt(discussionCompleted));

        if (discussionCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "Discussion in Pub complete";
            //toolCompletionText.text = toolCompletion;
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
            discussion.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "All are now complete. You may progress to your article.";
            //toolCompletionText.text = toolCompletion;
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }
    }

    public void Newsflash() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        //newsflash.SetActive(false);
        newsflashCompleted = true;
        PlayerPrefs.SetInt("NewsflashCompleted", boolToInt(newsflashCompleted));

        if (newsflashCompleted == true) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "Newsflash complete";
            //toolCompletionText.text = toolCompletion;
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
            newsflash.SetActive(false);
        }

        if (interview1Completed && interview2Completed && discussionCompleted && newsflashCompleted) {
            toolCompletionText.text = PlayerPrefs.GetString("ToolCompletionText") + "\n" + "All are now complete. You may progress to your article.";
            //toolCompletionText.text = toolCompletion;
            PlayerPrefs.SetString("ToolCompletionText", toolCompletionText.text);
            Debug.Log("Tool Completion Text: " + PlayerPrefs.GetString("ToolCompletionText"));
        }
    }
    public void FinalAssignment() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BrexitWorkplace : MonoBehaviour
{
    public GameObject interview1, interview2, discussion, newsflash, finalAssignment, mobilePhone;
    public MeshCollider discussionCollider;
    public BoxCollider interview1Collider, interview2Collider, finalAssignmentCollider;

    public TextMeshProUGUI textDisplay;

    //public int toolAvailability = 0;
    public int toolObjectiveCountdown = 8;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("ObjectiveCountdown");
        mobilePhone.SetActive(false); //WILL BE TRUE IN FULL GAME
        //click mobile phone and the interview will become available

        interview1.SetActive(true);
        interview2.SetActive(true);
        discussion.SetActive(true);
        newsflash.SetActive(true);
        finalAssignment.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.GetInt("ToolNumber");
        Debug.Log("Objective Countdown: " + toolObjectiveCountdown);

        if (toolObjectiveCountdown == 8) {        //toolAvailability == 0) {
            textDisplay.text = "You are receiving a call from your mentor... pick it up!";
            //PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);
            
            /*textDisplay.text = "You are receiving a call from your mentor... pick it up!";
            PlayerPrefs.SetInt("ToolNumber", toolAvailability);*/
        }

        if (toolObjectiveCountdown == 7) {        //toolAvailability == 1) {
            Interview1();

            textDisplay.text = "Interview with a Remain campaigner is now available. Click the reporter pad to continue.";
        }

        if (toolObjectiveCountdown == 6) {        //toolAvailability == 2) {
            Newsflash1();
        }

        if (toolObjectiveCountdown == 5) {        //toolAvailability == 3) {
            Discussion();
        }

        if (toolObjectiveCountdown == 4) {        //toolAvailability == 4) {
            Newsflash2();
        }

        if (toolObjectiveCountdown == 3) {        //toolAvailability == 5) {
            Interview2();
        }

        if (toolObjectiveCountdown == 2) {        //toolAvailability == 6) {
            Newsflash3();
        }

        if (toolObjectiveCountdown == 1) {        //toolAvailability == 7) {
            FinalAssignment();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void LoadDashboard() {
        SceneManager.LoadScene("Dashboard");
    }



    public void AddToToolAvailability() {
        //helps recognise when to activate other tools
        toolObjectiveCountdown--;
        PlayerPrefs.SetInt("ObjectiveCountdown", toolObjectiveCountdown);
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
        interview1.SetActive(true);
        interview1Collider.GetComponent<BoxCollider>().enabled = true;
    }

    public void Newsflash1() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        //the first Newsflash will be activated here
        interview1Collider.GetComponent<BoxCollider>().enabled = false;

        newsflash.SetActive(true);
        textDisplay.text = "BREAKING NEWS! Click the newsflash bar to proceed.";
    }

    public void Discussion() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        //the discussion becomes available
        newsflash.SetActive(false);

        discussion.SetActive(true);
        discussionCollider.GetComponent<MeshCollider>().enabled = true;
        textDisplay.text = "Discussion with the general public in a pub is now available. Click the beverage (camera at the minute) to proceed.";
    }

    public void Newsflash2() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        discussionCollider.GetComponent<MeshCollider>().enabled = false;

        newsflash.SetActive(true);
        textDisplay.text = "BREAKING NEWS AGAIN! Click the newsflash bar to proceed.";
    }

    public void Interview2() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        newsflash.SetActive(false);

        interview2.SetActive(true);
        interview2Collider.GetComponent<BoxCollider>().enabled = true;
        textDisplay.text = "Interview with a Leave campaigner is now available. Click the smaller reporter pad to continue.";
    }

    public void Newsflash3() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        interview2Collider.GetComponent<BoxCollider>().enabled = false;

        newsflash.SetActive(true);
        textDisplay.text = "ANOTHER!? BREAKING NEWS COMING IN! Click the newsflash to proceed.";
    }

    public void FinalAssignment() {
        /*toolAvailability++;
        PlayerPrefs.SetInt("ToolNumber", toolAvailability);
        Debug.Log("Tool Availability: " + toolAvailability);*/

        newsflash.SetActive(false);

        //dashboard will appear before this.

        finalAssignment.SetActive(true);
        finalAssignmentCollider.GetComponent<BoxCollider>().enabled = true;

        textDisplay.text = "You have completed all the necessary tools to build your report. Head to the laptop to construct your report.";
    }
}

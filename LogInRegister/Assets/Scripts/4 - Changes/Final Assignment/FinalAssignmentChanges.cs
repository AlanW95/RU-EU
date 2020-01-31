using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalAssignmentChanges : MonoBehaviour
{
    public GameObject[] tools;

    //public GameObject interview1S1, interview1S2, interview1S3, interview1S4;
    //public GameObject interview1S1Empty, interview1S2Empty, interview1S3Empty, interview1S4Empty;
    //Vector2 interview1S1InitialPos, interview1S2InitialPos, interview1S3InitialPos, interview1S4InitialPos;

    public TextMeshProUGUI interview101, interview102, interview103, interview104;
    public TextMeshProUGUI interview201, interview202, interview203, interview204;
    public TextMeshProUGUI discussion1, discussion2, discussion3, discussion4;
    //public TextMeshProUGUI newsflash1, newsflash2, newsflash3, newsflash4, newsflash5, newsflash6;

    private string theme1, theme2, theme3;
    public TextMeshProUGUI introduction, paragraph1, paragraph2; //, paragraph3;

    public GameObject startCanvas, finalAssignmentCanvas, exitGameCanvas;

    // Start is called before the first frame update
    void Start() {
        //Interview1Tab();
        startCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        interview101.text = PlayerPrefs.GetString("ChangesInterview1-1");
        interview102.text = PlayerPrefs.GetString("ChangesInterview1-2");
        interview103.text = PlayerPrefs.GetString("ChangesInterview1-3");

        interview201.text = PlayerPrefs.GetString("ChangesInterview2-1");
        interview202.text = PlayerPrefs.GetString("ChangesInterview2-2");
        interview203.text = PlayerPrefs.GetString("ChangesInterview2-3");

        discussion1.text = PlayerPrefs.GetString("NewChangesDiscussion1");
        discussion2.text = PlayerPrefs.GetString("NewChangesDiscussion2");
        discussion3.text = PlayerPrefs.GetString("NewChangesDiscussion3");
        discussion4.text = PlayerPrefs.GetString("NewChangesDiscussion4");

        theme1 = PlayerPrefs.GetString("TopChangesTheme");
        theme2 = PlayerPrefs.GetString("SecondChangesTheme");
        introduction.text = "The top 2 issues that concern EU citizens are; " + theme1 + " and " + theme2 + ". Now select 4 views that you think best illustrate your views about EU identity changing over time.";
        paragraph1.text = "It is clear in the debate about EU identity that " + theme1 + " is very important. As one interviewee said (select a quotation about " + theme1 + " from your notebook):";
        paragraph2.text = "However, many people are also concerned about " + theme2 + " (select a quotation about " + theme2 + " from your notebook):";
        //paragraph3.text = "Many people seem very concerned about [THEME3]. To quote one of our interviewees on this topic:";



        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("ChangesJournalist");
        }*/
    }

    public void ReturnToWorkplace() {
        SceneManager.LoadScene("ChangesJournalist");
    }

    public void ExitGame() {
        //Application.Quit();
        SceneManager.LoadScene("PostQuestions");
    }

    public void ReturnToMap() {
        SceneManager.LoadScene("ScenarioChoice");
    }

    public void MainCanvas() {
        finalAssignmentCanvas.SetActive(true);
        startCanvas.SetActive(false);
        Interview1Tab();
    }

    public void Interview1Tab() {
        tools[0].SetActive(true); //Interview 1
        tools[1].SetActive(false); //Interview 2
        tools[2].SetActive(false); //Discussion
        tools[3].SetActive(false); //Newsflash
    }

    public void Interview2Tab() {
        tools[0].SetActive(false); //Interview 1
        tools[1].SetActive(true); //Interview 2
        tools[2].SetActive(false); //Discussion
        tools[3].SetActive(false); //Newsflash
    }

    public void DiscussionTab() {
        tools[0].SetActive(false); //Interview 1
        tools[1].SetActive(false); //Interview 2
        tools[2].SetActive(true); //Discussion
        tools[3].SetActive(false); //Newsflash
    }

    public void NewsflashTab() {
        tools[0].SetActive(false); //Interview 1
        tools[1].SetActive(false); //Interview 2
        tools[2].SetActive(false); //Discussion
        tools[3].SetActive(true); //Newsflash
    }

    public void GameFinished() {
        /*finalAssignmentCanvas.SetActive(false);
        exitGameCanvas.SetActive(true);*/
        SceneManager.LoadScene("DashboardChanges");
    }
}

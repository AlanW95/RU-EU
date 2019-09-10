using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalAssignment : MonoBehaviour {

    public GameObject[] tools;

    //public GameObject interview1S1, interview1S2, interview1S3, interview1S4;
    //public GameObject interview1S1Empty, interview1S2Empty, interview1S3Empty, interview1S4Empty;
    //Vector2 interview1S1InitialPos, interview1S2InitialPos, interview1S3InitialPos, interview1S4InitialPos;

    public TextMeshProUGUI interview101, interview102, interview103, interview104;
    public TextMeshProUGUI interview201, interview202, interview203, interview204;
    public TextMeshProUGUI discussion1, discussion2, discussion3, discussion4;
    //public TextMeshProUGUI newsflash1, newsflash2, newsflash3, newsflash4, newsflash5, newsflash6;

    private string theme1, theme2, theme3;
    public TextMeshProUGUI introduction, paragraph1, paragraph2, paragraph3;

    // Start is called before the first frame update
    void Start() {
        Interview1Tab();
    }

    // Update is called once per frame
    void Update() {
        interview101.text = PlayerPrefs.GetString("BrexitProInterview1");
        interview102.text = PlayerPrefs.GetString("BrexitProInterview2");
        interview103.text = PlayerPrefs.GetString("BrexitProInterview3");
        interview104.text = PlayerPrefs.GetString("BrexitProInterview4");

        interview201.text = PlayerPrefs.GetString("BrexitAntiInterview1");
        interview202.text = PlayerPrefs.GetString("BrexitAntiInterview2");
        interview203.text = PlayerPrefs.GetString("BrexitAntiInterview3");
        interview204.text = PlayerPrefs.GetString("BrexitAntiInterview4");

        discussion1.text = PlayerPrefs.GetString("NewBrexitDiscussion1");
        discussion2.text = PlayerPrefs.GetString("NewBrexitDiscussion2");
        discussion3.text = PlayerPrefs.GetString("NewBrexitDiscussion3");
        discussion4.text = PlayerPrefs.GetString("NewBrexitDiscussion4");

        //newsflash1.text = PlayerPrefs.GetString("BrexitNewsflash1");
        //newsflash2.text = PlayerPrefs.GetString("BrexitNewsflash2");
        //newsflash3.text = PlayerPrefs.GetString("BrexitNewsflash3");
        //newsflash4.text = PlayerPrefs.GetString("BrexitNewsflash4");
        //newsflash5.text = PlayerPrefs.GetString("BrexitNewsflash5");
        //newsflash6.text = PlayerPrefs.GetString("BrexitNewsflash6");

        theme1 = PlayerPrefs.GetString("TopTheme");
        introduction.text = "They key issues that concern EU citizens seems to be; " + theme1 + " , [THEME2], [THEME3].";
        paragraph1.text = "It is clear in the debate about EU identity that " + theme1 + " is very important. As one interviewee said:";
        paragraph2.text = "However, we would also remember that [THEME2] is important too. Speaking to our reporter, our interviewee said:";
        paragraph3.text = "Many people seem very concerned about [THEME3]. To quote one of our interviewees on this topic:";



        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Journalist");
        }
    }

    public void ReturnToWorkplace() {
        SceneManager.LoadScene("Journalist");
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
}

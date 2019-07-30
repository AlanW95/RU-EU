using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Notebook : MonoBehaviour
{

    public GameObject[] notebook;

    //public TextMeshProUGUI[] interview1TextDisplay;
    public TextMeshProUGUI interview1TextDisplay1;
    public TextMeshProUGUI interview1TextDisplay2;
    public TextMeshProUGUI interview1TextDisplay3;
    public TextMeshProUGUI interview1TextDisplay4;
    public TextMeshProUGUI[] interview2TextDisplay;
    public TextMeshProUGUI[] discussionTextDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Interview 1
        interview1TextDisplay1.text = PlayerPrefs.GetString("ProInterview1");
        interview1TextDisplay2.text = PlayerPrefs.GetString("ProInterview2");
        interview1TextDisplay3.text = PlayerPrefs.GetString("ProInterview3");
        interview1TextDisplay4.text = PlayerPrefs.GetString("ProInterview4");
        /*interview1TextDisplay[0].text = PlayerPrefs.GetString("ProInterview1");
        interview1TextDisplay[1].text = PlayerPrefs.GetString("ProInterview2");
        interview1TextDisplay[2].text = PlayerPrefs.GetString("ProInterview3");
        interview1TextDisplay[3].text = PlayerPrefs.GetString("ProInterview4");
        interview1TextDisplay[4].text = PlayerPrefs.GetString("ProInterview5");
        interview1TextDisplay[5].text = PlayerPrefs.GetString("ProInterview6");
        interview1TextDisplay[6].text = PlayerPrefs.GetString("ProInterview7");
        interview1TextDisplay[7].text = PlayerPrefs.GetString("ProInterview8");
        interview1TextDisplay[8].text = PlayerPrefs.GetString("ProInterview9");
        interview1TextDisplay[9].text = PlayerPrefs.GetString("ProInterview10");*/

        //Interview 2
        interview2TextDisplay[0].text = PlayerPrefs.GetString("AntiInterview1");
        interview2TextDisplay[1].text = PlayerPrefs.GetString("AntiInterview2");
        interview2TextDisplay[2].text = PlayerPrefs.GetString("AntiInterview3");
        interview2TextDisplay[3].text = PlayerPrefs.GetString("AntiInterview4");
        /*interview2TextDisplay[4].text = PlayerPrefs.GetString("AntiInterview5");
        interview2TextDisplay[5].text = PlayerPrefs.GetString("AntiInterview6");
        interview2TextDisplay[6].text = PlayerPrefs.GetString("AntiInterview7");
        interview2TextDisplay[7].text = PlayerPrefs.GetString("AntiInterview8");
        interview2TextDisplay[8].text = PlayerPrefs.GetString("AntiInterview9");
        interview2TextDisplay[9].text = PlayerPrefs.GetString("AntiInterview10");*/

        //Discussion
        //PlayerPrefs.SetString("Discussion1", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
        //PlayerPrefs.SetString("Discussion2", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
        //PlayerPrefs.SetString("Discussion3", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
        //PlayerPrefs.SetString("Discussion4", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");

        discussionTextDisplay[0].text = PlayerPrefs.GetString("NewDiscussion1");
        discussionTextDisplay[1].text = PlayerPrefs.GetString("NewDiscussion2");
        discussionTextDisplay[2].text = PlayerPrefs.GetString("NewDiscussion3");
        discussionTextDisplay[3].text = PlayerPrefs.GetString("NewDiscussion4");


        //Newsflash
    }

    public void HomePage() {
        notebook[0].SetActive(true);
        notebook[1].SetActive(false);
        notebook[2].SetActive(false);
        notebook[3].SetActive(false);
        notebook[4].SetActive(false);
    }

    public void Interview1() {
        notebook[0].SetActive(false);
        notebook[1].SetActive(true);
        notebook[2].SetActive(false);
        notebook[3].SetActive(false);
        notebook[4].SetActive(false);
    }

    public void Interview2() {
        notebook[0].SetActive(false);
        notebook[1].SetActive(false);
        notebook[2].SetActive(true);
        notebook[3].SetActive(false);
        notebook[4].SetActive(false);
    }

    public void Discussion() {
        notebook[0].SetActive(false);
        notebook[1].SetActive(false);
        notebook[2].SetActive(false);
        notebook[3].SetActive(true);
        notebook[4].SetActive(false);
    }

    public void Newsflash() {
        notebook[0].SetActive(false);
        notebook[1].SetActive(false);
        notebook[2].SetActive(false);
        notebook[3].SetActive(false);
        notebook[4].SetActive(true);
    }

    public void ReturnToWorkplace() {
        SceneManager.LoadScene("Journalist");
    }
}

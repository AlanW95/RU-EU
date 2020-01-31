using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NotebookImmigration : MonoBehaviour
{
    public GameObject[] notebook;

    //public TextMeshProUGUI[] interview1TextDisplay;
    public TextMeshProUGUI interview1TextDisplay1;
    public TextMeshProUGUI interview1TextDisplay2;
    public TextMeshProUGUI interview1TextDisplay3;
    public TextMeshProUGUI interview1TextDisplay4;
    public TextMeshProUGUI[] interview2TextDisplay;
    public TextMeshProUGUI[] discussionTextDisplay;
    public TextMeshProUGUI discussionTextDisplay1, discussionTextDisplay2, discussionTextDisplay3, discussionTextDisplay4;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        PlayerPrefs.GetInt("CurrentImmigrationSocialScore");
        PlayerPrefs.GetInt("CurrentImmigrationEnvironmentScore");
        PlayerPrefs.GetInt("CurrentImmigrationRightsAndResponsibilitiesScore");
        PlayerPrefs.GetInt("CurrentImmigrationSafetyAndSecurityScore");
        PlayerPrefs.GetInt("CurrentImmigrationEmotionalScore");
        PlayerPrefs.GetInt("CurrentImmigrationEconomyScore");
        PlayerPrefs.GetInt("CurrentImmigrationPoliticalScore");
        PlayerPrefs.GetInt("CurrentImmigrationHistoricScore");
        PlayerPrefs.GetInt("CurrentImmigrationCultureScore");
        PlayerPrefs.GetInt("CurrentImmigrationGeographyScore");

        //Interview 1
        interview1TextDisplay1.text = PlayerPrefs.GetString("ImmigrationProInterview1");
        interview1TextDisplay2.text = PlayerPrefs.GetString("ImmigrationProInterview2");
        interview1TextDisplay3.text = PlayerPrefs.GetString("ImmigrationProInterview3");
        interview1TextDisplay4.text = PlayerPrefs.GetString("ImmigrationProInterview4");

        //Interview 2
        interview2TextDisplay[0].text = PlayerPrefs.GetString("ImmigrationAntiInterview1");
        interview2TextDisplay[1].text = PlayerPrefs.GetString("ImmigrationAntiInterview2");
        interview2TextDisplay[2].text = PlayerPrefs.GetString("ImmigrationAntiInterview3");
        interview2TextDisplay[3].text = PlayerPrefs.GetString("ImmigrationAntiInterview4");

        //Balance Scenario
        discussionTextDisplay1.text = PlayerPrefs.GetString("NewImmigrationDiscussion1");
        discussionTextDisplay2.text = PlayerPrefs.GetString("NewImmigrationDiscussion2");
        discussionTextDisplay3.text = PlayerPrefs.GetString("NewImmigrationDiscussion3");
        discussionTextDisplay4.text = PlayerPrefs.GetString("NewImmigrationDiscussion4");

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
        SceneManager.LoadScene("ImmigrationJournalist");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Notebook : MonoBehaviour
{

    public GameObject[] notebook;

    public TextMeshProUGUI[] discussionTextDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Interview 1


        //Interview 2


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

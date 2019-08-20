using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Newsflash : MonoBehaviour
{
    //public Image SelectionNewsflash;
    //public List<Sprite> NewsflashList = new List<Sprite>();
    //private int selection = 0;

    public GameObject startCanvas, newsflashCanvas;

    //public GameObject[] newsflashItems;

    private int selection = 0; //do this after each time they select the CONTINUE button the Feedback Canvas.
    public TextMeshProUGUI textDisplay;

    public GameObject ogCanvas, feedbackCanvas;

    //public GameObject feedback;

    public GameObject statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8, statement9, statement10, statement11, statement12, statement13;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        newsflashCanvas.SetActive(false);
        selection = 0;

        //feedback.SetActive(false);
        //newsflashItems[0].SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        /*if (selection == 1) {
            Debug.Log("First choice has been made. Two choices remaining!");
            textDisplay.text = "First choice has been made. Two choices remaining!";
        }

        if (selection == 2) {
            Debug.Log("Second choice made. One choice remaining!");
            textDisplay.text = "Second choice has been made. One choice remaining!";
        }*/

        if (selection == 13) {
            //go to feedback screen
            //feedback.SetActive(true);
            //ogCanvas.SetActive(false);
            //feedbackCanvas.SetActive(true);

            //give overall feedback
        }
    }
    
    public void ExitGame() {
        //Application.Quit();
        SceneManager.LoadScene("Journalist");
    }

    public void Statement1() { //this will appear when the start button is selected to start the tool
        //in addition to it show this, we must make the canvas visible and have the Start Canvas when availble, to SetActive(false).
        startCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement1.SetActive(true);
        selection++;
    }

    public void Statement2() {
        statement1.SetActive(false);
        statement2.SetActive(true);
        selection++; //adds one each time the continue button from feedback is clicked.
    }

    public void Statement3() {
        statement2.SetActive(false);
        statement3.SetActive(true);
        selection++;
    }

    public void Statement4() {
        statement3.SetActive(false);
        statement4.SetActive(true);
        selection++;
    }

    public void Statement5() {
        statement4.SetActive(false);
        statement5.SetActive(true);
        selection++;
    }

    public void Statement6() {
        statement5.SetActive(false);
        statement6.SetActive(true);
        selection++;
    }

    public void Statement7() {
        statement6.SetActive(false);
        statement7.SetActive(true);
        selection++;
    }

    public void Statement8() {
        statement7.SetActive(false);
        statement8.SetActive(true);
        selection++;
    }

    public void Statement9() {
        statement8.SetActive(false);
        statement9.SetActive(true);
        selection++;
    }

    public void Statement10() {
        statement9.SetActive(false);
        statement10.SetActive(true);
        selection++;
    }

    public void Statement11() {
        statement10.SetActive(false);
        statement11.SetActive(true);
        selection++;
    }

    public void Statement12() {
        statement11.SetActive(false);
        statement12.SetActive(true);
        selection++;
    }

    public void Statement13() {
        statement12.SetActive(false);
        statement13.SetActive(true); //if needed once all statements are complete... you can put the statement13.SetActive(false); in the Update()
        selection++;
    }

    //-----------------------------------------------------------------------------------
    
    //Change PlayerPrefs to go with each item of newsflash heading
    /*public void Item1Selected() {
        //add interactable to disable
        PlayerPrefs.SetString("Newsflash1", "No-one had anticipated the problems the Irish border would cause for Brexit.");
        Debug.Log("Newsflash item 1 has been added.");
        selection++;
    }

    public void Item2Selected() {
        PlayerPrefs.SetString("Newsflash2", "The separate sovereign nations of the past cannot solve the problems of the present; we must go forward together in Europe.");
        Debug.Log("Newsflash item 2 has been added.");
        selection++;
    }

    public void Item3Selected() {
        PlayerPrefs.SetString("Newsflash3", "The Brexit referendum has highlighted the strength of feeling about the EU.");
        Debug.Log("Newsflash item 3 has been added.");
        selection++;
    }

    public void Item4Selected() {
        PlayerPrefs.SetString("Newsflash4", "Poor knowledge of history amongst EU citizens increases anti EU feelings.");
        Debug.Log("Newsflash item 4 has been added.");
        selection++;
    }

    public void Item5Selected() {
        PlayerPrefs.SetString("Newsflash5", "European laws can never be fair to all.");
        Debug.Log("Newsflash item 5 has been added.");
        selection++;
    }

    public void Item6Selected() {
        PlayerPrefs.SetString("Newsflash6", "Leaving the EU will allow the UK to strike trade deals with the rest of the world.");
        Debug.Log("Newsflash item 6 has been added.");
        selection++;
    }*/
    
    /*public void NewsflashItem1() {
        newsflashItems[0].SetActive(true);
        newsflashItems[1].SetActive(false);
        newsflashItems[2].SetActive(false);
        newsflashItems[3].SetActive(false);
        newsflashItems[4].SetActive(false);
        newsflashItems[5].SetActive(false);
    }

    public void NewsflashItem2() {
        newsflashItems[0].SetActive(false);
        newsflashItems[1].SetActive(true);
        newsflashItems[2].SetActive(false);
        newsflashItems[3].SetActive(false);
        newsflashItems[4].SetActive(false);
        newsflashItems[5].SetActive(false);
    }

    public void NewsflashItem3() {
        newsflashItems[0].SetActive(false);
        newsflashItems[1].SetActive(false);
        newsflashItems[2].SetActive(true);
        newsflashItems[3].SetActive(false);
        newsflashItems[4].SetActive(false);
        newsflashItems[5].SetActive(false);
    }

    public void NewsflashItem4() {
        newsflashItems[0].SetActive(false);
        newsflashItems[1].SetActive(false);
        newsflashItems[2].SetActive(false);
        newsflashItems[3].SetActive(true);
        newsflashItems[4].SetActive(false);
        newsflashItems[5].SetActive(false);
    }

    public void NewsflashItem5() {
        newsflashItems[0].SetActive(false);
        newsflashItems[1].SetActive(false);
        newsflashItems[2].SetActive(false);
        newsflashItems[3].SetActive(false);
        newsflashItems[4].SetActive(true);
        newsflashItems[5].SetActive(false);
    }

    public void NewsflashItem6() {
        newsflashItems[0].SetActive(false);
        newsflashItems[1].SetActive(false);
        newsflashItems[2].SetActive(false);
        newsflashItems[3].SetActive(false);
        newsflashItems[4].SetActive(false);
        newsflashItems[5].SetActive(true);
    }*/

    /*public void PreviousSelection() {
        if (selection > 0) {
            selection--;
            SelectionNewsflash.sprite = NewsflashList[selection];
        } else {
            if (selection == 0) {
                selection = NewsflashList.Count - 1;
                SelectionNewsflash.sprite = NewsflashList[selection];
            }
        }
    }

    public void NextSelection() {
        if (selection < NewsflashList.Count - 1) {
            selection++;
            SelectionNewsflash.sprite = NewsflashList[selection];
        } else {
            if (selection == NewsflashList.Count - 1) {
                selection = 0;
                SelectionNewsflash.sprite = NewsflashList[selection];
            }
        }
    }*/
}

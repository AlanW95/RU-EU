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

    public GameObject startCanvas, newsflashCanvas, feedbackCanvas, finishCanvas;

    private int selection = 0; //do this after each time they select the CONTINUE button the Feedback Canvas.
    //public TextMeshProUGUI textDisplay;

    public GameObject statement1, statement2, statement3, statement4, statement5, statement6;
    public GameObject statement1Continue, statement2Continue, statement3Continue, statement4Continue, statement5Continue, statement6Continue;
    public GameObject correct, incorrect;

    public GameObject geography, political, culture, environment, rightsResponsibilities, economy, social, security, emotions, history;
    public GameObject geographyEmpty, politicalEmpty, cultureEmpty, environmentEmpty, rightsResponsibilitiesEmpty, economyEmpty, socialEmpty, securityEmpty, emotionsEmpty, historyEmpty;
    Vector2 geographyInitialPos, politicalInitialPos, cultureInitialPos, environmentInitialPos, rightsResponsibilitiesInitialPos, economyInitialPos, socialInitialPos, securityInitialPos, emotionsInitialPos, historyInitialPos;

    public GameObject pro, anti, neutral;
    public GameObject proEmpty, antiEmpty, neutralEmpty;
    Vector2 proInitialPos, antiInitialPos, neutralInitialPos;
    public GameObject answerCorrect, answerIncorrect;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(false); //feedbackCanvas will happen after each selection is made by clicking a theme, depending on theme selected it will be right or wrong but won't matter
        finishCanvas.SetActive(false);
        selection = 0;
    }

    // Update is called once per frame
    void Update() {
        
        PlayerPrefs.GetInt("CurrentSocialScore");
        PlayerPrefs.GetInt("CurrentEnvironmentScore");
        PlayerPrefs.GetInt("CurrentRightsAndResponsibilitiesScore");
        PlayerPrefs.GetInt("CurrentSafetyAndSecurityScore");
        PlayerPrefs.GetInt("CurrentEmotionalScore");
        PlayerPrefs.GetInt("CurrentEconomyScore");
        PlayerPrefs.GetInt("CurrentPoliticalScore");
        PlayerPrefs.GetInt("CurrentHistoricScore");
        PlayerPrefs.GetInt("CurrentCultureScore");
        PlayerPrefs.GetInt("CurrentGeographyScore");

        /*if (selection == 13) {
            //go to feedback screen
            //feedback.SetActive(true);
            //ogCanvas.SetActive(false);
            //feedbackCanvas.SetActive(true);

            startCanvas.SetActive(false);
            newsflashCanvas.SetActive(false);
            feedbackCanvas.SetActive(false);

            //give overall feedback
            finishCanvas.SetActive(true);
        }*/

        if (geography.transform.position == geographyEmpty.transform.position && neutral.transform.position == neutralEmpty.transform.position) {
            Statement2();
            /*feedbackCanvas.SetActive(true);
            correct.SetActive(true);
            incorrect.SetActive(false);
            statement1Continue.SetActive(true);*/
        }

        if (political.transform.position == politicalEmpty.transform.position && pro.transform.position == proEmpty.transform.position) {
            Statement3();
        }

        if (culture.transform.position == cultureEmpty.transform.position && anti.transform.position == antiEmpty.transform.position) {
            Statement4();
        }

        if (environment.transform.position == environmentEmpty.transform.position && neutral.transform.position == neutralEmpty.transform.position) {
            Statement5();
        }

        if (rightsResponsibilities.transform.position == rightsResponsibilitiesEmpty.transform.position && anti.transform.position == antiEmpty.transform.position) {
            Statement6();
        }

        if (economy.transform.position == economyEmpty.transform.position && pro.transform.position == proEmpty.transform.position) {
            //finished
            finishCanvas.SetActive(true);
        }
    }
    
    public void ReturnToJournalist() {
        //Application.Quit();
        SceneManager.LoadScene("Journalist");
    }

    public void FeedbackGone() {
        feedbackCanvas.SetActive(false);
    }

    //NEW STATEMENT 1 - GEOGRAPHY   
    public void Statement1() { //this will appear when the start button is selected to start the tool
        //in addition to it show this, we must make the canvas visible and have the Start Canvas when availble, to SetActive(false).
        startCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement1.SetActive(true);
        selection++;
    }

    public void Statement2() {
        statement1Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement1.SetActive(false);
        statement2.SetActive(true);
        selection++; //adds one each time the continue button from feedback is clicked.
    }

    public void Statement3() {
        statement2Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement2.SetActive(false);
        statement3.SetActive(true);
        selection++;
    }

    //NEW STATEMENT 2 - POLITICAL
    public void Statement4() {
        statement3Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement3.SetActive(false);
        statement4.SetActive(true);
        selection++;
    }

    public void Statement5() {
        statement4Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement4.SetActive(false);
        statement5.SetActive(true);
        selection++;
    }

    //NEW STATEMENT 3 - CULTURE
    public void Statement6() {
        statement5Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement5.SetActive(false);
        statement6.SetActive(true);
        selection++;
    }

    //---------------------------------------------------------------------------------------------
    /*
     * Going to simplify this down at a later date, for the moment this way has been taken
     */

    public void Statement1Correct() {
        //Geography
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement1Continue.SetActive(true);
    }

    public void Statement1Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement1Continue.SetActive(true);
    }

    public void Statement2Correct() {
        //Political
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement2Continue.SetActive(true);
    }

    public void Statement2Incorrect() {
        newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement2Continue.SetActive(true);
    }

    public void Statement3Correct() {
        //Economy
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement3Continue.SetActive(true);
    }

    public void Statement3Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement3Continue.SetActive(true);
    }

    public void Statement4Correct() {
        //Political
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement4Continue.SetActive(true);
    }

    public void Statement4Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement4Continue.SetActive(true);
    }

    public void Statement5Correct() {
        //Emotions
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement5Continue.SetActive(true);
    }

    public void Statement5Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement5Continue.SetActive(true);
    }

    public void Statement6Correct() {
        //Culture
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        statement6Continue.SetActive(true);
    }

    public void Statement6Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement6Continue.SetActive(true);
    }

    public void DragGeography() {
        geography.transform.position = Input.mousePosition;
    }

    public void DragPolitical() {
        political.transform.position = Input.mousePosition;
    }

    public void DragCulture() {
        culture.transform.position = Input.mousePosition;
    }

    public void DragEnvironment() {
        environment.transform.position = Input.mousePosition;
    }

    public void DragRightsAndResponsibilities() {
        rightsResponsibilities.transform.position = Input.mousePosition;
    }

    public void DragEconomy() {
        economy.transform.position = Input.mousePosition;
    }

    public void DragSocial() {
        social.transform.position = Input.mousePosition;
    }

    public void DragSecurity() {
        security.transform.position = Input.mousePosition;
    }

    public void DragEmotions() {
        emotions.transform.position = Input.mousePosition;
    }

    public void DragHistory() {
        history.transform.position = Input.mousePosition;
    }

    public void DragPro() {
        pro.transform.position = Input.mousePosition;
    }

    public void DragAnti() {
        anti.transform.position = Input.mousePosition;
    }

    public void DragNeutral() {
        neutral.transform.position = Input.mousePosition;
    }

    public void DropGeography() {
        float distance = Vector3.Distance(geography.transform.position, geographyEmpty.transform.position);

        if (distance < 50) {
            geography.transform.position = geographyEmpty.transform.position;
            //geographyCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            geography.transform.position = geographyInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropPolitical() {
        float distance = Vector3.Distance(political.transform.position, politicalEmpty.transform.position);

        if (distance < 50) {
            political.transform.position = politicalEmpty.transform.position;
            //politicalCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            political.transform.position = politicalInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropCulture() {
        float distance = Vector3.Distance(culture.transform.position, cultureEmpty.transform.position);

        if (distance < 50) {
            culture.transform.position = cultureEmpty.transform.position;
            //cultureCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            culture.transform.position = cultureInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropEnvironment() {
        float distance = Vector3.Distance(environment.transform.position, environmentEmpty.transform.position);
        
        if (distance < 50) {
            environment.transform.position = environmentEmpty.transform.position;
            //environmentCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            environment.transform.position = environmentInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropRightsAndResponsibilities() {
        float distance = Vector3.Distance(rightsResponsibilities.transform.position, rightsResponsibilitiesEmpty.transform.position);

        if (distance < 50) {
            rightsResponsibilities.transform.position = rightsResponsibilitiesEmpty.transform.position;
            //rightsResponsibilitiesCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            rightsResponsibilities.transform.position = rightsResponsibilitiesInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropEconomy() {
        float distance = Vector3.Distance(economy.transform.position, economyEmpty.transform.position);

        if (distance < 50) {
            economy.transform.position = economyEmpty.transform.position;
            //economyCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            economy.transform.position = economyInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropSocial() {
        float distance = Vector3.Distance(social.transform.position, socialEmpty.transform.position);

        if (distance < 50) {
            social.transform.position = socialEmpty.transform.position;
            //socialCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            social.transform.position = socialInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropSecurity() {
        float distance = Vector3.Distance(security.transform.position, securityEmpty.transform.position);

        if (distance < 50) {
            security.transform.position = securityEmpty.transform.position;
            //securityCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            security.transform.position = securityInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropEmotions() {
        float distance = Vector3.Distance(emotions.transform.position, emotionsEmpty.transform.position);

        if (distance < 50) {
            emotions.transform.position = emotionsEmpty.transform.position;
            //emotionsCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            emotions.transform.position = emotionsInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropHistory() {
        float distance = Vector3.Distance(history.transform.position, historyEmpty.transform.position);

        if (distance < 50) {
            history.transform.position = historyEmpty.transform.position;
            //historyCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            history.transform.position = historyInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropPro() {
        float distance = Vector3.Distance(pro.transform.position, proEmpty.transform.position);

        if (distance < 50) {
            pro.transform.position = proEmpty.transform.position;
            //proCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            pro.transform.position = proInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropAnti() {
        float distance = Vector3.Distance(anti.transform.position, antiEmpty.transform.position);

        if (distance < 50) {
            anti.transform.position = antiEmpty.transform.position;
            //antiCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            anti.transform.position = antiInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropNeutral() {
        float distance = Vector3.Distance(neutral.transform.position, neutralEmpty.transform.position);

        if (distance < 50) {
            neutral.transform.position = neutralEmpty.transform.position;
            //neutralCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            neutral.transform.position = neutralInitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void TextNotActive() {
        //2 seconds delay on each
        StartCoroutine(HideText(answerIncorrect, 2f));
        StartCoroutine(HideText(answerCorrect, 1.5f));
    }

    IEnumerator HideText(GameObject text, float delay) {
        yield return new WaitForSeconds(delay);
        text.SetActive(false);
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

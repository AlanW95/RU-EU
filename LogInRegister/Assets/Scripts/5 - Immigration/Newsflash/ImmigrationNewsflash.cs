using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ImmigrationNewsflash : MonoBehaviour
{
    //public Image SelectionNewsflash;
    //public List<Sprite> NewsflashList = new List<Sprite>();
    //private int selection = 0;

    public GameObject startCanvas, newsflashCanvas, feedbackCanvas, finishCanvas;

    private int selection = 0; //do this after each time they select the CONTINUE button the Feedback Canvas.
    //public TextMeshProUGUI textDisplay;

    public GameObject statement1; //, statement2, statement3, statement4, statement5, statement6;
    //public GameObject statement1Continue, statement2Continue, statement3Continue, statement4Continue, statement5Continue, statement6Continue;
    public GameObject correct, incorrect;

    public TextMeshProUGUI headlineText;
    public GameObject geography, political, culture, environment, rightsResponsibilities, economy, social, security, emotions, history, political2, economy2, security2;
    public GameObject geographyEmpty, politicalEmpty, cultureEmpty, environmentEmpty, rightsResponsibilitiesEmpty, economyEmpty, socialEmpty, securityEmpty, emotionsEmpty, historyEmpty, political2Empty, economy2Empty, security2Empty;
    Vector2 geographyInitialPos, politicalInitialPos, cultureInitialPos, environmentInitialPos, rightsResponsibilitiesInitialPos, economyInitialPos, socialInitialPos, securityInitialPos, emotionsInitialPos, historyInitialPos, political2InitialPos, economy2InitialPos, security2InitialPos;

    public GameObject pro1, anti1, neutral1, pro2, anti2, neutral2, pro3, anti3, neutral3;
    public GameObject proEmpty1, antiEmpty1, neutralEmpty1, proEmpty2, antiEmpty2, neutralEmpty2, proEmpty3, antiEmpty3, neutralEmpty3;
    Vector2 pro1InitialPos, anti1InitialPos, neutral1InitialPos, pro2InitialPos, anti2InitialPos, neutral2InitialPos, pro3InitialPos, anti3InitialPos, neutral3InitialPos;
    public GameObject answerCorrect, answerIncorrect;

    public GameObject nullTheme, nullView;
    Vector2 nullThemeInitialPos, nullViewInitialPos;
    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(false); //feedbackCanvas will happen after each selection is made by clicking a theme, depending on theme selected it will be right or wrong but won't matter
        finishCanvas.SetActive(false);
        selection = 0;

        pro2.SetActive(false);
        anti2.SetActive(false);
        neutral2.SetActive(false);
        //---------------------------
        pro3.SetActive(false);
        anti3.SetActive(false);
        neutral3.SetActive(false);

        //Initial Positions
        geographyInitialPos = geography.transform.position;
        politicalInitialPos = political.transform.position;
        cultureInitialPos = culture.transform.position;
        environmentInitialPos = environment.transform.position;
        rightsResponsibilitiesInitialPos = rightsResponsibilities.transform.position;
        economyInitialPos = economy.transform.position;
        socialInitialPos = social.transform.position;
        securityInitialPos = security.transform.position;
        emotionsInitialPos = emotions.transform.position;
        historyInitialPos = history.transform.position;

        pro1InitialPos = pro1.transform.position;
        anti1InitialPos = anti1.transform.position;
        neutral1InitialPos = neutral1.transform.position;
        pro2InitialPos = pro2.transform.position;
        anti2InitialPos = anti2.transform.position;
        neutral2InitialPos = neutral2.transform.position;

        nullThemeInitialPos = nullTheme.transform.position;
        nullViewInitialPos = nullView.transform.position;

        headlineText.text = "Scotland's First Minister has spoken of the coutnry's reputation for being open, warm-hearted, and hospitable: 'hundreds of thousands of nationals from other EU countries, choose Scotland as their home'.";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("CurrentSocialImmigrationScore");
        PlayerPrefs.GetInt("CurrentEnvironmentImmigrationScore");
        PlayerPrefs.GetInt("CurrentRightsAndResponsibilitiesImmigrationScore");
        PlayerPrefs.GetInt("CurrentSafetyAndSecurityImmigrationScore");
        PlayerPrefs.GetInt("CurrentEmotionalImmigrationScore");
        PlayerPrefs.GetInt("CurrentEconomyImmigrationScore");
        PlayerPrefs.GetInt("CurrentPoliticalImmigrationScore");
        PlayerPrefs.GetInt("CurrentHistoricImmigrationScore");
        PlayerPrefs.GetInt("CurrentCultureImmigrationScore");
        PlayerPrefs.GetInt("CurrentGeographyImmigrationScore");

        //Q1
        if (political.transform.position == politicalEmpty.transform.position && pro1.transform.position == proEmpty1.transform.position) {
            //finishCanvas.SetActive(true);
            political.SetActive(false);
            //off screen
            politicalEmpty.transform.position = new Vector2(-1164, -48);
            proEmpty1.transform.position = new Vector2(-1111, -296);
            //on screen
            emotionsEmpty.transform.position = nullTheme.transform.position;
            neutralEmpty1.transform.position = nullView.transform.position;

            political2.SetActive(true);
            pro1.SetActive(false);
            pro2.SetActive(true);
            Statement2();
        }
        //Q2
        if (emotions.transform.position == emotionsEmpty.transform.position && neutral1.transform.position == neutralEmpty1.transform.position) {

            emotions.SetActive(false);
            //off screen
            emotionsEmpty.transform.position = new Vector2(-1164, -48);
            neutralEmpty1.transform.position = new Vector2(-1111, -296);
            //on screen
            economyEmpty.transform.position = nullThemeInitialPos;
            antiEmpty1.transform.position = nullViewInitialPos;

            neutral1.SetActive(false);
            neutral2.SetActive(true);
            Statement3();

            //finishCanvas.SetActive(true);
        }
        //Q3
        if (economy.transform.position == economyEmpty.transform.position && anti1.transform.position == antiEmpty1.transform.position) {

            economy.SetActive(false);
            //off screen
            economyEmpty.transform.position = new Vector2(-1164, -48);
            antiEmpty1.transform.position = new Vector2(-1111, -296);
            //on screen
            economy2Empty.transform.position = nullThemeInitialPos;
            proEmpty2.transform.position = nullViewInitialPos;

            economy2.SetActive(true);
            anti1.SetActive(false);
            anti2.SetActive(true);
            Statement4();

            //finishCanvas.SetActive(true);
        }

        //Q4
        if (economy2.transform.position == economy2Empty.transform.position && pro2.transform.position == proEmpty2.transform.position) {

            economy2.SetActive(false);
            //off screen
            economy2Empty.transform.position = new Vector2(-1164, -48);
            proEmpty2.transform.position = new Vector2(-1111, -296);
            //on screen
            securityEmpty.transform.position = nullThemeInitialPos;
            proEmpty3.transform.position = nullViewInitialPos;

            pro2.SetActive(false);
            pro3.SetActive(true);
            Statement5();

            //finishCanvas.SetActive(true);
        }

        if (security.transform.position == securityEmpty.transform.position && pro3.transform.position == proEmpty3.transform.position) {

            security.SetActive(false);
            //off screen
            securityEmpty.transform.position = new Vector2(-1164, -48);
            proEmpty3.transform.position = new Vector2(-1111, -296);
            //on screen
            political2Empty.transform.position = nullThemeInitialPos;
            antiEmpty2.transform.position = nullViewInitialPos;

            security2.SetActive(true);
            pro3.SetActive(false);
            //anti3.SetActive(true);
            Statement6();

            //finishCanvas.SetActive(true);
        }

        if (political2.transform.position == political2Empty.transform.position && anti2.transform.position == antiEmpty2.transform.position) {

            political2.SetActive(false);
            //off screen
            political2Empty.transform.position = new Vector2(-1164, -48);
            antiEmpty2.transform.position = new Vector2(-1111, -296);
            //on screen
            security2Empty.transform.position = nullThemeInitialPos;
            antiEmpty3.transform.position = nullViewInitialPos;

            anti2.SetActive(false);
            anti3.SetActive(true);
            Statement7();

            //finishCanvas.SetActive(true);
        }

        if (security2.transform.position == security2Empty.transform.position && anti3.transform.position == antiEmpty3.transform.position) {

            finishCanvas.SetActive(true);
        }
    }

    public void ReturnToJournalist() {
        //Application.Quit();
        SceneManager.LoadScene("ImmigrationJournalist");
    }

    public void FeedbackGone() {
        feedbackCanvas.SetActive(false);
    }

    //ANSWER IS POLITICAL PRO
    public void Statement1() { //this will appear when the start button is selected to start the tool
        //in addition to it show this, we must make the canvas visible and have the Start Canvas when availble, to SetActive(false).
        startCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        statement1.SetActive(true);
        selection++;
    }

    //ANSWER IS EMOTIONS NEUTRAL
    public void Statement2() {
        headlineText.text = "At least 34 Syrian migrants, among them 15 young children, have drowned this morning after falling into the Aegean sea, according to the Greek coastguards.";

        //statement1Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        //statement2.SetActive(true);
        selection++; //adds one each time the continue button from feedback is clicked.
    }

    //ANSWER IS ECONOMY ANTI
    public void Statement3() {
        headlineText.text = "The leader of the local union of the industry workers said that immigrants work for less money and increase locals' unemployment.";

        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        selection++;
    }

    //ANSWER IS ECONOMY PRO
    public void Statement4() {
        headlineText.text = "A study conducted by the London School of Economics in 2016 concluded that EU immigrants pay more in taxes than they use public services and therefore they help to reduce the budget deficit.";

        //statement3Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        //statement3.SetActive(false);
        //statement4.SetActive(true);
        selection++;
    }

    //ANSWER IS SECURITY PRO
    public void Statement5() {
        headlineText.text = "A recent research by Oxford University showed that immigrants that adopted a cultural background similar to Europe's are likely to commit fewer crimes than the native population.";

        //statement4Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        //statement4.SetActive(false);
        //statement5.SetActive(true);
        selection++;
    }

    //ANSWER IS POLITICAL ANTI
    public void Statement6() {
        headlineText.text = "'I hope there will be a change in the European public arena in favour of these political parties who would like to stop immigration,' said the Hungarian Prime Minister.";

        //statement5Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        //statement5.SetActive(false);
        //statement6.SetActive(true);
        selection++;
    }

    //ANSWER IS SECURITY ANTI
    public void Statement7() {
        headlineText.text = "The leader of the German far-right party AfD said that the number of murders and rapes increased 15% since Europe's huge 2015 influx of migrants and refugees more.";

        //statement6Continue.SetActive(false);
        feedbackCanvas.SetActive(false);
        newsflashCanvas.SetActive(true);
        //statement6.SetActive(false);
        //statement7.SetActive(false);
        selection++;
    }

    //---------------------------------------------------------------------------------------------
    /*
     * Going to simplify this down at a later date, for the moment this way has been taken
     */

    public void Statement1Correct() {
        //Political Pro
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        //statement1Continue.SetActive(true);
    }

    /*public void Statement1Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement1Continue.SetActive(true);
    }*/

    public void Statement2Correct() {
        //Emotions Neutral
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        //statement2Continue.SetActive(true);
    }

    /*public void Statement2Incorrect() {
        newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement2Continue.SetActive(true);
    }*/

    public void Statement3Correct() {
        //Economy Anti
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        //statement3Continue.SetActive(true);
    }

    /*public void Statement3Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement3Continue.SetActive(true);
    }*/

    public void Statement4Correct() {
        //Economy Pro
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        //statement4Continue.SetActive(true);
    }

    /*public void Statement4Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement4Continue.SetActive(true);
    }*/

    public void Statement5Correct() {
        //Security Pro
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        //statement5Continue.SetActive(true);
    }

    /*public void Statement5Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement5Continue.SetActive(true);
    }*/

    public void Statement6Correct() {
        //Political Anti
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        //statement6Continue.SetActive(true);
    }

    /*public void Statement6Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement6Continue.SetActive(true);
    }*/

    public void Statement7Correct() {
        //Security Anti
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(true);
        incorrect.SetActive(false);
        //statement6Continue.SetActive(true);
    }

    /*public void Statement7Incorrect() {
        //newsflashCanvas.SetActive(false);
        feedbackCanvas.SetActive(true);
        correct.SetActive(false);
        incorrect.SetActive(true);
        statement6Continue.SetActive(true);
    }*/

    public void DragGeography() {
        geography.transform.position = Input.mousePosition;
    }

    public void DragPolitical() {
        political.transform.position = Input.mousePosition;
    }

    public void DragPolitical2() {
        political2.transform.position = Input.mousePosition;
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

    public void DragEconomy2() {
        economy2.transform.position = Input.mousePosition;
    }

    public void DragSocial() {
        social.transform.position = Input.mousePosition;
    }

    public void DragSecurity() {
        security.transform.position = Input.mousePosition;
    }

    public void DragSecurity2() {
        security2.transform.position = Input.mousePosition;
    }

    public void DragEmotions() {
        emotions.transform.position = Input.mousePosition;
    }

    public void DragHistory() {
        history.transform.position = Input.mousePosition;
    }

    public void DragPro1() {
        pro1.transform.position = Input.mousePosition;
    }

    public void DragAnti1() {
        anti1.transform.position = Input.mousePosition;
    }

    public void DragNeutral1() {
        neutral1.transform.position = Input.mousePosition;
    }

    public void DragPro2() {
        pro2.transform.position = Input.mousePosition;
    }

    public void DragAnti2() {
        anti2.transform.position = Input.mousePosition;
    }

    public void DragNeutral2() {
        neutral2.transform.position = Input.mousePosition;
    }

    public void DragPro3() {
        pro3.transform.position = Input.mousePosition;
    }

    public void DragAnti3() {
        anti3.transform.position = Input.mousePosition;
    }

    public void DragNeutral3() {
        neutral3.transform.position = Input.mousePosition;
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

    public void DropPolitical2() {
        float distance = Vector3.Distance(political2.transform.position, political2Empty.transform.position);

        if (distance < 50) {
            political2.transform.position = political2Empty.transform.position;
            //politicalCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        }
        else {
            political2.transform.position = political2InitialPos;
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

    public void DropEconomy2() {
        float distance = Vector3.Distance(economy2.transform.position, economy2Empty.transform.position);

        if (distance < 50) {
            economy2.transform.position = economy2Empty.transform.position;
            //economyCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        }
        else {
            economy2.transform.position = economy2InitialPos;
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

    public void DropSecurity2() {
        float distance = Vector3.Distance(security2.transform.position, security2Empty.transform.position);

        if (distance < 50) {
            security2.transform.position = security2Empty.transform.position;
            //securityCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        }
        else {
            security2.transform.position = security2InitialPos;
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

    public void DropPro1() {
        float distance = Vector3.Distance(pro1.transform.position, proEmpty1.transform.position);

        if (distance < 50) {
            pro1.transform.position = proEmpty1.transform.position;
            //proCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            pro1.transform.position = pro1InitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropAnti1() {
        float distance = Vector3.Distance(anti1.transform.position, antiEmpty1.transform.position);

        if (distance < 50) {
            anti1.transform.position = antiEmpty1.transform.position;
            //antiCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            anti1.transform.position = anti1InitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropNeutral1() {
        float distance = Vector3.Distance(neutral1.transform.position, neutralEmpty1.transform.position);

        if (distance < 50) {
            neutral1.transform.position = neutralEmpty1.transform.position;
            //neutralCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            neutral1.transform.position = neutral1InitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropPro2() {
        float distance = Vector3.Distance(pro2.transform.position, proEmpty2.transform.position);

        if (distance < 50) {
            pro2.transform.position = proEmpty2.transform.position;
            //proCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            pro2.transform.position = pro2InitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropAnti2() {
        float distance = Vector3.Distance(anti2.transform.position, antiEmpty2.transform.position);

        if (distance < 50) {
            anti2.transform.position = antiEmpty2.transform.position;
            //antiCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            anti2.transform.position = anti2InitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropNeutral2() {
        float distance = Vector3.Distance(neutral2.transform.position, neutralEmpty2.transform.position);

        if (distance < 50) {
            neutral2.transform.position = neutralEmpty2.transform.position;
            //neutralCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        } else {
            neutral2.transform.position = neutral2InitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropPro3() {
        float distance = Vector3.Distance(pro3.transform.position, proEmpty3.transform.position);

        if (distance < 50) {
            pro3.transform.position = proEmpty3.transform.position;
            //proCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        }
        else {
            pro3.transform.position = pro3InitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropAnti3() {
        float distance = Vector3.Distance(anti3.transform.position, antiEmpty3.transform.position);

        if (distance < 50) {
            anti3.transform.position = antiEmpty3.transform.position;
            //antiCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        }
        else {
            anti3.transform.position = anti3InitialPos;
            answerIncorrect.SetActive(true);
            TextNotActive();
        }
    }

    public void DropNeutral3() {
        float distance = Vector3.Distance(neutral3.transform.position, neutralEmpty3.transform.position);

        if (distance < 50) {
            neutral3.transform.position = neutralEmpty3.transform.position;
            //neutralCorrect = true;
            answerCorrect.SetActive(true);
            TextNotActive();
        }
        else {
            neutral3.transform.position = neutral3InitialPos;
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
}

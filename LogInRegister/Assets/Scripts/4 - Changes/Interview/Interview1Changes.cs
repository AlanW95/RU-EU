using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Interview1Changes : MonoBehaviour
{
    //initial starting canvas
    public GameObject startCanvas;

    //after START is selected from the Start Canvas, this canvas will appear
    public GameObject questionSelectionCanvas;
    public GameObject questionSelectionContinueButton;
    //public GameObject themeDefinitionCanvas;

    public GameObject interviewCanvas;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;

    //canvas that gives the player feedback on what they have done in the Pro Interview tool
    public GameObject feedbackCanvas;
    public GameObject scoreCanvas;

    public GameObject rankingCanvas;
    public TextMeshProUGUI statementText; //within ranking canvas

    [SerializeField]
    private float typingSpeed;
    public GameObject continueButton;

    //themes from selection, used to disabled each button
    public Button question1Button, question2Button, question3Button, question4Button, question5Button, question6Button, question7Button, question8Button, question9Button, question10Button;

    //each time a continue button is pressed the counter goes down
    public int interviewCounter;
    public int secondCounter;

    private bool statement1Selected = false;
    private bool statement2Selected = false;
    private bool statement3Selected = false;
    private bool statement4Selected = false;

    private bool selected = false;

    //PlayerPrefs
    //public string changesNeighbourInterview = "Neighbour1Interview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

    //public AudioClip backgroundClip;
    //public AudioSource backgroundSource;

    //Collecting data through Google Forms
    public InputField inputEmail, input1, input2, input3;
    private string emailAnswer, selection1Answer, selection2Answer, selection3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdrHnDk3QC8RQGqfLq3u8fGqlgzfWRsSHvabmGrGi3iycOPFw/formResponse"; //add Google link here

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);

        scoreCanvas.SetActive(false);
        rankingCanvas.SetActive(false);
        feedbackCanvas.SetActive(false);

        interviewCounter = 6;
        secondCounter = 3;

        //backgroundSource.clip = backgroundClip;
        //backgroundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("CurrentChangesSocialScore");
        PlayerPrefs.GetInt("CurrentChangesEnvironmentScore");
        PlayerPrefs.GetInt("CurrentChangesRightsAndResponsibilitiesScore");
        PlayerPrefs.GetInt("CurrentChangesSafetyAndSecurityScore");
        PlayerPrefs.GetInt("CurrentChangesEmotionalScore");
        PlayerPrefs.GetInt("CurrentChangesEconomyScore");
        PlayerPrefs.GetInt("CurrentChangesPoliticalScore");
        PlayerPrefs.GetInt("CurrentChangesHistoricScore");
        PlayerPrefs.GetInt("CurrentChangesCultureScore");
        PlayerPrefs.GetInt("CurrentChangesGeographyScore");

        if (textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }

        if (interviewCounter <= 0) {
            //give feedback
            //textDisplay.text = "Sorry but I must dash now, that is all I have time for.";
            Debug.Log("You have asked 3 questions!");

            rankingCanvas.SetActive(true);
        }

        if (secondCounter <= 0) {
            Debug.Log("You have answered 3 questions! If you wish, you may proceed and collect more statements but this will not affect your score.");
            //questionSelectionContinueButton.SetActive(true);
            questionSelectionCanvas.SetActive(false);

            //scoreCanvas.SetActive(true);
            feedbackCanvas.SetActive(true);
        }

        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("JournalistCR");
        }*/

        Debug.Log(PlayerPrefs.GetString("ChangesTopTheme"));
        Debug.Log(PlayerPrefs.GetString("ChangesSecondTheme"));
    }

    public void ResetPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

    //No longer being used.
    /*public void DisplayThemeDefinitions() {
        themeDefinitionCanvas.SetActive(true);
    }

    public void RemoveThemeDefinitions() {
        themeDefinitionCanvas.SetActive(false);
    }*/

    public void ReturnToMobileWorkplace() {
        SceneManager.LoadScene("JournalistCR"); //CR for Croatia
    }

    public void RankedStatements() {
        rankingCanvas.SetActive(false);
        questionSelectionCanvas.SetActive(true);

        secondCounter -= 1;
    }

    public void ScoreAndFeedback() {
        questionSelectionCanvas.SetActive(false);

        //scoreCanvas.SetActive(true);
        feedbackCanvas.SetActive(true);
    }

    public void CounterDown() {
        interviewCounter--;
        Debug.Log(interviewCounter);
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter; //letter by letter type animation of the text, more animations can be added via the Animate tab

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //this will be called from the PLAY button
    //attach one of the first three issue for the inspector shouldn't matter which one you put in
    public void QuestionsAppear() {
        startCanvas.SetActive(false);
        questionSelectionCanvas.SetActive(true);
        inputEmail.text = PlayerPrefs.GetString("PlayerEmail");
    }

    public void NextSentence() {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1) {
            Debug.Log("Button has been pressed");
            index++;
            textDisplay.text = "";

            startCanvas.SetActive(false); //start canvas kept appearing

            rankingCanvas.SetActive(false);

            StartCoroutine(Type());
        }
        else { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);

            interviewCanvas.SetActive(false);

            rankingCanvas.SetActive(true);
        }
    }

    //SOCIAL
    public void Question1() {
        question1Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question1Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "Emigration of educated people, combined with immigration of non-educated people, leaves my country in deep problems."); //SOCIAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "Emigration of educated people, combined with immigration of non-educated people, leaves my country in deep problems."); //SOCIAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "Emigration of educated people, combined with immigration of non-educated people, leaves my country in deep problems."); //SOCIAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    //ENVIRONMENT
    public void Question2() {
        question2Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question2Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "I generally agree with protecting the environment, but EU regulations have placed negative restrictions to our economy. Whole industries, such as fishing, have been impacted."); //ENVIRONMENT
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Environment";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "I generally agree with protecting the environment, but EU regulations have placed negative restrictions to our economy. Whole industries, such as fishing, have been impacted."); //ENVIRONMENT
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Environment";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "I generally agree with protecting the environment, but EU regulations have placed negative restrictions to our economy. Whole industries, such as fishing, have been impacted."); //ENVIRONMENT
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Environment";
            Debug.Log(input3.text);
        }
    }

    //RIGHTS & RESPONSIBILITIES
    public void Question3() {
        question3Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question3Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "I think that Croatia pays more money to the EU than it gets back."); //RIGHTS & RESPONSIBILITIES
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Rights & Responsibilities";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "I think that Croatia pays more money to the EU than it gets back."); //RIGHTS & RESPONSIBILITIES
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Rights & Responsibilities";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "I think that Croatia pays more money to the EU than it gets back."); //RIGHTS & RESPONSIBILITIES
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Rights & Responsibilities";
            Debug.Log(input3.text);
        }
    }

    //SECURITY
    public void Question4() {
        question4Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question4Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "That politics is great, but living in Croatia - which is outside the Schengen zone - I do not feel the same level of protection as in for instance, Germany."); //SECURITY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Security";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "That politics is great, but living in Croatia - which is outside the Schengen zone - I do not feel the same level of protection as in for instance, Germany."); //SECURITY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Security";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "That politics is great, but living in Croatia - which is outside the Schengen zone - I do not feel the same level of protection as in for instance, Germany."); //SECURITY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Security";
            Debug.Log(input3.text);
        }
    }

    //EMOTIONAL
    public void Question5() {
        question5Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question5Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "I definitely feel more Croatian than European. I feel that it will take many generations before Croatian people start feeling truly European."); //EMOTIONAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Emotional";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "I definitely feel more Croatian than European. I feel that it will take many generations before Croatian people start feeling truly European."); //EMOTIONAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Emotional";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "I definitely feel more Croatian than European. I feel that it will take many generations before Croatian people start feeling truly European."); //EMOTIONAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Emotional";
            Debug.Log(input3.text);
        }
    }

    //ECONOMY
    public void Question6() {
        question6Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question6Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "I think that Croatia is too small and vulnerable to get rid of fiscal sovereignty. I do not want Croatia to enter the eurozone."); //ECONOMY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Economy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "I think that Croatia is too small and vulnerable to get rid of fiscal sovereignty. I do not want Croatia to enter the eurozone."); //ECONOMY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Economy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "I think that Croatia is too small and vulnerable to get rid of fiscal sovereignty. I do not want Croatia to enter the eurozone."); //ECONOMY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Economy";
            Debug.Log(input3.text);
        }
    }

    //POLITICAL
    public void Question7() {
        question7Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());

    }

    public void Question7Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "Sometimes I do, sometimes I don't - but I would definitely want Croatia to have more independence in foreign policy affairs."); //POLITICAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Political";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "Sometimes I do, sometimes I don't - but I would definitely want Croatia to have more independence in foreign policy affairs."); //POLITICAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Political";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "Sometimes I do, sometimes I don't - but I would definitely want Croatia to have more independence in foreign policy affairs."); //POLITICAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Political";
            Debug.Log(input3.text);
        }
    }

    //HISTORY
    public void Question8() {
        question8Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question8Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "Croatia has always been, culturally and geographically, a part of Europe."); //HISTORY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "History";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "Croatia has always been, culturally and geographically, a part of Europe."); //HISTORY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "History";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "Croatia has always been, culturally and geographically, a part of Europe."); //HISTORY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "History";
            Debug.Log(input3.text);
        }
    }

    //CULTURE
    public void Question9() {
        question9Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question9Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "Croatian culture is not recognised enough in Europe - there are still too many people who associate it to Yugoslavia. Joining the EU changes that perception, but the rate of change is far too slow."); //CULTURE
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Culture";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "Croatian culture is not recognised enough in Europe - there are still too many people who associate it to Yugoslavia. Joining the EU changes that perception, but the rate of change is far too slow."); //CULTURE
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Culture";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "Croatian culture is not recognised enough in Europe - there are still too many people who associate it to Yugoslavia. Joining the EU changes that perception, but the rate of change is far too slow."); //CULTURE
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Culture";
            Debug.Log(input3.text);
        }
    }

    //GEOGRAPHY
    public void Question10() {
        question10Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Question10Selected() {

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ChangesInterview1-1", "Situated at the border of the EU, Croatia has an important geostrategic position. Historically, this has always been the case. I don't think that the EU pays enough attention to importance of Croatia's geographical position."); //GEOGRAPHY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-1"));
            input1.text = "Geography";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview1-2", "Situated at the border of the EU, Croatia has an important geostrategic position. Historically, this has always been the case. I don't think that the EU pays enough attention to importance of Croatia's geographical position."); //GEOGRAPHY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-2"));
            input2.text = "Geography";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview1-3", "Situated at the border of the EU, Croatia has an important geostrategic position. Historically, this has always been the case. I don't think that the EU pays enough attention to importance of Croatia's geographical position."); //GEOGRAPHY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview1-3"));
            input3.text = "Geography";
            Debug.Log(input3.text);
        }
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

    IEnumerator PostToGoogle(string emailAnswer, string selection1, string selection2, string selection3) {
        WWWForm form = new WWWForm();

        form.AddField("entry.1572594164", emailAnswer);
        form.AddField("entry.2029289940", selection1);
        form.AddField("entry.958724560", selection2);
        form.AddField("entry.759466322", selection3);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);

        yield return www;
    }

    public void Send() {
        emailAnswer = inputEmail.GetComponent<InputField>().text;
        Debug.Log(emailAnswer);
        selection1Answer = input1.GetComponent<InputField>().text;
        Debug.Log(selection1Answer);
        selection2Answer = input2.GetComponent<InputField>().text;
        Debug.Log(selection2Answer);
        selection3Answer = input3.GetComponent<InputField>().text;
        Debug.Log(selection3Answer);

        Debug.Log("Processing all themes selected and sending to Google Forms.");

        StartCoroutine(PostToGoogle(emailAnswer, selection1Answer, selection2Answer, selection3Answer));
    }
}

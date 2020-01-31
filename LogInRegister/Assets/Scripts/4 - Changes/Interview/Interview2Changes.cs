using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Interview2Changes : MonoBehaviour
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
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScXWz7UzsXdAXz6mgpxoZo-EHKPA5olBFVSKBsd8v1AYalKQA/formResponse"; //add Google link here

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
            SceneManager.LoadScene("ChangesJournalist");
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
        SceneManager.LoadScene("ChangesJournalist"); //CR for Croatia
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
            PlayerPrefs.SetString("ChangesInterview2-1", "Since Croatia joined the EU, we gained a lot of optimism regarding out future. However, this optimism is tamed by a sharp rise of immigration and by increasing privatization of public goods such as schooling and healthcare."); //SOCIAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "Since Croatia joined the EU, we gained a lot of optimism regarding out future. However, this optimism is tamed by a sharp rise of immigration and by increasing privatization of public goods such as schooling and healthcare."); //SOCIAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "Since Croatia joined the EU, we gained a lot of optimism regarding out future. However, this optimism is tamed by a sharp rise of immigration and by increasing privatization of public goods such as schooling and healthcare."); //SOCIAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "I think that Croatia is much less ambitious in that regard than it should be - and the EU can help us do even better."); //ENVIRONMENT
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Environment";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "I think that Croatia is much less ambitious in that regard than it should be - and the EU can help us do even better."); //ENVIRONMENT
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Environment";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "I think that Croatia is much less ambitious in that regard than it should be - and the EU can help us do even better."); //ENVIRONMENT
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "I think that the right to work in any European country is one of the greatest achievements of the EU. Some people are afraid of immigration, but I think that we will soon also have many migrants from other European countries who will come to live and work in Croatia."); //RIGHTS & RESPONSIBILITIES
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Rights & Responsibilities";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "I think that the right to work in any European country is one of the greatest achievements of the EU. Some people are afraid of immigration, but I think that we will soon also have many migrants from other European countries who will come to live and work in Croatia."); //RIGHTS & RESPONSIBILITIES
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Rights & Responsibilities";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "I think that the right to work in any European country is one of the greatest achievements of the EU. Some people are afraid of immigration, but I think that we will soon also have many migrants from other European countries who will come to live and work in Croatia."); //RIGHTS & RESPONSIBILITIES
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "I think that the EU, despite its internal conflicts, reacted to migrant crisis very well."); //SECURITY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Security";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "I think that the EU, despite its internal conflicts, reacted to migrant crisis very well."); //SECURITY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Security";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "I think that the EU, despite its internal conflicts, reacted to migrant crisis very well."); //SECURITY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "Not really. I always felt both European and Croatian, and I don't see a conflict between the two identities."); //EMOTIONAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Emotional";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "Not really. I always felt both European and Croatian, and I don't see a conflict between the two identities."); //EMOTIONAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Emotional";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "Not really. I always felt both European and Croatian, and I don't see a conflict between the two identities."); //EMOTIONAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "Unemployment rate is much lower, and life standard seems to be on the rise. While these changes can be attributed to an extent to large immigration, I do believe that Croatia is on a good track."); //ECONOMY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Economy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "Unemployment rate is much lower, and life standard seems to be on the rise. While these changes can be attributed to an extent to large immigration, I do believe that Croatia is on a good track."); //ECONOMY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Economy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "Unemployment rate is much lower, and life standard seems to be on the rise. While these changes can be attributed to an extent to large immigration, I do believe that Croatia is on a good track."); //ECONOMY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "Unfortunately, I cannot see many substantial changes - I think that local politics has more or less continued to work in the same way. Having said that, I do notice two major improvements. Public discourse has become much more polite, and rights of minorities are on the rise."); //POLITICAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Political";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "Unfortunately, I cannot see many substantial changes - I think that local politics has more or less continued to work in the same way. Having said that, I do notice two major improvements. Public discourse has become much more polite, and rights of minorities are on the rise."); //POLITICAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Political";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "Unfortunately, I cannot see many substantial changes - I think that local politics has more or less continued to work in the same way. Having said that, I do notice two major improvements. Public discourse has become much more polite, and rights of minorities are on the rise."); //POLITICAL
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "Yugoslavia cannot be compared to the EU, and Croatia is too small to be on its own. I believe that joining the EU was a logical step and I am sorry that Croatia joined so late."); //HISTORY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "History";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "Yugoslavia cannot be compared to the EU, and Croatia is too small to be on its own. I believe that joining the EU was a logical step and I am sorry that Croatia joined so late."); //HISTORY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "History";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "Yugoslavia cannot be compared to the EU, and Croatia is too small to be on its own. I believe that joining the EU was a logical step and I am sorry that Croatia joined so late."); //HISTORY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "Croatian language is quite small; in order to participate at an international level, each Croatian needs to speak at least one foreign language. These days, in our era of globalization, this is the problem with all small languages. However, the EU has amazing language protection laws, and I believe that Croatian language has a much better chance of preservation within the EU."); //CULTURE
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Culture";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "Croatian language is quite small; in order to participate at an international level, each Croatian needs to speak at least one foreign language. These days, in our era of globalization, this is the problem with all small languages. However, the EU has amazing language protection laws, and I believe that Croatian language has a much better chance of preservation within the EU."); //CULTURE
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Culture";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "Croatian language is quite small; in order to participate at an international level, each Croatian needs to speak at least one foreign language. These days, in our era of globalization, this is the problem with all small languages. However, the EU has amazing language protection laws, and I believe that Croatian language has a much better chance of preservation within the EU."); //CULTURE
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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
            PlayerPrefs.SetString("ChangesInterview2-1", "Croatia has always had an important geo-strategical position, and the EU invests a lot of effort into helping us to cope with it."); //GEOGRAPHY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-1"));
            input1.text = "Geography";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ChangesInterview2-2", "Croatia has always had an important geo-strategical position, and the EU invests a lot of effort into helping us to cope with it."); //GEOGRAPHY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-2"));
            input2.text = "Geography";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ChangesInterview2-3", "Croatia has always had an important geo-strategical position, and the EU invests a lot of effort into helping us to cope with it."); //GEOGRAPHY
            Debug.Log(PlayerPrefs.GetString("ChangesInterview2-3"));
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

        form.AddField("entry.175630732", emailAnswer);
        form.AddField("entry.1285278151", selection1);
        form.AddField("entry.778440416", selection2);
        form.AddField("entry.172086285", selection3);

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

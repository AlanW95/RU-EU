using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LorryDriverInterview : MonoBehaviour
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
    public Button question1Button, question2Button, question3Button, question4Button, question5Button, question6Button, question7Button, question8Button, question9Button, question10Button, question11Button;

    //each time a continue button is pressed the counter goes down
    public int interviewCounter;
    public int secondCounter;

    public TextMeshProUGUI chosenTextDisplay;
    
    //public AudioClip backgroundClip;
    //public AudioSource backgroundSource;

    //Collecting Data through Google Forms
    public InputField inputEmail, input1, input2, input3;
    private string emailAnswer, selection1Answer, selection2Answer, selection3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfNE9idc32Q3PKE1FHuyR0RIkHEF-7m9ywHlGskwBklKTRydQ/formResponse";

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);

        scoreCanvas.SetActive(false);
        rankingCanvas.SetActive(false);
        feedbackCanvas.SetActive(false);

        interviewCounter = 6;
        secondCounter = 3;

        FloatingTextController.Initialize();

        //backgroundSource.clip = backgroundClip;
        //backgroundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("CurrentLorryTruckSocialScore");
        PlayerPrefs.GetInt("CurrentLorryTruckEnvironmentScore");
        PlayerPrefs.GetInt("CurrentLorryTruckRightsAndResponsibilitiesScore");
        PlayerPrefs.GetInt("CurrentLorryTruckSafetyAndSecurityScore");
        PlayerPrefs.GetInt("CurrentLorryTruckEmotionalScore");
        PlayerPrefs.GetInt("CurrentLorryTruckEconomyScore");
        PlayerPrefs.GetInt("CurrentLorryTruckPoliticalScore");
        PlayerPrefs.GetInt("CurrentLorryTruckHistoricScore");
        PlayerPrefs.GetInt("CurrentLorryTruckCultureScore");
        PlayerPrefs.GetInt("CurrentLorryTruckGeographyScore");

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

            scoreCanvas.SetActive(true);
            feedbackCanvas.SetActive(true);
        }

        Debug.Log(PlayerPrefs.GetString("TopLorryTruckTheme"));
        Debug.Log(PlayerPrefs.GetString("SecondLorryTruckTheme"));
    }

    public void ResetPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

    //Used for individual demos of the tool
    /*public void ExitGame() {
        Application.Quit();
    }*/

    /*public void DisplayThemeDefinitions() {
        themeDefinitionCanvas.SetActive(true);
    }

    public void RemoveThemeDefinitions() {
        themeDefinitionCanvas.SetActive(false);
    }*/

    public void ReturnToMobileWorkplace() {
        SceneManager.LoadScene("LorryTruckJournalist");
    }

    public void RankedStatements() {
        rankingCanvas.SetActive(false);
        questionSelectionCanvas.SetActive(true);

        secondCounter--;
    }

    public void ScoreAndFeedback() {
        questionSelectionCanvas.SetActive(false);

        scoreCanvas.SetActive(true);
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
        } else { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);

            interviewCanvas.SetActive(false);

            rankingCanvas.SetActive(true);
            //statementText.text = PlayerPrefs.GetString("ProInterviewStatementSelection", proInterviewStatements);
        }
    }

    public void Question1() {
        question1Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question1Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "Are the new European proposals not primarily intended to satisfy Germany and the Netherlands?");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "Are the new European proposals not primarily intended to satisfy Germany and the Netherlands?");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "Are the new European proposals not primarily intended to satisfy Germany and the Netherlands?");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Question2() {
        question2Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question2Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "Income in Romania is the lowest in the European Union. Dutch and German companies are therefore keen to work with Romanians.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Decoy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "Income in Romania is the lowest in the European Union. Dutch and German companies are therefore keen to work with Romanians.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Decoy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "Income in Romania is the lowest in the European Union. Dutch and German companies are therefore keen to work with Romanians.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Decoy";
            Debug.Log(input3.text);
        }
    }

    public void Question3() {
        question3Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question3Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "After Brexit, Brussels would show its social face, wouldn't it?");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "After Brexit, Brussels would show its social face, wouldn't it?");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "After Brexit, Brussels would show its social face, wouldn't it?");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Question4() {
        question4Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question4Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "Fraudulent use of the tachograph? The penalties for breaching the European regulations on rest periods and driving times are far too high, and I have to pay for this myself.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Security";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "Fraudulent use of the tachograph? The penalties for breaching the European regulations on rest periods and driving times are far too high, and I have to pay for this myself.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Security";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "Fraudulent use of the tachograph? The penalties for breaching the European regulations on rest periods and driving times are far too high, and I have to pay for this myself.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Security";
            Debug.Log(input3.text);
        }
    }

    public void Question5() {
        question5Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question5Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "West-European transporters can hire a room with a postbox, and be able to hire Romanians to drive in Western Europe at Romanian salaries and insurances.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "West-European transporters can hire a room with a postbox, and be able to hire Romanians to drive in Western Europe at Romanian salaries and insurances.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "West-European transporters can hire a room with a postbox, and be able to hire Romanians to drive in Western Europe at Romanian salaries and insurances.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Question6() {
        question6Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question6Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "They say: The Netherlands exports cheese and tulips. Romania exports people.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Decoy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "They say: The Netherlands exports cheese and tulips. Romania exports people.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Decoy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "They say: The Netherlands exports cheese and tulips. Romania exports people.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Decoy";
            Debug.Log(input3.text);
        }
    }

    public void Question7() {
        question7Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());

    }

    public void Question7Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "Yes, thanks!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Decoy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "Yes, thanks!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Decoy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "Yes, thanks!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Decoy";
            Debug.Log(input3.text);
        }
    }

    public void Question8() {
        question8Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question8Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "I hardly ever leave my cabin and never seen my children.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "I hardly ever leave my cabin and never seen my children.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "I hardly ever leave my cabin and never seen my children.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Question9() {
        question9Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question9Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "He told me his company has to deal with an increasing shortage of truck drivers in the transport sector (40% of the ageing workforce will be retiring in the next 10 years) and with rising demands of the market. And of course there are economic benefits for him and me!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Economy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "He told me his company has to deal with an increasing shortage of truck drivers in the transport sector (40% of the ageing workforce will be retiring in the next 10 years) and with rising demands of the market. And of course there are economic benefits for him and me!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Economy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "He told me his company has to deal with an increasing shortage of truck drivers in the transport sector (40% of the ageing workforce will be retiring in the next 10 years) and with rising demands of the market. And of course there are economic benefits for him and me!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Economy";
            Debug.Log(input3.text);
        }
    }

    public void Question10() {
        question10Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question10Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "Actually trucks with Romanian license plates have to pass the same kind of controls as trucks from The Netherlands and other foreign countries. However, because no international agreement on environmental requirements is in order for many countries, trucks that are more contaminating sometimes enter more easily than less contaminating trucks that do have to obey these new rules. For me, that's an advantage!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Environment";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "Actually trucks with Romanian license plates have to pass the same kind of controls as trucks from The Netherlands and other foreign countries. However, because no international agreement on environmental requirements is in order for many countries, trucks that are more contaminating sometimes enter more easily than less contaminating trucks that do have to obey these new rules. For me, that's an advantage!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Environment";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "Actually trucks with Romanian license plates have to pass the same kind of controls as trucks from The Netherlands and other foreign countries. However, because no international agreement on environmental requirements is in order for many countries, trucks that are more contaminating sometimes enter more easily than less contaminating trucks that do have to obey these new rules. For me, that's an advantage!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Environment";
            Debug.Log(input3.text);
        }
    }

    public void Question11() {
        question11Button.interactable = false;
        questionSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question11Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview2-1", "I had to drive through the whole EU, and got the idea to realise a monitored parking place according to the German model in Romania. Quite lucrative for me!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Economy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview2-2", "I had to drive through the whole EU, and got the idea to realise a monitored parking place according to the German model in Romania. Quite lucrative for me!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Economy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview2-3", "I had to drive through the whole EU, and got the idea to realise a monitored parking place according to the German model in Romania. Quite lucrative for me!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Economy";
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

        form.AddField("entry.1891709835", emailAnswer);
        form.AddField("entry.1291448739", selection1);
        form.AddField("entry.1908054733", selection2);
        form.AddField("entry.671794453", selection3);

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

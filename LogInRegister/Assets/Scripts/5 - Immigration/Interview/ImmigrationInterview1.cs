﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ImmigrationInterview1 : MonoBehaviour
{
    //Pro Sided Interview for Immigration scenario.

    private bool interview1Completed;

    //initial starting canvas
    public GameObject startCanvas;

    //after START is selected from the Start Canvas, this canvas will appear
    public GameObject themeSelectionCanvas;
    public GameObject themeSelectionContinueButton;
    public GameObject themeDefinitionCanvas;

    public GameObject interviewCanvas;

    public TextMeshProUGUI textDisplay;
    public Animator animText;
    public string[] sentences;
    private int index;

    //canvas that gives the player feedback on what they have done in the Pro Interview tool
    public GameObject feedbackCanvas;
    public GameObject scoreCanvas;

    public GameObject rankingCanvas;
    public TextMeshProUGUI statementText;

    [SerializeField]
    private float typingSpeed;
    public GameObject continueButton;

    //themes from selection, used to disabled each button
    public Button theme1Button;
    public Button theme2Button;
    public Button theme3Button;
    public Button theme4Button;
    public Button theme5Button;
    public Button theme6Button;
    public Button theme7Button;
    public Button theme8Button;
    public Button theme9Button;
    public Button theme10Button;

    //each time a continue button is pressed the counter goes down
    public int interviewCounter;
    public int secondCounter;

    private bool statement1Selected = false;
    private bool statement2Selected = false;
    private bool statement3Selected = false;
    private bool statement4Selected = false;

    private bool selected = false;

    //PlayerPrefs
    //public string proInterview = "ProInterview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

    public AudioClip backgroundClip;
    public AudioSource backgroundSource;

    //Collecting Data through Google Forms
    public InputField inputEmail, input1, input2, input3;
    private string emailAnswer, selection1Answer, selection2Answer, selection3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScXIGajYafdSBbVGReI6CHkUDH2IQPjqjmOSc-sIA5g7P-a0Q/formResponse";

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

        backgroundSource.clip = backgroundClip;
        backgroundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
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
            themeSelectionCanvas.SetActive(false);

            scoreCanvas.SetActive(true);
            feedbackCanvas.SetActive(true);
            //themeSelectionContinueButton.SetActive(true);
        }
    }

    //Used for individual demos of the tool
    /*public void ExitGame() {
        Application.Quit();
    }*/

    public void ResetPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

    public void DisplayThemeDefinitions() {
        themeDefinitionCanvas.SetActive(true);
    }

    public void RemoveThemeDefinitions() {
        themeDefinitionCanvas.SetActive(false);
    }

    public void ReturnToMobileWorkplace() {
        SceneManager.LoadScene("ImmigrationJournalist"); //REMEMBER TO CHANGE EFFECTIVELY
    }

    public void RankedStatements() {
        rankingCanvas.SetActive(false);
        themeSelectionCanvas.SetActive(true);

        secondCounter--;
    }

    public void ScoreAndFeedback() {
        themeSelectionCanvas.SetActive(false);

        scoreCanvas.SetActive(true);
        feedbackCanvas.SetActive(true);
    }

    public void CounterDown() {
        interviewCounter--;
        Debug.Log(interviewCounter);
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            animText.SetTrigger("Change");
            textDisplay.text += letter; //letter by letter type animation of the text, more animations can be added via the Animate tab
            
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //this will be called from the PLAY button
    //attach one of the first three issue for the inspector shouldn't matter which one you put in
    public void QuestionsAppear() {
        startCanvas.SetActive(false);
        themeSelectionCanvas.SetActive(true);
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

    //Social, Environment, Rights & Responsibilities, Safety & Security, Emotions,
    //Economy, Political, History, Culture, Geography
    public void Theme1() {
        theme1Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        //interviewCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void Theme1Selected() {
        //Social
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "It is very important to maintain social conhesion. Emigrants will definitely contribute to solving the demographic problem in Europe.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "It is very important to maintain social conhesion. Emigrants will definitely contribute to solving the demographic problem in Europe.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "It is very important to maintain social conhesion. Emigrants will definitely contribute to solving the demographic problem in Europe.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Theme2() {
        //Environment
        theme2Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        //interviewCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void Theme2Selected() {
        //Environment
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "[NO STATEMENT IS HERE]");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Environment";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "[NO STATEMENT IS HERE]");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Environment";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "[NO STATEMENT IS HERE]");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Environment";
        }
    }

    public void Theme3() {
        //Rights & Responsibilities
        theme3Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme3Selected() {
        //Rights & Responsibilities
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The great majority of migrants are cooperative, follow the rules and accept that we have their best interests at heart.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "The great majority of migrants are cooperative, follow the rules and accept that we have their best interests at heart.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "The great majority of migrants are cooperative, follow the rules and accept that we have their best interests at heart.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Rights & Responsibilities";
        }
    }

    public void Theme4() {
        //Security
        theme4Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme4Selected() {
        //Security
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU has kept the peace for 40 years. That is not to be sneered at.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Security";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "The EU has kept the peace for 40 years. That is not to be sneered at.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Security";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "The EU has kept the peace for 40 years. That is not to be sneered at.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Security";
        }
    }

    public void Theme5() {
        //Emotions
        theme5Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme5Selected() {
        //Emotions
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "I'm proud that Europe is welcoming to those who have to leave in search of safety and a better life.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Emotions";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "I'm proud that Europe is welcoming to those who have to leave in search of safety and a better life.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Emotions";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "I'm proud that Europe is welcoming to those who have to leave in search of safety and a better life.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Emotions";
        }
    }

    public void Theme6() {
        //Economic
        theme6Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme6Selected() {
        //Economic
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "Migration really boosts our economy. Migrant workers contribute at all levels of our society, from cleaners and workers to scientists and doctors.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Economic";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "Migration really boosts our economy. Migrant workers contribute at all levels of our society, from cleaners and workers to scientists and doctors.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Economic";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "Migration really boosts our economy. Migrant workers contribute at all levels of our society, from cleaners and workers to scientists and doctors.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Economic";
        }
    }

    public void Theme7() {
        //Political
        theme7Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme7Selected() {
        //Political
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The way to keep our country great is to remain part of Europe and allow free movement of people across borders.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Political";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "The way to keep our country great is to remain part of Europe and allow free movement of people across borders.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Political";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "The way to keep our country great is to remain part of Europe and allow free movement of people across borders.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Political";
        }
    }

    public void Theme8() {
        //Historic
        theme8Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme8Selected() {
        //Historic
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "History says that change was the lever of growth for European countries; and migration has been part of that change for centuries.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Historic";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "History says that change was the lever of growth for European countries; and migration has been part of that change for centuries.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Historic";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "History says that change was the lever of growth for European countries; and migration has been part of that change for centuries.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Historic";
        }
    }

    public void Theme9() {
        //Culture
        theme9Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme9Selected() {
        //Culture
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "Immigrants should understand and share the common cultural heritage of the EU and the country they are staying in.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Culture";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "Immigrants should understand and share the common cultural heritage of the EU and the country they are staying in.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Culture";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "Immigrants should understand and share the common cultural heritage of the EU and the country they are staying in.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Culture";
        }
    }

    public void Theme10() {
        //Geography
        theme10Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme10Selected() {
        //Geography
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "My generation has really benefitted from the freedom of the people to travel, study and work throughout EU member states.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            input1.text = "Geography";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "My generation has really benefitted from the freedom of the people to travel, study and work throughout EU member states.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            input2.text = "Geography";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "My generation has really benefitted from the freedom of the people to travel, study and work throughout EU member states.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            input3.text = "Geography";
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

    IEnumerator Post(string emailAnswer, string selection1, string selection2, string selection3) {
        WWWForm form = new WWWForm();

        form.AddField("entry.865840549", emailAnswer);
        form.AddField("entry.989218689", selection1);
        form.AddField("entry.870223860", selection2);
        form.AddField("entry.1404101062", selection3);

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

        StartCoroutine(Post(emailAnswer, selection1Answer, selection2Answer, selection3Answer));
    }
}

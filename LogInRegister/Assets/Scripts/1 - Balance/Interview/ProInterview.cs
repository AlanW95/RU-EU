using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ProInterview : MonoBehaviour {
    //initial starting canvas
    public GameObject startCanvas;

    //after START is selected from the Start Canvas, this canvas will appear
    public GameObject themeSelectionCanvas;
    public GameObject themeSelectionContinueButton;
    public GameObject themeDefinitionCanvas;

    public GameObject remainerCanvas;

    public TextMeshProUGUI textDisplay;
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
    public Button socialButton;
    public Button environmentButton;
    public Button civilButton;
    public Button safetySecurityButton;
    public Button emotionalButton;
    public Button economicButton;
    public Button politicalButton;
    public Button historicButton;
    public Button cultureButton;
    public Button geographyButton;

    //each time a continue button is pressed the counter goes down
    public int interviewCounter;
    public int secondCounter;

    private bool statement1Selected = false;
    private bool statement2Selected = false;
    private bool statement3Selected = false;
    private bool statement4Selected = false;

    //PlayerPrefs
    //public string proInterview = "ProInterview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

    // Start is called before the first frame update
    void Start() {
        startCanvas.SetActive(true);

        scoreCanvas.SetActive(false);
        rankingCanvas.SetActive(false);
        feedbackCanvas.SetActive(false);

        interviewCounter = 10;
        secondCounter = 4;

        FloatingTextController.Initialize();
    }

    // Update is called once per frame
    void Update() {

        if (textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }

        if (interviewCounter <= 0) {
            //give feedback
            //textDisplay.text = "Sorry but I must dash now, that is all I have time for.";
            Debug.Log("You have asked 4 questions!");

            rankingCanvas.SetActive(true);
        }

        if (secondCounter <= 0)
        {
            Debug.Log("You have answered 4 questions! If you wish, you may proceed and collect more statements but this will not affect your score.");
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

    public void DisplayThemeDefinitions()
    {
        themeDefinitionCanvas.SetActive(true);
    }

    public void RemoveThemeDefinitions()
    {
        themeDefinitionCanvas.SetActive(false);
    }

    public void ReturnToMobileWorkplace() {
        SceneManager.LoadScene("Journalist");
    }

    public void RankedStatements()
    {
        rankingCanvas.SetActive(false);
        themeSelectionCanvas.SetActive(true);

        secondCounter -= 1;
    }

    public void ScoreAndFeedback()
    {
        themeSelectionCanvas.SetActive(false);

        scoreCanvas.SetActive(true);
        feedbackCanvas.SetActive(true);
        //chosenTextDisplay.text = PlayerPrefs.GetString("ProInterview1");
        /*Debug.Log(PlayerPrefs.GetString("ProInterview1").ToString());
        Debug.Log(PlayerPrefs.GetString("ProInterview2").ToString());
        Debug.Log(PlayerPrefs.GetString("ProInterview3").ToString());*/
    }

    public void CounterDown() {
        interviewCounter--;
        Debug.Log(interviewCounter);
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter; //letter by letter type animation of the text, more animations can be added via the Animate tab

            //Setting of PlayerPrefs----------------------------
            //PlayerPrefs.SetString("ProInterview", sentences[index]);
            //------------------------------------------------
            
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //this will be called from the PLAY button
    //attach one of the first three issue for the inspector shouldn't matter which one you put in
    public void QuestionsAppear() {
        startCanvas.SetActive(false);
        themeSelectionCanvas.SetActive(true);
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

            remainerCanvas.SetActive(false);

            rankingCanvas.SetActive(true);
            //statementText.text = PlayerPrefs.GetString("ProInterviewStatementSelection", proInterviewStatements);
        }
    }
    
    public void Social() {
        socialButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        //interviewCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview10", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Environment() {
        environmentButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Civil() {
        civilButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void SafetySecurity() {
        safetySecurityButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Emotional() {
        emotionalButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Economic() {
        economicButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Political() {
        politicalButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());

    }

    public void Historic() {
        historicButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Culture() {
        cultureButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Geography() {
        geographyButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //interviewCounter--;
        secondCounter--;
        statement1Selected = false;

        if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview1", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview2", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview3", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ProInterview4", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview4"));
            statement4Selected = true;
        }

        /*if (interviewCounter == 5) {
            PlayerPrefs.SetString("ProInterview5", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ProInterview6", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ProInterview7", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ProInterview8", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ProInterview9", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ProInterview1", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ProInterview10"));
        }*/

        StartCoroutine(Type());
    }
}

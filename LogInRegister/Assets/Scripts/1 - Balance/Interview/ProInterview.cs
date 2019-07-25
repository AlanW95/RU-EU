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

    //PlayerPrefs
    public string proInterview = "ProInterview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

    // Start is called before the first frame update
    void Start() {
        startCanvas.SetActive(true);

        scoreCanvas.SetActive(false);
        rankingCanvas.SetActive(false);
        feedbackCanvas.SetActive(false);

        interviewCounter = 10;
        secondCounter = 3;

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
            Debug.Log("You have asked 3 questions!");

            rankingCanvas.SetActive(true);
        }

        if (secondCounter <= 0)
        {
            Debug.Log("You have answered 3 questions! If you wish, you may proceed and collect more statements but this will not affect your score.");
            themeSelectionContinueButton.SetActive(true);
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
        chosenTextDisplay.text = PlayerPrefs.GetString(proInterview);
        Debug.Log(PlayerPrefs.GetString(proInterview).ToString());
    }

    public void CounterDown() {
        interviewCounter--;
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter; //letter by letter type animation of the text, more animations can be added via the Animate tab

            //Setting of PlayerPrefs----------------------------
            PlayerPrefs.SetString(proInterview, sentences[index]);
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

        //interviewCounter--;
        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "Freedom of movement has helped to create a much richer and more diverse society.");
        }

        StartCoroutine(Type());
    }

    public void Environment() {
        environmentButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "The EU has introduced very effective standard for caring for the environment.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "The EU has introduced very effective standard for caring for the environment.");
        }

        StartCoroutine(Type());
    }

    public void Civil() {
        civilButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
        }

        StartCoroutine(Type());
    }

    public void SafetySecurity() {
        safetySecurityButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "The EU provides rigorous standards for defending the safety and security of the country.");
        }

        StartCoroutine(Type());
    }

    public void Emotional() {
        emotionalButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "I would be absolutely devastated if my country voted to leave the EU.");
        }

        StartCoroutine(Type());
    }

    public void Economic() {
        economicButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "Being a member of the EU has had a huge positive impact on the economy of our country.");
        }

        StartCoroutine(Type());
    }

    public void Political() {
        politicalButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "The 4 freedoms of the EU have been beneficial for our country.");
        }

        StartCoroutine(Type());

    }

    public void Historic() {
        historicButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
        }

        StartCoroutine(Type());
    }

    public void Culture() {
        cultureButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "The EU has helped to create a shared cultural identity.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "The EU has helped to create a shared cultural identity.");
        }

        StartCoroutine(Type());
    }

    public void Geography() {
        geographyButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        if (interviewCounter == 9) {
            PlayerPrefs.SetString(proInterview + 1, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 8) {
            PlayerPrefs.SetString(proInterview + 2, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 7) {
            PlayerPrefs.SetString(proInterview + 3, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 6) {
            PlayerPrefs.SetString(proInterview + 4, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString(proInterview + 5, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString(proInterview + 6, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString(proInterview + 7, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString(proInterview + 8, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString(proInterview + 9, "European identity means that where you are born does not matter.");
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString(proInterview + 10, "European identity means that where you are born does not matter.");
        }

        StartCoroutine(Type());
    }
}

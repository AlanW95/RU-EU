using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AntiInterview : MonoBehaviour {
    //initial starting canvas
    public GameObject startCanvas;

    //after START is selected from the Start Canvas, this canvas will appear
    public GameObject themeSelectionCanvas;
    public GameObject themeSelectionContinueButton;
    public GameObject themeDefinitionCanvas;

    public GameObject leaverCanvas;

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

    private bool selected = false;

    //PlayerPrefs
    //public string proInterview = "ProInterview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

    public AudioClip backgroundClip;
    public AudioSource backgroundSource;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);

        scoreCanvas.SetActive(false);
        rankingCanvas.SetActive(false);
        feedbackCanvas.SetActive(false);

        interviewCounter = 8;
        secondCounter = 4;

        FloatingTextController.Initialize();

        backgroundSource.clip = backgroundClip;
        backgroundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }

        if (interviewCounter <= 0) {
            //give feedback
            //textDisplay.text = "Sorry but I must dash now, that is all I have time for.";
            Debug.Log("You have asked 4 questions!");

            rankingCanvas.SetActive(true);
        }

        if (secondCounter <= 0) {
            Debug.Log("You have answered 4 questions! If you wish, you may proceed and collect more statements but this will not affect your score.");
            themeSelectionCanvas.SetActive(false);

            scoreCanvas.SetActive(true);
            feedbackCanvas.SetActive(true);
            //themeSelectionContinueButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Journalist");
        }
    }

    public void ResetPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

    //Used for individual demos of the tool
    /*public void ExitGame() {
        Application.Quit();
    }*/

    public void DisplayThemeDefinitions() {
        themeDefinitionCanvas.SetActive(true);
    }

    public void RemoveThemeDefinitions() {
        themeDefinitionCanvas.SetActive(false);
    }

    public void ReturnToMobileWorkplace() {
        SceneManager.LoadScene("Journalist");
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
    }

    public void NextSentence() {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1) {
            Debug.Log("Button has been pressed");
            index++;
            textDisplay.text = "";

            startCanvas.SetActive(false);
            rankingCanvas.SetActive(false);

            StartCoroutine(Type());

        } else { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);

            leaverCanvas.SetActive(false);

            rankingCanvas.SetActive(true);
        }
    }

    public void Social() {
        socialButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        //interviewCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void SocialSelected() {
        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void Environment() {
        environmentButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void EnvironmentSelected() {
        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void Civil() {
        civilButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void RightsResponsibilitiesSelected() {

        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void SafetySecurity() {
        safetySecurityButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void SafetySecuritySelected() {

        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void Emotional() {
        emotionalButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void EmotionalSelected() {
        
        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void Economic() {
        economicButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void EconomicSelected() {
        
        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void Political() {
        politicalButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void PoliticalSelected() {
        
        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void Historic() {
        historicButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void HistoricSelected() {
        
        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURHT ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void Culture() {
        cultureButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void CultureSelected() {
        
        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }

    public void Geography() {
        geographyButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        leaverCanvas.SetActive(true);

        //interviewCounter--;
        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void GeographySelected() {
        
        if (interviewCounter == 7) {
            Debug.Log("I AM THE FIRST ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview1", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview1"));
        }

        if (interviewCounter == 6) {
            Debug.Log("I AM THE SECOND ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview2", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview2"));
        }

        if (interviewCounter == 5) {
            Debug.Log("I AM THE THIRD ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview3", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview3"));
        }

        if (interviewCounter == 4) {
            Debug.Log("I AM THE FOURTH ONE!");
            PlayerPrefs.SetString("BrexitAntiInterview4", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("BrexitAntiInterview4"));
        }
    }
}

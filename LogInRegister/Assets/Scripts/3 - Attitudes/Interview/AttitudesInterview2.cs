using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AttitudesInterview2 : MonoBehaviour {
    //random comment code

    //initial starting canvas
    public GameObject startCanvas;

    //after START is selected from the Start Canvas, this canvas will appear
    public GameObject themeSelectionCanvas;
    public GameObject themeSelectionContinueButton;
    public GameObject themeDefinitionCanvas;

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
    public Button theme1Button;
    public Button theme2Button;
    public Button theme3Button;
    public Button theme4Button;
    public Button theme5Button;
    public Button theme6Button;
    public Button theme7Button;
    public Button theme8Button;
    /*public Button theme9Button;
    public Button theme10Button;*/

    //each time a continue button is pressed the counter goes down
    public int interviewCounter;
    public int secondCounter;

    private bool statement1Selected = false;
    private bool statement2Selected = false;
    private bool statement3Selected = false;
     

    private bool selected = false;

    //PlayerPrefs
    public string antiInterview = "AntiInterview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

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
       // index = Random.Range(0, sentences.Length);
    }

    // Update is called once per frame
    void Update()
    {
        index = Random.Range(0, sentences.Length);
        Debug.Log("InterviewCounter: " + interviewCounter.ToString());

        Debug.Log("SecondCounter: " + secondCounter.ToString());
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

        if (interviewCounter <= 0) {
            //give feedback
            //textDisplay.text = "Sorry but I must dash now, that is all I have time for.";
            Debug.Log("You have asked 3 questions!");

            rankingCanvas.SetActive(true);
        }

        if (secondCounter == 0) {
            Debug.Log("You have answered 3 questions! If you wish, you may proceed and collect more statements but this will not affect your score.");
            themeSelectionCanvas.SetActive(false);
            scoreCanvas.SetActive(true);
            feedbackCanvas.SetActive(true);
            
        }


        //if (Input.GetKeyDown(KeyCode.Escape)) {
        /*   SceneManager.LoadScene("AttitudesMobileWorkplace");
       }*/
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
        SceneManager.LoadScene("AttitudesMobileWorkplace");
    }

    public void RankedStatements() {
        rankingCanvas.SetActive(false);
        themeSelectionCanvas.SetActive(true);

        secondCounter --;
    }

    public void ScoreAndFeedback() {
        themeSelectionCanvas.SetActive(false);

        scoreCanvas.SetActive(true);
        feedbackCanvas.SetActive(true);
        //chosenTextDisplay.text = PlayerPrefs.GetString(antiInterview);
        /*Debug.Log(PlayerPrefs.GetString(antiInterview).ToString());*/
    }

    public void CounterDown() {
        interviewCounter--;
        Debug.Log("Interview Counter: " + interviewCounter);
       
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {   //sentences[index = Random.Range(0, 2)].ToCharArray()) {   //random item of array
            textDisplay.text += letter; //letter by letter type animation of the text, more animations can be added via the Animate tab

            //Setting of PlayerPrefs----------------------------
            PlayerPrefs.SetString(antiInterview, sentences[index]);
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
           // index++;
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
            //statementText.text = PlayerPrefs.GetString("ProInterviewStatementSelection", proInterviewStatements);
        }
    }

    public void Theme1() {
        theme1Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Theme1Selected()
    {
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("AttitudesInterview2-1", "Peoples perception of EU is mostly dominated by the media portrayal of the EU laws and European directives.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-1"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "Peoples perception of EU is mostly dominated by the media portrayal of the EU laws and European directives.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "Peoples perception of EU is mostly dominated by the media portrayal of the EU laws and European directives.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
        }
    }

    public void Theme2() {
        theme2Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;
        StartCoroutine(Type());
    }

    public void Theme2Selected()
    {
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("AttitudesInterview2-1", "Europe is a rather stable part compared with the rest of the world with higher living standards and peace in the region.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-1"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "Europe is a rather stable part compared with the rest of the world with higher living standards and peace in the region.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "Europe is a rather stable part compared with the rest of the world with higher living standards and peace in the region.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
        }
    }
    public void Theme3() {
        theme3Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;
        StartCoroutine(Type());
    }

    public void Theme3Selected()
    {
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("AttitudesInterview2-1", "It is a big issue to find a balance between a member state's laws and EU laws.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-1"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "It is a big issue to find a balance between a member state's laws and EU laws.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "It is a big issue to find a balance between a member state's laws and EU laws.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
        }
    }
    public void Theme4() {
        theme4Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;
        StartCoroutine(Type());
    }

    public void Theme4Selected()
    {
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("AttitudesInterview2-1", "All European countried should be subjected to development and be recognized along with their individuality.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-1"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "All European countried should be subjected to development and be recognized along with their individuality.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "All European countried should be subjected to development and be recognized along with their individuality.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
        }
    }

    public void Theme5() {
        theme5Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Theme5Selected()
    {
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("AttitudesInterview2-1", "Brexit has strengthened the sense of European identity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-1"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "Brexit has strengthened the sense of European identity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "Brexit has strengthened the sense of European identity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
        }
    }

    public void Theme6() {
        theme6Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Theme6Selected()
    {
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("AttitudesInterview2-1", "EU citizens and the EU institutions need to get a better idea of what EU really is and why it is important.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-1"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "EU citizens and the EU institutions need to get a better idea of what EU really is and why it is important.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "EU citizens and the EU institutions need to get a better idea of what EU really is and why it is important.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
        }
    }
    public void Theme7() {
        theme7Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        statement1Selected = false;

        StartCoroutine(Type());

    }

    public void Theme7Selected()
    {
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("AttitudesInterview2-1", "EU being a practical entiry and the practical implementations of EU are two different things.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-1"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "EU being a practical entiry and the practical implementations of EU are two different things.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "EU being a practical entiry and the practical implementations of EU are two different things.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
        }
    }

    public void Theme8() {
        theme8Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        statement1Selected = false;

        StartCoroutine(Type());
    }

    public void Theme8Selected()
    {
        if (interviewCounter == 5) {
            PlayerPrefs.SetString("AttitudesInterview2-1", "EU gives the freedom to act internationally and gain international understanding.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-1"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "EU gives the freedom to act internationally and gain international understanding.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "EU gives the freedom to act internationally and gain international understanding.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
        }
    }
}

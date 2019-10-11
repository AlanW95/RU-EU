using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DirectorInterview : MonoBehaviour
{
    //initial starting canvas
    public GameObject startCanvas;

    //after START is selected from the Start Canvas, this canvas will appear
    public GameObject themeSelectionCanvas;
    public GameObject themeSelectionContinueButton;
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
    public Button question1Button, question2Button, question3Button, question4Button, question5Button, question6Button, question7Button, question8Button,
                  question9Button, question10Button, question11Button, question12Button, question13Button, question14Button, question15Button;

    //each time a continue button is pressed the counter goes down
    public int interviewCounter;
    public int secondCounter;

    //PlayerPrefs
    public string directorInterview = "DirectorInterview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

    public Animator animText;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);

        scoreCanvas.SetActive(false);
        rankingCanvas.SetActive(false);
        feedbackCanvas.SetActive(false);

        interviewCounter = 10;
        secondCounter = 3;
    }

    // Update is called once per frame
    void Update()
    {
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
            themeSelectionContinueButton.SetActive(true);
        }
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
        SceneManager.LoadScene("Journalist");
    }

    public void RankedStatements() {
        rankingCanvas.SetActive(false);
        themeSelectionCanvas.SetActive(true);

        secondCounter -= 1;
    }

    public void ScoreAndFeedback() {
        themeSelectionCanvas.SetActive(false);

        scoreCanvas.SetActive(true);
        feedbackCanvas.SetActive(true);
        chosenTextDisplay.text = PlayerPrefs.GetString(directorInterview);
        Debug.Log(PlayerPrefs.GetString(directorInterview).ToString());
    }

    public void CounterDown() {
        interviewCounter--;
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter; //letter by letter type animation of the text, more animations can be added via the Animate tab

            //Setting of PlayerPrefs----------------------------
            PlayerPrefs.SetString(directorInterview, sentences[index]);
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

            animText.SetTrigger("Change");

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

    public void Question1() {
        question1Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question2() {
        question2Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question3() {
        question3Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question4() {
        question4Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question5() {
        question5Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question6() {
        question6Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question7() {
        question7Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());

    }

    public void Question8() {
        question8Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question9() {
        question9Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question10() {
        question10Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question11() {
        question11Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question12() {
        question12Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question13() {
        question13Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question14() {
        question14Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question15() {
        question15Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }
}

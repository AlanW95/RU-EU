using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ImmigrationInterview1 : MonoBehaviour
{
    //Pro Sided Interview for Immigration scenario.

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

    //PlayerPrefs
    //public string proInterview = "ProInterview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);

        scoreCanvas.SetActive(false);
        rankingCanvas.SetActive(false);
        feedbackCanvas.SetActive(false);

        interviewCounter = 10;
        secondCounter = 4;

        FloatingTextController.Initialize();
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
        //chosenTextDisplay.text = PlayerPrefs.GetString("ImmigrationProInterview1");
        /*Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1").ToString());
        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2").ToString());
        Debug.Log(PlayerPrefs.GetString("ImmigrationImmigrationProInterview3").ToString());*/
    }

    public void CounterDown() {
        interviewCounter--;
        Debug.Log(interviewCounter);
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter; //letter by letter type animation of the text, more animations can be added via the Animate tab

            //Setting of PlayerPrefs----------------------------
            //PlayerPrefs.SetString("ImmigrationProInterview", sentences[index]);
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

        //secondCounter--;
        //interviewCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationIProInterview2", "Freedom of movement has helped to create a much richer and more diverse society.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "Freedom of movement has helped to create a much richer and more diverse society.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "Freedom of movement has helped to create a much richer and more diverse society.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview10", "Freedom of movement has helped to create a much richer and more diverse society.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Theme2() {
        theme2Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "The EU has introduced very effective standard for caring for the environment.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "The EU has introduced very effective standard for caring for the environment.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "The EU has introduced very effective standard for caring for the environment.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /* (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU has introduced very effective standard for caring for the environment.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Theme3() {
        theme3Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU provides rigorous standards for fair treatment and EU citizens really appreciate that.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Theme4() {
        theme4Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "The EU provides rigorous standards for defending the safety and security of the country.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "The EU provides rigorous standards for defending the safety and security of the country.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "The EU provides rigorous standards for defending the safety and security of the country.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU provides rigorous standards for defending the safety and security of the country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Theme5() {
        theme5Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "I would be absolutely devastated if my country voted to leave the EU.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "I would be absolutely devastated if my country voted to leave the EU.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "I would be absolutely devastated if my country voted to leave the EU.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "I would be absolutely devastated if my country voted to leave the EU.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Theme6() {
        theme6Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "Being a member of the EU has had a huge positive impact on the economy of our country.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "Being a member of the EU has had a huge positive impact on the economy of our country.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "Being a member of the EU has had a huge positive impact on the economy of our country.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "Being a member of the EU has had a huge positive impact on the economy of our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Theme7() {
        theme7Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "The 4 freedoms of the EU have been beneficial for our country.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "The 4 freedoms of the EU have been beneficial for our country.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "The 4 freedoms of the EU have been beneficial for our country.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The 4 freedoms of the EU have been beneficial for our country.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());

    }

    public void Theme8() {
        theme8Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "For all of us Europeans - our shared history matters. We do not want to repeat the mistakes of the past.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Theme9() {
        theme9Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "The EU has helped to create a shared cultural identity.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "The EU has helped to create a shared cultural identity.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "The EU has helped to create a shared cultural identity.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "The EU has helped to create a shared cultural identity.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }

    public void Theme10() {
        theme10Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        //interviewCounter--;
        //secondCounter--;
        statement1Selected = false;

        if (!PlayerPrefs.HasKey("ImmigrationProInterview1")) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            PlayerPrefs.Save();
        }
        else {
            if (!PlayerPrefs.HasKey("ImmigrationProInterview2")) {
                PlayerPrefs.SetString("ImmigrationProInterview2", "European identity means that where you are born does not matter.");
                Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
                PlayerPrefs.Save();
            }
            else {
                if (!PlayerPrefs.HasKey("ImmigrationProInterview3")) {
                    PlayerPrefs.SetString("ImmigrationProInterview3", "European identity means that where you are born does not matter.");
                    Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
                    PlayerPrefs.Save();
                }
                else {
                    if (!PlayerPrefs.HasKey("ImmigrationProInterview4")) {
                        PlayerPrefs.SetString("ImmigrationProInterview4", "European identity means that where you are born does not matter.");
                        Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
                        PlayerPrefs.Save();
                    }
                }
            }
        }

        /*if (interviewCounter == 9 && secondCounter == 3 && statement1Selected == false && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview1"));
            statement1Selected = true;
        }

        if (interviewCounter == 8 && secondCounter == 2 && statement1Selected == true && statement2Selected == false && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview2", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview2"));
            statement2Selected = true;
        }

        if (interviewCounter == 7 && secondCounter == 1 && statement1Selected == true && statement2Selected == true && statement3Selected == false && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview3", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview3"));
            statement3Selected = true;
        }

        if (interviewCounter == 6 && secondCounter == 0 && statement1Selected == true && statement2Selected == true && statement3Selected == true && statement4Selected == false) {
            PlayerPrefs.SetString("ImmigrationProInterview4", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview4"));
            statement4Selected = true;
        }

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("ImmigrationProInterview5", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview5"));
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("ImmigrationProInterview6", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview6"));
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("ImmigrationProInterview7", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview7"));
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("ImmigrationProInterview8", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview8"));
        }

        if (interviewCounter == 1) {
            PlayerPrefs.SetString("ImmigrationProInterview9", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview9"));
        }

        if (interviewCounter == 0) {
            PlayerPrefs.SetString("ImmigrationProInterview1", "European identity means that where you are born does not matter.");
            Debug.Log(PlayerPrefs.GetString("ImmigrationProInterview10"));
        }*/

        StartCoroutine(Type());
    }
}

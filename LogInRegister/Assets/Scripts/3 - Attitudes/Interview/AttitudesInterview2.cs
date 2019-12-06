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

    public AudioClip backgroundClip;
    public AudioSource backgroundSource;

    //Data for Google Forms
    public InputField inputEmail, input1, input2, input3;
    private string emailAnswer, selection1Answer, selection2Answer, selection3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdTgYaKzYVObfF5Divl52bMFIDrBbY6AOW3o7HOE6DuBbRiug/formResponse";

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

        backgroundSource.clip = backgroundClip;
        backgroundSource.Play();
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
            input1.text = "Social";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "Peoples perception of EU is mostly dominated by the media portrayal of the EU laws and European directives.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
            input2.text = "Social";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "Peoples perception of EU is mostly dominated by the media portrayal of the EU laws and European directives.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
            input3.text = "Social";
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
            input1.text = "Safety & Security";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "Europe is a rather stable part compared with the rest of the world with higher living standards and peace in the region.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
            input2.text = "Safety & Security";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "Europe is a rather stable part compared with the rest of the world with higher living standards and peace in the region.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
            input3.text = "Safety & Security";
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
            input1.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "It is a big issue to find a balance between a member state's laws and EU laws.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
            input2.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "It is a big issue to find a balance between a member state's laws and EU laws.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
            input3.text = "Rights & Responsibilities";
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
            input1.text = "Economic";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "All European countried should be subjected to development and be recognized along with their individuality.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
            input2.text = "Economic";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "All European countried should be subjected to development and be recognized along with their individuality.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
            input3.text = "Economic";
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
            input1.text = "Emotional";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "Brexit has strengthened the sense of European identity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
            input2.text = "Emotional";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "Brexit has strengthened the sense of European identity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
            input3.text = "Emotional";
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
            input1.text = "Historic";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "EU citizens and the EU institutions need to get a better idea of what EU really is and why it is important.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
            input2.text = "Historic";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "EU citizens and the EU institutions need to get a better idea of what EU really is and why it is important.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
            input3.text = "Historic";
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
            input1.text = "Political";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "EU being a practical entiry and the practical implementations of EU are two different things.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
            input2.text = "Political";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "EU being a practical entiry and the practical implementations of EU are two different things.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
            input3.text = "Political";
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
            input1.text = "Culture";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("AttitudesInterview2-2", "EU gives the freedom to act internationally and gain international understanding.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-2"));
            input2.text = "Culture";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("AttitudesInterview2-3", "EU gives the freedom to act internationally and gain international understanding.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview2-3"));
            input3.text = "Culture";
        }
    }

    int boolToInt(bool val) {
        if (val) {
            return 1;
        } else {
            return 0;
        }
    }

    bool intToBool(int val) {
        if (val != 0) {
            return true;
        } else {
            return false;
        }
    }

    IEnumerator Post(string emailAnswer, string selection1, string selection2, string selection3) {
        WWWForm form = new WWWForm();

        form.AddField("entry.2100924704", emailAnswer);
        form.AddField("entry.1710400999", selection1);
        form.AddField("entry.360859262", selection2);
        form.AddField("entry.1588982335", selection3);

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
    }
}

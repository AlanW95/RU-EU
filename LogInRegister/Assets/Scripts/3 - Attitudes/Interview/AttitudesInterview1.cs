using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class AttitudesInterview1 : MonoBehaviour
{
    private bool interview1Completed;

    //random comment code

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
    private string currentIndexSentence;

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
    public string proInterview = "ProInterview";
    //public static string proInterviewStatements;
    public TextMeshProUGUI chosenTextDisplay;

    public AudioClip backgroundClip;
    public AudioSource backgroundSource;

    //Collecting Data through Google Forms
    public InputField inputEmail, input1, input2, input3;
    private string emailAnswer, selection1Answer, selection2Answer, selection3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdAnkWdOzmQJ_4XGyuhOJ7GBnCPHnm4mUHi2cZABSn2iwFeHA/formResponse";

    // Start is called before the first frame update
    void Awake()
    {
        Random.seed = System.DateTime.Now.Millisecond;
    }//
    void Start()
    {
        startCanvas.SetActive(true);

        scoreCanvas.SetActive(false);
        rankingCanvas.SetActive(false);
        feedbackCanvas.SetActive(false);

        interviewCounter = 6;
        secondCounter = 3;
        //Random.seed = System.DateTime.Now.Millisecond;
        index = Random.Range(0, sentences.Length);
        Debug.Log("index" + index.ToString());
        //currentIndexSentence = sentences[index];
        FloatingTextController.Initialize();

        backgroundSource.clip = backgroundClip;
        backgroundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("CurrentAttitudesSocialScore");
        PlayerPrefs.GetInt("CurrentAttitudesEnvironmentScore");
        PlayerPrefs.GetInt("CurrentAttitudesRightsResponsibilitiesScore");
        PlayerPrefs.GetInt("CurrentAttitudesSafetyAndSecurityScore");
        PlayerPrefs.GetInt("CurrentAttitudesEmotionalScore");
        PlayerPrefs.GetInt("CurrentAttitudesEconomyScore");
        PlayerPrefs.GetInt("CurrentAttitudesPoliticalScore");
        PlayerPrefs.GetInt("CurrentAttitudesHistoricScore");
        PlayerPrefs.GetInt("CurrentAttitudesCultureScore");
        PlayerPrefs.GetInt("CurrentAttitudesGeographyScore");

        //index = Random.Range(0, sentences.Length);

        //currentIndexSentence = sentences[index];

        Debug.Log("InterviewCounter: " + interviewCounter.ToString());

        Debug.Log("SecondCounter: " + secondCounter.ToString());


        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

        if (interviewCounter <= 0)
        {
            //give feedback
            //textDisplay.text = "Sorry but I must dash now, that is all I have time for.";
            Debug.Log("You have asked 3 questions!");

            rankingCanvas.SetActive(true);
        }

        if (secondCounter == 0)
        {
            Debug.Log("You have answered 3 questions! If you wish, you may proceed and collect more statements but this will not affect your score.");
            themeSelectionCanvas.SetActive(false);

            scoreCanvas.SetActive(true);
            feedbackCanvas.SetActive(true);
        }

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("AttitudesMobileWorkplace");
        }*/
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

    public void ReturnToMobileWorkplace()
    {
        SceneManager.LoadScene("AttitudesMobileWorkplace");
    }

    public void RankedStatements()
    {
        rankingCanvas.SetActive(false);
        themeSelectionCanvas.SetActive(true);

        secondCounter--;
    }

    public void ScoreAndFeedback()
    {
        themeSelectionCanvas.SetActive(false);

        scoreCanvas.SetActive(true);
        feedbackCanvas.SetActive(true);
        // chosenTextDisplay.text = PlayerPrefs.GetString(proInterview);
        // Debug.Log(PlayerPrefs.GetString(proInterview).ToString());
    }

    public void CounterDown()
    {
        interviewCounter--;
        Debug.Log("InterviewCounter:" + interviewCounter);
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {   //sentences[index = Random.Range(0, 2)].ToCharArray()) {   //random item of array
            textDisplay.text += letter; //letter by letter type animation of the text, more animations can be added via the Animate tab

            //Setting of PlayerPrefs----------------------------
            // PlayerPrefs.SetString(proInterview, sentences[index]);
            //------------------------------------------------

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //this will be called from the PLAY button
    //attach one of the first three issue for the inspector shouldn't matter which one you put in
    public void QuestionsAppear()
    {
        startCanvas.SetActive(false);
        themeSelectionCanvas.SetActive(true);

        inputEmail.text = PlayerPrefs.GetString("PlayerEmail");
    }

    public void NextSentence()
    {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            Debug.Log("Button has been pressed");
            // index++;
            //currentIndexSentence = sentences[index];
            textDisplay.text = "";

            startCanvas.SetActive(false); //start canvas kept appearing

            rankingCanvas.SetActive(false);

            StartCoroutine(Type());
        }
        else
        { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);

            interviewCanvas.SetActive(false);

            rankingCanvas.SetActive(true);
            //statementText.text = PlayerPrefs.GetString("ProInterviewStatementSelection", proInterviewStatements);
        }
    }

    public void Theme1()
    {
        theme1Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void Theme1Selected()
    {
        if (interviewCounter == 5)
        {
            PlayerPrefs.SetString("AttitudesInterview1-1", "Open borders makes it easy to plan and go on vacations and/or work.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4)
        {
            PlayerPrefs.SetString("AttitudesInterview1-2", "Open borders makes it easy to plan and go on vacations and/or work.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3)
        {
            PlayerPrefs.SetString("AttitudesInterview1-3", "Open borders makes it easy to plan and go on vacations and/or work.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Theme2()
    {
        theme2Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void Theme2Selected()
    {
        if (interviewCounter == 5)
        {
            PlayerPrefs.SetString("AttitudesInterview1-1", "Europe has done a lot for the respect for different nations but there are more possibilities to make things better in terms of stability and preservence of peace in the region.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-1"));
            input1.text = "Safety & Security";
        }

        if (interviewCounter == 4)
        {
            PlayerPrefs.SetString("AttitudesInterview1-2", "Europe has done a lot for the respect for different nations but there are more possibilities to make things better in terms of stability and preservence of peace in the region.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-2"));
            input2.text = "Safety & Security";
        }

        if (interviewCounter == 3)
        {
            PlayerPrefs.SetString("AttitudesInterview1-3", "Europe has done a lot for the respect for different nations but there are more possibilities to make things better in terms of stability and preservence of peace in the region.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-3"));
            input3.text = "Safety & Security";
        }
    }

    public void Theme3()
    {
        theme3Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void Theme3Selected()
    {
        if (interviewCounter == 5)
        {
            PlayerPrefs.SetString("AttitudesInterview1-1", "People feel less positive about EU because of the conservative and neoliberal policies.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-1"));
            input1.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 4)
        {
            PlayerPrefs.SetString("AttitudesInterview1-2", "People feel less positive about EU because of the conservative and neoliberal policies.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-2"));
            input2.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 3)
        {
            PlayerPrefs.SetString("AttitudesInterview1-3", "People feel less positive about EU because of the conservative and neoliberal policies.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-3"));
            input3.text = "Rights & Responsibilities";
        }
    }

    public void Theme4()
    {
        theme4Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme4Selected()
    {
        if (interviewCounter == 5)
        {
            PlayerPrefs.SetString("AttitudesInterview1-1", "It is absolutely important to have EU to economically thrive against other big economically powerful countries.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-1"));
            input1.text = "Economic";
        }

        if (interviewCounter == 4)
        {
            PlayerPrefs.SetString("AttitudesInterview1-2", "It is absolutely important to have EU to economically thrive against other big economically powerful countries.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-2"));
            input2.text = "Economic";
        }

        if (interviewCounter == 3)
        {
            PlayerPrefs.SetString("AttitudesInterview1-3", "It is absolutely important to have EU to economically thrive against other big economically powerful countries.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-3"));
            input3.text = "Economic";
        }
    }
    public void Theme5()
    {
        theme5Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void Theme5Selected()
    {
        if (interviewCounter == 5)
        {
            PlayerPrefs.SetString("AttitudesInterview1-1", "Perhaps Greeks do not feel European.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-1"));
            input1.text = "Emotional";
        }

        if (interviewCounter == 4)
        {
            PlayerPrefs.SetString("AttitudesInterview1-2", "Perhaps Greeks do not feel European.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-2"));
            input2.text = "Emotional";
        }

        if (interviewCounter == 3)
        {
            PlayerPrefs.SetString("AttitudesInterview1-3", "Perhaps Greeks do not feel European.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-3"));
            input3.text = "Emotional";
        }
    }

    public void Theme6()
    {
        theme6Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void Theme6Selected()
    {
        if (interviewCounter == 5)
        {
            PlayerPrefs.SetString("AttitudesInterview1-1", "Principles of the Enlightenment, French revolution and ancient Greek civilization with modern meanings are the main component of European identity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-1"));
            input1.text = "Historic";
        }

        if (interviewCounter == 4)
        {
            PlayerPrefs.SetString("AttitudesInterview1-2", "Principles of the Enlightenment, French revolution and ancient Greek civilization with modern meanings are the main component of European identity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-2"));
            input2.text = "Historic";
        }

        if (interviewCounter == 3)
        {
            PlayerPrefs.SetString("AttitudesInterview1-3", "Principles of the Enlightenment, French revolution and ancient Greek civilization with modern meanings are the main component of European identity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-3"));
            input3.text = "Historic";
        }
    }
    public void Theme7()
    {
        theme7Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());

    }
    public void Theme7Selected()
    {
        if (interviewCounter == 5)
        {
            PlayerPrefs.SetString("AttitudesInterview1-1", "Russia is conspiring against EU as they see the advantages of strength and unity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-1"));
            input1.text = "Political";
        }

        if (interviewCounter == 4)
        {
            PlayerPrefs.SetString("AttitudesInterview1-2", "Russia is conspiring against EU as they see the advantages of strength and unity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-2"));
            input2.text = "Political";
        }

        if (interviewCounter == 3)
        {
            PlayerPrefs.SetString("AttitudesInterview1-3", "Russia is conspiring against EU as they see the advantages of strength and unity.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-3"));
            input3.text = "Political";
        }
    }
    public void Theme8()
    {
        theme8Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }
    public void Theme8Selected()
    {
        if (interviewCounter == 5)
        {
            PlayerPrefs.SetString("AttitudesInterview1-1", "EU related initiatives has enormously enriched the life of a lot of students who has participated in different programs funded and hosted by the EU.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-1"));
            input1.text = "Culture";
        }

        if (interviewCounter == 4)
        {
            PlayerPrefs.SetString("AttitudesInterview1-2", "EU related initiatives has enormously enriched the life of a lot of students who has participated in different programs funded and hosted by the EU.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-2"));
            input2.text = "Culture";
        }

        if (interviewCounter == 3)
        {
            PlayerPrefs.SetString("AttitudesInterview1-3", "EU related initiatives has enormously enriched the life of a lot of students who has participated in different programs funded and hosted by the EU.");
            Debug.Log(PlayerPrefs.GetString("AttitudesInterview1-3"));
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

        form.AddField("entry.721828448", emailAnswer);
        form.AddField("entry.1025422201", selection1);
        form.AddField("entry.1209985452", selection2);
        form.AddField("entry.1181296085", selection3);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DirectorInterview : MonoBehaviour
{
    private bool interviewDirectorCompleted;

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

    public TextMeshProUGUI chosenTextDisplay;

    //public AudioClip backgroundClip;
    //public AudioSource backgroundSource;

    //Collecting Data through Google Forms
    public InputField inputEmail, input1, input2, input3;
    private string emailAnswer, selection1Answer, selection2Answer, selection3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSc7qubFOrHkBLccQG2cmZdkOcWmk0fNOUFqe84ovyucqDHY-Q/formResponse";

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
            //themeSelectionContinueButton.SetActive(true);
            themeSelectionCanvas.SetActive(false);

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

    public void Question1() {
        question1Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question1Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "Fine. Thanks.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Decoy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "Fine. Thanks.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Decoy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "Fine. Thanks.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Decoy";
            Debug.Log(input3.text);
        }
    }

    public void Question2() {
        question2Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question2Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "The number of controllers has diminished over the last years.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Rights & Responsibilities";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "The number of controllers has diminished over the last years.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Rights & Responsibilities";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "The number of controllers has diminished over the last years.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Rights & Responsibilities";
            Debug.Log(input3.text);
        }
    }

    public void Question3() {
        question3Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question3Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "You do everything you can to keep in line with the market. The rates that we can charge our clients are under severe pressure. It would be good if we could pay all drivers the Dutch collective agreement (CAO) wage. Then the customer will have to appreciate the profession of driver more.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "You do everything you can to keep in line with the market. The rates that we can charge our clients are under severe pressure. It would be good if we could pay all drivers the Dutch collective agreement (CAO) wage. Then the customer will have to appreciate the profession of driver more.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "You do everything you can to keep in line with the market. The rates that we can charge our clients are under severe pressure. It would be good if we could pay all drivers the Dutch collective agreement (CAO) wage. Then the customer will have to appreciate the profession of driver more.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Question4() {
        question4Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question4Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "We employ Lithuanian, Hungarian and Romanian drivers, some of them with academic training. They would receive a monthly salary of EUR 250-300 in a hospital in their own country. They are truck drivers because they earn as much as six times as much. They think that the job is an excellent escape.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Economy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "We employ Lithuanian, Hungarian and Romanian drivers, some of them with academic training. They would receive a monthly salary of EUR 250-300 in a hospital in their own country. They are truck drivers because they earn as much as six times as much. They think that the job is an excellent escape.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Economy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "We employ Lithuanian, Hungarian and Romanian drivers, some of them with academic training. They would receive a monthly salary of EUR 250-300 in a hospital in their own country. They are truck drivers because they earn as much as six times as much. They think that the job is an excellent escape.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Economy";
            Debug.Log(input3.text);
        }
    }

    public void Question5() {
        question5Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question5Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "I am the director of a Dutch transport company. It's a family business and we've been in business since 1981. My father tells me those were different times…");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Decoy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "I am the director of a Dutch transport company. It's a family business and we've been in business since 1981. My father tells me those were different times…");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Decoy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "I am the director of a Dutch transport company. It's a family business and we've been in business since 1981. My father tells me those were different times…");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Decoy";
            Debug.Log(input3.text);
        }
    }

    public void Question6() {
        question6Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question6Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "I can't answer that question. My company is here.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Decoy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "I can't answer that question. My company is here.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Decoy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "I can't answer that question. My company is here.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Decoy";
            Debug.Log(input3.text);
        }
    }

    public void Question7() {
        question7Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question7Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "If the labor market in Hungary and Romania becomes higher, wages will rise there. That would also improve their working conditions. I think that there will then be some sort of stabilization. That will take time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Economy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "If the labor market in Hungary and Romania becomes higher, wages will rise there. That would also improve their working conditions. I think that there will then be some sort of stabilization. That will take time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Economy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "If the labor market in Hungary and Romania becomes higher, wages will rise there. That would also improve their working conditions. I think that there will then be some sort of stabilization. That will take time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Economy";
            Debug.Log(input3.text);
        }
    }

    public void Question8() {
        question8Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question8Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "Dishonest competition. No European agreements on exchanging license plate information for violations of environmental zones.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Security";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "Dishonest competition. No European agreements on exchanging license plate information for violations of environmental zones.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Security";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "Dishonest competition. No European agreements on exchanging license plate information for violations of environmental zones.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Security";
            Debug.Log(input3.text);
        }
    }

    public void Question9() {
        question9Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question9Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "We don't want to take money from anyone. You need to find a position where an employer is able to pay everyone a wage that is normal in terms of the conditions in their country of residence. I wonder whether you have to pay six times as much as a Hungarian or Romanian earns in their own country when you are working in Europe. We want to keep our company afloat.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "We don't want to take money from anyone. You need to find a position where an employer is able to pay everyone a wage that is normal in terms of the conditions in their country of residence. I wonder whether you have to pay six times as much as a Hungarian or Romanian earns in their own country when you are working in Europe. We want to keep our company afloat.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "We don't want to take money from anyone. You need to find a position where an employer is able to pay everyone a wage that is normal in terms of the conditions in their country of residence. I wonder whether you have to pay six times as much as a Hungarian or Romanian earns in their own country when you are working in Europe. We want to keep our company afloat.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Question10() {
        question10Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question10Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "Everyone is upset when a truck driver has an accident and causes a traffic jam. Consumers also forget that it costs money to have products arrive at their shops or homes safely and on time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "Everyone is upset when a truck driver has an accident and causes a traffic jam. Consumers also forget that it costs money to have products arrive at their shops or homes safely and on time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "Everyone is upset when a truck driver has an accident and causes a traffic jam. Consumers also forget that it costs money to have products arrive at their shops or homes safely and on time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Question11() {
        question11Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question11Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "Employers also need more clarity. Our cargo goes to and from the Netherlands by all European member states and is transferred from truck to train and boat to vice versa. We work with hundreds of companies with local drivers, so called charters. It is unclear when you will have to pay what.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Rights & Responsibilities";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "Employers also need more clarity. Our cargo goes to and from the Netherlands by all European member states and is transferred from truck to train and boat to vice versa. We work with hundreds of companies with local drivers, so called charters. It is unclear when you will have to pay what.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Rights & Responsibilities";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "Employers also need more clarity. Our cargo goes to and from the Netherlands by all European member states and is transferred from truck to train and boat to vice versa. We work with hundreds of companies with local drivers, so called charters. It is unclear when you will have to pay what.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Rights & Responsibilities";
            Debug.Log(input3.text);
        }
    }

    public void Question12() {
        question12Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question12Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "I don't look at what a driver earns, but at what he costs. With a Dutch driver, you talk about 25 to 26 euros per hour. A Hungarian or Romanian costs half.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "I don't look at what a driver earns, but at what he costs. With a Dutch driver, you talk about 25 to 26 euros per hour. A Hungarian or Romanian costs half.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "I don't look at what a driver earns, but at what he costs. With a Dutch driver, you talk about 25 to 26 euros per hour. A Hungarian or Romanian costs half.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }
    }

    public void Question13() {
        question13Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question13Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "Feyenoord of course!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Decoy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "Feyenoord of course!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Decoy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "Feyenoord of course!");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Decoy";
            Debug.Log(input3.text);
        }
    }

    public void Question14() {
        question14Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);

        StartCoroutine(Type());
    }

    public void Question14Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "Stricter rules from Brussels are desperately needed. If this rule is ever abolished, it will be done for all truckers in the Netherlands. Then national hauliers will also be able to work with cheap Polish, Hungarian or Bulgarian drivers. In that case, there will no longer be a place for the Dutch driver in no time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Rights & Responsibilities";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "Stricter rules from Brussels are desperately needed. If this rule is ever abolished, it will be done for all truckers in the Netherlands. Then national hauliers will also be able to work with cheap Polish, Hungarian or Bulgarian drivers. In that case, there will no longer be a place for the Dutch driver in no time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Rights & Responsibilities";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "Stricter rules from Brussels are desperately needed. If this rule is ever abolished, it will be done for all truckers in the Netherlands. Then national hauliers will also be able to work with cheap Polish, Hungarian or Bulgarian drivers. In that case, there will no longer be a place for the Dutch driver in no time.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Rights & Responsibilities";
            Debug.Log(input3.text);
        }
    }

    public void Question15() {
        question15Button.interactable = false;
        themeSelectionCanvas.SetActive(false);

        interviewCanvas.SetActive(true);
        Debug.Log("Decoy statement.");

        StartCoroutine(Type());
    }

    public void Question15Selected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("LorryTruckInterview1-1", "I don't see how that's of relevance for this interview.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-1"));
            input1.text = "Decoy";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("LorryTruckInterview1-2", "I don't see how that's of relevance for this interview.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-2"));
            input2.text = "Decoy";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("LorryTruckInterview1-3", "I don't see how that's of relevance for this interview.");
            Debug.Log(PlayerPrefs.GetString("LorryTruckInterview1-3"));
            input3.text = "Decoy";
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

        form.AddField("entry.340684418", emailAnswer);
        form.AddField("entry.727809134", selection1);
        form.AddField("entry.821187719", selection2);
        form.AddField("entry.1349968296", selection3);

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

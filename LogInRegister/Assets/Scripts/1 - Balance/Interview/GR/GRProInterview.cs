﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GRProInterview : MonoBehaviour
{
    private bool interview1Completed;

    //initial starting canvas
    public GameObject startCanvas;

    //after START is selected from the Start Canvas, this canvas will appear
    public GameObject themeSelectionCanvas;
    public GameObject themeSelectionContinueButton;
    public GameObject themeDefinitionCanvas;

    public GameObject remainerCanvas;

    //public TextMeshProUGUI textDisplay;
    public Text textDisplay;

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

    public TextMeshProUGUI chosenTextDisplay;

    public AudioClip backgroundClip;
    public AudioSource backgroundSource;

    //Collecting Data through Google Forms
    public InputField inputEmail, input1, input2, input3;
    private string emailAnswer, selection1Answer, selection2Answer, selection3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeRkxP5ZCsqPnWQbTLHudiOcRjW21pyAdkV-flT31XniuS9hw/formResponse";

    //---------------------------------------------------------

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
            rankingCanvas.SetActive(true);
        }

        if (secondCounter <= 0) {
            Debug.Log("You have answered 3 questions! If you wish, you may proceed and collect more statements but this will not affect your score.");
            themeSelectionCanvas.SetActive(false);

            scoreCanvas.SetActive(true);
            feedbackCanvas.SetActive(true);
            //Send();
            //themeSelectionContinueButton.SetActive(true);
        }
    }

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
        //interview1Completed = false;
        //PlayerPrefs.SetInt("Interview1Completed", boolToInt(interview1Completed));
        SceneManager.LoadScene("GRJournalist");
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

            startCanvas.SetActive(false);

            rankingCanvas.SetActive(false);

            StartCoroutine(Type());
        }
        else { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);

            remainerCanvas.SetActive(false);

            rankingCanvas.SetActive(true);
        }
    }

    public void Social() {
        socialButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        //interviewCounter--;
        statement1Selected = false;


        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void SocialSelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Η ελεύθερη κυκλοφορία έχει συμβάλει στη δημιουργία μιας πολύ πιο πλούσιας και ποικιλόμορφης κοινωνίας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Social";
            Debug.Log(input1.text);
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Η ελεύθερη κυκλοφορία έχει συμβάλει στη δημιουργία μιας πολύ πιο πλούσιας και ποικιλόμορφης κοινωνίας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Social";
            Debug.Log(input2.text);
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Η ελεύθερη κυκλοφορία έχει συμβάλει στη δημιουργία μιας πολύ πιο πλούσιας και ποικιλόμορφης κοινωνίας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Social";
            Debug.Log(input3.text);
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Η ελεύθερη κυκλοφορία έχει συμβάλει στη δημιουργία μιας πολύ πιο πλούσιας και ποικιλόμορφης κοινωνίας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void Environment() {
        environmentButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void EnvironmentSelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Η ΕΕ έχει εισαγάγει πολύ αποτελεσματικά πρότυπα για τη φροντίδα του περιβάλλοντος.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Environment";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Η ΕΕ έχει εισαγάγει πολύ αποτελεσματικά πρότυπα για τη φροντίδα του περιβάλλοντος.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Environment";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Η ΕΕ έχει εισαγάγει πολύ αποτελεσματικά πρότυπα για τη φροντίδα του περιβάλλοντος.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Environment";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Η ΕΕ έχει εισαγάγει πολύ αποτελεσματικά πρότυπα για τη φροντίδα του περιβάλλοντος.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void Civil() {
        civilButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void RightsResponsibilitiesSelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Η ΕΕ παρέχει αυστηρά πρότυπα για δίκαιη μεταχείριση των πολιτών της ανεξαρτήτως κράτους μέλους.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Η ΕΕ παρέχει αυστηρά πρότυπα για δίκαιη μεταχείριση των πολιτών της ανεξαρτήτως κράτους μέλους.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Η ΕΕ παρέχει αυστηρά πρότυπα για δίκαιη μεταχείριση των πολιτών της ανεξαρτήτως κράτους μέλους.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Rights & Responsibilities";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Η ΕΕ παρέχει αυστηρά πρότυπα για δίκαιη μεταχείριση των πολιτών της ανεξαρτήτως κράτους μέλους.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void SafetySecurity() {
        safetySecurityButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void SafetySecuritySelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Η ΕΕ παρέχει αυστηρά πρότυπα για την υπεράσπιση της ασφάλειας και της προστασίας όλων των χωρών μελών.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Security";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Η ΕΕ παρέχει αυστηρά πρότυπα για την υπεράσπιση της ασφάλειας και της προστασίας όλων των χωρών μελών.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Security";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Η ΕΕ παρέχει αυστηρά πρότυπα για την υπεράσπιση της ασφάλειας και της προστασίας όλων των χωρών μελών.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Security";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Η ΕΕ παρέχει αυστηρά πρότυπα για την υπεράσπιση της ασφάλειας και της προστασίας όλων των χωρών μελών.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void Emotional() {
        emotionalButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void EmotionalSelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Θα ήμουν απόλυτα απογοητευμένος εάν η χώρα μου ψήφιζε να εγκαταλείψει την ΕΕ.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Emotional";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Θα ήμουν απόλυτα απογοητευμένος εάν η χώρα μου ψήφιζε να εγκαταλείψει την ΕΕ.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Emotional";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Θα ήμουν απόλυτα απογοητευμένος εάν η χώρα μου ψήφιζε να εγκαταλείψει την ΕΕ.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Emotional";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Θα ήμουν απόλυτα απογοητευμένος εάν η χώρα μου ψήφιζε να εγκαταλείψει την ΕΕ.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void Economic() {
        economicButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void EconomicSelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", " Η ιδιότητα του μέλους της ΕΕ είχε πάρα πολύ θετικό αντίκτυπο στην οικονομία της χώρας μας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Economic";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", " Η ιδιότητα του μέλους της ΕΕ είχε πάρα πολύ θετικό αντίκτυπο στην οικονομία της χώρας μας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Economic";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", " Η ιδιότητα του μέλους της ΕΕ είχε πάρα πολύ θετικό αντίκτυπο στην οικονομία της χώρας μας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input2.text = "Economic";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", " Η ιδιότητα του μέλους της ΕΕ είχε πάρα πολύ θετικό αντίκτυπο στην οικονομία της χώρας μας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void Political() {
        politicalButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());

    }

    public void PoliticalSelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Οι 4 ελευθερίες της ΕΕ ήταν ωφέλιμες για τη χώρα μας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Political";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Οι 4 ελευθερίες της ΕΕ ήταν ωφέλιμες για τη χώρα μας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Political";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Οι 4 ελευθερίες της ΕΕ ήταν ωφέλιμες για τη χώρα μας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Political";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Οι 4 ελευθερίες της ΕΕ ήταν ωφέλιμες για τη χώρα μας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void Historic() {
        historicButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void HistoricSelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Για όλους εμάς τους Ευρωπαίους - η κοινή ιστορία μας έχει σημασία. Δεν θέλουμε να επαναλάβουμε τα λάθη του παρελθόντος.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Historic";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Για όλους εμάς τους Ευρωπαίους - η κοινή ιστορία μας έχει σημασία. Δεν θέλουμε να επαναλάβουμε τα λάθη του παρελθόντος.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Historic";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Για όλους εμάς τους Ευρωπαίους - η κοινή ιστορία μας έχει σημασία. Δεν θέλουμε να επαναλάβουμε τα λάθη του παρελθόντος.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Historic";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Για όλους εμάς τους Ευρωπαίους - η κοινή ιστορία μας έχει σημασία. Δεν θέλουμε να επαναλάβουμε τα λάθη του παρελθόντος.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void Culture() {
        cultureButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void CultureSelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Η ιδιότητα του μέλους της ΕΕ συνέβαλε στη δημιουργία μιας κοινής πολιτιστικής ταυτότητας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Culture";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Η ιδιότητα του μέλους της ΕΕ συνέβαλε στη δημιουργία μιας κοινής πολιτιστικής ταυτότητας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Culture";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Η ιδιότητα του μέλους της ΕΕ συνέβαλε στη δημιουργία μιας κοινής πολιτιστικής ταυτότητας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Culture";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Η ιδιότητα του μέλους της ΕΕ συνέβαλε στη δημιουργία μιας κοινής πολιτιστικής ταυτότητας.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
        }
    }

    public void Geography() {
        geographyButton.interactable = false;
        themeSelectionCanvas.SetActive(false);

        remainerCanvas.SetActive(true);

        //interviewCounter--;
        //secondCounter--;
        statement1Selected = false;

        animText.SetTrigger("Change");

        StartCoroutine(Type());
    }

    public void GeographySelected() {

        if (interviewCounter == 5) {
            PlayerPrefs.SetString("BrexitProInterview1", "Η ευρωπαϊκή ταυτότητα σημαίνει ότι δεν έχει σημασία που έχει γεννηθεί κανείς.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview1"));
            input1.text = "Geography";
        }

        if (interviewCounter == 4) {
            PlayerPrefs.SetString("BrexitProInterview2", "Η ευρωπαϊκή ταυτότητα σημαίνει ότι δεν έχει σημασία που έχει γεννηθεί κανείς.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview2"));
            input2.text = "Geography";
        }

        if (interviewCounter == 3) {
            PlayerPrefs.SetString("BrexitProInterview3", "Η ευρωπαϊκή ταυτότητα σημαίνει ότι δεν έχει σημασία που έχει γεννηθεί κανείς.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview3"));
            input3.text = "Geography";
        }

        if (interviewCounter == 2) {
            PlayerPrefs.SetString("BrexitProInterview4", "Η ευρωπαϊκή ταυτότητα σημαίνει ότι δεν έχει σημασία που έχει γεννηθεί κανείς.");
            Debug.Log(PlayerPrefs.GetString("BrexitProInterview4"));
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

        form.AddField("entry.73471519", emailAnswer);
        form.AddField("entry.1263600930", selection1);
        form.AddField("entry.1537282767", selection2);
        form.AddField("entry.36802520", selection3);

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

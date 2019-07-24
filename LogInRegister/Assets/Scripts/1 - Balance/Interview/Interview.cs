using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Interview : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    
    [SerializeField]
    private float typingSpeed;

    public GameObject continueButton;

    private bool isRound1Finished = false;
    private bool isRound2Finished = false;
    private bool isRound3Finished = false;
    private bool isRound4Finished = false;

    public GameObject startCanvas;

    public GameObject stakeSelectionCanvas;


    //these are what are first visible when the Interview tool loads after the player presses PLAY
    public GameObject questionBQ;
    public GameObject interviewTitle;
    public GameObject interviewSubTitle;
    public GameObject leftCharacter;
    public GameObject rightCharacter;
    public GameObject questionBox;


    //public GameObject speechBubble;


    public GameObject proPerson;
    public GameObject antiPerson;
    public GameObject proResponseBox;
    public GameObject antiResponseBox;
    public GameObject proBQ;
    public GameObject antiBQ;
    public GameObject issueText;

    //public GameObject[] proInterviewQuestions;
    //public GameObject[] proInterviewResponses;

    //public GameObject[] antiInterviewQuestions;
    //public GameObject[] antiInterviewResponses;

    //-----------Round 1----------------------
    public GameObject btnFreedomOfMovement;
    public GameObject btnImmigration;
    public GameObject btnEnvironment;
    //----------------------------------------

    //-----------Round 2----------------------
    public GameObject btnEconomy;
    public GameObject btnSovereignty;
    public GameObject btnFeelings;
    //----------------------------------------

    //-----------Round 3----------------------
    public GameObject btnJobs;
    public GameObject btnOpportunitiesForAll;
    public GameObject btnCulturalCloseness;
    //----------------------------------------

    //-----------Round 4----------------------
    public GameObject btnSecurity;
    public GameObject btnFairTreatment;
    public GameObject btnEmotions;
    //----------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);

        //characters and speech bubbles default set as false to begin with
        proPerson.SetActive(false);
        antiPerson.SetActive(false);
        //speechBubble.SetActive(false);
        proResponseBox.SetActive(false);
        antiResponseBox.SetActive(false);
        proBQ.SetActive(false);
        antiBQ.SetActive(false);
        issueText.SetActive(false);

        //-----------Round 1----------------------
        /*questionBQ.SetActive(true);
        interviewTitle.SetActive(true);
        interviewSubTitle.SetActive(true);
        leftCharacter.SetActive(true);
        rightCharacter.SetActive(true);
        questionBox.SetActive(true);

        //Questions btn
        btnFreedomOfMovement.SetActive(true);
        btnImmigration.SetActive(true);
        btnEnvironment.SetActive(true);*/
        //----------------------------------------

        //-----------Round 2----------------------
        btnEconomy.SetActive(false);
        btnSovereignty.SetActive(false);
        btnFeelings.SetActive(false);
        //----------------------------------------

        //-----------Round 3----------------------
        btnJobs.SetActive(false);
        btnOpportunitiesForAll.SetActive(false);
        btnCulturalCloseness.SetActive(false);
        //----------------------------------------

        //-----------Round 4----------------------
        btnSecurity.SetActive(false);
        btnFairTreatment.SetActive(false);
        btnEmotions.SetActive(false);
        //----------------------------------------


    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }
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
        stakeSelectionCanvas.SetActive(true);

        //-----------Round 1----------------------
        /*questionBQ.SetActive(true);
        interviewTitle.SetActive(true);
        interviewSubTitle.SetActive(true);
        leftCharacter.SetActive(true);
        rightCharacter.SetActive(true);
        questionBox.SetActive(true);

        //Questions btn
        btnFreedomOfMovement.SetActive(true);
        btnImmigration.SetActive(true);
        btnEnvironment.SetActive(true);*/
        //----------------------------------------
    }

    public void Round1NextSentence() {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";

            proPerson.SetActive(false);
            proResponseBox.SetActive(false);
            proBQ.SetActive(false);

            antiPerson.SetActive(true);
            antiResponseBox.SetActive(true);
            antiBQ.SetActive(true);
            //speechBubble.SetActive(true);

            StartCoroutine(Type());
        } else { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);

            proPerson.SetActive(false);
            proResponseBox.SetActive(false);
            proBQ.SetActive(false);

            antiPerson.SetActive(false);
            antiResponseBox.SetActive(false);
            antiBQ.SetActive(false);
            //speechBubble.SetActive(false);

            //need to find a way to say when each set of three are done it is set as true for that round
            questionBQ.SetActive(true);
            interviewTitle.SetActive(true);
            interviewSubTitle.SetActive(true);
            leftCharacter.SetActive(true);
            rightCharacter.SetActive(true);
            questionBox.SetActive(true);
            isRound1Finished = true;

            if (isRound1Finished == true) {
                btnFreedomOfMovement.SetActive(false);
                btnImmigration.SetActive(false);
                btnEnvironment.SetActive(false);

                btnEconomy.SetActive(true);
                btnSovereignty.SetActive(true);
                btnFeelings.SetActive(true);
            }
        }
    }

    public void Round2NextSentence() {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";

            proPerson.SetActive(false);
            proResponseBox.SetActive(false);
            proBQ.SetActive(false);
            antiPerson.SetActive(true);
            antiResponseBox.SetActive(true);
            antiBQ.SetActive(true);

            //speechBubble.SetActive(true);

            StartCoroutine(Type());
        } else { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);
            //need to find a way to say when each set of three are done it is set as true for that round
            questionBQ.SetActive(true);
            interviewTitle.SetActive(true);
            interviewSubTitle.SetActive(true);
            leftCharacter.SetActive(true);
            rightCharacter.SetActive(true);
            questionBox.SetActive(true);

            proPerson.SetActive(false);
            proResponseBox.SetActive(false);
            proBQ.SetActive(false);

            antiPerson.SetActive(false);
            antiResponseBox.SetActive(false);
            antiBQ.SetActive(false);
            //speechBubble.SetActive(false);

            isRound1Finished = false;
            isRound2Finished = true;

            if (isRound2Finished == true) {
                btnEconomy.SetActive(false);
                btnSovereignty.SetActive(false);
                btnFeelings.SetActive(false);

                btnJobs.SetActive(true);
                btnOpportunitiesForAll.SetActive(true);
                btnCulturalCloseness.SetActive(true);
            }
        }
    }

    public void Round3NextSentence() {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";

            proPerson.SetActive(false);
            proResponseBox.SetActive(false);
            proBQ.SetActive(false);
            antiPerson.SetActive(true);
            antiResponseBox.SetActive(true);
            antiBQ.SetActive(true);
            //speechBubble.SetActive(true);

            StartCoroutine(Type());
        } else { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);
            //need to find a way to say when each set of three are done it is set as true for that round
            questionBQ.SetActive(true);
            interviewTitle.SetActive(true);
            interviewSubTitle.SetActive(true);
            leftCharacter.SetActive(true);
            rightCharacter.SetActive(true);
            questionBox.SetActive(true);

            proPerson.SetActive(false);
            proResponseBox.SetActive(false);
            proBQ.SetActive(false);
            antiPerson.SetActive(false);
            antiResponseBox.SetActive(false);
            antiBQ.SetActive(false);
            //speechBubble.SetActive(false);

            isRound2Finished = false;
            isRound3Finished = true;
        }

        if (isRound3Finished == true) {
            btnJobs.SetActive(false);
            btnOpportunitiesForAll.SetActive(false);
            btnCulturalCloseness.SetActive(false);

            btnSecurity.SetActive(true);
            btnFairTreatment.SetActive(true);
            btnEmotions.SetActive(true);
        }
    }

    public void Round4NextSentence() {

        continueButton.SetActive(false);

        if (index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";

            proPerson.SetActive(false);
            proResponseBox.SetActive(false);
            proBQ.SetActive(false);
            antiPerson.SetActive(true);
            antiResponseBox.SetActive(true);
            antiBQ.SetActive(true);
            //speechBubble.SetActive(true);

            StartCoroutine(Type());
        } else { //if there is no more dialogue the continue button isn't active and no text will appear
            textDisplay.text = "";
            continueButton.SetActive(false);
            //need to find a way to say when each set of three are done it is set as true for that round
            //all the necessary disappear
            questionBQ.SetActive(false);
            interviewTitle.SetActive(false);
            interviewSubTitle.SetActive(false);
            leftCharacter.SetActive(false);
            rightCharacter.SetActive(false);
            questionBox.SetActive(false);

            proPerson.SetActive(false);
            proResponseBox.SetActive(false);
            proBQ.SetActive(false);
            antiPerson.SetActive(false);
            antiResponseBox.SetActive(false);
            antiBQ.SetActive(false);
            //speechBubble.SetActive(false);

            isRound3Finished = false;
            isRound4Finished = true;

            if (isRound4Finished == true) {
                //show feedback screen/ final screen for tool

            }
        }
    }


    //-----------Round 1----------------------
    public void FreedomOfMovement() {
        startCanvas.SetActive(false);
        stakeSelectionCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnFreedomOfMovement.SetActive(false);
        btnImmigration.SetActive(false);
        btnEnvironment.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    public void Immigration() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnImmigration.SetActive(false);
        btnFreedomOfMovement.SetActive(false);
        btnEnvironment.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    public void Environment() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnEnvironment.SetActive(false);
        btnFreedomOfMovement.SetActive(false);
        btnImmigration.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    //----------------------------------------

    //-----------Round 2----------------------
    public void Economy() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnEconomy.SetActive(false);
        btnSovereignty.SetActive(false);
        btnFeelings.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    public void Sovereignty() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);
        
        btnSovereignty.SetActive(false);
        btnEconomy.SetActive(false);
        btnFeelings.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    public void Feelings() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnFeelings.SetActive(false);
        btnEconomy.SetActive(false);
        btnSovereignty.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }
    //----------------------------------------

    //-----------Round 3----------------------
    public void Jobs() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnJobs.SetActive(false);
        btnOpportunitiesForAll.SetActive(false);
        btnCulturalCloseness.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    public void OpportunitiesForAll() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnOpportunitiesForAll.SetActive(false);
        btnJobs.SetActive(false);
        btnCulturalCloseness.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    public void CulturalCloseness() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnCulturalCloseness.SetActive(false);
        btnJobs.SetActive(false);
        btnOpportunitiesForAll.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }
    //----------------------------------------

    //-----------Round 4----------------------
    public void Security() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnSecurity.SetActive(false);
        btnFairTreatment.SetActive(false);
        btnEmotions.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    public void FairTreatment() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnFairTreatment.SetActive(false);
        btnSecurity.SetActive(false);
        btnEmotions.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }

    public void Emotions() {
        startCanvas.SetActive(false);

        questionBQ.SetActive(false);
        interviewTitle.SetActive(false);
        interviewSubTitle.SetActive(false);
        leftCharacter.SetActive(false);
        rightCharacter.SetActive(false);
        questionBox.SetActive(false);

        btnEmotions.SetActive(false);
        btnSecurity.SetActive(false);
        btnFairTreatment.SetActive(false);

        proPerson.SetActive(true);
        //speechBubble.SetActive(true);
        proResponseBox.SetActive(true);
        proBQ.SetActive(true);
        issueText.SetActive(true);

        StartCoroutine(Type());
    }
    //----------------------------------------
}

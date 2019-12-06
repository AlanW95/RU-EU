using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DiscussionAttitudes : MonoBehaviour
{

    public TextMeshProUGUI statementTextDisplay;

    //Discussion text  
    public string[] discussion2;
    private int index;

    [SerializeField]
    private float typingSpeed;

    public GameObject continueButton;

    //background
    public GameObject toolBG;

    //3 characters for discussion tool
    public GameObject proCharacter, antiCharacter, undecidedCharacter;

    public Animator animPro, animAnti, animUndecided;
    public Animator animText;

    //interview style response box
    public GameObject responseBox;

    //Dialogue Bool Finish
    private bool isTheme1Finished = false;
    private bool isTheme2Finished = false;
    private bool isTheme3Finished = false;
    private bool isTheme4Finished = false;
    private bool isTheme5Finished = false;
    private bool isTheme6Finished = false;

    //Dialogue Context (before the dialogue begins)
    public GameObject contextTheme1, contextTheme2, contextTheme3, contextTheme4, contextTheme5, contextTheme6;
    public GameObject contextBG;

    public GameObject playerSelection;
    public GameObject[] character1Text, character2Text, character3Text;
    public TextMeshProUGUI theme1Character1, theme2Character1, theme3Character1, theme4Character1, theme5Character1, theme6Character1;
    public TextMeshProUGUI theme1Character2, theme2Character2, theme3Character2, theme4Character2, theme5Character2, theme6Character2;
    public TextMeshProUGUI theme1Character3, theme2Character3, theme3Character3, theme4Character3, theme5Character3, theme6Character3;
    private bool hasPlayerSelected = false;

    private bool isDialogueFinished = false;

    //For Bottom
    private bool proDiscussion1, antiDiscussion1 = false;
    private bool proDiscussion2, antiDiscussion2 = false;
    private bool proDiscussion3, antiDiscussion3 = false;
    private bool proDiscussion4, antiDiscussion4 = false;
    private bool proDiscussion5, antiDiscussion5 = false;
    private bool proDiscussion6, antiDiscussion6 = false;

    public GameObject task3;

    private int discussionCount = 0;

    private int countdown = 6;

    public GameObject startCanvas;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);

        FloatingTextController.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (statementTextDisplay.text == discussion2[index]) {
            continueButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("AttitudesMobileWorkplace");
        }

        //StatementsSelected();

        if (countdown == 0) {
            //give feedback
            //this is placement at the moment
            //task2FullCanvas.SetActive(false);
            //task3.SetActive(true);
            Debug.Log("Discussion has been complete!");
            task3.SetActive(true);

            toolBG.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("AttitudesMobileWorkplace");
        }
    }

    IEnumerator Type() {
        foreach (char letter in discussion2[index].ToCharArray()) {
            statementTextDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ReturnToTheMobileWorkplace() {
        SceneManager.LoadScene("AttitudesMobileWorkplace");
    }

    //Task 2 is relatively the same as the original way we had the Discussion tool but this time after each one, 
    //the player will be asked if they find the pro or anti more convincing to be used later on.

    //originally was StartTask2
    public void StartDialogue() {
        Debug.Log("This button has been pressed!");

        startCanvas.SetActive(false);

        toolBG.SetActive(true);
        proCharacter.SetActive(false);
        antiCharacter.SetActive(false);
        undecidedCharacter.SetActive(false);

        responseBox.SetActive(false);

        playerSelection.SetActive(false);

        /* When the tool first begins the player will be presented with the first context.
         * Everything will be SetActive(false) except the context for Social to begin.
         */

        //context statements for the dialogue
        //set false as they don't appear straight away
        //contextTheme1 is first, after each dialogue and selection, it goes to the next one
        contextBG.SetActive(true);
        contextTheme1.SetActive(true);
        contextTheme2.SetActive(false);
        contextTheme3.SetActive(false);
        contextTheme4.SetActive(false);
        contextTheme5.SetActive(false);
        contextTheme6.SetActive(false);

        //animText.SetTrigger("Change"); //for player if added later on
    }

    public void IfFinished() {
        //if either or are finished - go back to the screen
        /*if (isDialogueFinished) {

            toolBG.SetActive(false);
        }

        //if both are finished - go to feedback
        if (isDialogueFinished == true) {
            //give feedback
            //this is placement at the moment
            //task2FullCanvas.SetActive(false);
            //task3.SetActive(true);
            Debug.Log("Discussion has been complete!");
            task3.SetActive(true);

            toolBG.SetActive(false);
        }*/

        if (countdown == 0) {
            Debug.Log("Discussion has been complete!");
            task3.SetActive(true);
            toolBG.SetActive(false);
        }
    }

    //-------------------------------------------------------------
    public void Theme1NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            animText.SetTrigger("Change");

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isTheme1Finished = true;

            if (isTheme1Finished == true) {
                contextTheme1.SetActive(false);
                contextBG.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);


                character1Text[0].SetActive(true);
                character2Text[0].SetActive(true);
                character3Text[0].SetActive(true);
                theme1Character1.text = "I actually feel that i am an European citizen and that i have enough information about my rights.";
                theme1Character2.text = "I am British, and not European and i have no need to learn more about my rights as EU citizens.";
                theme1Character3.text = "I am first of all Greek, but i would like to be better informed about my rights as an EU citizen.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress

                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme1Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            character1Text[0].SetActive(false);
            character2Text[0].SetActive(false);
            character3Text[0].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available

            contextTheme2.SetActive(true);
            contextBG.SetActive(true);
        }
    }

    public void Theme2NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isTheme2Finished = true;

            if (isTheme2Finished == true) {
                contextTheme2.SetActive(false);
                contextBG.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[1].SetActive(true);
                character2Text[1].SetActive(true);
                character3Text[1].SetActive(true);

                theme2Character1.text = "A European economic and monetary union with 1 single currency is essential for keeping EU competitive.";
                theme2Character2.text = "The Euro and a monetary union is not advantageous for the EU.";
                theme2Character3.text = "Regarding if a single monetary union with a single currency is good or not, is not so easy to say per see, since so many factors play a role.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme2Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            character1Text[1].SetActive(false);
            character2Text[1].SetActive(false);
            character3Text[1].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
            contextTheme3.SetActive(true);
            contextBG.SetActive(true);
        }
    }

    public void Theme3NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isTheme3Finished = true;

            if (isTheme3Finished == true) {
                contextTheme3.SetActive(false);
                contextBG.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[2].SetActive(true);
                character2Text[2].SetActive(true);
                character3Text[2].SetActive(true);

                theme3Character1.text = "We can take for sure that the EU is trustworthy and work for the good of the EU citizen.";
                theme3Character2.text = "Other than the bureaucracy, EU is mostly trustworthy and is trying to work for the good of the EU citizen.";
                theme3Character3.text = "The EU is not very trustworthy and is not working for the good of all EU citizen.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme3Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            character1Text[2].SetActive(false);
            character2Text[2].SetActive(false);
            character3Text[2].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
            contextTheme4.SetActive(true);
            contextBG.SetActive(true);
        }
    }

    public void Theme4NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isTheme4Finished = true;

            if (isTheme4Finished == true) {
                contextTheme4.SetActive(false);
                contextBG.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[3].SetActive(true);
                character2Text[3].SetActive(true);
                character3Text[3].SetActive(true);

                theme4Character1.text = "A common EU policy on migration would benefit Greece very much.";
                theme4Character2.text = "It is essential that EU have one common policy on migration.";
                theme4Character3.text = "A common EU policy on migration is not necessary and not of good for UK.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme4Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            character1Text[3].SetActive(false);
            character2Text[3].SetActive(false);
            character3Text[3].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into UnityAnalytics when available

            //instead of moving on to the next area, we will give the player feedback at this stage, with a final tool feedback screen.
            contextTheme5.SetActive(true);
            contextBG.SetActive(true);
        }
    }

    public void Theme5NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isTheme5Finished = true;

            if (isTheme5Finished == true) {
                contextTheme5.SetActive(false);
                contextBG.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[4].SetActive(true);
                character2Text[4].SetActive(true);
                character3Text[4].SetActive(true);

                theme5Character1.text = "Throughout the history of the EC and EU the peacekeeping aspect has been very important and beneficial for the prosperity of Europe.";
                theme5Character2.text = "Throughout the history of the EC and EU the peacekeeping aspect deserves recognition.";
                theme5Character3.text = "The relevance of peacekeeping function of EC/EU in Europe is exaggerated, and should not be compared with that of NATO.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme5Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            character1Text[4].SetActive(false);
            character2Text[4].SetActive(false);
            character3Text[4].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //StartTask3();

            //store data
            //put into UnityAnalytics when available

            //instead of moving on to the next area, we will give the player feedback at this stage, with a final tool feedback screen.
            contextTheme6.SetActive(true);
            contextBG.SetActive(true);
        }
    }

    public void Theme6NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isTheme6Finished = true;

            if (isTheme6Finished == true) {
                contextTheme6.SetActive(false);
                contextBG.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[5].SetActive(true);
                character2Text[5].SetActive(true);
                character3Text[5].SetActive(true);

                theme6Character1.text = "The Dutch government as well as European commission should focus more on environmental and climate change issues.";
                theme6Character2.text = "We have surely more important problems to solve than using more resources on environmental and climate changes.";
                theme6Character3.text = "A common energy policy among EU member states is very important as it is for Germany.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme6Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            character1Text[5].SetActive(false);
            character2Text[5].SetActive(false);
            character3Text[5].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
        }
    }

    //---------------------------------------------------------------------------------

    public void Theme1() {
        contextTheme1.SetActive(false);
        contextBG.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme2() {
        contextTheme2.SetActive(false);
        contextBG.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme3() {
        contextTheme3.SetActive(false);
        contextBG.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme4() {
        contextTheme4.SetActive(false);
        contextBG.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme5() {
        contextTheme5.SetActive(false);
        contextBG.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme6() {
        contextTheme6.SetActive(false);
        contextBG.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    //-------------------------------------------------------------------

        //Discussion Theme 1 - SOCIAL

    //Add these to the Continue button then it takes
    public void Person1Theme1Selected() {
        PlayerPrefs.SetString("AttitudesDiscussion1", "I actually feel that i am an European citizen and that i have enough information about my rights.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme1Selected() {
        PlayerPrefs.SetString("AttitudesDiscussion1", "I am British, and not European and i have no need to learn more about my rights as EU citizens.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    public void Person3Theme1Selected() {
        PlayerPrefs.SetString("AttitudesDiscussion1", "I am first of all Greek, but i would like to be better informed about my rights as an EU citizen.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    //--------------------------------------------------------------

        //Discussion Theme 2 - ECONOMIC

    //Add these to the Continue button then it takes
    public void Person1Theme2Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion2", "A European economic and monetary union with 1 single currency is essential for keeping EU competitive. ");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme2Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion2", "The Euro and a monetary union is not advantageous for the EU.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme2Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion2", "Regarding if a single monetary union with a single currency is good or not, is not so easy to say per se, since so many factors play a role.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //--------------------------------------------------------------

        //Discussion Theme 3 - POLITICAL

    //Add these to the Continue button then it takes
    public void Person1Theme3Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion3", "We can take for sure that the EU is trustworthy and work for the good of the EU citizen.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme3Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion3", "Other than the bureaucracy, EU is mostly trustworthy and is trying to work for the good of the EU citizen.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme3Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion3", "The EU is not very trustworthy and is not working for the good of all EU citizen.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //--------------------------------------------------------------------

        //Discussion Theme 4 - SAFETY & SECURITY

    //Add these to the Continue button then it takes
    public void Person1Theme4Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion4", "A common EU policy on migration would benefit Greece very much.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme4Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion4", "It is essential that EU have one common policy on migration.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme4Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion4", "A common EU policy on migration is not necessary and not of good for UK. ");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //--------------------------------------------------------------------------------------

        //Discussion Theme 5 - HISTORICAL

    //Add these to the Continue button then it takes
    public void Person1Theme5Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion5", "Throughout the history of the EC and EU the peacekeeping aspect has been very important and beneficial for the prosperity of EU.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme5Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion5", "Throughout the history of the EC and EU the peacekeeping aspect deserves recognition.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme5Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion5", "The relevance of peacekeeping function of EC/EU in Europe is exaggerated, and should not be compared with that of NATO. ");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //---------------------------------------------------------------------------

        //Discussion Theme 6 - ENVIRONMENTAL

    //Add these to the Continue button then it takes
    public void Person1Theme6Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion6", "The Dutch government as well as European commission should focus more on environmental and climate change issues.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme6Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion6", "We have surely more important problems to solve than using more resources on environmental and climate changes.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme6Selected() {

        PlayerPrefs.SetString("AttitudesDiscussion6", "A common energy policy among EU member states is very important as it is for Germany.");
        Debug.Log(PlayerPrefs.GetString("AttitudesDiscussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);
    }

    //----------------------------------------------------------------------------------------
}
